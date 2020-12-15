using EcommercePortalClient.Models;
using EcommercePortalClient.Models.ViewModels;
using EcommercePortalClient.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortalClient.Controllers
{
    public class ProceedToBuyController : Controller
    {

        private readonly IProceedToBuyProvider _provider;
        private log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ProceedToBuyController));
        public ProceedToBuyController(IProceedToBuyProvider provider)
        {
            this._provider = provider;
        }

        [HttpGet]
        public  IActionResult AddToCart()
        {
            
           
  
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(CartViewModel cart)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(cart);
                }
                Cart cartobj = new Cart();

                try
                {
                    var response = await _provider.AddToCart(cart);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsoncontent = await response.Content.ReadAsStringAsync();
                        cartobj = JsonConvert.DeserializeObject<Cart>(jsoncontent);
                        
                        return View("CartAdded", cartobj);
                    }
                    else if(response.StatusCode ==System.Net.HttpStatusCode.NoContent)
                    {
                        return RedirectToAction("AddToWishlist");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        ModelState.AddModelError("", "Having server issue while adding to cart");
                        return View();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", "Invalid model states");
                        return View();
                    }
                }
                catch (Exception e)
                {
                    _logger.Error("Exception Occured as : " + e.Message);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult CartAdded()
        {
            Cart cartobj = new Cart();
            return View(cartobj);
        }

        [HttpGet]
        public IActionResult AddToWishlist()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToWishlist(WishlistViewModel wish)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(wish);
                }
                WishlistStatusViewModel status = new WishlistStatusViewModel();
                try
                {
                    var response = await _provider.AddToWishlist(wish);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsoncontent = await response.Content.ReadAsStringAsync();
                        status = JsonConvert.DeserializeObject<WishlistStatusViewModel>(jsoncontent);
                        return View("WishlistStatus", status);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        ModelState.AddModelError("", "Having server issue while adding to wishlist");
                        return View();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", "Invalid model states");
                        return View();
                    }
                }
                catch (Exception e)
                {
                    _logger.Error("Exception Occured as : " + e.Message);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult WishlistStatus()
        {
            WishlistStatusViewModel status = new WishlistStatusViewModel();
            return View(status);
        }
    }
}
