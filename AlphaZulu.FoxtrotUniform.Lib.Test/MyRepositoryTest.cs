using Xunit;

namespace AlphaZulu.FoxtrotUniform.Lib.Test
{
  public class MyRepositoryTest : IClassFixture<MyRepository>
  {
    private MyRepository _myClass;

    public MyRepositoryTest(MyRepository myClass)
    {
      _myClass = myClass;
    }

    [Fact]
    public void TestGetResult()
    {
      var result = _myClass.GetResult(1, 2);

      Assert.Equal(3, result);
    }
  }
}
