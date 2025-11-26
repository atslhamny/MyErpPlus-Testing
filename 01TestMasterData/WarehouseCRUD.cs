using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class WarehouseCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Warehouse - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Warehouse - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Warehouse - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Warehouse - Insert - Location Blank (Negative)
            if (frm.IsStopped) return;
            await LocationBlank();

            Step = 5; // Warehouse - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 6; // Warehouse - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 7; // Warehouse - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 8; // Warehouse - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Proses Warehouse - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Warehouse - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Warehouse - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var btnWarehouse = await page.XPathAsync("//a[contains(@href, 'M1Warehouse?md')]/span");
            if (btnWarehouse.Length > 0)
               await btnWarehouse[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 5; // Apa Ada Label Error
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

      public async Task CodeBlank()
      {
         var Proses = "Warehouse - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Nama
            await App.InputData("//input[@Name='Wnama']", "Test");

            Step = 3; // Klik Search Location
            await App.ClickBtn("//label[@title='Lokasi']/following-sibling::a");

            Step = 4; // Klik Location
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 5; //Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Klik Close [X]
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
         var Proses = "Warehouse - Insert - Nama Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Wkode']", $"{rand}");

            Step = 3; // Klik Search Location
            await App.ClickBtn("//label[@title='Lokasi']/following-sibling::a");

            Step = 4; // Klik Location
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 5; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 7; // Apa Ada Label Error
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

      public async Task LocationBlank()
      {
         var Proses = "Warehouse - Insert - Location Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Wkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Wnama']", "Test");

            Step = 4; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 5; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 6; // Apa Ada Label Error
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

      public async Task Create()
      {
         var Proses = "Warehouse - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik menu
            await App.Click("//a[contains(@href, 'M1Warehouse?md')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Wkode']", $"{rand}");

            Step = 4; // Input Nama
            await App.InputData("//input[@Name='Wnama']", "Test");

            Step = 5; // Klik Seach Debit Account
            await App.ClickBtn("//label[@title='Lokasi']/following-sibling::a");

            Step = 6; // Klik Debit Account
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 8; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");
            
            Step = 9; // Set hasil
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
          var Proses = "Warehouse - Read (Positive)"; frm.UpdateStatus(Proses);
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
          var Proses = "Warehouse - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@Name='Wnama']", "Update");

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
        var Proses = "Warehouse - Delete (Positive)"; frm.UpdateStatus(Proses);
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

                Step = 4; // apa ada label error?
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
