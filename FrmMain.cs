using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tester.TestFinance;
using Tester.TestSales;
using Tester.TestProduction;
using Tester.WarehouseInventory;
using Tester.TestPurchasing;
using Tester.TestFixAsset;
using WebView2.DevTools.Dom;
using Tester._02TestFinanceAccounting;

namespace Tester
{
   public partial class FrmMain : Form
   {
      int idLogs = 0;
      public bool IsStopped = false;

      public FrmMain()
      {
         InitializeComponent();
         StartBrowser();
      }

      #region "Set Jml Test"

      private int test;
      private int pass;
      private int fail;

      public int Test
      {
         get { return test; }
         set
         {
            test = value;
            LblTest.Text = "Test : " + test;
         }
      }
      public int PASS
      {
         get { return pass; }
         set
         {
            pass = value;
            LblPass.Text = "Pass : " + pass;
         }
      }
      public int FAILED
      {
         get { return fail; }
         set
         {
            fail = value;
            LblFailed.Text = "Fail : " + fail;
         }
      }

      #endregion "Set Jml Test"

      #region "Control Events"

      private async void BtnStart_Click(object sender, EventArgs e)
      {
         int Step = 0;
         try
         {
            if (BtnStart.Text == "Start")
            {
               App.FrmMain = this;
               App.web1 = web1;

               IsStopped = false;
               BtnStart.Text = "Stop";
               BtnStart.BackColor = System.Drawing.Color.Blue;

               Step = 1; // Auto Login
               var pageLog = await App.page.XPathAsync("//body[@id='s-LoginPage']");
               if (pageLog.Length > 0)
               {

                  BtnStart.Text = "Start";
                  BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                  IsStopped = true;
               }

               Step = 2; // Run All
               string test = MnTest.Text;
               if ((test == "All DataMaster" || test == "All DataMaster") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run All Task Data Master", "Run", stopwatch.ElapsedMilliseconds);
                     //await new CoaCRUD().Start();
                     //await new AreaCRUD().Start();
                     //await new AreaFitur().Start();
                     //await new BankCRUD().Start();
                     await new ItemCRUD().Start();
                     await new ItemFitur().Start();
                     //await new OtherCostCRUD().Start();
                     //await new BranchCRUD().Start();
                     //await new TransactionNoteCRUD().Start();
                     //await new TransactionNoteDetailCRUD().Start();
                     //await new CostCenterCRUD().Start();
                     //await new DivisionCRUD().Start();
                     //await new ExpeditionCRUD().Start();
                     //await new WarehouseCRUD().Start();
                     ////await new ItemCategoryCRUD().Start();
                     //await new ContactCategoryCRUD().Start();
                     //await new CustomerCategoryCRUD().Start();
                     //await new SupplierCategoryCRUD().Start();
                     //await new SalesmanCategoryCRUD().Start();
                     //await new CityCRUD().Start();
                     //await new OtherCRUD().Start();
                     //await new LocationCRUD().Start();
                     ////await new ItemLocationCRUD().Start();
                     //await new CurrencyCRUD().Start();
                     //await new CountryCRUD().Start();
                     //await new TaxCRUD().Start();
                     //await new ProvinceCRUD().Start();
                     //await new ProjectCRUD().Start();
                     //await new UnitCRUD().Start();
                     //await new SubDivisionCRUD().Start();
                     //await new TermsCRUD().Start();
                     //await new ItemTypeCRUD().Start();
                     //await new StockAdjustmentCRUD().Start();
                     //await new ProductClassCRUD().Start();
                     //await new DepartmentCRUD().Start();
                     //await new SubDepartmentCRUD().Start();
                     //await new PriceCategoryCRUD().Start();
                     //await new ClassCRUD().Start();
                     //await new ModelCRUD().Start();
                     //await new SizeCRUD().Start();
                     //await new ColourCRUD().Start();
                     //await new OemCRUD().Start();
                     //await new MerkCRUD().Start();
                     //await new MaterialCRUD().Start();
                     //await new GroupCRUD().Start();
                     //await new DesignCRUD().Start();
                     //await new VendorCRUD().Start();
                     //await new SubClassCRUD().Start();
                     Logs("Info", "Run All Task Data Master", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }
               Step = 3; // Run Finance and Accounting
               string testfinance = MnTest.Text;
               if ((testfinance == "Finance and Accounting" || testfinance == "Finance and Accounting") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run Finance and Accounting", "Run", stopwatch.ElapsedMilliseconds);
                   
                     Logs("Info", "Run Finance and Accounting", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }

               Step = 4; // Run Warehouse and Inventory
               string testwarehouse = MnTest.Text;
               if ((testwarehouse == "Warehouse and Inventory" || testwarehouse == "Warehouse and Inventory") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run Warehouse and Inventory", "Run", stopwatch.ElapsedMilliseconds);
                     await new MaterialRequisition().Start();
                     await new TransferStock().Start();
                     await new StockAdjustment().Start();
                     await new StockOpname().Start();
                     await new PriceListAdjustment().Start();
                     await new ItemBeginningBalance().Start();
                     Logs("Info", "Run Warehouse and Inventory", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }

               Step = 5; // Run Purchasing
               string testpurchasing = MnTest.Text;
               if ((testpurchasing == "Purchasing" || testpurchasing == "Purchasing") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run Purchasing", "Run", stopwatch.ElapsedMilliseconds);
                     await new PurchaseRequest().Start();
                     await new PurchaseOrder().Start();
                     await new AdvancePurchase().Start();
                     await new GoodsReceiptNote().Start();
                     await new PurchaseInvoice().Start();
                     await new PurchaseReturn().Start();
                     await new VendorPaymentPlan().Start();
                     await new VendorPayment().Start();
                     await new ExchangeInvoice().Start();
                     //await new PurchaseReturn().Start();  
                     Logs("Info", "Run Purchasing", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }

               Step = 6; // Run Sales
               string testsales = MnTest.Text;
               if ((testsales == "Sales" || testsales == "Sales") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run Sales", "Run", stopwatch.ElapsedMilliseconds);
                     await new SalesOrder().Start();
                     await new DeliveryOrder().Start();
                     await new DeliveryResult().Start();
                     await new SalesInvoice().Start();
                     //await new SalesRetur().Start(); 
                     await new PaymentReceipt().Start();
                     Logs("Info", "Run Sales", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }

               Step = 7; // Run Production
               string testproduction = MnTest.Text;
               if ((testproduction == "Production" || testproduction == "Production") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run Production", "Run", stopwatch.ElapsedMilliseconds);
                     await new ProductionFormula().Start();
                     //await new MaterialOrder().Start(); 
                     await new MaterialSlip().Start();
                     await new ReturBahanBaku().Start();
                     await new ProductionSlip().Start();
                     Logs("Info", "Run Production", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }

               Step = 7; // Run Fix Asset
               string testfixasset = MnTest.Text;
               if ((testfixasset == "Fix Asset" || testfixasset == "Fix Asset") && !IsStopped)
               {
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();
                  int Tsk = 0;
                  try
                  {
                     Tsk = 1;
                     Logs("Info", "Run Fix Asset", "Run", stopwatch.ElapsedMilliseconds);
                     await new DepreciationAsset().Start();
                     await new AssetCategoryTax().Start();
                     await new AssetCategory().Start();
                     await new Asset().Start();
                     Logs("Info", "Run Fix Asset", "DONE", stopwatch.ElapsedMilliseconds);

                     BtnStart.Text = "Start";
                     BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
                     IsStopped = true;
                     if (IsStopped == true)
                     {

                     }
                  }
                  catch (Exception tsk)
                  {
                     stopwatch.Stop();
                     App.LogFile.Write(Serilog.Events.LogEventLevel.Error, $"{tsk} {tsk.Message}");
                     string msg = $"Start Error Step {Tsk} : {tsk.Message}";
                     MessageBox.Show(msg);
                  }
               }

               if (IsStopped == true)
               {

               }
               else
               {

               }

               IsStopped = false;
            }
            else
            {
               IsStopped = true;
               BtnStart.Text = "Start";
               BtnStart.BackColor = System.Drawing.Color.RoyalBlue;
            }

         }
         catch (Exception ex)
         {

            string msg = $"Start Error Step {Step} : {ex.Message}";
            MessageBox.Show(msg);
         }
      }

      private void BtnOptions_Click(object sender, EventArgs e)
      {
      }

      private void MnTest_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (this.MnTest.Text == "All DataMaster" || this.MnTest.Text == "All DataMaster")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }

         if (this.MnTest.Text == "Finance and Accounting" || this.MnTest.Text == "Finance and Accounting")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }

         if (this.MnTest.Text == "Warehouse and Inventory" || this.MnTest.Text == "Warehouse and Inventory")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }

         if (this.MnTest.Text == "Purchasing" || this.MnTest.Text == "Purchasing")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }

         if (this.MnTest.Text == "Sales" || this.MnTest.Text == "Sales")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }

         if (this.MnTest.Text == "Production" || this.MnTest.Text == "Production")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }

