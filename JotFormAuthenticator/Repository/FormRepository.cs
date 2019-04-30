using JotFormAuthenticator.DBContext;
using JotFormAuthenticator.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JotFormAuthenticator.Repository
{
    public class FormRepository : IFormRepository
    {
        private FormDBContext _context;

        public FormRepository(FormDBContext FormDBContext)
        {
            _context = FormDBContext;
        }

        public void AddForm(FormModel Form)
        {
            _context.Add(Form);
            _context.SaveChanges();
        }

        public List<FormModel> GetForms()
        {
            return _context.Forms
                .Include(f => f.FormFields).ToList();
            
        }

        public FormModel GetFormSubmission(long SubmissionID)
        {

            return _context.Forms.Where(f => f.SubmissionID == SubmissionID).FirstOrDefault();
        }

        public List<FormModel> GetAllActiveForms()
        {
            return _context.Forms.Where(f => f.Accepted == null)
                .GroupBy(f => f.FormID)
                .Select(f => f.First())
                .ToList();
        }

        public List<FieldModel> GetAllFields()
        {
            return _context.Fields.ToList();
        }
    }
}
