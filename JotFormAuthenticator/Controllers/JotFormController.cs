using JotFormAuthenticator.Models;
using JotFormAuthenticator.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JotFormAuthenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JotFormController : ControllerBase
    {
        private readonly IFormRepository _repository;

        public JotFormController (IFormRepository Repository)
        {
            _repository = Repository;
        }

        [HttpGet]
        public List<FormModel> Get()
        {
            return _repository.GetForms();
        }

        [HttpGet]
        [Route("GetFields")]
        public List<FieldModel> GetFields()
        {
            return _repository.GetAllFields();
        }

        [HttpGet]
        [Route("GetSubmission")]
        public FormModel GetSubmission(long SubmissionID)
        {
            FormModel form = _repository.GetForm(SubmissionID);

            List<FieldModel> fields = form.FormFields;

            return form;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<FormModel> GetAllForms()
        {
            return _repository.GetAllActiveForms();
        }

        [HttpPost]
        public void Post([FromForm] JotFormModel Form)
        {
            var Rawfields = JsonConvert.DeserializeObject<Dictionary<string, object>>(Form.RawRequest);
            List<FieldModel> fields = FormFields(Rawfields, Form.SubmissionID);

            FormModel form = new FormModel {
                FormID = Form.FormID,
                FormName = Form.FormTitle,
                SubmissionID = Form.SubmissionID,
                FormFields = fields
            };

            _repository.AddForm(form);
        }

        private List<FieldModel> FormFields(Dictionary<string, object> Fields, long SubmissionID, string FormName = null)
        {
            List<FieldModel> fields = new List<FieldModel>();

            foreach ( var f in Fields )
            {
                if ( f.Value is string)
                {
                    if ( f.Key == "slug" || f.Key == "event_id" )
                    {

                    }
                    else {
                        fields.Add(new FieldModel {
                            FieldName = f.Key,
                            FieldParentName = FormName,
                            FieldValue = f.Value.ToString(),
                            SubmissionID = SubmissionID
                        });
                    }
                }
                else
                {
                    fields.AddRange(FormFields(JsonConvert.DeserializeObject<Dictionary<string, object>>(f.Value.ToString()), SubmissionID, f.Key));
                }
            }
            return fields;
        }

    }
}