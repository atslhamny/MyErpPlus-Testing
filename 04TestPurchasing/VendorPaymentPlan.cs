using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestPurchasing
{
   public class VendorPaymentPlan
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
            frm.Logs("Info", $"Vendor Payment Plan step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Vendor Payment Plan Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Vendor Payment Plan - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Purchasing/M4Vpp?md')]/span");
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
         var Proses = "Vendor Payment Plan - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Supplier 
            await App.ClickBtn("//label[@title='Supplier']/following-sibling::a");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");

            Step = 4; // Klik Show [AR]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik Ceklist
            await App.Click("//span[contains(@class, 'select-item')][1]");

            Step = 6; // Klik COA
            await App.ClickBtn("//a[text()='COA (AP)']");

            Step = 7; // Klik Add COA
            await App.ClickBtn("//div[@class='field DetailList5']//div[contains(@class, 'add-button')]");

            Step = 8; // Klik Coa Name
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

            Step = 9; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 10; // Input Uang
            await App.InputData("//input[@name='Jmlbayar']", "-10000000"); // contoh inputan [-50000]

            Step = 11; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 12; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 13; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 14; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 15; // Set hasil
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
