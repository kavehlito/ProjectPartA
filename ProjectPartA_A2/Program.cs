using System;

namespace ProjectPartA_A2
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
        }

        const int _maxNrArticles = 10;
        const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Project Part A\n");
            int menuSel = 5;
            do
            {
                menuSel = MenuSelection();
                MenuExecution(menuSel);

            } while (menuSel != 5);
        }

        private static int MenuSelection()
        {
            int menuSel;
            Console.WriteLine($"\n{nrArticles} articles entered.");
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Enter an article");
            Console.WriteLine("2 - Remove an article");
            Console.WriteLine("3 - Print receipt sorted by price");
            Console.WriteLine("4 - Print receipt sorted by name");
            Console.WriteLine("5 - Quit");

            string userInput = Console.ReadLine();
            int.TryParse(userInput, out menuSel);

            //Your code for menu selection

            return menuSel;
        }
        private static void MenuExecution(int menuSel)
        {
            try
            {
                //Your code for execution based on the menu selection
                switch (menuSel)
                {
                    case 1:
                        ReadAnArticle();
                        break;
                    case 2:
                        RemoveAnArticle();
                        break;
                    case 3:
                        SortArticles(false);
                        break;
                    case 4:
                        SortArticles(true);
                        break;
                    case 5:
                        Console.WriteLine("Thanks for visiting our shop!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ReadAnArticle()
        {
            int i = nrArticles;
            while (nrArticles < _maxNrArticles)
            {
                Console.WriteLine($"\nPlease enter the name and price for article #{nrArticles} in the format name; price (example Beer; 2,25): ");
                try
                {
                    string userinput = Console.ReadLine();
                    string[] articleSplit = userinput.Split(';');
                    string name;
                    decimal price;

                    name = articleSplit[0].Trim();

                    if (string.IsNullOrEmpty(articleSplit[0]) || name.Length > _maxArticleNameLength)
                    {
                        Console.WriteLine("Wrong name input, please enter a name (example candy)");
                        continue;
                    }
                    if (!decimal.TryParse(articleSplit[1], out price))
                    {
                        Console.WriteLine("Wrong price input, please enter a number (example 43,27)");
                        continue;
                    }
                    if (articles[i].Name == null)
                    {
                    articles[i].Name = name;
                    articles[i].Price = price;
                    i++;
                    nrArticles++;
                    }
                }
                catch (IndexOutOfRangeException ex)
                { Console.WriteLine("Wrong format input, please enter a valid format input(example Beer; 23,92)", ex.Message); }
                break;
            }
        }

        private static void RemoveAnArticle()
        {
            //Your code to remove an article
            Console.WriteLine("Please enter the name of the article you would like to remove (example Chocolate)");

            string chooseArticle = Console.ReadLine().ToUpper();
            for (int i = 0; i < articles.Length; i++)
            {
                if (articles[i].Name.ToUpper().Contains(chooseArticle) == true)
                {
                    Array.Clear(articles, i, 1);
                    nrArticles--;
                    break;
                }
                else
                {
                    Console.WriteLine("This article does NOT exist");
                    break;
                }
            }
        }
        private static void PrintReciept(string title)
        {
            //Your code to print a receipt
            Console.WriteLine($"Receipt Purchased Articles \nPurchace date: {DateTime.Now}");
            Console.WriteLine();
            Console.WriteLine($"Number of articles purchased: {nrArticles}");
            Console.WriteLine();
            Console.WriteLine("{0,-3} {1,-15} {2,20}", "#", "Name", "Price");


            for (int i = 0; i < articles.Length; i++)
            {
                if (articles[i].Name != null)
                {
                    Console.WriteLine("{0,-3} {1,-15} {2,20:C2}", i, articles[i].Name, articles[i].Price);
                }
            }
            decimal total = 0;
            for (int i = 0; i < articles.Length; i++)
            {
                total += articles[i].Price;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0,-3} {1,24:C2}", "Total Purhcase:", total);
            Console.WriteLine("{0,-3} {1,19:C2}", "Including VAT (25%):", total * _vat);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void SortArticles(bool sortByName = false)
        {
            //Your code to Sort. Either BubbleSort or SelectionSortfor (int i = 0; i < array.Length; i++)
            if (sortByName == true)
            {
                for (int c = 0; c < articles.Length; c++)
                {
                    bool isAnyChange = false;
                    for (int r = 0; r < (articles.Length - 1); r++)
                    {
                        if (string.Compare(articles[r].Name, articles[r + 1].Name) < 0)
                        {
                            isAnyChange = true;
                            (articles[r], articles[r + 1]) = (articles[r + 1], articles[r]);
                        }
                    }
                    if (!isAnyChange)
                    {
                        Console.WriteLine($"Articles Sorted by Name");
                        PrintReciept("Name");
                        break;
                    }
                }
            }
            if (sortByName == false)
            {
                for (int i = 0; i < articles.Length; i++)
                {
                    bool isAnyChange = false;
                    for (int j = 0; j < articles.Length - 1; j++)
                    {
                        if (articles[j].Price < articles[j + 1].Price)
                        {
                            isAnyChange = true;
                            (articles[j], articles[j + 1]) = (articles[j + 1], articles[j]);
                        }
                    }
                    if (!isAnyChange)
                    {
                        Console.WriteLine($"Articles Sorted by Price\n");
                        PrintReciept("Price");
                        break;
                    }
                }
            }


        }
    }
}