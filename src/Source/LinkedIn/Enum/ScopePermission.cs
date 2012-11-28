using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LinkedIn
{
    /// <summary>
    /// Represents options for requesting additional permissions from the member.
    /// From https://developer.linkedin.com/documents/authentication
    /// </summary>
    public enum ScopePermission
    {
        /// <summary>
        /// Name, photo, headline, and current positions
        /// </summary>
        [Description("r_basicprofile")]
        BasicProfile = 0,

        /// <summary>
        /// Full profile including experience, education, skills, and recommendations
        /// </summary>
        [Description("r_fullprofile")]
        FullProfile = 1,

        /// <summary>
        /// The primary email address you use for your LinkedIn account
        /// </summary>
        [Description("r_emailaddress")]
        EmailAddress = 2,

        /// <summary>
        /// Your 1st and 2nd degree connections
        /// </summary>
        [Description("r_network")]
        Network = 3,

        /// <summary>
        /// Address, phone number, and bound accounts
        /// </summary>
        [Description("r_contactinfo")]
        ContactInfo = 4,

        /// <summary>
        /// Retrieve and post updates to LinkedIn as you
        /// </summary>
        [Description("rw_nus")]
        NetworkUpdates = 5,

        /// <summary>
        /// Retrieve and post group discussions as you
        /// </summary>
        [Description("rw_groups")]
        GroupDiscussions = 6,

        /// <summary>
        /// Send messages and invitations to connect as you
        /// </summary>
        [Description("w_messages")]
        Messages = 7
    }
}
