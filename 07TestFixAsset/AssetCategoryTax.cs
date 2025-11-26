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
   public class AssetCategoryTax
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Asset Category Tax - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Asset Category Tax - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Asset Category Tax - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Asset Category Tax - Insert - Depreciation Method Blank (Negative)
            if (frm.IsStopped) return;
            await DepreciationMethodBlank();

            Step = 5; // Asset Category Tax - Insert (Postitive)
            if (frm.IsStopped) return;
            await Insert();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Asset Category Tax - CRUD step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Asset Category Tax - CRUD Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Asset Category Tax - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/FixedAsset/M7AssetCategoryTax?md')]/span");
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
         var Proses = "Asset Category Tax - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; //Input Name
            await App.InputData("//input[@name='Actnama']", "BANGUNAN");

            Step = 3; // Klik [Search Depreciation Method]
            await App.ClickBtn("//label[@title='Metode Penyusutan']/following-sibling::a");

            Step = 4; // Klik [Depreciation Method]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriPenyusutanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 5; //Input Economical Age
            await App.InputData("//input[@name='Actumur']", "20");

            Step = 6; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 7; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 8;
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
      public async Task NameBlank()
      {
         var Proses = "Asset Category Tax - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Actkode']", $"{rand}");

            Step = 3; // Klik [Search Depreciation Method]
            await App.ClickBtn("//label[@title='Metode Penyusutan']/following-sibling::a");

            Step = 4; // Klik [Depreciation Method]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriPenyusutanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 5; //Input Economical Age
            await App.InputData("//input[@name='Actumur']", "20");

            Step = 6; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 7; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

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

      public async Task DepreciationMethodBlank()
      {
         var Proses = "Asset Category Tax - Depreciation Method Blank(Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Actkode']", $"{rand}");

            Step = 3; //Input Name
            await App.InputData("//input[@name='Actnama']", "BANGUNAN");

            Step = 4; //Input Economical Age
            await App.InputData("//input[@name='Actumur']", "20");

            Step = 5; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 6; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

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

      public async Task Insert()
      {
         var Proses = "Asset Category Tax - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input code
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Actkode']", $"{rand}");

            Step = 3; //Input Name
            await App.InputData("//input[@name='Actnama']", "BANGUNAN");

            Step = 4; // Klik [Search Depreciation Method]
            await App.ClickBtn("//label[@title='Metode Penyusutan']/following-sibling::a");

            Step = 5; // Klik [Depreciation Method]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickKategoriPenyusutanDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][2]");

            Step = 6; //Input Economical Age
            await App.InputData("//input[@name='Actumur']", "20");

            Step = 7; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 8; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 9; // Set hasil
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
