﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BGScheduler
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ScheduleProdEntities : DbContext
    {
        public ScheduleProdEntities()
            : base("name=ScheduleProdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AreaDefinition> AreaDefinitions { get; set; }
        public virtual DbSet<ClubDemographic> ClubDemographics { get; set; }
        public virtual DbSet<EmpAssignment> EmpAssignments { get; set; }
        public virtual DbSet<EmpDemographic> EmpDemographics { get; set; }
        public virtual DbSet<RoleDefinition> RoleDefinitions { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    }
}
