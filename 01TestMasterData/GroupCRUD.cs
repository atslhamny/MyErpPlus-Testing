using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class GroupCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      { 
         int Step = 0;
         try
         {
            Step = 1; // Group - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            //Step = 2; // Group - Insert - Code Blank (Negative)
            //if (frm.IsStopped) return;
            //await CodeBlank();

            //Step = 3; // Group - Insert - Name Blank (Negative)
            //if (frm.IsStopped) return;
            //await NameBlank();

            Step = 4; // Group - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            //Step = 5; // Group - Read (Positive)
            //if (frm.IsStopped) return;
            //await ReadGroup();

            //Step = 6; // Group - Update (Positive)
            //if (frm.IsStopped) return;
            //await UpdateGroup();

            //Step = 7; // Group - Delete (Positive)
            //if (frm.IsStopped) return;
            //await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Group - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Group - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Group - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Section?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");
  
            Step = 2; // Klik [New..] 
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
         var Proses = "Group - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         { 
            Step = 1; // Klik Menu
            await App.ClickBtn("//a[contains(@href, 'M1Section?md')]/span");

            Step = 2; // Klik [New..]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Nama
            await App.InputData("//input[@name='Snama']", "PERABOTAN");

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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task NameBlank()
      {
         var Proses = "Group - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Menu
            await App.ClickBtn("//a[contains(@href, 'M1Section?md')]/span");

            Step = 2; // Klik [New..]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Kode
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Skode']", $"{rand}");

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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }
      public async Task Create()
      {
         var Proses = "Group - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New..]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Kode
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Skode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@name='Snama']", "PERABOTAN");

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
            jam.Stop();
            frm.FAILED++;
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task ReadGroup()
      {
         var Proses = "Group - Read (Positive)"; frm.UpdateStatus(Proses);
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

      public async Task UpdateGroup()
      {
         var Proses = "Group - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Snama']", "Update");

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
         var Proses = "Group - Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick Value
            await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klick Delete 
            await App.ClickBtn("//i[contains(@class,'trash')]/..");

            Step = 3; // Klick Ya Pop Up
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
