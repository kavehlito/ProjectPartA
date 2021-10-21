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
        static int nrArticles;

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
            if (nrArticles == _maxNrArticles)
            {
                Console.WriteLine("You have reached the maximum amount of articles!");
            }
            while (nrArticles < _maxNrArticles)
            {
                Console.WriteLine($"\nPlease enter the name and price for article #{nrArticles} in the format name; price (example Beer; 2,25): ");
                try
                {
                    string userinput = Console.ReadLine();
                    string[] articleSplit = userinput.Split(';');

                    decimal price;

                    if (string.IsNullOrEmpty(articleSplit[0]) || articleSplit[0].Length > _maxArticleNameLength)
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
                        articles[i].Name = articleSplit[0];
                        articles[i].Price = price;
                        i++;
                        nrArticles++;
                    }
                    if (nrArticles == _maxNrArticles)
                    {
                        Console.WriteLine("You have reached the maximum amount of articles!");
                        break;
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
            string chooseArticle = Console.ReadLine().ToLower();
            try
            {
                for (int i = 0; i < nrArticles; i++)
                {
                   /* if (articles[i].Name == null)
                    {
                        continue;
                    }*/
                    if (articles[i].Name.ToLower().Contains(chooseArticle) == true)
                    {
                        Console.WriteLine($"Article {articles[i].Name} has been removed");
                        Array.Clear(articles, i, 1);
                        nrArticles--;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This article does NOT exist");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("This article does NOT exist");
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

            int articleposition = 0;
            for (int i = 0; i < articles.Length; i++)
            {
                if (articles[i].Name != null)
                {
                    Console.WriteLine("{0,-3} {1,-15} {2,20:C2}", articleposition, articles[i].Name, articles[i].Price);
                    articleposition++;
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
                for (int c = 0; c < nrArticles - 1; c++)
                {
                    bool isAnyChange = false;
                    for (int r = 0; r < (nrArticles - 1); r++)
                    {
                        if (string.Compare(articles[r + 1].Name, articles[r].Name) < 0)
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
                for (int i = 0; i < nrArticles - 1; i++)
                {
                    bool isAnyChange = false;
                    for (int j = 0; j < nrArticles - 1; j++)
                    {
                        if (articles[j].Price > articles[j + 1].Price)
                        {
                            isAnyChange = true;
                            (articles[j], articles[j + 1]) = (articles[j + 1], articles[j]);
                        }
                    }
                    if (!isAnyChange)
                    {
                        Console.WriteLine($"Articles Sorted by Price");
                        PrintReciept("Price");
                        break;
                    }
                }
            }


        }
    }
}