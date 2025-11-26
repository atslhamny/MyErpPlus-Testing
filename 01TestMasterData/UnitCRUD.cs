using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class UnitCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Unit - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Unit - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Unit - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Unit - Insert - Value Blank (Negative)
            if (frm.IsStopped) return;
            await ValueBlank();

            Step = 5;// Unit - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 6; // Unit - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 7; // Unit - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 8; // Unit - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Proses Unit - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Unit - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
          var Proses = "Unit - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var btnCountry = await page.XPathAsync("//a[contains(@href, 'M1Unit?md')]/span");
            if (btnCountry.Length > 0)
               await btnCountry[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

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

      public async Task CodeBlank()
      {
            var Proses = "Unit - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
            Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
            int Step = 0;
            try
            {
                Step = 1; // Klik [New...]
                await App.ClickBtn("//div[contains(@class, 'add-button')]");

                Step = 2; // Input Nama
                await App.InputData("//input[@name='Unama']", "BOX002");

                Step = 3; // Input Value
                await App.InputData("//input[@name='Unilai']", "1");

                Step = 4; // Klik Save
                await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

                Step = 5; // Klik Close [X]
                await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

                Step = 6; // Apa Ada Label Error?
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

      public async Task NameBlank()
      {
          var Proses = "Unit - Insert - Nama Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Kode
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Ukode']", $"{rand}");

            Step = 3; // Input Value
            await App.InputData("//input[@name='Unilai']", "1");

            Step = 4; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 5; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 6; //Apa Ada Label Error?
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

      public async Task ValueBlank()
      {
         var Proses = "Unit - Insert - Value Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Tambah Data 
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Kode
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Ukode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@name='Unama']", "BOX002");

            Step = 4; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 5; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 6; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");
            
            Step = 7; // Set Hasil
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
            var Proses = "Unit - Insert (Positive)"; frm.UpdateStatus(Proses);
            Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
            int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Kode
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Ukode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@name='Unama']", "BOX002");

            Step = 4; // Input Value
            await App.InputData("//input[@name='Unilai']", "1");

            Step = 5; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 6; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");
            
            Step = 7; // Set hasil
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
          var Proses = "Unit - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik value
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
         var Proses = "Unit - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Unama']", "Update");

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
         var Proses = "Unit - Delete (Positive)"; frm.UpdateStatus(Proses);
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
