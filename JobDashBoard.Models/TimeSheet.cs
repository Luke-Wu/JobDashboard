using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobDashBoard.Models
{
    /// <summary>
    /// TimeSheet entity class
    /// </summary>
    public class TimeSheet
    {
        /// <summary>
        /// Timesheet ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimesheetID { get; set; }

        /// <summary>
        /// The task no that this timesheet record belongs to
        /// </summary>
        public int TaskNo { get; set; }

        /// <summary>
        /// Hand date of this timesheet record
        /// </summary>
        public DateTime HandleDate { get; set; }

        /// <summary>
        /// The work hours of this timesheet record
        /// </summary>
        public double WorkHours { get; set; }

        public virtual Task Task { get; set; }


    }
}
