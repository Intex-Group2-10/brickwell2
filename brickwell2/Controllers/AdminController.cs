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

    public IActionResult AdminUsers()
    {
        return View();
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
        return RedirectToAction("AdminUsers");
    }
}