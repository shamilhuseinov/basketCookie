using System;
using System.Collections.Generic;
using fiorello_project.DAL;
using fiorello_project.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace fiorello_project.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BasketModel> basket;

            var basketCookie = Request.Cookies["basket"];
            if (basketCookie is null)
            {
                basket = new List<BasketModel>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketModel>>(basketCookie);
            }

            foreach (var basketProduct in basket)
            {
                var product = await _context.Products.FindAsync(basketProduct.Id);
                if (product is not null)
                {
                    basketProduct.Title = product.Title;
                    basketProduct.PhotoName = product.MainPhotoName;
                    basketProduct.Price = product.Price;
                    basketProduct.StockQuantity = product.Quantity;
                }
            }
            return View(basket);
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync(int id)
        {
            List<BasketModel> basket;

            var basketCookie = Request.Cookies["basket"];
            if (basketCookie is null)
            {
                basket = new List<BasketModel>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketModel>>(basketCookie);
            }

            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound("Product was not found");
            }

            var basketProduct = basket.Find(bp => bp.Id == product.Id);
            if (basketProduct is not null)
            {
                if (product.Quantity == basketProduct.Count)
                    return NotFound("Count is maximum");

                basketProduct.Count++;
            }
            else
            {
                basket.Add(new BasketModel
                {
                    Id = product.Id,
                    Count = 1
                });
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return Ok("product successfully added to basket");
        }

        [HttpGet]
        public async Task<IActionResult> IncreaseCount(int id)
        {
            List<BasketModel> basket = JsonConvert.DeserializeObject<List<BasketModel>>(Request.Cookies["basket"]);


            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound("Product was not found");
            }

            var basketProduct = basket.Find(bp => bp.Id == product.Id);
            if (basketProduct is not null)
            {
                if (product.Quantity == basketProduct.Count)
                    return NotFound("Count is maximum");

                basketProduct.Count++;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DecreaseCount(int id)
        {
            List<BasketModel> basket = JsonConvert.DeserializeObject<List<BasketModel>>(Request.Cookies["basket"]);


            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound("Product was not found");
            }

            var basketProduct = basket.Find(bp => bp.Id == product.Id);
            if (basketProduct is not null)
            {
                if (basketProduct.Count == 0)
                    basket.Remove(basketProduct);
                else
                    basketProduct.Count--;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return Ok();
        }
    }
}

