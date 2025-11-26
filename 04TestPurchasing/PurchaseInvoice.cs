using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestPurchasing
{
   public class PurchaseInvoice
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
            //await DetailBlank();

            Step = 3;
            if (frm.IsStopped) return;
            await Insert();

            //Step = 4;
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 5;
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 7;
            //if (frm.IsStopped) return;
            //await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $" Purchase Invoice step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses  Purchase Invoice Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = " Purchase Invoice - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Purchasing/M4Ri?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klick [<]
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
      public async Task DetailBlank()
      {
         var Proses = " Purchase Invoice - Insert -  Detail Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Supplier
            await App.ClickBtn("//label[@title='Supplier']/following-sibling::a");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [Ok]
            await App.ClickBtn("//button[text()='OK']");

            Step = 6; // Klick Close [<]
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
         var Proses = " Purchase Invoice - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Supplier
            await App.ClickBtn("//label[@title='Supplier']/following-sibling::a");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik Item Name
            await App.ClickBtn("//label[@title='Nama Barang']/following-sibling::a");

            Step = 6; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Input Price
            await App.InputData("//input[@name='Harga']", "100000");

            Step = 8; // Klick Save
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 9; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 10; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 11; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 12; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 13; // Set hasil
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
         var Proses = " Purchase Invoice - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = " Purchase Invoice - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Name 
            await App.InputData("//input[@name='Riuraian']", "Update");

            Step = 2; // Klick Save
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

      //public async Task Delete()
      //{
      //   var Proses = " Purchase Invoice - Delete (Positive)"; frm.UpdateStatus(Proses);
      //   Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
      //   int Step = 0;
      //   try
      //   {
      //      Step = 1; // Klick Value
      //      await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

      //      Step = 2; // Klick Delete 
      //      await App.ClickBtn("//i[contains(@class, 'trash')]/..");

      //      Step = 3; // Klick Ya Pop Up
      //      await App.ClickBtn("//button[text()='Yes']"); ;

      //      Step = 4;
      //      var LblError = await page.XPathAsync("//div[contains(text(), 'Data tidak bisa dihapus kerena ada transaksi terkait.')]");

      //      Step = 5; // Set hasil
      //      await App.ClickBtn("//button[text()='OK']");
      //      jam.Stop();
      //      frm.Logs("P", Proses, LblError.Length > 0 ? "FAILED" : "PASS", jam.ElapsedMilliseconds);
      //      if (LblError.Length > 0) { frm.FAILED++; } else { frm.PASS++; };
      //   }
      //   catch (Exception ex)
      //   {
      //      frm.FAILED++;
      //      jam.Stop();
      //      frm.Logs("P", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
      //   }
      //}
   }
}
