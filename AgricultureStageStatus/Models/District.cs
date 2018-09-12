namespace AgricultureStageStatus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("District")]
    public partial class District
    {
        [Key]
        public int DistrictSysID { get; set; }

        [StringLength(150)]
        public string DistrictName { get; set; }

        public int? AreaSysID { get; set; }

        [StringLength(2)]
        public string DistrictCode { get; set; }

        [StringLength(50)]
        public string MapFileName { get; set; }

        [StringLength(50)]
        public string PointType { get; set; }

        public string Points { get; set; }

        [StringLength(50)]
        public string lat { get; set; }

        [StringLength(50)]
        public string lon { get; set; }

        [Required]
        [StringLength(50)]
        public string DistBbsId { get; set; }

        [Required]
        [StringLength(50)]
        public string AreaBbsId { get; set; }
    }
}
