using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LinkedIn.ServiceEntities;

namespace LinkedIn
{
    public interface ILinkedInService
    {
        /// <summary>
        /// Retrieve the current user his profile.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1002
        /// </summary>
        /// <param name="profileType">The type of profile to retrieve.</param>
        /// <returns>A <see cref="Person"/> representing the current user.</returns>
        Person GetCurrentUser(ProfileType profileType);

        /// <summary>
        /// Retrieve the current user his profile.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1002
        /// </summary>
        /// <param name="profileType">The type of profile to retrieve.</param>
        /// <param name="profileFields">A list of profile fields to retrieve.</param>
        /// <returns>A <see cref="Person"/> representing the current user.</returns>
        /// <exception cref="ArgumentException">When <paramref name="profileType"/> is Standard and 
        /// <paramref name="profileFields"/> contains SitePublicProfileRequestUrl.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="profileFields"/> is null.</exception>    
        Person GetCurrentUser(ProfileType profileType, List<ProfileField> profileFields);

        /// <summary>
        /// Retrieve a profile for a member.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1002
        /// </summary>
        /// <param name="memberId">The identifier for the member.</param>
        /// <returns>A <see cref="Person"/> representing the member.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberId"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="memberId"/> is an empty string.</exception>
        /// <remarks>You cannot use a member id to get a public profile.</remarks>
        Person GetProfileByMemberId(string memberId);

        /// <summary>
        /// Retrieve a profile for a member.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1002
        /// </summary>
        /// <param name="memberId">The identifier for the member.</param>
        /// <param name="profileFields">A list of Profile fields to retrieve.</param>
        /// <returns>A <see cref="Person"/> representing the member.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberId"/> is null. -or-
        /// when <paramref name="profileFields"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="profileType"/> is Standard and 
        /// <paramref name="profileFields"/> contains SitePublicProfileRequestUrl. -or-
        /// when <paramref name="memberId"/> is an empty string.</exception>
        /// <remarks>You cannot use a member id to get a public profile.</remarks>
        Person GetProfileByMemberId(string memberId, List<ProfileField> profileFields);

        /// <summary>
        /// Retrieve a collection of profiles for a list of member identifiers.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1002
        /// </summary>
        /// <param name="memberIds">The list of identifiers for the members.</param>
        /// <returns>A <see cref="People"/> object representing a collection of profiles.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberIds"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="memberIds"/> is an empty list.</exception>
        /// <remarks>You cannot use a member id to get a public profile.</remarks>
        People GetProfilesByMemberIds(List<string> memberIds);

        /// <summary>
        /// Retrieve the connections for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        Connections GetConnectionsForCurrentUser();

        /// <summary>
        /// Retrieve the connections for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="profileFields">A list of Profile fields to retrieve.</param>
        /// <param name="modified">Which kind of modification shoud be returned.</param>
        /// <param name="modifiedSince">Time since the connections are modified (in milliseconds since epoch).</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="modifiedSince"/> is not a valid timestamp.</exception>
        Connections GetConnectionsForCurrentUser(List<ProfileField> profileFields, Modified modified, int modifiedSince);

        /// <summary>
        /// Retrieve the connections for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="profileFields">A list of Profile fields to retrieve.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        Connections GetConnectionsForCurrentUser(List<ProfileField> profileFields, int start, int count);

        /// <summary>
        /// Retrieve the connections for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="profileFields">A list of Profile fields to retrieve.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="modified">Which kind of modification shoud be returned.</param>
        /// <param name="modifiedSince">Time since the connections are modified (in milliseconds since epoch).</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="modifiedSince"/> is not a valid timestamp.</exception>
        Connections GetConnectionsForCurrentUser(List<ProfileField> profileFields, int start, int count, Modified modified, int modifiedSince);

        /// <summary>
        /// Retrieve the connections for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="memberId">The identifier for the member.</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberId"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="memberId"/> is an empty string.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="modifiedSince"/> is not a valid timestamp.</exception>
        Connections GetConnectionsByMemberId(string memberId);

