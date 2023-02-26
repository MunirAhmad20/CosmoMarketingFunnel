using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Money_Finder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using bookingapp.Models;
using Grpc.Core;
using System.Data;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using static Money_Finder.Models.ResponseBack;

using System.Text.Json;
using System.Text;
using RestSharp;

namespace Money_Finder.Controllers
{
   
    public class adminController : Controller
    {
        public static string disuploadcount;
        public static string recby
        {
            get { return disuploadcount; }
            set { disuploadcount = 0 + value; }

        }
        public static string uploadcountt;
        public static string recbyy
        {
            get { return uploadcountt; }
            set { uploadcountt = 0 + value; }

        }
        public static string currentid;
        public static string currentidrecbyy
        {
            get { return currentid; }
            set { currentid = value; }

        }
        public static string incorerct;
        public static string recbyyincorrect
        {
            get { return incorerct; }
            set { incorerct = value; }

        }
        public static string username;
        public static string urecby
        {
            get { return username; }
            set { username = value; }

        }

        public static string response;
        public static string responserecby
        {
            get { return response; }
            set { response = value; }

        }
        public static string offertype;
        public static string currentoffertyperecbyy
        {
            get { return offertype; }
            set { offertype = value; }

        }

        //// int  uploadcount=0;
        /// int    disuploadcount=1;
        AppDBContext d = new AppDBContext();

        //[HttpPost]
        //public IActionResult Auth()
        //{


        //}

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult logout()
        {
            urecby = null;


            return RedirectToAction("login", "admin");
        }

        public IActionResult datatabletest()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult approve(string departid)
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            var data = d.AdminLogin.Find(Convert.ToInt32(departid));
            data.Status = "Approved";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult blacklist(string departid)
        {
            var data = d.AdminLogin.Find(Convert.ToInt32(departid));
            data.Status = "blacklisted";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult delete(string offertype, List<string> archiveitem)
        {
            foreach (var i in archiveitem)
            {

                var data = d.AdminLogin.Find(Convert.ToInt32(i));
                d.AdminLogin.Remove(data);
                d.SaveChanges();
                


            }
            
            return Ok();
        }
        public IActionResult systemuser()
        {
            if (urecby != null)
            {

                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.user = d.AdminLogin.ToList();



                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }

        }

        [HttpPost]
        public IActionResult updateuser(string userid, string id, string roll, string contact, string skype, string password, string gmail, string fname, string lname, List<IFormFile> files)
        {
            //if (files != null)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                if (files != null && files.Count != 0)
                {


                    foreach (var file in files)
                    {
                        {
                            //Getting FileName
                            var fileName = Path.GetFileName(file.FileName);

                            //Assigning Unique Filename (Guid)
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                            //Getting file Extension
                            var fileExtension = Path.GetExtension(fileName);

                            // concatenating  FileName + FileExtension
                            var newFileName = String.Concat(myUniqueFileName, fileExtension);

                            // Combines two strings into a path.
                            var filepath =
               new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                            using (FileStream fs = System.IO.File.Create(filepath))
                            {
                                file.CopyTo(fs);
                                fs.Flush();

                            }


                            var data = d.AdminLogin.Find(Convert.ToInt32(userid));
                            data.Image = newFileName;
                            data.SkypeAddress = skype;
                            data.UserName = fname + " " + lname;
                            data.FirstName = fname;
                            data.LastName = lname;

                            data.SystemRoll = roll;
                            data.Contact = contact;
                            data.Gmail = gmail;
                            data.Password = password;
                            d.Entry(data).State = EntityState.Modified;
                            d.SaveChanges();

                        }
                    }
                    return RedirectToAction("systemuser", "admin");
                }


                else
                {
                    var data = d.AdminLogin.Find(Convert.ToInt32(userid));

                    data.SkypeAddress = skype;
                    data.UserName = fname + " " + lname;
                    data.FirstName = fname;
                    data.LastName = lname;
                    data.SystemRoll = roll;
                    data.Contact = contact;
                    data.Gmail = gmail;
                    data.Password = password;
                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();
                    return RedirectToAction("systemuser", "admin");
                }

            }
        }


