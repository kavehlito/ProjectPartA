using System;

namespace ProjectPartA_A1
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
            ReadArticles();
            PrintReciept();
        }

        private static void ReadArticles()
        {
            //Your code to enter the articles

            while (true)
            {
                Console.WriteLine("How many articles do you want (between 1 and 10)?");
                string input = Console.ReadLine();
                bool isString = int.TryParse(input, out nrArticles);


                if (nrArticles < 1 || nrArticles > _maxNrArticles)
                    Console.WriteLine("Wrong input, try a number between 1 and 10!");
                else break;
            }

            int i = 0;
            while (i < nrArticles)
            {
                Console.WriteLine($"Please enter the name and price for article #{i} in the format name; price (example Beer; 2,25): ");
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

                articles[i].Name = name;
                articles[i].Price = price;

                i++;
            }
        }
        private static void PrintReciept()
        {
            //Your code to print out a reciept
            Console.WriteLine($"Receipt Purchased Articles \nPurchace date: {DateTime.Now}");
            Console.WriteLine();
            Console.WriteLine($"Number of articles purchased: {nrArticles}");
        }
    }
}
