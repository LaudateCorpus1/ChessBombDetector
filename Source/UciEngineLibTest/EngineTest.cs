using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UciEngineLib;

namespace UciEngineLibTest
{
  [TestClass]
  public class EngineTest
  {
    private Stream CreateStreamFromString(string str)
    {
      return new MemoryStream(Encoding.Default.GetBytes(str ?? ""));
    }

    [TestMethod]
    public void TestEngineEventHandler()
    {
      int errorCount = 0;
      Stream stream = CreateStreamFromString(Resource.EngineEvents);
      var reader = new StreamReader(stream);
      using (var engine = new Engine(reader, null))
      {
        engine.ExceptionEvent += (sender, args) => errorCount++;
        engine.Run();
        engine.WaitForEventProcessor();
      }
      Assert.AreEqual(0, errorCount);
    }
  }
}