         if (this.MnTest.Text == "Fix Asset" || this.MnTest.Text == "Fix Asset")
         {
            string UrlKategori = $"{App.UrlUtama}";
            web1.CoreWebView2.Navigate(UrlKategori);
         }
      }

      #endregion "Control Events"


      #region "Browser"

      public async void StartBrowser()
      {
         await web1.EnsureCoreWebView2Async(null);

         web1.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
         web1.CoreWebView2.AddWebResourceRequestedFilter(null, CoreWebView2WebResourceContext.Image);

         App.page = await web1.CoreWebView2.CreateDevToolsContextAsync();
         web1.CoreWebView2.Navigate(App.UrlUtama);
      }

      private void CoreWebView2_WebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
      {
         e.Response = web1.CoreWebView2.Environment.CreateWebResourceResponse(null, 404, "Not found", null);
      }

      #endregion "Browser"


      #region "Methods"

      public void UpdateStatus(string status)
      {
         LblProgress.Text = status;
      }

      public void Logs(string PositifNegatif, string Process, string Result, long time = 0)
      {
         LblProgress.Text = $"{Process}";
         DateTime localDate = DateTime.Now;
         string timeNow = localDate.ToString("dd/MM/yyyy HH:mm:ss");
         var lgitem = new LogItem
         {
            IdLogs = idLogs + 1,
            TimeNow = timeNow,
            PositifNegatif = PositifNegatif,
            Process = Process,
            Result = Result,
            StopWatch = time.ToString()
         };

         logsitemsBindingSource2.List.Insert(0, lgitem);

         if (Result == "FAILED")
            App.LogFailed($"- {PositifNegatif} - {Process} - {Result}");

      }

      #endregion "Methods"

      private void MnTest_Click(object sender, EventArgs e)
      {

      }
   }
}
