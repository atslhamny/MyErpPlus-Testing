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
   public class AssetCategoryTaxFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Asset Category tax Fitur - Search Code (Positive)
            if (frm.IsStopped) return;
            await SearchCode();

            Step = 2; // Asset Category tax Fitur - Search Nama (Positive)
            if (frm.IsStopped) return;
            await SearchNama();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Asset Category tax - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Asset Category tax - Fitur Selesai");
         }
      }
      public async Task SearchCode()
      {
         var Proses = "Asset Category tax Fitur - Search Code (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_FixedAsset_M7AssetCategoryTaxGrid0_QuickFilter_Actkode']", "121");

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
         var Proses = "Asset Category tax Fitur - Search Nama (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [Reset]
            await App.ClickBtn("//div[contains(@class, 'btn-reset')]");

            Step = 2; // Input [Search Nama]
            await App.InputSearch("//input[@id='Myerpplus_FixedAsset_M7AssetCategoryTaxGrid0_QuickFilter_Actnama']", "Bangunan");

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
