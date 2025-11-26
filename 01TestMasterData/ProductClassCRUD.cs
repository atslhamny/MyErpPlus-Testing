using System;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;
using System.Diagnostics;

namespace Tester
{
   public class ProductClassCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Other Cost - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await BlankInsert();

            Step = 2; // Other Cost - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await BlankCode();

            Step = 3; // Other Cost - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await BlankName();

            Step = 4; // Product Class - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 5; // Product Class - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 6; // Product Class - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 7; // Product Class - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Proses Product Class - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Product Class - CRUD Selesai");
         }
      }
      public async Task BlankInsert()
      {
         var Proses = "Other Cost - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var btnCountry = await page.XPathAsync("//a[contains(@href, 'M1ClassProduct?md')]/span");
            if (btnCountry.Length > 0)
               await btnCountry[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 5; // apakah ada label error?
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

      public async Task BlankCode()
      {
         var Proses = "Other Cost - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input name
            await App.InputData("//input[@name='Cpnama']", "INITESTING");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 5; // apa ada label error?
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
        public async Task BlankName()
      {
         var Proses = "Other Cost - Insert - Blank Name(Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Cpkode']", $"{rand}");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

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
         var Proses = "Product Class - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Cpkode']", $"{rand}");

            Step = 3; // input name
            await App.InputData("//input[@name='Cpnama']", "INITESTING");

            Step = 4; // Klik Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 6; // Set hasil
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
         var Proses = "Product Class - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = "Product Class - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Cpnama']", " Update");

            Step = 2; // Klik Save
            await App.ClickBtn("//div[text()='Save']");

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
         var Proses = "Product Class - Delete (Positive)"; frm.UpdateStatus(Proses);
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

            Step = 4; // Apa Ada Label Error?
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
