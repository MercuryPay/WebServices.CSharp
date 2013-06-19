
namespace WebServices.CSharp
{
    class Program
    {
        /// <summary>
        /// E2ETKN = Merchant setup for E2E Encryption with Mercury Tokenization
        /// TOKEN = Merchant setup for Mercury Tokenization only
        /// </summary>
        static void Main(string[] args)
        {
            E2ETKN e2etkn = new E2ETKN();
            e2etkn.Run();

            //// Uncomment the code below to run Mercury Tokenization transactions
            //TOKEN token = new TOKEN();
            //token.Run();
        }
    }
}
