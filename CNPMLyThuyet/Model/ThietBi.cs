//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPMLyThuyet.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThietBi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThietBi()
        {
            this.ChiTietBaoTris = new HashSet<ChiTietBaoTri>();
        }
    
        public string MaTB { get; set; }
        public string TenTB { get; set; }
        public string TinhTrang { get; set; }
        public System.DateTime NgaySuDung { get; set; }
        public int SoLanBaoTri { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBaoTri> ChiTietBaoTris { get; set; }
    }
}
