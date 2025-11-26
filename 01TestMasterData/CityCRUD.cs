using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class CityCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // City - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            //Step = 2; // City - Insert - Code Blank (Negative)
            //if (frm.IsStopped) return;
            //await CodeBlank();

            //Step = 3; // City - Insert - Name Blank (Negative)
            //if (frm.IsStopped) return;
            //await NameBlank();

            Step = 4; // City - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            //Step = 5; // City - Read (Positive)
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 6; // City - Update (Positive)
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 7; // City - Delete (Positive)
            //if (frm.IsStopped) return;
            //await Delete();
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"City - CRUD step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses City - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "City - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1City?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klick [New...] 
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klick Save
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

      //public async Task CodeBlank()
      //{
      //   var Proses = "City - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; //  Klik Menu
      //      await App.ClickBtn("//a[contains(@href, 'M1City?md')]/span");

      //      Step = 2; // Klik [New...] 
      //      await App.ClickBtn("//div[contains(@class, 'add-button')]");

      //      Step = 3; //  Input Nama
      //      await App.InputData("//input[@name='Cnama']", "Bangil");

      //      Step = 4; // Klick Search (Provinsi)
      //      await App.ClickBtn("//label[@title='Propinsi']/following-sibling::a");

      //      Step = 5; // Klik Value
      //      await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

      //      Step = 6; // Klick Save
      //      await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

      //      Step = 7; // Klick Close [X]
      //      await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

      //      Step = 8; // Apa Ada Label Error?
      //      var LblError = await page.XPathAsync("//label[@class='error']");

      //      Step = 9; // Set hasil
      //      jam.Stop();
      //      frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
      //      if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };

      //   }
      //   catch (Exception ex)
      //   {
      //      jam.Stop();
      //      frm.FAILED++;
      //      frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}

      //public async Task NameBlank()
      //{
      //   var Proses = "City - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; //  Klik Menu
      //      await App.ClickBtn("//a[contains(@href, 'M1City?md')]/span");

      //      Step = 2; // Klick [New...]
      //      await App.ClickBtn("//div[contains(@class, 'add-button')]");

      //      Step = 3; // Input Kode
      //      await App.InputData("//input[@name='Ckode']", "BGL");

      //      Step = 4; // Klick Search (Provinsi)
      //      await App.ClickBtn("//label[@title='Propinsi']/following-sibling::a");

      //      Step = 5; // Klik Value
      //      await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

      //      Step = 6; // Klick Save
      //      await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

      //      Step = 7; // Klick Close [X]
      //      await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

      //      Step = 8; // Apa Ada Label Error?
      //      var LblError = await page.XPathAsync("//label[@class='error']");

      //      Step = 9; // Set hasil
      //      jam.Stop();
      //      frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
      //      if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };

      //   }
      //   catch (Exception ex)
      //   {
      //      jam.Stop();
      //      frm.FAILED++;
      //      frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}

      public async Task Create()
      {
         var Proses = "City - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Menu
            await App.ClickBtn("//a[contains(@href, 'M1City?md')]/span");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Kode
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Ckode']", $"{rand}");

            Step = 4; // Input Nama
            await App.InputData("//input[@name='Cnama']", "Belung");

            Step = 5; // Klick Search (Provinsi)
            await App.ClickBtn("//label[@title='Propinsi']/following-sibling::a");

            Step = 6; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // Klick Save
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

      //public async Task Read()
      //{
      //   var Proses = "City - Read (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; //  click Detail
      //      await App.Click("//div[@class='slick-cell l0 r0']/a");

      //      frm.PASS++;
      //      jam.Stop();
      //      frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
      //   }
      //   catch (Exception ex)
      //   {
      //      frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}

      //public async Task Update()
      //{
      //   var Proses = "City - Update (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Klik Value
      //      await App.InputData("//input[@name='Cnama']", "Update");

      //      Step = 2; // Klik Save
      //      await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

      //      frm.PASS++;
      //      jam.Stop();
      //      frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
      //   }
      //   catch (Exception ex)
      //   {
      //      frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}

      //public async Task Delete()
      //{
      //   var Proses = "City - Delete (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Klick Value
      //      await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

      //      Step = 2; // Klick Delete 
      //      await App.ClickBtn("//i[contains(@class, 'trash')]/..");

      //      Step = 3; // Klick Ya Pop Up
      //      await App.ClickBtn("//button[text()='Yes']"); ;

      //      Step = 4; // Apa Ada Label Error?
      //      var LblError = await page.XPathAsync("//div[contains(text(), 'Data tidak bisa dihapus kerena ada transaksi terkait.')]");

      //      Step = 5; // Set hasil
      //      await App.ClickBtn("//button[text()='OK']");
      //      jam.Stop();
      //      frm.Logs("P", Proses, LblError.Length > 0 ? "FAILED" : "PASS", jam.ElapsedMilliseconds);
      //      if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };
      //   }
      //   catch (Exception ex)
      //   {
      //      frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}
   }
}
