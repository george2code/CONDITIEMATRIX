﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HCalc.Domain.Entities;

namespace HCalc.WebUI.Models
{
    public class CalcViewModel
    {
        [Display(Name = "Bouwdeel / onderdeel")]
        public Nullable<int> BuildingPartsId { get; set; }
        public IEnumerable<BuildingPart> Parts { get; set; }

        [Display(Name = "Gebrek")]
        public Nullable<int> DefectDescriptionsId { get; set; }
        public IEnumerable<DefectDescription> DefectDescriptions { get; set; }


        // Importance
        [Display(Name = " Importance (Gebr)")]
        public int DefectImportancesId { get; set; }
        public IEnumerable<DefectImportance> DefectImportances { get; set; }
        // Intencity
        [Display(Name = "Intencity (Int)")]
        public int DefectIntencitiesId { get; set; }
        public IEnumerable<DefectIntencity> DefectIntencities { get; set; }
        // Extent 
        [Display(Name = "Extent (OMV)")]
        public int DefectExtentsId { get; set; }
        public IEnumerable<DefectExtent> DefectExtents { get; set; }

        [Display(Name = "Actie")]
        public Nullable<int> ActionId { get; set; }
        public IEnumerable<HCalc.Domain.Entities.Action> Actions { get; set; }

        [Display(Name = "Eenh")]
        public int EenhId { get; set; }
        public IEnumerable<SelectListItem> EenhList { get; set; }

        [Display(Name = "BTW")]
        public int TaxeId { get; set; }
        public IEnumerable<SelectListItem> TaxeList { get; set; }

        [Display(Name = "%")]
        public int Percent { get; set; }


        [Display(Name = "Kosten")]
        public int Cost { get; set; }

        [Display(Name = "Cycle")]
        public int Cycle { get; set; }

        [Display(Name = "Startjaar")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{YYYY/MM/DD}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> StartDate { get; set; }

        public int StartYear { get; set; }

        [Display(Name = "Hvh")]
        public int Hvh { get; set; }

        public int Condition { get; set; }

        public int Total { get; set; }
    }
}