using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sporties.ViewModel
{
    public class UrunModel
    {
        public int urunId { get; set; }
        public string urunAdi { get; set; }
        public int urunKatId { get; set; }
        public string urunKatAdi { get; set; }
        public decimal urunFiyat { get; set; }
        public string urunAciklama { get; set; }
        public int urunAdet { get; set; }
        public string urunFoto { get; set; }
        public string urunKodu { get; set; }
        public int urunMarkaId { get; set; }

    }
}