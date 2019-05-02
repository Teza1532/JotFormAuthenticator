using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JotFormAuthenticator.Models;
using JotFormAuthenticator.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormAuthenticator.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IFormRepository _repository;

        public HomeController(IFormRepository Repository)
        {
            _repository = Repository;
        }

        [HttpGet("[action]")]
        public List<FormModel> Forms() => _repository.GetForms();

        [HttpGet("[action]")]
        public List<FormModel> AcceptedForms() => _repository.GetAcceptedForms();

        [HttpGet("[action]")]
        public List<FormModel> RejectedForms() => _repository.GetRejectedForms();

        [HttpGet("[action]/{FormID}")]
        public List<FieldModel> FormFields(int FormID) => _repository.getFields(FormID);

        [HttpPut("[action]/{FormID}")]
        public int AcceptForm(int FormID) => _repository.AcceptForm(FormID);

        [HttpPut("[action]/{FormID}")]
        public int RejectForm(int FormID) => _repository.RejectForm(FormID);
    }
}