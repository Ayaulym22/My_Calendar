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
    public class CalendarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calendars
        public async Task<ActionResult> Index()
        {
            var calendars = db.Calendars.Include(c => c.Event).Include(c => c.Task);
            return View(await calendars.ToListAsync());
        }

        // GET: Calendars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = await db.Calendars.FindAsync(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // GET: Calendars/Create
        public ActionResult Create()
        {
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject");
            ViewBag.Task_id = new SelectList(db.Tasks, "Task_id", "Task_name");
            return View();
        }

        // POST: Calendars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Calendar_id,Month,Year,Day,Event_id,Task_id")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Calendars.Add(calendar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject", calendar.Event_id);
            ViewBag.Task_id = new SelectList(db.Tasks, "Task_id", "Task_name", calendar.Task_id);
            return View(calendar);
        }

        // GET: Calendars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = await db.Calendars.FindAsync(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject", calendar.Event_id);
            ViewBag.Task_id = new SelectList(db.Tasks, "Task_id", "Task_name", calendar.Task_id);
            return View(calendar);
        }

        // POST: Calendars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Calendar_id,Month,Year,Day,Event_id,Task_id")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject", calendar.Event_id);
            ViewBag.Task_id = new SelectList(db.Tasks, "Task_id", "Task_name", calendar.Task_id);
            return View(calendar);
        }

        // GET: Calendars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = await db.Calendars.FindAsync(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: Calendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Calendar calendar = await db.Calendars.FindAsync(id);
            db.Calendars.Remove(calendar);
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
