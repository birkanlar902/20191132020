using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sporties.ViewModel
{
    public class SiparisModel
    {
        public int siparisId { get; set; }
        public int siparisUyeId { get; set; }
        public string siparisTarih { get; set; }
        public int siparisKodu { get; set; }
        public int siparisUrunId { get; set; }

        public string siparisUyeAdi { get; set; }
        public string siparisUyeSoyadi { get; set; }
        public string siparisUyeAdres { get; set; }
        public string siparisUyeTelefon { get; set; }
        public string siparisUyeEposta { get; set; }

        public string siparisUrunAdi { get; set; }
        public decimal siparisUrunFiyati { get; set; }
        public string siparisUrunAciklama { get; set; }
        public int siparisUrunAdet { get; set; }
        public string siparisUrunKodu { get; set; }

        public string siparisUrunMarkaAdi { get; set; }
        public string siparisUrunKategoriAdi { get; set; }

    }
}