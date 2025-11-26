using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestFinance
{
   public class BankReceipt
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Bank Receipt - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Bank Receipt - Insert - Received From Blank (Negative)
            if (frm.IsStopped) return;
            await ReceivedFrom();

            Step = 3; // Bank Receipt - Insert - TrsDetail Blank (Negative)
            if (frm.IsStopped) return;
            await TrsDetailBlank();

            Step = 4; // Bank Receipt - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 5; // Bank Receipt - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            //Step = 6;
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 7;
            //if (frm.IsStopped) return;
            //await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Bank Receipt step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Bank Receipt Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Bank Receipt - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Finance/M2Rm?md')]/span");
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

      public async Task ReceivedFrom()
      {
         var Proses = "Bank Receipt - Insert - Received From Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Payment Method
            await App.ClickBtn("//span[text()=' Credit']");

            Step = 3; //Input Received From
            await App.ClickBtn("//label[@title='Nama Rekening']/following-sibling::a");

            Step = 4; // Klik [CoA No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Input [Quantity]
            await App.InputData("//input[@name='Jumlah']", "3");

            Step = 6; // Klik [save Credit]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 7; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 8; // Klick Close [X]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 9;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 15; // Set hasil
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
      public async Task TrsDetailBlank()
      {
         var Proses = "Bank Receipt - Insert - TrsDetail Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Payment Method
            await App.ClickBtn("//label[@title='Terima Dari']/following-sibling::a");

            Step = 4; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 6; // Klik [X]
            await App.ClickBtn("//button[text()='OK']");

            Step = 7; // Klick [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 8; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 9; // Set hasil
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
         var Proses = "Bank Receipt - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Payment Method
            await App.ClickBtn("//label[@title='Terima Dari']/following-sibling::a");

            Step = 3; //Input Received From
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 4; // Klik Value
            await App.ClickBtn("//span[text()=' Credit']");

            Step = 5; // Klik Bank Account 
            await App.ClickBtn("//label[@title='Nama Rekening']/following-sibling::a");

            Step = 6; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Input Desc
            await App.InputData("//input[@name='Jumlah']", "100000");

            Step = 8; // Input [Catatan]
            await App.InputData("//input[@name='Catatan']", "test");

            Step = 9; // Klik [save Credit]
            await App.Click("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

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
         var Proses = "Bank Receipt - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 3; // Read
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
         var Proses = "Bank Receipt - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Name 
            await App.InputData("//input[@name='Rmuraian']", "Update");

            Step = 2; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

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
      //   var Proses = "Cash Receipt - Delete (Positive)"; frm.UpdateStatus(Proses);
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
