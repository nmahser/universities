using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using universities.Models;
using universities.APIHandlerManager;
using Newtonsoft.Json;
using universities.DataAccess;
using System.Net.Http;



namespace universities.Controllers
{
    public class HomeController : Controller
    {

        public static ApplicationDbContext dbContext;
        
        HttpClient httpClient;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Schools()
        {
            ViewBag.dbSuccessComp = 0;
            //APIHandler webHandler = new APIHandler(dbContext);
            APIHandler webHandler = new APIHandler();

            Schools schools = webHandler.GetSchools();
            
            TempData["Schools"] = JsonConvert.SerializeObject(schools);

            return View(schools);
        }

       
        public IActionResult Populate()
        {
            
            Schools schools = JsonConvert.DeserializeObject<Schools>(TempData["Schools"].ToString());


            foreach (School school in schools.results)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.School.Where(s => s.Id.Equals(school.Id)).Count() == 0)
                {
                    dbContext.School.Add(school);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbScucessComp = 1;

            return View("Index",schools);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
