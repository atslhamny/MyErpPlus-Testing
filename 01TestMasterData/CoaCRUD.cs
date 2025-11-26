using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebView2.DevTools.Dom;

namespace Tester
{
   public class CoaCRUD
   {
      readonly FrmMain frm = App.FrmMain;
      readonly WebView2DevToolsContext page = App.page;
      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1;
            var pagepaket = await page.XPathAsync("//section[@class='content']//div[text()='Bank']");
            if (pagepaket.Length > 0)
            {
               goto Task;
            }
            else
            {
               var btnPaket = await page.XPathAsync("//i[contains(@class,'fa-database')]/following-sibling::span");
               if (btnPaket.Length > 0)
               {
                  await btnPaket[0].EvaluateFunctionAsync("e => e.click()");

                  var paket = await page.XPathAsync("//i[contains(@class,'fa-folder')]/following-sibling::span[text()='Data Master']");
                  if (paket.Length > 0)
                  {
                     await paket[0].EvaluateFunctionAsync("e => e.click()");
                     var subpaket = await page.WaitForXPathAsync("//a[contains(@href, 'M1Coa?md')]/span", new WaitForSelectorOptions() { Visible = true });
                     if (subpaket != null)
                     {
                        await subpaket.ClickAsync();
                        goto Task;
                     }
                  }
               }
            }

         Task:
            Step = 1; // Coa - Insert - All Blank (Negative)
            if (frm.IsStopped) return;
            await BlankInsert();

            //Step = 2; // Coa - Insert - No Blank (Negative)
            //if (frm.IsStopped) return;
            //await BlankNo();

            //Step = 3; // Coa - Insert - Nama Blank (Negative)
            //if (frm.IsStopped) return;
            //await BlankNama();

            //Step = 4; // Coa - Insert - Currency Blank (Negative)
            //if (frm.IsStopped) return;
            //await BlankCurrency();

            Step = 5; // Coa - Insert (Positive)
            if (frm.IsStopped) return;
            await Insert();

            //Step = 6; // Coa - Read (Positive)
            //if (frm.IsStopped) return;
            //await Read();

            //Step = 7; // Coa - Update (Positive)
            //if (frm.IsStopped) return;
            //await Update();

            //Step = 8; // Coa - Delete (Positive)
            //if (frm.IsStopped) return;
            //await Delete();
         }
         catch (Exception ex)
         {
           frm.Logs("Info", $"COA - CRUD step {Step}", $"FAILED -- {ex.Message}");
         }
         finally
         {
           frm.UpdateStatus("Proses COA - CRUD Selesai");
         }
      }

      public async Task BlankInsert()
      {
         var Proses = "Coa - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 3; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 4; // Apa Ada Label LblError?
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 5; // Set hasil
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
        
      public async Task BlankNo()
      {
         var Proses = "Coa - Insert - No Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input Nama
            await App.InputData("//input[@name='Cnama']", "Bank Indonesia");

            Step = 3; // Klik Currency
            await App.ClickDropdown("//label[text()='*Uang']/../a");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 6; // Apa Ada Label Error?
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

      public async Task BlankNama()
      {
         var Proses = "Coa - Insert - Name Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input No
            await App.InputData("//input[@name='Cnomor']", "100420.369");

            Step = 3; // Klick Currency
            await App.ClickDropdown("//label[text()='*Uang']/../a");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 6;
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

      public async Task BlankCurrency()
      {
         var Proses = "Coa - Insert - Currency Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick [New...]
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input No
            await App.InputData("//input[@name='Cnomor']", "100420.369");

            Step = 3; // Input Nama
            await App.InputData("//input[@name='Cnama']", "Bank Indonesia");

            Step = 4; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

            Step = 5; // Klick Close [X]
            await App.ClickBtn("//button[@title='Close']");

            Step = 6; // Apa Ada Label Error?
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

      public async Task Insert()
      {
         var Proses = "Coa - Insert (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick [New...}
            await App.ClickBtn("//div[contains(@class, 'add-button')]");

            Step = 2; // Input No
            var rand = new RandomGenerator().RandomString(10);
            await App.InputData("//input[@name='Cnomor']", $"{rand}");

            Step = 3; // Input Nama
            await App.InputData("//input[@name='Cnama']", "Bank India");

            Step = 4; // Klick Currency
            await App.ClickDropdown("//label[text()='*Uang']/../a");

            Step = 5; // Klick Save
            await App.ClickBtn("//div[text()='Save']");

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

      public async Task Read()
      {
         var Proses = "Coa - Read (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; //Read
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
         var Proses = "Coa - Update (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Input Nama
            await App.InputData("//input[@name='Cnama']", "Update");

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

      public async Task Delete()
      {
         var Proses = "Coa - Delete (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // Klick Value
            await App.Click("//div[contains(@class, 'top grid-canvas-left')]/div[contains(@class, 'slick-row')]");

            Step = 2; // Klick Delete
            await App.ClickBtn("//div[contains(@class, 'buttons-outer')]/div[3]/div/div");

            Step = 3; // Klick Ya Pop Up
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
