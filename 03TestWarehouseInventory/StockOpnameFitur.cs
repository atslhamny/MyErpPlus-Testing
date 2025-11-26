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
   public class StockOpnameFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Stock Opname Fitur - Transaction No (Positive)
            if (frm.IsStopped) return;
            await TransactionNo();

            Step = 2; // Stock Opname Fitur - Status (Positive)
            if (frm.IsStopped) return;
            await Status();

            Step = 3; // Stock Opname Fitur - Search Description (Positive)
            if (frm.IsStopped) return;
            await Description();

            Step = 4; // Stock Opname Fitur - Search Note (Positive)
            if (frm.IsStopped) return;
            await SearchNote();

            Step = 5; // Stock Opname Fitur - Action Draft (Positive)
            if (frm.IsStopped) return;
            await ActionDraft();

            Step = 6; // // Stock Opname Fitur - Action Close (Positive)
            if (frm.IsStopped) return;
            await ActionClose();

            Step = 7; //// Stock Opname Fitur - Action Jurnal Voucher (Positive)
            if (frm.IsStopped) return;
            await ActionJurnalVoucher();

            Step = 8; // // Stock Opname Fitur - Action Related Transaction (Positive)
            if (frm.IsStopped) return;
            await ActionRelatedTransaction();

            Step = 11; // // Stock Opname Fitur - Action Delete (Positive)
            if (frm.IsStopped) return;
            await ActionDelete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Stock Opname - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Stock Opname - Fitur Selesai");
         }
      }
      public async Task TransactionNo()
      {
         var Proses = "Stock Opname Fitur - Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Spnotransaksi']", "LSP22100002");

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
         var Proses = "Stock Opname Fitur - Status (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
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

      public async Task Description()
      {
         var Proses = "Stock Opname Fitur - Transaction No (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Spuraian']", "Coba");

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
         var Proses = "Stock Opname Fitur - Search Note (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Spcatatan']", "test");

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
         var Proses = "Stock Opname Fitur - Action Draft (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
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
         var Proses = "Stock Opname Fitur - Action Close (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
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
         var Proses = "Stock Opname Fitur - Action Jurnal Voucher (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
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
         var Proses = "Stock Opname Fitur - Action Related Transaction (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
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
         var Proses = "Stock Opname Fitur - Action Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sp?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_Inventory_M3SpGrid0_QuickFilter_Sptgl']");
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
