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
   public class SalesInvoiceFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Sales Invoice Fitur - Transaction No (Positive)
            if (frm.IsStopped) return;
            await TransactionNo();

            Step = 2; // Sales Invoice Fitur - Status (Positive)
            if (frm.IsStopped) return;
            await Status();

            Step = 3; // Sales Invoice Fitur - Supplier (Positive)
            if (frm.IsStopped) return;
            await Customer();

            Step = 4; // Sales Invoice Fitur - Search Description (Positive)
            if (frm.IsStopped) return;
            await Description();

            Step = 5; // Sales Invoice Fitur - Search Note (Positive)
            if (frm.IsStopped) return;
            await SearchNote();

            Step = 6; // Sales Invoice Fitur - Action Draft (Positive)
            if (frm.IsStopped) return;
            await ActionDraft();

            Step = 7; //  Sales Invoice Fitur - Action Close (Positive)
            if (frm.IsStopped) return;
            await ActionClose();

            Step = 8; // Sales Invoice Fitur - Action Jurnal Voucher (Positive)
            if (frm.IsStopped) return;
            await ActionJurnalVoucher();

            Step = 9; //  Sales Invoice Fitur - Action Related Transaction (Positive)
            if (frm.IsStopped) return;
            await ActionRelatedTransaction();

            Step = 10; // Sales Invoice Fitur - Action Delete (Positive)
            if (frm.IsStopped) return;
            await ActionDelete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Sales Invoice - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Sales Invoice - Fitur Selesai");
         }
      }
      public async Task TransactionNo()
      {
         var Proses = "Sales Invoice Fitur - Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sinotransaksi']", "LSI22100080");

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
         var Proses = "Sales Invoice Fitur - Status (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Status]
            await App.Click("//a[contains(@class, 'select2-choice')]");

            Step = 3; // Klik [Draft]
            await App.Click("//li/div[text()='Draft']");

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

      public async Task Customer()
      {
         var Proses = "Sales Invoice Fitur - Customer (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik Search Supplier
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[4]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");


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
         var Proses = "Sales Invoice Fitur - Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Siuraian']", "Coba");

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
         var Proses = "Sales Invoice Fitur - Search Note (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sicatatan']", "test");

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

      public async Task ActionDraft()
      {
         var Proses = "Sales Invoice Fitur - Action Draft (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Status]
            await App.Click("//a[contains(@class, 'select2-choice')]");

            Step = 3; // Klik [Draft]
            await App.Click("//li/div[text()='Approved']");

            Step = 4; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");

            Step = 5; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 6; // Klik [Draft]
            await App.Click("//li[@id='btnActDraft']");

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

      public async Task ActionClose()
      {
         var Proses = "Sales Invoice Fitur - Action Close (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Status]
            await App.Click("//a[contains(@class, 'select2-choice')]");

            Step = 3; // Klik [Draft]
            await App.Click("//li/div[text()='Approved']");

            Step = 4; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");

            Step = 5; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 6; // Klik [CloseUnclose]
            await App.Click("//li[@id='btnActCloseUnclose']");

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

      public async Task ActionJurnalVoucher()
      {
         var Proses = "Sales Invoice Fitur - Action Jurnal Voucher (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");

            Step = 3; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 4; // Klik [Jurnal]
            await App.Click("//li[@id='btnActJurnal']");

            Step = 5; // Klik [Cancel]
            await App.Click("//button[text()='Cancel']");

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

      public async Task ActionRelatedTransaction()
      {
         var Proses = "Sales Invoice Fitur - Action Related Transaction (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");

            Step = 3; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 4; // Klik [Related]
            await App.Click("//li[@id='btnActTransaksiTerkait']");

            Step = 5; // Klik [Ok]
            await App.Click("//button[text()='OK']");

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

      public async Task ActionDelete()
      {
         var Proses = "Sales Invoice Fitur - Action Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Sales_M5SiGrid0_QuickFilter_Sitgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Status]
            await App.Click("//a[contains(@class, 'select2-choice')]");

            Step = 3; // Klik [Draft]
            await App.Click("//li/div[text()='Draft']");

            Step = 4; // Klik [Data]
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");

            Step = 5; // Klik [Action]
            await App.ClickBtn("//span[text()=' Action']");

            Step = 6; // Klik [Delete]
            await App.Click("//li[@id='btnActDelete']");

            Step = 6; // Klik [Yes]
            await App.Click("//button[text()='Yes']");

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
