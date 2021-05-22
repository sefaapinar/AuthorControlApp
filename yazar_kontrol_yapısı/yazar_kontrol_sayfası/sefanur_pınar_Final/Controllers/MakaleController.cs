using MakaleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sefanur_pınar_Final.Controllers
{
    public class MakaleController : Controller
    {
        

        // GET: Makale
        public ActionResult Anasayfa()
        {
            MakaleModel.MakaleDB makalelist = new MakaleModel.MakaleDB();
            var liste = makalelist.Makale.ToList();

            return View("Anasayfa", liste);
            
        }
       
        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            return View("KullaniciEkle");
        }

        [HttpPost]
        public ActionResult KullaniciEkle(MakaleModel.Kullanici yeniKullanici)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            model.Kullanici.Add(yeniKullanici);
            model.SaveChanges();

            return RedirectToAction("KullaniciEkle");
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View("KategoriEkle");
        }

        [HttpPost]
        public ActionResult KategoriEkle(MakaleModel.Kategori yeniKategori)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            model.Kategori.Add(yeniKategori);
            model.SaveChanges();

            return RedirectToAction("KategoriEkle");
        }

        [HttpGet]
        public ActionResult MakaleEkle()
        {
            return View("MakaleEkle");
        }

        [HttpPost]
        public ActionResult MakaleEkle(MakaleModel.Makale yeniMakale)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            model.Makale.Add(yeniMakale);
            model.SaveChanges();

            return RedirectToAction("MakaleEkle");
        }
        [HttpGet]
        public ActionResult UnvanEkle()
        {
            return View("UnvanEkle");
        }

        [HttpPost]
        public ActionResult UnvanEkle(MakaleModel.Unvan yeniUnvan)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            model.Unvan.Add(yeniUnvan);
            model.SaveChanges();

            return RedirectToAction("UnvanEkle");
        }

        [HttpGet]
        public ActionResult BolumEkle()
        {
            return View("BolumEkle");
        }

        [HttpPost]
        public ActionResult BolumEkle(MakaleModel.Bolum yeniBolum)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            model.Bolum.Add(yeniBolum);
            model.SaveChanges();

            return RedirectToAction("BolumEkle");
        }
        
       
        public ActionResult KullaniciListe()
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();

            var liste = model.Kullanici.ToList();

            var kullaniciListe = model.Kullanici.ToList();

            return View("KullanıcıListe", liste);
        }


        [Route("Kullanici/{UnvanNo:int}")]
        public ActionResult KullaniciGetir(int UnvanNo)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            var kullaniciListesi = model.Kullanici.Where(p => p.UnvanNo == UnvanNo);
            return View("KullaniciListe",kullaniciListesi);
        }

        [Route("Kategori/{No:int}")]
        public ActionResult KategoriGetir(int No)
        {
            MakaleModel.MakaleDB model = new MakaleModel.MakaleDB();
            var KategoriListesi = model.Kullanici.Where(p => p.No == No);
            return View("KategoriListe", KategoriListesi);
        }











    }
}