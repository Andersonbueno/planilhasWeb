//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Planilhas.Models;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;


//namespace Planilhas.Controllers
//{
//    public class RolesController : Controller
//    {
//       private OurDbContext context = new OurDbContext();

//        //
//        // GET: /Roles/
//        public ActionResult Index()
//        {
//            var roles = context.Roles.ToList();
//            return View(roles);
//        }

//        //
//        // GET: /Roles/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        //
//        // POST: /Roles/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                context.Roles.Add(new IdentityRole()
//                {
//                    Name = collection["RoleName"]
//                });
//                context.SaveChanges();
//                ViewBag.ResultMessage = "Role criada com sucesso !";
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        //
//        // GET: /Roles/Edit/5
//        public ActionResult Edit(string roleName)
//        {
//            var thisRole = context.Roles.Where(r => r.RoleName.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

//            return View(thisRole);
//        }

//        //
//        // POST: /Roles/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
//        {
//            try
//            {
//                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
//                context.SaveChanges();

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        //
//        // GET: /Roles/Delete/5
//        public ActionResult Delete(string RoleName)
//        {
//            var thisRole = context.Roles.Where(r => r.RoleName.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
//            context.Roles.Remove(thisRole);
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public ActionResult ManageUserRoles()
//        {
//            var list = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
//            ViewBag.Roles = list;
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult RoleAddToUser(string UserName, string RoleName)
//        {
//            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
//            var account = new AccountController();
//            account.UserManager.AddToRole(user.Id, RoleName);

//            ViewBag.ResultMessage = "Role criada com sucesso !";

//            // prepopulat roles for the view dropdown
//            var list = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
//            ViewBag.Roles = list;

//            return View("ManageUserRoles");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult GetRoles(string UserName)
//        {
//            if (!string.IsNullOrWhiteSpace(UserName))
//            {
//                ApplicationUser user = context.UserRoles.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
//                var account = new AccountController();

//                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

//                // prepopulat roles for the view dropdown
//                var list = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
//                ViewBag.Roles = list;
//            }

//            return View("ManageUserRoles");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
//        {
//            var account = new AccountController();
//            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

//            if (account.UserManager.IsInRole(user.Id, RoleName))
//            {
//                account.UserManager.RemoveFromRole(user.Id, RoleName);
//                ViewBag.ResultMessage = "Role removido deste usuario com sucesso !";
//            }
//            else
//            {
//                ViewBag.ResultMessage = "Este usuario nao pertence a role selecionada.";
//            }
//            // prepopulat roles for the view dropdown
//            var list = context.Roles.OrderBy(r => r.RoleName).ToList().Select(rr => new SelectListItem { Value = rr.RoleName.ToString(), Text = rr.RoleName }).ToList();
//            ViewBag.Roles = list;

//            return View("ManageUserRoles");
//        }
//    }
//}
