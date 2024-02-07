using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Joanna.RestApi.Framework.Utils
{
    public class EndpointPaths
    {
        #region Pet Paths
        public static string PetResourceUrl() => "/pet";

        public static string PetByIdResourceUrl(long petId) => $"{PetResourceUrl()}/{petId}";

        #endregion

        #region User Paths
        public static string UserResourceUrl() => "/user";

        #endregion
    }
}
