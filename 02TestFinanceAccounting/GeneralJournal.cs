using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestFinance
{
   public class GeneralJournal
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // General Journal - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // General Journal - Insert - Contact Blank (Negative)
            if (frm.IsStopped) return;
            await ContactBlank();

            Step = 3; // General Journal - Insert - Detail Blank (Negative)
            if (frm.IsStopped) return;
            await DetailBlank();

            Step = 4; // General Journal - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 5; // General Journal - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 6; // General Journal - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            //Step = 7;
            //if (frm.IsStopped) return;
            //await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $" General Journal step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses  General Journal Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = " General Journal - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Finance/M2Gj?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klik [Ok]
            await App.ClickBtn("//button[text()='OK']");

            Step = 5; // Klick [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 6; // Apa Ada Label Erro?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
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
         var Proses = " General Journal - Insert - Contact Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [+Add...]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Search Account No.]
            await App.ClickBtn("//label[@title='No Rek']/following-sibling::a");

            Step = 4; // Klik [Account No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Input [Debit]
            await App.InputData("//input[@name='Debit']", "250000");

            Step = 6; // Klick [Save debit]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 7; // Klik [Search Account No.]
            await App.ClickBtn("//label[@title='No Rek']/following-sibling::a");

            Step = 8; // Klik [Account No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 9; // Input [credit]
            await App.InputData("//input[@name='Kredit']", "250000");

            Step = 10; // Klick [Save Kredit]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 11; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 12; // Klick [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 13; // Klick [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 14;
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
      public async Task DetailBlank()
      {
         var Proses = " General Journal - Insert - Detail Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Kliki [search contact]
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 3; // Klik [contact]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klick [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klik [Ok]
            await App.ClickBtn("//button[text()='OK']");

            Step = 6; // Klick [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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
         var Proses = " General Journal - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Kliki [search contact]
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 3; // Klik [contact]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik [+Add...]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik [Search Account No.]
            await App.ClickBtn("//label[@title='No Rek']/following-sibling::a");

            Step = 6; // Klik [Account No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Input [Debit]
            await App.InputData("//input[@name='Debit']", "250000");

            Step = 8; // Klick [Save debit]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 9; // Klik [Search Account No.]
            await App.ClickBtn("//label[@title='No Rek']/following-sibling::a");

            Step = 10; // Klik [Account No.]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 11; // Input [credit]
            await App.InputData("//input[@name='Kredit']", "250000");

            Step = 12; // Klick [Save Kredit]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 13; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 14; // Klick [Save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 15; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 16; // Klick [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 17; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 18; // Set hasil
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
         var Proses = " General Journal - Read (Positive)"; frm.UpdateStatus(Proses);
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
         var Proses = " General Journal - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Name 
            await App.InputData("//input[@name='Gjuraian']", "Update");

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
   }
}
