namespace PII_Batalla_Naval
{
    public class BoatsHits : IHits
    {
         private int count = 0;

        public BoatsHits(){}

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
