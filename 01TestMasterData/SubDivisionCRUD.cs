using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class SubDivisionCRUD
   {
      FrmMain frm = App.FrmMain;
      WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Sub Division - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Sub Division - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Sub Division - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Sub Division - Insert - Division Blank (Negative)
            if (frm.IsStopped) return;
            await DivisionBlank();

            Step = 5; // Sub Division - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 6; // Sub Division - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 7; // Sub Division - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 8; // Sub Division - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Sub Division - CRUD step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Sub Division - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Sub Division - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var menu = await page.XPathAsync("//a[contains(@href, 'M1Subdivision')]/span");
            if (menu.Length > 0)
               await menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 5; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 6; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);

         }
      }

      public async Task CodeBlank()
      {
         var Proses = "Sub Division - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Subdivision')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Sdnama']", "Sub Divisi 02");

            Step = 4; // Klik [Search]
            await App.ClickBtn("//label[@title='Divisi']/following-sibling::a");

            Step = 5; // [[Search] Division]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 7; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 8; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 9; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);

         }
      }

      public async Task NameBlank()
      {
         var Proses = "Sub Division - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Subdivision')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Kode]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Sdkode']", $"{rand}");

            Step = 4; // Klik [[Search]]
            await App.ClickBtn("//label[@title='Divisi']/following-sibling::a");

            Step = 5; // [[[Search] Division]]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 7; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 8; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 9; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);

         }
      }

      public async Task DivisionBlank()
      {
         var Proses = "Sub Division - Insert - Division Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Subdivision')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Kode]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Sdkode']", $"{rand}");

            Step = 4; // Input [Nama]
            await App.InputData("//input[@name='Sdnama']", "Sub Divisi 02");

            Step = 5; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 7; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);

         }
      }

      public async Task Create()
      {
         var Proses = "Sub Division - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Kode]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Sdkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Sdnama']", "Sub Divisi 02");

            Step = 4; // Klik [Search]
            await App.ClickBtn("//label[@title='Divisi']/following-sibling::a");

            Step = 5; // [[Search] Division]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 7; // Apa ada label error?
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
         var Proses = "Sub Division - Read (Positive)"; frm.UpdateStatus(Proses);
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

      public async Task Update()
      {
         var Proses = "Sub Division - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input nama
            await App.InputData("//input[@name='Sdnama']", "Update");

            Step = 2; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

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
         var Proses = "Sub Division - Delete (Positive)"; frm.UpdateStatus(Proses);
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

            Step = 5;
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
