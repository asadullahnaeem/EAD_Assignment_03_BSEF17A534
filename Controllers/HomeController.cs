using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prayer.Models;

namespace prayer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View(dc.myLists.Select(c => c.Area).Distinct().ToList());
        }
        public ActionResult GetList24()
        {
            var area = Request["area"];
            return View(dc.myLists.Where(c => c.Area == area));
        }
        public ActionResult GetList12()
        {
            var area = Request["area"];
            return View(dc.myLists.Where(c => c.Area == area));
        }

        public ActionResult Delete(int id)
        {
            var row = dc.myLists.First(c => c.ID == id);
            dc.myLists.DeleteOnSubmit(row);
            dc.SubmitChanges();
            TempData["Message"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Edit24(int id)
        {
            return View(dc.myLists.First(c=>c.ID == id));
        }
        public ActionResult Edit12(int id)
        {
            return View(dc.myLists.First(c => c.ID == id));
        }
        public ActionResult EditDone24(int id)
        {
            var val = dc.myLists.First(c => c.ID == id);
            val.Area = Request["area"];
            val.Mosque = Request["mosque-name"];
            val.Address = Request["address"];
            val.Fajar = new TimeSpan(Convert.ToInt16(Request["fajar_hours"]) , Convert.ToInt16(Request["fajar_minutes"]),0);
            val.Duhur = new TimeSpan(Convert.ToInt16(Request["duhur_hours"]), Convert.ToInt16(Request["duhur_minutes"]), 0);
            val.Asar  = new TimeSpan(Convert.ToInt16(Request["asar_hours"]), Convert.ToInt16(Request["asar_minutes"]), 0);
            val.Magrib = new TimeSpan(Convert.ToInt16(Request["magrib_hours"]), Convert.ToInt16(Request["magrib_minutes"]), 0);
            val.Esha = new TimeSpan(Convert.ToInt16(Request["esha_hours"]), Convert.ToInt16(Request["esha_minutes"]), 0);
            val.Jummah = new TimeSpan(Convert.ToInt16(Request["jummah_hours"]), Convert.ToInt16(Request["jummah_minutes"]), 0);
            dc.SubmitChanges();
            TempData["Message"] = "Edit Done Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult EditDone12(int id)
        {
            var val = dc.myLists.First(c => c.ID == id);
            val.Area = Request["area"];
            val.Mosque = Request["mosque-name"];
            val.Address = Request["address"];
            val.Fajar = Convert.ToDateTime(Request["fajar_hours"]+":"+Request["fajar_minutes"]+" "+Request["fajar_meridiem"]).TimeOfDay;
            val.Duhur = Convert.ToDateTime(Request["duhur_hours"] + ":" + Request["duhur_minutes"] + " " + Request["duhur_meridiem"]).TimeOfDay;
            val.Asar = Convert.ToDateTime(Request["asar_hours"] + ":" + Request["asar_minutes"] + " " + Request["asar_meridiem"]).TimeOfDay;
            val.Magrib = Convert.ToDateTime(Request["magrib_hours"] + ":" + Request["magrib_minutes"] + " " + Request["magrib_meridiem"]).TimeOfDay;
            val.Esha = Convert.ToDateTime(Request["esha_hours"] + ":" + Request["esha_minutes"] + " " + Request["esha_meridiem"]).TimeOfDay;
            val.Jummah = Convert.ToDateTime(Request["jummah_hours"] + ":" + Request["fajar_minutes"] + " " + Request["jummah_meridiem"]).TimeOfDay;            dc.SubmitChanges();
            TempData["Message"] = "Edit Done Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult AddMosque()
        {
            return View();
        }

        public ActionResult AddMosque24()
        {
            return View();
        }
        public ActionResult AddMosque12()
        {
            return View();
        }
        public ActionResult AddDone24()
        {
            myList val = new myList
            {
                Area = Request["area"],
                Mosque = Request["mosque-name"],
                Address = Request["address"],
                Fajar = new TimeSpan(Convert.ToInt16(Request["fajar_hours"]), Convert.ToInt16(Request["fajar_minutes"]), 0),
                Duhur = new TimeSpan(Convert.ToInt16(Request["duhur_hours"]), Convert.ToInt16(Request["duhur_minutes"]), 0),
                Asar = new TimeSpan(Convert.ToInt16(Request["asar_hours"]), Convert.ToInt16(Request["asar_minutes"]), 0),
                Magrib = new TimeSpan(Convert.ToInt16(Request["magrib_hours"]), Convert.ToInt16(Request["magrib_minutes"]), 0),
                Esha = new TimeSpan(Convert.ToInt16(Request["esha_hours"]), Convert.ToInt16(Request["esha_minutes"]), 0),
                Jummah = new TimeSpan(Convert.ToInt16(Request["jummah_hours"]), Convert.ToInt16(Request["jummah_minutes"]), 0)
            };
            dc.myLists.InsertOnSubmit(val);
            dc.SubmitChanges();
            TempData["Message"] = "Mosque Added Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult AddDone12()
        {
            myList val = new myList
            {
                Area = Request["area"],
                Mosque = Request["mosque-name"],
                Address = Request["address"],
                Fajar = Convert.ToDateTime(Request["fajar_hours"] + ":" + Request["fajar_minutes"] + " " + Request["fajar_meridiem"]).TimeOfDay,
                Duhur = Convert.ToDateTime(Request["duhur_hours"] + ":" + Request["duhur_minutes"] + " " + Request["duhur_meridiem"]).TimeOfDay,
                Asar = Convert.ToDateTime(Request["asar_hours"] + ":" + Request["asar_minutes"] + " " + Request["asar_meridiem"]).TimeOfDay,
                Magrib = Convert.ToDateTime(Request["magrib_hours"] + ":" + Request["magrib_minutes"] + " " + Request["magrib_meridiem"]).TimeOfDay,
                Esha = Convert.ToDateTime(Request["esha_hours"] + ":" + Request["esha_minutes"] + " " + Request["esha_meridiem"]).TimeOfDay,
                Jummah = Convert.ToDateTime(Request["jummah_hours"] + ":" + Request["fajar_minutes"] + " " + Request["jummah_meridiem"]).TimeOfDay
            };        
            dc.myLists.InsertOnSubmit(val);
            dc.SubmitChanges();
            TempData["Message"] = "Mosque Added Successfully";
            return RedirectToAction("Index");
        }
    }
}