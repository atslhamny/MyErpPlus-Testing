using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester._02TestFinanceAccounting
{
   public class BankReceiptFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Bank Receipt Fitur - Transaction No (Positive)
            if (frm.IsStopped) return;
            await BugTransactionNo();

            Step = 2; // Bank Receipt Fitur - Status (Positive)
            if (frm.IsStopped) return;
            await Status();

            Step = 3; // Bank Receipt Fitur - Search Contact (Positive)
            if (frm.IsStopped) return;
            await SearchContact();   
            
            Step = 4; // Bank Receipt Fitur - Search Payment Method (Positive)
            if (frm.IsStopped) return;
            await PaymentMethod();

            Step = 5; // Bank Receipt Fitur - Search Description (Positive)
            if (frm.IsStopped) return;
            await Description();

            Step = 6; // Bank Receipt Fitur - Search Note (Positive)
            if (frm.IsStopped) return;
            await SearchNote();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Bank Receipt - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Bank Receipt - Fitur Selesai");
         }
      }
      public async Task BugTransactionNo()
      {
         var Proses = "Bank Receipt Fitur - Bug Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            //Step = 1; // Navigasi Menu
            //var Menu = await page.XPathAsync("//a[contains(@href, '/Finance/M2Cr?md')]/span");
            //if (Menu.Length > 0)
            //   await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            //await Task.Delay(5000);

            //var xDate = await page.WaitForXPathAsync("//input[contains(@class,'tgl1')]");
            //if (xDate != null)
            //{
            //   await xDate.SetNodeValueAsync("");
            //}

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Finance_M2RmGrid0_QuickFilter_Rmnotransaksi']", "LRM22100046");

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

      public async Task Status()
      {
         var Proses = "Bank Receipt Fitur - Status (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Reset
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            Step = 2; // Klik Status
            await App.ClickBtn("//div[@id='s2id_Myerpplus_Finance_M2RmGrid0_QuickFilter_Rmstatus']//a[contains(@class, 'select2-choice')]");

            Step = 3;
            await App.Click("//div[contains(@class, 'select2-result')][text()='Draft']");

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

      public async Task SearchContact()
      {
         var Proses = "Bank Receipt Fitur - Search Pay To (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Reset
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            Step = 2; // Klik Search Pay To
            await App.ClickBtn("//input[@id='rmkontaknama']/following-sibling::button//i[contains(@class, 'fa fa-search text-blue')]");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

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

      public async Task PaymentMethod()
      {
         var Proses = "Bank Receipt Fitur - PaymentMethod (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Reset
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            Step = 2; // Klik Status
            await App.ClickBtn("//div[@id='s2id_Myerpplus_Finance_M2RmGrid0_QuickFilter_Rmcarabayar']//a[contains(@class, 'select2-choice')]");

            Step = 3;
            await App.Click("//div[contains(@class, 'select2-result')][text()='Check / Giro']");

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

      public async Task Description()
      {
         var Proses = "Bank Receipt Fitur - Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Reset
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            Step = 2; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Finance_M2RmGrid0_QuickFilter_Rmuraian']", "coba");

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

      public async Task SearchNote()
      {
         var Proses = "Bank Receipt Fitur - Search Note (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Reset
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            Step = 2; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Finance_M2RmGrid0_QuickFilter_Rmcatatan']", "test");

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
