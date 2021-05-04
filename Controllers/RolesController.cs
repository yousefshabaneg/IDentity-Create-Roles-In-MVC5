using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDentity.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IDentity.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(dbContext.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = dbContext.Roles.Find(id);
            if (role == null)
                return HttpNotFound();
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    dbContext.Roles.Add(role);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(role);
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var role = dbContext.Roles.Find(id);
            if (role == null)
                return HttpNotFound();
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")]IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(role).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(IdentityRole mainRole)
        {
            var role = dbContext.Roles.Find(mainRole.Id);
            if (role == null)
                return HttpNotFound();
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var role = dbContext.Roles.Find(id);
            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
