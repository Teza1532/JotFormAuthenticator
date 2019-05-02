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
                .Where(f => f.Accepted == null)
                .OrderByDescending(f => f.CreatedOn)
                .ToList();
        }

        public List<FormModel> GetAcceptedForms()
        {
            return _context.Forms
                .Where(f => f.Accepted == true)
                .OrderByDescending(f => f.CreatedOn)
                .ToList();
        }

        public List<FormModel> GetRejectedForms()
        {
            return _context.Forms
                .Where(f => f.Accepted == false)
                .OrderByDescending(f => f.CreatedOn)
                .ToList();
        }



        public FormModel GetFormFields(int FormID)
        {
            return _context.Forms
                .Where(f => f.FormModelID == FormID)
                .Where(f => f.Accepted == null)
                .Include(f => f.FormFields)
                .FirstOrDefault();
        }

        public List<FieldModel> getFields(int FormID)
        {
            return _context.Fields
                .Where(f => f.FormModelID == FormID)
                .ToList();
        }

        public FormModel GetForm(long SubmissionID)
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

        public int AcceptForm(int FormID)
        {
            FormModel form = _context.Forms
                 .Where(f => FormID == f.FormModelID)
                 .Where(f => f.Accepted == null)
                 .SingleOrDefault();

            if ( form != null )
            {
                form.Accepted = true;
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int RejectForm(int FormID)
        {
            FormModel form = _context.Forms
                 .Where(f => FormID == f.FormID)
                 .Where(f => f.Accepted == null)
                 .SingleOrDefault();

            if ( form != null )
            {
                form.Accepted = false;
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
