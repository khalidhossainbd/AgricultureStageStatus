
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
                Season = c.SeasonCode,
                DateCreated = c.DateCreated
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
                Season = c.SeasonCode,
                FiscalCode = c.FiscalCode,
                DateCreated = c.DateCreated,
                MeasureDate = c.MeasureDate
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
                Season = c.SeasonCode,
                FiscalCode = c.FiscalCode,
                DateCreated = c.DateCreated,
                MeasureDate = c.MeasureDate
            }).ToList();

            return data;
        }

        [HttpGet]
        public List<CropStageViewModel> Get(DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.Where(d => d.DateCreated >= fromDate && d.MeasureDate <= toDate).ToList();
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
                Season = c.SeasonCode,
                FiscalCode =c.FiscalCode,
                DateCreated = c.DateCreated,
                MeasureDate = c.MeasureDate
            }).ToList();
            return data;
        }

        [HttpGet]
        public List<CropStageViewModel> Get(string distBbsId, DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.Where(d => d.DateCreated >= fromDate && d.MeasureDate <= toDate && d.DistBbsId == distBbsId).ToList();
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
                Season = c.SeasonCode,
                FiscalCode = c.FiscalCode,
                DateCreated = c.DateCreated,
                MeasureDate = c.MeasureDate
            }).ToList();
            return data;
        }


        [HttpGet]
        public List<CropStageViewModel> Get(string distBbsId, string seasonCode, DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            oc.CropStageList = db.CropDailyStages.Where(d => d.DateCreated >= fromDate && d.MeasureDate <= toDate && d.DistBbsId == distBbsId && d.SeasonCode == seasonCode).ToList();
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
                Season = c.SeasonCode,
                FiscalCode = c.FiscalCode,
                DateCreated = c.DateCreated,
                MeasureDate = c.MeasureDate
            }).ToList();
            return data;
        }

        [HttpPost]
        // POST: api/CropStage
        public void Post([FromBody]CropStageViewModel value)
        {
            CropDailyStage cds = new CropDailyStage();
            cds.DistBbsId = value.District;
            cds.Recovry = value.stg_rcv;
            cds.Tillering = value.stg_tlr;
            cds.P_I = value.stg_pni;
            cds.Booting = value.stg_btg;
            cds.Flowering = value.stg_flr;
            cds.SoftDough = value.stg_sdf;
            cds.HardDough = value.stg_hdf;
            cds.Ripening= value.stg_rpn;
            cds.Harvesting = value.stg_hrv;
            cds.SeasonCode = value.Season;
            cds.FiscalCode = value.FiscalCode;
            cds.FiscalYearID = this.GetFiscalId(value.FiscalCode);
            cds.DistrictID = this.GetDistId(value.District);
            cds.DateCreated = value.DateCreated;
            cds.MeasureDate = value.MeasureDate;
            db.CropDailyStages.Add(cds);
            db.SaveChanges();   
        }

        // PUT: api/CropStage/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/CropStage/5
        public void Delete(int id)
        {
            db.CropDailyStages.Remove(db.CropDailyStages.FirstOrDefault(d => d.ID == id));
            db.SaveChanges();
        }
        public int GetFiscalId(string code)
        {
            var data = db.FiscalYears.FirstOrDefault(a => a.FiscalCode == code);
            return data.ID;
        }
        public int GetDistId(string code)
        {
            var data = db.Districts.FirstOrDefault(a => a.DistBbsId == code);
            return data.DistrictSysID;
        }


    }
}
