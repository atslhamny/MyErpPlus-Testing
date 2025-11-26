using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class TermsCRUD
   {
      FrmMain frm = App.FrmMain;
      WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Terms - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Terms - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Terms - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4;// Terms - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            Step = 5; // Terms - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 6; // Terms - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 7; // Terms - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Terms - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Terms - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Terms - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var menu = await page.XPathAsync("//a[contains(@href, 'M1Terms')]/spann");
            if (menu.Length > 0)
               await menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New....]
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
         var Proses = "Terms - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Terms')]/span");

            Step = 2; // Klik [New....]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Trnama']", "Divisi20");

            Step = 4; // Input [Discount1]
            await App.InputData("//input[@name='Trdiskon1']", "1");

            Step = 5; // Input [Discount2]
            await App.InputData("//input[@name='Trdiskon2']", "2");

            Step = 6; // Input [Discount Day1]
            await App.InputData("//input[@name='Trharidiskon1']", "1");

            Step = 7; // Input [Discount Day2]
            await App.InputData("//input[@name='Trharidiskon2']", "2");

            Step = 8; // Input [Forfeit]
            await App.InputData("//input[@name='Trdenda']", "3");

            Step = 9; // Input [Maturity]
            await App.InputData("//input[@name='Trharijatuhtempo']", "3");

            Step = 10; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 11; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 12; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 13; // Set hasil
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
         var Proses = "Terms - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            await App.ClickBtn("//a[contains(@href, 'M1Terms')]/span");

            Step = 2; // Klik [New....]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Input [Kode]
            await App.InputData("//input[@name='Trkode']", "D46");

            Step = 4; // Input [Discount1]
            await App.InputData("//input[@name='Trdiskon1']", "1");

            Step = 5; // Input [Discount2]
            await App.InputData("//input[@name='Trdiskon2']", "2");

            Step = 6; // Input [Discount Day1]
            await App.InputData("//input[@name='Trharidiskon1']", "1");

            Step = 7; // Input [Discount Day2]
            await App.InputData("//input[@name='Trharidiskon2']", "2");

            Step = 8; // Input [Forfeit]
            await App.InputData("//input[@name='Trdenda']", "3");

            Step = 9; // Input [Maturity]
            await App.InputData("//input[@name='Trharijatuhtempo']", "3");

            Step = 10; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 11; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 12; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 13; // Set hasil
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
         var Proses = "Terms - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New....]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Kode
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Trkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Trnama']", "Divisi20");

            Step = 4; // Input [Discount1]
            await App.InputData("//input[@name='Trdiskon1']", "1");

            Step = 5; // Input [Discount2]
            await App.InputData("//input[@name='Trdiskon2']", "2");

            Step = 6; // Input [Discount Day1]
            await App.InputData("//input[@name='Trharidiskon1']", "1");

            Step = 7; // Input [Discount Day2]
            await App.InputData("//input[@name='Trharidiskon2']", "2");

            Step = 8; // Input [Forfeit]
            await App.InputData("//input[@name='Trdenda']", "3");

            Step = 9; // Input [Maturity]
            await App.InputData("//input[@name='Trharijatuhtempo']", "3");

            Step = 10; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 11; // Apa ada label error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 12; // Set hasil
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
         var Proses = "Terms - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = "Terms - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Trnama']", "Update");

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
         var Proses = "Terms - Delete (Positive)"; frm.UpdateStatus(Proses);
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
