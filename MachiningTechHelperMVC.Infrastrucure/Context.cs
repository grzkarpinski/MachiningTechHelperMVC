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
        public DbSet<Drill> Drills { get; set; }
        public DbSet<DrillCheckedParameters> DrillsCheckedParameters { get; set; }
        public DbSet<FeedPerRevision> FeedPerRevisions { get; set; }
        public DbSet<FeedPerTooth> FeedPerTeeth { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<MillingInsert> MillingInserts { get; set; }
        public DbSet<MillingTool> MillingTools { get; set; }
        public DbSet<MillingToolCheckedParameters> MillingToolsCheckedParameters { get; set; }
        public DbSet<MillingToolMillingInsert> MillingToolMillingInserts { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<SolidMillingTool> SolidMillingTools { get; set; }
        public DbSet<SolidMillingToolCheckedParameters> SolidMillingToolsCheckedParameters { get; set; }
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
                .HasOne<Grade>(d => d.Grade)
                .WithMany(g => g.Drills)
                .HasForeignKey(d => d.GradeId);

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
                .HasOne<MillingInsert>(m => m.MillingInsert)
                .WithMany(mi => mi.FeedPerTeeth)
                .HasForeignKey(m => m.MillingInsertId);

            builder.Entity<FeedPerTooth>()
                .HasOne<SolidMillingTool>(m => m.SolidMillingTool)
                .WithMany(mi => mi.FeedPerTeeth)
                .HasForeignKey(m => m.SolidMillingToolId);

            builder.Entity<MillingInsert>()
                .HasOne<Grade>(mi => mi.Grade)
                .WithMany(g => g.MillingInserts)
                .HasForeignKey(mi => mi.GradeId);

            builder.Entity<MillingTool>()
                .HasOne<Producer>(mt => mt.Producer)
                .WithMany(p => p.MillingTools)
                .HasForeignKey(mt => mt.ProducerId);

            builder.Entity<MillingToolCheckedParameters>()
                .HasOne<MillingTool>(mtcp => mtcp.MillingTool)
                .WithMany(mt => mt.MillingToolCheckedParameters)
                .HasForeignKey(mtcp => mtcp.MillingToolId);

            builder.Entity<SolidMillingTool>()
                .HasOne<Grade>(smt => smt.Grade)
                .WithMany(g => g.SolidMillingTools)
                .HasForeignKey(smt => smt.GradeId);

            builder.Entity<SolidMillingTool>()
                .HasOne<Producer>(smt => smt.Producer)
                .WithMany(p => p.SolidMillingTools)
                .HasForeignKey(smt => smt.ProducerId);

            builder.Entity<SolidMillingToolCheckedParameters>()
                .HasOne<SolidMillingTool>(smtcp => smtcp.SolidMillingTool)
                .WithMany(smt => smt.SolidMillingToolCheckedParameters)
                .HasForeignKey(smtcp => smtcp.SolidMillingToolId);
        }
    }
}
