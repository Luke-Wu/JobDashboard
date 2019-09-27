using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobDashBoard.Models
{
    /// <summary>
    /// Task entity class
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Task No
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskNo { get; set; }

        /// <summary>
        /// Staff No that the task belongs to
        /// </summary>
        public int StaffNo { get; set; }

        /// <summary>
        /// Task title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Task create date
        /// </summary>
        public DateTime? CreateDate { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual ICollection<TimeSheet> TimeSheets { get; set; }


    }
}
