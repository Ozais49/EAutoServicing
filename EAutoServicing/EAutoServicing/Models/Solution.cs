//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EAutoServicing.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solution
    {
        public Solution()
        {
            this.Bills = new HashSet<Bill>();
        }
    
        public string Id { get; set; }
        public string ServiceID { get; set; }
        public string SolutionDesc { get; set; }
        public Nullable<System.DateTime> SolvedDate { get; set; }
        public string IsBilled { get; set; }
    
        public virtual ICollection<Bill> Bills { get; set; }
    }
}