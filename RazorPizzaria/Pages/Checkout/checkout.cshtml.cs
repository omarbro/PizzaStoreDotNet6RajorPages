using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzaria.Data;
using RazorPizzaria.Models;

namespace RazorPizzaria.Pages.Checkout
{
    [BindProperties(SupportsGet =true)]
    public class checkoutModel : PageModel
    {
        public string PizzaName { get; set; }

        public float PizzaPrice { get; set; }

        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;
        public checkoutModel(ApplicationDbContext context)
        {
            _context= context;
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(PizzaName))
            {
                PizzaName = "Custom";
            }
            if (string.IsNullOrEmpty(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder pizzaOrder= new PizzaOrder();
            pizzaOrder.PizzaName = PizzaName;   
            pizzaOrder.BasePrice= PizzaPrice;

            _context.PizzaOrders.Add(pizzaOrder);
            _context.SaveChanges();

        }
    }
}
