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
        List<FormModel> GetAllActiveForms();
        FormModel GetForm(long SubmissionID);
        List<FieldModel> GetAllFields();
        FormModel GetFormFields(int FormID);
        List<FieldModel> getFields(int FormID);
        int AcceptForm(int FormID);
        int RejectForm(int FormID);
        List<FormModel> GetAcceptedForms();
        List<FormModel> GetRejectedForms();
    }
}
