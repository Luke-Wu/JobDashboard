using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobDashBoard.Models
{
    /// <summary>
    /// Staff entity class
    /// </summary>
    public class Staff
    {

        /// <summary>
        /// staff no
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffNo { get; set; }

        /// <summary>
        /// staff first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// staff last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// staff brith date
        /// </summary>
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}
