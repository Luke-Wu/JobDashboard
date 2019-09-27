using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JobDashBoard.API.Helpers
{
    /// <summary>
    /// json help class
    /// </summary>
    internal static class JsonHelper
    {
        /// <summary>
        /// Search API parameter json error message
        /// </summary>
        /// <returns></returns>
        public static string ParameterJsonError()
        {
            var jsonError = new JObject(

                  new JProperty("error",

                              new JObject(

                                  new JProperty("status", 404),
                                  new JProperty("message", "Date parameter not exist")
                                  )
              ));
            return JsonConvert.SerializeObject(jsonError);
        }

        /// <summary>
        /// Search API parameter no data error message
        /// </summary>
        /// <returns></returns>
        public static string NoDataJsonError()
        {
            var jsonError = new JObject(

                  new JProperty("error",

                              new JObject(

                                  new JProperty("status", 404),
                                  new JProperty("message", "No data exist in the date range")
                                  )
              ));
            return JsonConvert.SerializeObject(jsonError);
        }

        /// <summary>
        /// Search API internal error message
        /// </summary>
        /// <returns></returns>
        public static string APIJsonError(string message)
        {
            var jsonError = new JObject(

                  new JProperty("error",

                              new JObject(

                                  new JProperty("status", 500),
                                  new JProperty("message", message)
                                  )
              ));
            return JsonConvert.SerializeObject(jsonError);
        }



    }
}