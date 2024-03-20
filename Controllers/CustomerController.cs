using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly GeneralStoreDbContext _ctx;
        public CustomerController(GeneralStoreDbContext dbContext)
        {
            _ctx = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<CustomerIndexViewModel> customers = await _ctx.Customers
            .Select(customer => new CustomerIndexViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            })
                .ToListAsync();

            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is invalid.";
                return View(model);
            }

            Customer entity = new()
            {
                Name = model.Name,
                Email = model.Email
            };
                _ctx.Customers.Add(entity);

            if (await _ctx.SaveChangesAsync() != 1)
            {
                TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
                return View(model);
            }

                return RedirectToAction(nameof(Index));
        }
    }
}