        [HttpPost]
        public IActionResult submitnewuser(string userid, string roll, string skype, string contact, string password, string gmail, string fname, string lname, List<IFormFile> files)
        {
            if (files != null && files.Count!=0)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }
                        if (userid == "" || userid == string.Empty || userid == null)
                        {
                            AdminLogin s = new AdminLogin();
                            s.Image = newFileName;
                            s.UserName = fname + " " + lname;
                            s.SystemRoll = roll;
                            s.Contact = contact;
                            s.FirstName = fname;
                            s.LastName = lname;
                            s.Gmail = gmail;
                            s.SkypeAddress = skype;
                            s.Status = "Approved";
                            s.Password = password;
                            d.AdminLogin.Add(s);
                            d.SaveChanges();
                        }
                        else
                        {
                            var data = d.AdminLogin.Find(Convert.ToInt32(userid));
                            data.Image = newFileName;
                            data.SkypeAddress = skype;
                            data.UserName = username;
                            data.SystemRoll = roll;
                            data.FirstName = fname;
                            data.LastName = lname;
                            data.Gmail = gmail;
                            data.Password = password;
                            d.Entry(data).State = EntityState.Modified;
                            d.SaveChanges();
                        }



                    }
                }
            }



            else
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
               
                        if (userid == "" || userid == string.Empty || userid == null)
                        {
                            AdminLogin s = new AdminLogin();
                           
                            s.UserName = fname + " " + lname;
                            s.FirstName = fname ;
                            s.LastName = lname ;
                            s.SystemRoll = roll;
                            s.Contact = contact;
                            s.Gmail = gmail;
                            s.SkypeAddress = skype;
                            s.Status = "Approved";
                            s.Password = password;
                            d.AdminLogin.Add(s);
                            d.SaveChanges();
                        }
                        else
                        {
                            var data = d.AdminLogin.Find(Convert.ToInt32(userid));
                        
                            data.SkypeAddress = skype;
                            data.UserName = username;
                    data.FirstName = fname;
                    data.LastName = lname;
                    data.SystemRoll = roll;
                            data.Gmail = gmail;
                            data.Password = password;
                            d.Entry(data).State = EntityState.Modified;
                            d.SaveChanges();
                        }

            }
            return RedirectToAction("systemuser", "admin");
        }


        [HttpPost]
        public IActionResult submitqa(string title,string Notes, List<string> redirectlink, List<string> option)
        {
            foreach (var i in option)

            {
                //var countt = d.QaOffer.Where(o => o.Option == i).Count();
                //if (countt<1)
                //{
                foreach (var ii in redirectlink)
                {
                    //var count = d.QaOffer.Where(o => o.Option == ii).Count();
                    //if (count<1)
                    {
                        QaOffer q = new QaOffer();
                        q.QaTitle = title;
                        q.RedirectLink = ii;
                        q.Option = i;
                        q.Validation = "on";
                        q.Notes = Notes;
                        d.QaOffer.Add(q);

                        d.SaveChanges();
                        redirectlink.Remove(ii);
                    }
                    break;

                }

            }



            return RedirectToAction("conditional_flow", "admin");
        }

        public IActionResult incorrect()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        public IActionResult affliateinfo()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult valuepass(string tid, string tidpass)
        {

            var count = d.AdminLogin.Where(o => o.Gmail == tid && o.Password == tidpass && o.Status == "Approved").Count();
            if (count >= 1)
            {
                ViewBag.use = d.AdminLogin.Where(o => o.Gmail == tid && o.Password == tidpass && o.Status == "Approved").ToList();
                foreach (var i in ViewBag.use)
                {
                    ViewBag.user = i.UserName;
                    urecby = ViewBag.user;
                }
                return RedirectToAction("dashboard", "admin");
            }
            else
            {

                return RedirectToAction("login", "admin");
            }
        }
        [HttpPost]
        public IActionResult checkvalid()
        {
            string username = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();
            
            var count = d.AdminLogin.Where(o => o.Gmail == username && o.Password == password && o.Status == "Approved").Count();
            if (count >= 1)
            {
                int userid = 0;
                var dbdatetime = "";
                var datetimediffrense = " ";
                string trycount = "0";
                TimeSpan ts = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm")) - DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm"));
                ViewBag.use = d.AdminLogin.Where(o => o.Gmail == username && o.Password == password && o.Status == "Approved").ToList();
                foreach (var i in ViewBag.use)
                {
                    ViewBag.user = i.UserName;
                    urecby = ViewBag.user;
                    trycount = i.TryCount;
                    dbdatetime = i.DateTime;
                    userid = i.AdminLoginId;
                    if (dbdatetime==null || dbdatetime == " " || dbdatetime == "")
                    {
                        dbdatetime= DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                    }
                    else
                    {
                        dbdatetime = i.DateTime;
                       ts = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm")) - DateTime.Parse(dbdatetime);
                        //string days = "";
                        //string hours = "";
                        //string minutes = "";

                        //if (ts.Days > 0 && ts.Hours > 0 && ts.Minutes > 0)
                        //{

                        //    days = string.Format("{0:%d}", ts);
                        //    hours = string.Format("{0:%h}", ts);
                        //    minutes = string.Format("{0:%m}", ts);
                        //}
                        //else if (ts.Days > 0 && ts.Hours > 0)
                        //{

                        //    days = string.Format("{0:%d}", ts);
                        //    hours = string.Format("{0:%h}", ts);
                            
                        //}
                        //else if (ts.Hours > 0 && ts.Minutes > 0)
                        //{

                        //    lbl = string.Format("{0:%h} hours: {0:%m} minutes", ts);
                        //    days = string.Format("{0:%d}", ts);
                        //    hours = string.Format("{0:%h}", ts);
                        //    minutes = string.Format("{0:%m}", ts);
                        //}
                        //else
                        //{
                        //    lbl = string.Format("{0:%d} days: {0:%h} hours: {0:%m} minutes", ts);
                        //}
                    }
                }
                if (ts.Days == 0 && ts.Hours == 0 && ts.Minutes < 30)
                {
                    if (Convert.ToInt32(trycount) > 5)
                    {
                        recbyyincorrect = "locked";
                        return RedirectToAction("login", "admin");
                    }
                    else
                    {
                        var data = d.AdminLogin.Find(Convert.ToInt32(userid));

                        data.TryCount = "0";
                        data.DateTime = " ";

                        d.Entry(data).State = EntityState.Modified;
                        d.SaveChanges();
                        return RedirectToAction("dashboard", "admin");
                    }

                }
                else
                {
                    var data = d.AdminLogin.Find(Convert.ToInt32(userid));

                    data.TryCount = "0";
                    data.DateTime = " ";

                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();
                    return RedirectToAction("dashboard", "admin");
                }
                return RedirectToAction("login", "admin");
            }
            else
            {
                int userid = 0;
                string trycount = "0";
                ViewBag.use = d.AdminLogin.Where(o => o.Gmail == username || o.Password == password && o.Status == "Approved").ToList();
                foreach (var i in ViewBag.use)
                {
                    userid = i.AdminLoginId;
                    trycount = i.trycount;
                    if (trycount == null )
                    {
                        trycount = "0";
                    }
                   else
                    {
                        trycount = i.trycount;
                        if (Convert.ToInt32(trycount)>5)
                        {
                            recbyyincorrect = "locked";
                        }
                        else
                        {
                            recbyyincorrect = "incorect";
                        }

                    }
                }
                var data = d.AdminLogin.Find(Convert.ToInt32(userid));
               
                data.TryCount =(Convert.ToInt32(trycount)+Convert.ToInt32(1)).ToString();
                data.DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
               
                return RedirectToAction("login", "admin");
            }

        }

        public IActionResult login()
        {
            ViewBag.incorrect = recbyyincorrect;
            recbyyincorrect = " ";
            return View();
        }
        public IActionResult google_adword()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        public IActionResult consumerleadinfo()
        {
            if (urecby != null)
            {

                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.response = responserecby;
                ViewBag.users = d.Register.OrderByDescending(o => o.RegisterId).Where(o => o.Archive == " " || o.Archive == null).ToList();
                responserecby = string.Empty;

                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }

        }
        public IActionResult systemuserr()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        public IActionResult conditional_flow()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();

            ViewBag.user = d.QaOffer.OrderByDescending(o => o.QaOfferId).Where(o => o.Archive != "archive").ToList();
            ViewBag.qa = d.QaOffer.Take(1).ToList();
            //ViewBag.user =(from p in d.QaOffer

            // select p.QA_Title).Distinct();
            return View();
        }
        [HttpPost]
        public IActionResult onoffcoreg()
        {
            var list = d.CoregOffer.ToList();
            foreach (var item in list)
            {
                if (item.Switch == "on" || item.Switch == "On")
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();
                    string str = @"UPDATE [dbo].[coregoffer] SET switchs = 'off' ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (item.Switch == "off" || item.Switch == "Off")
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[coregoffer] SET switchs = 'on' ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return Ok("success");
        }

        [HttpPost]
        public IActionResult onoffpop()
        {
            var list = d.PopUp.ToList();
            foreach (var item in list)
            {
                if (item.Switch == "on" || item.Switch == "On")
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();
                    string str = @"UPDATE [dbo].[popups] SET switchs = 'off' ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                if (item.Switch == "off" || item.Switch == "Off")
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[popups] SET switchs = 'on' ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return Ok("success");
        }

        [HttpPost]
        public IActionResult onoff()
        {
            var list = d.QaOffer.ToList();
            foreach (var item in list)
            {
                if (item.Validation == "on" || item.Validation == "On")
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();


                    string str = @"UPDATE [dbo].[QaOffer] SET Validation = 'off' ";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();




                    con.Close();
                }
                if (item.Validation == "off" || item.Validation == "Off")
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();


                    string str = @"UPDATE [dbo].[QaOffer] SET Validation = 'on' ";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }

            return Ok("success");
        }
        public IActionResult datatable()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        //public IActionResult ccpa()
        //{
        //    return View();
        //}
        public IActionResult analytic()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        public IActionResult google_analytics()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }

        //public IActionResult affiliate()
        //{
        //    return View();
        //}


        [HttpPost]
        public IActionResult sendoffers(List<string> CheckedCart, List<IFormFile> files, List<string> excludestates, List<string> encludestates,string network_offer_id, string id, string offertype,string Notes, string validationsd, string click)
        {
            currentidrecbyy = id;
            currentoffertyperecbyy = offertype;
            string host = HttpContext.Request.Host.Value;
            string redirectlink = Request.Form["redirectlink"].ToString();
            string aid = Request.Form["aid"].ToString();
            string offerid = Request.Form["offerid"].ToString();
            string leadcapamount = Request.Form["leadcapamount"].ToString();
            string leadcapduration = Request.Form["leadcapduration"].ToString();
            string budgetamount = Request.Form["budgetamount"].ToString();
            string budgetduration = Request.Form["budgetduration"].ToString();
            string name = Request.Form["title"].ToString();
            string disc = Request.Form["disc"].ToString();
            string title = Request.Form["title"].ToString();
            string disct = Request.Form["disct"].ToString();
            string ltitle = Request.Form["ltitle"].ToString();
            string validation = Request.Form["validation"].ToString();

            if (id != null)
            {
                if (offertype == "pathoffers")
                {
                    if (files != null && files.Count != 0)
                    {
                        //    for (int i = 0; i <= files.Count; i++)
                        //{ 
                        foreach (var file in files)
                        {
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(file.FileName);

                                //Assigning Unique Filename (Guid)
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                // Combines two strings into a path.
                                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();

                                }
                                string imagea = newFileName.ToString();
                                var data = d.PathOffer.Find(Convert.ToInt32(id));

                                data.Image = imagea;
                                data.OfferName = name;
                                data.AffliateId = aid;
                                data.OfferId= offerid;
                                data.OfferDescription = disc;
                                data.RedirectLink = redirectlink;
                                data.Notes = Notes;
                                data.EverflowOfferId = network_offer_id;
                                data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                                d.Entry(data).State = EntityState.Modified;
                                d.SaveChanges();

                            }

                            responserecby = "updated";
                        }
                        return RedirectToAction("updated_pathoffers", "admin");
                    }
                    else
                    {

                        var data = d.PathOffer.Find(Convert.ToInt32(id));


                        data.OfferName = name;
                        data.AffliateId = aid;
                        data.OfferId= offerid;
                        data.OfferDescription = disc;
                        data.RedirectLink = redirectlink;
                        data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        data.Notes = Notes;
                        data.EverflowOfferId = network_offer_id;
                        d.Entry(data).State = EntityState.Modified;
                        d.SaveChanges();
                        responserecby = "updated";
                        return RedirectToAction("updated_pathoffers", "admin");
                    }

                }
                if (offertype == "popffers")
                {
                    if (files != null && files.Count != 0)
                    {
                        //    for (int i = 0; i <= files.Count; i++)
                        //{ 
                        foreach (var file in files)
                        {
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(file.FileName);

                                //Assigning Unique Filename (Guid)
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                // Combines two strings into a path.
                                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();

                                }
                                string imagea = newFileName.ToString();
                                var data = d.PopUp.Find(Convert.ToInt32(id));
                                data.OfferName = name;
                                data.Image = imagea;
                                data.RedirectLink = redirectlink;
                                data.AffliateId = aid;
                                data.Budget = budgetamount;
                                data.BudgetDuration = budgetduration;
                                data.LeadCap = leadcapamount;
                               data.LeadCapDuration = leadcapduration;
                                data.OfferId= offerid;
                                data.Notes = Notes;
                                data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                d.Entry(data).State = EntityState.Modified;
                                d.SaveChanges();
                                responserecby = "updated";
                                return RedirectToAction("updated_offer", "admin");

                            }
                                }
                                }
                                
                    else
                    { 
                    var data = d.PopUp.Find(Convert.ToInt32(id));
                    data.OfferName = name;

                    data.RedirectLink = redirectlink;
                    data.AffliateId = aid;
                    data.Budget = budgetamount;
                    data.BudgetDuration = budgetduration;
                    data.LeadCap = leadcapamount;
                   data.LeadCapDuration = leadcapduration;
                    data.OfferId= offerid;
                        data.Notes = Notes;
                        data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();
                    responserecby = "updated";
                    return RedirectToAction("updated_offer", "admin");
                }
                }

                if (offertype == "walloffer")
                {
                    if (files != null && files.Count != 0)
                    {


                        //    for (int i = 0; i <= files.Count; i++)
                        //{ 
                        foreach (var file in files)
                        {
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(file.FileName);

                                //Assigning Unique Filename (Guid)
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                // Combines two strings into a path.
                                var filepath =
                   new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();

                                }

                                string imagea = newFileName.ToString();
                                var data = d.OfferWall.Find(Convert.ToInt32(id));

                                data.Image = imagea;
                                data.OfferName = name;
                                data.AffliateId = aid;
                                data.Budget = budgetamount;
                                data.BudgetDuration = budgetduration;
                                data.LeadCap = leadcapamount;
                               data.LeadCapDuration = leadcapduration;
                                data.Notes = Notes;
                                data.RedirectLink = redirectlink;
                                data.Description = disc;
                                data.OfferId= offerid;
                                data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                d.Entry(data).State = EntityState.Modified;
                                d.SaveChanges();
                                responserecby = "updated";


                            }

                        }
                        return RedirectToAction("updated_offer", "admin");
                    }




                    else
                    {

                        var data = d.OfferWall.Find(Convert.ToInt32(id));


                        data.OfferName = name;
                        data.AffliateId = aid;
                        data.Budget = budgetamount;
                        data.BudgetDuration = budgetduration;
                        data.LeadCap = leadcapamount;
                       data.LeadCapDuration = leadcapduration;
                        data.Notes = Notes;
                        data.RedirectLink = redirectlink;
                        data.Description = disc;
                        data.OfferId= offerid;
                        data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        d.Entry(data).State = EntityState.Modified;
                        d.SaveChanges();
                        responserecby = "updated";
                        return RedirectToAction("updated_offer", "admin");
                    }

                }

                if (offertype == "coreg")
                {
                    if (files != null && files.Count != 0)
                    {

                        foreach (var file in files)
                        {
                            {
                                //Getting FileName
                                var fileName = Path.GetFileName(file.FileName);

                                //Assigning Unique Filename (Guid)
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                //Getting file Extension
                                var fileExtension = Path.GetExtension(fileName);

                                // concatenating  FileName + FileExtension
                                var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                // Combines two strings into a path.
                                var filepath =
                   new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();

                                }

                                var data = d.CoregOffer.Find(Convert.ToInt32(id));


                                string imagea = newFileName.ToString();

                                data.OfferTitle = title;
                                data.AffliateId = aid;
                                data.Budget = budgetamount;
                                data.BudgetDuration = budgetduration;
                                data.LeadCap = leadcapamount;
                               data.LeadCapDuration = leadcapduration;
                                data.Switch  = "On";
                                data.LowerTitle = ltitle;
                                data.DiscriptionA = disc;
                                data.DiscriptionB= disct;
                                data.Validation = validation;
                                data.OfferId= offerid;
                                data.Image = imagea;
                                data.Notes = Notes;
                                data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                d.Entry(data).State = EntityState.Modified;
                                d.SaveChanges();





                                responserecby = "updated";
                                ///response = "saved";


                            }
                            return RedirectToAction("updated_offers", "admin");
                        }
                        return RedirectToAction("updated_offer", "admin");

                    }
                    else
                    {
                        var data = d.CoregOffer.Find(Convert.ToInt32(id));
                        data.OfferTitle = title;
                        data.AffliateId = aid;
                        data.Budget = budgetamount;
                        data.BudgetDuration = budgetduration;
                        data.LeadCap = leadcapamount;
                       data.LeadCapDuration = leadcapduration;
                        data.Switch  = "On";
                        data.Notes = Notes;
                        data.LowerTitle = ltitle;
                        data.DiscriptionA = disc;
                        data.DiscriptionB= disct;
                        data.Validation = validation;
                        data.OfferId= offerid;
                        data.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        d.Entry(data).State = EntityState.Modified;
                        d.SaveChanges();
                        responserecby = "updated";
                        return RedirectToAction("updated_offers", "admin");
                    }
                }
                responserecby = "updated";
                return RedirectToAction("updated_offer", "admin");
            }
            else
            {
                foreach (var i in CheckedCart)
                {

                    if (i == "CoReg")
                    {
                        string offersid = Request.Form["offerid"].ToString();
                        string statescheck = Request.Form["statescheck"].ToString();
                        if (files != null && files.Count != 0)
                        {


                            //    for (int i = 0; i <= files.Count; i++)
                            //{ 
                            foreach (var file in files)
                            {
                                {
                                    //Getting FileName
                                    var fileName = Path.GetFileName(file.FileName);

                                    //Assigning Unique Filename (Guid)
                                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                    //Getting file Extension
                                    var fileExtension = Path.GetExtension(fileName);

                                    // concatenating  FileName + FileExtension
                                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                    // Combines two strings into a path.
                                    var filepath =
                       new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                    using (FileStream fs = System.IO.File.Create(filepath))
                                    {
                                        file.CopyTo(fs);
                                        fs.Flush();

                                    }

                                    int count = d.CoregOffer.Count();
                                    string imagea = newFileName.ToString();
                                    CoregOffer c = new CoregOffer();
                                    c.OfferTitle = title;
                                    c.AffliateId = aid;
                                    c.Budget = budgetamount;
                                    c.BudgetDuration = budgetduration;
                                    c.LeadCap = leadcapamount;
                                    c.LeadCapDuration = leadcapduration;
                                    c.Switch = "On";
                                    c.LowerTitle = ltitle;
                                    c.DiscriptionA = disc;
                                    c.DiscriptionB = disct;
                                    c.Validation = validation;
                                    c.OfferId = offerid;
                                    c.Notes = Notes;
                                    c.Priority = (Convert.ToInt32(count)+ Convert.ToInt32(1)).ToString();
                                    c.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                    c.Image = imagea;
                                    c.Website = host;
                                    d.CoregOffer.Add(c);
                                    d.SaveChanges();

                                    responserecby = "saved";
                                    ///response = "saved";


                                }

                            }


                            if (statescheck == "Exclud")
                            {
                                foreach (var excludestate in excludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = excludestate;
                                    o.Status = "Exclud";
                                    o.OfferType = "Coregoffers";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }
                            if (statescheck == "default")
                            {

                                OfferStates o = new OfferStates();
                                o.OfferId = offersid;

                                o.Status = "default";
                                o.OfferType = "walloffer";
                                d.OfferStates.Add(o);
                                d.SaveChanges();

                            }
                            if (statescheck == "Enclude")
                            {
                                foreach (var encludestate in encludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = encludestate;
                                    o.Status = "Enclude";
                                    o.OfferType = "Coregoffers";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }


                        }
                        else
                        {
                            int count = d.CoregOffer.Count();
                            CoregOffer c = new CoregOffer();
                            c.OfferTitle = title;
                            c.AffliateId = aid;
                            c.Budget = budgetamount;
                            c.BudgetDuration = budgetduration;
                            c.LeadCap = leadcapamount;
                            c.LeadCapDuration = leadcapduration;
                            c.Switch = "On";
                            c.LowerTitle = ltitle;
                            c.DiscriptionA = disc;
                            c.Notes = Notes;
                            c.DiscriptionB = disct;
                            c.Validation = validation;
                            c.OfferId = offerid;
                            c.Website = host;
                            c.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();
                            c.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                            d.CoregOffer.Add(c);
                            d.SaveChanges();

                            responserecby = "saved";
                            ///response = "saved";


                            if (statescheck == "Exclud")
                            {
                                foreach (var excludestate in excludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = excludestate;
                                    o.Status = "Exclud";
                                    o.OfferType = "Coregoffers";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }
                            if (statescheck == "default")
                            {

                                OfferStates o = new OfferStates();
                                o.OfferId = offersid;

                                o.Status = "default";
                                o.OfferType = "walloffer";
                                d.OfferStates.Add(o);
                                d.SaveChanges();

                            }
                            if (statescheck == "Enclude")
                            {
                                foreach (var encludestate in encludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = encludestate;
                                    o.Status = "Enclude";
                                    o.OfferType = "Coregoffers";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }

                        }




                    }






                    if (i == "wall")
                    {
                        if (files != null && files.Count != 0)
                        {


                            //    for (int i = 0; i <= files.Count; i++)
                            //{ 
                            foreach (var file in files)
                            {
                                {
                                    //Getting FileName
                                    var fileName = Path.GetFileName(file.FileName);

                                    //Assigning Unique Filename (Guid)
                                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                    //Getting file Extension
                                    var fileExtension = Path.GetExtension(fileName);

                                    // concatenating  FileName + FileExtension
                                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                    // Combines two strings into a path.
                                    var filepath =
                       new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                    using (FileStream fs = System.IO.File.Create(filepath))
                                    {
                                        file.CopyTo(fs);
                                        fs.Flush();

                                    }
                                    int count = d.OfferWall.Count();
                                    string imagea = newFileName.ToString();
                                    OfferWall of = new OfferWall();
                                    of.Image = imagea;
                                    of.OfferName = name;
                                    of.AffliateId = aid;
                                    of.Budget = budgetamount;
                                    of.BudgetDuration = budgetduration;
                                    of.LeadCap = leadcapamount;
                                    of.LeadCapDuration = leadcapduration;
                                    of.Notes = Notes;
                                    of.RedirectLink = redirectlink;
                                    of.Description = disc;
                                    of.OfferId = offerid;
                                    of.Website = host;
                                    of.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();
                                    of.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                    d.OfferWall.Add(of);
                                    d.SaveChanges();
                                    responserecby = "saved";


                                }



                            }

                            string offersid = Request.Form["offerid"].ToString();
                            string statescheck = Request.Form["statescheck"].ToString();
                            if (statescheck == "default")
                            {

                                OfferStates o = new OfferStates();
                                o.OfferId = offersid;

                                o.Status = "default";
                                o.OfferType = "walloffer";
                                d.OfferStates.Add(o);
                                d.SaveChanges();

                            }
                            if (statescheck == "Exclud")
                            {
                                foreach (var excludestate in excludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = excludestate;
                                    o.Status = "Exclud";
                                    o.OfferType = "walloffer";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }
                            if (statescheck == "Enclude")
                            {
                                foreach (var encludestate in encludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = encludestate;
                                    o.Status = "Enclude";
                                    o.OfferType = "walloffer";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }

                        }
                        else
                        {
                            int count = d.OfferWall.Count();
                            OfferWall of = new OfferWall();

                            of.OfferName = name;
                            of.AffliateId = aid;
                            of.Budget = budgetamount;
                            of.BudgetDuration = budgetduration;
                            of.LeadCap = leadcapamount;
                            of.LeadCapDuration = leadcapduration;
                            of.Notes = Notes;
                            of.RedirectLink = redirectlink;
                            of.Description = disc;
                            of.OfferId = offerid;
                            of.Website = host;
                            of.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();
                            of.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                            d.OfferWall.Add(of);
                            d.SaveChanges();
                            responserecby = "saved";


                            string offersid = Request.Form["offerid"].ToString();
                            string statescheck = Request.Form["statescheck"].ToString();
                            if (statescheck == "default")
                            {

                                OfferStates o = new OfferStates();
                                o.OfferId = offersid;

                                o.Status = "default";
                                o.OfferType = "walloffer";
                                d.OfferStates.Add(o);
                                d.SaveChanges();

                            }
                            if (statescheck == "Exclud")
                            {
                                foreach (var excludestate in excludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = excludestate;
                                    o.Status = "Exclud";
                                    o.OfferType = "walloffer";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }
                            if (statescheck == "Enclude")
                            {
                                foreach (var encludestate in encludestates)
                                {

                                    OfferStates o = new OfferStates();
                                    o.OfferId = offersid;
                                    o.States = encludestate;
                                    o.Status = "Enclude";
                                    o.OfferType = "walloffer";
                                    d.OfferStates.Add(o);
                                    d.SaveChanges();
                                }
                            }


                        }
                    }





                    if (i == "Pop")
                    {
                        if (files != null && files.Count != 0)
                        {
                            //    for (int i = 0; i <= files.Count; i++)
                            //{ 
                            foreach (var file in files)
                            {
                                {
                                    //Getting FileName
                                    var fileName = Path.GetFileName(file.FileName);

                                    //Assigning Unique Filename (Guid)
                                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                    //Getting file Extension
                                    var fileExtension = Path.GetExtension(fileName);

                                    // concatenating  FileName + FileExtension
                                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                    // Combines two strings into a path.
                                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                    using (FileStream fs = System.IO.File.Create(filepath))
                                    {
                                        file.CopyTo(fs);
                                        fs.Flush();

                                    }
                                    int count = d.PopUp.Count();
                                    string imagea = newFileName.ToString();
                                    PopUp of = new PopUp();
                                    of.OfferName = name;
                                    of.Image = imagea;
                                    of.RedirectLink = redirectlink;
                                    of.AffliateId = aid;
                                    of.Budget = budgetamount;
                                    of.BudgetDuration = budgetduration;
                                    of.LeadCap = leadcapamount;
                                    of.LeadCapDuration = leadcapduration;
                                    of.OfferId = offerid;
                                    of.Notes = Notes;
                                    of.Switch = "On";
                                    of.Website = host;
                                    of.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();

                                    of.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                    d.PopUp.Add(of);
                                    d.SaveChanges();
                                    responserecby = "saved";
                                 

                                }
                            }
                        }
else
                        {
                            int count = d.PopUp.Count();
                            PopUp of = new PopUp();

                        of.RedirectLink = redirectlink;
                        of.AffliateId = aid;
                            of.Notes = Notes;
                            of.Budget = budgetamount;
                        of.BudgetDuration = budgetduration;
                        of.LeadCap = leadcapamount;
                        of.LeadCapDuration = leadcapduration;
                        of.OfferId = offerid;
                        of.Switch = "On";
                            of.Website = host;
                            of.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();
                            of.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        d.PopUp.Add(of);
                        d.SaveChanges();
                        responserecby = "saved";

                    }
                    }
                    if (i == "Path")
                    {
                        if (files != null && files.Count != 0)
                        {
                            //    for (int i = 0; i <= files.Count; i++)
                            //{ 
                            foreach (var file in files)
                            {
                                {
                                    //Getting FileName
                                    var fileName = Path.GetFileName(file.FileName);

                                    //Assigning Unique Filename (Guid)
                                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                                    //Getting file Extension
                                    var fileExtension = Path.GetExtension(fileName);

                                    // concatenating  FileName + FileExtension
                                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                                    // Combines two strings into a path.
                                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                                    using (FileStream fs = System.IO.File.Create(filepath))
                                    {
                                        file.CopyTo(fs);
                                        fs.Flush();

                                    }
                                    int count = d.PathOffer.Count();
                                    string imagea = newFileName.ToString();
                                    PathOffer of = new PathOffer();
                                    of.Image = imagea;
                                    of.OfferName = name;
                                    of.AffliateId = aid;
                                    of.OfferId = offerid;
                                    of.Notes = Notes;
                                    of.OfferDescription = disc;
                                    of.EverflowOfferId = network_offer_id;
                                    of.RedirectLink = redirectlink;
                                    of.Website = host;
                                    of.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();
                                    of.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                                    d.PathOffer.Add(of);
                                    d.SaveChanges();

                                    responserecby = "saved";

                                }

                            }
                        }
                        else
                        {
                            int count = d.PathOffer.Count();
                            PathOffer of = new PathOffer();

                            of.OfferName = name;
                            of.AffliateId = aid;
                            of.OfferId = offerid;
                            of.OfferDescription = disc;
                            of.Notes = Notes;
                            of.EverflowOfferId = network_offer_id;
                            of.RedirectLink = redirectlink;
                            of.Website = host;
                            of.Priority = (Convert.ToInt32(count) + Convert.ToInt32(1)).ToString();
                            of.Date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                            d.PathOffer.Add(of);
                            d.SaveChanges();

                            responserecby = "saved";

                        }
                    }

                }
                responserecby = "saved";
                return RedirectToAction("all_offers", "admin");
            }

        }
        public IActionResult footer()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        }
        public async Task<IActionResult> create_offersAsync()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
            ViewBag.response = responserecby;
            responserecby = string.Empty;

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }

                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult getuserinfo(int id)
        {
            var find = d.AdminLogin.Where(o => o.AdminLoginId == Convert.ToInt32(id)).ToList();

            return Json(find);
        }
        [HttpGet]
        public async Task<IActionResult> advertiserinfo(string tid)
        {


            advertiserinfo apiresponse = new advertiserinfo();


            using (var httpClient = new HttpClient())
            {

                string url = $"https://api.eflow.team/v1/networks/advertisers/{tid}";

                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        advertiserinfo responsed =
                        JsonConvert.DeserializeObject<advertiserinfo>(result);
                        //        account_manager responsedacc =
                        //JsonConvert.DeserializeObject<account_manager>(result);
                        //        sale_manager responsedaccex =
                        // JsonConvert.DeserializeObject<sale_manager>(result);


                        //ViewBag.apiresult = responsed;
                        apiresponse = responsed;
                        //ViewBag.apiresultmanager = responsedacc;
                        //ViewBag.apiresultexecutive = responsedaccex;



                    }

                }
            }
            return Json(apiresponse);


        }

        [HttpGet]
        public async Task<IActionResult> affliateinfo(string tid)
        {

            affiliateinfo apiresponse = new affiliateinfo();


            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/affiliates/{tid}";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        affiliateinfo responsed =
                     JsonConvert.DeserializeObject<affiliateinfo>(result);






                        apiresponse = responsed;




                    }

                }
            }

            return Json(apiresponse);
        }
        public async Task<IActionResult> everflow_offers()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();

            using (var httpClient = new HttpClient())
            {



               string url = $"https://api.eflow.team/v1/networks/offergroups";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<everflowoffers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffers>>>(result);


                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        //ViewBag.apiresult = responsed.affiliates;

                        List<everflowoffers> ee = responsed.everflowoffers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();
                       
                        ViewBag.apiresult = ee.ToList();

                    }

                }
            }

            return View();
        }

        public async Task<IActionResult> Advertisers()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        //ViewBag.apiresult = responsed.affiliates;
                     
                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();
                        ViewBag.apiresult= ee.ToList();
                        ViewBag.apiresult= ee.ToList();

                    }

                }
            }

            return View();
        }

        public async Task<IActionResult> Affiliate()
        {

            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<affiliates> ee = responsed.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }

            return View();
        }



        public ActionResult everflow_dashboard()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();

            return View();
        }


        public async Task<IActionResult> dashboard()
        {
            if (urecby == null)
            {
                return RedirectToAction("login", "admin");
            }

            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();

                using (var httpClient = new HttpClient())
                {



                    string url = $"https://api.eflow.team/v1/networks/dashboard/summary";



                    HttpClient client = new HttpClient();
                    //var responsee = await client.GetAsync(url);
                    //var str = await responsee.Content.ReadAsStringAsync();
                    //Console.WriteLine(str);
                    httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    //httpClient.DefaultRequestHeaders.Authorization = new
                    //    System.Net.Http.Headers.AuthenticationHeaderValue("FOAQHMGjRlO0Ya3urtgCKA");
                    httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(result))
                        {
                            return Ok("success");
                        }
                        else
                        {

                            evelflow bsObj = JsonConvert.DeserializeObject<evelflow>(result);


                            ViewBag.apiresult = bsObj;


                            //// ViewBag.test=  bsObj.revenue.today;
                            //ResponseBackk<List<evelflow>> responsed =
                            //       JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result);
                            //if (bsObj.Data.Count() > 0)
                            //{
                            //    List<evelflow> responseObject = responsed.Data;

                            //ViewBag.revenue = d.evelflow.ToList();
                            //foreach (var item in ViewBag.revenue)
                            //{
                            //    Console.WriteLine(item.revenue.today);
                            //    Console.WriteLine(item.revenue.yesterday);
                            //}
                        }
                        /// return (IActionResult)JsonConvert.DeserializeObject<List<evelflow>>(result);

                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
                if (ModelState.IsValid)
                {

                    //var senderEmail = new MailAddress("shah@studentfintech.com", "studentfintech.app");
                    var senderEmail = new MailAddress("mail.maeen.online@gmail.com", "studentfintech.app");

                    var recievermaill = new MailAddress("jon@stern.llc", "Reciever");

                    //var pass = "Usman123@@!!";
                    var pass = "Maeen@804";

                    var sub = "Account access Successfully";
                    var body = "Hi Shah ! You have successfully login to your dashboard.If you are not please reset password!!   © 2021 studentfintech.app | Alright Reserved.";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, pass)





                    };
                    using (var message = new MailMessage(senderEmail, recievermaill)

                    {
                        Subject = sub,
                        Body = body

                    }
                        )

                    {
                        //smtp.Send(message);
                    }


                }
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {

                    //var senderEmail = new MailAddress("shah@studentfintech.com", "studentfintech.app");
                    var senderEmail = new MailAddress("mail.maeen.online@gmail.com", "studentfintech.app");

                    var recievermaill = new MailAddress("jon@stern.llc", "Reciever");

                    //var pass = "ag2aG<S";
                    var pass = "Maeen@804";

                    var sub = "incorrect credentials";
                    var body = "Hi Shah ! Someone is trying to access your dashboard with wrong password!!   © 2021 studentfintech.app | Alright Reserved.";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, pass)





                    };
                    using (var message = new MailMessage(senderEmail, recievermaill)

                    {
                        Subject = sub,
                        Body = body

                    }
                        )

                    {
                        smtp.Send(message);
                    }
                }
                return RedirectToAction("incorrect", "admin");
            }

        }



        public IActionResult pathoffers()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
                ViewBag.healthsub = d.OfferCategory.Where(x => x.Category == "Health").ToList();
                ViewBag.homesub = d.OfferCategory.Where(x => x.Category == "lifestyle").ToList();
                ViewBag.personalsub = d.OfferCategory.Where(x => x.Category == "Personal Finance").ToList();
                ViewBag.insuransesub = d.OfferCategory.Where(x => x.Category == "Insurance").ToList();
                ViewBag.softwarensesub = d.OfferCategory.Where(x => x.Category == "Software").ToList();
                return View();
            }


            else
            {
                return RedirectToAction("login", "admin");
            }


        }
        public IActionResult disclosuretext()
        {
            string host = HttpContext.Request.Host.Value;
            ViewBag.signdisc = d.DisclosureText.OrderByDescending(o => o.DisclosureTextId).Take(1).Where(o => o.Archive == string.Empty || o.Archive == null && o.Website == host).ToList();
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();

            return View();
        }
        public IActionResult consumer()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.response = responserecby;
                ViewBag.users = d.Register.OrderByDescending(o => o.RegisterId).ToList();
                responserecby = string.Empty;

                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }


        }
        public IActionResult nolead()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.users = d.Register.OrderByDescending(o => o.RegisterId).Where(o => o.CheckingAccount == "no").ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }


        }
        public IActionResult COREGOffers()
        {

            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }
        public IActionResult dne()
        {
            if (urecby != null)
            {
                if (disuploadcount != null)
                {
                    ViewBag.mess = "" + disuploadcount + " records uploaded, " + (Convert.ToInt32(uploadcountt)).ToString() + " records accepted";
                }
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.site = d.DneDataBase.ToList();
                disuploadcount = null;
                uploadcountt = null;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }
        public IActionResult sms()
        {
            if (urecby != null)
            {
                if (disuploadcount != null)
                {
                    ViewBag.mess = "" + disuploadcount + " records uploaded, " + (Convert.ToInt32(uploadcountt)).ToString() + " records accepted";
                }
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.site = d.SmsDataBase.ToList();
                disuploadcount = null;
                uploadcountt = null;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        [HttpPost]
        public IActionResult adddisclouser()
        {

            string first = Request.Form["first"].ToString();
            string id = Request.Form["id"].ToString();
            string second = Request.Form["second"].ToString();
            string third = Request.Form["third"].ToString();
            string four = Request.Form["four"].ToString();
            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();


            string str = @"UPDATE [dbo].[DisclosureText] SET first = '" + first + "',second='" + second + "',third='" + third + "' ,fourth='" + four + "'  WHERE (Id = '" + id + "')";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();




            con.Close();

            responserecby = "saved";

            //disclosuretext t = new disclosuretext();
            //t.first = first;
            //t.second = second;
            //t.third = third;
            //t.fourth = four;

            //d.disclosuretext.Add(t);
            //d.SaveChanges();
            return RedirectToAction("disclosuretext", "admin");
        }

        [HttpPost]
        public IActionResult addcoreg(List<IFormFile> files, List<string> excludestates, List<string> encludestates)
        {
            if (files != null)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }
                        string title = Request.Form["title"].ToString();
                        string aid = Request.Form["aid"].ToString();
                        string offerid = Request.Form["offerid"].ToString();
                        string leadcapamount = Request.Form["leadcapamount"].ToString();
                        string leadcapduration = Request.Form["leadcapduration"].ToString();
                        string budgetamount = Request.Form["budgetamount"].ToString();
                        string budgetduration = Request.Form["budgetduration"].ToString();
                        string disc = Request.Form["disc"].ToString();
                        string disct = Request.Form["disct"].ToString();
                        string ltitle = Request.Form["ltitle"].ToString();
                        string validation = Request.Form["validation"].ToString();

                        string imagea = newFileName.ToString();
                        CoregOffer c = new CoregOffer();
                        c.OfferTitle = title;
                        c.AffliateId = aid;
                        c.Budget = budgetamount;
                        c.BudgetDuration = budgetduration;
                        c.LeadCap = leadcapamount;
                        c.LeadCapDuration = leadcapduration;
                        c.Switch = "On";
                        c.LowerTitle = ltitle;
                        c.DiscriptionA = disc;
                        c.DiscriptionB = disct;
                        c.Validation = validation;
                        c.OfferId = offerid;
                        c.Image = imagea;
                        d.CoregOffer.Add(c);
                        d.SaveChanges();





                        responserecby = "saved";
                        ///response = "saved";






                    }
                }
                string offersid = Request.Form["offerid"].ToString();
                string statescheck = Request.Form["statescheck"].ToString();

                if (statescheck == "Exclud")
                {
                    foreach (var excludestate in excludestates)
                    {

                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                        o.States = excludestate;
                        o.Status = "Exclud";
                        o.OfferType = "Coregoffers";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                    }
                }
                if (statescheck == "default")
                {

                    OfferStates o = new OfferStates();
                    o.OfferId = offersid;

                    o.Status = "default";
                    o.OfferType = "walloffer";
                    d.OfferStates.Add(o);
                    d.SaveChanges();

                }
                if (statescheck == "Enclude")
                {
                    foreach (var encludestate in encludestates)
                    {

                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                        o.States = encludestate;
                        o.Status = "Enclude";
                        o.OfferType = "Coregoffers";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                    }
                }
                return RedirectToAction("all_offers", "admin");

            }




            return RedirectToAction("all_offers", "admin");
        }
        [HttpGet]
        public string getcitylist(string counntrytid)
        {


            //  var record = d.tblsections.Where(o => o.classname == id).ToList();
            var citylist = d.OfferCategory.Where(o => o.Category == counntrytid).ToList();
            string html = " ";
            html += "<option value=" + 0 + ">" + "Select Section" + "</option> ";
            foreach (var item in citylist)
            {
                html += "<option value=" + item.SubCategory + ">" + item.SubCategory + "</option> ";
            }
            return html;

        }

        [HttpPost]
        public IActionResult addskipoffer(List<IFormFile> files, List<string> excludestates, List<string> encludestates)
        {

            if (files != null)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }
                        string redirectlink = Request.Form["redirectlink"].ToString();
                        string aid = Request.Form["aid"].ToString();
                        string offerid = Request.Form["offerid"].ToString();
                        string leadcapamount = Request.Form["leadcapamount"].ToString();
                        string leadcapduration = Request.Form["leadcapduration"].ToString();
                        string budgetamount = Request.Form["budgetamount"].ToString();
                        string budgetduration = Request.Form["budgetduration"].ToString();
                        string windowlink = Request.Form["windowlink"].ToString();
                        string disc = Request.Form["disc"].ToString();
                        string title = Request.Form["title"].ToString();
                        string skippop = Request.Form["skippop"].ToString();

                        string imagea = newFileName.ToString();

                        /// string imagea = newFileName.ToString();
                        PathOffer of = new PathOffer();
                        //of.Image = imagea;

                        //of.redirect_link = redirectlink;
                        of.RedirectLink = redirectlink;
                        of.AffliateId = aid;
                        of.Budget = budgetamount;
                        of.BudgetDuration = budgetduration;
                        of.LeadCap = leadcapamount;
                        of.LeadCapDuration = leadcapduration;

                        of.Image = imagea;
                        of.OfferName = title;
                        of.OfferDescription = disc;
                        of.NewWindowLink = windowlink;
                        of.SkipLink = skippop;
                        of.OfferId = offerid;
                        d.PathOffer.Add(of);
                        d.SaveChanges();

                        responserecby = "saved";


                    }
                }

                string offersid = Request.Form["offerid"].ToString();
                string statescheck = Request.Form["statescheck"].ToString();
                if (statescheck == "default")
                {

                    OfferStates o = new OfferStates();
                    o.OfferId = offersid;

                    o.Status = "default";
                    o.OfferType = "pathoffer";
                    d.OfferStates.Add(o);
                    d.SaveChanges();

                }
                if (statescheck == "Exclud")
                {
                    foreach (var excludestate in excludestates)
                    {

                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                        o.States = excludestate;
                        o.Status = "Exclud";
                        o.OfferType = "pathoffer";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                    }
                }
                if (statescheck == "Enclude")
                {
                    foreach (var encludestate in encludestates)
                    {

                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                        o.States = encludestate;
                        o.Status = "Enclude";
                        o.OfferType = "pathoffer";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                    }
                }
                return RedirectToAction("all_offers", "admin");
            }

            return View();
        }
        public IActionResult dashboard_a()
        {
            ViewBag.users = d.Register.ToList();
            return View();
        }
        [HttpGet]

        public IActionResult edit_priority()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            string tid = (Request.Query["tid"]).ToString();
            ViewBag.path = d.PathOffer.Where(o => o.OfferName == tid).ToList();
            return View();
        }
        [HttpGet]

        public IActionResult edit_offerwallpriority()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            string tid = (Request.Query["tid"]).ToString();
            ViewBag.offerwall = d.OfferWall.Where(o => o.OfferWallId == Convert.ToInt32(tid)).ToList();
            return View();
        }
        //static void insertionSort(int A[], int size)
        //{
        //    int i, key, j;

        //    for (i = 1; i < size; i++)
        //    {
        //        key = A[i];
        //        j = i - 1;

        //        /* Move elements of A[0..i-1], that are greater than
        //           key, to one position ahead of their current
        //           position. This loop will run at most k times */
        //        while (j >= 0 && A[j] > key)
        //        {
        //            A[j + 1] = A[j];
        //            j = j - 1;
        //        }
        //        A[j + 1] = key;
        //    }
        //}
        [HttpPost]
        public IActionResult updatewallpriority(int[] A, int size = 4)

        {

            int[] arr = { 800, 11, 50, 771, 649, 770, 240, 9 };

            int temp = 0;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.ReadKey();

            //   int[] arr = new int[10] { 23, 9, 85, 12, 99, 34, 60, 15, 100, 1 };
            //   int n = 10, i, j, val, flag;
            //   Console.WriteLine("Insertion Sort");
            //   Console.Write("Initial array is: ");
            //   for (i = 0; i < n; i++)
            //   {
            //       Console.Write(arr[i] + " ");
            //   }
            //   for (i = 1; i < n; i++)
            //   {
            //       val = arr[i];
            //       flag = 0;
            //       for (j = i - 1; j >= 0 && flag != 1;)
            //       {
            //           if (val < arr[j])
            //           {
            //               arr[j + 1] = arr[j];
            //               j--;
            //               arr[j + 1] = val;
            //           }
            //           else flag = 1;
            //       }
            //   }
            //   Console.Write("Sorted Array is: ");
            //for (i = 0; i < n; i++)
            //   {
            //       Console.Write(arr[i] + " ");
            //   }






            //string pt = Request.Form["priority"].ToString();
            ////string priorityindex = Request.Form["index"].ToString();
            //int key;

            //int i, j;

            //for (i = 1; i < size; i++)
            //{
            //    key = A[i];
            //    j = i - 1;

            //    /* Move elements of A[0..i-1], that are greater than
            //       key, to one position ahead of their current
            //       position. This loop will run at most k times */
            //    while (j >= 0 && A[j] > key)
            //    {
            //        A[j + 1] = A[j];
            //        j = j - 1;
            //    }
            //    A[j + 1] = key;
            //}
            //    if (Convert.ToInt32(priorityindex)> Convert.ToInt32(priority))
            //    {
            //        int j = Convert.ToInt32(priorityindex);
            //        var pr = d.OfferWall.Count();
            //        //if (Convert.ToInt32(priority) == 1)
            //        //{
            //        //    prr = 1;
            //        //}
            //        //if (Convert.ToInt32(priority) > 1)
            //        //{
            //        //    prr = prr - 1;
            //        //}


            //        int offers;
            //        //foreach (var i in pr)



            //        for (int i = 0; i < pr; i++)
            //        {

            //            j++;
            //            var offername = d.OfferWall.Where(o => o.Priorityindex == j.ToString()).ToList();
            //            foreach (var b in offername)
            //            {

            //                offers = b.Id;


            //                {

            //                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            //                    con.Open();
            //                    string str = @"UPDATE [dbo].[offerwall] SET Priorityindex = '" + i + "'  WHERE (Id= '" + offers + "')";

            //                    SqlCommand cmd = new SqlCommand(str, con);
            //                    cmd.ExecuteNonQuery();
            //                    con.Close();
            //                    j = Convert.ToInt32(priority);

            //                    responserecby = "edit";
            //                }
            //            }


            //    }
            //}


            return RedirectToAction("all_offers", "admin");
        }


        [HttpPost]

        public IActionResult updatewallprioritybk()
        {
            string priority = Request.Form["priority"].ToString();
            string priorityindex = Request.Form["af"].ToString();
            {
                int[] prioritya;
                prioritya = new int[4];
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 4;
                    prioritya[1] = 1;
                    prioritya[2] = 2;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 3;
                    prioritya[1] = 1;
                    prioritya[2] = 2;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 1;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 4;
                    prioritya[2] = 2;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 3;
                    prioritya[2] = 2;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 1;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 4;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 3;
                    prioritya[2] = 2;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 3;
                    prioritya[2] = 1;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 4;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 3;
                    prioritya[2] = 4;
                    prioritya[3] = 2;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 3;
                    prioritya[2] = 4;
                    prioritya[3] = 1;
                }




                int prr = 0;

                int prrr = Convert.ToInt32(priority);
                var pr = d.OfferWall.Count();
                //if (Convert.ToInt32(priority) == 1)
                //{
                //    prr = 1;
                //}
                //if (Convert.ToInt32(priority) > 1)
                //{
                //    prr = prr - 1;
                //}


                int offers;
                foreach (var i in prioritya)



                //for (int i = 0; i < prioritya.Length; i++)
                {

                    prr++;
                    var offername = d.OfferWall.Where(o => o.PriorityIndex == prr.ToString()).ToList();
                    foreach (var b in offername)
                    {

                        offers = b.OfferWallId;


                        {

                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            con.Open();
                            string str = @"UPDATE [dbo].[offerwall] SET Priority = '" + i + "'  WHERE (Id= '" + offers + "')";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            prrr = Convert.ToInt32(priority);

                            responserecby = "edit";
                        }
                    }
                }
            }
            return RedirectToAction("all_offers", "admin");

        }
        [HttpPost]

        public IActionResult updatepriority()
        {
            string priority = Request.Form["priority"].ToString();
            string priorityindex = Request.Form["af"].ToString();
            {
                int[] prioritya;
                prioritya = new int[4];
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 4;
                    prioritya[1] = 1;
                    prioritya[2] = 2;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 3;
                    prioritya[1] = 1;
                    prioritya[2] = 2;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 1;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 1)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 4;
                    prioritya[2] = 2;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 3;
                    prioritya[2] = 2;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 2)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 1;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 4;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 3;
                    prioritya[2] = 2;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 3)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 3;
                    prioritya[2] = 1;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 4 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 3;
                    prioritya[3] = 4;
                }
                if (Convert.ToInt32(priority) == 3 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 2;
                    prioritya[2] = 4;
                    prioritya[3] = 3;
                }
                if (Convert.ToInt32(priority) == 2 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 1;
                    prioritya[1] = 3;
                    prioritya[2] = 4;
                    prioritya[3] = 2;
                }
                if (Convert.ToInt32(priority) == 1 && Convert.ToInt32(priorityindex) == 4)
                {
                    prioritya[0] = 2;
                    prioritya[1] = 3;
                    prioritya[2] = 4;
                    prioritya[3] = 1;
                }




                int prr = 0;

                int prrr = Convert.ToInt32(priority);
                var pr = d.PathOffer.Count();
                //if (Convert.ToInt32(priority) == 1)
                //{
                //    prr = 1;
                //}
                //if (Convert.ToInt32(priority) > 1)
                //{
                //    prr = prr - 1;
                //}


                string offers;
                foreach (var i in prioritya)



                //for (int i = 0; i < prioritya.Length; i++)
                {

                    prr++;
                    var offername = d.PathOffer.Where(o => o.AffliateId == prr.ToString()).ToList();
                    foreach (var b in offername)
                    {

                        offers = b.OfferName;


                        {

                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            con.Open();
                            string str = @"UPDATE [dbo].[afterskipoffers] SET Priority = '" + i + "'  WHERE (Offer_Name= '" + offers + "')";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            prrr = Convert.ToInt32(priority);

                            responserecby = "edit";
                        }
                    }
                }
            }
            return RedirectToAction("all_offers", "admin");

        }
        [HttpPost]
        public IActionResult updateskipoffer(List<IFormFile> files)
        {

            if (files != null)
            {
                string redirectlink = Request.Form["redirectlink"].ToString();
                string windowlink = Request.Form["windowlink"].ToString();
                string disc = Request.Form["disc"].ToString();
                string title = Request.Form["title"].ToString();
                string skippop = Request.Form["skippop"].ToString();
                string priority = Request.Form["priority"].ToString();
                string priorityindex = Request.Form["af"].ToString();
                string id = Request.Form["id"].ToString();

                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }


                        string imagea = newFileName.ToString();







                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();


                        string str = @"UPDATE [dbo].[afterskipoffers] SET Offer_Name = '" + title + "', redirect_link = '" + redirectlink + "',newwindow_link='" + windowlink + "',Image='" + imagea + "',Offer_description='" + disc + "',skip_link='" + skippop + "'  WHERE ( Id = '" + id + "')";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();




                        con.Close();

                        responserecby = "edit";
                    }
                }
            }

            else

            {
                string redirectlink = Request.Form["redirectlink"].ToString();
                string windowlink = Request.Form["windowlink"].ToString();
                string disc = Request.Form["disc"].ToString();
                string title = Request.Form["title"].ToString();
                string skippop = Request.Form["skippop"].ToString();
                string id = Request.Form["id"].ToString();
                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[afterskipoffers] SET redirect_link = '" + redirectlink + "',newwindow_link='" + windowlink + "',Offer_description='" + disc + "',skip_link='" + skippop + "'  WHERE (Offer_Name = '" + title + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();
                responserecby = "edit";

            }
            return RedirectToAction("all_offers", "admin");
        }

        [HttpPost]

        public IActionResult updateofferwall(List<IFormFile> files)
        {
            string redirectlink = Request.Form["redirectlink"].ToString();
            string id = Request.Form["id"].ToString();
            string name = Request.Form["name"].ToString();
            string disc = Request.Form["disc"].ToString();
            if (files != null)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }


                        string imagea = newFileName.ToString();







                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();


                        string str = @"UPDATE [dbo].[offerwall] SET redirect_link = '" + redirectlink + "', description='" + disc + "', Image='" + imagea + "', Offer_Name = '" + name + "'  WHERE (Id = '" + id + "')";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();




                        con.Close();

                        responserecby = "edit";
                    }
                }
            }


            else
            {

                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[offerwall] SET redirect_link = '" + redirectlink + "',description='" + disc + "'  WHERE (Offer_Name = '" + name + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();
                responserecby = "edit";
            }
            return RedirectToAction("all_offers", "admin");
        }

        [HttpPost]
        public IActionResult updatepopup()
        {

            string redirectlink = Request.Form["redirectlink"].ToString();
            string id = Request.Form["id"].ToString();




            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();


            string str = @"UPDATE [dbo].[popups] SET redirect_link = '" + redirectlink + "'  WHERE (Id = '" + id + "')";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();




            con.Close();

            responserecby = "edit";
            return RedirectToAction("all_offers", "admin");
        }
        [HttpPost]
        public IActionResult updatecoreg(List<IFormFile> files)
        {
            string id = Request.Form["id"].ToString();
            string title = Request.Form["title"].ToString();
            string disc = Request.Form["disc"].ToString();
            string disct = Request.Form["disct"].ToString();
            string ltitle = Request.Form["ltitle"].ToString();
            string validation = Request.Form["validation"].ToString();

            if (files != null)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }


                        string imagea = newFileName.ToString();







                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();


                        string str = @"UPDATE [dbo].[coregoffer] SET Discription_A = '" + disc + "', Discription_B='" + disct + "', Image='" + imagea + "', Lower_title='" + ltitle + "',validation='" + validation + "', Offer_title = '" + title + "'  WHERE (Id= '" + id + "')";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();




                        con.Close();
                        responserecby = "edit";

                    }
                }
            }


            if (files == null)

            {

                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[coregoffer] SET Discription_A = '" + disc + "', Discription_B='" + disct + "', Lower_title='" + ltitle + "', validation='" + validation + "', Offer_title = '" + title + "'  WHERE (Id= '" + id + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();
                responserecby = "edit";

            }
            return RedirectToAction("all_offers", "admin");
        }

        [HttpPost]

        public IActionResult addexcel(List<IFormFile> files)
        {
            string gmail;

            foreach (var file in files)
            {
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    string filepath =
        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFile")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();

                    }



                    ///string constr=string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);

                    /// OleDbConnection Econ = new OleDbConnection(constr);
                    OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filepath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
                    mycon.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            // Response.Write("<br/>"+dr[0].ToString());
                            gmail = (dr[0].ToString());

                            UpdateDatabase(gmail);
                        }
                        else
                        {
                            break;
                        }



                    }
                    ///Label3.Text = "" + uploadcount + " Has Been Uploaded Successfully From " + disuploadcount + "";
                    mycon.Close();






                }
            }
            return RedirectToAction("dne", "admin");
        }
        [HttpPost]

        public IActionResult addsmsexcel(List<IFormFile> files)
        {
            string gmail;

            foreach (var file in files)
            {
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    string filepath =
        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFile")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();

                    }



                    ///string constr=string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);

                    /// OleDbConnection Econ = new OleDbConnection(constr);
                    OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filepath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
                    mycon.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            // Response.Write("<br/>"+dr[0].ToString());
                            gmail = (dr[0].ToString());

                            UpdatesmsDatabase(gmail);
                        }
                        else
                        {
                            break;
                        }



                    }
                    ///Label3.Text = "" + uploadcount + " Has Been Uploaded Successfully From " + disuploadcount + "";
                    mycon.Close();






                }
            }
            return RedirectToAction("sms", "admin");
        }

        [HttpPost]

        public IActionResult addunsubexcel(List<IFormFile> files)
        {
            string gmail;

            foreach (var file in files)
            {
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.
                    string filepath =
        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFile")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();

                    }



                    ///string constr=string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);

                    /// OleDbConnection Econ = new OleDbConnection(constr);
                    OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filepath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
                    mycon.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            // Response.Write("<br/>"+dr[0].ToString());
                            gmail = (dr[0].ToString());

                            UpdatesiteunsubDatabase(gmail);
                        }
                        else
                        {
                            break;
                        }



                    }
                    ///Label3.Text = "" + uploadcount + " Has Been Uploaded Successfully From " + disuploadcount + "";
                    mycon.Close();






                }
            }
            return RedirectToAction("siteunsub", "admin");
        }

        private void UpdateDatabase(string gmail)
        {

            disuploadcount = (Convert.ToInt32(disuploadcount) + 1).ToString(); ;
            var count = d.DneDataBase.Where(o => o.Gmail == gmail).Count();
            if (count == 0)
            {
                uploadcountt = (Convert.ToInt32(uploadcountt) + 1).ToString();
                DneDataBase t = new DneDataBase();
                t.Gmail = gmail;
                d.DneDataBase.Add(t);
                d.SaveChanges();
            }
            ////  String query = "update studentdetail set sname='" + sname1 + "', fathername='" + fname1 + "', mothername='" + mname1 + "' where rollno=" + rollno1;
            // String mycon = "Data Source=HP-PC\\SQLEXPRESS; Initial Catalog=ExcelDatabase; Integrated Security=True";
            /// SqlConnection con = new SqlConnection(mycon);
            /// con.Open();
            // SqlCommand cmd = new SqlCommand();
            // cmd.CommandText = query;
            ///  cmd.Connection = con;
            ///  cmd.ExecuteNonQuery();

        }
        private void UpdatesiteunsubDatabase(string gmail)
        {

            disuploadcount = (Convert.ToInt32(disuploadcount) + 1).ToString(); ;
            var count = d.SiteUnSubscribe.Where(o => o.Email == gmail).Count();
            if (count == 0)
            {
                uploadcountt = (Convert.ToInt32(uploadcountt) + 1).ToString();
                SiteUnSubscribe t = new SiteUnSubscribe();
                t.Email = gmail;
                d.SiteUnSubscribe.Add(t);
                d.SaveChanges();
            }
        }
        private void UpdatesmsDatabase(string gmail)
        {

            disuploadcount = (Convert.ToInt32(disuploadcount) + 1).ToString(); ;
            var count = d.SiteUnSubscribe.Where(o => o.Email == gmail).Count();
            if (count == 0)
            {
                uploadcountt = (Convert.ToInt32(uploadcountt) + 1).ToString();
                SmsDataBase t = new SmsDataBase();
                t.Gmail = gmail;
                d.SmsDataBase.Add(t);
                d.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IActionResult> edit_offerAsync(string tid, string offertype)
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
            ViewBag.offertype = offertype;
            ViewBag.editoffer = d.PathOffer.Where(o => o.PathOfferId == Convert.ToInt32(tid)).Take(1).ToList();
            {


                var client = new RestClient("https://api.eflow.team/v1/networks/reporting/entity");
                var request = new RestRequest("https://api.eflow.team/v1/networks/reporting/entity", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"timezone_id\": 90,\n  \"currency_id\": \"USD\",\n  \"from\": \"2022-11-28\",\n  \"to\": \"2022-11-30\",\n  \"columns\": [\n    {\n      \"column\": \"offer\"\n    },\n    {\n      \"column\": \"affiliate\"\n    },\n    {\n      \"column\": \"offer_status\"\n    },\n    {\n      \"column\": \"affiliate_status\"\n    }\n  ],\n  \"usm_columns\": [],\n  \"query\": {\n    \"filters\": [],\n    \"exclusions\": [],\n    \"metric_filters\": [],\n    \"user_metrics\": [],\n    \"settings\": {}\n  }\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    root responsed =
                       JsonConvert.DeserializeObject<root>(response.Content);

                    ViewBag.apiresult = responsed;

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }


            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();

                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> updated_pathoffersAsync()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
            offertype = currentoffertyperecbyy;
            int tid = Convert.ToInt32(currentidrecbyy);
            ViewBag.offertype = offertype;
            ViewBag.editoffer = d.PathOffer.Where(o => o.PathOfferId == Convert.ToInt32(tid)).Take(1).ToList();
            {


                var client = new RestClient("https://api.eflow.team/v1/networks/reporting/entity");
                var request = new RestRequest("https://api.eflow.team/v1/networks/reporting/entity", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"timezone_id\": 90,\n  \"currency_id\": \"USD\",\n  \"from\": \"2022-11-28\",\n  \"to\": \"2022-11-30\",\n  \"columns\": [\n    {\n      \"column\": \"offer\"\n    },\n    {\n      \"column\": \"affiliate\"\n    },\n    {\n      \"column\": \"offer_status\"\n    },\n    {\n      \"column\": \"affiliate_status\"\n    }\n  ],\n  \"usm_columns\": [],\n  \"query\": {\n    \"filters\": [],\n    \"exclusions\": [],\n    \"metric_filters\": [],\n    \"user_metrics\": [],\n    \"settings\": {}\n  }\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    root responsed =
                       JsonConvert.DeserializeObject<root>(response.Content);

                    ViewBag.apiresult = responsed;

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }


            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> updated_offerAsync()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
            offertype = currentoffertyperecbyy;
            int tid = Convert.ToInt32(currentidrecbyy);



            if (offertype == "walloffer")
            {



                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.OfferWall.Where(o => o.OfferWallId == Convert.ToInt32(tid)).Take(1).ToList();

            }
            if (offertype == "pathoffers")
            {



                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.PathOffer.Where(o => o.PathOfferId == Convert.ToInt32(tid)).Take(1).ToList();

            }
            if (offertype == "popffers")
            {



                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.PopUp.Where(o => o.PopUpId == Convert.ToInt32(tid)).Take(1).ToList();

            }
            ViewBag.response = responserecby;
            responserecby = " ";
            {


                var client = new RestClient("https://api.eflow.team/v1/networks/reporting/entity");
                var request = new RestRequest("https://api.eflow.team/v1/networks/reporting/entity", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"timezone_id\": 90,\n  \"currency_id\": \"USD\",\n  \"from\": \"2022-11-28\",\n  \"to\": \"2022-11-30\",\n  \"columns\": [\n    {\n      \"column\": \"offer\"\n    },\n    {\n      \"column\": \"affiliate\"\n    },\n    {\n      \"column\": \"offer_status\"\n    },\n    {\n      \"column\": \"affiliate_status\"\n    }\n  ],\n  \"usm_columns\": [],\n  \"query\": {\n    \"filters\": [],\n    \"exclusions\": [],\n    \"metric_filters\": [],\n    \"user_metrics\": [],\n    \"settings\": {}\n  }\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    root responsed =
                       JsonConvert.DeserializeObject<root>(response.Content);

                    ViewBag.apiresult = responsed;

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }


            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }
                }
            }

            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> update_offerAsync(string tid, string offertype)
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();

            if (offertype == "walloffer")
            {



                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.OfferWall.Where(o => o.OfferWallId == Convert.ToInt32(tid)).Take(1).ToList();

            }
            if (offertype == "pathoffers")
            {



                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.PathOffer.Where(o => o.PathOfferId == Convert.ToInt32(tid)).Take(1).ToList();

            }
            if (offertype == "popffers")
            {



                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.PopUp.Where(o => o.PopUpId == Convert.ToInt32(tid)).Take(1).ToList();

            }

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }
                }
            }
            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> update_offersAsync(string tid, string offertype, string click)
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
            if (offertype == "coreg")
            {
                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.CoregOffer.Where(o => o.CoregOfferId == Convert.ToInt32(tid)).Take(1).ToList();
            }
            ViewBag.click = click;

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }
                }
            }
            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }

            return View();
        }

        public async Task<IActionResult> updated_offersAsync()
        {
            string offertype = currentoffertyperecbyy;
            int tid = Convert.ToInt32(currentidrecbyy);
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
            if (offertype == "coreg")
            {
                ViewBag.offertype = offertype;
                ViewBag.editoffer = d.CoregOffer.Where(o => o.CoregOfferId == Convert.ToInt32(tid)).Take(1).ToList();
            }
            ViewBag.response = responserecby;
            responserecby = " ";
       

         

            using (var httpClient = new HttpClient())
            {



                string url = $"https://api.eflow.team/v1/networks/advertisers";




                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage response = await httpClient.GetAsync(url);


                if (response.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var result = await response.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(result.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<advertisers>> responsed =
                     JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                        ViewBag.apiresult = responsed.affiliates;

                        List<advertisers> ee = responsed.advertisers.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresult = ee.ToList();


                    }

                }
            }
            using (var httpClient = new HttpClient())
            {



                ////Affeliates
                ///
                string urll = $"https://api.eflow.team/v1/networks/affiliates";
                ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                HttpClient clients = new HttpClient();

                httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                if (responsedd.StatusCode == HttpStatusCode.OK)
                {



                    /// var result = await response.Content.ReadAsStringAsync();
                    var resultss = await responsedd.Content.ReadAsStringAsync();


                    if (string.IsNullOrEmpty(resultss.ToString()))
                    {
                        return Ok("success");
                    }
                    else
                    {


                        ResponseBackk<List<affiliates>> responses =
                     JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                        evelflow e = new evelflow();

                        //affiliates = responsed.affiliates.ToList() ;
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                        ViewBag.apiresultss = responses.affiliates;

                        List<affiliates> ee = responses.affiliates.ToList();

                        /// var apiresult =responsed.affiliates.ToList();
                        var apiresultsss = ee.ToList();


                    }
                }
            }

            {

                var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //List<everflowoffertable> ee = new List<everflowoffertable>();

                    //ResponseBackk<List<everflowoffertable>> responses =
                    // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                    everflowoffertable responsed =
                     JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                    ViewBag.offertable = responsed.offers.ToList();

                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }


            return View();
        }
        [HttpGet]
        public IActionResult edit_pathoffers()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            string tid = (Request.Query["tid"]).ToString();
            ViewBag.path = d.PathOffer.Where(o => o.OfferName == tid).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult edit_coregoffers()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            string tid = (Request.Query["tid"]).ToString();
            ViewBag.coreg = d.CoregOffer.Where(o => o.CoregOfferId == Convert.ToInt32(tid)).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult edit_popup()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            string tid = (Request.Query["tid"]).ToString();
            ViewBag.popup = d.PopUp.Where(o => o.PopUpId == Convert.ToInt32(tid)).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult edit_offerwall()
        {
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            string tid = (Request.Query["tid"]).ToString();
            ViewBag.offerwall = d.OfferWall.Where(o => o.OfferWallId == Convert.ToInt32(tid)).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Deleteconsumer()
        {
            string tid = (Request.Query["tid"]).ToString();
            var del = d.Register.Where(o => o.RegisterId == Convert.ToInt32(tid)).FirstOrDefault();
            d.Register.Remove(del);
            d.SaveChanges();
            responserecby = "Delete";
            return RedirectToAction("consumer", "admin");
        }
        [HttpPost]
        public IActionResult setpriority(string offertype, List<string> priority)
        {
            int prr=0;
            foreach (var item in priority)
            {
                {

                    prr++;
                   
                        {

                            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                            con.Open();
                            string str = @"UPDATE [dbo].[offerwall] SET Priority = '" + prr + "'  WHERE (Id= '" + item + "')";

                            SqlCommand cmd = new SqlCommand(str, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                           

                            responserecby = "edit";
                        }
                    }
                }
            return RedirectToAction("all_offers", "admin");
        }
        [HttpPost]
        public IActionResult setpathpriority(string offertype, List<string> priority)
        {
            int prr = 0;
            foreach (var item in priority)
            {
                {

                    prr++;

                    {

                        SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                        con.Open();
                        string str = @"UPDATE [dbo].[PathOffer] SET Priority = '" + prr + "'  WHERE (Id= '" + item + "')";

                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        con.Close();


                        responserecby = "edit";
                    }
                }
            }
            return RedirectToAction("all_offers", "admin");
        }
        [HttpPost]
    public IActionResult Deletedne(string offertype, List<string> archiveitem)
        {
           
            foreach (var i in archiveitem)
            {

                var del = d.DneDataBase.Where(o => o.DneDataBaseId == Convert.ToInt32(i)).FirstOrDefault();
            d.DneDataBase.Remove(del);
            d.SaveChanges();
            responserecby = "Delete";
            //return RedirectToAction("dne", "admin");
          
        }
            return Ok();
        }
        [HttpPost]
        public IActionResult Deleteunsub(string offertype, List<string> archiveitem)
        {

            foreach (var i in archiveitem)
            {

                var del = d.SiteUnSubscribe.Where(o => o.SiteUnSubscribeId == Convert.ToInt32(i)).FirstOrDefault();
                d.SiteUnSubscribe.Remove(del);
                d.SaveChanges();
                responserecby = "Delete";
                //return RedirectToAction("dne", "admin");

            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Deletesms(string offertype, List<string> archiveitem)
        {

            foreach (var i in archiveitem)
            {

                var del = d.SmsDataBase.Where(o => o.SmsDataBaseId == Convert.ToInt32(i)).FirstOrDefault();
                d.SmsDataBase.Remove(del);
                d.SaveChanges();
                responserecby = "Delete";
                //return RedirectToAction("dne", "admin");

            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Deleteccpaoffer(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
           
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].CcpaOptOut SET archive = 'archive'  WHERE (Id = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
           
            return Ok();
            }
        [HttpPost]
        public IActionResult Deleteconumeroffer(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "afterskipoffers")
            {
                foreach (var i in archiveitem)
                {

                
                    var select = d.PathOffer.Where(o => o.PathOfferId == Convert.ToInt32(i)).FirstOrDefault();
                    d.PathOffer.Remove(select);
                    d.SaveChanges();

                }
            }
            if (offertype == "offerwall")
            {
                foreach (var i in archiveitem)
                {

                    

                    var select = d.OfferWall.Where(o => o.OfferWallId == Convert.ToInt32(i)).FirstOrDefault();
                    d.OfferWall.Remove(select);
                    d.SaveChanges();

                }
            }
            if (offertype == "QaOffers")
            {
                foreach (var i in archiveitem)
                {


                    var select = d.QaOffer.Where(o => o.QaOfferId == Convert.ToInt32(i)).FirstOrDefault();
                    d.QaOffer.Remove(select);
                    d.SaveChanges();


                }
            }
            if (offertype == "coreg")
            {


                foreach (var i in archiveitem)
                {

                    int idd =Convert.ToInt32(i);
                    var select = d.CoregOffer.Where(o => o.CoregOfferId == idd).FirstOrDefault();
                    d.CoregOffer.Remove(select);
                    d.SaveChanges();
                }
            }

            if (offertype == "popups")
            {


                foreach (var i in archiveitem)
                {

                    int idd = Convert.ToInt32(i);
                    var select = d.PopUp.Where(o => o.PopUpId == idd).FirstOrDefault();
                    d.PopUp.Remove(select);
                    d.SaveChanges();
                }
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult restoreconumeroffer(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "afterskipoffers")
            {
                foreach (var i in archiveitem)
                {

                    var data = d.PathOffer.Find(Convert.ToInt32(i));
                    data.Archive = "active";
                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();
                    //SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    //con.Open();

                    //string str = @"UPDATE [dbo].[afterskipoffers] SET archive = 'active'  WHERE (Id = '" + i + "')";

                    //SqlCommand cmd = new SqlCommand(str, con);
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                }
            }
            if (offertype == "offerwall")
            {
                foreach (var i in archiveitem)
                {
                    var data = d.OfferWall.Find(Convert.ToInt32(i));
                    data.Archive = "active";
                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();

                    //SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    //con.Open();

                    //string str = @"UPDATE [dbo].[offerwall] SET archive = 'active'   WHERE (Id = '" + i + "')";

                    //SqlCommand cmd = new SqlCommand(str, con);
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                }
            }
            if (offertype == "coreg")
            {


                foreach (var i in archiveitem)
                {
                    var data = d.CoregOffer.Find(Convert.ToInt32(i));
                    data.Archive = "active";
                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();

                    //SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    //con.Open();

                    //string str = @"UPDATE [dbo].coregoffer SET archive = 'active'   WHERE (Id = '" + i + "')";

                    //SqlCommand cmd = new SqlCommand(str, con);
                    //cmd.ExecuteNonQuery();
                    //con.Close();


                }
            }
            if (offertype == "popups")
            {


                foreach (var i in archiveitem)
                {
                    var data = d.PopUp.Find(Convert.ToInt32(i));
                    data.Archive = "active";
                    d.Entry(data).State = EntityState.Modified;
                    d.SaveChanges();
                    //SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    //con.Open();

                    //string str = @"UPDATE [dbo].popups SET archive = 'active'   WHERE (Id = '" + i + "')";

                    //SqlCommand cmd = new SqlCommand(str, con);
                    //cmd.ExecuteNonQuery();
                    //con.Close();



                }
            }


            return Ok();
        }
        [HttpPost]
        public IActionResult DeleteQaOffer(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
          
                foreach (var i in archiveitem)
                {


                    var select = d.QaOffer.Where(o => o.QaOfferId == Convert.ToInt32(i)).FirstOrDefault();
                    d.QaOffer.Remove(select);
                    d.SaveChanges();

                
            }
            return Ok();
        }

            [HttpPost]
        public IActionResult archieveQaOffer(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
          
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[QaOffer] SET Archive = 'archive'  WHERE (QaOfferId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            return Ok();

        }
        [HttpPost]
        public IActionResult restoreconumeroffers(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "afterskipoffers")
            {
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[PathOffer] SET archive = ' '  WHERE (PathOfferId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "offerwall")
            {
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[OfferWall]  SET Archive = ' '  WHERE (OfferWallId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "QaOffers")
            {
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[QaOffer] SET archive = ' '  WHERE (QaOfferId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "coreg")
            {


                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[CoregOffer] SET Archive = ' '  WHERE (CoregOfferId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "popups")
            {


                foreach (var i in archiveitem)
                {
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].PopUp SET Archive = ' '  WHERE (PopUpId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }


            return Ok();
        }
    
            [HttpPost]
        public IActionResult archieveconumeroffer(string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
            if (offertype== "afterskipoffers")
            {
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[PathOffer] SET Archive = 'archive'  WHERE (PathOfferId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "offerwall")
            {
                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[OfferWall] SET Archive = 'archive'  WHERE (OfferWallId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "coreg")
            {


                foreach (var i in archiveitem)
                {

                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].[CoregOffer] SET Archive = 'archive'  WHERE (CoregOfferId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            if (offertype == "popups")
            {


                foreach (var i in archiveitem)
                {
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();

                    string str = @"UPDATE [dbo].PopUp SET Archive = 'archive'  WHERE (PopUpId = '" + i + "')";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();


                  
                }
            }


            return Ok();
        }

        [HttpPost]
        public IActionResult Deleteoffer( string offertype, List<string> archiveitem)
        {
            ///string tid = (Request.Query["tid"]).ToString();
            //var item = d.OfferWall.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "offerwall")
          
            {

                foreach (var i in archiveitem)
                {
              
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();

                string str = @"UPDATE [dbo].[OfferWall] SET Archive = 'archive'  WHERE (OfferWallId = '" + i + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            }



           //// var items = d.CoregOffer.Where(o => o.Offer_title == tid).Count();
            if (offertype == "coregg")

            {

                foreach (var i in archiveitem)
                {
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].CoregOffer SET Archive = 'archive'  WHERE (CoregOfferId = '" + i + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }
            }
            ///var itemss = d.tcpaoffers.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "tcpaoffers")

            {

                foreach (var i in archiveitem)
                { 
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].TcpaOffers SET Archive = 'archive'  WHERE (TcpaOffersId = '" + i + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }
            }


           /// var itema = d.offers.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "offers")

            {
                foreach (var i in archiveitem)
                { 
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].Offers SET Archive = 'archive'  WHERE (OffersId = '" + i + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }
            }

           /// var itemskip = d.PathOffer.Where(o => o.Offer_Name == tid).Count();
            if (offertype == "afterskipoffers")

            {

                foreach (var i in archiveitem)
                { 
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[PathOffer] SET Archive = 'archive'  WHERE (PathOfferId = '" + i + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }
            }


           /// var itempop = d.PopUp.Where(o => o.redirect_link == tid).Count();
            if (offertype == "popups")

            {

                foreach (var i in archiveitem)
                { 
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].PopUp SET Archive = 'archive'  WHERE (PopUpId = '" + i + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }
            }




            responserecby = "archive";



            return Ok();
        }
        [HttpGet]
        public IActionResult switchs()
        {
            string tid = Request.Query["tid"].ToString();
            var check = d.CoregOffer.Where(o => o.CoregOfferId == Convert.ToInt32(tid)).ToList();

          ////  string switchs = Request.Form["switch"].ToString();
            foreach (var i in check)
            {
                ViewBag.switchs = i.Switch;
                if (i.Switch == "Off")
                {
                   // ViewBag.switchss = "On";
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();


                    string str = @"UPDATE [dbo].[CoregOffer] SET Switch = 'On' Where(CoregOfferId='" + tid+"') ";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    responserecby = "On";
                   /// return RedirectToAction("all_offers", "admin");
                }
                else
                {
                  ///  ViewBag.switchss = "Off";
                    SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                    con.Open();


                    string str = @"UPDATE [dbo].[CoregOffer] SET Switch = 'Off' Where(CoregOfferId='" + tid + "') ";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    responserecby = "Off";
                    /// return RedirectToAction("all_offers", "admin");
                }
            }
            return RedirectToAction("all_offers", "admin");

        }

        [HttpGet]
        public IActionResult restoreoffer()
        {
            string tid = (Request.Query["tid"]).ToString();
            var item = d.OfferWall.Where(o => o.OfferName == tid).Count();
            if (item > 0)

            {


                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].OfferWall SET Archive = '"+string.Empty+"'  WHERE (OfferName = '" + tid + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }



            var items = d.CoregOffer.Where(o => o.OfferTitle == tid).Count();
            if (items > 0)

            {


                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[CoregOffer] SET Archive = '"+string.Empty+"'  WHERE (OfferTitle = '" + tid + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }
            var itemss = d.TcpaOffers.Where(o => o.OfferName == tid).Count();
            if (itemss > 0)

            {


                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].TcpaOffers SET Archive = '" + string.Empty + "'  WHERE (OfferName = '" + tid + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }


            var itema = d.Offers.Where(o => o.OfferName == tid).Count();
            if (itema > 0)

            {


                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].Offers SET Archive = '" + string.Empty + "'  WHERE (OfferName = '" + tid + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }



            var itemskip = d.PathOffer.Where(o => o.OfferName == tid).Count();
            if (itemskip > 0)

            {


                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[PathOffer] SET Archive = '" + string.Empty + "'  WHERE (OfferName = '" + tid + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }

            var itempop = d.PopUp.Where(o => o.RedirectLink == tid).Count();
            if (itempop > 0)

            {


                SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
                con.Open();


                string str = @"UPDATE [dbo].[popups] SET archive = '"+string.Empty+"'  WHERE (redirect_link = '" + tid + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();




                con.Close();

            }




            responserecby = "restore";


               return RedirectToAction("all_offers", "admin");
        }
        [HttpGet]
        public IActionResult getccpaeoffer(string id, string offertype)
        {
                var find = d.CcpaOptOut.Where(o => o.CcpaOptOutId == Convert.ToInt32(id)).ToList();
                return Json(find);
  
        }
        [HttpGet]
        public IActionResult getconsumereoffer(string id, string offertype)
        {
            var find = d.Register.Where(o => o.RegisterId == Convert.ToInt32(id)).ToList();
            return Json(find);

        }
        [HttpGet]
        public IActionResult getmoreoffer(string id, string offertype)
        {
            
            if (offertype == "offerwall")
            {


               var find = d.OfferWall.Where(o => o.OfferWallId == Convert.ToInt32(id)).ToList();
                return Json(find);

            }
            if (offertype == "coreg")
            {


                var find = d.CoregOffer.Where(o => o.CoregOfferId == Convert.ToInt32(id)).ToList();

                return Json(find);
            }
            if (offertype == "pathoffers")
            {


                var find = d.PathOffer.Where(o => o.PathOfferId == Convert.ToInt32(id)).ToList();

                return Json(find);
            }
            else
            {

                var find = d.PopUp.Where(o => o.PopUpId == Convert.ToInt32(id)).ToList();

                return Json(find);
            }
        }
        [HttpGet]
        public IActionResult geteverflowreport(string id)
        {
            


                var client = new RestClient("https://api.eflow.team/v1/networks/reporting/entity");
                var request = new RestRequest("https://api.eflow.team/v1/networks/reporting/entity", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            request.AddParameter("application/json", "{\n  \"timezone_id\": 90,\n  \"currency_id\": \"USD\",\n  \"from\": \""+date+ "\",\n  \"to\": \""+ date + "\",\n  \"columns\": [\n    {\n      \"column\": \"offer\"\n    },\n    {\n      \"column\": \"affiliate\"\n    },\n    {\n      \"column\": \"offer_status\"\n    },\n    {\n      \"column\": \"affiliate_status\"\n    }\n  ],\n  \"usm_columns\": [],\n  \"query\": {\n    \"filters\": [\n      {\n        \"resource_type\": \"offer\",\n        \"filter_id_value\": \""+id+"\"\n      }\n    ],\n    \"exclusions\": [],\n    \"metric_filters\": [],\n    \"user_metrics\": [],\n    \"settings\": {}\n  }\n}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
             

                    root responsed =
                       JsonConvert.DeserializeObject<root>(response.Content);
                    ViewBag.offertable = responsed.table.ToList();
                    return Json(ViewBag.offertable);
  
        }
        public IActionResult archieve_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.Where(o => o.Archive == "archive" && o.Website == host).ToList();
                //ViewBag.coregoffer = d.CoregOffer.Take(1);
                ViewBag.offerwall = d.OfferWall.Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                ViewBag.popffers = d.PopUp.Where(o => o.Archive == "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();
                ViewBag.QaOffers = d.QaOffer.Where(o => o.Archive == "archive" && o.Website == host).ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public async Task<IActionResult> everflow_offerAsync()

        {
            var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager"); ;
            var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
            request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //List<everflowoffertable> ee = new List<everflowoffertable>();

                //ResponseBackk<List<everflowoffertable>> responses =
                // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                everflowoffertable responsed =
                 JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                ViewBag.offertable = responsed.offers.ToList();

            }
            else
            {
                Console.WriteLine("Failed");
            }
            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
            return View();
        
        }
    
        public async Task<IActionResult> all_offersAsync()
        {
            string host = HttpContext.Request.Host.Value;
            /// response = "saved";
            ViewBag.response = responserecby;
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o=> o.CoregOfferId).Where(o => o.Archive != "archive" && o.Website == host).ToList();
                ViewBag.coregoffer = d.CoregOffer.OrderByDescending(o => o.CoregOfferId ).Where(o => o.Website == host).Take(1);
                ViewBag.offerwall = d.OfferWall.OrderBy(o => o.Priority).Where(o => o.Archive != "archive" && o.Website == host).ToList();
                //ViewBag.testofferwall = d.testofferwall.OrderBy(o => o.Priority).Where(o => o.Archive != "archive").ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.OrderBy(o => o.Priority).Where(o => o.Archive != "archive" && o.Website == host).ToList();
                ViewBag.qa = d.CoregOffer.Where(o => o.Website == host).Take(1).ToList();
                ViewBag.pop = d.PopUp.Where(o => o.Website == host).Take(1).ToList();
                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;



                //createofferrs

             
                ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
             


                {

                    var client = new RestClient("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager");
                    var request = new RestRequest("https://api.eflow.team/v1/networks/offerstable?page=1&page_size=100&order_field=network_advertiser_name&order_direction=asc&relationship=ruleset&relationship=tracking_domain&relationship=account_manager&relationship=sales_manager", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("x-eflow-api-key", "FOAQHMGjRlO0Ya3urtgCKA");
                    request.AddParameter("application/json", "{\n  \"filters\": {\n    \"offer_status\": \"active\"\n  },\n  \"search_terms\": []\n}", ParameterType.RequestBody);
                    RestResponse response = client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                       //List<everflowoffertable> ee = new List<everflowoffertable>();

                        //ResponseBackk<List<everflowoffertable>> responses =
                        // JsonConvert.DeserializeObject<ResponseBackk<List<everflowoffertable>>>(response.Content);
                        everflowoffertable responsed =
                         JsonConvert.DeserializeObject<everflowoffertable>(response.Content);

                        ViewBag.offertable = responsed.offers.ToList() ;

                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }

                using (var httpClient = new HttpClient())
                {



                    string url = $"https://api.eflow.team/v1/networks/advertisers";




                    HttpClient client = new HttpClient();

                    httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();

                    httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                    HttpResponseMessage response = await httpClient.GetAsync(url);


                    if (response.StatusCode == HttpStatusCode.OK)
                    {



                        /// var result = await response.Content.ReadAsStringAsync();
                        var result = await response.Content.ReadAsStringAsync();


                        if (string.IsNullOrEmpty(result.ToString()))
                        {
                            return Ok("success");
                        }
                        else
                        {


                            ResponseBackk<List<advertisers>> responsed =
                         JsonConvert.DeserializeObject<ResponseBackk<List<advertisers>>>(result);
                            evelflow e = new evelflow();

                            //affiliates = responsed.affiliates.ToList() ;
                            JsonSerializerSettings settings = new JsonSerializerSettings();
                            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                            var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(result, settings);

                            ViewBag.apiresult = responsed.affiliates;

                            List<advertisers> ee = responsed.advertisers.ToList();

                            /// var apiresult =responsed.affiliates.ToList();
                            var apiresult = ee.ToList();


                        }

                    }
                }
                using (var httpClient = new HttpClient())
                {



                    ////Affeliates
                    ///
                    string urll = $"https://api.eflow.team/v1/networks/affiliates";
                    ///string url = $"https://api.eflow.team/v1/networks/advertisers";



                    HttpClient clients = new HttpClient();

                    httpClient.BaseAddress = new Uri("https://api.eflow.team/v1/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();

                    httpClient.DefaultRequestHeaders.Add("X-Eflow-API-Key", "FOAQHMGjRlO0Ya3urtgCKA");
                    HttpResponseMessage responsedd = await httpClient.GetAsync(urll);


                    if (responsedd.StatusCode == HttpStatusCode.OK)
                    {



                        /// var result = await response.Content.ReadAsStringAsync();
                        var resultss = await responsedd.Content.ReadAsStringAsync();


                        if (string.IsNullOrEmpty(resultss.ToString()))
                        {
                            return Ok("success");
                        }
                        else
                        {


                            ResponseBackk<List<affiliates>> responses =
                         JsonConvert.DeserializeObject<ResponseBackk<List<affiliates>>>(resultss);
                            evelflow e = new evelflow();

                            //affiliates = responsed.affiliates.ToList() ;
                            JsonSerializerSettings settings = new JsonSerializerSettings();
                            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                            var outObject = JsonConvert.DeserializeObject<ResponseBackk<List<evelflow>>>(resultss, settings);

                            ViewBag.apiresultss = responses.affiliates;

                            List<affiliates> ee = responses.affiliates.ToList();

                            /// var apiresult =responsed.affiliates.ToList();
                            var apiresultsss = ee.ToList();


                        }

                    }
                }






                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }


        
        }
        public IActionResult coreg_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive != "archive").ToList();
                ViewBag.coregoffer = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive != "archive").ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive").ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive != "archive").ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult exit_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive != "archive").ToList();
                ViewBag.coregoffer = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive != "archive").ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive").ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive != "archive").ToList();

                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult pop_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;


            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive != "archive").ToList();
                ViewBag.coregoffer = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive != "archive").ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive").ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive != "archive").ToList();


                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult wall_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;


            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive != "archive").ToList();
                ViewBag.coregoffer = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive != "archive").ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive").ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive != "archive").ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult path_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive != "archive").ToList();
                ViewBag.coregoffer = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive != "archive").ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive").ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive != "archive").ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult archiveoffers()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.OrderByDescending(o => o.AdminLoginId).Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive == "archive").ToList();
                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive == "archive").ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive == "archive").ToList();
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive == "archive").ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
         

         
        }


        public IActionResult archieve_coreg_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                //ViewBag.coregoffer = d.CoregOffer.Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();
                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult archieve_exit_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                //ViewBag.coregoffer = d.CoregOffer.Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult archieve_pop_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;


            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                //ViewBag.coregoffer = d.CoregOffer.Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult archieve_wall_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;


            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                //ViewBag.coregoffer = d.CoregOffer.Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult archieve_path_offers()
        {
            /// response = "saved";
            ViewBag.response = responserecby;

            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.coregoffers = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                //ViewBag.coregoffer = d.CoregOffer.Take(1);
                ViewBag.offerwall = d.OfferWall.OrderByDescending(o => o.OfferWallId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                ViewBag.popffers = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive == "archive" && o.Website == host).ToList();
                ViewBag.pathoffers = d.PathOffer.OrderByDescending(o => o.PathOfferId).Where(o => o.Archive == "archive" && o.Website == host).OrderBy(o => o.Priority).ToList();

                //foreach (var i in ViewBag.coregoffer)
                //{
                //    ViewBag.switchs = i.switchs;
                //    if (ViewBag.switchs=="Off")
                //    {
                //        ViewBag.switchss = "On";
                //    }
                //    else
                //    {
                //        ViewBag.switchss = "Off";
                //    }
                //}
                responserecby = string.Empty;
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }



        }
        public IActionResult offerwall()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.catagory = d.OfferCategory.Select(x => x.Category).Distinct().ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }
        public IActionResult popup()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }
        public IActionResult  ccpa()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.ccpa = d.CcpaOptOut.Where(o=> o.Archive==" " || o.Archive==null).ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }

        }
        public IActionResult siteunsub()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.site = d.SiteUnSubscribe.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
           
        }
        [HttpPost]
        public IActionResult addsms(string gmail,string phone)
        {
            SmsDataBase s = new SmsDataBase();
            s.Gmail = gmail;
            s.Phone = phone;
            d.SmsDataBase.Add(s);
            d.SaveChanges();
            return Ok();

        }
        [HttpPost]
        public IActionResult addunsubscribe(string gmail)
        {
            SiteUnSubscribe s = new SiteUnSubscribe();
            s.Email = gmail;
            d.SiteUnSubscribe.Add(s);
            d.SaveChanges();
            return Ok();

        }
        public IActionResult tcpa()
        {
            if (urecby != null)
            {
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.tcpadisc = d.TcpaOffers.OrderByDescending(o => o.TcpaOffersId).Where(o => o.Archive == string.Empty || o.Archive == null).Take(1).ToList();

                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
            //ViewBag.offers = d.offers.OrderByDescending(o => o.Id).Take(5).ToList();
           
        }
        public IActionResult disclouser()
        {
            if (urecby != null)
            {
                string host = HttpContext.Request.Host.Value;
                ViewBag.sites = d.AdminLogin.Where(o => o.UserName == urecby).ToList();
                ViewBag.tcpadisc = d.DisclosureText.OrderByDescending(o => o.DisclosureTextId).Where(o => o.Archive == string.Empty || o.Archive == null && o.Website == host).Take(1).ToList();

                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
            //ViewBag.offers = d.offers.OrderByDescending(o => o.Id).Take(5).ToList();

        }
        [HttpPost]
        public IActionResult submitdisclouser(string id, string first, string second, string third, string fourth)
        {
            var data = d.DisclosureText.Find(Convert.ToInt32(id));
            data.First = first;
            data.Second = second;
            data.Third = third;
            data.Fourth = fourth;

            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return RedirectToAction("disclouser", "admin");
        }
        [HttpPost]
 

        public IActionResult addprocess(List<IFormFile> files)
        {
            AppDBContext d = new AppDBContext();


                if (files != null)
                {
                    //    for (int i = 0; i <= files.Count; i++)
                    //{ 
                    foreach (var file in files)
                    {
                        {
                            //Getting FileName
                            var fileName = Path.GetFileName(file.FileName);

                            //Assigning Unique Filename (Guid)
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                            //Getting file Extension
                            var fileExtension = Path.GetExtension(fileName);

                            // concatenating  FileName + FileExtension
                            var newFileName = String.Concat(myUniqueFileName, fileExtension);

                            // Combines two strings into a path.
                            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                            using (FileStream fs = System.IO.File.Create(filepath))
                            {
                                file.CopyTo(fs);
                                fs.Flush();

                            }
                            string redirectlink = Request.Form["redirectlink"].ToString();
                            string name = Request.Form["name"].ToString();
                            string imagea = newFileName.ToString();
                        Offers of = new Offers();
                        of.Image = imagea;
                        of.OfferName = name;
                        of.RedirectLink = redirectlink;
                        of.Date = DateTime.Now.ToShortDateString();
                        d.Offers.Add(of);
                        d.SaveChanges();

                        responserecby = "saved";
                        return RedirectToAction("dashboard", "admin");
                    }
                  
    }
}
            return View();
}



        [HttpPost]


        public IActionResult addtcpa()
        {
            AppDBContext d = new AppDBContext();

            string id = Request.Form["id"].ToString();
            string description = Request.Form["redirectlink"].ToString();
                        string name = Request.Form["name"].ToString();
                        string bulletpoint = Request.Form["bulletpoint"].ToString();


            SqlConnection con = new SqlConnection(DecHelper.ConnectionString);
            con.Open();


            string str = @"UPDATE [dbo].[tcpaoffers] SET Offer_Name = '" + name + "',description='" + description + "',bulletpoint='" + bulletpoint + "',date='" + DateTime.Now.ToString("MM/dd/yyyy") + "'  WHERE (Id = '" + id + "')";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();




            con.Close();



            //           /// string imagea = newFileName.ToString();
            //           tcpaoffers of = new tcpaoffers();
            ////of.Image = imagea;
            //of.Offer_Name = name;
            ////of.redirect_link = redirectlink;
            //of.date = redirectlink;
            //            d.tcpaoffers.Add(of);
            //            d.SaveChanges();

            responserecby = "saved";
            return RedirectToAction("tcpa", "admin");
            
    
        }
       

        [HttpPost]




        public IActionResult addpopup(List<IFormFile> files)
        {
            AppDBContext d = new AppDBContext();

            string redirectlink = Request.Form["redirectlink"].ToString();
            string aid = Request.Form["aid"].ToString();
            string leadcapamount = Request.Form["leadcapamount"].ToString();
            string leadcapduration = Request.Form["leadcapduration"].ToString();
            string budgetamount = Request.Form["budgetamount"].ToString();
            string budgetduration = Request.Form["budgetduration"].ToString();
            string offerid = Request.Form["offerid"].ToString();
            PopUp of = new PopUp();
          
            of.RedirectLink = redirectlink;
            of.AffliateId = aid;
            of.Budget = budgetamount;
            of.BudgetDuration = budgetduration;
            of.LeadCap = leadcapamount;
            of.LeadCapDuration = leadcapduration;
            of.OfferId = offerid;

            of.Date = DateTime.Now.ToShortDateString();
            d.PopUp.Add(of);
            d.SaveChanges();
            responserecby = "saved";

            return RedirectToAction("all_offers", "admin");


        }

        [HttpPost]


        public IActionResult addofferwall(List<IFormFile> files , List<string> excludestates, List<string> encludestates)
        {
            AppDBContext d = new AppDBContext();


            if (files != null)
            {


                //    for (int i = 0; i <= files.Count; i++)
                //{ 
                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }
                        string redirectlink = Request.Form["redirectlink"].ToString();
                        string aid = Request.Form["aid"].ToString();
                        string offerid = Request.Form["offerid"].ToString();
                        string leadcapamount = Request.Form["leadcapamount"].ToString();
                        string leadcapduration = Request.Form["leadcapduration"].ToString();
                        string budgetamount = Request.Form["budgetamount"].ToString();
                        string budgetduration = Request.Form["budgetduration"].ToString();
                        string name = Request.Form["name"].ToString();
                        string disc = Request.Form["disc"].ToString();
                        string imagea = newFileName.ToString();
                       OfferWall of = new OfferWall();
                        of.Image = imagea;
                        of.OfferName = name;
                        of.AffliateId = aid;
                        of.Budget = budgetamount;
                        of.BudgetDuration = budgetduration;
                        of.LeadCap = leadcapamount;
                        of.LeadCapDuration = leadcapduration;

                        of.RedirectLink = redirectlink;
                        of.Description = disc;
                        of.OfferId = offerid;
                        of.Date = DateTime.Now.ToShortDateString();
                        d.OfferWall.Add(of);
                        d.SaveChanges();
                        responserecby = "saved";

                      
                    }
                   


                }
               
                string offersid = Request.Form["offerid"].ToString();
                string statescheck = Request.Form["statescheck"].ToString();
                if (statescheck == "default")
                {
                  
                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                     
                        o.Status = "default";
                        o.OfferType = "walloffer";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                   
                }
                if (statescheck== "Exclud")
                {
                    foreach (var excludestate in excludestates)
                    {

                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                        o.States = excludestate;
                        o.Status = "Exclud";
                        o.OfferType = "walloffer";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                    }
            }
                if (statescheck == "Enclude")
                {
                    foreach (var encludestate in encludestates)
                    {

                        OfferStates o = new OfferStates();
                        o.OfferId = offersid;
                        o.States = encludestate;
                        o.Status = "Enclude";
                        o.OfferType = "walloffer";
                        d.OfferStates.Add(o);
                        d.SaveChanges();
                    }
                }
                return RedirectToAction("all_offers", "admin");
            }
                return View();
        }
    }
}






