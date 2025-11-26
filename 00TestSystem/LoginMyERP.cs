using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;                                                                                                                                                                          
using System.Windows.Forms;                                                                                
using WebView2.DevTools.Dom;

namespace Tester
{
   public class LoginMyERP
   {
      FrmMain frm = App.FrmMain;
      Microsoft.Web.WebView2.WinForms.WebView2 web1 = App.web1;
      WebView2DevToolsContext page = App.page;
      string url = App.UrlUtama;

      public async Task Start()
      {
         int Step = 0;
         try
         {
            Step = 1; // Init

            Stopwatch jam = new Stopwatch();
            jam.Start();


            Step = 2; // Blank Login
            await BlankLogin();

            if (frm.IsStopped) return;


            Step = 3; //Login Tanpa Username
            await LoginBlankEmail();

            if (frm.IsStopped) return;

            Step = 4; //Login Tanpa Password
            await LoginBlankPassword();

            if (frm.IsStopped) return;

            Step = 5; //Login Tanpa Password
            await LoginWrongPassword();

            if (frm.IsStopped) return;

            Step = 6;// untuk login
            await WrongUsername();

            if (frm.IsStopped) return;

            Step = 7;// untuk login
            await Login();

            if (frm.IsStopped) return;

            frm.Logs("Info", "Auto Login", "PASS", jam.ElapsedMilliseconds);
         }
         catch (Exception ex)
         {
            frm.Logs("Info", $"Auto Login step {Step}", $"FAILED - {ex.Message}");
         }
      }

      public async Task BlankLogin()
      {
         var Proses = "Auto Login - All Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // set url target
            string UrlTarget = url;

            Step = 2; // pergi ke url target
            web1.CoreWebView2.Navigate($"{UrlTarget}");

            Step = 3; // click Sign In
            await App.ClickBtn("//button [@type = 'submit']");

            Step = 4;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 5; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task LoginBlankEmail()
      {
         var Proses = "Auto Login - Email Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // set url target
            string UrlTarget = url;

            Step = 2; // pergi ke url target
            web1.CoreWebView2.Reload();

            Step = 3;
            await App.InputData("//input[@name='Username']", "");

            Step = 4;
            await App.InputData("//input[@name='Password']", "123456");

            Step = 5; // click Sign In
            await App.ClickBtn("//button[@type = 'submit']");

            Step = 6;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task LoginBlankPassword()
      {
         var Proses = "Auto Login - Password Blank (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // set url target
            string UrlTarget = url;

            Step = 2; // pergi ke url target
            web1.CoreWebView2.Reload();

            Step = 3;
            await App.InputData("//input[@name='Username']", "agil");

            Step = 4;
            await App.InputData("//input[@name='Password']", "");

            Step = 5; // click Sign In
            await App.ClickBtn("//button[@type = 'submit']");

            Step = 6;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task LoginWrongPassword()
      {
         var Proses = "Auto Login - Wrong Password (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // set url target
            string UrlTarget = url;

            Step = 2; // pergi ke url target
            web1.CoreWebView2.Reload();

            Step = 3;
            await App.InputData("//input[@name='Username']", "agil");

            Step = 4;
            await App.InputData("//input[@name='Password']", "yondagtaukoktanyasaya");

            Step = 5; // click Sign In
            await App.ClickBtn("//button[@type = 'submit']");

            Step = 6;
            var LblError = await page.XPathAsync("//label[@class='error']");  

            Step = 7; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task WrongUsername()
      {
         var Proses = "Auto Login - Wrong Username (Negative)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // set url target
            string UrlTarget = url;

            Step = 2; // pergi ke url target
            web1.CoreWebView2.Reload();

            Step = 3;
            await App.InputData("//input[@name='Username']", "agiel");

            Step = 4;
            await App.InputData("//input[@name='Password']", "123456");

            Step = 5; // click Sign In
            await App.ClickBtn("//button[@type = 'submit']");

            Step = 6;
            var LblError = await page.XPathAsync("//label[@class='error']");

            Step = 7; // Set hasil
            jam.Stop();
            frm.Logs("N", Proses, LblError != null ? "PASS" : "FAILED", jam.ElapsedMilliseconds);
            if (LblError != null) { frm.PASS++; } else { frm.FAILED++; };
         }
         catch (Exception ex)
         {
            frm.FAILED++;
            jam.Stop();
            frm.Logs("N", $"{Proses} - step {Step} : {ex.Message}", "FAILED", jam.ElapsedMilliseconds);
         }
      }

      public async Task Login()
      {
         var Proses = "Auto Login - Login (Positive)"; frm.UpdateStatus(Proses);
         Stopwatch jam = new Stopwatch(); jam.Start(); frm.Test++;
         int Step = 0;
         try
         {
            Step = 1; // set url target
            string UrlTarget = url;

            Step = 2; // pergi ke url target
            web1.CoreWebView2.Reload();

            Step = 3;
            await App.InputData("//input[@name='Username']", "demo1");

            Step = 4;
            await App.InputData("//input[@name='Password']", "123456");

            Step = 5; // click Sign In
            await App.ClickBtn("//button [@type = 'submit']");

            await page.WaitForXPathAsync("//h1[text()='Home']");

            jam.Stop();
            frm.Logs("P", Proses, "PASS", jam.ElapsedMilliseconds);
            frm.PASS++;
         }
         catch (Exception ex)
         {
            jam.Stop();
            frm.Logs("P", Proses, "FAILED", jam.ElapsedMilliseconds);
            frm.FAILED++;     
         }
      }
   }
}
