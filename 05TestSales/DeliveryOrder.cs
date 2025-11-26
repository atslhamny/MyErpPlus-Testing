using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestSales
{
   public class DeliveryOrder
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

            //Step = 2;
            //if (frm.IsStopped) return;
            //await SalesmanBlank();

            Step = 3;
            if (frm.IsStopped) return;
            await Insert();

            //Step = 4;
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 5;
            //if (frm.IsStopped) return;
            //await HapusDetail();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Delivery Order step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Delivery Order Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Delivery Order - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Sales/M5Do?md')]/span");
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
      public async Task SalesmanBlank()
      {
         var Proses = "Delivery Order - Insert - Salesman Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Customer
            await App.ClickBtn("//label[@title='Pelanggan']/following-sibling::a");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [Ok]
            await App.ClickBtn("//button[text()='OK']");

            Step = 6; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 7; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
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
         var Proses = "Delivery Order - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Customer 
            await App.ClickBtn("//label[@title='Pelanggan']/following-sibling::a");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][3]");

            Step = 4; // Klik Salesman
            await App.ClickBtn("//label[@title='Salesman']/following-sibling::a");

            Step = 5; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");

            Step = 6; // Klik Take SO
            await App.ClickBtn("//div//span[text()=' Take SO']");

            Step = 7; // Klik By TRansaction
            await App.Click("//a[@class='check-square'][text()='By Transaction No.']");

            Step = 8; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Sales_PickSoMasterDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");

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
      public async Task Update()
      {
         var Proses = "Delivery Order - Update Detail (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]/div[@style='top:0px']");

            Step = 2; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 3; // Klik [Draft]
            await App.Click("//li[@id='btnActDraft']");

            Step = 4; // Klik [Status]
            await App.Click("//a[contains(@class, 'select2-choice')]");

            Step = 5; // Klik [Draft]
            await App.Click("//li/div[text()='Draft']");

            Step = 6; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]/div[@style='top:0px']//a");

            Step = 7; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 8; // Klik [Search Item Code]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 9; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][7]");

            Step = 10; // Input [Quantity]
            await App.InputData("//input[@name='Jml']", "5");

            Step = 11; // Input [Price]
            await App.InputData("//input[@name='Harga']", "10000");

            Step = 12; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 13; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 14; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 15; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            frm.PASS++;
            jam.Stop();
            frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task HapusDetail()
      {
         var Proses = "Delivery Order - Hapus Detail (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]/div[@style='top:0px']//a");

            Step = 2; // Klik [Hapus]
            await App.ClickBtn("//div[contains(@class, 'odd')]//i[contains(@class, 'fa')]");

            Step = 3; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 5; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            frm.PASS++;
            jam.Stop();
            frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
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
