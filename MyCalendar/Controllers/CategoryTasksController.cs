using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCalendar.Models;
using Schedule.Models;

namespace MyCalendar.Controllers
{
    public class CategoryTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryTasks
        public async Task<ActionResult> Index()
        {
            return View(await db.CategoryTasks.ToListAsync());
        }

        // GET: CategoryTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTask categoryTask = await db.CategoryTasks.FindAsync(id);
            if (categoryTask == null)
            {
                return HttpNotFound();
            }
            return View(categoryTask);
        }

        // GET: CategoryTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryTasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Category_Id,Name")] CategoryTask categoryTask)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTasks.Add(categoryTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoryTask);
        }

        // GET: CategoryTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTask categoryTask = await db.CategoryTasks.FindAsync(id);
            if (categoryTask == null)
            {
                return HttpNotFound();
            }
            return View(categoryTask);
        }

        // POST: CategoryTasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Category_Id,Name")] CategoryTask categoryTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoryTask);
        }

        // GET: CategoryTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTask categoryTask = await db.CategoryTasks.FindAsync(id);
            if (categoryTask == null)
            {
                return HttpNotFound();
            }
            return View(categoryTask);
        }

        // POST: CategoryTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CategoryTask categoryTask = await db.CategoryTasks.FindAsync(id);
            db.CategoryTasks.Remove(categoryTask);
            await db.SaveChangesAsync();
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
