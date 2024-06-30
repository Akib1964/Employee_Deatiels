using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWITHEF.Models;

namespace CRUDWITHEF.Controllers
{
    public class EmployeeController : Controller
    {
        private CRUDWITHEFEntities db = new CRUDWITHEFEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.EMPLOYEEMASTERs.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPCODE,EMPNAME,DESIGNATION,SALARY")] EMPLOYEEMASTER eMPLOYEEMASTER)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEEMASTERs.Add(eMPLOYEEMASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEEMASTER);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPCODE,EMPNAME,DESIGNATION,SALARY")] EMPLOYEEMASTER eMPLOYEEMASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEEMASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEEMASTER);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            if (eMPLOYEEMASTER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEMASTER);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEEMASTER eMPLOYEEMASTER = db.EMPLOYEEMASTERs.Find(id);
            db.EMPLOYEEMASTERs.Remove(eMPLOYEEMASTER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
