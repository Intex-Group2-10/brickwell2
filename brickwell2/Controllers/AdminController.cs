using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using brickwell2.Models;
using System;
using System.Diagnostics;
using brickwell2.Models.ViewModels;

namespace brickwell2.Controllers;

public class AdminController : Controller
{
    private ILegoRepository _repo;
    
    public AdminController(ILegoRepository legoInfo) 
    {
        _repo = legoInfo;
    }
    public IActionResult AdminOrders()
    {
        var viewOrders = _repo.Orders.ToList();
        return View(viewOrders);
    }

    public IActionResult AdminProducts()
    {
        return View();
    }

    public IActionResult AdminUsers(int pageNum)
    {
        int pageSize = 20;
        var user = new UserPaginationListViewModel
        {
            Customers = _repo.Customers
                .OrderBy(x => x.CustomerId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

            UserPagination = new UserPagination
            {
                CurrentPage = pageNum,
                UsersPerPage = pageSize,
                TotalUsers = _repo.Customers.Count()
            }
        };
        return View(user);
    }
    
    [HttpGet]
    public IActionResult EditCustomer ()
    {
        ViewBag.categories = _repo.Customers.ToList();
        return View("AdminUsers");
    }
    
    [HttpPost]
    public IActionResult EditCustomer (Models.Customer customer)
    {
            _repo.AddCustomer(customer);
            return RedirectToAction("AdminUsers");
    }
    
    [HttpGet]
    public IActionResult DeleteCustomer(int id)
    {
        var recordToDelete = _repo.Customers
            .Single(x => x.CustomerId == id);

        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult DeleteCustomer (Models.Customer deleteInfo)
    {
        _repo.DeleteCustomer(deleteInfo);

        return RedirectToAction("AdminUsers");
    }
}