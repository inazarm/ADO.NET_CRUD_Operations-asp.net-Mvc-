using ADONET_CRUDOperations.DataAccess;
using ADONET_CRUDOperations.Models;
using System;
using System.Web.Mvc;

namespace ADONET_CRUDOperations.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }
        public ActionResult InsertCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]

        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
                string result = objDB.UpdateData(objCustomer);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]

        public ActionResult Delete(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]

        public ActionResult Delete(Customer objCustomer)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            string result = objDB.DeleteData(objCustomer);
            ViewData["result"] = result;
            ModelState.Clear(); //clearing model
            return View();
        }
    }
}