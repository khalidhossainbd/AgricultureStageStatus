namespace AgricultureStageStatus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("CropDailyStage")]
    public partial class CropDailyStage
    {
        public int ID { get; set; }
        public int DistrictID { get; set; }
        public int FiscalYearID { get; set; }
        public int SeasonID { get; set; }
        public int? CropID { get; set; }
        public int? CropVarityID { get; set; }
        public DateTime? MeasureDate { get; set; }
        public int? LastModifiedByID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public short? Tillering { get; set; }
        public short? P_I { get; set; }
        public short? Booting { get; set; }
        public short? Flowering { get; set; }
        public short? SoftDough { get; set; }
        public short? HardDough { get; set; }
        public short? Ripening { get; set; }
        public short? Harvesting { get; set; }        
        public short? Recovry { get; set; }
        [StringLength(50)]
        public string FiscalCode { get; set; }
        [StringLength(50)]
        public string DistBbsId { get; set; }
        [StringLength(50)]
        public string SeasonCode { get; set; }
        [NotMapped]
        public List<CropDailyStage> CropStageList { get; set; }
    }
}
