using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace MyTestProject
{
    public class ExtentReportsConfig
    {
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;

        public static ExtentReports GetExtentReports()
        {
            if (extent == null)
            {
                string reportDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string reportPath = reportDirectory.Replace("bin\\Debug\\net8.0","TestResults");
                if (!Directory.Exists(reportDirectory))
                {
                    Directory.CreateDirectory(reportDirectory);
                }
                htmlReporter = new ExtentHtmlReporter(reportPath);
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}
