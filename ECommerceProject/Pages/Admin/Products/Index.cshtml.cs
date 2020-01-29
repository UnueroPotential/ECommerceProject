﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceProject.Data;

namespace ECommerceProject.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ECommerceProject.Data.ApplicationDbContext _context;

        public IndexModel(ECommerceProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            try
            {
                Product = await _context.Products.Include(p => p.SubCategory)
                .Include(x=>x.Images).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}