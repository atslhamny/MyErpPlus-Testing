using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestFinance
{
   public class CashReceipt
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Cash Receipt - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Cash Receipt - Insert - Received Blank (Negative)
            if (frm.IsStopped) return;
            await ReceivedBlank();

            Step = 3; // Cash Receipt - Insert - Detail Blank (Negative)
            if (frm.IsStopped) return;
            await DetailBlank();

            Step = 4; // Cash Receipt - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 5; // Cash Receipt - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            //Step = 6;
            //if (frm.IsStopped) return;
            //await Update();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Cash Receipt step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Cash Receipt Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Cash Receipt - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Finance/M2Cr?md')]/span");
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

      public async Task ReceivedBlank()
      {
         var Proses = "Cash Receipt - Insert - Received Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Add Credit ]
            await App.ClickBtn("//span[text()=' Credit']");

            Step = 3; // Klik [Search CoA No.]
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

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
      public async Task DetailBlank()
      {
         var Proses = "Cash Receipt - Insert - Detail Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Received From]
            await App.ClickBtn("//label[@title='Terima Dari']/following-sibling::a");

            Step = 3; // Klik [Received From]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [X]
            await App.ClickBtn("//button[text()='OK']");

            Step = 6; // Klick [<]
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
         var Proses = "Cash Receipt - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Search Received From]
            await App.ClickBtn("//label[@title='Terima Dari']/following-sibling::a");

            Step = 3; // Klik [Received From]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 4; // Klik [Add Credit ]
            await App.ClickBtn("//span[text()=' Credit']");

            Step = 5; // Klik [Search CoA No.]
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

            Step = 6; // Klik [CoA No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 7; // Input [Quantity]
            await App.InputData("//input[@name='Jumlah']", "10000");  
            
            Step = 8; // Input [Catatan]
            await App.InputData("//input[@name='Catatan']", "test");

            Step = 9; // Klik [save Credit]
            await App.Click("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 10; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 11; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 12; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

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
         var Proses = "Cash Receipt - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {

            Step = 2; // Read
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
         var Proses = "Cash Receipt - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Name 
            await App.InputData("//input[@name='Cruraian']", "Update");

            Step = 2; // Klik Save
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
   }
}
