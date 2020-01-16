using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD4_exo1;
using System.Threading;

public struct doublon
    {
        public int value;
        public int ite;
    }
class Program
{
    static void Main(string[] args)
    {

        int[][] matrice = new int[][]
        {
            new int[] {2,2,3,8,4,3},
            new int[] {1,2,3,10,4,6},
            new int[] {1,2,3,4,5,6},
            new int[] {1,2,3,10,4,6},
            new int[] {1,2,3,10,4,6},
            new int[] {1,2,3,4,5,6}
        };

        Task_List tasks = new Task_List();
        Thread[] thread_list = new Thread[matrice.Length];

        // COUNT THE ITERATIONS
        
        for(int i=0; i<matrice[0].Length;i++) // we browse the matrix and split it into submaatrix
        {
            int[][] submatrice = {matrice[i]};
            IterationCount itc = new IterationCount(submatrice);
            tasks.add(itc);
            thread_list[i] = new Thread(new ThreadStart(itc.execute));
            thread_list[i].Start();
        }

        foreach (Thread thread in thread_list)
        {
            thread.Join();
        }

        List<object> results = tasks.GetResults;


        // Display the results 
        for (int i=0;i<results.Count;i++)
        {
            List<doublon> res = (List<doublon>)results[i];
            Console.WriteLine("\n Ligne {0} \n", i);
            for (int j = 0; j < res.Count; j++)
            {
                Console.WriteLine("Value = {0}, Ite = {1}", res[j].value, res[j].ite);
            }
        }


        // COMPUTE THE AVERAGE

        Thread[] thread_list2 = new Thread[matrice.Length];

        for (int i = 0; i < matrice[0].Length; i++) // we browse the matrix and split it into submaatrix
        {
            int[][] submatrice = { matrice[i] };
            AverageCount avgc = new AverageCount(submatrice);
            tasks.add(avgc);
            thread_list2[i] = new Thread(new ThreadStart(avgc.execute));
            thread_list2[i].Start();
        }

        foreach (Thread thread in thread_list2)
        {
            thread.Join();
        }

        List<object> results_avg = tasks.GetResults;
        Console.WriteLine("\n");

        double res2 = 0;
        int it = 0;

        // Display the results and compute the total average in the for loop
        for (int i = matrice.Length; i < results_avg.Count; i++)
        {
            Console.WriteLine("Ligne {1} : Average = {0}", results_avg[i],i- matrice.Length);
            double res_avg = (double)results_avg[i];
            res2 = res2 + res_avg;
            it = it + 1;
        }

        Console.WriteLine("AVG final : {0}", res2/it);

        Console.ReadKey();
    }
}
