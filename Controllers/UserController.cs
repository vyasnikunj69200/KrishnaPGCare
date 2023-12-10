using AutoMapper;
using KrishnaPGCare.Models;
using KrishnaPGCare.Models.AutoCreate;
using Microsoft.AspNetCore.Http;
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

        public IActionResult UserHomePage()
        {
            string welcomeMessage = TempData["WelcomeMessage"] as string;
            return View();
        }

        public IActionResult TenantHomePage()
        {
            string welcomeMessage = TempData["WelcomeMessage"] as string;
            List<PropertyTbl> properties = _context.PropertyTbls.ToList();
            List<BookingRequestTbl> bookingRequests = _context.BookingRequestTbls.Where(x => x.TenantId == HttpContext.Session.GetInt32("UserId")).ToList();
            var viewModel = new TenantHomePageViewModel
            {
                WelcomeMessage = welcomeMessage,
                Properties = properties,
                BookingRequests = bookingRequests
            };
            return View(viewModel);
        }


        public IActionResult TenantRequestList()
        {
            List<BookingRequestTbl> bookingRequests = _context.BookingRequestTbls.ToList();
            List<TenantTbl> tenants = _context.TenantTbls.ToList();
            List<PropertyTbl> properties = _context.PropertyTbls.ToList();

            List<BookingRequestModel> viewModel = new List<BookingRequestModel>();

            foreach (var booking in bookingRequests)
            {
                var model = new BookingRequestModel
                {
                    RequestId = booking.RequestId,
                    TenantId = booking.TenantId,
                    PropertyId = booking.PropertyId,
                    Rquestdatetime = booking.Rquestdatetime,
                    AcceptByOwner = booking.AcceptByOwner,
                    RoomType = booking.RoomType,
                    TenantName = tenants.FirstOrDefault(x => x.TenantId == booking.TenantId)?.FirstName + ' ' + tenants.FirstOrDefault(x => x.TenantId == booking.TenantId)?.LastName,
                    PropertyName = properties.FirstOrDefault(x => x.PropertyId == booking.PropertyId)?.PropertyName,
                    PhoneNumber = tenants.FirstOrDefault(x => x.TenantId == booking.TenantId)?.ContactPhone,
                };

                viewModel.Add(model);
            }

            return View(viewModel);
        }


        public IActionResult SingleBook([FromQuery] int propertyId)
        {
            BookingRequestTbl bookingRequestTbl = new BookingRequestTbl();
            if (propertyId > 0)
            {
                bookingRequestTbl.PropertyId = propertyId;
                bookingRequestTbl.RoomType = 1;
                bookingRequestTbl.AcceptByOwner = false;
                bookingRequestTbl.Rquestdatetime = DateTime.Now;
                bookingRequestTbl.TenantId = HttpContext.Session.GetInt32("UserId");

                _context.Add(bookingRequestTbl);
                _context.SaveChanges();
            }
            return RedirectToAction("TenantHomePage", "User");
        }

        public IActionResult DoubleBook([FromQuery] int propertyId)
        {
            BookingRequestTbl bookingRequestTbl = new BookingRequestTbl();
            if (propertyId > 0)
            {
                bookingRequestTbl.PropertyId = propertyId;
                bookingRequestTbl.RoomType = 2;
                bookingRequestTbl.AcceptByOwner = false;
                bookingRequestTbl.Rquestdatetime = DateTime.Now;
                bookingRequestTbl.TenantId = HttpContext.Session.GetInt32("UserId");

                _context.Add(bookingRequestTbl);
                _context.SaveChanges();
            }
            return RedirectToAction("TenantHomePage", "User");
        }

        public IActionResult TripleBook([FromQuery] int propertyId)
        {
            BookingRequestTbl bookingRequestTbl = new BookingRequestTbl();
            if (propertyId > 0)
            {
                bookingRequestTbl.PropertyId = propertyId;
                bookingRequestTbl.RoomType = 3;
                bookingRequestTbl.AcceptByOwner = false;
                bookingRequestTbl.Rquestdatetime = DateTime.Now;
                bookingRequestTbl.TenantId = HttpContext.Session.GetInt32("UserId");

                _context.Add(bookingRequestTbl);
                _context.SaveChanges();
            }
            return RedirectToAction("TenantHomePage", "User");
        }

        public IActionResult ManageTenantProfile()
        {
            // Example of retrieving UserId from session
            var userId = HttpContext.Session.GetInt32("UserId");

            // Assuming UserTbl and UserModel have similar properties
            TenantTbl userTbl = _context.TenantTbls.FirstOrDefault(x => x.TenantId == userId);

            if (userTbl != null)
            {
                TenantModel user = ToTenantModel(userTbl); // Assuming UserModel has a constructor that accepts UserTbl
                return View("TenantAddEdit", user); // Now you can work with the 'user' object, which is an instance of UserModel
            }
            else
            {
                // Handle the case where the user is not found
            }

            return View();
        }

        public IActionResult manageProperty()
        {
            var properties = _context.PropertyTbls.ToList();
            return View(properties);
        }

        public IActionResult manageSingleProperty([FromQuery] int propertyId)
        {
            var properties = _context.PropertyTbls.Where(x => x.PropertyId == propertyId).FirstOrDefault();
            return View(properties);
        }

        public IActionResult ManageProfile()
        {
            // Example of retrieving UserId from session
            var userId = HttpContext.Session.GetInt32("UserId");

            // Assuming UserTbl and UserModel have similar properties
            UserTbl userTbl = _context.UserTbls.FirstOrDefault(x => x.UserId == userId);

            if (userTbl != null)
            {
                UserModel user = new UserModel(userTbl); // Assuming UserModel has a constructor that accepts UserTbl
                return View(user);// Now you can work with the 'user' object, which is an instance of UserModel
            }
            else
            {
                // Handle the case where the user is not found
            }

            return View();
        }

        public IActionResult ViewTenatProfile([FromQuery] int propertyId)
        {
            TenantTbl tenant = _context.TenantTbls.Where(x => x.TenantId == propertyId).FirstOrDefault();
            return View(tenant);
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
                return View(model);
            }
            if (IsValidUser(model.Email, model.Password))
            {
                TempData["WelcomeMessage"] = "Welcome to Krishna PG Care website";
                if (model.Email.ToString() == "shivani@gmai.com")
                {
                    return RedirectToAction("UserHomePage", "User");
                }
                else
                {
                    return RedirectToAction("TenantHomePage", "User");
                }

            }
            ModelState.AddModelError("PasswordIncorrect", "Incorrect password");
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProperty(PropertyTbl updatedProperty)
        {
            if (ModelState.IsValid)
            {
                var existingProperty = _context.PropertyTbls.FirstOrDefault(x => x.PropertyId == updatedProperty.PropertyId);

                if (existingProperty != null)
                {
                    // Update the properties with the new values
                    existingProperty.PropertyName = updatedProperty.PropertyName;
                    existingProperty.PropertyDescription = updatedProperty.PropertyDescription;
                    existingProperty.PropertyType = updatedProperty.PropertyType;
                    existingProperty.Address = updatedProperty.Address;
                    existingProperty.City = updatedProperty.City;
                    existingProperty.State = updatedProperty.State;
                    existingProperty.PostalCode = updatedProperty.PostalCode;
                    existingProperty.Country = updatedProperty.Country;
                    existingProperty.TotalRooms = updatedProperty.TotalRooms;
                    existingProperty.AvailableRooms = updatedProperty.AvailableRooms;
                    existingProperty.PricePerRoom = updatedProperty.PricePerRoom;
                    existingProperty.Amenities = updatedProperty.Amenities;
                    existingProperty.PropertyStatus = updatedProperty.PropertyStatus;

                    _context.SaveChanges();

                    // Redirect to a success page or return a success response
                    var properties1 = _context.PropertyTbls.ToList();
                    return View("manageProperty", properties1);
                }
                else
                {
                    // Property not found
                    return NotFound();
                }
            }

            // If the ModelState is not valid, return the same view with validation errors
            var properties = _context.PropertyTbls.ToList();
            return View("manageProperty", properties);
        }

        [HttpPost]
        public IActionResult UpdateProfile(UserModel updatedProfile)
        {
            if (ModelState.IsValid)
            {
                var existingProperty = _context.UserTbls.FirstOrDefault(x => x.UserId == updatedProfile.UserId);

                if (existingProperty != null)
                {
                    // Update the properties with the new values
                    existingProperty.FirstName = updatedProfile.FirstName;
                    existingProperty.LastName = updatedProfile.LastName;
                    existingProperty.Email = updatedProfile.Email;
                    existingProperty.Addresss = updatedProfile.Addresss;
                    existingProperty.PasswordHash = updatedProfile.PasswordHash;
                    existingProperty.City = updatedProfile.City;
                    existingProperty.State = updatedProfile.State;
                    existingProperty.PostalCode = updatedProfile.PostalCode;
                    existingProperty.Country = updatedProfile.Country;
                    _context.SaveChanges();

                    // Redirect to a success page or return a success response
                    TempData["WelcomeMessage"] = "Profile update sucessfull.";
                    return View("UserHomePage");
                }
                else
                {
                    // Property not found
                    return NotFound();
                }
            }

            // If the ModelState is not valid, return the same view with validation errors
            return View("UserHomePage");
        }

        public IActionResult AddOrUpdateTenant1()
        {
            TenantModel tenant = new TenantModel();
            return View("TenantAddEdit", tenant);
        }

        public IActionResult TenantList()
        {
            List<TenantTbl> tenant = _context.TenantTbls.ToList();
            return View(tenant);
        }


        [HttpPost]
        public IActionResult AddOrUpdateTenant(TenantModel tenant)
        {
            if (ModelState.IsValid)
            {
                // Add or update logic based on your requirement
                if (tenant.TenantId == 0)
                {
                    // This is a new tenant, add it to the database
                    TenantTbl tenantTbl = ToTenantTbl(tenant);
                    _context.TenantTbls.Add(tenantTbl);
                }
                else
                {
                    // This is an existing tenant, update it in the database
                    var existingTenant = _context.TenantTbls.FirstOrDefault(t => t.TenantId == tenant.TenantId);

                    if (existingTenant != null)
                    {
                        // Update properties with new values
                        // Update properties with new values
                        existingTenant.FirstName = tenant.FirstName;
                        existingTenant.LastName = tenant.LastName;
                        existingTenant.Email = tenant.Email;
                        existingTenant.Password = tenant.Password;
                        existingTenant.ContactPhone = tenant.ContactPhone;
                        existingTenant.Address = tenant.Address;
                        existingTenant.City = tenant.City;
                        existingTenant.State = tenant.State;
                        existingTenant.PostalCode = tenant.PostalCode;
                        existingTenant.Country = tenant.Country;
                        // Update other properties similarly

                        // Update the database
                        _context.SaveChanges();
                    }
                    else
                    {
                        // Tenant not found
                        return NotFound();
                    }
                }

                // Save changes to the database
                _context.SaveChanges();

                // Redirect to a success page or return a success response
                if (tenant.TenantId == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // If ModelState is not valid, return to the same view with validation errors
            return View("TenantAddEdit", tenant);
        }

        #region PRIVATE METHOD

        private bool IsValidUser(string email, string password)
        {
            if (email.ToString() == "shivani@gmai.com")
            {
                var userEntity = _context.UserTbls.FirstOrDefault(u => u.Email == email);
                if (userEntity != null)
                {
                    if (password == userEntity.PasswordHash)
                    {
                        // Passwords match, so the user is valid

                        // Log the successful login attempt in UserLoginHistoryTbl
                        LogSuccessfulLogin(userEntity.UserId);
                        HttpContext.Session.SetInt32("UserId", userEntity.UserId);
                        return true;
                    }
                    // Log the unsuccessful login attempt in UserLoginHistoryTbl
                    LogFailedLogin(email);

                    // If no user with the provided email or invalid password, return false
                    return false;
                }
                return false;

            }
            else
            {
                var userEntity = _context.TenantTbls.FirstOrDefault(u => u.Email == email);


                //var userEntity = _context.UserTbls.FirstOrDefault(u => u.Email == email);

                if (userEntity != null)
                {
                    if (password == userEntity.Password)
                    {
                        // Passwords match, so the user is valid

                        // Log the successful login attempt in UserLoginHistoryTbl
                        LogSuccessfulLogin(userEntity.TenantId);
                        HttpContext.Session.SetInt32("UserId", userEntity.TenantId);
                        return true;
                    }
                }

                // Log the unsuccessful login attempt in UserLoginHistoryTbl
                LogFailedLogin(email);

                // If no user with the provided email or invalid password, return false
                return false;
            }
        }

        private void LogSuccessfulLogin(int userId)
        {
            var loginHistory = new UserLoginHistoryTbl
            {
                UserId = userId,
                LoginDateTime = DateTime.Now,
                Ipaddress = "NOT found",//_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),  // Replace with actual IP address
                UserAgent = "NOT found",    // Replace with actual user agent
                Status = true // Assuming 'true' represents success in your system
            };

            _context.UserLoginHistoryTbls.Add(loginHistory);
            _context.SaveChanges();
        }

        private void LogFailedLogin(string email)
        {
            var loginHistory = new UserLoginHistoryTbl
            {
                UserId = 0, // Set to null for failed login attempts
                LoginDateTime = DateTime.Now,
                Ipaddress = "Not found",//_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),  // Replace with actual IP address
                UserAgent = "Not found",   // Replace with actual user agent
                Status = false, // Assuming 'false' represents failure in your system
                FailureReason = $"Failed login attempt for email: {email}"
            };

            _context.UserLoginHistoryTbls.Add(loginHistory);
            _context.SaveChanges();
        }

        #endregion


        #region Table convert
        public TenantTbl ToTenantTbl(TenantModel tenantModel)
        {
            return new TenantTbl
            {
                TenantId = tenantModel.TenantId,
                FirstName = tenantModel.FirstName,
                LastName = tenantModel.LastName,
                Email = tenantModel.Email,
                Password = tenantModel.Password,
                ContactPhone = tenantModel.ContactPhone,
                Address = tenantModel.Address,
                City = tenantModel.City,
                State = tenantModel.State,
                PostalCode = tenantModel.PostalCode,
                Country = tenantModel.Country,
                MoveInDate = tenantModel.MoveInDate,
                MonthlyRent = tenantModel.MonthlyRent,
                RoomNumber = tenantModel.RoomNumber,
                LeaseStartDate = tenantModel.LeaseStartDate,
                LeaseEndDate = tenantModel.LeaseEndDate,
                LeaseTerm = tenantModel.LeaseTerm,
                SecurityDeposit = tenantModel.SecurityDeposit,
                LeaseStatus = tenantModel.LeaseStatus
                // Initialize other collections if necessary (e.g., HashSet properties)
            };
        }

        public TenantModel ToTenantModel(TenantTbl tenantModel)
        {
            return new TenantModel
            {
                TenantId = tenantModel.TenantId,
                FirstName = tenantModel.FirstName,
                LastName = tenantModel.LastName,
                Email = tenantModel.Email,
                Password = tenantModel.Password,
                ContactPhone = tenantModel.ContactPhone,
                Address = tenantModel.Address,
                City = tenantModel.City,
                State = tenantModel.State,
                PostalCode = tenantModel.PostalCode,
                Country = tenantModel.Country,
                MoveInDate = tenantModel.MoveInDate,
                MonthlyRent = tenantModel.MonthlyRent,
                RoomNumber = tenantModel.RoomNumber,
                LeaseStartDate = tenantModel.LeaseStartDate,
                LeaseEndDate = tenantModel.LeaseEndDate,
                LeaseTerm = tenantModel.LeaseTerm,
                SecurityDeposit = tenantModel.SecurityDeposit,
                LeaseStatus = tenantModel.LeaseStatus
                // Initialize other collections if necessary (e.g., HashSet properties)
            };
        }

        #endregion

    }
}
