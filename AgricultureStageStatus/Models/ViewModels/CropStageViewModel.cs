using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgricultureStageStatus.Models.ViewModels
{
    public class CropStageViewModel
    {
        public string Region { get; set; }
        public string District { get; set; }
        public string Season { get; set; }
        public short? stg_rcv { get; set; }
        public short? stg_tlr { get; set; }
        public short? stg_pni { get; set; }
        public short? stg_btg { get; set; }
        public short? stg_flr { get; set; }
        public short? stg_sdf { get; set; }
        public short? stg_hdf { get; set; }
        public short? stg_rpn { get; set; }
        public short? stg_hrv { get; set; }

    }
    
}