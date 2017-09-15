using MVCWithAngular2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAngular2.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult GetLastContact()
        {
            Contact c = null;

            using(MyDatabaseEntities dc= new MyDatabaseEntities())
            {
                c = dc.Contacts.OrderByDescending(a => a.ContactID).Take(1).FirstOrDefault();
            }

            return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public JsonResult GetGivenContact(GetContactModels Contact)
        {
            Contact c = null;

            using (MyDatabaseEntities db_con = new MyDatabaseEntities())
            {
                c = db_con.Contacts.Where(a => a.FirstName == Contact.Name).Take(1).FirstOrDefault();
                //c = dc.Contacts.OrderByDescending(a => a.ContactID).Take(1).FirstOrDefault();
            }

            return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}