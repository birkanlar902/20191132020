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
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.Siparisler = new HashSet<Siparisler>();
        }
    
        public int urunId { get; set; }
        public string urunAdi { get; set; }
        public decimal urunFiyat { get; set; }
        public string urunAciklama { get; set; }
        public int urunAdet { get; set; }
        public string urunFoto { get; set; }
        public string urunKodu { get; set; }
        public int urunKatId { get; set; }
        public int urunMarkaId { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Markalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparisler> Siparisler { get; set; }
    }
}