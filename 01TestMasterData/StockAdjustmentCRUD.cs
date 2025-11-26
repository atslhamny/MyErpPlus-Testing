using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class StockAdjustmentCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Stock Adjustment Type - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await BlankInsert();

            Step = 2; // Stock Adjustment Type - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await BlankCode();

            Step = 3; // Stock Adjustment Type - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await BlankName();

            Step = 4; // Stock Adjustment Type - Insert - Account Name Blank (Negative)
            if (frm.IsStopped) return;
            await BlankAccountName();

            Step = 5; // Stock Adjustment Type - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 6; // Stock Adjustment Type - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 7; // Stock Adjustment Type - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 8; // Stock Adjustment Type - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Stock Adjustment - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Stock Adjustment Type - CRUD Selesai");
         }
      }
      public async Task BlankInsert()
      {
         var Proses = "Stock Adjustment Type - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Typesa?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New..]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

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

      public async Task BlankCode()
      {
         var Proses = "Stock Adjustment Type - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input name
            await App.InputData("//input[@name='Tsanama']", "INITESTING");

            Step = 3; //
            await App.ClickBtn("//label[@title='Nama Rekening']/following-sibling::a");

            Step = 4; // Klik Credit Accoutn
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 5; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 6; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

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
      public async Task BlankName()
      {
         var Proses = "Stock Adjustment Type - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input code
            var rand = new RandomGenerator().RandomString(4);
            await App.InputData("//input[@name='Tsakode']", $"{rand}");

            Step = 3; //
            await App.ClickBtn("//label[@title='Nama Rekening']/following-sibling::a");

            Step = 4; // Klik Credit Accoutn
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 5; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 6; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

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
      public async Task BlankAccountName()
      {
         var Proses = "Stock Adjustment Type - Insert - Account Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input code
            var rand = new RandomGenerator().RandomString(4);
            await App.InputData("//input[@name='Tsakode']", $"{rand}");

            Step = 3; // input name
            await App.InputData("//input[@name='Tsanama']", "INITESTING");

            Step = 4; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

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
      public async Task Insert()
      {
         var Proses = "Stock Adjustment Type - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input code
            var rand = new RandomGenerator().RandomString(4);
            await App.InputData("//input[@name='Tsakode']", $"{rand}");

            Step = 3; // input name
            await App.InputData("//input[@name='Tsanama']", "INITESTING");

            Step = 4; //
            await App.ClickBtn("//label[@title='Nama Rekening']/following-sibling::a");

            Step = 5; // Klik Credit Accoutn
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // Klik Save
            await App.ClickBtn("//div[text()='Save']");

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
         var Proses = "Stock Adjustment Type - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = "Stock Adjustment Type - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
           
            Step = 1; // Input Nama
            await App.InputData(" Update", "//input[@name='Tsanama']");

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
         var Proses = "Stock Adjustment Type - Delete (Positive)"; frm.UpdateStatus(Proses);
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
