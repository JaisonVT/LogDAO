using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogDAO.Models;
using LogDAO.Services.Data;

namespace LogDAO.Controllers
{
    public class GadgetController : Controller
    {
        // GET: Gadget
        public ActionResult GadgetList()
        {
            List<GadgetModel> gadgetModels = new List<GadgetModel>();
            GadgetOperations gadgetOperations = new GadgetOperations();
            gadgetModels = gadgetOperations.FetchAll();

            return View(gadgetModels);
        }
        public ActionResult SingleDetails(int Id)
        {
            GadgetOperations gadgetOperations = new GadgetOperations();
 
            GadgetModel gad = gadgetOperations.FetchOne(Id);
            return View(gad);
        }
        public ActionResult Edit(int id)
        {
            GadgetOperations gad = new GadgetOperations();

            GadgetModel gadget = gad.Edit(id);
            return View(gadget);
        }
        public ActionResult EditAction(GadgetModel gadget)
        {
            GadgetOperations gadgetOperations = new GadgetOperations();

            GadgetModel gad = gadgetOperations.Update(gadget);
            
            List<GadgetModel> gadgetModels = new List<GadgetModel>();
            GadgetOperations gadgetOp = new GadgetOperations();
            gadgetModels = gadgetOp.FetchAll();

            return View("GadgetList", gadgetModels);
        }
        public ActionResult Delete(int id)
        {
            GadgetOperations gad = new GadgetOperations();
            gad.DeleteOperation(id);

            List<GadgetModel> gadgetModels = new List<GadgetModel>();
            GadgetOperations gadgetOp = new GadgetOperations();
            gadgetModels = gadgetOp.FetchAll();

            return View("GadgetList", gadgetModels);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult CreateAction(GadgetModel gadget)
        {
            GadgetOperations gd = new GadgetOperations();
            gd.InsertGadget(gadget);

            List<GadgetModel> gadgetModels = new List<GadgetModel>();
            GadgetOperations gadgetOp = new GadgetOperations();
            gadgetModels = gadgetOp.FetchAll();
            return View("GadgetList", gadgetModels);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchAction(string SearchByName)
        {
            GadgetOperations gad = new GadgetOperations();
            List<GadgetModel> gadgets = gad.SearchAll(SearchByName);
            return View("GadgetList", gadgets);
        }
    }
}