        /// <summary>
        /// Retrieve the connections for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="memberId">The identifier for the member.</param>
        /// <param name="modified">Which kind of modification shoud be returned.</param>
        /// <param name="modifiedSince">Time since the connections are modified (in milliseconds since epoch).</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberId"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="memberId"/> is an empty string.</exception>
        Connections GetConnectionsByMemberId(string memberId, Modified modified, int modifiedSince);

        /// <summary>
        /// Retrieve the connections a member.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="memberId">The identifier for the member.</param>
        /// <param name="profileFields">A list of Profile fields to retrieve.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberId"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="memberId"/> is an empty string.</exception>
        Connections GetConnectionsByMemberId(string memberId, List<ProfileField> profileFields, int start, int count);

        /// <summary>
        /// Retrieve the connections a member.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1004
        /// </summary>
        /// <param name="memberId">The identifier for the member.</param>
        /// <param name="profileFields">A list of Profile fields to retrieve.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="modified">Which kind of modification shoud be returned.</param>
        /// <param name="modifiedSince">Time since the connections are modified (in milliseconds since epoch).</param>
        /// <returns>A <see cref="Connections"/> object representing the connections.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="memberId"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="memberId"/> is an empty string.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="modifiedSince"/> is not a valid timestamp.</exception>
        Connections GetConnectionsByMemberId(string memberId, List<ProfileField> profileFields, int start, int count, Modified modified, int modifiedSince);

        /// <summary>
        /// Get a 'out of network' profile.
        /// <para/>
        /// For more info see: http://developer.linkedin.com/docs/DOC-1160
        /// </summary>
        /// <param name="apiRequest">The api information for the request.</param>
        /// <returns>A <see cref="Person"/> representing the profile.</returns>
        /// <exception cref="ArgumentException">When the url in <paramref name="apiRequest"/> is invalid.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="apiRequest"/> is null.</exception>
        Person GetOutOfNetworkProfile(ApiRequest apiRequest);

        /// <summary>
        /// Get a 'out of network' profile.
        /// <para/>
        /// For more info see: http://developer.linkedin.com/docs/DOC-1160
        /// </summary>
        /// <param name="requestUri">The request uri for this profile.</param>
        /// <param name="httpHeaders">The request headers for this profile.</param>
        /// <returns>A <see cref="Person"/> representing the profile.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="requestUri"/> is null. -or-
        /// when <paramref name="httpHeaders"/> is null.</exception>
        Person GetOutOfNetworkProfile(Uri requestUri, IEnumerable<HttpHeader> httpHeaders);

        /// <summary>
        /// Retrieve the Network Updates for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateType">The type of Network Updates to retrieve.</param>
        /// <returns>A <see cref="Network"/> object representing the Network Updates.</returns>
        Updates GetNetworkUpdates(NetworkUpdateTypes updateType);

        /// <summary>
        /// Retrieve the Network Updates for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateType">The type of Network Updates to retrieve.</param>
        /// <param name="scope">The scope of the network updates (the current user his updates or the aggregated network updates).</param>
        /// <returns>A <see cref="Network"/> object representing the Network Updates.</returns>
        Updates GetNetworkUpdates(NetworkUpdateTypes updateType, Scope scope);

        /// <summary>
        /// Retrieve the Network Updates for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateType">The type of Network Updates to retrieve.</param>
        /// <param name="after">The <see cref="DateTime"/> after which to retrieve updates for.</param>
        /// <param name="before">The <see cref="DateTime"/> before which to retrieve updates for.</param>
        /// <returns>A <see cref="Network"/> object representing the Network Updates.</returns>
        Updates GetNetworkUpdates(NetworkUpdateTypes updateType, DateTime after, DateTime before);

