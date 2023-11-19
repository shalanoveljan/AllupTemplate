using Allup_Template.DataAccessLayer;
using Allup_Template.Models;
using Allup_Template.ViewModels.BasketVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Allup_Template.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

           
            if(!await _context.Products.AnyAsync(p => p.IsDeleted == false && p.Id == id))
            {
                return NotFound();
            }

            string? cookie = Request.Cookies["basket"];

            List<BasketVM> BasketVMs = null;

            if (!string.IsNullOrWhiteSpace(cookie))
            {
                BasketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(cookie);

                if (BasketVMs.Exists(b => b.ProductID == id))
                {
                    BasketVMs.Find(b => b.ProductID == id).Count += 1;
                }
                else
                {
                    BasketVM basketVM = new BasketVM()
                    {
                        ProductID = (int)id,
                        Count = 1,
                       
                    };
                    BasketVMs.Add(basketVM);
                }
            }

            else
            {
                BasketVM basketVM=new BasketVM()
                {
                    ProductID= (int)id,
                    Count=1,
                   
                };
                BasketVMs = new List<BasketVM> { basketVM };

            }


             cookie=JsonConvert.SerializeObject(BasketVMs);
            Response.Cookies.Append("basket", cookie);

            foreach (BasketVM basketVM in BasketVMs)
            {
                Product? product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == basketVM.ProductID);

                basketVM.Title = product.Title;
                basketVM.Price = product.DiscountPrice > 0 ? product.DiscountPrice : product.Price;
                basketVM.Image = product.MainImage;
                basketVM.Extax = product.ExTax;



            }

            return PartialView("_BasketPartial",BasketVMs);
        }


        public IActionResult GetBasket()
        {
            string? cookie = Request.Cookies["basket"];

            if(cookie != null)
            {
                List<BasketVM>? basketVMs=JsonConvert.DeserializeObject<List<BasketVM>?>(cookie);
            return Ok(basketVMs);
            }

            return Ok();
        }
    }
}
