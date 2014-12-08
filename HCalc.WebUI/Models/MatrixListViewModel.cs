using System.Collections.Generic;

namespace HCalc.WebUI.Models
{
    public class MatrixListViewModel
    {
        public List<MatrixViewModel> Matrices { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}