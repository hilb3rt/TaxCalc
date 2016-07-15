using System;
using System.Collections.Generic;
using System.IO;

//Jared "Zephyr" Brammer
//brammer.jared@gmail.com
//Programming Assessment

namespace TaxCalculator
{
   class Program
   {
      static void Main(string[] args)
      {
         //Variables
         
         //strLine - string - Used to hold each line of the file as it is being read
         string strLine;

         //lstInput - list<string> - a list containing strings - holds each line of the file being read
         List<string> lstInput = new List<string>();

         //get the input file/receipt by creating a stream reader
         StreamReader file = new StreamReader(@"BasketFile.txt");
         
         //read each line of the file and store it in the list(lstInput)
         while ((strLine = file.ReadLine()) != null)
         {
            //if the line is blank skip it
            if (strLine != "")
            {
               //add the line to lstInput
               lstInput.Add(strLine);
            }
         }

         //print the input to the screen
         Utility.PrintInput(lstInput);

         //call the fucntion to start processing the input data
         ProcessFile(lstInput);

         //wait for user input to close the window
         Console.ReadLine();
      }

      //Function Name - ProcessFile
      //Parameters - List<string> input - contains the receipt/data read from the input file
      //Purpose: Reads through the input file, builds the baskets, and the items contained within them
      //Returns: Nothing
      public static void ProcessFile(List<string> input)
      {
         //Variables

         //List<Basket> lstBasket - list of basket items
         List<Basket> lstBasket = new List<Basket>();

         //Basket basket - new basket item used to store items from the receipt/input file
         Basket basket = new Basket(); ;

         //Output the first shopping basket "header"
         Console.WriteLine(Environment.NewLine + input[0]);

         //read through each line of the stored input file
         foreach (string line in input)
         {
            //if the line starts with "shoppinh" or has an index of 1 then we know that this is the first line and should skip processing the totals
            //since they haven't been created yet
            if (line.StartsWith("Shopping") && input.IndexOf(line) > 0)
            {
               //process the totals for the current basket
               processTotals(basket);

               //create a new basket object
               basket = new Basket();

               //Output the current shopping basket "header"
               Console.WriteLine(Environment.NewLine + line);
            }
            //if the line doesn't contain the word "shopping" then process the current item and store it in the current basket
            else if (!line.StartsWith("Shopping"))
            {
               //call the BasketItem class' addItem function with the current line/item passed to it
               basket.basketItems.Add(BasketItem.AddItem(line));
            }
         }

         //process the totals for the last basket
         processTotals(basket);
      }

      //Function Name - processTotals
      //Parameters - Basket basket - contains the current basket and all its items
      //Purpose: Calculate the totals (tax and item price + tax) for the current basket's items and then display the totals to the screen
      //Returns: nothing
      public static void processTotals(Basket basket)
      {
         //read through each item in the basket
         foreach (BasketItem item in basket.basketItems)
         {
            //keep track of the salesTax while rounding to the nearest .05
            basket.salesTax += Math.Ceiling((item.taxTotal) * 20) / 20;

            //keep track of the  total price for each item
            basket.salesTotal += item.itemPrice;
         }
         //display the total salesTax and sale price for all items in the basket
         Console.WriteLine("\tSales Taxes: {0:n2}", basket.salesTax);
         Console.WriteLine("\tTotal: {0:n2}", basket.salesTotal);
      }
   }
}
