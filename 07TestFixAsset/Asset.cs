using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebView2.DevTools.Dom;

namespace Tester.TestFixAsset
{
   public class Asset
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Asset  - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Asset - Insert - Code Blank(Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Asset  - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Asset  - Insert - Category Blank (Negative)
            if (frm.IsStopped) return;
            await CategoryBlank();

            Step = 5; // Asset  - Insert  (Positive)
            if (frm.IsStopped) return;
            await Insert();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Asset  - CRUD step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Asset  - CRUD Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Asset  - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/FixedAsset/M7Asset?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 4; // Klick [X]
            await App.ClickBtn("//button[@title='Close']");

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

      public async Task CodeBlank()
      {
         var Proses = "Asset  - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; //Input Name
            await App.InputData("//input[@name='Anama']", "PERLENGKAPAN");

            Step = 3; // Klik [Search UoM]
            await App.ClickBtn("//label[@title='Satuan']/following-sibling::a");

            Step = 4; // Klik [UoM]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickSatuanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 5; // Klik [Search Category]
            await App.ClickBtn("//label[@title='Kategori']/following-sibling::a");

            Step = 6; // Klik [Category]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][5]");

            Step = 7; //Input Acquisition Value 
            await App.InputData("//input[@name='Ahargabeli']", "20000");

            Step = 8; //Input Expenses By Month
            await App.InputData("//input[@name='Abebanperbln']", "10000");

            Step = 9; //Input Accumulated Of Expense
            await App.InputData("//input[@name='Aakumulasibeban']", "10000");

            Step = 10; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 11; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 12;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 13; // Set hasil
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
      public async Task NameBlank()
      {
         var Proses = "Asset  - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Akode']", $"{rand}");

            Step = 3; // Klik [Search UoM]
            await App.ClickBtn("//label[@title='Satuan']/following-sibling::a");

            Step = 4; // Klik [UoM]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickSatuanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 5; // Klik [Search Category]
            await App.ClickBtn("//label[@title='Kategori']/following-sibling::a");

            Step = 6; // Klik [Category]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][5]");

            Step = 7; //Input Acquisition Value 
            await App.InputData("//input[@name='Ahargabeli']", "20000");

            Step = 8; //Input Expenses By Month
            await App.InputData("//input[@name='Abebanperbln']", "10000");

            Step = 9; //Input Accumulated Of Expense
            await App.InputData("//input[@name='Aakumulasibeban']", "10000");

            Step = 10; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 11; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 12; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 13; // Set hasil
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

      public async Task CategoryBlank()
      {
         var Proses = "Asset  - Category Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Akode']", $"{rand}");

            Step = 3; //Input Name
            await App.InputData("//input[@name='Anama']", "PERLENGKAPAN");

            Step = 4; // Klik [Search UoM]
            await App.ClickBtn("//label[@title='Satuan']/following-sibling::a");

            Step = 5; // Klik [UoM]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickSatuanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 6; //Input Acquisition Value 
            await App.InputData("//input[@name='Ahargabeli']", "20000");

            Step = 7; //Input Expenses By Month
            await App.InputData("//input[@name='Abebanperbln']", "10000");

            Step = 8; //Input Accumulated Of Expense
            await App.InputData("//input[@name='Aakumulasibeban']", "10000");

            Step = 9; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 10; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 11; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 12; // Set hasil
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

      public async Task Insert()
      {
         var Proses = "Asset  - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Akode']", $"{rand}");

            Step = 3; //Input Name
            await App.InputData("//input[@name='Anama']", "PERLENGKAPAN");

            Step = 4; // Klik [Search UoM]
            await App.ClickBtn("//label[@title='Satuan']/following-sibling::a");

            Step = 5; // Klik [UoM]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickSatuanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 6; // Klik [Search Category]
            await App.ClickBtn("//label[@title='Kategori']/following-sibling::a");

            Step = 7; // Klik [Category]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 8; //Input Acquisition Value 
            await App.InputData("//input[@name='Ahargabeli']", "20000");

            Step = 9; //Input Expenses By Month
            await App.InputData("//input[@name='Abebanperbln']", "10000");

            Step = 10; //Input Accumulated Of Expense
            await App.InputData("//input[@name='Aakumulasibeban']", "10000");

            Step = 11; // Klick Save
            await App.Click("//div[text()='Save']");

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
   }
}
