using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogMVC.Controllers;

public class ProductController : Controller
{
    // Mock database
    private static readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop Pro X", Description = "High performance laptop for professionals.", Price = 1299.99m, Category = "Electronics", ImageUrl = "/images/laptop.jpg" },
        new Product { Id = 2, Name = "Wireless Headphones", Description = "Noise-cancelling over-ear headphones.", Price = 199.50m, Category = "Audio", ImageUrl = "/images/headphones.jpg" },
        new Product { Id = 3, Name = "Smartwatch Series 5", Description = "Track your fitness and stay connected.", Price = 249.99m, Category = "Wearables", ImageUrl = "/images/smartwatch.jpg" },
        new Product { Id = 4, Name = "Ergonomic Office Chair", Description = "Comfortable chair for long working hours.", Price = 150.00m, Category = "Furniture", ImageUrl = "/images/chair.jpg" },
        new Product { Id = 5, Name = "4K Monitor 27 inch", Description = "Crisp and clear display for your workspace.", Price = 349.99m, Category = "Electronics", ImageUrl = "/images/monitor.jpg" }
    };

    // GET: /Product/
    public IActionResult Index()
    {
        return View(_products);
    }

    // GET: /Product/Details/5
    public IActionResult Details(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}
