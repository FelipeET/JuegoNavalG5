namespace PII_Batalla_Naval
{
    public class WaterHits : IHits
    {
        private int count = 0;

        public WaterHits(){}

        public void CountHits()
        {
            count++;

        }

        public int Count 
        {
            get 
            {
                return count;
            }
        }
    }
}