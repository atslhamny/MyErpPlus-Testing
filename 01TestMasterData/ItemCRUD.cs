using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class ItemCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Item - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Item - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Item - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Item - Insert - Type Blank (Negative)
            if (frm.IsStopped) return;
            await TypeBlank();

            Step = 5; // Item - Insert - COGS Blank (Negative)
            if (frm.IsStopped) return;
            await COGSBlank();

            Step = 6; // Item - Bug Save (Positive)
            if (frm.IsStopped) return;
            await BugSave();

            Step = 7; // Item - Bug Sub Department (Positive)
            if (frm.IsStopped) return;
            await BugSubDepartment();

            Step = 8; // Item - Bug Sub Item From (Positive)
            if (frm.IsStopped) return;
            await BugSubItemFrom();

            Step = 9; // Item - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            //Step = 10; // Item - Read (Positive)
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 11; // Item - Update (Positive)
            //if (frm.IsStopped) return;
            //await Update();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Item - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Item - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Item - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New..]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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
         var Proses = "Item - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New..]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "Agiel Reri");

            Step = 3; // Klik [Save]
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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

      public async Task NameBlank()
      {
         var Proses = "Item - Insert -  Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New..]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 3; // Klik [Save]
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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

      public async Task COGSBlank()
      {
         var Proses = "Item - Insert - COGS Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New..]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "Agiel Reri");

            Step = 4; // Klik (Type)
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 5; // Klik COGS
            await App.ClickFilter("//label[text()='*HPP']/../a");

            Step = 6; // Close Value
            await App.Click("//label[text()='*HPP']/../a/abbr");

            Step = 7; // Klik [Save]
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 8; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 9; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 10; // Set hasil
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
         var Proses = "Item - Insert - Type Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New..]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "Agiel Reri");

            Step = 4; // Klik (Type)
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 5; // Close Value
            await App.Click("//label[text()='*Jenis']/../a/abbr");

            Step = 6; // Klik COGS
            await App.ClickFilter("//label[text()='*HPP']/../a");

            Step = 7; // Klik [Save]
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 8; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 9; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 10; // Set hasil
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

      public async Task BugSave()
      {
         var Proses = "Item - Bug Save (Positive)"; frm.UpdateStatus(Proses);
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
            await App.InputData("//input[@Name='Bnama']", "HDD King Ston 500GB");

            Step = 4; // Klik (Type)
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 5; // Klik COGS
            await App.ClickFilter("//label[text()='*HPP']/../a");

            Step = 6; // Klik Save
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 7; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
            jam.Stop();
            frm.Logs("P", Proses, LblError.Length > 0 ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };

         }
         catch (Exception ex)
         {
            jam.Stop();
            frm.FAILED++;
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task BugSubDepartment()
      {
         var Proses = "Item - Bug Sub Department (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "HDD King Ston 500GB");

            Step = 4; // Klik (Type)
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 5; // Klik COGS
            await App.ClickFilter("//label[text()='*HPP']/../a");

            Step = 6; // Klik Sub Department
            await App.ClickBtn("//label[@title='Sub Departemen']/following-sibling::a");

            Step = 7; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickSubDepartemenDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");

            Step = 15; // Klik [Close]
            await App.Click("//button[@title='Close']");

            Step = 7; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
            jam.Stop();
            frm.Logs("P", Proses, LblError.Length > 0 ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };

         }
         catch (Exception ex)
         {
            jam.Stop();
            frm.FAILED++;
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task BugSubItemFrom()
      {
         var Proses = "Item - Bug Sub Item From (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 3; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 4; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "HDD King Ston 500GB");

            Step = 5; // Klik (Type)
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 6; // Klik COGS
            await App.ClickFilter("//label[text()='*HPP']/../a");

            Step = 7; // Klik Sub Department
            await App.ClickBtn("//label[@title='Sub Item Dari']/following-sibling::a");

            Step = 8; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 9; // Set hasil
            jam.Stop();
            frm.Logs("P", Proses, LblError.Length > 0 ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };

         }
         catch (Exception ex)
         {
            jam.Stop();
            frm.FAILED++;
            frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task Create()
      {
         var Proses = "Item - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Bkode']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "HDD King Ston 500GB");

            Step = 4; // Klik (Type)
            await App.ClickFilter("//label[text()='*Jenis']/../a");

            Step = 5; // Klik COGS
            await App.ClickFilter("//label[text()='*HPP']/../a");

            Step = 6; // Klik Save
            await App.Click("//div[contains(@class, 'save-and-close-button')]");

            Step = 16; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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
         var Proses = "Item - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = "Item - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@Name='Bnama']", "Update");

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
   }
}
