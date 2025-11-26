using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class MaterialCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Material - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Material - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Material - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Material - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 5; // Material - Read (Positive)
            if (frm.IsStopped) return;
            await ReadMaterial();

            Step = 6; // Material - Update (Positive)
            if (frm.IsStopped) return;
            await UpdateMaterial();

            Step = 7; // Material - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Material - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Material - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Material - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var menu = await page.XPathAsync("//a[contains(@href, 'M1Material?md')]/span");
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
         var Proses = "Material - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Material?md')]/span");

            Step = 2; // Klik [New...] 
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Mnama']", "SUPER");

            Step = 4; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 5; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 6; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
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
         var Proses = "Material - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Material?md')]/span");

            Step = 2; // Klik [New...] 
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Kode]
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Mkode']", $"{rand}");

            Step = 4; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 5; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 6; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
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
         var Proses = "Material - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...] 
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Kode]
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Mkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Mnama']", "SUPER");

            Step = 4; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

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

      public async Task ReadMaterial()
      {
         var Proses = "Material - Read (Positive)"; frm.UpdateStatus(Proses);
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

      public async Task UpdateMaterial()
      {
         var Proses = "Material - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Mnama']", "Update");

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
         var Proses = "Material - Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Value
            await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klik [Delete] 
            await App.ClickBtn("//i[contains(@class, 'trash')]/..");

            Step = 3; // Klik [Ya Pop Up]
            await App.ClickBtn("//button[text()='Yes']"); ;

            Step = 4; // Apa ada label error?
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
