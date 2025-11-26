using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestSales
{
   public class SalesInvoice
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1;
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2;
            if (frm.IsStopped) return;
            await Insert();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Sales Invoice step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Sales Invoice Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Sales Invoice - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Sales/M5Si?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 5; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 6; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };

         }
         catch (Exception ex)
         {
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task Insert()
      {
         var Proses = "Sales Invoice - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Customer]
            await App.ClickBtn("//label[@title='Pelanggan']/following-sibling::a");

            Step = 3; // Klik [Customer]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][3]");

            Step = 4; // Klik [Search Salesman]
            await App.ClickBtn("//label[@title='Salesman']/following-sibling::a");

            Step = 5; // Klik [Salesman]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");

            Step = 6; // Klik [Take DO]
            await App.ClickBtn("//div[contains(@class, 'stampeDO')]");

            Step = 7; // Klik [By Transaction No]
            await App.ClickBtn("//li[@id='b1']//a[text()='By Transaction No.']");

            Step = 8; // Klik [Value]
            await App.DoubleClick("//div[contains(@id,'Myerpplus')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");

            Step = 4; // Klik [Status]
            await App.Click("//label[text()='*Status']/../a");

            Step = 4; // Klik [Approved]
            await App.Click("//div[contains(@id, 'select2')][text()='Approved']");

            Step = 9; // Klik [save]
            await App.Click("//div[text()='Save']");

            Step = 10; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 11; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 12; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 13; // Set hasil
            jam.Stop();
            frm.Logs("P", Proses, LblError.Length > 0 ? "FAILED" : "PASS", jam.ElapsedMilliseconds);
            if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }
   }
}
