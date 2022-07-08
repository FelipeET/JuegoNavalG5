using System;
using System.Text;

namespace PII_Batalla_Naval
{
    public class PrintWaterHitsStats : IPrintStats
    {
        public PrintWaterHitsStats(){}
        public void PrintStats(int data)
        {
             StringBuilder s = new StringBuilder();
             s.Append($"La cantidad de disparos que han impactado el agua son: {data}");
             Console.WriteLine(s.ToString());
        }
    }
}