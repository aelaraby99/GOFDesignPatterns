namespace SingletonThreadSafe
{
    internal class Program
    {
        static MemoryLogger logger;
        static void Main( string [] args )
        {
            AssignVoucher("aelaraby999@gmail.com" , "VOUCHER_100");
            UseVoucher("VOUCHER_100");
            logger.ShowLog();
            Console.ReadKey();
        }
        static void AssignVoucher( string email , string voucher )
        {
            logger = MemoryLogger.GetInstance;
            // Logic here
            logger.LogInfo($"Voucher '{voucher}' assigned");
            // Another Logic
            logger.LogError($"Unable to send email '{email}'");
        }
        static void UseVoucher( string voucher )
        {
            logger = MemoryLogger.GetInstance;
            // Logic here
            logger.LogWarning($"3 attempts made to validate the voucher");
            // Logic here
            logger.LogInfo($"'{voucher}' is used");
        }
    }
}
