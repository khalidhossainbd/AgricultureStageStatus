namespace AgricultureStageStatus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FiscalYear")]
    public partial class FiscalYear
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string FiscalYearName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string FiscalCode { get; set; }
    }
}
