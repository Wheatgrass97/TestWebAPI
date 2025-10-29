namespace TestWebAPI.Helpers
{
    public static class TransactionStatusHelper
    {
        public static string TsConvertToStr(int transactionStatus)
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

        public static int TsConvertToInt(string ts)
        {
            if (ts.ToLower() == "approved")
            {
                return 1;
            }
            else if (ts.ToLower() == "failed" || ts.ToLower() == "rejected")
            {
                return 2;
            }
            else if (ts.ToLower() == "finished" || ts.ToLower() == "done")
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
