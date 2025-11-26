using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class LocationCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Location - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await BlankInsert();

            Step = 2; // Location - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await BlankCode();

            Step = 3; // Location - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await BlankName();

            Step = 4; // Location - Insert - Transaction Blank (Negative)
            if (frm.IsStopped) return;
            await BlankTransaction();

            Step = 5; // Location - Insert - Branch Blank (Negative)
            if (frm.IsStopped) return;
            await BlankBranch();

            Step = 6; // Location - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 7; // Location - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 8; // Location - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            Step = 9; // Location - Delete (Positive)
            if (frm.IsStopped) return;
            await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Location - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Location - CRUD Selesai");
         }
      }

      public async Task BlankInsert()
      {
         var Proses = "Location - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke menu
            var menu = await page.XPathAsync("//a[contains(@href, 'M1Location?md')]/span");
            if (menu.Length > 0)
               await menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [[Save]]
            await App.ClickBtn("//div[text()='Save']");

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

      public async Task BlankCode()
      {
         var Proses = "Location - Insert - Blank Code (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input [name]
            await App.InputData("//input[@name='Lnama']", "INI TESTING");

            Step = 3; // input [[transaction code]]
            await App.InputData("//input[@name='Lkodetransaksi']", "432423");

            Step = 4; // Klik [[Search branch]]
            await App.ClickBtn("//label[text()='Branch']/../a");

            Step = 5; // Double [[Klik search branch]]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // input [[wide]]
            await App.InputData("//input[@name='Lluas']", "12");

            Step = 7; // input [[address]]
            await App.InputData("//input[@name='Lalamat1']", "TESTING");

            Step = 8; // input [[city]]
            await App.InputData("//input[@name='Lkota']", "TESTING");

            Step = 9; // input [[Zipcode]]
            await App.InputData("//input[@name='Lkodepos']", "684282");

            Step = 10; // input [[Phone No]]
            await App.InputData("//input[@name='Lnotelp']", "68722981");

            Step = 11; // input [[No Fax]]
            await App.InputData("//input[@name='Lnofax']", "998761");

            Step = 12; // input [[Note]]
            await App.InputData("//textarea[@name='Lcatatan']", "Testing");

            Step = 13; // Klik [[Save]]
            await App.ClickBtn("//div[text()='Save']");

            Step = 14; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 15; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 16; // Set hasil
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

      public async Task BlankName()
      {
         var Proses = "Location - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input [Code]
            await App.InputData("//input[@name='Lkode']", "181735");

            Step = 3; // input [transaction code]
            await App.InputData("//input[@name='Lkodetransaksi']", "432423");

            Step = 4; // Klik [Search branch]
            await App.ClickBtn("//label[text()='Branch']/../a");

            Step = 5; // Double [Klik search branch]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // input [wide]
            await App.InputData("//input[@name='Lluas']", "12");

            Step = 7; // input [address]
            await App.InputData("//input[@name='Lalamat1']", "TESTING");

            Step = 8; // input [city]
            await App.InputData("//input[@name='Lkota']", "TESTING");

            Step = 9; // input [Zipcode]
            await App.InputData("//input[@name='Lkodepos']", "684282");

            Step = 10; // input [Phone No]
            await App.InputData("//input[@name='Lnotelp']", "68722981");

            Step = 11; // input [No Fax]
            await App.InputData("//input[@name='Lnofax']", "998761");

            Step = 12; // input [Note]
            await App.InputData("//textarea[@name='Lcatatan']", "Testing");

            Step = 13; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 14; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 15; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 16; // Set hasil
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
      public async Task BlankTransaction()
      {
         var Proses = "Location - Insert - Transaction Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input [Code]
            await App.InputData("//input[@name='Lkode']", "181735");

            Step = 3; // input name
            await App.InputData("//input[@name='Lnama']", "INI TESTING");

            Step = 4; // Klik [Search branch]
            await App.ClickBtn("//label[text()='Branch']/../a");

            Step = 5; // Double [Klik search branch]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 6; // input [wide]
            await App.InputData("//input[@name='Lluas']", "12");

            Step = 7; // input [address]
            await App.InputData("//input[@name='Lalamat1']", "TESTING");

            Step = 8; // input [city]
            await App.InputData("//input[@name='Lkota']", "TESTING");

            Step = 9; // input [Zipcode]
            await App.InputData("//input[@name='Lkodepos']", "684282");

            Step = 10; // input [Phone No]
            await App.InputData("//input[@name='Lnotelp']", "68722981");

            Step = 11; // input [No Fax]
            await App.InputData("//input[@name='Lnofax']", "998761");

            Step = 12; // input [Note]
            await App.InputData("//textarea[@name='Lcatatan']", "Testing");

            Step = 13; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 14; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 15; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 16; // Set hasil
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
      public async Task BlankBranch()
      {
         var Proses = "Location - Insert - Branch Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input [Code]
            await App.InputData("//input[@name='Lkode']", "181735");

            Step = 3; // input name
            await App.InputData("//input[@name='Lnama']", "INI TESTING");

            Step = 4; // input [transaction code]
            await App.InputData("//input[@name='Lkodetransaksi']", "432423");

            Step = 5; // Klik [Search branch]
            await App.ClickBtn("//label[text()='Branch']/../a");

            Step = 6; // Double [Klik search branch]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // input [wide]
            await App.InputData("//input[@name='Lluas']", "12");

            Step = 8; // input [address]
            await App.InputData("//input[@name='Lalamat1']", "TESTING");

            Step = 9; // input [city]
            await App.InputData("//input[@name='Lkota']", "TESTING");

            Step = 10; // input [Zipcode]
            await App.InputData("//input[@name='Lkodepos']", "684282");

            Step = 11; // input [Phone No]
            await App.InputData("//input[@name='Lnotelp']", "68722981");

            Step = 12; // input [No Fax]
            await App.InputData("//input[@name='Lnofax']", "998761");

            Step = 13; // input [Note]
            await App.InputData("//textarea[@name='Lcatatan']", "Testing");

            Step = 14; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 15; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 16; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 17; // Set hasil
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

      public async Task Insert()
      {
         var Proses = "Location - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // input [Code]
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Lkode']", $"{rand}");

            Step = 3; // input name
            await App.InputData("//input[@name='Lnama']", "INI TESTING");

            Step = 4; // input [transaction code]
            await App.InputData("//input[@name='Lkodetransaksi']", "2344");

            Step = 5; // Klik [Search branch]
            await App.ClickBtn("//label[text()='Branch']/../a");

            Step = 6; // Double [Klik search branch]
            await App.DoubleClick("//div[contains(@id,'Dialog')]//div[contains(@class,'content')]");

            Step = 7; // input [wide]
            await App.InputData("//input[@name='Lluas']", "14");

            Step = 8; // input [address]
            await App.InputData("//input[@name='Lalamat1']", "TESTING");

            Step = 9; // input [city]
            await App.InputData("//input[@name='Lkota']", "TESTING");

            Step = 10; // input [Zipcode]
            await App.InputData("//input[@name='Lkodepos']", "655651");

            Step = 11; // input [Phone No]
            await App.InputData("//input[@name='Lnotelp']", "0813244");

            Step = 12; // input [No Fax]
            await App.InputData("//input[@name='Lnofax']", "00815128742");

            Step = 13; // input [Note]
            await App.InputData("//textarea[@name='Lcatatan']", "Testing");

            Step = 14; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 15; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 16; // Set hasil
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
         var Proses = "Location - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = "Location - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input Nama
            await App.Update(" Update", "//input[@name='Lnama']");

            Step = 2; // Klik [Save]
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
         var Proses = "Location - Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Klik Value
            await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klik Delete Contact
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
