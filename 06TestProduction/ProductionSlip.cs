using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;

namespace Tester.TestProduction
{
   public class ProductionSlip
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

            Step = 2;
            if (frm.IsStopped) return;
            await Insert();

            //Step = 3;
            //if (frm.IsStopped) return;
            //await UpdateDraft();       
            
            //Step = 3;
            //if (frm.IsStopped) return;
            //await UpdateMaterial();

         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Production Slip step {Step}", $"FAILED -- {ex.Message}");

         }
         finally
         {
            frm.UpdateStatus("Proses Production Slip Selesai");
         }
      }
      public async Task AllBlank()
      {
         var Proses = "Production Slip - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var Menu = await page.XPathAsync("//a[contains(@href, '/Production/M6Pd?md')]/span");
            if (Menu.Length > 0)
               await Menu[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Save]
            await App.ClickBtn("//div[text()='Save']"); 
            
            Step = 4; // Klik [OK]
            await App.ClickBtn("//button[text()='OK']");
            
            Step = 5; // Klik [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 6; // Klik [<]
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
         var Proses = "Production Slip - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klik [Add]
            await App.ClickBtn("//div[@class='field DetailList1']//div[contains(@class, 'add-button')]");

            Step = 3; // Klik [Search Item Kode]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 4; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 5; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 6; // Klik [click material detail]
            await App.ClickBtn("//a[text()='Material Detail']");

            Step = 7; // Klik [klik Add]
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 8; // Klik [Search Item Kode]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 9; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][8]");

            Step = 10; // Input [Quantity]
            await App.InputData("//input[@name='Harga']", "20000");

            Step = 11; // Klik [save Add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");

            Step = 12; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 13; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'panel-titlebar-close')]");

            Step = 14; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 15; // Set hasil
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

      public async Task UpdateDraft()
      {
         var Proses = "Production Slip - Update Draft (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // value
            await App.Click("//div[contains(@class,'grid-canvas')]//div[contains(@class,'content')]");  
            
            Step = 2; // klik action
            await App.ClickBtn("//span[text()=' Action']");  
            
            Step = 3; // klik draft
            await App.Click("//li[@id='btnActDraft']");
            
            Step = 4; // klik filter draft
            await App.Click("//span[text()='Status']/following-sibling::div/a");  
            
            Step = 5; // klik draft
            await App.Click("//li/div[text()='Draft']");  

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
         var Proses = "Production Slip - Update Material (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // value
            await App.Click("//div[@class='slick-cell l0 r0']/a");  
            
            Step = 2; // klik material detail
            await App.ClickBtn("//a[text()='Material Detail']");  
            
            Step = 3; // klik draft
            await App.ClickBtn("//div[@class='field DetailList2']//div[contains(@class, 'add-button')]");

            Step = 4; // Klik [Search Item Kode]
            await App.ClickBtn("//label[@title='Kode Barang']/following-sibling::a");

            Step = 5; // Klik [Item Kode]
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickBarangDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')][7]");

            Step = 6; // Input [Jumlah]
            await App.InputData("//input[@name='Harga']", "20000");

            Step = 7; // Klik [save add]
            await App.ClickBtn("//div[contains(@class, 'TemplatedDialog') and @style]//div[text()='Save']");  
           
            Step = 8; // Klik [save]
            await App.ClickBtn("//div[text()='Save']");

            Step = 9; // Klik [OK]
            await App.ClickBtn("//button[text()='OK']");

            Step = 10; // Klik [<]
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
