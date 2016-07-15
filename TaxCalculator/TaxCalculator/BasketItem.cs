using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
   //Basket object to hold items and values for each basket to be processed
   public class BasketItem
   {
      //itemQunatity - int - public attribute to hold the item quantity 
      public int itemQunatity { get; set; }
      //itemType - string - public attribute to hold the item type 
      public string itemType { get; set; }

      //itemPrice - double - public attribute to hold the item's price
      public decimal itemPrice { get; set; }

      //taxable - bool - public atribute used to determine if the item is a taxable item
      public bool taxable { get; set; }

      //importTax - bool - public atribute used to determine if the item should be taxed due to importation
      public bool importTax { get; set; }

      //salesTaxTotal - decimal - public atribute used to hold the total salesTax value
      public decimal salesTaxTotal { get; set; }

      //importTaxTotal - decimal - public atribute used to hold the total importTax value
      public decimal importTaxTotal { get; set; }

      //taxTotal - decimal - public atribute used to hold the total tax value
      public decimal taxTotal { get; set; }

      //Function Name - BasketItem
      //Parameters - None
      //Purpose: Default constructor
      //Returns: A reference to a BasketItem object
      public BasketItem()
      {
         this.itemQunatity = 0;
         this.itemType = "";
         this.itemPrice = 0;
         this.taxable = false;
         this.importTax = false;
         this.salesTaxTotal = 0;
         this.importTaxTotal = 0;
         this.taxTotal = 0;
      }

      //Function Name - BasketItem
      //Parameters - int itemQunatity - quantity of one item purchased
      //             string itemType - description of the item
      //             decimal itemPrice - price of a specific item
      //             bool taxable - boolean for whether or not sale tax should be applied
      //             bool importTax -- boolean for whether or not an import tax should be applied
      //Purpose: Constructor - build a BasketItem object
      //Returns: A reference to a BasketItem object
      public BasketItem(int itemQunatity, string itemType, decimal itemPrice, bool taxable, bool importTax)
      {
         this.itemQunatity = itemQunatity;
         this.itemType = itemType;
         this.itemPrice = itemPrice;
         this.taxable = taxable;
         this.importTax = importTax;
         this.salesTaxTotal = 0;
         this.importTaxTotal = 0;
         this.taxTotal = 0;
      }

      //Function Name - AddItem
      //Parameters - string line - the current line/item being processed
      //Purpose: Create a BasketItem object and calculate the total price, sales tax, and import tax for the item
      //Returns: A basketItem
      public static BasketItem AddItem(string line)
      {
         //boolean variables used to determine if a specific tax applies to an item
         bool applyImportedTax = false;
         bool applySalesTax = false;

         //Utility function to determine if an item should be taxed
         applySalesTax = Utility.CheckSalesTax(line);

         //Utility function to determine if an item should be taxed
         applyImportedTax = Utility.CheckImportTax(line);

         //Extract specific items from the passed in line and parse them in order to build a BasketItem
         BasketItem basketItem = new BasketItem(Int32.Parse(line.Substring(0, 1)),
                          line.Substring(line.IndexOf(" ") + 1, line.IndexOf("at") - 2),
                          Decimal.Parse(line.Substring(line.IndexOf("at ") + 3)),
                          applySalesTax,
                          applyImportedTax);

         //if the item is taxable call the utility function to determine the tax amount
         if(basketItem.taxable == true)
         {
            basketItem.salesTaxTotal = Utility.CalcSalesTax(basketItem);
         }

         //if the item is taxable call the utility function to determine the tax amount
         if(basketItem.importTax == true)
         {
            basketItem.importTaxTotal = Utility.CalcImportTax(basketItem);
         }

         //calulate the total tax for the item
         basketItem.taxTotal  = basketItem.salesTaxTotal + basketItem.importTaxTotal;

         //calulate the toatl price for the item using the included tax then round to the nearest .05
         basketItem.itemPrice += Math.Ceiling((basketItem.salesTaxTotal + basketItem.importTaxTotal) * 20) / 20;

         //output the total price for the current item
         Console.WriteLine("\t" + line.Substring(0, 1) + " " + line.Substring(line.IndexOf(" ") + 1, line.IndexOf("at ") - 2) + ": " + basketItem.itemPrice);

         //return the item
         return basketItem;
      }
   }
}
