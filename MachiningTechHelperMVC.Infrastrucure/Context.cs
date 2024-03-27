using MachiningTechHelperMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure
{
    public class Context: IdentityDbContext
    {
        public DbSet<Drill>? Drills { get; set; }
        public DbSet<DrillCheckedParameters>? DrillsCheckedParameters { get; set; }
        public DbSet<FeedPerRevision>? FeedPerRevisions { get; set; }
        public DbSet<FeedPerTooth>? FeedPerTeeth { get; set; }
        public DbSet<FeedPerToothSolid>? FeedPerTeethSolid { get; set; }
        public DbSet<MillingInsert>? MillingInserts { get; set; }
        public DbSet<MillingTool>? MillingTools { get; set; }
        public DbSet<MillingToolCheckedParameters>? MillingToolsCheckedParameters { get; set; }
        public DbSet<MillingToolMillingInsert>? MillingToolMillingInserts { get; set; }
        public DbSet<Producer>? Producers { get; set; }
        public DbSet<SolidMillingTool>? SolidMillingTools { get; set; }
        public DbSet<SolidMillingToolCheckedParameters>? SolidMillingToolsCheckedParameters { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //many to many
            builder.Entity<MillingToolMillingInsert>()
                .HasKey(x => new { x.MillingToolId, x.MillingInsertId });

            builder.Entity<MillingToolMillingInsert>()
                .HasOne<MillingTool>(mi => mi.MillingTool)
                .WithMany(m => m.MillingToolMillingInserts)
                .HasForeignKey(mi => mi.MillingToolId);

            builder.Entity<MillingToolMillingInsert>()
                .HasOne<MillingInsert>(mi => mi.MillingInsert)
                .WithMany(m => m.MillingToolMillingInserts)
                .HasForeignKey(mi => mi.MillingInsertId);

            //one to many

            builder.Entity<Drill>()
                .HasOne<Producer>(d => d.Producer)
                .WithMany(p => p.Drills)
                .HasForeignKey(d => d.ProducerId);

            builder.Entity<DrillCheckedParameters>()
                .HasOne<Drill>(dcp => dcp.Drill)
                .WithMany(d => d.DrillCheckedParameters)
                .HasForeignKey(dcp => dcp.DrillId);

            builder.Entity<FeedPerRevision>()
                .HasOne<Drill>(fpr => fpr.Drill)
                .WithMany(d => d.FeedPerRevisions)
                .HasForeignKey(fpr => fpr.DrillId);

            builder.Entity<FeedPerTooth>()
                .HasOne(m => m.MillingInsert)
                .WithMany(mi => mi.FeedPerTeeth)
                .HasForeignKey(m => m.MillingInsertId);

            builder.Entity<FeedPerToothSolid>()
                .HasOne(m => m.SolidMillingTool)
                .WithMany(mi => mi.FeedPerTeethSolid)
                .HasForeignKey(m => m.SolidMillingToolId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MillingTool>()
                .HasOne<Producer>(mt => mt.Producer)
                .WithMany(p => p.MillingTools)
                .HasForeignKey(mt => mt.ProducerId);

            builder.Entity<MillingToolCheckedParameters>()
                .HasOne<MillingTool>(mtcp => mtcp.MillingTool)
                .WithMany(mt => mt.MillingToolCheckedParameters)
                .HasForeignKey(mtcp => mtcp.MillingToolId);

            builder.Entity<SolidMillingTool>()
                .HasOne<Producer>(smt => smt.Producer)
                .WithMany(p => p.SolidMillingTools)
                .HasForeignKey(smt => smt.ProducerId);

            builder.Entity<SolidMillingToolCheckedParameters>()
                .HasOne<SolidMillingTool>(smtcp => smtcp.SolidMillingTool)
                .WithMany(smt => smt.SolidMillingToolCheckedParameters)
                .HasForeignKey(smtcp => smtcp.SolidMillingToolId);

            builder.Entity<MillingToolCheckedParameters>()
                .HasOne<MillingInsert>(smtcp => smtcp.MillingInsert)
                .WithMany(mi => mi.MillingToolCheckedParameters)
                .HasForeignKey(smtcp => smtcp.MillingInsertId);
        }
    }
}
