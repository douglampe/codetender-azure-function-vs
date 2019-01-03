using AlphaZulu.FoxtrotUniform.Web.Test.Internal;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using Xunit;

namespace AlphaZulu.FoxtrotUniform.Web.Test
{
  public class MyFunctionTest
  {
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    [InlineData(6, -7, -1)]
    public async Task TestMyControllerGetResult(int a, int b, int result)
    {
      var request = new HttpRequestMessage
      {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"https://localhost/myroute?a={a}&b={b}")
      };

      request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

      var traceWriter = new TestTraceWriter(TraceLevel.Info);

      var response = MyFunction.Run(request, traceWriter);

      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

      Assert.Equal(result, int.Parse(responseContent));
    }
  }
}
