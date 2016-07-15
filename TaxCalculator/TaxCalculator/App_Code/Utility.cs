using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
   public class Utility
   {
      //Function Name - PrintInput
      //Parameters - List<string> input - current input
      //Purpose: Prints to the screen the data read in from the file/receipt
      //Returns: nothing
      public static void PrintInput(List<string> input)
      {
         //output headers
         Console.WriteLine("Input");
         Console.WriteLine("----------------");
         //read each string from the passed in list
         foreach (string line in input)
         {
            //if it contains the word "Shopping" print it as a header otherwise indent it and print as a line item
            if (line.Contains("Shopping"))
            {
               Console.WriteLine(Environment.NewLine +line);
            }
            else 
            {
               // Use a tab to indent each line of the file.
               Console.WriteLine("\t" + line);
            }

         }

         //print the headers for the calculated output
         Console.WriteLine(Environment.NewLine + "OutPut");
         Console.WriteLine("----------------");
      }

      //Function Name - CheckSalesTax
      //Parameters - string currentItem - the current item as a string
      //Purpose: Determine if a sales tax should be applied
      //Returns: Boolean - true/false
      public static bool CheckSalesTax(string currentItem)
      {
         //boolean variable to be returned
         bool addSalesTax = true;

         //determine if the item falls into the four non-taxable catergories ***
         if (currentItem.Contains("book") ||
            currentItem.Contains("chocolate bar") ||
             currentItem.Contains("box of chocolates") ||
             currentItem.Contains("headache pills"))
         {
            addSalesTax = false;
         }

         return addSalesTax;

      }

      //Function Name - CheckImportTax
      //Parameters - string currentItem - the current item as a string
      //Purpose: Determine if a import tax should be applied
      //Returns: Boolean - true/false
      public static bool CheckImportTax(string currentItem)
      {
         //boolean variable to be returned
         bool applyImportedTax = false;

         //determine if the item is taxable
         if (currentItem.Contains("imported"))
         {
            applyImportedTax = true;
         }

         return applyImportedTax;

      }

      //Function Name - CalcSalesTax
      //Parameters - BasketItem item - current item being processed
      //Purpose: Calulate the sales tax for the item
      //Returns: the total tax for the individual item
      public static decimal CalcSalesTax(BasketItem item)
      {
         decimal salesTax = 0;
         decimal taxAmount = .10M;

         salesTax += taxAmount * item.itemPrice;

         return salesTax;
      }

      //Function Name - CalcImportTax
      //Parameters - BasketItem item - current item being processed
      //Purpose: Calulate the import tax for the item
      //Returns: the total tax for the individual item
      public static decimal CalcImportTax(BasketItem item)
      {
         decimal importTax = 0;
         decimal taxAmount = .05M;

         importTax += taxAmount * item.itemPrice;

         return importTax;
      }
   }
}
