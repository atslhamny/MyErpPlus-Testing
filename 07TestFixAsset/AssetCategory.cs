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
   public class AssetCategory
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Asset Category - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Asset Category - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Asset Category - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Asset Category - Insert - Groups Of Fixed Blank (Negative)
            if (frm.IsStopped) return;
            await GroupsOfFixedBlank();

            Step = 5; // Asset Category - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Asset Category - CRUD step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Asset Category - CRUD Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Asset Category - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/FixedAsset/M7AssetCategory?md')]/span");
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
         var Proses = "Asset Category - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; //Input Name
            await App.InputData("//input[@name='Acnama']", "BANGUNAN");

            Step = 3; // Klik [Search Groups Of Fixed]
            await App.ClickBtn("//label[@title='Kelompok Aktiva Tetap Pajak']/following-sibling::a");

            Step = 4; // Klik [Groups Of Fixed]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriTaxAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 6; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 7;
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
      public async Task NameBlank()
      {
         var Proses = "Asset Category - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Ackode']", $"{rand}");

            Step = 3; // Klik [Search Groups Of Fixed]
            await App.ClickBtn("//label[@title='Kelompok Aktiva Tetap Pajak']/following-sibling::a");

            Step = 4; // Klik [Groups Of Fixed]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriTaxAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 6; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

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

      public async Task GroupsOfFixedBlank()
      {
         var Proses = "Asset Category - Groups Of Fixed (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Ackode']", $"{rand}");

            Step = 3; //Input Name
            await App.InputData("//input[@name='Acnama']", "BANGUNAN");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 6; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
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
         var Proses = "Asset Category - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Ackode']", $"{rand}");

            Step = 3; //Input Name
            await App.InputData("//input[@name='Acnama']", "BANGUNAN");

            Step = 4; // Klik [Search Groups Of Fixed]
            await App.ClickBtn("//label[@title='Kelompok Aktiva Tetap Pajak']/following-sibling::a");

            Step = 5; // Klik [Groups Of Fixed]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriTaxAsetDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 6; // Klick Save
            await App.Click("//div[text()='Save']");

            Step = 7; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 8; // Set hasil
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
