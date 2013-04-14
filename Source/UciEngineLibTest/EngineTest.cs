using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StreamReader reader = new StreamReader(stream);
            using (Engine engine = new Engine(reader, null))
            {
                engine.ExceptionEvent += (sender, args) => errorCount++;
                engine.Run();
                engine.WaitForEventProcessor();
            }
            Assert.AreEqual(0, errorCount);
        }
    }
}
