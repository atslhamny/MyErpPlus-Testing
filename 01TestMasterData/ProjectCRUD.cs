using System;
using System.Threading.Tasks;
using WebView2.DevTools.Dom;
using System.Diagnostics;

namespace Tester
{
   public class ProjectCRUD
   {
     readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Project - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await AllBlank();

            Step = 2; // Project - Insert - Code Blank (Negative)
            if (frm.IsStopped) return;
            await CodeBlank();

            Step = 3; // Project - Insert - Name Blank (Negative)
            if (frm.IsStopped) return;
            await NameBlank();

            Step = 4; // Project - Insert (Positive)
            if (frm.IsStopped) return;
            await Create();

            //Step = 5; // Project - Read (Positive)
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 6; // Project - Update (Positive)
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 7; // Project - Delete (Positive)
            //if (frm.IsStopped) return;
            //await Delete();
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Proses Project - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
            frm.UpdateStatus("Proses Project - CRUD Selesai");
         }
      }

      public async Task AllBlank()
      {
         var Proses = "Project - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Navigasi Menu
            var btnProject = await page.XPathAsync("//a[contains(@href, 'M1Project?md')]/span");
            if (btnProject.Length > 0)
               await btnProject[0].EvaluateFunctionAsync<string>("e => e.click()");

            Step = 2; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 3; // Klik Save 
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 5; //Apa Ada Label Error?
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
         var Proses = "Project - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Nama
            await App.InputData("//input[@Name='Pnama']", "Panama");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 5; //Apa Ada Label Error?
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

      public async Task NameBlank()
      {
         var Proses = "Project - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Code
            var rand = new RandomGenerator().RandomString(5);
            await App.InputData("//input[@Name='Pkode']", $"{rand}");

            Step = 3; // Klik Save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 4; // Klik Close [X]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

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

      public async Task Create()
      {
         var Proses = "Project - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input [Kode]
            var rand = new RandomGenerator().RandomString(3);
            await App.InputData("//input[@name='Pkode']", $"{rand}");

            Step = 3; // Input [Nama]
            await App.InputData("//input[@name='Pnama']", "ABC");

            Step = 4; // Klik Contact
            await App.ClickBtn("//label[@title='Kontak']/following-sibling::a");

            Step = 5; // Klik Value Contact
            await App.DoubleClick("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 6; // Input Contact Person
            await App.InputData("input[name='Pkontakperson']", "Adi");

            Step = 7; // Klik Project Leader
            await App.ClickBtn("//label[@title='Pimpinan Proyek']/following-sibling::a");

            Step = 8; // Klik Value
            await App.ClickBtn("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 9; // Klik Division
            await App.ClickBtn("//label[@title='Divisi']/following-sibling::a");

            Step = 10; // Klik Value
            await App.ClickBtn("//div[contains(@id,'Myerpplus_Pickers_PickContactDialog')][contains(@class,'route-handler')]//div[contains(@class,'content')]");

            Step = 11; // Input Contract No
            await App.InputData("input[name='Pnilaikontrak']", "9034209");

            Step = 12; // Klik [Save]
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

            Step = 13; // Apa ada label error?
            var LblError = await page.XPathAsync("//span[text()='Alert']");

            Step = 14; // Klik [Close]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 15; // Klik [<]
            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

            Step = 16; // Set hasil
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
         var Proses = "Project - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Value
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
         var Proses = "Project - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // input Nama
            await App.InputData("//input[@Name='Pnama']", "Update");

            Step = 2; // Klik save
            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

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

      public async Task Delete()
      {
         var Proses = "Project - Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klik Value 
            await App.ClickBtn("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klik Delete 
            await App.ClickBtn("//i[contains(@class, 'trash')]/..");

            Step = 3; // Klik Ya Pop Up
            await App.ClickBtn("//button[text()='Yes']"); ;

            Step = 4; // Apa Ada Label Error?
            var LblError = await page.XPathAsync("//div[contains(text(), 'Data tidak bisa dihapus kerena ada transaksi terkait.')]");
            
            Step = 5; // Set hasil
            await App.ClickBtn("//button[text()='OK']");
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
