using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestProduction
{
   public class ReturBahanBaku
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

            //Step = 3;
            //if (frm.IsStopped) return;
            //await Update();


         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Retur Bahan Baku step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Retur Bahan Baku Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Retur Bahan Baku - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Mrn?md')]/span");
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
         var Proses = "Retur Bahan Baku - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Result Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Item Code
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 4; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][7]");

            Step = 5; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 6; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 7; // Klik [Close]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 8; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 9; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 10; // Set hasil
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
         var Proses = "Retur Bahan Baku - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Value DATA
            await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klik Action
            await App.ClickBtn("//span[text()=' Action']");

            Step = 3; // Klik Draft
            await App.Click("//li[@id='btnActDraft']");

            Step = 4; // Klik Status
            await App.Click("//span[text()='Status']/following-sibling::div/a");

            Step = 5; // Klik Status Draft
            await App.Click("//li/div[text()='Draft']");

            Step = 6; // Klik Read
            await App.Click("//div[@class='slick-cell l0 r0']/a");

            Step = 7; // Klik Result Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 8; // Klik Item Code
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 9; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][8]");

            Step = 10; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 11; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 12; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 13; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//span[text()='Alert']");

            Step = 14; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };

            Step = 15; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 16; // Klik [<]
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
