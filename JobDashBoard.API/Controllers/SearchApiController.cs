using JobDashBoard.API.Helpers;
using JobDashBoard.API.Models;
using JobDashBoard.BLL;
using JobDashBoard.IBLL;
using JobDashBoard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace JobDashBoard.API.Controllers
{
    public class SearchApiController : ApiController
    {

        private readonly ITimeSheetService _timesheetService;
        public SearchApiController(ITimeSheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }



        /// <summary>
        /// Search API get staffs work hours based on begin date and end date 
        /// </summary>
        /// <param name="strBeginDate">begin date</param>
        /// <param name="strEndDate">end date</param>
        /// <returns>Json data including staff and work hours information</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/SearchApi/GetWorkHours/{strBeginDate}/{strEndDate}")]
        public HttpResponseMessage GetWorkHours(string strBeginDate,string strEndDate)
        {

            var resp = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(strBeginDate) && !string.IsNullOrEmpty(strEndDate))
            {
                try
                {
                    DateTime beginDate = DateTime.Parse(strBeginDate);
                    DateTime endDate = DateTime.Parse(strEndDate);

                    //get all the timesheet list between begin date and end date
                    IEnumerable<TimeSheet> allTimesheets = _timesheetService.FindList(beginDate, endDate);

                    if (allTimesheets.Count() > 0)
                    {
                        
                        //get all the staffs job records based on timesheet list
                        var allJobRecords = allTimesheets.ToList().GroupBy(t => t.Task.Staff).Select(g => new JobRecordModel
                        {
                            StaffNo = g.Key.StaffNo,
                            FirstName = g.Key.FirstName,
                            LastName = g.Key.LastName,
                            BeginDate = beginDate,
                            EndDate = endDate,
                            WorkHours = g.Sum(t => t.WorkHours)

                        });

                        

                        resp.Content = new StringContent(JsonConvert.SerializeObject(allJobRecords), System.Text.Encoding.UTF8, "application/json");
                    }
                    else
                    {
                        resp.Content = new StringContent(JsonHelper.NoDataJsonError(), System.Text.Encoding.UTF8, "application/json");
                    }
   
                }
                catch (Exception e)
                {

                    resp.Content = new StringContent(JsonHelper.APIJsonError(e.Message), System.Text.Encoding.UTF8, "application/json");

                }
              
            }
            else
            {
                resp.Content = new StringContent(JsonHelper.ParameterJsonError(), System.Text.Encoding.UTF8, "application/json");
                
            }


            return resp;


        }






    }
}