using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JotFormAuthenticator.Models;
using JotFormAuthenticator.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAnalysis.Controllers
{
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        private readonly IFormRepository _repository;

        public FormController(IFormRepository Repository)
        {
            _repository = Repository;
        }

        // GET: /<controller>/
        [HttpGet("[action]")]
        public List<FormModel> GetForms()
        {
            List < FormModel > forms = _repository.GetAcceptedForms();

            foreach(FormModel form in forms)
            {
                foreach(FieldModel field in form.FormFields)
                {

                }
            }

            return forms;
        }
    }
}
