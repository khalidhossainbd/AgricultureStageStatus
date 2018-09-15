
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
        // GET: api/CropStage
        [HttpGet]
        public CropStageViewModelPub Get(int record_from, int record_to)
        {
            CropStageViewModelPub returnData = new CropStageViewModelPub();

            if (record_to - record_from > 100) {
                return returnData;
            }
            CropStage db = new CropStage();
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            var croplist= db.CropDailyStages.OrderBy(x=> x.ID ).Skip(record_from).Take(record_to).ToList();
            returnData.TotalRecords = db.CropDailyStages.Count();
            
            data = croplist.AsEnumerable().Select(c => new CropStageViewModel
            {
                Id = c.ID,
                Region = this.GetAreaCode(c.DistBbsId),
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
                MeasureDate =c.MeasureDate
            }).ToList();
            returnData.CropStageViewModels = data;
            returnData.NextUrl = "http://localhost:53904/api/cropstage?record_from="+ record_to.ToString() + "&record_to=" + (record_to +100).ToString();
            return returnData;
        }
        [HttpGet]
        public List<CropStageViewModel> Get(int id)
        {
            CropStage db = new CropStage();
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            oc.CropStageList = db.CropDailyStages.Where(c => c.ID == id).ToList();
            
            data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
            {
                Id = c.ID,
                Region = this.GetAreaCode(c.DistBbsId),
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
        // GET: api/CropStage/5
        public List<CropStageViewModel> Get(string distBbsId)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            using(CropStage db = new CropStage()) { 
            oc.CropStageList = db.CropDailyStages.Where(c=>c.DistBbsId== distBbsId).ToList();
           
            data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
            {
                Id = c.ID,
                Region = this.GetAreaCode(c.DistBbsId),
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
            }
            return data;
        }
        
        [HttpGet]
        // GET: api/CropStage/5
        public List<CropStageViewModel> Get(string distBbsId, string seasonCode)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            using (CropStage db = new CropStage())
            {
                oc.CropStageList = db.CropDailyStages.Where(c => c.DistBbsId == distBbsId && c.SeasonCode == seasonCode).ToList();
                data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
                {
                    Id = c.ID,
                    Region = this.GetAreaCode(c.DistBbsId),
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
            }
            return data;
        }

        [HttpGet]
        public List<CropStageViewModel> Get(DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            using (CropStage db = new CropStage())
            {
                oc.CropStageList = db.CropDailyStages.Where(d => d.DateCreated >= fromDate && d.MeasureDate <= toDate).ToList();
                data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
                {
                    Id = c.ID,
                    Region = this.GetAreaCode(c.DistBbsId),
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
            }
            return data;
        }

        [HttpGet]
        public List<CropStageViewModel> Get(string distBbsId, DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            using (CropStage db = new CropStage())
            {
                oc.CropStageList = db.CropDailyStages.Where(d => d.DateCreated >= fromDate && d.MeasureDate <= toDate && d.DistBbsId == distBbsId).ToList();
                data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
                {
                    Id = c.ID,
                    Region = this.GetAreaCode(c.DistBbsId),
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
            }
            return data;
        }
        
        [HttpGet]
        public List<CropStageViewModel> Get(string distBbsId, string seasonCode, DateTime fromDate, DateTime toDate)
        {
            CropStageViewModel result = new CropStageViewModel();
            CropDailyStage oc = new CropDailyStage();
            List<CropStageViewModel> data = new List<CropStageViewModel>();
            using (CropStage db = new CropStage())
            {
                oc.CropStageList = db.CropDailyStages.Where(d => d.DateCreated >= fromDate && d.MeasureDate <= toDate && d.DistBbsId == distBbsId && d.SeasonCode == seasonCode).ToList();
                data = oc.CropStageList.AsEnumerable().Select(c => new CropStageViewModel
                {
                    Id = c.ID,
                    Region = this.GetAreaCode(c.DistBbsId),
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
            }
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
            cds.SeasonID = this.GetSeasonId(value.Season);
            cds.SeasonCode = value.Season;
            cds.FiscalCode = value.FiscalCode;
            cds.FiscalYearID = this.GetFiscalId(value.FiscalCode);
            cds.DistrictID = this.GetDistId(value.District);
            cds.DateCreated = DateTime.Now;
            cds.MeasureDate = value.MeasureDate;
            using (CropStage db = new CropStage())
            {
                db.CropDailyStages.Add(cds);
                db.SaveChanges(); 
            }
              
        }
        // PUT: api/CropStage/5
        public void Put(int id, [FromBody]CropStageViewModel value)
        {
            CropStage db = new CropStage();
            CropDailyStage cds = new CropDailyStage();
            cds.ID = id;
            cds.DistBbsId = value.District;
            cds.Recovry = value.stg_rcv;
            cds.Tillering = value.stg_tlr;
            cds.P_I = value.stg_pni;
            cds.Booting = value.stg_btg;
            cds.Flowering = value.stg_flr;
            cds.SoftDough = value.stg_sdf;
            cds.HardDough = value.stg_hdf;
            cds.Ripening = value.stg_rpn;
            cds.Harvesting = value.stg_hrv;
            cds.SeasonID = this.GetSeasonId(value.Season);
            cds.SeasonCode = value.Season;
            cds.FiscalCode = value.FiscalCode;
            cds.FiscalYearID = this.GetFiscalId(value.FiscalCode);
            cds.DistrictID = this.GetDistId(value.District);
            
            //var crop = db.CropDailyStages.Where(x => x.ID == id).FirstOrDefault();
            
            db.CropDailyStages.Attach(cds);
            db.Entry(cds).State = EntityState.Modified;
            var bl = db.SaveChanges()>0;
           
        }
        // DELETE: api/CropStage/5
        public void Delete(int id)
        {
            using(CropStage db = new CropStage()) { 
            db.CropDailyStages.Remove(db.CropDailyStages.FirstOrDefault(d => d.ID == id));
            db.SaveChanges();
            }
        }
        public int GetFiscalId(string code)
        {
            using (CropStage db = new CropStage())
            {
                var data = db.FiscalYears.FirstOrDefault(a => a.FiscalCode == code);
                return data.ID;
            }
        }
        public int GetDistId(string code)
        {
            using (CropStage db = new CropStage())
            {
                var data = db.Districts.FirstOrDefault(a => a.DistBbsId == code);
                return data.DistrictSysID;
            }
            
        }
        public int GetSeasonId(string code)
        {
            using (CropStage db = new CropStage())
            {
                var data = db.Seasons.FirstOrDefault(a => a.SeasonCode == code);
                return data.SeasonID;
            }
            
        }
        public string GetAreaCode(string code)
        {
            using (CropStage db = new CropStage())
            {
                var area = db.Districts.FirstOrDefault(a => a.DistBbsId == code);
                return area.AreaBbsId;
            }
        }
    }
}
