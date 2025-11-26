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
   public class WorkOrderFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Work Order Fitur - Transaction No (Positive)
            if (frm.IsStopped) return;
            await TransactionNo();

            Step = 2; // Work Order Fitur - Status (Positive)
            if (frm.IsStopped) return;
            await Status();

            Step = 3; // Work Order Fitur - Request By (Positive)
            if (frm.IsStopped) return;
            await RequestBy();

            Step = 4; // Work Order Fitur - Action Draft (Positive)
            if (frm.IsStopped) return;
            await ActionDraft();

            Step = 5; // // Work Order Fitur - Action Close (Positive)
            if (frm.IsStopped) return;
            await ActionClose();

            Step = 6; //// Work Order Fitur - Action Jurnal Voucher (Positive)
            if (frm.IsStopped) return;
            await ActionJurnalVoucher();

            Step = 7; // // Work Order Fitur - Action Related Transaction (Positive)
            if (frm.IsStopped) return;
            await ActionRelatedTransaction();

            Step = 8; // // Work Order Fitur - Action Delete (Positive)
            if (frm.IsStopped) return;
            await ActionDelete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Work Order - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Work Order - Fitur Selesai");
         }
      }
      public async Task TransactionNo()
      {
         var Proses = "Work Order Fitur - Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wonotransaksi']", "LWO22100008");

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
         var Proses = "Work Order Fitur - Status (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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

      public async Task RequestBy()
      {
         var Proses = "Work Order Fitur - RequestBy (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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

      public async Task ActionDraft()
      {
         var Proses = "Work Order Fitur - Action Draft (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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
         var Proses = "Work Order Fitur - Action Close (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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
         var Proses = "Work Order Fitur - Action Jurnal Voucher (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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
         var Proses = "Work Order Fitur - Action Related Transaction (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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
         var Proses = "Work Order Fitur - Action Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Wo?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Production_M6WoGrid0_QuickFilter_Wotgl']");
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
