using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestFinance
{
   public class BeginningBalance
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // BeginningBalance - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // BeginningBalance - Insert - Contact Blank (Negative)
            if (frm.IsStopped) return;
            await ContactBlank();

            Step = 3; // BeginningBalance - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            Step = 4; // BeginningBalance - Read (Positive)
            if (frm.IsStopped) return;
            await Read();

            Step = 5; // BeginningBalance - Update (Positive)
            if (frm.IsStopped) return;
            await Update();

            //Step = 7;
            //if (frm.IsStopped) return;
            //await Delete();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $" BeginningBalance step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses  BeginningBalance Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = " BeginningBalance - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Finance/M2Cb?md')]/span");
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
      public async Task ContactBlank()
      {
         var Proses = " BeginningBalance - Insert - Contact Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik CoA 
            await App.ClickBtn("//label[@title='Nama Akun']/following-sibling::a");

            Step = 4; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Input Debit
            await App.InputData("//Input[@name='Debit']", "200000");

            Step = 6; // Klick Save
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 7; // Klik Giro
            await App.ClickBtn("//a[text()='Giro']");

            Step = 8; // Klik Add Giro
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 9; // Klik Giro Type
            await App.ClickDropdown("//label[text()='*Jenis Giro']/../a");

            Step = 10; // Klik Coa 
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

            Step = 11; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 12; // Klik Bank
            await App.ClickDropdown("//label[text()='*Bank']/../a");

            Step = 13; // Input Total 
            await App.InputData("//Input[@Name='Jumlah']", "200000");

            Step = 14; // Input No Bank 
            var rand = new RandomGenerator().RandomString(7);
            await App.InputData("//input[@name='Noacbank']", $"{rand}");

            Step = 15; // Input No Giro
            var rand1 = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Nogiro']", $"{rand1}");

            Step = 16; // Klick Save
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 17; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 18; // Klik [X]
            await App.ClickBtn("//button[text()='OK']");

            Step = 19; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

            Step = 20; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 21; // Set hasil
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
         var Proses = " BeginningBalance - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik Kontak 
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 3; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Finance_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 5; // Klik CoA 
            await App.ClickBtn("//label[@title='Nama Akun']/following-sibling::a");

            Step = 6; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 7; // Input Debit
            await App.InputData("//Input[@name='Debit']", "200000");

            Step = 8; // Klick Save
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 9; // Klik Giro
            await App.ClickBtn("//a[text()='Giro']");

            Step = 10; // Klik Add Giro
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 11; // Klik Giro Type
            await App.ClickDropdown("//label[text()='*Jenis Giro']/../a");

            Step = 12; // Klik Coa 
            await App.ClickBtn("//label[@title='No Akun']/following-sibling::a");

            Step = 13; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickCoaDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 14; // Klik Bank
            await App.ClickDropdown("//label[text()='*Bank']/../a");

            Step = 15; // Input Total 
            await App.InputData("//Input[@Name='Jumlah']", "200000");

            Step = 16; // Input No Bank 
            var rand = new RandomGenerator().RandomString(7);
            await App.InputData("//input[@name='Noacbank']", $"{rand}");

            Step = 17; // Input No Giro
            var rand1 = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@name='Nogiro']", $"{rand1}");

            Step = 18; // Klick Save
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 19; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 20; // Klick [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 21; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 22; // Set hasil
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
         var Proses = " BeginningBalance - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 2; // Klick Close [<]
            await App.ClickBtn("//button[@class='panel-titlebar-close']");

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
         var Proses = " BeginningBalance - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Name 
            await App.InputData("//input[@name='Catatan']", "Update");

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
      //   var Proses = " BeginningBalance - Delete (Positive)"; frm.UpdateStatus(Proses);
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
