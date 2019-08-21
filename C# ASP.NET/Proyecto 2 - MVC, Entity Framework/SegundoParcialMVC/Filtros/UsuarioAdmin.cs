using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SegundoParcialMVC.Filtros
{
    public class UsuarioAdmin : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["esAdmin"] != null && HttpContext.Current.Session["esAdmin"].Equals(false))
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    { "Controller", "Productos" },
                    { "Action", "Index" }
                });
            }
            base.OnActionExecuting(filterContext);
        }

    }
}