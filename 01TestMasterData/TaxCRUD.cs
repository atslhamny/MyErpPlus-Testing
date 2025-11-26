using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class TaxCRUD
   {
      FrmMain frm = App.FrmMain;
      WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Tax - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Tax - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Tax - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Tax - Insert - Purchase Tax Blank (Negative)
            if (frm.IsStopped) return;
            await PurchaseTaxBlank();

            Step = 5; // Tax - Insert - Sales Tax Blank (Negative)
            if (frm.IsStopped) return;
            await SalesTaxBlank();

            Step = 6; // Tax - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 7; // Tax - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 8; // Tax - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 9; // Tax - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Tax - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Tax - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Tax - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var menu = await page.XPathAsync("//a[contains(@href, 'M1Tax?md')]/span");
            if (menu.Length > 0)
               await menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik Close [X]
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
         var Proses = "Tax - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.Click("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Nama]
            await App.InputData("//input[@Name='Tnama']", "ABC");

            Step = 3; // Input [Nilai]
            await App.InputData("//input[@Name='Tnilai']", "12");

            Step = 4; // Klik [Akun Pajak Beli]
            await App.ClickBtn("//label[@title='Akun Pajak Beli']/following-sibling::a");

            Step = 5; // Klik [Debit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // Klik [Akun Pajak Jual]
            await App.ClickBtn("//label[@title='Akun Pajak Jual']/following-sibling::a");

            Step = 7; // Klik [Credit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 8; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 9; // Klik Close [X] 
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 10; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 11; // Set hasil
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
         var Proses = "Tax - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Tkode']", $"{rand}");

            Step = 3; // Input [Value]
            await App.InputData("//input[@Name='Tnilai']", "12");

            Step = 4; // Klik Akun Pajak Beli
            await App.ClickBtn("//label[@title='Akun Pajak Beli']/following-sibling::a");

            Step = 5; // Klik [Debit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; //
            await App.ClickBtn("//label[@title='Akun Pajak Jual']/following-sibling::a");

            Step = 7; // Klik [Credit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 8; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 9; // Klik Close [X] 
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 10; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 11; // Set hasil
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

      public async Task PurchaseTaxBlank()
      {
         var Proses = "Tax - Insert - Purchase Tax Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Code]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Tkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@Name='Tnama']", "ABC");

            Step = 4; // Input [Nama]
            await App.InputData("//input[@Name='Tnilai']", "12");

            Step = 5; // Klik [Akun Pajak Jual]
            await App.ClickBtn("//label[@title='Akun Pajak Jual']/following-sibling::a");

            Step = 6; // Klik [Credit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 8; // Klik Close [X] 
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 9; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 10; // Set hasil
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

      public async Task SalesTaxBlank()
      {
         var Proses = "Tax - Insert - Sales Tax Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Code]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Tkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@Name='Tnama']", "ABC");

            Step = 4; // Input [Nama]
            await App.InputData("//input[@Name='Tnilai']", "12");

            Step = 5; //
            await App.ClickBtn("//label[@title='Akun Pajak Beli']/following-sibling::a");

            Step = 6; // Klik  Account
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 8; // Klik Close [X] 
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 9; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 10; // Set hasil
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
         var Proses = "Tax - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Code]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Tkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@Name='Tnama']", "ABC");

            Step = 4; // Input [Nama]
            await App.InputData("//input[@Name='Tnilai']", "12");

            Step = 5; // Klik Akun Pajak Beli
            await App.ClickBtn("//label[@title='Akun Pajak Beli']/following-sibling::a");

            Step = 6; // Klik [Debit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // Klik Akun Pajak Jual
            await App.ClickBtn("//label[@title='Akun Pajak Jual']/following-sibling::a");

            Step = 8; // Klik [Credit Account]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 9; //Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 10; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 11; // Set hasil
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
         var Proses = "Tax - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik  Value
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
         var Proses = "Tax - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@Name='Tnama']", "Update");

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
         var Proses = "Tax - Delete (Positive)"; frm.UpdateStatus(Proses);
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

            Step = 4;
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
