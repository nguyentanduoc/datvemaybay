//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelPlain.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHUYENBAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUYENBAY()
        {
            this.VEs = new HashSet<VE>();
        }
    
        public int MA_CHUYENBAY { get; set; }
        public int MA_TUYENBAY { get; set; }
        public int MA_MAYBAY { get; set; }
        public string TEN_CHUYENBAY { get; set; }
        public Nullable<System.DateTime> NGAYBAY_CHUYENBAY { get; set; }
        public Nullable<System.TimeSpan> GIOBAY_CHUYENBAY { get; set; }
    
        public virtual MAYBAY MAYBAY { get; set; }
        public virtual TUYENBAY TUYENBAY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VE> VEs { get; set; }
    }
}
