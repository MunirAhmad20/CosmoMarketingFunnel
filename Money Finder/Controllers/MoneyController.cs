using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Money_Finder.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Money_Finder.Controllers
{

    public class MoneyController : Controller
    {

        public static string tid;
        public static string recbytid
        {
            get { return tid; }
            set { tid = value; }

        }
        public static string zip;
        public static string recbyzip
        {
            get { return zip; }
            set { zip = value; }

        }
        public static string f_name;
        public static string recbyf_name
        {
            get { return f_name; }
            set { f_name = value; }

        }
        public static string variablepassf_name;
        public static string recbyf_namevariablepassf_name
        {
            get { return variablepassf_name; }
            set { variablepassf_name = value; }

        }
        public static string variablepassl_name;
        public static string recbyf_namevariablepassl_name
        {
            get { return variablepassl_name; }
            set { variablepassl_name = value; }

        }
        public static string fname;
        public static string recbyfname
        {
            get { return fname; }
            set { fname = value; }

        }
        public static string lname;
        public static string recbylname
        {
            get { return lname; }
            set { lname = value; }

        }
        public static string l_name;
        public static string recbyl_name
        {
            get { return l_name; }
            set { l_name = value; }

        }
        public static string email;
        public static string recbyemail
        {
            get { return email; }
            set { email = value; }

        }
        public static string validation;
        public static string recbyvalidation
        {
            get { return validation; }
            set { validation = value; }

        }
        public static string states;
        public static string recbyystats
        {
            get { return states; }
            set { states = value; }

        }
        public static string offerid;
        public static string recbyyofferid
        {
            get { return offerid; }
            set { offerid = value; }

        }



        public static string offercount;
        public static string recbyyoffercount
        {
            get { return offercount; }
            set { offercount = value; }

        }
        public static string phone;
        public static string recbyyphone
        {
            get { return phone; }
            set { phone = value; }

        }
        AppDBContext d = new AppDBContext();


        public class FileAuthorizationMiddleware
        {
            private readonly RequestDelegate _next;

            public FileAuthorizationMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {

                if (context.Request.Path.Value.EndsWith(".xlsx") /*|| context.Request.Path.Value.EndsWith(".png") || context.Request.Path.Value.EndsWith(".jpg")|| context.Request.Path.Value.EndsWith(".jpeg")*/)
                {
                    // Check if the user is authorized to access the file

                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return;

                }

                await _next(context);
            }
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult testmodal()
        {

            ViewBag.sites = d.AdminLogin.Where(o => o.UserName == "Admin").ToList();


            ViewBag.user = d.AdminLogin.ToList();
            return View();
        }
        public IActionResult everflowtest()
        {

            return View();
        }
        public IActionResult ping()
        {

            return View();
        }
        public async Task<IActionResult> short_formAsync()
        {
            //ViewBag.githash = GetGitHash();
            RecordArrival();
            string tid = Request.Query["tid"].ToString();
            string source_one = Request.Query["sourceone"].ToString();
            string firstname = Request.Query["firstname"].ToString();
            string first_name = Request.Query["first_name"].ToString();
            string lastname = Request.Query["lastname"].ToString();
            string last_name = Request.Query["last_name"].ToString();
            string address = Request.Query["address"].ToString();
            string email = Request.Query["email"].ToString();
            string zip = Request.Query["zip"].ToString();
            string phonea = Request.Query["phonea"].ToString();
            string phoneb = Request.Query["phoneb"].ToString();
            string phonec = Request.Query["phonec"].ToString();
            string City = Request.Query["city"].ToString();
            string Age = Request.Query["age"].ToString();
            string DOB = Request.Query["dob"].ToString();
            string Gender = Request.Query["gender"].ToString();
            string State = Request.Query["state"].ToString();
            ViewBag.tid = tid;
            if (firstname != string.Empty && firstname != null)
            {
                ViewBag.firstname = firstname;
                recbyfname = firstname;
                recbyf_name = null;

            }
            else
            {
                ViewBag.firstname = first_name;
                recbyf_name = first_name;
                recbyfname = null;
            }
            if (lastname != string.Empty && lastname != null)
            {
                ViewBag.lastname = lastname;

                recbylname = lastname;
                recbyl_name = null;

            }
            else
            {
                ViewBag.lastname = last_name;
                recbyl_name = last_name;
                recbylname = null;
            }
            /// Console.WriteLine("First Name " + recbyfname + " " + recbyf_name + "" + "Last Name" + last_name + " " + lastname);

            ViewBag.address = address;
            ViewBag.email = email;
            ViewBag.zip = zip;
            ViewBag.phonea = phonea;
            ViewBag.phoneb = phoneb;
            ViewBag.phonec = phonec;
            ViewBag.State = State;
            ViewBag.Gender = Gender;
            ViewBag.DOB = DOB;
            ViewBag.City = City;
            ViewBag.Age = Age;
            recbytid = tid;


            recbyzip = zip;
            recbyemail = email;
            ViewBag.source_one = source_one;

            recbyemail = email;


            recbyzip = zip;
            recbyystats = states;
            recbyyphone = phonea + phoneb + phonec;

            string host = HttpContext.Request.Host.Value;
            ViewBag.tcpadisc = d.DisclosureText.OrderByDescending(o => o.DisclosureTextId).Where(o => o.Archive == string.Empty || o.Archive == null && o.Website == host).Take(1).ToList();
            ViewBag.qa = d.CoregOffer.Where(o => o.Website == host).Take(1).ToList();
            ViewBag.pop = d.PopUp.Where(o => o.Website == host).Take(1).ToList();
            ///  d.offers.OrderByDescending(o => o.Id).Take(5).ToList();
            ViewBag.offers = d.TcpaOffers.OrderByDescending(o => o.TcpaOffersId).Where(o => o.Archive != "archive").Take(1).ToList();
            ViewBag.discloser = d.DisclosureText.OrderByDescending(o => o.DisclosureTextId).Where(o => o.Archive != "archive" && o.Website == host).Take(1).ToList();
            ///   ViewBag.coreg = d.coregoffer.OrderByDescending(o => o.Id).Take(1).ToList();
            ViewBag.nocoreg = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Validation == "no" && o.Archive != "archive" && o.Website == host).Take(1).ToList();
            ViewBag.coreg = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Validation == "yes" && o.Archive != "archive" && o.Website == host).Take(1).ToList();
            ViewBag.popup = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive" && o.Website == host).Take(1).ToList();

            return View();
        }

        private string GetGitHash()
        {
            string output = string.Empty;
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = "rev-parse --short HEAD",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                process.StartInfo = startInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd().Replace("\n", String.Empty);
                process.WaitForExit();
            }
            return output;
        }

        public async Task<IActionResult> HomeAsync()
        {
            string tid = Request.Query["tid"].ToString();
            string source_one = Request.Query["source_one"].ToString();
            string firstname = Request.Query["first_name"].ToString();
            string lastname = Request.Query["last_name"].ToString();
            string address = Request.Query["address"].ToString();
            string email = Request.Query["email"].ToString();
            string zip = Request.Query["zip"].ToString();
            string phonea = Request.Query["phonea"].ToString();
            string phoneb = Request.Query["phoneb"].ToString();
            string phonec = Request.Query["phonec"].ToString();
            ViewBag.tid = tid;
            ViewBag.firstname = firstname;
            ViewBag.lastname = lastname;
            ViewBag.address = address;
            ViewBag.email = email;
            ViewBag.zip = zip;
            ViewBag.phonea = phonea;
            ViewBag.phoneb = phoneb;
            ViewBag.phonec = phonec;
            ViewBag.source_one = source_one;
            string host = HttpContext.Request.Host.Value;
            ///  d.offers.OrderByDescending(o => o.Id).Take(5).ToList();
            ViewBag.offers = d.TcpaOffers.OrderByDescending(o => o.TcpaOffersId).Where(o => o.Archive != "archive").Take(1).ToList();
            ViewBag.discloser = d.DisclosureText.OrderByDescending(o => o.DisclosureTextId).Where(o => o.Archive != "archive" && o.Website == host).Take(1).ToList();
            ///   ViewBag.coreg = d.coregoffer.OrderByDescending(o => o.Id).Take(1).ToList();
            ViewBag.nocoreg = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Validation == "no" && o.Archive != "archive" && o.Switch != "Off").Take(1).ToList();
            ViewBag.coreg = d.CoregOffer.OrderByDescending(o => o.CoregOfferId).Where(o => o.Validation == "yes" && o.Archive != "archive" && o.Switch != "Off").Take(1).ToList();
            ViewBag.popup = d.PopUp.OrderByDescending(o => o.PopUpId).Where(o => o.Archive != "archive").Take(1).ToList();
            using (var httpClient = new HttpClient())
            {

                string url = $"http://ip-api.com/json";

                HttpClient client = new HttpClient();

                httpClient.BaseAddress = new Uri("http://ip-api.com/json");
                httpClient.DefaultRequestHeaders.Accept.Clear();

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
                        userlocationcs responsed =
                        JsonConvert.DeserializeObject<userlocationcs>(result);

                        ViewBag.apiresult = responsed;

                        recbyystats = responsed.region;

                    }

                }
            }
            return View();
        }
        public IActionResult offerwall()
        {
            string host = HttpContext.Request.Host.Value;
            ViewBag.offerswall = d.OfferWall.OrderBy(o => o.Priority).Where(o => o.Archive != "archive" && o.Website == host).ToList();
            ViewBag.tid = recbytid;
            return View();
        }
        public IActionResult CCPA()
        {
            return View();
        }
        public IActionResult thankyou()
        {
            return View();
        }
        public IActionResult unsubnotification()
        {
            return View();
        }
        public IActionResult privacy_policy()
        {
            return View();
        }
        [HttpGet]

        public IActionResult other_offer(int count)
        {

            if ((count).ToString() != string.Empty)
            {
                string host = HttpContext.Request.Host.Value;
                var counter = 1 + count;
                //var state = d.userlocationcs.ToList();
                //foreach (var i in state)
                //{
                //    recbyystats = i.region;
                //}
                var rowcount = d.PathOffer.Where(o => o.Archive != "archive" && o.Website == host).Count();

                //// var rowcount = d.afterskipoffers.Where(o => o.Archive != "archive").Count();
                if (counter < rowcount)

                {
                    ViewBag.package = d.PathOffer.OrderBy(x => x.Priority).Where(o => o.Archive != "archive" && o.Website == host).Skip(counter).Take(1).ToList();
                    ViewBag.count = counter;

                    ViewBag.tid = recbytid;

                    ViewBag.fname = recbyfname;
                    ViewBag.lname = recbylname;
                    ViewBag.f_name = recbyf_name;

                    ViewBag.email = recbyemail;

                    ViewBag.l_name = recbyl_name;
                    ViewBag.zip = recbyzip;
                    if (recbylname != null && recbylname != string.Empty)
                    {
                        ViewBag.parameterlname = "lastname";
                        ViewBag.parameterzip = "zip";
                        ViewBag.parameteremail = "email";
                    }
                    else
                    {
                        ViewBag.parameterlname = "Last_name";
                        ViewBag.parameterzip = "Zip";
                        ViewBag.parameteremail = "Email";
                    }
                    if (recbyfname != null && recbyfname != string.Empty)
                    {
                        ViewBag.parameterfname = "firstname";
                        ViewBag.parameterzip = "zip";
                        ViewBag.parameteremail = "email";
                    }
                    else
                    {
                        ViewBag.parameterfname = "First_name";
                        ViewBag.parameterzip = "Zip";
                        ViewBag.parameteremail = "Email";
                    }

                    return View();
                }
                else
                {
                    return Redirect("/Money/offerwall?tid=" + recbytid + "&subid1=1234");
                }
            }
            else
            {
                return Redirect("/Money/offerwall?tid=" + recbytid + "&subid1=1234");
            }

        }

        [HttpPost]
        public IActionResult offer(int count)
        {

            if ((count).ToString() != string.Empty)
            {
                string host = HttpContext.Request.Host.Value;
                var counter = 1 + count;
                //var state = d.userlocationcs.ToList();
                //foreach (var i in state)
                //{
                //    recbyystats = i.region;
                //}
                var rowcount = d.PathOffer.Where(o => o.Archive != "archive" && o.Website == host).Count();

                //// var rowcount = d.afterskipoffers.Where(o => o.Archive != "archive").Count();
                if (counter < rowcount)

                {
                    ViewBag.package = d.PathOffer.OrderBy(x => x.Priority).Where(o => o.Archive != "archive" && o.Website == host).Skip(counter).Take(1).ToList();
                    ViewBag.count = counter;
                    ViewBag.tid = recbytid;
                    ViewBag.fname = recbyfname;
                    ViewBag.lname = recbylname;
                    ViewBag.f_name = recbyf_name;
                    ViewBag.email = recbyemail;
                    ViewBag.l_name = recbyl_name;
                    ViewBag.zip = recbyzip;
                    return View();
                }
                else
                {
                    return Redirect("/Money/offerwall?tid=" + recbytid + "&subid1=1234");
                }
            }
            else
            {
                return Redirect("/Money/offerwall?" + recbytid + "&subid1=1234");
            }
        }
        public IActionResult terms()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addccpAsync()
        {
            string fname = Request.Form["FIRST_NAME"].ToString();
            string lname = Request.Form["LAST_NAME"].ToString();
            string addres = Request.Form["RequestType"].ToString();

            string phonna = Request.Form["phonea"].ToString();
            string phoneb = Request.Form["phoneb"].ToString();
            string phonec = Request.Form["phonec"].ToString();
            string email = Request.Form["email"].ToString();
            string message = Request.Form["message"].ToString();
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string id = Request.HttpContext.Connection.Id.ToString();
            string dob = "";
            string zip = "";
            string state = "";
            string city = "";
            string compphone = phonna + phoneb + phonec;
            HttpClient client = new HttpClient();
            string host = HttpContext.Request.Host.Value;
            string sendlead = $"https://stern.waypointsoftware.io/capture.php?xAuthentication=d66e29f339b8317492bc55777e015da0&email={email}&firstname={fname}&lastname={lname}&phone1={compphone}&address1={addres}&city={city}&state={state}&zip={zip}&DOB={dob}&LeadIP={ip}&PostURL={host}";

            var varleadresponse = await client.GetAsync(sendlead);
            var leadstr = await varleadresponse.Content.ReadAsStringAsync();

            CcpaOptOut c = new CcpaOptOut();
            c.FirstName = fname;
            c.LastName = lname;
            c.TypeRequest = addres;
            c.Phone = phonna + phoneb + phonec;
            c.Email = email;
            c.Message = message;
            d.CcpaOptOut.Add(c);
            d.SaveChanges();
            return RedirectToAction("thankyou", "Money");

        }
        public IActionResult accessdenied()
        {


            return View();
        }

        public IActionResult testpop()
        {
            return View();
        }
        [HttpGet]
        public IActionResult applymidpath()
        {

            int count = Convert.ToInt32((Request.Query["tid"]).ToString());
            //Convert.ToInt32(Request.Form["count"].ToString());

            if ((count).ToString() != string.Empty)
            {

                var counter = 1 + count;
                //var state = d.userlocationcs.ToList();
                //foreach (var i in state)
                //{
                //    recbyystats = i.region;
                //}
                var rowcount = d.OfferStates.Where(o => o.OfferType == "pathoffer").Count();

                //// var rowcount = d.afterskipoffers.Where(o => o.Archive != "archive").Count();
                if (counter < rowcount)
                {

                    var counts = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.Status == recbyystats && o.States == "Enclude" && o.OfferType == "pathoffer").Count();
                    var Excludcount = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Exclud" && o.OfferType == "pathoffer").Count();
                    if (Excludcount >= 1)
                    {
                        var offerselect = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Enclude" || o.Status == "default" && o.OfferType == "pathoffer").Take(1).ToList();
                        foreach (var i in offerselect)
                        {
                            recbyyofferid = (i.OfferStatesId).ToString();
                        }
                    }
                    if (counts >= 1)
                    {
                        var offerselect = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Enclude" && o.OfferType == "pathoffer").Take(1).ToList();
                        foreach (var i in offerselect)
                        {
                            recbyyofferid = (i.OfferStatesId).ToString();
                        }
                    }
                    else
                    {
                        var offerselect = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.OfferType == "pathoffer" && o.Status == "default").Take(1).ToList();
                        foreach (var i in offerselect)
                        {
                            recbyyofferid = (i.OfferStatesId).ToString();
                        }
                    }

                    /// ViewBag.package = d.afterskipoffers.OrderBy(x => x.Priority).Where(o => o.Archive != "archive").Skip(counter).Take(1).ToList();

                    if (recbyyofferid != null)
                    {
                        ViewBag.package = d.PathOffer.Where(o => o.Archive != "archive" && o.PathOfferId == Convert.ToInt32(recbyyofferid)).Skip(counter).Take(1).ToList();
                        ViewBag.count = counter;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("offerwall", "Money");
                    }
                }
                else
                {
                    return RedirectToAction("offerwall", "Money");
                }
            }
            else
            {
                ViewBag.count = 1;
                return RedirectToAction("applymidpath", "Money");
            }

        }

        public IActionResult applymidpath1()
        {


            ViewBag.package = d.PathOffer.OrderBy(x => x.Priority).Where(o => o.Archive != "archive").Skip(1).Take(1).ToList();
            ViewBag.count = 0;
            return View();
        }
        [HttpGet]
        public IActionResult yesqa(string id)
        {

            ////var find = d.qaoffer.OrderByDescending(x => x.Id).Where(o => o.Validation == "Yes").Skip(Convert.ToInt32(id)).Take(1).ToList();

            //return Json(find);
            return View();

        }
        [HttpGet]
        public IActionResult noqa(string id)
        {

            //var find = d.qaoffer.OrderByDescending(x => x.Id).Where(o => o.Validation == "Yes").Skip(Convert.ToInt32(id)).Take(1).ToList();

            //return Json(find);
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> unsubmailAsync()
        {
            string zip = Request.Form["email"].ToString();
            string fname = Request.Form["FIRST_NAME"].ToString();
            string lname = Request.Form["LAST_NAME"].ToString();
            string addres = Request.Form["RequestType"].ToString();

            string phonna = Request.Form["phonea"].ToString();
            string phoneb = Request.Form["phoneb"].ToString();
            string phonec = Request.Form["phonec"].ToString();
            string email = Request.Form["email"].ToString();
            string message = Request.Form["message"].ToString();
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string id = Request.HttpContext.Connection.Id.ToString();
            string dob = "";
            string eamil = "";
            string state = "";
            string city = "";
            string compphone = phonna + phoneb + phonec;

            HttpClient client = new HttpClient();
            string host = HttpContext.Request.Host.Value;
            string sendlead = $"https://stern.waypointsoftware.io/capture.php?xAuthentication=b8e5be7f85f5b9b97a08f2f530308722&email={zip}&firstname={fname}&lastname={lname}&phone1={compphone}&address1={addres}&city={city}&state={state}&zip={eamil}&DOB={dob}&LeadIP={ip}&PostURL={host}";

            var varleadresponse = await client.GetAsync(sendlead);
            var leadstr = await varleadresponse.Content.ReadAsStringAsync();
            Console.WriteLine(leadstr);

            SiteUnSubscribe r = new SiteUnSubscribe();

            r.Email = zip;
            d.SiteUnSubscribe.Add(r);
            d.SaveChanges();
            ViewBag.offers = d.Offers.OrderByDescending(o => o.OffersId).Where(o => o.Archive != "archive").Take(5).ToList();
            return RedirectToAction("unsubnotification", "Money");

        }
        public IActionResult Unsubcribe()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> submitoffers()
        {
            string tid = Request.Form["TRANSACTIONID"].ToString();
            string source_one = Request.Form["source_one"].ToString();
            string url = $"https://www.sfclk.com/?nid=519&transaction_id={tid}";
            //string url = $"http://api.ipstack.com/111.88.85.157?access_key=e27293785b6041375acfae85dd71a36c";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);


            var str = await response.Content.ReadAsStringAsync();
            string fname = Request.Form["first_name"].ToString();
            /// string lname = Request.Form["last_name"].ToString();
            string addres = Request.Form["address"].ToString();
            string zip = Request.Form["zip"].ToString();
            string phone = Request.Form["phone"].ToString();
            //string phonna = Request.Form["phonea"].ToString();
            //string phoneb = Request.Form["phoneb"].ToString();
            //string phonec = Request.Form["phonec"].ToString();
            string phonna = phone.Substring(3, 3);
            string phoneb = phone.Substring(8, 3);
            string phonec = phone.Substring(12, 4);
            string universal_leadid = Request.Form["universal_leadid"].ToString();
            string email = Request.Form["email"].ToString();
            string CHECKINGACCOUNT = Request.Form["checkingaccount"].ToString();
            string nsyesno = Request.Form["nsyesno"].ToString();
            string device = Request.Form["device"].ToString();
            string form = Request.Form["lf"].ToString();
            string age = Request.Form["age"].ToString();
            string city = Request.Form["city"].ToString();
            string dob = Request.Form["dob"].ToString();
            string gender = Request.Form["gender"].ToString();
            string state = Request.Form["state"].ToString();
            var phone1 = phonna + phoneb + phonec;
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string id = Request.HttpContext.Connection.Id.ToString();
            recbyvalidation = nsyesno;
            string host = HttpContext.Request.Host.Value;
            string sendlead = $"http://stern.waypointsoftware.io/capture.php?xAuthentication=b6c2f04801de596783ecbd4271d9dbb4&email={email}&firstname={fname}&lastname={lname}&phone1={phone}&address1={addres}&city={city}&state={state}&zip={zip}&DOB={dob}&LeadIP={ip}&PostURL={host}";
            var varleadresponse = await client.GetAsync(sendlead);
            var leadstr = await varleadresponse.Content.ReadAsStringAsync();

            Register r = new Register();

            r.FirstName = fname;
            r.LastName = lname;
            r.LeadId = universal_leadid;
            r.Address = addres;
            r.ZipCode = zip;
            //r.phone = phonna + phoneb + phonec;
            r.Phone = phone;
            r.Email = email;
            r.CheckingAccount = CHECKINGACCOUNT;
            r.NetSpend = nsyesno;
            r.IpAddress = ip;
            r.DeviceId = id;
            r.DeviceType = device;
            r.Forms = form;
            r.TransactionID = tid;
            r.State = state;
            r.Gender = gender;
            r.City = city;
            r.Dob = dob;
            r.Age = age;
            r.SourceOne = source_one;
            r.WebsiteId = host;
            r.Date = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToShortTimeString();
            d.Register.Add(r);
            d.SaveChanges();
            ViewBag.tid = tid;
            recbytid = tid;
            recbyemail = email;
            if (recbyfname != string.Empty && recbyfname != null)
            {
                recbyfname = fname;

            }
            else
            {

                recbyf_name = fname;
            }


            recbyyphone = phone1;

            recbyzip = zip;
            recbyyphone = phone;
            if (recbyf_name != null && recbyf_name != string.Empty && recbyl_name != null && recbyl_name != string.Empty)
            {
                return Redirect("/Money/offers?tid=" + tid + "&subid1=1234&First_name=" + fname + "&Last_name=" + recbyl_name + "&Phonea=" + phonna + "&Phoneb=" + phoneb + "&Phonec=" + phonec + "&Email=" + email + "&Zip=" + zip + "&Address=" + addres + "&Age=" + age + "&State=" + state + "&City=" + city + "");

            }
            if (recbyf_name != null && recbyf_name != string.Empty && recbylname != null && recbylname != string.Empty)
            {
                return Redirect("/Money/offers?tid=" + tid + "&subid1=1234&First_name=" + fname + "&lastname=" + recbylname + "&phonea=" + phonna + "&phoneb=" + phoneb + "&phonec=" + phonec + "&email=" + email + "&zip=" + zip + "&address=" + addres + "&age=" + age + "&state=" + state + "&city=" + city + "");

            }
            if (recbyfname != null && recbyfname != string.Empty && recbyl_name != null && recbyl_name != string.Empty)
            {
                return Redirect("/Money/offers?tid=" + tid + "&subid1=1234&firstname=" + fname + "&Last_name=" + recbyl_name + "&phonea=" + phonna + "&phoneb=" + phoneb + "&phonec=" + phonec + "&email=" + email + "&zip=" + zip + "&address=" + addres + "&age=" + age + "&state=" + state + "&city=" + city + "");

            }
            if (recbyfname != null && recbyfname != string.Empty && recbylname != null && recbylname != string.Empty)
            {
                return Redirect("/Money/offers?tid=" + tid + "&subid1=1234&firstname=" + fname + "&lastname=" + recbylname + "&phonea=" + phonna + "&phoneb=" + phoneb + "&phonec=" + phonec + "&email=" + email + "&zip=" + zip + "&address=" + addres + "&age=" + age + "&state=" + state + "&city=" + city + "");

            }
            //if (recbyf_name != null && recbyf_name != string.Empty )
            //{
            //    return Redirect("/Money/offers?tid=" + tid + "&subid1=1234&First_name=" + fname + "&Last_name=" + lname + "&phonea=" + phonna + "&phoneb=" + phoneb + "&phonec=" + phonec + "&email=" + email + "&zip=" + zip + "&address=" + addres + "&age=" + age + "&state=" + state + "&city=" + city + "");

            //}
            else
            {
                return Redirect("/Money/offers?tid=" + tid + "&subid1=1234&firstname=" + fname + "&lastname=" + lname + "&phonea=" + phonna + "&phoneb=" + phoneb + "&phonec=" + phonec + "&email=" + email + "&zip=" + zip + "&address=" + addres + "&age=" + age + "&state=" + state + "&city=" + city + "");

            }
        }
        [HttpGet]
        public async Task<IActionResult> offers()
        {

            var count = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Enclude" && o.OfferType == "pathoffer").Count();
            var Excludcount = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Exclud" && o.OfferType == "pathoffer").Count();
            if (Excludcount >= 1)
            {
                var offerselect = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Enclude" || o.Status == "default" && o.OfferType == "pathoffer").Skip(Excludcount).Take(1).ToList();
                foreach (var i in offerselect)
                {
                    recbyyofferid = (i.OfferStatesId).ToString();
                }
            }
            if (count >= 1)
            {
                var offerselect = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.States == recbyystats && o.Status == "Enclude" && o.OfferType == "pathoffer").Take(1).ToList();
                foreach (var i in offerselect)
                {
                    recbyyofferid = (i.OfferStatesId).ToString();
                }
            }
            else
            {
                var offerselect = d.OfferStates.OrderByDescending(o => o.OfferStatesId).Where(o => o.OfferType == "pathoffer" && o.Status == "default").Take(1).ToList();
                foreach (var i in offerselect)
                {
                    recbyyofferid = (i.OfferStatesId).ToString();
                }
            }

            string host = HttpContext.Request.Host.Value;
            //ViewBag.offers = d.offers.OrderByDescending(o => o.Id).Where(o => o.Archive != "archive").Take(1).ToList();
            ViewBag.package = d.PathOffer.OrderBy(x => x.Priority).Where(o => o.Archive != "archive" && o.Website == host).Take(1).ToList();
            ViewBag.qatitle = d.QaOffer.OrderByDescending(x => x.QaOfferId).Where(o => o.Archive != "archive" && o.Website == host).Take(1).ToList();
            var qa = d.QaOffer.OrderByDescending(x => x.QaOfferId).Where(o => o.Archive != "archive" && o.Website == host).Take(1).ToList();

            foreach (var item in qa)
            {
                ViewBag.qa = d.QaOffer.Where(o => o.QaTitle == item.QaTitle).ToList();
            }
            ViewBag.count = 0;
            ViewBag.tid = recbytid;
            ViewBag.state = recbyystats;

            ViewBag.email = recbyemail;
            ViewBag.fname = recbyfname;
            ViewBag.lname = recbylname;
            ViewBag.l_name = recbyl_name;
            if (recbylname != null && recbylname != string.Empty)
            {
                ViewBag.parameterlname = "lastname";
                ViewBag.parameterzip = "zip";
                ViewBag.parameteremail = "email";
            }
            else
            {
                ViewBag.parameterlname = "Last_name";
                ViewBag.parameterzip = "Zip";
                ViewBag.parameteremail = "Email";
            }
            if (recbyfname != null && recbyfname != string.Empty)
            {
                ViewBag.parameterfname = "firstname";
                ViewBag.parameterzip = "zip";
                ViewBag.parameteremail = "email";
            }
            else
            {
                ViewBag.parameterfname = "First_name";
                ViewBag.parameterzip = "Zip";
                ViewBag.parameteremail = "Email";
            }
            ViewBag.zip = recbyzip;
            ViewBag.f_name = recbyf_name;

            ///ViewBag.zip = recbyzip == ""? HttpContext.Session.GetString("zip"):recbyzip;
            // return RedirectToAction("applymidpath1", "Money");
            return View();

            //else
            //{
            //    return RedirectToAction("accessdenied", "Money");
            //}


        }
        [HttpPost]
        public IActionResult addprocess()
        {
            string fname = Request.Form["FIRST_NAME"].ToString();
            string lname = Request.Form["LAST_NAME"].ToString();
            string addres = Request.Form["ADDRESS1"].ToString();
            string zip = Request.Form["ZIP"].ToString();
            string phonna = Request.Form["phonea"].ToString();
            string phoneb = Request.Form["phoneb"].ToString();
            string phonec = Request.Form["phonec"].ToString();
            string email = Request.Form["email"].ToString();

            Register r = new Register();

            r.FirstName = fname;
            r.LastName = lname;
            r.Address = addres;
            r.ZipCode = zip;
            r.Phone = phonna + phoneb + phonec;
            r.Email = email;
            d.Register.Add(r);
            d.SaveChanges();

            return RedirectToAction("offers", "Money");
        }

        private void RecordArrival()
        {
            var arrival = new Arrival
            {
                ArrivalId = Guid.NewGuid(),
                SessionId = HttpContext.Session.Id,
                Timestamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")),
                Url = Request.GetDisplayUrl(),
                IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
            };
            d.Arrival.Add(arrival);
            d.SaveChanges();
        }
    }
}
