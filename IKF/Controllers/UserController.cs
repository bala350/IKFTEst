using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IKFTEST.Models;

namespace IKFTEST.Controllers
{
    public class UserController : Controller
    {

        DbOparation db = new DbOparation();
        [HttpGet]
        public ActionResult AddUser()
        {

            ViewBag.list= db.getAll();
            return View();
        }

        [HttpPost]
        public ActionResult AddUSer(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    db.Insert(user);
                  
                    ViewBag.msg = "User Details Added Successfully";
                    ModelState.Clear();
                }
                
                return View();
            }
            catch (Exception ex)
            {

                return View();
            }



          
        }


        [HttpGet]
        public ActionResult AllUSer()
        {
            try
            {
                List<User> list = db.getAll();

                return View("AllUser", list);
            }
            catch (Exception ex)
            {

                //  throw;
            }
            return View();
        }
        // GET: User




        [HttpGet]
        public ActionResult  UpdateUser(User us,string id)
        {
            db.GetById(us.id);
            return View(us);
           
        }



        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            try
            {
                db.Update(user);
                ViewBag.msg = "Updated Successfully";
                return RedirectToAction("AddUSer");
            }
            catch (Exception ex)
            {

               // throw;
            }


            return View();
        }


        [HttpGet]
        public ActionResult DeleteUser(User user, string id)
        {

            db.GetById(user.id);
            return View(user);
        }



        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            try
            {

                db.Delete(id);
                ViewBag.msg = "User Deleted Successfully";
                return RedirectToAction("AddUSer");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}