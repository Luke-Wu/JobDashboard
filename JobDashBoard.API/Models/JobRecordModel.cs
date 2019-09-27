using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobDashBoard.API.Models
{
    /// <summary>
    /// Staff job records model including staffs and work hours information
    /// </summary>
    public class JobRecordModel
    {
        public int StaffNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public double WorkHours { get; set; }


    }
}