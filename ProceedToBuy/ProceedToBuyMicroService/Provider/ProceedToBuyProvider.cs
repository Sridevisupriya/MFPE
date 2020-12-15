using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProceedToBuyService.Models;
using ProceedToBuyService.Repository;

namespace ProceedToBuyService.Provider
{
    public class ProceedToBuyProvider : IProceedToBuyProvider
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyProvider));

        private readonly IProceedToBuyRepository proceedToBuyRepository;
        public ProceedToBuyProvider(IProceedToBuyRepository repo)
        {
            proceedToBuyRepository = repo;
        }
        public WishlistSuccess Wish(int custid,int prodid)
        {
            
            WishlistDto wl = new WishlistDto()
            {
                
                CustomerId=custid,
                ProductId = prodid,
                Quantity=1,
                DateAddedToWishlist=DateTime.Now.Date
            };
            WishlistDto wl1 =  proceedToBuyRepository.addToWishlist(wl);
            if(wl1!=null)
            {
                WishlistSuccess msg = new WishlistSuccess();
                msg.Message = "Requested product is out of stock. Product added to wishlist";
                return msg;
            }
            else
            {
                return null;
            }
            
        }


        public CartDto GetSupply(int prodid, int custid, int zipcode, DateTime delidt)
        {

            var client = new HttpClient();


            client.BaseAddress = new Uri("https://localhost:44388/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Vendor/GetVendorDetails/" + prodid).Result;

            string apiResponse = response.Content.ReadAsStringAsync().Result;
            //var value = response.Content.ReadAsStringAsync().Result;

            List<VendorDto> vendorsdto = JsonConvert.DeserializeObject<List<VendorDto>>(apiResponse);
            if (vendorsdto.Count > 0)
            {
                int max = 0;
                VendorDto taggeddto = vendorsdto.FirstOrDefault();

                foreach (VendorDto v in vendorsdto)
                {
                    if (v.Rating >= max)
                    {
                        max = v.Rating;
                        taggeddto = v;
                    }
                }
                Vendor taggedvendor = new Vendor()
                {
                    VendorId = taggeddto.VendorId,
                    VendorName = taggeddto.VendorName,
                    Rating = taggeddto.Rating,
                    DeliveryCharge = taggeddto.DeliveryCharge
                };



                Random unid = new Random();
                CartDto finalcart = new CartDto()
                {
                    CartId = unid.Next(1, 999),
                    CustomerId = custid,
                    ProductId = prodid,
                    Zipcode = zipcode,
                    DeliveryDate = delidt,
                    VendorObj = taggedvendor,
                };
                CartDto ficart = proceedToBuyRepository.addToCart(finalcart);
                return finalcart;




            }
            else
            {
                CartDto fcart = new CartDto();
                fcart.ProductId = prodid;
                fcart.CustomerId = custid;
                fcart.Zipcode = zipcode;
                return fcart;

            }


        }
    }
}
