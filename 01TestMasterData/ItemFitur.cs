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
   public class ItemFitur
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Item Fitur - Search Code (Positive)
            if (frm.IsStopped) return;
            await SearchCode();

            Step = 2; // Item Fitur - Search Name (Positive)
            if (frm.IsStopped) return;
            await SearchNama();

            Step = 3; // Item Fitur - Search Supplier (Positive)
            if (frm.IsStopped) return;
            await SearchSupplier();

            Step = 4; // Item Fitur - Status (Positive)
            if (frm.IsStopped) return;
            await Status();

            Step = 5; // Item Fitur - Stok (Positive)
            if (frm.IsStopped) return;
            await Stok();

            Step = 6; // Item Fitur - Search UoM (Positive)
            if (frm.IsStopped) return;
            await SearchUoM();

            Step = 7; // Item Fitur - Search Category (Positive)
            if (frm.IsStopped) return;
            await SearchCategory();

            Step = 8; // Item Fitur - Search Merk (Positive)
            if (frm.IsStopped) return;
            await SearchMerk();

            Step = 9; // Item Fitur - Search Vendor (Positive)
            if (frm.IsStopped) return;
            await SearchVendor();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Item - Fitur step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Item - Fitur Selesai");
         }
      }
      public async Task SearchCode()
      {
         var Proses = "Item Fitur - Search Code (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Code]
            await App.InputSearch("//input[@id='Myerpplus_Master_M1ItemGrid0_QuickFilter_Bkode']", "112");

            Step = 2;
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

      public async Task SearchNama()
      {
         var Proses = "Item Fitur - Search Nama (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Input [Search Nama]
            await App.InputSearch("//input[@id='Myerpplus_Master_M1ItemGrid0_QuickFilter_Bnama']", "Buku");

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
      public async Task SearchSupplier()
      {
         var Proses = "Item Fitur - Search Supplier (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Klik Search Supplier
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[3]/button");

            Step = 2; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");


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
         var Proses = "Item Fitur - Status (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik Status
            await App.ClickFilter("//a[contains(@class, 'select2-choice')]");

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

      public async Task Stok()
      {
         var Proses = "Item Fitur - Stok (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik Stok (Sedikit)
            await App.InputData("//input[@id='Myerpplus_Master_M1ItemGrid0_QuickFilter_Bkode']", "20");

            Step = 3; // Klik Stok (Lebih Banyak)
            await App.InputData("//div[@class= 'quick-filter-item quick-filter-active']/input[2]", "50");


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

      public async Task SearchUoM()
      {
         var Proses = "Item Fitur - Search UoM (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik Search UoM
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[6]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickSatuanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");


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

      public async Task SearchCategory()
      {
         var Proses = "Item Fitur - Search Category (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik Search Category
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[7]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickItemKategoriDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");


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

      public async Task SearchMerk()
      {
         var Proses = "Item Fitur - Search Merk (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik Search Merk
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[8]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickMerkDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][10]");


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

      public async Task SearchVendor()
      {
         var Proses = "Item Fitur - Search Vendor (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi ke Menu
            var Menu = await page.XPathAsync("//a[contains(@href, 'M1Item?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik Search Vendor
            await App.ClickBtn("//div[contains(@class, 'quick-filters-bar')]/div[9]/button");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickVendorDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");


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
