﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EAutoServicingContext : DbContext
    {
        public EAutoServicingContext()
            : base("name=EAutoServicingContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeetype> Employeetypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<ServiceBooking> ServiceBookings { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
