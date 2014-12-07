using System.Web.Mvc;
using HCalc.WebUI.Utils;

namespace HCalc.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public UserInfo CurrentUser
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserInfo"] != null)
                    return (UserInfo)System.Web.HttpContext.Current.Session["UserInfo"];
                return null;
            }
            set { System.Web.HttpContext.Current.Session["UserInfo"] = value; }
        }
	}
}