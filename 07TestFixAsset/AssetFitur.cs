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
   public class AssetFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Asset Fitur - Search Code (Positive)
            if (frm.IsStopped) return;
            await SearchCode();

            Step = 2; // Asset Fitur - Search Nama (Positive)
            if (frm.IsStopped) return;
            await SearchNama();

            Step = 3; // Asset Fitur - Kategori (Positive)
            if (frm.IsStopped) return;
            await Kategori();

            Step = 4; // Asset Fitur - Method (Positive)
            if (frm.IsStopped) return;
            await Method();

            Step = 5; // Asset Fitur - Economical Age (Positive)
            if (frm.IsStopped) return;
            await EconomicalAge();

            Step = 6; // Asset Fitur - Search Nama (Positive)
            if (frm.IsStopped) return;
            await Status();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Asset - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Asset - Fitur Selesai");
         }
      }
      public async Task SearchCode()
      {
         var Proses = "Asset Fitur - Search Code (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Atglbeli']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }
            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Akode']", "AGM");

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

      public async Task SearchNama()
      {
         var Proses = "Asset Fitur - Search Nama (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Atglbeli']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Input [Search Nama]
            await App.InputSearch("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Anama']", "Bangunan");

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

      public async Task Kategori()
      {
         var Proses = "Sales Invoice Fitur - Kategori (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Atglbeli']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik Search Supplier
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[4]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");


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

      public async Task Method()
      {
         var Proses = "Sales Invoice Fitur - Method (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Atglbeli']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik Search Supplier
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[5]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriPenyusutanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][1]");


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

      public async Task EconomicalAge()
      {
         var Proses = "Asset Fitur - Economical Age (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Atglbeli']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Input [Search Nama]
            await App.InputSearch("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Aumurekonomis']", "3");

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

            var date = await page.WaitForXPathAsync("//input[@id='Myerpplus_FixedAsset_M7AssetGrid0_QuickFilter_Atglbeli']");
            if (date != null)
            {
               await date.EvaluateFunctionAsync("e => e.value = null");
            }

            Step = 2; // Klik [Status]
            await App.Click("//a[contains(@class, 'select2-choice')]");

            Step = 3; // Klik [Draft]
            await App.Click("//li/div[text()='Progress']");

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
