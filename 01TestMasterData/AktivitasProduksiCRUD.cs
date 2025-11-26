//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using WebView2.DevTools.Dom;

//namespace Tester
//{
//   public class AktivitasProduksiCRUD
//   {
//      FrmMain frm = App.FrmMain;
//      WebView2DevToolsContext page = App.page;

//      public async Task Start()
//      {
//         int Step = 0;
//         try
//         {
//            Step = 1;
//            if (frm.IsStopped) return;
//            await AllBlank();

//            Step = 2;
//            if (frm.IsStopped) return;
//            await CodeBlank();

//            Step = 3;
//            if (frm.IsStopped) return;
//            await NameBlank();

//            Step = 4;
//            if (frm.IsStopped) return;
//            await WarehouseBlank();

//            Step = 5;
//            if (frm.IsStopped) return;
//            await Create();

//            Step = 6;
//            if (frm.IsStopped) return;
//            await Read();

//            Step = 7;
//            if (frm.IsStopped) return;
//            await Update();

//            Step = 8;
//            if (frm.IsStopped) return;
//            await Delete();

//         }
//         catch (Exception ex)
//         {
//            frm.Logs("Info", $"AktivitasProduksi - CRUD step {Step}", $"FAILED -- {ex.Message}");
//         }
//         finally
//         {
//            frm.UpdateStatus("Proses AktivitasProduksi - CRUD Selesai");
//         }
//      }

//      public async Task AllBlank()
//      {
//         var Proses = "AktivitasProduksi - Insert - All Blank (Negative)"; frm.UpdateStatus(Proses);
//         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
//         int Step = 0;
//         try
//         {
//            Step = 1; // Navigasi Ke Menu
//            var btnAktvsPrd = await page.XPathAsync("//a[contains(@href, 'M1ProductionActivity?md')]/span");
//            if (btnAktvsPrd.Length > 0)
//               await btnAktvsPrd[0].EvaluateFunctionAsync<string>("e => e.click()");

//            Step = 2; // Klik [New...]
//            await App.ClickBtn("//div[contains(@class, 'add-button')]");

//            Step = 3; // Klik Save
//            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

//            Step = 4; // Klik [X]
//            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

//            Step = 5; // apa ada label Erro?
//            var LblError = await page.XPathAsync("//label[@class='error']");

//            Step = 6; // Set hasil
//            jam.Stop();
//            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
//            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };

//         }
//         catch (Exception ex)
//         {
//            jam.Stop();
//            frm.FAILED++;
//            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
//         }
//      }

//      public async Task CodeBlank()
//      {
//         var Proses = "AktivitasProduksi - Insert - Code Blank (Negative)"; frm.UpdateStatus(Proses);
//         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
//         int Step = 0;
//         try
//         {
//            Step = 1; // Klik [New...]
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 3; // Input Nama
//            await App.InputData("//input[@Name='Panama']", "TEST");

//            Step = 3; // Warehouse Result
//            await App.Click("//label[@title='Gudang Hasil']/following-sibling::a");

//            Step = 5; // Click Warehouse Result
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 1; //Add Button Result Detail
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 3; // Item Barang
//            await App.Click("//label[@title='Kode Barang']/following-sibling::a");

//            Step = 5; // Click Item Barang
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 3; //Input COGS
//            await App.InputData("//input[@Name='Hpp']", "100");

//            Step = 12; // Klik Save
//            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

//            Step = 7; // KliK [X]
//            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

//            Step = 13; // Apa Ada Label Error?
//            var LblError = await page.XPathAsync("//label[@class='error']");

//            Step = 6; // Set hasil
//            jam.Stop();
//            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
//            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
//         }
//         catch (Exception ex)
//         {
//            jam.Stop();
//            frm.FAILED++;
//            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
//         }
//      }

//      public async Task NameBlank()
//      {
//         Stopwatch stopwatch = new Stopwatch();
//         stopwatch.Start();
//         frm.Test++;
//         int Step = 0;
//         try
//         {
//            frm.UpdateStatus("- N - AktivitasProduksi - Insert -  Name Blank");

//            Step = 1; //Add Button
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 2; //Input Code
//            await App.InputData("//input[@Name='Pakode']", "ABC");

//            Step = 3; // Warehouse Result
//            await App.Click("//label[@title='Gudang Hasil']/following-sibling::a");

//            Step = 5; // Click Warehouse Result
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 1; //Add Button Result Detail
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 3; // Item Barang
//            await App.Click("//label[@title='Kode Barang']/following-sibling::a");

//            Step = 5; // Click Item Barang
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 3; //Input COGS
//            await App.InputData("//input[@Name='Hpp']", "100");

