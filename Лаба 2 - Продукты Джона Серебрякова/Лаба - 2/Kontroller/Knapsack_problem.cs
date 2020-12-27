using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Kontroller
{
    public class Knapsack_problem
    {
        public static List<int> knapsack(int[] weight, int[] cost, int needed)
        {
            List<int> rukzak = new List<int>();
            int n = weight.Length;
            int[,] zy = new int[needed + 1, n + 1];
            for (int j = 1; j <= n; j++)
            {
                for (int w = 1; w <= needed; w++)
                {
                    if (weight[j - 1] <= w)
                    {
                        zy[w, j] = Math.Max(zy[w, j - 1], zy[w - weight[j - 1], j - 1] + cost[j - 1]);
                    }
                    else
                    {
                        zy[w, j] = zy[w, j - 1];
                    }
                }
            }
            int res = zy[needed, n], a = needed;
            for (int i = n; i >= 0; i--)  // идём в обратном порядке
            {
                if (res <= 0)  // условие прерывания - собрали "рюкзак" 
                    break;
                if (res == zy[a,i - 1])  // ничего не делаем, двигаемся дальше
                    continue;
                else
                // "забираем" предмет
                {
                    //rukzak.Add(weights[i - 1]);
                  rukzak.Add(i-1);
                  res -= cost[i - 1];  // отнимаем значение ценности от общей
                  a -= weight[i - 1];  }// отнимаем площадь от общей
            }
            rukzak.Add(zy[needed, n]);
            return rukzak;
        } 
    }
}
