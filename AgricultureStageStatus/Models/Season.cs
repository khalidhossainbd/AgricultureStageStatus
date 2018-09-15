namespace AgricultureStageStatus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Season")]
    public partial class Season
    {
        public int SeasonID { get; set; }

        [Required]
        [StringLength(50)]
        public string SeasonName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [StringLength(50)]
        public string SeasonCode { get; set; }
    }
}
