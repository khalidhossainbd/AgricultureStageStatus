
using AgricultureStageStatus.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgricultureStageStatus.Controllers
{
    public class CropStageController : ApiController
    {
        CropStage db = new CropStage();
        // GET: api/CropStage
        [HttpGet]
        public List<CropStageViewModel> Get()
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.ToList();
            
            List<CropStageViewModel> data= oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
            {
                District = c.DistBbsId,
                stg_rcv = c.Recovry,
                stg_tlr = c.Tillering,
                stg_pni = c.P_I,
                stg_btg = c.Booting,
                stg_flr = c.Flowering,
                stg_sdf = c.SoftDough,
                stg_hdf = c.HardDough,
                stg_rpn = c.Ripening,
                stg_hrv = c.Harvesting,
                Season = c.SeasonCode
            }).ToList();

            return data;
        }

        [HttpGet]
        // GET: api/CropStage/5
        public List<CropStageViewModel> Get(string distBbsId)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.Where(c=>c.DistBbsId== distBbsId).ToList();
           
            List<CropStageViewModel> data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
            {
                District= c.DistBbsId,
                stg_rcv = c.Recovry,
                stg_tlr = c.Tillering,
                stg_pni = c.P_I,
                stg_btg = c.Booting,
                stg_flr = c.Flowering,
                stg_sdf = c.SoftDough,
                stg_hdf = c.HardDough,
                stg_rpn = c.Ripening,
                stg_hrv = c.Harvesting,
                Season = c.SeasonCode
            }).ToList();

            return data;
        }


        [HttpGet]
        // GET: api/CropStage/5
        public List<CropStageViewModel> Get(string distBbsId, string seasonCode)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.Where(c => c.DistBbsId == distBbsId && c.SeasonCode == seasonCode).ToList();
            //var data = oc.CropStageList.Select(c => c.DistBbsId).ToList();

            List<CropStageViewModel> data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
            {
                District = c.DistBbsId,
                stg_rcv = c.Recovry,
                stg_tlr = c.Tillering,
                stg_pni = c.P_I,
                stg_btg = c.Booting,
                stg_flr = c.Flowering,
                stg_sdf = c.SoftDough,
                stg_hdf = c.HardDough,
                stg_rpn = c.Ripening,
                stg_hrv = c.Harvesting,
                Season = c.SeasonCode
            }).ToList();

            return data;
        }


        public List<CropStageViewModel> Get(DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.Where(d => Convert.ToDateTime(d.DateCreated) >= fromDate && Convert.ToDateTime(d.DateCreated) <= toDate).ToList();
            List<CropStageViewModel> data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
            {
                District = c.DistBbsId,
                stg_rcv = c.Recovry,
                stg_tlr = c.Tillering,
                stg_pni = c.P_I,
                stg_btg = c.Booting,
                stg_flr = c.Flowering,
                stg_sdf = c.SoftDough,
                stg_hdf = c.HardDough,
                stg_rpn = c.Ripening,
                stg_hrv = c.Harvesting,
                Season = c.SeasonCode
            }).ToList();
            return data;
        }



        // POST: api/CropStage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CropStage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CropStage/5
        public void Delete(int id)
        {
        }
    }
}
