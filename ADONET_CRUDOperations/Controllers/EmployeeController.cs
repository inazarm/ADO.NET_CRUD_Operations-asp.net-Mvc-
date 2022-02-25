using ADONET_CRUDOperations.DataAccess;
using ADONET_CRUDOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADONET_CRUDOperations.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Employee empObj = new Employee();
            EmployeeDAL empDAL = new EmployeeDAL();
            empObj.ShowAllEmployee = empDAL.Selectalldata();
            return View(empObj);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee empObj)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    EmployeeDAL empDAL = new EmployeeDAL();
                    var result = empDAL.InsertData(empObj);
                    ViewData["data"] = result;
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                var ex_msg = ex.Message.ToString();
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            Employee empObj = new Employee();
            EmployeeDAL empDAL = new EmployeeDAL();
            return View(empDAL.SelectDatabyID(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
