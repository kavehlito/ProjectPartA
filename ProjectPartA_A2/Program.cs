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
            int menuSel = 5;

            //Your code for menu selection

            return menuSel;
        }
        private static void MenuExecution(int menuSel)
        {
            try
            {
                //Your code for execution based on the menu selection
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ReadAnArticle()
        {
            //Your code to enter an article
        }
        private static void RemoveAnArticle()
        {
            //Your code to remove an article
        }

        private static void PrintReciept(string title)
        {
            //Your code to print a receipt
        }

        private static void SortArticles(bool sortByName = false)
        {
            //Your code to Sort. Either BubbleSort or SelectionSort
        }
    }
}
