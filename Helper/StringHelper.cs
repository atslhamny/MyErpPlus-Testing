using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tester.Helper
{
   public class StringHelper
   {

      static public string UpperCaseFirstChar(string text)
      {
         string ret = "";
         string[] txt = text.Split(' ');
         int x = 0;
         foreach (var item in txt)
         {
            x += 1;
            ret += Regex.Replace(item, "^[a-z]", m => m.Value.ToUpper());
            if (x < txt.Length)
            {
               ret += " ";
            }
         }
         return ret;
      }

   }
}
