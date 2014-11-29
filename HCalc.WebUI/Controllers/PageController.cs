using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HCalc.Domain.Abstract;
using HCalc.Domain.Entities;
using HCalc.Domain.Enums;
using HCalc.Domain.Logic;
using HCalc.WebUI.Models;
using Ninject;

namespace HCalc.WebUI.Controllers
{
    public class PageController : Controller
    {
        #region Fields 

        private ConditionBuilder _conditionBuilder;

        private IBuildingPartRepository _buildingPartRepository;
        private IDefectDescriptionRepository _defectDescriptionRepository;

        private IDefectImportanceRepository _defectImportanceRepository;
        private IDefectIntencityRepository _defectIntencityRepository;
        private IDefectExtentRepository _defectExtentRepository;

        private IActionRepository _actionRepository;

        #endregion

        public ConditionBuilder ConditionBuilder
        {
            get {
                if (_conditionBuilder == null)
                {
                    
                } }
        }

        [Inject]
        public PageController(IBuildingPartRepository buildingPartRepository, 
            IDefectDescriptionRepository defectDescriptionRepository,
            IDefectImportanceRepository defectImportanceRepository,
            IDefectIntencityRepository defectIntencityRepository,
            IDefectExtentRepository defectExtentRepository,
            IActionRepository actionRepository)
        {
            _buildingPartRepository = buildingPartRepository;
            _defectDescriptionRepository = defectDescriptionRepository;
            _defectImportanceRepository = defectImportanceRepository;
            _defectIntencityRepository = defectIntencityRepository;
            _defectExtentRepository = defectExtentRepository;
            _actionRepository = actionRepository;
        }

        //
        // GET: /Page/
        public ActionResult Index()
        {
            var parts = new CalcViewModel
            {
                Parts = _buildingPartRepository.BuildingParts,
                DefectDescriptions = _defectDescriptionRepository.DefectDescriptions,
                DefectImportances = _defectImportanceRepository.DefectImportances,
                DefectIntencities = _defectIntencityRepository.DefectIntencities,
                DefectExtents = _defectExtentRepository.DefectExtents,
                Actions = _actionRepository.Actions
            };

            // Eenh enum
            IEnumerable<Eenh> actionTypes = Enum.GetValues(typeof(Eenh)).Cast<Eenh>();
            parts.EenhList = from action in actionTypes
                                select new SelectListItem {
                                    Text = action.ToString(),
                                    Value = ((int)action).ToString()
                                };

            // Taxes enum
            IEnumerable<Taxe> taxeTypes = Enum.GetValues(typeof(Taxe)).Cast<Taxe>();
            parts.TaxeList = from taxe in taxeTypes
                             select new SelectListItem {
                                 Text = taxe.ToString(),
                                 Value = ((int)taxe).ToString()
                             };

            return View(parts);
        }


        [HttpPost]
        public ActionResult Index(CalcViewModel model)
        {
//            var newItem = new Matrix()
//            {
//                DefectDescriptionId = model.DefectDescriptions.
//            }



            // id Bouwdeel (Building parts)

            // id Geberk

            // id Importance 
            // id Intencity 
            // id Extent 

            // condition

            // id Actie

            // Hvh id
            // Eenh id
            // percent id
            // cost
            // total


            // BTW 6 / 19
            // Cycle
            // Start year





            return View(model);
        }


        [HttpGet]
        public string GetCondition(int extent, int intencity, int importance)
        {
            var conditionBuilder = new ConditionBuilder();
                var result = conditionBuilder.GetCondition(extent, intencity, importance);
            return (result == 0) ? "-" : result.ToString();
        }

        [HttpGet]
        public int GetTotalCost(int count, int percentId, int cost)
        {
            var percent = (percentId == 0) ? 1 : 0.2;
            return Convert.ToInt32(count * percent * cost);
        }
	}
}