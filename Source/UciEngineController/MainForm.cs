using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UciEngineLib;
using log4net;

namespace UciEngineController
{
  public partial class MainForm : Form
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    private readonly Process _engineProcess;

    private readonly Engine _engine;

    public MainForm()
    {
      InitializeComponent();
      _engineProcess = new Process
        {
          StartInfo =
            {
              FileName = ConfigurationManager.AppSettings["EngineFileName"],
              UseShellExecute = false,
              RedirectStandardOutput = true,
              RedirectStandardInput = true,
              CreateNoWindow = true
            }
        };
      _engineProcess.Start();
      _engine = new Engine(_engineProcess.StandardOutput, _engineProcess.StandardInput);
      _engine.ExceptionEvent += (sender, args) =>
        Log.Error(String.Format("Error handling output line'{0}'", args.Data.Item1), args.Data.Item2);
      _engine.InfoEvent += (sender, args) =>
          {
            if (args.Data.CurrMove != null)
            {
              Log.InfoFormat("CurrMove={0}", args.Data.CurrMove.Value);
            }
          };
      while (_engineProcess.StandardOutput.ReadLine() != "")
      {
      }
      _engine.Run();
      _engine.SetOption("Threads", ConfigurationManager.AppSettings["EngineThreadCount"]);
    }

    private void GoButton_Click(object sender, EventArgs e)
    {
      Go();
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
      Stop();
    }

    private void Go()
    {
      _engine.Go();
    }

    private void Stop()
    {
      _engine.Stop();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        _engine.Quit();
        _engine.WaitForEventProcessor();
        _engineProcess.WaitForExit();
      }
      finally
      {
        _engineProcess.Close();
      }
    }
  }
}
