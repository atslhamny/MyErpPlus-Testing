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
   public class BranchCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Branch - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            //Step = 2; // Branch - Insert - Code Blank (Negative)
            //if (frm.IsStopped) return;
            //await CodeBlank();

            //Step = 3; // Branch - Insert - Name Blank (Negative)
            //if (frm.IsStopped) return;
            //await NameBlank();

            Step = 4; // Branch - Insert (Positive)
            if (frm.IsStopped) return;
            await CreateBranch();

            //Step = 5; // Branch - Read (Positive)
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 6; // Branch - Update (Positive)
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 7; // Branch - Delete (Positive)
            //if (frm.IsStopped) return;
            //await Delete();

         }
         catch (Exception ex)
         {
           frm.Logs("Info", $"Branch - CRUD step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
           frm.UpdateStatus("Proses Branch - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Branch - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Branch?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");
            
            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klick Save 
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Click Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 5; // Apa Ada Label LblError?
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
      //   var Proses = "Branch - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Klik [New...]
      //      await App.Click("//div[contains(@class, 'add-button')]");

      //      Step = 2; // Input Nama
      //      await App.InputData("//input[@Name='Bnama']", "Agiel Reri");

      //      Step = 3; // Klick Save
      //      await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

      //      Step = 4; // Klick Close[X]
      //      await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

      //      Step = 5; // Apa Ada Label Error?
      //      var LblError = await page.XPathAsync("//label[@class='error']");

      //      Step = 6; // Set hasil
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
      //   var Proses = "Branch - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Klik [New...]
      //      await App.Click("//div[contains(@class, 'add-button')]");

      //      Step = 2; // Input Code
      //      await App.InputData("//input[@Name='Bkode']", "A1");

      //      Step = 3; // Klick Save
      //      await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

      //      Step = 4; // Klick Close [X]
      //      await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

      //      Step = 5; // Apa Ada Label Error?
      //      var LblError = await page.XPathAsync("//label[@class='error']");

      //      Step = 6; // Set hasil
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

      public async Task CreateBranch()
      {
         var Proses = "Branch - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "Agiel");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 5; // Apa Ada Label Error?
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

      //public async Task Read()
      //{
      //   var Proses = "Branch - Read (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Klick Value
      //      await App.Click("//div[@class='slick-cell l0 r0']/a");

      //     frm.PASS++;
      //      jam.Stop();
      //      frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
      //   }
      //   catch (Exception ex)
      //   {
      //     frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}

      //public async Task Update()
      //{
      //   var Proses = "Branch - Update (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Input Name
      //      await App.InputData("//input[@Name='Bnama']", "Update");

      //      Step = 2; // Klik Save
      //      await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

      //     frm.PASS++;
      //      jam.Stop();
      //      frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
      //   }
      //   catch (Exception ex)
      //   {
      //     frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}

      //public async Task Delete()
      //{
      //   var Proses = "Branch - Delete (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; //  Click Read Contact
      //      await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

      //      Step = 2; //  Click Delete Contact
      //      await App.ClickBtn("//i[contains(@class, 'trash')]/..");

      //      Step = 3; //  Click Ya Pop Up
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
      //     frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}
   }
}
