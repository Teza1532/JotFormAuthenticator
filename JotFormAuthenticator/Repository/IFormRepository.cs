using JotFormAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JotFormAuthenticator.Repository
{
    public interface IFormRepository
    {
        void AddForm(FormModel Form);
        List<FormModel> GetForms();
    }
}