//            Step = 12; //  Click Save Tags
//            await App.ClickBtn("//div[contains(@class, 'save-and-close-button')]");

//            Step = 7; // Click Save Tags
//            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

//            Step = 13;
//            var LblError = await page.XPathAsync("//label[@class='error']");
//            if (LblError != null)
//            {
//               stopwatch.Stop();
//              frm.Logs("N", "AktivitasProduksi - Insert - Name Blank", "PASS", stopwatch.ElapsedMilliseconds);
//            }
//            else if (LblError == null)
//            {
//               stopwatch.Stop();
//              frm.Logs("N", "AktivitasProduksi - Insert - Name Blank", "FAILED", stopwatch.ElapsedMilliseconds);
//               App.NegaFail("- N - AktivitasProduksi - Insert - Name Blank - FAILED");
//            }
//            frm.PASS++;
//         }
//         catch (Exception ex)
//         {
//            frm.FAILED++;
//            stopwatch.Stop();
//           frm.Logs("N", "AktivitasProduksi - Insert - Name Blank", "FAILED", stopwatch.ElapsedMilliseconds);
//            App.NegaFail("- N - AktivitasProduksi - Insert - Name Blank - FAILED");
            

//         }
//      }

//      public async Task WarehouseBlank()
//      {
//         Stopwatch stopwatch = new Stopwatch();
//         stopwatch.Start();
//         frm.Test++;
//         int Step = 0;
//         try
//         {
//            frm.UpdateStatus("- N - AktivitasProduksi - Insert -  Warehouse Blank");

//            Step = 1; //Add Button
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 2; //Input Code
//            await App.InputData("//input[@Name='Pakode']", "ABC");

//            Step = 3; //Input Nama
//            await App.InputData("//input[@Name='Panama']", "TEST");

//            Step = 1; //Add Button Result Detail
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 3; // Item Barang
//            await App.Click("//label[@title='Kode Barang']/following-sibling::a");

//            Step = 5; // Click Item Barang
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 3; //Input COGS
//            await App.InputData("//input[@Name='Hpp']", "100");

//            Step = 4; //Click Save
//            await App.Click("//div[contains(@class, 'save-and-close-button')]");

//            Step = 7; // Click Save Tags
//            await App.ClickBtn("//button[contains(@class, 'ui-dialog-titlebar-close')]");

//            Step = 13;
//            var LblError = await page.XPathAsync("//label[@class='error']");
//            if (LblError != null)
//            {
//               stopwatch.Stop();
//              frm.Logs("N", "AktivitasProduksi - Insert - Department Blank", "PASS", stopwatch.ElapsedMilliseconds);
//            }
//            else if (LblError == null)
//            {
//               stopwatch.Stop();
//              frm.Logs("N", "AktivitasProduksi - Insert - Warehouse Blank", "FAILED", stopwatch.ElapsedMilliseconds);
//               App.NegaFail("- N - AktivitasProduksi - Insert - Warehouse  Blank - FAILED");
//            }
//            frm.PASS++;
//         }
//         catch (Exception ex)
//         {
//            frm.FAILED++;
//            stopwatch.Stop();
//           frm.Logs("N", "AktivitasProduksi - Insert - Warehouse Blank", "FAILED", stopwatch.ElapsedMilliseconds);
//            App.NegaFail("- N - AktivitasProduksi - Insert - Warehouse Blank - FAILED");
            

//         }

//      }

//      public async Task Create()
//      {
//         Stopwatch stopwatch = new Stopwatch();
//         stopwatch.Start();
//         frm.Test++;
//         int Step = 0;
//         try
//         {
//            frm.UpdateStatus("- P - AktivitasProduksi - Insert");

//            Step = 1; //Add Button
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 2; //Input Code
//            var rand = new RandomGenerator().RandomString(3);
//            await App.InputData("//input[@Name='Pakode']", $"{rand}");

//            Step = 3; //Input Nama
//            await App.InputData("//input[@Name='Panama']", "TEST");

//            Step = 3; // Warehouse Result
//            await App.Click("//label[@title='Gudang Hasil']/following-sibling::a");

//            Step = 5; // Click Warehouse Result
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 1; //Add Button Result Detail
//            await App.Click("//div[contains(@class, 'add-button')]");

//            Step = 3; // Item Barang
//            await App.Click("//label[@title='Kode Barang']/following-sibling::a");

//            Step = 5; // Click Item Barang
//            await App.DoubleClick("//div[@class='slick-cell l0 r0']");

//            Step = 3; //Input COGS
//            await App.InputData("//input[@Name='Hpp']", "100");

