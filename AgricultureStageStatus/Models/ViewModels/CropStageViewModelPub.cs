using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgricultureStageStatus.Models.ViewModels
{
    public class CropStageViewModelPub
    {
        public string NextUrl { get; set; }
        public int TotalRecords { get; set; }
        public virtual IEnumerable<CropStageViewModel> CropStageViewModels { get; set; }
    }
    
}