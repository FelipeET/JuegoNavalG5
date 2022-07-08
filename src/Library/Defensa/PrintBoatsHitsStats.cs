using System;
using System.Text;

namespace PII_Batalla_Naval
{
    public class PrintBoatsHitsStats : IPrintStats
    {
        public PrintBoatsHitsStats(){}
        public void PrintStats(int data)
        {
             StringBuilder s = new StringBuilder();
             s.Append($"La cantidad de disparos que han impactado barcos son: {data}");
             Console.WriteLine(s.ToString());
        }
    }
}