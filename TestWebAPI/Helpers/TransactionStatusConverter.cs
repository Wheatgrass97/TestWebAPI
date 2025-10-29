namespace TestWebAPI.Helpers
{
    public static class TransactionStatusHelper
    {
        public static string TransactionStatusConverter(int transactionStatus)
        {
            if (transactionStatus == 1)
            {
                return "A";
            }
            else if (transactionStatus == 2)
            {
                return "R";
            }
            else if (transactionStatus == 3)
            {
                return "D";
            }
            else
            {
                return null;
            }
        }
    }
}
