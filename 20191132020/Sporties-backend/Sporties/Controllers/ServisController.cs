using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Http;
using Sporties.Models;
using Sporties.ViewModel;

namespace Sporties.Controllers
{
    public class ServisController : ApiController
    {
        DB001Entities3 db = new DB001Entities3();
        SonucModel sonuc = new SonucModel();

        #region Kategori

        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategoriler.Select(x => new KategoriModel()
            {

                katId = x.katId,
                katAdi = x.katAdi,
                katUrunSay = x.Urunler.Count()

            }
            ).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/kategoribyid/{katId}")]
        public KategoriModel KategoriById(int katId)
        {
            KategoriModel kayit = db.Kategoriler.Where(s => s.katId == katId).Select(x => new KategoriModel()
            {
                katId = x.katId,
                katAdi = x.katAdi,
                katUrunSay = x.Urunler.Count()
            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategoriler.Count(s => s.katAdi == model.katAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Kayıtlıdır.";
                return sonuc;
            }

            Kategoriler yeni = new Kategoriler();
            yeni.katAdi = model.katAdi;
            db.Kategoriler.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Başarıyla Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategoriler kayit = db.Kategoriler.Where(s => s.katId == model.katId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Kategori Yok";
                return sonuc;
            }

            kayit.katAdi = model.katAdi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Başarıyla Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel KategoriSil(int katId)
        {
            Kategoriler kayit = db.Kategoriler.Where(s => s.katId == katId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Kategori Yok";
                return sonuc;
            }

            if (db.Urunler.Count(s => s.urunKatId == katId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Kategorinin İçerisinde Ürünler Var Kategori Silinemedi";
                return sonuc;
            }

            db.Kategoriler.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";
            return sonuc;
        }

        #endregion

        #region Urun

        [HttpGet]
        [Route("api/urunliste")]
        public List<UrunModel> UrunListe()
        {
            List<UrunModel> liste = db.Urunler.Select(x => new UrunModel()
            {

                urunId = x.urunId,
                urunAdi = x.urunAdi,
                urunKatId = x.urunKatId,
                urunFiyat = x.urunFiyat,
                urunAciklama = x.urunAciklama,
                urunAdet = x.urunAdet,
                urunFoto = x.urunFoto,
                urunKodu = x.urunKodu,
                urunMarkaId = x.urunMarkaId,
                urunKatAdi = x.Kategoriler.katAdi,


            }
            ).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/urunbyid/{urunId}")]
        public UrunModel UrunById(int urunId)
        {
            UrunModel kayit = db.Urunler.Where(s => s.urunId == urunId).Select(x => new UrunModel()
            {
                urunId = x.urunId,
                urunAdi = x.urunAdi,
                urunKatId = x.urunKatId,
                urunFiyat = x.urunFiyat,
                urunAciklama = x.urunAciklama,
                urunAdet = x.urunAdet,
                urunFoto = x.urunFoto,
                urunKodu = x.urunKodu,
                urunMarkaId = x.urunMarkaId,
            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/urunekle")]
        public SonucModel UrunEkle(UrunModel model)
        {
            if (db.Urunler.Count(s => s.urunAdi == model.urunAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Ürün Kayıtlıdır.";
                return sonuc;
            }

            Urunler yeni = new Urunler();
            yeni.urunAdi = model.urunAdi;
            yeni.urunKatId = model.urunKatId;
            yeni.urunFiyat = model.urunFiyat;
            yeni.urunAciklama = model.urunAciklama;
            yeni.urunAdet = model.urunAdet;
            yeni.urunFoto = "stokfoto.jpg";
            yeni.urunKodu = model.urunKodu;
            yeni.urunMarkaId = model.urunMarkaId;
            db.Urunler.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ürün Başarıyla Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/urunduzenle")]
        public SonucModel UrunDuzenle(UrunModel model)
        {
            Urunler kayit = db.Urunler.Where(s => s.urunId == model.urunId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Ürün Yok";
                return sonuc;
            }


            kayit.urunAdi = model.urunAdi;
            kayit.urunKatId = model.urunKatId;
            kayit.urunFiyat = model.urunFiyat;
            kayit.urunAciklama = model.urunAciklama;
            kayit.urunAdet = model.urunAdet;
            kayit.urunFoto = model.urunFoto;
            kayit.urunKodu = model.urunKodu;
            kayit.urunMarkaId = model.urunMarkaId;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Ürün Başarıyla Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/urunsil/{urunId}")]
        public SonucModel UrunSil(int urunId)
        {
            Urunler kayit = db.Urunler.Where(s => s.urunId == urunId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Ürün Yok";
                return sonuc;
            }


            db.Urunler.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ürün Silindi";
            return sonuc;
        }

        [HttpPost]
        [Route("api/urunfotoguncelle")]
        public SonucModel UrunFotoGuncelle(UrunFoto model)
        {
            Urunler urn = db.Urunler.Where(s => s.urunKodu == model.urunKodu).SingleOrDefault();
            if (urn == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Ürün Yok";
                return sonuc;
            }

            if (urn.urunFoto != "stokfoto.jpg")
            {
                string yol = System.Web.Hosting.HostingEnvironment.MapPath("~/Dosyalar/" + urn.urunFoto);
                if (File.Exists(yol))
                {
                    File.Delete(yol);
                }
            }

            string data = model.fotoData;
            string base64 = data.Substring(data.IndexOf(',') + 1);
            base64 = base64.Trim('\0');
            byte[] imgbytes = Convert.FromBase64String(base64);
            string dosyaAdi = urn.urunKodu + model.fotoUzanti.Replace("image/", ".");

            using (var ms = new MemoryStream(imgbytes, 0, imgbytes.Length))
            {

                Image img = Image.FromStream(ms, true);
                img.Save(System.Web.Hosting.HostingEnvironment.MapPath("~/Dosyalar/" + dosyaAdi));

            }

            urn.urunFoto = dosyaAdi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Görsel Güncellendi";


            return sonuc;
        }

        #endregion

        #region Marka

        [HttpGet]
        [Route("api/markaliste")]
        public List<MarkaModel> MarkaListe()
        {
            List<MarkaModel> liste = db.Markalar.Select(x => new MarkaModel()
            {

                markaId = x.markaId,
                markaAdi = x.markaAdi,
             

            }
            ).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/markabyid/{markaId}")]
        public MarkaModel MarkaById(int markaId)
        {
            MarkaModel kayit = db.Markalar.Where(s => s.markaId == markaId).Select(x => new MarkaModel()
            {
                markaId = x.markaId,
                markaAdi = x.markaAdi,
            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/markaEkle")]
        public SonucModel UrunEkle(MarkaModel model)
        {
            if (db.Markalar.Count(s => s.markaAdi == model.markaAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Marka Kayıtlıdır.";
                return sonuc;
            }

            Markalar yeni = new Markalar();

            yeni.markaAdi = model.markaAdi;
         
            db.Markalar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Marka Başarıyla Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/markaduzenle")]
        public SonucModel MarkaDuzenle(MarkaModel model)
        {
            Markalar kayit = db.Markalar.Where(s => s.markaId == model.markaId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Marka Yok";
                return sonuc;
            }

            kayit.markaAdi = model.markaAdi;
          
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Marka Başarıyla Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/markasil/{markaId}")]
        public SonucModel MarkaSil(int markaId)
        {
            Markalar kayit = db.Markalar.Where(s => s.markaId == markaId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Marka Yok";
                return sonuc;
            }




            db.Markalar.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Marka Silindi";
            return sonuc;
        }

        #endregion

        #region Uye

        [HttpGet]
        [Route("api/uyeliste")]
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> liste = db.Uyeler.Select(x => new UyeModel()
            {

                uyeId = x.uyeId,
                uyeAdi = x.uyeAdi,
                uyeSoyadi = x.uyeSoyadi,
                uyeKadi = x.uyeKadi,
                uyeSifre = x.uyeSifre,
                uyeTelefon = x.uyeTelefon,
                uyeEposta = x.uyeEposta,
                uyeAdres = x.uyeAdres,
                uyeYetkileri = x.uyeYetkileri,


            }
            ).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/uyebyid/{uyeId}")]
        public UyeModel UyeById(int uyeId)
        {
            UyeModel kayit = db.Uyeler.Where(s => s.uyeId == uyeId).Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                uyeAdi = x.uyeAdi,
                uyeSoyadi = x.uyeSoyadi,
                uyeKadi = x.uyeKadi,
                uyeSifre = x.uyeSifre,
                uyeTelefon = x.uyeTelefon,
                uyeEposta = x.uyeEposta,
                uyeAdres = x.uyeAdres,
                uyeYetkileri = x.uyeYetkileri,
            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uyeler.Count(s => s.uyeKadi == model.uyeKadi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Üye Kayıtlıdır.";
                return sonuc;
            }

            Uyeler yeni = new Uyeler();

            yeni.uyeAdi = model.uyeAdi;
            yeni.uyeSoyadi = model.uyeSoyadi;
            yeni.uyeKadi = model.uyeKadi;
            yeni.uyeSifre = model.uyeSifre;
            yeni.uyeTelefon = model.uyeTelefon;
            yeni.uyeEposta = model.uyeEposta;
            yeni.uyeAdres = model.uyeAdres;
            yeni.uyeYetkileri = model.uyeYetkileri;

            db.Uyeler.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Başarıyla Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uyeler kayit = db.Uyeler.Where(s => s.uyeId == model.uyeId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Üye Yok";
                return sonuc;
            }

                kayit.uyeAdi = model.uyeAdi;
                kayit.uyeSoyadi = model.uyeSoyadi;
                kayit.uyeKadi = model.uyeKadi;
                kayit.uyeSifre = model.uyeSifre;
                kayit.uyeTelefon = model.uyeTelefon;
                kayit.uyeEposta = model.uyeEposta;
                kayit.uyeAdres = model.uyeAdres;
                kayit.uyeYetkileri = model.uyeYetkileri;

        


            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Başarıyla Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/uyesil/{uyeId}")]
        public SonucModel UyeSil(int uyeId)
        {
            Uyeler kayit = db.Uyeler.Where(s => s.uyeId == uyeId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Üye Yok";
                return sonuc;
            }




            db.Uyeler.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi";
            return sonuc;
        }

        #endregion

        #region Siparis

        [HttpGet]
        [Route("api/siparisliste")]
        public List<SiparisModel> SiparisListe()
        {
            List<SiparisModel> liste = db.Siparisler.Select(x => new SiparisModel()
            {

                siparisId = x.siparisId,
                siparisUyeId = x.siparisUyeId,
                siparisTarih = x.siparisTarih,
                siparisKodu = x.siparisKodu,
                siparisUrunId = x.siparisUrunId,

                siparisUyeAdi = x.Uyeler.uyeAdi,
                siparisUyeSoyadi = x.Uyeler.uyeSoyadi,
                siparisUyeAdres = x.Uyeler.uyeAdres,
                siparisUyeTelefon = x.Uyeler.uyeTelefon,
                siparisUyeEposta = x.Uyeler.uyeEposta,

                siparisUrunAdi = x.Urunler.urunAdi,
                siparisUrunFiyati = x.Urunler.urunFiyat,
                siparisUrunAciklama = x.Urunler.urunAciklama,
                siparisUrunAdet = x.Urunler.urunAdet,
                siparisUrunKodu = x.Urunler.urunKodu,

                siparisUrunMarkaAdi = x.Urunler.Markalar.markaAdi,
                siparisUrunKategoriAdi = x.Urunler.Kategoriler.katAdi,




            }
            ).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/siparisbyid/{siparisId}")]
        public SiparisModel SiparisById(int siparisId)
        {
            SiparisModel kayit = db.Siparisler.Where(s => s.siparisId == siparisId).Select(x => new SiparisModel()
            {
                siparisId = x.siparisId,
                siparisUyeId = x.siparisUyeId,
                siparisTarih = x.siparisTarih,
                siparisKodu = x.siparisKodu,
                siparisUrunId = x.siparisUrunId,

                siparisUyeAdi = x.Uyeler.uyeAdi,
                siparisUyeSoyadi = x.Uyeler.uyeSoyadi,
                siparisUyeAdres = x.Uyeler.uyeAdres,
                siparisUyeTelefon = x.Uyeler.uyeTelefon,
                siparisUyeEposta = x.Uyeler.uyeEposta,

                siparisUrunAdi = x.Urunler.urunAdi,
                siparisUrunFiyati = x.Urunler.urunFiyat,
                siparisUrunAciklama = x.Urunler.urunAciklama,
                siparisUrunAdet = x.Urunler.urunAdet,
                siparisUrunKodu = x.Urunler.urunKodu,

                siparisUrunMarkaAdi = x.Urunler.Markalar.markaAdi,
                siparisUrunKategoriAdi = x.Urunler.Kategoriler.katAdi,

            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/siparisEkle")]
        public SonucModel SiparisEkle(SiparisModel model)
        {
            if (db.Siparisler.Count(s => s.siparisKodu == model.siparisKodu) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Sipariş Kayıtlıdır.";
                return sonuc;
            }

            Siparisler yeni = new Siparisler();

          
            yeni.siparisUyeId = model.siparisUyeId;
            yeni.siparisTarih = model.siparisTarih;
            yeni.siparisKodu = model.siparisKodu;
            yeni.siparisUrunId = model.siparisUrunId;
          

            db.Siparisler.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sipariş Başarıyla Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/siparisduzenle")]
        public SonucModel SiparisDuzenle(SiparisModel model)
        {
            Siparisler kayit = db.Siparisler.Where(s => s.siparisId == model.siparisId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Sipariş Yok";
                return sonuc;
            }


            kayit.siparisId = model.siparisId;
            kayit.siparisUyeId = model.siparisUyeId;
            kayit.siparisTarih = model.siparisTarih;
            kayit.siparisKodu = model.siparisKodu;
            kayit.siparisUrunId = model.siparisUrunId;



            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Sipariş Başarıyla Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/siparissil/{siparisId}")]
        public SonucModel SiparisSil(int siparisId)
        {
            Siparisler kayit = db.Siparisler.Where(s => s.siparisId == siparisId).FirstOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Böyle Bir Sipariş Yok";
                return sonuc;
            }




            db.Siparisler.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sipariş Silindi";
            return sonuc;
        }

        #endregion


    }
}
