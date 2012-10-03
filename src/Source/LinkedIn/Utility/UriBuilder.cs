using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace LinkedIn.Utility
{
    public static class UriUtility
    {
        #region BuildApiUrlForCurrentUser

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="profileType"> Indicate the profile type. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(ProfileType profileType)
        {
            return BuildApiUrlForCurrentUser(profileType, null, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(string resourceName)
        {
            return BuildApiUrlForCurrentUser(new Resource {Name = resourceName});
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(QueryStringParameters parameters)
        {
            return BuildApiUrlForCurrentUser(ProfileType.Standard, null, parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resource"> The API resource. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(Resource resource)
        {
            return BuildApiUrlForCurrentUser(resource, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resources"> A list of API resources. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(Collection<Resource> resources)
        {
            return BuildApiUrlForCurrentUser(ProfileType.Standard, resources, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="profileType"> Indicate the profile type. </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(ProfileType profileType, string resourceName)
        {
            return BuildApiUrlForCurrentUser(profileType, new Resource {Name = resourceName});
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="profileType"> Indicate the profile type. </param>
        /// <param name="resource"> The API resource. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(ProfileType profileType, Resource resource)
        {
            return BuildApiUrlForCurrentUser(ProfileType.Standard, new Collection<Resource> {resource}, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(string resourceName, QueryStringParameters parameters)
        {
            return BuildApiUrlForCurrentUser(new Resource {Name = resourceName}, parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resource"> The API resource. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(Resource resource, QueryStringParameters parameters)
        {
            return BuildApiUrlForCurrentUser(ProfileType.Standard, new Collection<Resource> {resource}, parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="profileType"> Indicate the profile type. </param>
        /// <param name="resources"> A list of API resources. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForCurrentUser(ProfileType profileType, Collection<Resource> resources,
                                                           QueryStringParameters parameters)
        {
            string identifier = Constants.CurrentUserIdentifier;
            if (profileType == ProfileType.Public)
            {
                identifier = string.Concat(identifier, Constants.PublicProfileIdentifier);
            }

            return BuildApiUrlForMember(identifier, resources, parameters);
        }

        #endregion

        #region BuildApiUrlForMember

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="memberId"> The identifier for a member. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlByMemberId(string memberId)
        {
            return BuildApiUrlByMemberId(memberId, string.Empty);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="memberId"> The identifier for a member. </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlByMemberId(string memberId, string resourceName)
        {
            string identifier = string.Format(CultureInfo.InvariantCulture, Constants.MemberIdIdentifierFormat, memberId);

            return BuildApiUrlForMember(identifier, resourceName, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="identifier"> The identifier for a member. </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForMember(string identifier, string resourceName,
                                                      QueryStringParameters parameters)
        {
            return BuildApiUrlForMember(identifier, new Resource {Name = resourceName}, parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="identifier"> The identifier for a member. </param>
        /// <param name="resource"> The API resource. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForMember(string identifier, Resource resource,
                                                      QueryStringParameters parameters)
        {
            return BuildApiUrl(
                new Collection<Resource>
                    {
                        new Resource {Name = Constants.PeopleResourceName, Identifier = identifier},
                        resource
                    },
                parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="identifier"> The identifier of the member. </param>
        /// <param name="resources"> A list of API resources. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrlForMember(string identifier, Collection<Resource> resources,
                                                      QueryStringParameters parameters)
        {
            if (resources == null)
            {
                resources = new Collection<Resource>();
            }

            resources.Insert(0, new Resource {Name = Constants.PeopleResourceName, Identifier = identifier});

            return BuildApiUrl(resources, parameters);
        }

        #endregion

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <returns> A <see cref="UriBuilder" /> representing the API url. </returns>
        public static UriBuilder BuildApiUrl(string resourceName)
        {
            return BuildApiUrl(new Resource {Name = resourceName});
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resource"> The API resource. </param>
        /// <returns> A <see cref="UriBuilder" /> representing the API url. </returns>
        public static UriBuilder BuildApiUrl(Resource resource)
        {
            return BuildApiUrl(new Collection<Resource> {resource}, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resources"> A list of API resources. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrl(Collection<Resource> resources)
        {
            return BuildApiUrl(resources, null);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrl(string resourceName, QueryStringParameters parameters)
        {
            return BuildApiUrl(new Resource {Name = resourceName}, parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resource"> The API resource. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrl(Resource resource, QueryStringParameters parameters)
        {
            return BuildApiUrl(new Collection<Resource> {resource}, parameters);
        }

        /// <summary>
        ///   Initialize the url of the API.
        /// </summary>
        /// <param name="resources"> A list of API resources. </param>
        /// <param name="parameters"> A list of parameters. </param>
        /// <returns> A <see cref="UriBuilder" /> object representing the url. </returns>
        public static UriBuilder BuildApiUrl(Collection<Resource> resources, QueryStringParameters parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Constants.ApiBaseUrl);
            foreach (Resource resource in resources)
            {
                if (string.IsNullOrEmpty(resource.Name) == false)
                {
                    sb.Append("/");
                    sb.Append(resource.Name);
                    if (string.IsNullOrEmpty(resource.Identifier) == false)
                    {
                        sb.Append("/");
                        sb.Append(resource.Identifier);
                    }
                }
            }

            UriBuilder uri = new UriBuilder(sb.ToString());

            if (parameters != null)
            {
                return parameters.AppendToUri(uri);
            }
            else
            {
                return uri;
            }
        }
    }
}