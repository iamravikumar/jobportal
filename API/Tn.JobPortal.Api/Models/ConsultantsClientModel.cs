﻿using System.Collections.Generic;

namespace Tn.JobPortal.Api.Models
{
    /// <summary>
    /// ConsultantsDataModel
    /// </summary>
    public class ConsultantsClientModel
    {
        /// <summary>
        /// Gets or sets the consultant identifier.
        /// </summary>
        /// <value>
        /// The consultant identifier.
        /// </value>
        public int ConsultantId { get; set; }

        /// <summary>
        /// Gets or sets the name of the consultant.
        /// </summary>
        /// <value>
        /// The name of the consultant.
        /// </value>
        public string ConsultantName { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public List<string> MemberIdList { get; set; }

        /// <summary>
        /// Gets or sets the job role identifier.
        /// </summary>
        /// <value>
        /// The job role identifier.
        /// </value>
        public List<int> JobRoleIdList { get; set; }

        /// <summary>
        /// Gets or sets the inserted by.
        /// </summary>
        /// <value>
        /// The inserted by.
        /// </value>
        public string InsertedBy { get; set; }
    }
}
