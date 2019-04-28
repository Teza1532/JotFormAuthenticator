﻿using JotFormAuthenticator.DBContext;
using JotFormAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Forms.ToList();
        }
    }
}
