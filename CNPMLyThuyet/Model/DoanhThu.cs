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
    
    public partial class DoanhThu
    {
        public int MaDT { get; set; }
        public Nullable<int> Thang { get; set; }
        public Nullable<int> Nam { get; set; }
        public Nullable<int> TongTien { get; set; }
        public string MaMB { get; set; }
    
        public virtual MatBang MatBang { get; set; }
    }
}
