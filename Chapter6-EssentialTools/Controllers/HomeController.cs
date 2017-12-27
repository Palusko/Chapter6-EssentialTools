using Chapter6_EssentialTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace Chapter6_EssentialTools.Controllers
{
  public class HomeController : Controller
  {
    private IValueCalculator calc;

    private Product[] products =
    {
      new Product { Name = "Kayak",
                    Category = "Watersports",
                    Price = 275m },
      new Product { Name = "LifeJacket",
                    Category = "Watersports",
                    Price = 48.95m },
      new Product { Name = "Soccer Ball",
                    Category = "Soccet",
                    Price = 19.50m },
      new Product { Name = "Corner Flag",
                    Category = "Soccer",
                    Price = 34.95m }
    };

    public HomeController(IValueCalculator calcParam, IValueCalculator calc2)
    {
      calc = calcParam;
    }

    // GET: Home
    public ActionResult Index()
    {
      //var ninjectKernel = new StandardKernel();
      //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

     // IValueCalculator calc = ninjectKernel.Get<IValueCalculator>(); 

      var cart = new ShoppingCart(calc) { Products = products }; //this is the equivalent of the two lines below
      //var cart = new ShoppingCart(calc);
      //cart.Products = products;

      decimal totalValue = cart.CalculateProductTotal();
      return View(totalValue);
    }
  }
}