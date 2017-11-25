using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BHIP.Model;
using BHIP.Model.Helper;

namespace BHIP.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }
            
            MenuViewModel menu = new MenuViewModel();
            menu.menuView = menu.DisplayAdminMenu(0);

            return View(menu);
        }

        public ActionResult Create(int id)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }
            
            MenuViewModel menu = new MenuViewModel();

            MenuView menuView = new MenuView();
            menuView.Parent = id;

            //Get the list of Roles
            menuView.RolesList = menu.GetRoles();

            return View(menuView);
        }

        [HttpPost]
        public ActionResult Create(MenuView menu, params string[] selectedRoles)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }
            
            int menuId = 0;

            if (ModelState.IsValid)
            {
                MenuViewModel menuView = new MenuViewModel();
                menuId = menuView.InsertMenuItem(menu.Parent, menu.Title, menu.Link);
                if (menuId > 0)
                {
                    menuView.SaveMenuRoles(menuId, selectedRoles);
                }
                return RedirectToAction("Index");

            }

            return View(menu);
        }

        public ActionResult _SecureMenu()
        {
            MenuViewModel menu = new MenuViewModel();
            menu.menuView = menu.DisplayMenu(0);

            return PartialView("_SecureMenu", menu);
        }

        public ActionResult SaveMenu(string menuOrder)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }
            
            MenuViewModel menuView = new MenuViewModel();
            menuView.SaveOrder(menuOrder);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }
            
            MenuViewModel menu = new MenuViewModel();
            MenuView menuView = new MenuView();
            menuView = menu.GetMenu(id);
            menuView.RolesList = menu.GetEditRoles(id);

            return View(menuView);

        }

        [HttpPost]
        public ActionResult Edit(MenuView menu, params string[] selectedRoles)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }

            if (ModelState.IsValid)
            {
                MenuViewModel menuView = new MenuViewModel();
                menuView.SaveEditMenu(menu);

                if (selectedRoles != null)
                {
                    menuView.SaveEditMenuRoles(menu.MenuID, selectedRoles);
                }

                return RedirectToAction("Index");
            }

            return View(menu);
        }

        public ActionResult Delete(int id)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }

            MenuViewModel menuView = new MenuViewModel();

            return View(menuView.GetMenu(id));
        }

        [HttpPost]
        public ActionResult Delete(MenuView menu)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Redirect("~/");
            }

            MenuViewModel menuView = new MenuViewModel();
            menuView.DeleteMenuItem(menu.MenuID);

            return RedirectToAction("Index");
        }
    }
}