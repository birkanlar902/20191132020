//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sporties.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Siparisler
    {
        public int siparisId { get; set; }
        public int siparisUyeId { get; set; }
        public string siparisTarih { get; set; }
        public int siparisKodu { get; set; }
        public int siparisUrunId { get; set; }
    
        public virtual Urunler Urunler { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}