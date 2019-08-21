﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SegundoParcialMVC.Filtros
{
    public class UsuarioLogueado : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["nombre"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    { "Controller", "Login" },
                    { "Action", "Index" }
                });
            }
            base.OnActionExecuting(filterContext);

        }

    }
}