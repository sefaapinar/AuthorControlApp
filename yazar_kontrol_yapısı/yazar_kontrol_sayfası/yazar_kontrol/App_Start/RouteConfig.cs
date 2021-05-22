using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sefanur_pınar_Final
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
             name: "KullaniciListe",
            url: "KullaniciListesi/{UnvanNo}",
            defaults: new { controller = "Makale", action = "KullaniciGetir" }
            );



            routes.MapRoute(
              name: "KategoriListe",
              url: "KategoriListesi/{No}",
              defaults: new { controller = "Makale", action = "KategoriGetir" }
            );


            //routes.MapRoute(
            //    name: "KullaniciListe",
            //    url: "KullaniciListesi/{UnvanNo}",
            //    defaults: new { controller = "Makale", action = "KullaniciGetir" }
            //  );



            routes.MapRoute(
                name: "BolumEkleGetir",
                url: "BolumekleyiGetir",
                defaults: new { controller = "Makale", action = "BolumEkle" }
            );

            routes.MapRoute(
                name: "KategoriEkleGetir",
                url: "KategoriEkleyiGetir",
                defaults: new { controller = "Makale", action = "KategoriEkle" }
            );

            routes.MapRoute(
              name: "KullaniciEkleGetir",
              url: "KullaniciEkleyiGetir",
              defaults: new { controller = "Makale", action = "KullaniciEkle" }
          );

            routes.MapRoute(
              name: "MakaleEkleGetir",
              url: "MakaleEkleyiGetir",
              defaults: new { controller = "Makale", action = "MakaleEkle" }
          );

            routes.MapRoute(
              name: "UnvanEkleGetir",
              url: "UnvanEkleyiGetir",
              defaults: new { controller = "Makale", action = "UnvanEkle" }
          );






            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Makale", action = "Anasayfa", id = UrlParameter.Optional }
            );
        }
    }
}