        /// <summary>
        /// Retrieve the Network Updates for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateTypes">The type(s) of Network Updates to retrieve.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="after">The <see cref="DateTime"/> after which to retrieve updates for.</param>
        /// <param name="before">The <see cref="DateTime"/> before which to retrieve updates for.</param>
        /// <returns>A <see cref="Network"/> object representing the Network Updates.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="count"/> is smaller then zero. -or-
        /// when <paramref name="start"/> is smaller then zero.</exception>
        Updates GetNetworkUpdates(NetworkUpdateTypes updateTypes, int count, int start, DateTime after, DateTime before);

        /// <summary>
        /// Retrieve the Network Updates for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateTypes">The type(s) of Network Updates to retrieve.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="after">The <see cref="DateTime"/> after which to retrieve updates for.</param>
        /// <param name="before">The <see cref="DateTime"/> before which to retrieve updates for.</param>
        /// <param name="showHiddenMembers">Whether to display updates from people the member has chosen to "hide" from their update stream.</param>
        /// <returns>A <see cref="Network"/> object representing the Network Updates.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="count"/> is smaller then zero. -or-
        /// when <paramref name="start"/> is smaller then zero.</exception>
        Updates GetNetworkUpdates(NetworkUpdateTypes updateTypes, int count, int start, DateTime after, DateTime before, bool showHiddenMembers);

        /// <summary>
        /// Retrieve the Network Updates for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateTypes">The type(s) of Network Updates to retrieve.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="after">The <see cref="DateTime"/> after which to retrieve updates for.</param>
        /// <param name="before">The <see cref="DateTime"/> before which to retrieve updates for.</param>
        /// <param name="showHiddenMembers">Whether to display updates from people the member has chosen to "hide" from their update stream.</param>
        /// <param name="scope">The scope of the network updates (the current user his updates or the aggregated network updates).</param>
        /// <returns>A <see cref="Network"/> object representing the Network Updates.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="count"/> is smaller then zero. -or-
        /// when <paramref name="start"/> is smaller then zero.</exception>
        Updates GetNetworkUpdates(NetworkUpdateTypes updateTypes, int count, int start, DateTime after, DateTime before, bool showHiddenMembers, Scope scope);

        /// <summary>
        /// Retrieve network statistics (e.g. how many connections they have one and two degrees away).
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <returns>A <see cref="NetworkStats"/> object representing the network statistics.</returns>
        NetworkStats GetNetworkStatistics();

        /// <summary>
        /// Comment on a network update.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1006
        /// </summary>
        /// <param name="updateKey">The identifier of a network update.</param>
        /// <param name="comment">The actual comment.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentException">When <paramref name="updateKey"/> is null. -or-
        /// when <paramref name="comment"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="updateKey"/> is an empty string. -or-
        /// when <paramref name="comment"/> is an empty string.</exception>
        bool CommentOnNetworkUpdate(string updateKey, string comment);

        /// <summary>
        /// Like a network update.
        /// </summary>
        /// <param name="updateKey">The identifier of a network update.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentException">When <paramref name="updateKey"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="updateKey"/> is an empty string.</exception>
        bool LikeNetworkUpdate(string updateKey);

        /// <summary>
        /// Unlike a network update.
        /// </summary>
        /// <param name="updateKey">The identifier of a network update.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentException">When <paramref name="updateKey"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="updateKey"/> is an empty string.</exception>
        bool UnlikeNetworkUpdate(string updateKey);

        /// <summary>
        /// Search for members.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1191
        /// </summary>
        /// <param name="keywords">The keywords to search for.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <returns>A <see cref="People"/> object representing the search result.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="count"/> is smaller then zero or larger then 25.</exception>
        PeopleSearch Search(string keywords, int start, int count);

