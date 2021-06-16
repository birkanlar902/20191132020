using Sporties.Models;
using Sporties.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sporties.Auth
{
    public class uyeService
    {
        DB001Entities3 db = new DB001Entities3();
        public UyeModel UyeOturumAc(string kadi, string parola)
        {
            UyeModel uye = db.Uyeler.Where(s => s.uyeKadi == kadi && s.uyeSifre == parola).Select(x => new UyeModel()
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

            }).SingleOrDefault();

            return uye;
        }

    }
}