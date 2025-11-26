using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestFinance
{
   public class CashDisbursements
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Cash Disbursements -Insert - All Blank(Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Cash Disbursements - Insert - Pay To Blank (Negative)
            if (frm.IsStopped) return;
            await PayToBlank();

            Step = 3; // Cash Disbursements - Insert - Debit Blank (Negative)
            if (frm.IsStopped) return;
            await DebitBlank();

            Step = 4; // Cash Disbursements - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 5; // Cash Disbursements - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            //Step = 6;
            //if (frm.IsStopped) return;
            //await Update();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Cash Disbursements step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Cash Disbursements Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Cash Disbursements - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Finance/M2Cd?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 5; // Apa Ada Label Erro?
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

      public async Task PayToBlank()
      {
         var Proses = "Cash Disbursements - Insert - Pay To Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Add Debit ]
            await App.ClickBtn("//span[text()=' Debit']");

            Step = 3; // Klik [Search CoA No.]
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

            Step = 4; // Klik [CoA No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Input [Quantity]
            await App.InputData("//input[@name='Jumlah']", "3");

            Step = 6; // Klik [save Credit]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 7; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 8; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 9;
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
      public async Task DebitBlank()
      {
         var Proses = "Cash Disbursements - Insert - Debit Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Pay To]
            await App.ClickBtn("//label[@title='Bayar Ke']/following-sibling::a");

            Step = 3; // Klik [Pay To]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [X]
            await App.ClickBtn("//button[text()='OK']");

            Step = 6; // Klik [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 7; // Apa Ada Label Error?
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


      public async Task Insert()
      {
         var Proses = "Cash Disbursements - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Pay To]
            await App.ClickBtn("//label[@title='Bayar Ke']/following-sibling::a");

            Step = 3; // Klik [Pay To]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 4; // Klik [Add Debit ]
            await App.ClickBtn("//span[text()=' Debit']");

            Step = 5; // Klik [Search CoA No.]
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

            Step = 6; // Klik [CoA No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 7; // Input [Quantity]
            await App.InputData("//input[@name='Jumlah']", "20000");

            Step = 8; // Input [Catatan]
            await App.InputData("//input[@name='Catatan']", "test");

            Step = 9; // Klik [save Credit]
            await App.Click("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 10; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 11; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 12; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 13; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 14; // Set hasil
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
         var Proses = "Cash Disbursements - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         { 

            Step = 3; // Read
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
         var Proses = "Cash Disbursements - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Name 
            await App.InputData("//input[@name='Cduraian']", "Update");

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
   }
}
