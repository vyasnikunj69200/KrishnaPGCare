using AutoMapper;
using KrishnaPGCare.Models;
using KrishnaPGCare.Models.AutoCreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KrishnaPGCare.Startup;

namespace KrishnaPGCare.Controllers
{
    public class UserController : Controller
    {
        private readonly shopkrillContext _context;

        public UserController(shopkrillContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}


        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = AutoMapperConfig.RegisterMappings();
                    IMapper mapper = config.CreateMapper();
                    var userEntity = mapper.Map<UserTbl>(userModel);

                    _context.UserTbls.Add(userEntity);
                    _context.SaveChanges();
                    return RedirectToAction("Index"); // You can redirect to another action after inserting.
                }

                return View(userModel);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }


        public ActionResult Login()
        {
            TempData["WelcomeMessage"] = null;
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                // Validation failed, return the view with errors
                return View(model);
            }
            // Validate the user's email and password
            if (IsValidUser(model.Email, model.Password))
            {
                // Redirect to a protected page or perform some action upon successful login
//                ViewBag.LoginSucess = true;
                TempData["WelcomeMessage"] = "Welcome to Krishna PG Care website";
                return RedirectToAction("Index", "Home"); // You can redirect to another action after inserting.
            }

            // If login fails, return to the login page with an error message
            ModelState.AddModelError("PasswordIncorrect", "Incorrect password");
            return View(model);
        }

        private bool IsValidUser(string email, string password)
        {
            var userEntity = _context.UserTbls.FirstOrDefault(u => u.Email == email);

            if (userEntity != null)
            {
                if (password == userEntity.PasswordHash)
                {
                    // Passwords match, so the user is valid
                    return true;
                }
            }

            // If no user with the provided email or invalid password, return false
            return false;
        }

    }
}
