using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayPayCore.Models;
using PayPayCore.PaypalHelper;

namespace PayPayCore.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {

        public IConfiguration configuration { get; }
        public CartController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            var productModel = new ProductModel();
            ViewBag.products = productModel.FindAll();
            ViewBag.total = productModel.FindAll().Sum(p => p.Price * p.Quantity);
            return View();
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> Checkout(double total)
        {
            var payPalAPI = new PaypalAPI(configuration);
            string url = await payPalAPI.getRedirectURLToPaypal(total, "USD");
            return Redirect(url);
        }

       
        [Route("success")]
        public async Task<IActionResult> Success([FromQuery(Name = "paymentId")] string paymentId, [FromQuery(Name = "PayerID")] string PayerID)
        {
            var payPalAPI = new PaypalAPI(configuration);
            PaypalPaymentExecutedResponse result = await payPalAPI.executedPayment(paymentId, PayerID);
            Debug.WriteLine("Transaction Details");
            Debug.WriteLine("cart:" + result.cart);
            Debug.WriteLine("create_time: " + result.create_time.ToLongDateString());
            Debug.WriteLine("id:" + result.id);
            Debug.WriteLine("intent:" + result.intent);
            Debug.WriteLine("links 0 - href:" + result.links[0].href);
            Debug.WriteLine("links 0 - method:" + result.links[0].method);
            Debug.WriteLine("links 0 - rel:" + result.links[0].rel);
            Debug.WriteLine("payer_info - first_name" + result.payer.payer_info.first_name);
            Debug.WriteLine("payer_info - last_name" + result.payer.payer_info.last_name);
            Debug.WriteLine("payer_info - email" + result.payer.payer_info.email);
            Debug.WriteLine("payer_info - billing_address" + result.payer.payer_info.billing_address);
            Debug.WriteLine("payer_info - country_code" + result.payer.payer_info.country_code);
            Debug.WriteLine("payer_info - shipping_address" + result.payer.payer_info.shipping_Address);
            Debug.WriteLine("payer_info - payer_id" + result.payer.payer_info.payer_id);
            Debug.WriteLine("state" + result.state);
            ViewBag.result = result;
            return View("Success");
        }
    }
}
