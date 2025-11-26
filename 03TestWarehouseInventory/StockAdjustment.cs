using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.WarehouseInventory
{
   public class StockAdjustment
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1;
            if (frm.IsStopped) return;
            await AllBlank();

            //Step = 2;
            //if (frm.IsStopped) return;
            //await ContactBlank();

            //Step = 3;
            //if (frm.IsStopped) return;
            //await AdjustmentTypeBlank();

            //Step = 4;
            //if (frm.IsStopped) return;
            //await DetailBlank();

            Step = 5;
            if (frm.IsStopped) return;
            await Insert();

            //Step = 6;
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 7;
            //if (frm.IsStopped) return;
            //await Update();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Stock Adjustment step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Stock Adjustment Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Stock Adjustment - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Inventory/M3Sa?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 5; // Apa Ada Label Error?
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

      public async Task ContactBlank()
      {
         var Proses = "Stock Adjustment - Insert - Contact Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Adjustment Type]
            await App.ClickBtn("//label[@title='Jenis Penyesuaian']/following-sibling::a");

            Step = 3; // Klik [Adjustment Type]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickTypeDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik [Search Item Code]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 6; // Klik [Item Code]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 8; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 9; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 10;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 11; // Set hasil
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
      public async Task AdjustmentTypeBlank()
      {
         var Proses = "Stock Adjustment - Insert - Adjustment Type Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Contact]
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 3; // Klik [Contact]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik [Search Item Code]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 6; // Klik [Item Code]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 8; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 9; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 10; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 11; // Set hasil
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

      public async Task DetailBlank()
      {
         var Proses = "Stock Adjustment - Insert - Detail Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Contact]
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 3; // Klik [Contact]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [Search Adjustment Type]
            await App.ClickBtn("//label[@title='Jenis Penyesuaian']/following-sibling::a");

            Step = 5; // Klik [Adjustment Type]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickTypeDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 6; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 7; // Klik [Ok]
            await App.ClickBtn("//button[text()='OK']");

            Step = 8; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 9; // Apa Ada Label Error?
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

      public async Task Insert()
      {
         var Proses = "Stock Adjustment - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Contact]
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 3; // Klik [Contact]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [Search Adjustment Type]
            await App.ClickBtn("//label[@title='Jenis Penyesuaian']/following-sibling::a");

            Step = 5; // Klik [Adjustment Type]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickTypeDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 6; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 7; // Klik [Search Item Code]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 8; // Klik [Item Code]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 9; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 10; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 11; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 12; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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
         var Proses = "Stock Adjustment - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 1; // Read
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
         var Proses = "Stock Adjustment - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input [Name ]
            await App.InputData("//input[@name='Sauraian']", "Update");

            Step = 2; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 3; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 4; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

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