        /// <summary>
        /// Search for members.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1191
        /// </summary>
        /// <param name="keywords">The keywords to search for.</param>
        /// <param name="firstName">The first name to search for.</param>
        /// <param name="lastName">The last name to search for.</param>
        /// <param name="companyName">The company name to search for.</param>
        /// <param name="currentCompany">Whether the company to search for is the current company.</param>
        /// <param name="sortCriteria">The sort criteria for the search results.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="profileFields">A list of profile fields to retrieve.</param>
        /// <returns>A <see cref="People"/> object representing the search result.</returns>
        /// <exception cref="ArgumentException">When <paramref name="profileFields"/> contains SitePublicProfileRequestUrl.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="count"/> is smaller then zero or larger then 25.</exception>
        PeopleSearch Search(
            string keywords,
            string firstName,
            string lastName,
            string companyName,
            bool currentCompany,
            SortCriteria sortCriteria,
            int start,
            int count,
            Collection<ProfileField> profileFields);

        /// <summary>
        /// Search for members.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1191
        /// </summary>
        /// <param name="keywords">The keywords to search for.</param>
        /// <param name="firstName">The first name to search for.</param>
        /// <param name="lastName">The last name to search for.</param>
        /// <param name="companyName">The company name to search for.</param>
        /// <param name="currentCompany">Whether the company to search for is the current company.</param>
        /// <param name="title">The title to search for.</param>
        /// <param name="currentTitle">Whether the title to search for is the current title.</param>
        /// <param name="schoolName">The school name to search for.</param>
        /// <param name="currentSchool">Whether the school to search for is the current school.</param>
        /// <param name="countryCode">The country code to search for.</param>
        /// <param name="postalCode">The postal code to search for. (Not supported for all countries.)</param>
        /// <param name="distance">The distrance from a central point in miles. (This is best used in combination with both countryCode and postalCode.)</param>
        /// <param name="sortCriteria">The sort criteria for the search results.</param>
        /// <param name="start">Starting location within the result set for paginated returns.</param>
        /// <param name="count">Number of results to return.</param>
        /// <param name="profileFields">A list of profile fields to retrieve.</param>
        /// <param name="facetFields">A list of facet fields to retrieve.</param>
        /// <param name="facets">A list of facet to refine the search results.</param>
        /// <returns>A list of <see cref="Person"/> objects representing the members.</returns>
        /// <exception cref="ArgumentException">When <paramref name="postalCode"/> is provided and 
        /// <paramref name="countryCode"/> is null or empty. -or-
        /// when <paramref name="profileFields"/> contains SitePublicProfileRequestUrl.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="count"/> is smaller then zero or larger then 25.</exception>
        PeopleSearch Search(
            string keywords,
            string firstName,
            string lastName,
            string companyName,
            bool currentCompany,
            string title,
            bool currentTitle,
            string schoolName,
            bool currentSchool,
            string countryCode,
            string postalCode,
            int distance,
            SortCriteria sortCriteria,
            int start,
            int count,
            Collection<ProfileField> profileFields,
            Collection<FacetField> facetFields,
            Dictionary<FacetCode, Collection<string>> facets);

  

        /// <summary>
        /// Create a new share for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1212
        /// </summary>
        /// <param name="comment">The comment to share.</param>
        /// <param name="visibility">The visibility of the new share.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="comment"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="comment"/> is an empty string. -or-
        /// when <paramref name="visibility" /> is unknown.</exception>
        bool CreateShare(string comment, VisibilityCode visibility);

        /// <summary>
        /// Create a new share for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1212
        /// </summary>
        /// <param name="comment">The comment to share.</param>
        /// <param name="title">The title of the share.</param>
        /// <param name="description">The description of the share.</param>
        /// <param name="uri">The uri to share.</param>
        /// <param name="imageUri">The uri of the image to share.</param>
        /// <param name="visibility">The visibility of the new share.</param>
        /// <param name="postOnTwitter">Whether to post this share on Twitter.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentException">When <paramref name="comment"/> and <paramref name=""/>
        /// a combination of a title and submitted url is null or empty. -or-
        /// when <paramref name="visibility" /> is unknown.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="comment"/> is longer then 700 characters. -or-
        /// when <paramref name="title"/> is longer then 200 characters. -or-
        /// when <paramref name="description"/> is longer then 400 characters.</exception>
        bool CreateShare(string comment, string title, string description, Uri uri, Uri imageUri, VisibilityCode visibility, bool postOnTwitter);

