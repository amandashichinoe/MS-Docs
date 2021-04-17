using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AsyncBreakfast
{
    class Program
    {
        /*forma assíncrona */
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number){ /*forma assíncrona */
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        } /* */

        /*forma síncrona 
        static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast  = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

        } */

        private static Juice PourOJ(){
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting buttter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices) { //forma assíncrona
        //private static Toast ToastBread(int slices){ //forma síncrona
            for(int slice =0; slice < slices; slice++){
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000); //forma assíncrona
            //Task.Delay(3000).Wait(); //forma síncrona
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices) { //forma assíncrona
        //private static Bacon FryBacon(int slices) { //forma síncrona
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000); //forma assíncrona
            //Task.Delay(3000).Wait(); //forma síncrona
            for(int slice = 0; slice < slices; slice ++){
                Console.WriteLine ("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000); //forma assíncrona
            //Task.Delay(3000).Wait(); //forma síncrona
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }       

        private static async Task<Egg> FryEggsAsync(int howMany){ //forma assíncrona
        //private static Egg FryEggs(int howMany){ //forma síncrona
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000); //forma assíncrona
            //Task.Delay(3000).Wait(); //forma síncrona
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine($"cooking the eggs ...");
            await Task.Delay(3000); //forma assíncrona
            //Task.Delay(3000).Wait(); //forma síncrona
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee(){
        Console.WriteLine("Pouring coffee");
        return new Coffee();
        }
    }
}
