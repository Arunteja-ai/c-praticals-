using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ProductCatalogMVC.Controllers;

public class CartController : Controller
{
    private const string CartSessionKey = "CartItems";

    // Dummy product list (same as ProductController for demonstration)
    private static readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop Pro X", Description = "High performance laptop for professionals.", Price = 1299.99m, Category = "Electronics", ImageUrl = "/images/laptop.jpg" },
        new Product { Id = 2, Name = "Wireless Headphones", Description = "Noise-cancelling over-ear headphones.", Price = 199.50m, Category = "Audio", ImageUrl = "/images/headphones.jpg" },
        new Product { Id = 3, Name = "Smartwatch Series 5", Description = "Track your fitness and stay connected.", Price = 249.99m, Category = "Wearables", ImageUrl = "/images/smartwatch.jpg" },
        new Product { Id = 4, Name = "Ergonomic Office Chair", Description = "Comfortable chair for long working hours.", Price = 150.00m, Category = "Furniture", ImageUrl = "/images/chair.jpg" },
        new Product { Id = 5, Name = "4K Monitor 27 inch", Description = "Crisp and clear display for your workspace.", Price = 349.99m, Category = "Electronics", ImageUrl = "/images/monitor.jpg" }
    };

    public IActionResult Index()
    {
        var cart = GetCart();
        return View(cart);
    }

    [HttpPost]
    public IActionResult AddToCart(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            var cart = GetCart();
            cart.Add(product);
            SaveCart(cart);
            TempData["SuccessMessage"] = $"{product.Name} added to your cart!";
        }
        return RedirectToAction("Index", "Product");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int id)
    {
        var cart = GetCart();
        var product = cart.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            cart.Remove(product);
            SaveCart(cart);
        }
        return RedirectToAction("Index");
    }

    private List<Product> GetCart()
    {
        var sessionData = HttpContext.Session.GetString(CartSessionKey);
        if (string.IsNullOrEmpty(sessionData))
        {
            return new List<Product>();
        }
        return JsonSerializer.Deserialize<List<Product>>(sessionData) ?? new List<Product>();
    }

    private void SaveCart(List<Product> cart)
    {
        var sessionData = JsonSerializer.Serialize(cart);
        HttpContext.Session.SetString(CartSessionKey, sessionData);
    }
}
