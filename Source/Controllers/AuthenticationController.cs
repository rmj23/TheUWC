using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Source.Helpers;

namespace Source.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.Tried = false;
            LoginModel model = new LoginModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }


        // POST: Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginModel model, string ReturnUrl)
         {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                UserModel result = model.Authenticate();

                if (result != null) //Authentication Successful
                {
                    if (!result.isVerified)
                    {
                        return RedirectToAction("Verification", "Authentication");
                    }

                    FormsAuthentication.SetAuthCookie(result.Email, false);

                    Session["UserFirstName"] = result.FirstName;
                    Session["UserLastName"] = result.LastName;
                    Session["DistrictID"] = result.DistrictID;
                    Session["SchoolID"] = result.SchoolID;
                    Session["UserID"] = result.ID;


                    switch (result.RoleID)
                    {
                        case 1: //Is teacher

                            Session["TeacherID"] = repo.GetTeacherIDByUserID(result.ID);

                            //No previous path
                            if (String.IsNullOrEmpty(model.ReturnUrl))
                            {
                               return RedirectToAction("Dashboard", "Teacher");
                            }
                            //Navigate to desired path
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }

                        case 2: //Is student

                            Session["StudentID"] = repo.StudentModelSelectOneByUserModel(result).StudentID;

                            //No previous path
                            if (String.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return RedirectToAction("Dashboard", "Student");
                            }
                            //Navigate to desired path
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }

                        case 3: //Is Web Admin

                            //No previous path
                            if (String.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return RedirectToAction("Dashboard", "WebAdmin");
                            }
                            //Navigate to desired path
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }

                        case 4: //Is District Admin

                            //No previous path
                            if (String.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return RedirectToAction("Dashboard", "DistrictAdmin");
                            }
                            //Navigate to desired path
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }

                        case 5: //Is Parent
                          
                            //No previous path
                            if (String.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return RedirectToAction("Dashboard", "Parent");
                            }
                            //Navigate to desired path
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }

                        case 6: //Is SchoolAdmin

                            //No previous path
                            if (String.IsNullOrEmpty(model.ReturnUrl))
                            {
                                return RedirectToAction("Dashboard", "SchoolAdmin");
                            }
                            //Navigate to desired path
                            else
                            {
                                return Redirect(model.ReturnUrl);
                            }
                    }
                }
            }
            //Authentication Failed
            ViewBag.Tried = true;
            ViewBag.Successful = false;
            ModelState.AddModelError("authenticationError", "Invalid Credentials");
            return View(model);
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        // POST: Register
        [HttpPost]
        public ActionResult Register(RegisterUserViewModel model, ValidationModel valid)
        {

            Repository repo = new Repository();
            try
            {
                model.user.RoleID = 1;
                model.user.isVerified = false;
                model.user.globalRoleId = 99;
                string VerificationCode = GenerateVerificationCode();
                UserModel user = model.login.NewUser(model.login.UserName, model.login.Password, model.login.schoolCode, model.user);
                string msg = "To confirm your email, login and enter the code below: " + VerificationCode;
                repo.ValidationModelInsert(VerificationCode, user.ID);
                EmailModelFunctions.Send(model.login.UserName, msg, "Uni-spire Email Verification");
                return RedirectToAction("Login", "Authentication");
            }
            catch (Exception ex)
            {
                repo.InsertSqlError(ex.Message.ToString());
                ViewBag.Error = true;
            }
            return View();
        }
        [Authorize]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
        //GET: SET and GET users without hashPassword. Must move ActionLink into View. Removed for security reasons

        public ActionResult PasswordUpdate()
        {
            Repository repo = new Repository();

            //< !--Set users with no password-->
            List<UserModel> ListOfUsers = new List<UserModel>();
            ListOfUsers = repo.LoginModelGetUsersWithoutPassword();
            foreach (UserModel User in ListOfUsers)
            {
                repo.LoginModelSetNewPassword(User.ID);
            }
            return RedirectToAction("Login");
        }

        public ActionResult PasswordChange()
        {
            ViewBag.Tried = false;
            PasswordUpdateModel model = new PasswordUpdateModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PasswordChange(PasswordUpdateModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                PasswordUpdateModel result = model.Authenticate();
                if (result != null) //Auth successful
                {
                    repo.PasswordUpdateModelChangePassword(result);
                    return RedirectToAction("Index", "Home");
                }
            }
            //Authentication Failed
            ViewBag.Tried = true;
            ViewBag.Successful = false;
            return View(model);
        }
        public ActionResult Verification()
        {
            return View();
        }

        //GET: Validation
        public ActionResult Validate()
        {

            return RedirectToAction("Verification", "Authentication");
        }

        //POST: Validation
        [HttpPost]
        public ActionResult Verification(ValidationModel model)
        {
            Repository repo = new Repository();
            bool isValid = repo.ValidationModelCheck(model.VerificationCode, model.Email);
            if (isValid)
            {

                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                return RedirectToAction("Error", "Shared");
            }
        }
        public ActionResult ForgotPassword()
        {
            ForgotPasswordModel model = new ForgotPasswordModel();
            ViewBag.EmailSent = false;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            Repository repo = new Repository();
            //Check if email is valid.
            List<UserModel> users = repo.UserSelectAll();
            List<string> existingEmails = users.Select(x => x.Email).ToList();
            bool isExistingEmail = existingEmails.Any(e => existingEmails.Contains(model.Email));
            if (!isExistingEmail)
            {
                ModelState.AddModelError("InvalidEmail", "Email not found. Please enter a valid email.");
                return View(model);
            }
            //Get a verification code
            string verificationCode = GenerateVerificationCode();
            //Insert email/code combo in database
            repo.InsertVerificationCode(model.Email, verificationCode);
            //Send compose email body and send email.
            string body = "We have recieved your password reset request. Please click the following link to reset your password: " +
            string.Format("{0}://{1}{2}",
                                                  Url.RequestContext.HttpContext.Request.Url.Scheme,
                                                  Url.RequestContext.HttpContext.Request.Url.Authority,
                                                  Url.Action("ResetPassword", "Authentication"))
            + "?verifCode=" + verificationCode + "." + Environment.NewLine + "Please note that this link is only valid for 15 minutes.";
            EmailModelFunctions.Send(model.Email, body, "Uni-Spire Password Reset");
            ViewBag.EmailSent = true;
            return View(model);
        }
        public ActionResult ResetPassword(string verifCode)
        {
            //Check if verification code is valid
            Repository repo = new Repository();
            ForgotPasswordModel result = repo.CheckVerificationCode(verifCode);
            if (result == null) //Token expired
            {
                ViewBag.IsActive = false;
                ResetPasswordModel emptyModel = new ResetPasswordModel();
                return View(emptyModel);
            }
            var isActive = result.IsActive;
            ViewBag.IsActive = isActive;
            ResetPasswordModel model = new ResetPasswordModel();
            model.Email = result.Email;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            ViewBag.IsPasswordReset = false;
            Repository repo = new Repository();
            //Get User
            List<UserModel> allUsers = repo.UserSelectAll();
            UserModel currentUser = allUsers.Where(x => x.Email == model.Email).FirstOrDefault();
            if (currentUser != null)
            {
                repo.LoginModelSetNewPassword(currentUser, model.Password);
                ViewBag.IsPasswordReset = true;
            }
            return View();
        }
        private string GenerateVerificationCode()
        {
            var set = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringSet = new char[8];
            var random = new Random();

            for (int i = 0; i < stringSet.Length; i++)
            {
                stringSet[i] = set[random.Next(set.Length)];
            }

            var VerificationCode = new String(stringSet);
            return VerificationCode;
        }
    }
}
