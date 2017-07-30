using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using Mvc.Models;
using Newtonsoft.Json;
using System.Text;

namespace Mvc.Controllers
{
    public class MembersController : Controller
    {
        #region Properties
        //Declaring Log4Net 
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MembersController));
        #endregion

        #region Controller Methods
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(AddMemberViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:51304");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsync("api/Members", stringContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = response.Content.ReadAsStringAsync().Result;
                        viewModel.Members = JsonConvert.DeserializeObject<List<Members>>(responseBody);

                        computeOldestMember(viewModel);
                    }
                    else
                    {
                        logger.Error("Error saving Member information");
                    }

                    return View(viewModel);
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());
                return View();
            }
        }
        #endregion

        #region Private Method
        private static void computeOldestMember(AddMemberViewModel viewModel)
        {
            int oldestMemberAge = 0;
            string oldestMemberDetails = string.Empty;
            DateTime now = DateTime.Today;
            foreach (var member in viewModel.Members)
            {
                var age = 0;
                //check for oldest date
                if (!string.IsNullOrEmpty(member.DateOfBirth))
                    age = HelperUtility.DateTimeExtensions.Age(Convert.ToDateTime(member.DateOfBirth));

                if (age > oldestMemberAge)
                {
                    oldestMemberAge = age;
                    oldestMemberDetails = string.Concat(oldestMemberAge, ", ", member.FirstName, " ", member.LastName);
                }
            }
            viewModel.OldestMember = oldestMemberDetails;
        }
        #endregion
    }
}