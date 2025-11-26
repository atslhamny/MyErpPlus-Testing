using System;
using System.Threading.Tasks;
using System.Diagnostics;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class OtherCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Negative Test
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Negative Test
            if (frm.IsStopped) return;
            await TypeBlank();

            Step = 3; // Negative Test
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 4; // Negative Test
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 5; // Positive Test
            if (frm.IsStopped) return;
            await Create();

            Step = 6; // Positive Test
            if (frm.IsStopped) return;
            await ReadOther();

            Step = 7; // Positive Test
            if (frm.IsStopped) return;
            await UpdateOther();

            Step = 8; // Positive Test
            if (frm.IsStopped) return;
            await Delete();
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Other - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Other - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Other - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Other?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 3; // Klik [x]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 4; // Apa Ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 5; // Set hasil
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

      public async Task TypeBlank()
      {
         var Proses = "Other - Insert - Type Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Menu
            await App.ClickBtn("//a[contains(@href, 'M1Other?md')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Kode
            await App.InputData("//input[@name='Okode']", "AB001");

            Step = 4; // Input Nama
            await App.InputData("//input[@name='Onama']", "Test");

            Step = 5; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Klik [x]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

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

      public async Task CodeBlank()
      {
         var Proses = "Other  - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Menu
            await App.ClickBtn("//a[contains(@href, 'M1Other?md')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Type
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 4; // Input Nama
            await App.InputData("//input[@name='Onama']", "Test");

            Step = 5; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Klik [x]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

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

      public async Task NameBlank()
      {
         var Proses = "Other - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Menu
            await App.ClickBtn("//a[contains(@href, 'M1Other?md')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Type
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 4; // Input Kode
            await App.InputData("//input[@name='Okode']", "AB001");

            Step = 5; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Klik [x]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 7; // Apa Ada label error?
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

      public async Task Create()
      {
         var Proses = "Other - Insert (Positive)"; frm.UpdateStatus(Proses); ;
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik menu
            await App.ClickBtn("//a[contains(@href, 'M1Other?md')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Type
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 4; // Input Kode
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Okode']", $"{rand}");

            Step = 5; // Input Nama
            await App.InputData("//input[@name='Onama']", "Test");

            Step = 6; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 7; // Apa Ada label error?
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

      public async Task ReadOther()
      {
         var Proses = "Other - Read (Postive)"; frm.UpdateStatus(Proses); ;
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Value
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
      public async Task UpdateOther()
      {
         var Proses = "Other - Update (Positive)"; frm.UpdateStatus(Proses); ;
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Onama']", "Update");

            Step = 2; // Klik Save
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

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
      public async Task Delete()
      {
         var Proses = "Other - Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Value 
            await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klik Delete 
            await App.ClickBtn("//i[contains(@class, 'trash')]/..");

            Step = 3; // Klik Ya Pop Up
            await App.ClickBtn("//button[text()='Yes']"); ;

            Step = 4; // Apa Ada label error?
            var LblError = await page.XPathAsync("//div[contains(text(), 'Data tidak bisa dihapus kerena ada transaksi terkait.')]");

            Step = 5; // Set hasil
            await App.ClickBtn("//button[text()='OK']");
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
