//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElektroikHayvanKimliklendirmeAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VeterinerKimlik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VeterinerKimlik()
        {
            this.HayvanHastalik = new HashSet<HayvanHastalik>();
        }
    
        public int VeterinerNo { get; set; }
        public string VeterinerTC { get; set; }
        public string VeterinerAdı { get; set; }
        public string VeterinerSoyadı { get; set; }
        public string KurumAdı { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HayvanHastalik> HayvanHastalik { get; set; }
    }
}
