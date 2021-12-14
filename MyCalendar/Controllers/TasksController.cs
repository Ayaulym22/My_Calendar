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
using System.IO;

namespace MyCalendar.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            var tasks = db.Tasks.Include(t => t.CategoryTask).Include(t => t.Notification);
            return View(await tasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule.Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.CategoryTasks, "Category_Id", "Name");
            ViewBag.Notify_Id = new SelectList(db.Notifications, "Notify_Id", "Notify_date");
            return View();
        }

        // POST: Tasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Schedule.Models.Task task)
        {

            //string fileName = Path.GetFileNameWithoutExtension(task.ImageFile.FileName);
            //string extension = Path.GetExtension(task.ImageFile.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //task.ImagePath = "~/Image/" + fileName;
            //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            //task.ImageFile.SaveAs(fileName);
            db.Tasks.Add(task);
            db.SaveChanges();
            ViewBag.Category_Id = new SelectList(db.CategoryTasks, "Category_Id", "Name", task.Category_Id);
            ViewBag.Notify_Id = new SelectList(db.Notifications, "Notify_Id", "Notify_date", task.Notify_Id);
            return RedirectToAction("Index");
        }

        // GET: Tasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule.Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.CategoryTasks, "Category_Id", "Name", task.Category_Id);
            ViewBag.Notify_Id = new SelectList(db.Notifications, "Notify_Id", "Notify_date", task.Notify_Id);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Task_id,Task_name,Description,Deadline,ImagePath,Completed,Category_Id,Notify_Id")] Schedule.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.CategoryTasks, "Category_Id", "Name", task.Category_Id);
            ViewBag.Notify_Id = new SelectList(db.Notifications, "Notify_Id", "Notify_date", task.Notify_Id);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule. Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Schedule.Models.Task task = await db.Tasks.FindAsync(id);
            db.Tasks.Remove(task);
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
