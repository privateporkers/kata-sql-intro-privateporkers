using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var test = dapperOrProduct();
            foreach (var prod in test.GetProductWithReview())
            {
                Console.WriteLine($"Product Name: {prod.Name}  Reviews:  {prod.Comments}");
            }*/

            //DapperChoice();
            crudChoice(dapperChoice());
        }

        public static string dapperChoice()
        {
            var answ = " ";
            Console.WriteLine("Would you like to Create(C), Delete(D), Update(U), or get all(A)?");
            while( !(answ == "u" || answ == "c" || answ == "d" || answ == "a"))
            {
                answ = Console.ReadLine().ToLower();
                if(answ == "u" || answ == "c" || answ == "d" || answ == "a")
                {
                    break;
                }
                Console.WriteLine("That is not one of the options! Please pick one");
            }

            return answ;
        }

        public static IProductRepo dapperOrProduct()
        {
            IProductRepo choice;
            var connectionString = " Server=localhost;Database=adventureworks;Uid=root;Pwd=";

            Console.WriteLine("Do you want to use Dapper? (y or n)");
            string dap  = " ";

            while( !( dap == "y" || dap == "n" ) )
            {
                dap = Console.ReadLine();
                if(dap == "y" || dap == "n")
                {
                    break;
                }
                Console.WriteLine("That is is not a valid choicde, please choose another");
            }


            if(dap == "y")
            {
                choice = new DapperProductRepository(connectionString);
            }
            else
            {
                choice = new ProductRepository(connectionString);
            }

            return choice;
        }

        public static int TestNum()
        {
            int num;

            while(!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("That is not a number, please enter a valid number");
            }

            return num;
        }

        public static void crudChoice(string str)
        {
            var produ = new Product();

            var repo = dapperOrProduct();

            if(str == "u")
            {
                Console.WriteLine("What ID do you want to specify?");
                produ.Id = Convert.ToInt32( Console.ReadLine() );

                Console.WriteLine("What would you like to rename this product?");
                produ.Name = Console.ReadLine();

                repo.UpdateProduct(produ);
            }

            if(str == "c")
            {
                Console.WriteLine("What is your product called?");
                produ.Name = Console.ReadLine();

                repo.InsertProduct(produ);
            }

            if(str == "d")
            {
                Console.WriteLine("What Id would you like to delete?");
                int num;
                num = TestNum();
                repo.DeleteProduct(num);

            }

            if(str == "a")
            {
                Console.WriteLine("Would you like a full list(a), an inner list with review(b), or reviews and all products(c)");
                string getProductsAnsw = " ";

                while( !(getProductsAnsw == "a" || getProductsAnsw == "b" || getProductsAnsw == "c"))
                {
                    getProductsAnsw = Console.ReadLine();
                    if(getProductsAnsw == "a" || getProductsAnsw == "b" || getProductsAnsw == "c")
                    {
                        break;
                    }
                    Console.WriteLine("That is not the correct input, please choose again");
                }

                switch(getProductsAnsw)
                {
                    case "a":
                        foreach (var prod in repo.GetProducts())
                        {
                            Console.WriteLine($"Product Name: {prod.Name}");
                        }
                        break;
                    case "b":
                        foreach (var prod in repo.GetProductWithReview())
                        {
                            Console.WriteLine($"Product Name: {prod.Name}  Reviews:  {prod.Comments}");
                        }
                        break;
                    case "c":
                        foreach (var prod in repo.GetProductAndReview())
                        {
                            Console.WriteLine($"Product Name: {prod.Name}  Reviews:  {prod.Comments}");
                        }
                        break;
                }
            }
        }
    }
}