//            Step = 4; //Click Save
//            await App.Click("//div[contains(@class, 'save-and-close-button')]");

//            Step = 13;
//            var LblError = await page.XPathAsync("//label[@class='error']");
//            if (LblError.Length > 0)
//            {
//               stopwatch.Stop();
//              frm.Logs("P", "AktivitasProduksi - Insert", "FAILED", stopwatch.ElapsedMilliseconds);
//               App.LogFailed("- P - AktivitasProduksi - Insert - FAILED");
//            }
//            else
//            {
//               stopwatch.Stop();
//              frm.Logs("P", "AktivitasProduksi - Insert", "PASS", stopwatch.ElapsedMilliseconds);
//               App.LogPass("- P - AktivitasProduksi - Insert - PASS");
//            }
//            frm.PASS++;
//         }
//         catch (Exception ex)
//         {
//            frm.FAILED++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Insert", "FAILED", stopwatch.ElapsedMilliseconds);
//            App.LogFailed("- P - AktivitasProduksi - Insert - FAILED");
            

//         }
//      }

//      public async Task Read()
//      {
//         Stopwatch stopwatch = new Stopwatch();
//         stopwatch.Start();
//         frm.Test++;
//         int Step = 0;
//         try
//         {
//            frm.UpdateStatus("- P - AktivitasProduksi - Read");

//            Step = 1; //  click Detail Tags
//            await App.Click("//div[@class='slick-cell l0 r0']/a");

//            frm.PASS++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Read", "PASS", stopwatch.ElapsedMilliseconds);
//            App.LogPass("- P - AktivitasProduksi - Read - PASS");
//         }
//         catch (Exception ex)
//         {
//            frm.FAILED++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Read", "FAILED", stopwatch.ElapsedMilliseconds);
//            App.LogFailed("- P - AktivitasProduksi - Read - FAILED");
            

//         }
//      }

//      public async Task Update()
//      {
//         Stopwatch stopwatch = new Stopwatch();
//         stopwatch.Start();
//         frm.Test++;
//         int Step = 0;
//         try
//         {
//            frm.UpdateStatus("- P - AktivitasProduksi - Update");

//            await App.InputData("//input[@Name='Panama']", "Update");

//            await App.Click("//div[contains(@class, 'save-and-close-button')]");

//            frm.PASS++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Update", "PASS", stopwatch.ElapsedMilliseconds);
//            App.LogPass("- P - AktivitasProduksi - Update - PASS");
//         }
//         catch (Exception ex)
//         {
//            frm.FAILED++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Update", "FAILED", stopwatch.ElapsedMilliseconds);
//            App.LogFailed("- P - AktivitasProduksi - Update - FAILED");
            

//         }
//      }

//      public async Task Delete()
//      {
//         Stopwatch stopwatch = new Stopwatch();
//         stopwatch.Start();
//         frm.Test++;
//         int Step = 0;
//         try
//         {
//            frm.UpdateStatus("- P - AktivitasProduksi - Delete");

//            Step = 3; //  Click Read Contact
//            await App.Click("//div[@class='slick-row']");

//            Step = 4; //  Click Delete Contact
//            await App.ClickBtn("//i[contains(@class, 'fa-trash')]");

//            Step = 5; //  Click Ya Pop Up
//            await App.ClickBtn("//button[text()='Yes']"); ;

//            Step = 13;
//            var LblError = await page.XPathAsync("//div[contains(text(), 'Data tidak bisa dihapus kerena ada transaksi terkait.')]");
//            if (LblError.Length > 0)
//            {
//               stopwatch.Stop();
//               await App.ClickBtn("//button[text()='OK']");
//               frm.Logs("P", "Currency - Delete", "FAILED", stopwatch.ElapsedMilliseconds);
//               App.LogFailed("- P - Currency - Insert - FAILED");
//            }
//            else
//            {
//               stopwatch.Stop();
//               frm.Logs("P", "Currency - Delete", "PASS", stopwatch.ElapsedMilliseconds);
//               App.LogPass("- P - Currency - Insert - PASS");
//            }

//            frm.PASS++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Delete", "PASS", stopwatch.ElapsedMilliseconds);
//            App.LogPass("- P - AktivitasProduksi - Delete - PASS");
//         }
//         catch (Exception ex)
//         {
//            frm.FAILED++;
//            stopwatch.Stop();
//           frm.Logs("P", "AktivitasProduksi - Delete", "FAILED", stopwatch.ElapsedMilliseconds);
//            App.LogFailed("- P - AktivitasProduksi - Delete - FAILED");
            

//         }
//      }
//   }
//}
