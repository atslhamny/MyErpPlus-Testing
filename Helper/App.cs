using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public static class App
   {

      public static string RootFolder = "";
      public static string LogFolder = "";
      public static ILogger LogFile;

      public static FrmMain FrmMain;
      public static Microsoft.Web.WebView2.WinForms.WebView2 web1;
      public static WebView2DevToolsContext page;

      public static string UrlUtama = "http://agilretri.com/";


      public static void Setup()
      {
         RootFolder = AppDomain.CurrentDomain.BaseDirectory;

         LogFolder = RootFolder + @"Logs\";
         if (!Directory.Exists(LogFolder))
            Directory.CreateDirectory(LogFolder);

         LogFile = new LoggerConfiguration().WriteTo.File(LogFolder + $"Test MyERP - {DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".txt"}").CreateLogger();
      }


      #region "Logs"

      public static void Log(string teks)
      {
         Console.ForegroundColor = ConsoleColor.White;
         Console.Write($"{DateTime.Now.ToString("HH:mm:ss")} - {teks}");
      }

      public static void LogPass(string text)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("PASS");
         LogFile.Write(Serilog.Events.LogEventLevel.Information, text);
      }
      public static void LogFailed(string text)
      {
         Console.ForegroundColor = ConsoleColor.Red;
         LogFile.Write(Serilog.Events.LogEventLevel.Information, text);
      }
      public static void NegaFail(string text)
      {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("FAILED");
         LogFile.Write(Serilog.Events.LogEventLevel.Information, text);
      }
      public static void NegaPass(string text)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("PASS");
         LogFile.Write(Serilog.Events.LogEventLevel.Information, text);
      }

      #endregion "Logs"


      #region "Action"

      public static async Task ClickFilter(string selector)
      {
         var Click = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await Click.ClickAsync();
         await Task.Delay(1000);
         await page.Keyboard.PressAsync("Enter");
      }

      public static async Task Click(string selector)
      {
         await Task.Delay(1000);
         var Clickk = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await Clickk.ClickAsync();
      }

      public static async Task DoubleClick(string selector)
      {
         await Task.Delay(1000);
         var Click2 = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await Click2.ClickAsync(new WebView2.DevTools.Dom.Input.ClickOptions { ClickCount = 2 });
      }

      public static async Task ClickBtn(string selector)
      {
         var ClickBtn = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await ClickBtn.EvaluateFunctionAsync("e => e.click()");
      }

      public static async Task InputData(string selector, string input)
      {
         var InputData = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await InputData.TypeAsync(input);
      }

      public static async Task ClickDropdown(string selector)
      {
         var Click = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await Click.ClickAsync();
         await Task.Delay(1000);
         await page.Keyboard.PressAsync("Enter");
      }

      public static async Task InputChannel(string selector)
      {
         var Click = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await Click.ClickAsync();
         await Task.Delay(1000);
         await page.Keyboard.TypeAsync("");
         await Task.Delay(1000);
         await page.Keyboard.PressAsync("Enter");
      }

      public static async Task FilterNegara(string selector, string input)
      {
         var Click = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await Click.ClickAsync();
         await Task.Delay(1000);
         await Click.TypeAsync(input);
         await Task.Delay(1000);
         await Click.PressAsync("Enter");
      }

      public static async Task InputSearch(string selector, string input)
      {
         var InputData = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await InputData.TypeAsync(input);
         await Task.Delay(1000);
         await page.Keyboard.PressAsync("Enter");
         await Task.Delay(1000);
      }

      public static async Task Update(string input, string selector)
      {
         await page.Keyboard.TypeAsync(input);
         var ClickBtn = await page.WaitForXPathAsync(selector, new WaitForSelectorOptions() { Visible = true });
         await ClickBtn.EvaluateFunctionAsync<string>("e => e.click()");
      }

      #endregion "Action"

   }
}