        /// <summary>
        /// Create a rehare for the current user.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1212
        /// </summary>
        /// <param name="comment">The comment to include with the reshare.</param>
        /// <param name="shareId">The identifier of the share to reshare.</param>
        /// <param name="visibility">The visibility of the reshare.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="shareId"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="shareId"/> is an empty string. -or-
        /// When <paramref name="visibility" /> is unknown.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="comment"/> is longer then 700 characters.</exception>
        bool CreateReShare(string comment, string shareId, VisibilityCode visibility);

        /// <summary>
        /// Invite a person to the current user his network.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1012
        /// </summary>
        /// <param name="personId">The identifier of the person to invite.</param>
        /// <param name="subject">The subject of the message that will be sent to the recipient.</param>
        /// <param name="body">The body of the message that will be sent to the recipient.</param>
        /// <param name="connectionType">The type of connection to invite the person to.</param>
        /// <param name="apiRequest">A <see cref="ApiRequest"/> object used to authorize the recipient.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentException">When <paramref name="personId"/> is an empty string. -or-
        /// when <paramref name="subject"/> is an empty string. -or-
        /// when <paramref name="body"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="personId"/> is null. -or-
        /// when <paramref name="subject"/> is null. -or-
        /// when <paramref name="body"/> is null.</exception>
        bool InvitePerson(string personId, string subject, string body, ConnectionType connectionType, ApiRequest apiRequest);

        /// <summary>
        /// Invite a person to the current user his network.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1012
        /// </summary>
        /// <param name="emailAddress">The e-mail address of the person to invite.</param>
        /// <param name="firstName">The first name of the person to invite.</param>
        /// <param name="lastName">The last name of the person to invite.</param>
        /// <param name="subject">The subject of the message that will be sent to the recipient.</param>
        /// <param name="body">The body of the message that will be sent to the recipient.</param>
        /// <param name="connectionType">The type of connection to invite the person to.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentException">When <paramref name="emailAddress"/> is an empty string. -or-
        /// when <paramref name="firstName"/> is an empty string. -or-
        /// when <paramref name="lastName"/> is an empty string. -or-
        /// when <paramref name="subject"/> is an empty string. -or-
        /// when <paramref name="body"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="emailAddress"/> is null. -or-
        /// when <paramref name="firstName"/> is null. -or-
        /// when <paramref name="lastName"/> is null. -or-
        /// when <paramref name="subject"/> is null. -or-
        /// when <paramref name="body"/> is null.</exception>
        bool InvitePerson(string emailAddress, string firstName, string lastName, string subject, string body, ConnectionType connectionType);

        /// <summary>
        /// Send a message to one or more persons.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1012
        /// </summary>
        /// <param name="subject">The subject of the message.</param>
        /// <param name="body">The body of the message.</param>
        /// <param name="memberIds">A list of member identifiers.</param>
        /// <param name="includeCurrentUser">Whether to send the message to the current user.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        bool SendMessage(string subject, string body, IEnumerable<string> memberIds, bool includeCurrentUser);

        /// <summary>
        /// Post a Network Update.
        /// <para />
        /// For more info see: http://developer.linkedin.com/docs/DOC-1009
        /// </summary>
        /// <param name="cultureName">A culture name indicating the language of the update.</param>
        /// <param name="body">The actual content of the update. You can use HTML to include links to the user name and the content the user created. Other HTML tags are not supported. All body text should be HTML entity escaped and UTF-8 compliant.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="body"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="body"/> is an empty string.</exception>
        bool PostNetworkUpdate(string cultureName, string body);

        /// <summary>
        /// Invalidate the currently used OAuth token.
        /// </summary>
        /// <returns><b>true</b> if successful; otherwise <b>false</b>.</returns>
        bool InvalidateToken();
    }
}