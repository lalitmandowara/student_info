//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School_Info
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        public Class()
        {
            this.student = new HashSet<student>();
        }
    
        public int Id { get; set; }
        public string ClassName { get; set; }
        public decimal Amount { get; set; }
    
        public virtual ICollection<student> student { get; set; }
    }
}