using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class SubDepartmentCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // SubDepartment - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // SubDepartment - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // SubDepartment - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // SubDepartment - Insert - Department Blank (Negative)
            if (frm.IsStopped) return;
            await DepartmentBlank();

            Step = 5; // SubDepartment - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 6; // SubDepartment - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 7; // SubDepartment - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 8; // SubDepartment - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"SubDepartment - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
           frm.UpdateStatus("Proses SubDepartment - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "SubDepartment - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1SubDepartment?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");
            
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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task CodeBlank()
      {
         var Proses = "SubDepartment - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Nama
            await App.InputData("//input[@Name='Sdpnama']", "PT Paadang");

            Step = 3; // Klik Search
            await App.Click("//label[@title='Departemen']/following-sibling::a");

            Step = 4; // Click Data Search
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task NameBlank()
      {
         var Proses = "SubDepartment - Insert -  Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Sdpkode']", $"{rand}");

            Step = 3; // Klik Search Department
            await App.Click("//label[@title='Departemen']/following-sibling::a");

            Step = 4; // Klik Data Department
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task DepartmentBlank()
      {
         var Proses = "SubDepartment - Insert -  Department Blank (Negative)"; frm.UpdateStatus(Proses); 
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@Name='Sdpkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Sdpnama']", "PT Paadang");

            Step = 4; // Klik [Save]
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }
      public async Task Create()
      {
         var Proses = "SubDepartment - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Sdpkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Sdpnama']", "PT Paadang");

            Step = 4; //
            await App.Click("//label[@title='Departemen']/following-sibling::a");

            Step = 5; // Klik Debit Account
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // Klik Save
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 7; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
            jam.Stop();
            frm.Logs("P", Proses, LblError.Length > 0 ? "FAILED" : "PASS", jam.ElapsedMilliseconds);
            if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };

         }
         catch (Exception ex)
         {
            jam.Stop();
            frm.FAILED++;
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task Read()
      {
         var Proses = "SubDepartment - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = "SubDepartment - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@Name='Sdpnama']", "Update");

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
         var Proses = "SubDepartment - Delete (Positive)"; frm.UpdateStatus(Proses);
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
