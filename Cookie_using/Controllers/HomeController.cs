using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookie_using.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("name", "alicanyilmaz");
            HttpContext.Response.Cookies.Add(cookie); //kullanıcıya Response ile gönderiyoruz Cookie yi
            cookie.Expires = DateTime.Now.AddDays(1); //AddHour AddSecond gibi birçok option geliyor intellisense ile.BU sayede de Cookie silme işlemini zamanlayabilirsiniz.

            return View();
        }

        public ActionResult Index2()
        {
            if(HttpContext.Request.Cookies["name"]!=null)
            {
                ViewBag.username = HttpContext.Request.Cookies["name"].Value;  //Value string döndürür yani Cookie ler object değil string tutar.
            }
            else
            {
                ViewBag.username = "There is not Cookie";
            }
            return View();
        }

        public ActionResult Index3()
        {
            if (HttpContext.Request.Cookies["name"] != null)
            {
                HttpContext.Request.Cookies.Remove("name");  //Cookie yi silde silebilirsiniz bu şekilde.Fkat bu sorun çıkarabiliyor o yuzden sunu kullanmak daha mantıklı.
                HttpContext.Response.Cookies["name"].Expires = DateTime.Now.AddSeconds(5); //bu sekilde silseniz daha mantıklı.Index3 çalıştıktan 2 sn sonra silecek.
            }
           
            return View();
        }
    }
}