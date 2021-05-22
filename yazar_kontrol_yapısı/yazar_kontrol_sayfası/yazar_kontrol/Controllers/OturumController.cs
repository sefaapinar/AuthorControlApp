using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace sefanur_pınar_Final.Controllers
{
    public class OturumController : Controller
    {
        // GET: Oturum
        public ActionResult OturumAc()
        {
            return View("OturumAc");
        }

        [HttpPost]

        public ActionResult Oturum(MakaleModel.Kullanici kullanici)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();

            var KullaniciBil = model.Kullanici.FirstOrDefault(k => k.KullaniciAdi == kullanici.KullaniciAdi && k.Parola == kullanici.Parola);

            if (KullaniciBil != null)
            {
                JavaScriptSerializer serilestir = new JavaScriptSerializer();

                string kullaniciBilgisi = serilestir.Serialize(KullaniciBil);

                FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(
                   1, KullaniciBil.KullaniciAdi,
                   DateTime.Now, DateTime.Now.AddMinutes(10),
                   false, kullaniciBilgisi, FormsAuthentication.FormsCookiePath);

                string sifreliBilet = FormsAuthentication.Encrypt(bilet);


                HttpCookie cerez = new HttpCookie(FormsAuthentication.FormsCookieName, sifreliBilet);


                cerez.HttpOnly = true;
                Response.Cookies.Add(cerez);

                return RedirectToAction("KullaniciEkle", "Makale");

            }
            else
            {
                return RedirectToAction("OturumAc");
            }
        }

            public ActionResult OturumuKapat()
            {
                FormsAuthentication.SignOut();
                var cerez = Request.Cookies["Oturum"];
                cerez.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cerez);
                Request.Cookies.Remove("Oturum");

                return RedirectToAction("OturumAc");

            }

        
        
    }
}