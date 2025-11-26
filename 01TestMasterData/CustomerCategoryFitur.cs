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
   public class CustomerCategoryFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Customer Category  Fitur - Search Code (Positive)
            if (frm.IsStopped) return;
            await SearchCode();

            Step = 2; // Customer Category  Fitur - Search Name (Positive)
            if (frm.IsStopped) return;
            await SearchNama();

            Step = 3; // Customer Category  Fitur - Search Note (Positive)
            if (frm.IsStopped) return;
            await SearchNote();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Customer Category  - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Customer Category  - Fitur Selesai");
         }
      }
      public async Task SearchCode()
      {
         var Proses = "Customer Category  Fitur - Search Code (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Master_M1CustomerCategoryGrid0_QuickFilter_Cckode']", "DK");

            Step = 2;
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");

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
         var Proses = "Customer Category  Fitur - Search Nama (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Nama]
            await App.InputSearch("//input[@id='Myerpplus_Master_M1CustomerCategoryGrid0_QuickFilter_Ccnama']", "LUAR");

            Step = 2; // Hapus [Search Nama]
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");

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
         var Proses = "Customer Category  Fitur - Search Note (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Note]
            await App.InputSearch("//input[@id='Myerpplus_Master_M1CustomerCategoryGrid0_QuickFilter_Cccatatan']", "cata");

            Step = 2; // Hapus [Search Note]
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");
            await page.Keyboard.PressAsync("Backspace");

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
