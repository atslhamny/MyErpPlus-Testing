using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestProduction
{
   public class ProductionFormula
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
            await FinishedGoodsBlank();

            Step = 4;
            if (frm.IsStopped) return;
            await DetailBlank();

            Step = 5;
            if (frm.IsStopped) return;
            await Insert();

            //Step = 6;
            //if (frm.IsStopped) return;
            //await Update();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Production Formula step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Production Formula Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Production Formula - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Bom?md')]/span");
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

      public async Task FinishedGoodsBlank()
      {
         var Proses = "Production Formula - Insert - Finished Goods Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Search Item Kode]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 4; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 6; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 7; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 8;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 9; // Set hasil
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

      public async Task DetailBlank()
      {
         var Proses = "Production Formula - Insert - Detail Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Finished Goods]
            await App.ClickBtn("//label[@title='Barang Jadi']/following-sibling::a");

            Step = 3; // Klik [Finished Goods]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

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
         var Proses = "Production Formula - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Finished Goods]
            await App.ClickBtn("//label[@title='Barang Jadi']/following-sibling::a");

            Step = 3; // Klik [Finished Goods]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik [Search Item Kode]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 6; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 8; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 9; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 10; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 11; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 12; // Set hasil
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
         var Proses = "Production Formula - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");

            Step = 2; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 3; // Klik [Draft]
            await App.Click("//li[@id='btnActDraft']");

            Step = 4; // Klik [Status]
            await App.Click("//span[text()='Status']/following-sibling::div/a");

            Step = 5; // Klik [Draft]
            await App.Click("//li/div[text()='Draft']");

            Step = 6; // Klik [Data]
            await App.Click("//div[@class='slick-cell l0 r0']/a");

            Step = 7; // Klik [Add Material]
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 8; // Klik [Search Item Code]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 9; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][8]");

            Step = 10; // Input [Price]
            await App.InputData("//input[@name='Harga']", "100000");

            Step = 11; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 12; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 13; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 14; // Klik [<]
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
