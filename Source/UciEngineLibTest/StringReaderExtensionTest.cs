using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UciEngineLib.Utils;

namespace UciEngineLibTest
{
  [TestClass]
  public class StringReaderExtensionTest
  {
    [TestMethod]
    public void TestReadWord()
    {
      StringReader reader = new StringReader("string 128 MB Hash");
      Assert.AreEqual("string", reader.ReadWord());
      Assert.AreEqual("128", reader.ReadWord());
      Assert.AreEqual("MB", reader.ReadWord());
      Assert.AreEqual("Hash", reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
    }

    [TestMethod]
    public void TestReadWordNull()
    {
      StringReader reader = new StringReader("");
      Assert.AreEqual(null, reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
    }

    [TestMethod]
    public void TestReadWordSpace()
    {
      StringReader reader = new StringReader("  ");
      Assert.AreEqual("", reader.ReadWord());
      Assert.AreEqual("", reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
    }

    [TestMethod]
    public void TestReadWordInternalSpace()
    {
      StringReader reader = new StringReader(" 1 2 3  ");
      Assert.AreEqual("", reader.ReadWord());
      Assert.AreEqual("1", reader.ReadWord());
      Assert.AreEqual("2", reader.ReadWord());
      Assert.AreEqual("3", reader.ReadWord());
      Assert.AreEqual("", reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
      Assert.AreEqual(null, reader.ReadWord());
    }

  }
}
