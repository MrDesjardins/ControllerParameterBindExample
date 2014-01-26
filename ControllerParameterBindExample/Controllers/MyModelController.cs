using ControllerParameterBindExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerParameterBindExample.Controllers
{
    public class MyModelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region Default Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MyModel model)
        {
            SetViewBagFromModel(model);

            return View();
        }
        #endregion

        #region Create Black Listing Property
        [HttpGet]
        public ActionResult CreateWithBindingExclude()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateWithBindingExclude([Bind(Exclude="Property1, Property2")]MyModel model)
        {
            SetViewBagFromModel(model);
            return View("Create");
        }
        #endregion

        #region Create White Listing Property

        [HttpGet]
        public ActionResult CreateWithBindingInclude()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateWithBindingInclude([Bind(Exclude = "Property1, Property2")]MyModel model)
        {
            SetViewBagFromModel(model);
            return View("Create");
        }
        #endregion

        private void SetViewBagFromModel(MyModel model)
        {
            ViewBag.Prop1 = model.Property1;
            ViewBag.Prop2 = model.Property2;
            ViewBag.Prop3 = model.Property3;
            ViewBag.Prop4 = model.Property4;
            ViewBag.Prop5 = model.Property5;
        }

	}
}