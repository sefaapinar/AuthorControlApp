using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace sefanur_pınar_Final.Controllers
{
    [Attribute.Log]
    public class HastaController : Controller
    {
        private object yeniMuayene;

        public PartialViewResult Baslik()
        {
            var cerez = Request.Cookies["Oturum"];
            if (cerez != null)
            {
                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(cerez.Value);
                JavaScriptSerializer serilestir = new JavaScriptSerializer();
                var kullanici = serilestir.Deserialize<Models.KullaniciBilgi>(bilet.UserData);
                return PartialView("_sitebaslik", kullanici);
            }
            else
            {

                return PartialView("_sitebaslik");
            }



        }
         
        [HttpGet]
               
        public ActionResult MakaleEkle()
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            var liste = model.Kullanici.ToList();

            return View("Makale", liste);
        }

        [HttpPost]
        
        public ActionResult MakaleEkle(MakaleModel.Makale yeniMakale)
        {

            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();

            var cerez = Request.Cookies["Oturum"];
            if (cerez != null)
            {
                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(cerez.Value);

                JavaScriptSerializer serilestir = new JavaScriptSerializer();
                var kullaniciBilgi = serilestir.Deserialize<Models.KullaniciBilgi>(bilet.UserData);

                yeniMakale.KullaniciNo = kullaniciBilgi.No;
                model.Makale.Add(yeniMakale);
                model.SaveChanges();
            }

            
            return RedirectToAction("MakaleEkle");
        }



    }
}
}  
