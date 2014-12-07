using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HCalc.Domain;
using HCalc.Domain.Concrete;
using HCalc.Domain.Contract;
using HCalc.Domain.Entities;
using HCalc.Domain.Enums;
using HCalc.Domain.Logic;
using HCalc.WebUI.Models;

namespace HCalc.WebUI.Controllers
{
    [Authorize]
    public class PageController : BaseController
    {
        #region Fields 

        private ConditionBuilder _conditionBuilder;

        private BuildingPartRepository _buildingPartRepository;
        private DefectDescriptionRepository _defectDescriptionRepository;

        private DefectImportanceRepository _defectImportanceRepository;
        private DefectIntencityRepository _defectIntencityRepository;
        private DefectExtentRepository _defectExtentRepository;

        private ActionRepository _actionRepository;

        private MatrixRepository _matrixRepository;

        #endregion

        #region Properties

        public ConditionBuilder ConditionBuilder {
            get { return _conditionBuilder ?? (_conditionBuilder = new ConditionBuilder()); }
            set { _conditionBuilder = value; }
        }

        #endregion

        #region Constructor

        private IUnitOfWork uow = null;

        public PageController()
        {
            uow = new UnitOfWork();

            _buildingPartRepository = new BuildingPartRepository(uow);
            _defectDescriptionRepository = new DefectDescriptionRepository(uow);
            _defectImportanceRepository = new DefectImportanceRepository(uow);
            _defectIntencityRepository = new DefectIntencityRepository(uow);
            _defectExtentRepository = new DefectExtentRepository(uow);
            _actionRepository = new ActionRepository(uow);
            _matrixRepository = new MatrixRepository(uow);
        }

        #endregion

        //
        // GET: /Page/
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View(InitCalcViewModel());
        }

        [HttpPost]
        public ActionResult Add(CalcViewModel model)
        {
            var newItem = new Matrix()
            {
                BuildingPartId = model.BuildingPartsId,
                DefectDescriptionId = model.DefectDescriptionsId,
                ImportanceId = model.DefectImportancesId,
                IntencityId = model.DefectIntencitiesId,
                ExtentId = model.DefectExtentsId,
                Condition = model.Condition,
                ActieId = model.ActionId,
                HvhId = model.Hvh,
                EenhId = model.EenhId,
                Percent = (model.Percent == 0) ? 1 : (float)0.2,
                Cost = model.Cost,
                Total = model.Total,
                BTW = model.TaxeId,
                Cycle = model.Cycle,
                StartYear = (model.StartDate.HasValue) ? model.StartDate.Value.Year : 0,
                UpdatedDate = DateTime.Now
            };

             // insert
             _matrixRepository.Insert(newItem);

             // redirect
             return RedirectToAction("Index", "Page");
        }


        public ActionResult Edit(int id)
        {
            var matrix = _matrixRepository.SingleOrDefault(id);

            if (matrix != null)
            {
                var model = InitCalcViewModel();

                model.BuildingPartsId = matrix.BuildingPartId;
                model.DefectDescriptionsId = matrix.DefectDescriptionId;
                model.DefectImportancesId = matrix.ImportanceId;
                model.DefectIntencitiesId = matrix.IntencityId;
                model.DefectExtentsId = matrix.ExtentId;
                model.ActionId = matrix.ActieId;

                //TODO: check that all params has been assigned
                model.EenhId = matrix.EenhId;
                model.TaxeId = matrix.BTW;
                model.StartDate = new DateTime(matrix.StartYear, DateTime.Now.Month, 1);

                return View(model);
            }

            return RedirectToAction("Index", "Page");
        }



        private CalcViewModel InitCalcViewModel()
        {
            var parts = new CalcViewModel
            {
                Parts = _buildingPartRepository.GetAll(),
                DefectDescriptions = _defectDescriptionRepository.GetAll(),
                DefectImportances = _defectImportanceRepository.GetAll(),
                DefectIntencities = _defectIntencityRepository.GetAll(),
                DefectExtents = _defectExtentRepository.GetAll(),
                Actions = _actionRepository.GetAll()
            };

            // Eenh enum
            IEnumerable<Eenh> eenhsTypes = Enum.GetValues(typeof(Eenh)).Cast<Eenh>();
            parts.EenhList = from eenh in eenhsTypes
                             select new SelectListItem
                             {
                                 Text = eenh.ToString(),
                                 Value = ((int)eenh).ToString()
                             };

            // Taxes enum
            IEnumerable<Taxe> taxeTypes = Enum.GetValues(typeof(Taxe)).Cast<Taxe>();
            parts.TaxeList = from taxe in taxeTypes
                             select new SelectListItem
                             {
                                 Text = taxe.ToString(),
                                 Value = ((int)taxe).ToString()
                             };

            return parts;
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        #region Ajax calls

        [HttpGet]
        public string GetCondition(int extent, int intencity, int importance)
        {
            var result = ConditionBuilder.GetCondition(extent, intencity, importance);
            return (result == 0) ? "-" : result.ToString();
        }

        [HttpGet]
        public int GetTotalCost(int count, int percentId, int cost)
        {
            var percent = (percentId == 0) ? 1 : 0.2;
            return Convert.ToInt32(count * percent * cost);
        }

        [HttpGet]
        public string GetCalendarCostList(int total, int taxe, int cycle, int year)
        {
            var sb = new StringBuilder();
            var yearCost = Convert.ToInt32(total/taxe*100) + total;
            int nextYear = year;

            if (cycle == 99)
            {
                // one time action
                sb.AppendFormat("<li><span class=\"label label-info\">{0}</span> - {1} &euro;</li>",
                    nextYear,
                    yearCost);
            }
            else
            {
                for (int i = 0; i < cycle; i++) {
                    if (i > 0) {
                        nextYear += cycle;
                    }

                    sb.AppendFormat("<li><span class=\"label label-info\">{0}</span> - {1} &euro;</li>",
                        nextYear,
                        yearCost);
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}