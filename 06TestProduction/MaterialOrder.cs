using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestProduction
{
   public class MaterialOrder
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

            Step = 4;
            if (frm.IsStopped) return;
            await Insert();

            Step = 5;
            if (frm.IsStopped) return;
            await UpdateDetail();

            Step = 6;
            if (frm.IsStopped) return;
            await UpdateMaterial();

            Step = 2;
            if (frm.IsStopped) return;
            await DraftLangsung();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Material Order step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Material Order Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Material Order - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Pdr?md')]/span");
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

      public async Task DraftLangsung()
      {
         var Proses = "Material Order - Insert - Draft Langsung (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Data
            await App.Click("//div[@class='slick-cell l0 r0']/a");

            Step = 2; // Klik Draft
            await App.ClickBtn("//li[@id='btnActDraft']");

            Step = 3; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//span[text()='Alert']");

            Step = 4; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };

            Step = 5; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 6; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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
         var Proses = "Material Order - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            //Step = 2; // Klik ProductionType
            //await App.ClickBtn("//label[@title='Jenis Produksi']/following-sibling::a");

            //Step = 3; //Klik Value
            //await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickProduksiKategoriDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 4; // Klik Status
            await App.ClickBtn("//label[text()='*Status']/../a");

            Step = 4; // Klik Draft
            await App.ClickDropdown("//div[contains(@id, 'select2')][text()='Draft']");

            Step = 5; // Klik Result Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 6; // Klik Item Code
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 7; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][8]");

            Step = 8; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 9; // Klik Material Detail
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 10; // Klik Item Code 
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 11; // Klik Value
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][7]");

            Step = 12; // Input Harga
            await App.InputData("//input[@name='Harga']", "10000");

            Step = 13; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 14; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 15; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 16; // Klik [<]
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
      public async Task UpdateDetail()
      {
         var Proses = "Material Order - Update Detail (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Read
            await App.Click("//div[@class='slick-cell l0 r0']/a");

            Step = 2; // Klik Result Detail
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Item Code
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 4; // Klik Value HVS
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][8]");

            Step = 5; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 6; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 15; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 16; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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

      public async Task UpdateMaterial()
      {
         var Proses = "Material Order - Update Material (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Read
            await App.Click("//div[@class='slick-cell l0 r0']/a");

            Step = 2; // Klik Material Detail
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Item Code
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 4; // Klik Value HVS
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][7]");

            Step = 12; // Input Harga
            await App.InputData("//input[@name='Harga']", "10000");

            Step = 5; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 6; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 15; // Klik [Close]
            await App.ClickBtn("//button[@title='Close']");

            Step = 16; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

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
