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

        private const int PAGE_SIZE = 10;

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
        public ActionResult Index(int page = 1)
        {
            var matrices = _matrixRepository.GetAll()
                .OrderByDescending(m => m.Id)
                .Skip((page - 1)*PAGE_SIZE)
                .Take(PAGE_SIZE);

            var matrixListViewModel = new MatrixListViewModel()
            {
                Matrices = new List<MatrixViewModel>(),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = _matrixRepository.GetAll().Count()
                }
            };


            if (matrices.Any())
            {
                foreach (var matrix in matrices)
                {
                    var model = new MatrixViewModel();

                    var buildingPart = (matrix.BuildingPartId.HasValue)
                        ? _buildingPartRepository.SingleOrDefault(matrix.BuildingPartId.Value)
                        : null;

                    var defectDescription = (matrix.DefectDescriptionId.HasValue)
                        ? _defectDescriptionRepository.SingleOrDefault(matrix.DefectDescriptionId.Value)
                        : null;
                        
                    model.Id = matrix.Id;
                    model.BuildingPartCode = (buildingPart != null) ? (double?)buildingPart.Code : null;
                    model.BuildingPartText = (buildingPart != null) ? buildingPart.Name : null;

                    model.DefectDescriptionText = (defectDescription != null) ? defectDescription.Description : null;

                    model.Gebr = matrix.ImportanceId;
                    model.Intencity = matrix.IntencityId;
                    model.Omvang = matrix.ExtentId;
                    model.Condition = matrix.Condition;

                    if (matrix.ActieId.HasValue)
                        model.Action = _actionRepository.SingleOrDefault(matrix.ActieId.Value).Name;

                    model.CountHvh = matrix.HvhId;
                    model.Eenh = ((Eenh) matrix.EenhId).ToString();
                    model.Percent = matrix.Percent.HasValue ? matrix.Percent.Value.ToString() : string.Empty;

                    model.Cost = matrix.Cost;
                    model.Total = matrix.Total.HasValue ? matrix.Total.Value : 0;
                    model.BTW = matrix.BTW;
                    model.Cycle = matrix.Cycle;

                    model.StartYear = matrix.StartYear;


                    // render calendar cost
                    model.CalendarBuilder = RenderCalendarCostString(model.Total, matrix.BTW, matrix.Cycle,
                        matrix.StartYear);

                    // append to list
                    matrixListViewModel.Matrices.Add(model);
                }
            }


            return View(matrixListViewModel);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View(InitCalcViewModel());
        }

        [HttpPost]
        public ActionResult Add(CalcViewModel model)
        {
            if (ModelState.IsValid)
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
                    Percent = (model.Percent == 0) ? 1 : (float) 0.2,
                    Cost = model.Cost,
                    Total = model.Total,
                    BTW = model.TaxeId,
                    Cycle = model.Cycle,
                    StartYear = model.StartYear,
                    UpdatedDate = DateTime.Now
                };

                // insert
                _matrixRepository.Insert(newItem);

                // redirect
                return RedirectToAction("Index", "Page");
            }

            model = updateCalcViewModel(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var matrix = _matrixRepository.SingleOrDefault(id);

            if (matrix != null)
            {
                var model = InitCalcViewModel();

                model.Id = id;

                model.BuildingPartsId = matrix.BuildingPartId;
                model.DefectDescriptionsId = matrix.DefectDescriptionId;
                model.DefectImportancesId = matrix.ImportanceId;
                model.DefectIntencitiesId = matrix.IntencityId;
                model.DefectExtentsId = matrix.ExtentId;
                model.Condition = matrix.Condition;
                model.ActionId = matrix.ActieId;

                model.Hvh = matrix.HvhId;
                model.EenhId = matrix.EenhId;
                model.Percent = (matrix.Percent == 1) ? 0 : 1;
                model.Cost = matrix.Cost;
               
                if (matrix.Total.HasValue)
                 model.Total = matrix.Total.Value;

                //TODO: check that all params has been assigned
                model.TaxeId = matrix.BTW;
                model.Cycle = matrix.Cycle;
                model.StartYear = matrix.StartYear;

                return View(model);
            }

            return RedirectToAction("Index", "Page");
        }


        [HttpPost]
        public ActionResult Edit(CalcViewModel model)
        {
            model = updateCalcViewModel(model);

            if (ModelState.IsValid)
            {
                var matrixEntity = new Matrix()
                {
                    Id =  model.Id,
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
                    StartYear = model.StartYear,
                    UpdatedDate = DateTime.Now
                };

                // update
                _matrixRepository.Update(matrixEntity);

                // back to home page
                return RedirectToAction("Index");
            }

            return View(model);
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
        public void DeleteCondition(int id)
        {
            var entity = _matrixRepository.SingleOrDefault(id);
            if (entity != null)
            {
                _matrixRepository.Delete(entity);
            }
        }

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
            var yearCost = Convert.ToInt32(total*taxe/100) + total;
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

        #region Methods
        private string RenderCalendarCostString(int total, int taxe, int cycle, int year)
        {
            var sb = new StringBuilder();
            var yearCost = Convert.ToInt32(total * taxe / 100) + total;
            int nextYear = year;

            for (int i = 0; i < cycle; i++)
            {
                if (i > 0)
                {
                    nextYear += cycle;
                }

                sb.AppendFormat("{0} - &euro;{1}, ",
                    nextYear,
                    yearCost);

                if (cycle == 99)
                    break;
            }


            var result = sb.ToString();
            var index = result.LastIndexOf(", ");
            return result.Remove(index);
        }

        private CalcViewModel InitCalcViewModel()
        {
            var parts = new CalcViewModel {
                Parts = _buildingPartRepository.GetAll(),
                DefectDescriptions = _defectDescriptionRepository.GetAll(),
                DefectImportances = _defectImportanceRepository.GetAll(),
                DefectIntencities = _defectIntencityRepository.GetAll(),
                DefectExtents = _defectExtentRepository.GetAll(),
                Actions = _actionRepository.GetAll(),
                StartYear = 2014
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

        private CalcViewModel updateCalcViewModel(CalcViewModel model)
        {
            model.Parts = _buildingPartRepository.GetAll();
            model.DefectDescriptions = _defectDescriptionRepository.GetAll();
            model.DefectImportances = _defectImportanceRepository.GetAll();
            model.DefectIntencities = _defectIntencityRepository.GetAll();
            model.DefectExtents = _defectExtentRepository.GetAll();
            model.Actions = _actionRepository.GetAll();

            // Eenh enum
            IEnumerable<Eenh> eenhsTypes = Enum.GetValues(typeof(Eenh)).Cast<Eenh>();
            model.EenhList = from eenh in eenhsTypes
                             select new SelectListItem
                             {
                                 Text = eenh.ToString(),
                                 Value = ((int)eenh).ToString()
                             };

            // Taxes enum
            IEnumerable<Taxe> taxeTypes = Enum.GetValues(typeof(Taxe)).Cast<Taxe>();
            model.TaxeList = from taxe in taxeTypes
                             select new SelectListItem
                             {
                                 Text = taxe.ToString(),
                                 Value = ((int)taxe).ToString()
                             };

            return model;
        }

        #endregion
    }
}