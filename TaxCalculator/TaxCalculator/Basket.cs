using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
   public class Basket
   {
      //salesTax - decimal - public atribute used to hold the accumalted sales tax for a basket
      public decimal salesTax { get; set; }

      //salesTotal - decimal - public atribute used to hold the accumalted sales price/total for a basket
      public decimal salesTotal { get; set; }

      //basketItems - List<BasketItem> - public atribute that contains a list of all the items in a basket
      public List<BasketItem> basketItems { get; set; }

      //Function Name - Basket
      //Parameters - none
      //Purpose: Defauly constructor for a Basket object
      //Returns: A reference to a Basket object
      public Basket()
      {
         basketItems = new List<BasketItem>();
         salesTax = 0;
         salesTotal = 0;
      }
   }
}

