using System;
using System.Collections.Generic;
using System.IO;

namespace sdam_stock_assignment
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Stock Inventory Application");
            ShowInterface();
            int choice = GetInput();


            // Assign each choice to the corresponding method
            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        AddToStock(@"../../../stock.txt",
                            @"../../../addlog.txt");
                        break;
                    case 2:
                        TakeFromStock(@"../../../stock.txt",
                            @"../../../takelog.txt")
                        ;
                        break;
                    case 3:
                        ShowItems();
                        break;
                    case 4:
                        FinancialReport();
                        break;
                    case 5:
                        TransactionLog();
                        break;
                    case 6:
                        PersonalUsage();
                        break;
                }
                ShowInterface();
                choice = GetInput();
            }
        }
        // initialise interface
        private static void ShowInterface()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("\n1. Add to Stock");
            Console.WriteLine(" ");

            Console.WriteLine("2. Take From Stock");
            Console.WriteLine(" ");

            Console.WriteLine("3. Inventory Report");
            Console.WriteLine(" ");

            Console.WriteLine("4. Financial Report");
            Console.WriteLine(" ");

            Console.WriteLine("5. Transaction Log");
            Console.WriteLine(" ");

            Console.WriteLine("6. Personal Usage");
            Console.WriteLine(" ");

            Console.WriteLine("7. Exit");
        }
        private static int GetInput()
        {
            int option = ReadChoice("\nChoice");
            while (option < 1 || option > 7)
            {
                Console.WriteLine("\nInvalid Choice! Please enter another choice");
                option = ReadChoice("\nChoice");
            }
            return option;
        }
        //read in user choice
        private static int ReadChoice(string pChoice)
        {
            try
            {
                Console.Write(pChoice + ":    ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return 10;
            }
        }


        //Add to stock operation
        private static void AddToStock(string filepath, string logFilePath)
        {

            Console.WriteLine("Enter Item Code");
            string itemCode = Console.ReadLine();
            Console.WriteLine("Enter Item Name");
            string itemName = Console.ReadLine();
            Console.WriteLine("Enter Item Quantity");

            //try catch for user entry of quantity - can't enter string

            try
            {
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Item Price");

                //try catch for user entry of Price - can't enter string


                try
                {
                    float price = float.Parse(Console.ReadLine());
                    DateTime time = DateTime.Now;
                    stockManager stockMgr = new stockManager();

                    stockMgr.AddItem(new stockItem(itemCode, itemName, price, quantity));

                    try
                    {

                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                        {
                            file.WriteLine(itemCode + "," + itemName + "," + quantity + "," + price);
                        }
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@logFilePath, true))
                        {
                            file.WriteLine(itemCode + "," + itemName + "," + price + "," + "Added to stock" + "," + time);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: PLEASE ENTER A VALID PRICE");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: PLEASE ENTER AN INTEGER FOR QUANTITY");
            }
        }

        // show inventory operation
        public static void ShowItems()
        {
            // read in text file
            string[] lines = File.ReadAllLines(@"../../../stock.txt");
            List<float> costs = new List<float>();
            Console.WriteLine("Inventory Report");
            Console.WriteLine("      ");

            Console.WriteLine("\t{0, -20} {1, -20} {2, -12}", "Code", "Name", "No. In Stock");
            Console.WriteLine("      ");

            // for each line write contents

            foreach (var line in lines)
            {
                var code = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                var item = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                var stock = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[2];


                Console.WriteLine("\t{0, -20} {1, -20} {2, -12}", code, item, stock);
            }


        }


        // financial report operation
        public static void FinancialReport()
        {

            // read in stock file
            string[] lines = File.ReadAllLines(@"../../../stock.txt");
            Console.WriteLine("Financial Report");
            Console.WriteLine("      ");

            Console.WriteLine("\t{0, -20} {1, -20}", "Item", "Cost");
            Console.WriteLine("      ");

            // create float to hold total expenditure

            float expend = 0;
            foreach (var line in lines)
            {


                var item = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];

                // split line to get price value
                var price = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3];

                //each loop adds price to total expenditure float
                expend += (float.Parse(price));
                //writes current lines item and price for each individual item
                Console.WriteLine("\t{0, -20} {1, 0} {2, -20}", item, "£", price);
            }

            Console.WriteLine("");
            // writes total
            Console.WriteLine("\t{0, -20} {1, 0} {2, -20}", "Total Expenditure", "£", expend);

        }



        // transaction log operation
        public static void TransactionLog()

        {
            //read in log that holds 'Added To' logs
            string[] addlog = File.ReadAllLines(@"../../../addlog.txt");
            Console.WriteLine("Transaction Log");
            Console.WriteLine("      ");

            Console.WriteLine("{0, -5} {1, -10} {2, -15} {3, -20} {4, -12}", "Code |", "Item-Name |", "Price |", "Type |", "Time");
            Console.WriteLine("      ");


            foreach (var line in addlog)
            {
                var code = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                var name = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                var price = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[2];
                var type = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3];
                var time = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[4];


                Console.WriteLine("{0, -5} {1, -12} {2, -10} {3, -20} {4, -12}", code, name, price, type, time);
            }

            //read in log that holds 'Taken From' logs

            string[] takelog = File.ReadAllLines(@"../../../takelog.txt");
            Console.WriteLine("");
            Console.WriteLine("      ");

            Console.WriteLine("{0, -5} {1, -10} {2, -20} {3, -12}", "Person Name |", "Code |", "Type |", "Time |");
            Console.WriteLine("      ");


            foreach (var line in takelog)
            {
                var name = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                var code = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                var type = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[2];
                var time = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3];


                Console.WriteLine("{0, -15} {1, -5} {2, -20} {3, -12}", name, code, type, time);
            }
        }

        //take from stock operation
        public static void TakeFromStock(string filepath, string logFilePath)
        {
            //read in stock file
            var items = File.ReadAllLines(@"../../../stock.txt");
            //create list that holds items
            var itemsList = new List<string>(items);
            var item = new List<string>();
            DateTime time = DateTime.Now;

            Console.WriteLine("Enter Item Code");

            //read item code that user wants to take
            int searchTerm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");

            string name = Console.ReadLine();
            foreach (var line in itemsList)
            {

                var quantitysearch = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[2];
                var codesearch = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                var pricesearch = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3];
                var namesearch = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                var code = Convert.ToInt32(codesearch);
                var quantity = Convert.ToInt32(quantitysearch);

                //creates new int variable to hold new stock amount that can be written to file
                int newQuantity = quantity - 1;

                if (code != searchTerm)
                {

                    //if the code is not what the user entered, add whole line to item list to be re-written in the file
                    item.Add(line);

                }
                if (code == searchTerm)
                {

                    //if the code is what the user entered, check its in stock
                    if (quantity > 0)
                    {


                        string newRecord = codesearch + "," + namesearch + "," + Convert.ToString(newQuantity)/*use new quantity variable for updated record*/ + "," + pricesearch + ",";
                        item.Add(newRecord); // add new record to item list 
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@logFilePath, true))
                        {
                            // adds to transaction log
                            file.WriteLine(name + "," + searchTerm + "," + "Taken From stock" + "," + time);
                        }


                    }
                    else
                    {
                        Console.WriteLine("Item is not in Stock");
                        break;
                    }


                }
            }
            using (System.IO.TextWriter file = new System.IO.StreamWriter(@filepath))
            {
                foreach (string i in item) // overwrite file with list that contains updated record
                {
                    file.WriteLine(i);

                }
                file.Close();
            }
        }

        //personal usage operation
        public static void PersonalUsage()
        {

            //read in "take from" log and stock list 
            string[] stock = File.ReadAllLines(@"../../../stock.txt");
            string[] log = File.ReadAllLines(@"../../../takelog.txt");


            Console.WriteLine("Please enter a name");
            string searchTerm = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("{0, -10} {1, -10}", "Showing usage for : ", searchTerm);

            Console.WriteLine("{0, -10} {1, -10} {2, -5}", "Item Code", "Item Name", "Date Taken");


            foreach (var line in log)
            {

                var code = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                var personname = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                var date = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[3];


                //compare search term with the person name of the current line
                bool compare = string.Equals(searchTerm, personname, StringComparison.CurrentCultureIgnoreCase);

                if (compare == true)
                {
                    // if bool is true (search term = name in line) search each line in stock  
                    foreach (var i in stock)
                    {
                        var codeStock = i.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                        var nameStock = i.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                        if (codeStock == code) // if the code from the log matches code from stock, write the item name, item code and date

                        {
                            Console.WriteLine("{0, -10} {1, -10} {2, -5}", codeStock, nameStock, date);

                        }
                    }


                }
            }





        }







    }


}

