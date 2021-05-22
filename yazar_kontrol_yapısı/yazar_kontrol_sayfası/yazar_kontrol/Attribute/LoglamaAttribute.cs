using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace sefanur_pınar_Final.Nitelik
{
    public class LoglamaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MakaleModel.Log yeniLog = new MakaleModel.Log();

            var cerez = filterContext.HttpContext.Request.Cookies["Oturum"];
            if (cerez != null)
            {
                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(cerez.Value);

                JavaScriptSerializer serilestir = new JavaScriptSerializer();
                var kullanici = serilestir.Deserialize<Models.KullaniciBilgi>(bilet.UserData);

                yeniLog.KullaniciNumara = kullanici.No;
            }

            yeniLog.MetotAdi = filterContext.ActionDescriptor.ActionName;
            yeniLog.IP = filterContext.HttpContext.Request.UserHostAddress;
            yeniLog.Tarayici = filterContext.HttpContext.Request.Browser.Browser;
            if (filterContext.ActionParameters.Count > 0)
            {
                JavaScriptSerializer seri = new JavaScriptSerializer();
                yeniLog.Parametre = seri.Serialize(filterContext.ActionParameters);
            }
            
            yeniLog.Tarih = DateTime.Now;


            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            model.Log.Add(yeniLog);
            model.SaveChanges();
        }
    }
}