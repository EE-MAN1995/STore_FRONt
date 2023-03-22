using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STore_FRONt.Models;

namespace STore_FRONt.Controllers
{
    public class Contact_InfosController : Controller
    {
        private F_StoreEntities9 db = new F_StoreEntities9();

        // GET: Contact_Infos
        public async Task<ActionResult> Index()
        {
            return View(await db.Contact_Infos.ToListAsync());
        }

        // GET: Contact_Infos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Infos contact_Infos = await db.Contact_Infos.FindAsync(id);
            if (contact_Infos == null)
            {
                return HttpNotFound();
            }
            return View(contact_Infos);
        }

        // GET: Contact_Infos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact_Infos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,First_Name,Last_Name,Phone_Number,Adress")] Contact_Infos contact_Infos)
        {
            if (ModelState.IsValid)
            {
                db.Contact_Infos.Add(contact_Infos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contact_Infos);
        }

        // GET: Contact_Infos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Infos contact_Infos = await db.Contact_Infos.FindAsync(id);
            if (contact_Infos == null)
            {
                return HttpNotFound();
            }
            return View(contact_Infos);
        }

        // POST: Contact_Infos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,First_Name,Last_Name,Phone_Number,Adress")] Contact_Infos contact_Infos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact_Infos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact_Infos);
        }

        // GET: Contact_Infos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact_Infos contact_Infos = await db.Contact_Infos.FindAsync(id);
            if (contact_Infos == null)
            {
                return HttpNotFound();
            }
            return View(contact_Infos);
        }

        // POST: Contact_Infos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contact_Infos contact_Infos = await db.Contact_Infos.FindAsync(id);
            db.Contact_Infos.Remove(contact_Infos);
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
