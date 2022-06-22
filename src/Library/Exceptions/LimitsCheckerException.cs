using System;

namespace PII_Batalla_Naval{
    public class LimitsCheckerException: Exception
    {
        public LimitsCheckerException(string message): base (message)
        {
            
        }
    }
}