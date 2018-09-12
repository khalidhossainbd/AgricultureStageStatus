namespace AgricultureStageStatus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Area")]
    public partial class Area
    {
        [Key]
        public int AreaSysID { get; set; }

        [StringLength(150)]
        public string AreaName { get; set; }

        [StringLength(50)]
        public string MapFileName { get; set; }

        [StringLength(50)]
        public string PointType { get; set; }

        public string Points { get; set; }

        [StringLength(150)]
        public string AreaBbsId { get; set; }
    }
}
