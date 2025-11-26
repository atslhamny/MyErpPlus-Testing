using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestFixAsset
{
   public class DepreciationAsset
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Depreciation Asset -Insert - All Blank(Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Depreciation Asset -Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();


         }
         catch (Exception ex)
         {
            frm.Logs("Info", $" Depreciation Asset step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses  Depreciation Asset Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = " Depreciation Asset - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/FixedAsset/M7Da?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [Ok]
            await App.ClickBtn("//button[text()='OK']");

            Step = 5; // Klick [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 6; // Apa Ada Label Erro?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
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
         var Proses = " Depreciation Asset - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Show] 
            await App.ClickBtn("//div[contains(@class, 'tool-button add-button icon-tool-button')]//span[text()=' Show']");

            Step = 3; // Klik [Check List]
            await App.ClickBtn("//div[@class='slick-cell l1 r1']/span");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [Close]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 6; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 7; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
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
      public async Task Read()
      {
         var Proses = "Depreciation Asset - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Read
            await App.Click("//div[@class='slick-cell l0 r0']/a");

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
      public async Task Update()
      {
         var Proses = "Depreciation Asset - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input [Name ]
            await App.ClickBtn("//div[contains(@class, 'tool-button add-button icon-tool-button')]//span[text()=' Show']");

            Step = 2; // Input [Ceklis ke 2]
            await App.ClickBtn("//div[@class='slick-cell l1 r1']/span[2]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 5; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

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
