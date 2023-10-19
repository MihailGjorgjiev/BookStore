using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
using AlbumsMVC.Models;
using Microsoft.AspNet.Identity;

namespace AlbumsMVC.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.User).Include(o => o.Book).ToList();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            var order = db.Orders.Include(o => o.User).Include(o => o.Book).Where(z=>z.Id==id).FirstOrDefault();
            var purchaseDetails = db.PurchaseDatas.Where(z => z.Email == order.User.Email).FirstOrDefault();
            ViewBag.purchase=purchaseDetails;
            
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create(int id)
        {
            OrderPurchaseDTO model = new OrderPurchaseDTO
            {
                Order=new Order{},
                PurchaseData=new PurchaseData { }
            };
            model.Order.DateOfPurchase = DateTime.Now;
            model.Order.BookId=id;
            model.Order.Book = db.Books.Find(id);
            model.Order.UserId=User.Identity.GetUserId();
            model.Order.User = db.Users.Find(model.Order.UserId);
            model.PurchaseData.Email = model.Order.User.Email;
            return View(model);
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(OrderPurchaseDTO model)
        {
            try
            {
                Order order = model.Order;
                order.Book=db.Books.Include(b=>b.Author).Include(b=>b.Genre).Where(b=>b.Id==order.BookId).FirstOrDefault();
                order.User = db.Users.Find(order.UserId);
                PurchaseData purchase = model.PurchaseData;
                db.Orders.Add(order);
                db.PurchaseDatas.Add(purchase);
                Book book = db.Books.Find(order.BookId);
                book.Quantity -= 1;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index","Books");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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
        public ActionResult Excel()
        {
            var grid = new GridView();
            var orders = db.Orders.Include(o=>o.Book).Include(o=>o.User).ToList();
            List<Excel> excels = new List<Excel>();
            foreach (var order in orders)
            {
                var e = new Excel
                {
                    BookTitle = order.Book.Title,
                    Email = order.User.Email,
                    TimeOfPurchase = order.DateOfPurchase,
                    Price = order.Book.Price
                };
                excels.Add(e);
            }
            grid.DataSource = excels;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Orders.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }
    }
}
