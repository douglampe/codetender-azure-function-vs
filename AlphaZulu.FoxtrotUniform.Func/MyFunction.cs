using AlphaZulu.FoxtrotUniform.Lib;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace AlphaZulu.FoxtrotUniform.Func
{
  public static class MyFunction
  {
    [FunctionName("MyFunction")]
    public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "myroute")]HttpRequestMessage req, TraceWriter log)
    {
      var repository = new MyRepository();

      var a = GetQueryValue(req, "a");
      var b = GetQueryValue(req, "b");

      if (a == null || b == null || !int.TryParse(a, out int aValue) || !int.TryParse(b, out int bValue))
      {
        return req.CreateResponse(HttpStatusCode.BadRequest, "Query string must contain integer values for both 'a' and 'b'.");
      }

      var responseValue = repository.GetResult(aValue, bValue);

      return req.CreateResponse(HttpStatusCode.OK, responseValue);
    }

    private static string GetQueryValue(HttpRequestMessage req, string key) 
    {
      return req
      .GetQueryNameValuePairs()
      .FirstOrDefault(q => string.Compare(q.Key, key, true) == 0)
      .Value;
    }
  }
}