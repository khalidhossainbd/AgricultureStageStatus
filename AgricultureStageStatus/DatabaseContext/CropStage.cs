namespace AgricultureStageStatus
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CropStage : DbContext
    {
        public CropStage()
            : base("name=CropStage")
        {
        }

        public virtual DbSet<CropDailyStage> CropDailyStages { get; set; }
        public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Area> Region { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
