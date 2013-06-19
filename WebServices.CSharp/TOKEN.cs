using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServices.CSharp
{
    public class TOKEN
    {
        // Transaction Varialbles
        private static string merchantID = "023358150511666";
        private static string password = "xyz";
        private static string invoiceNo = string.Empty;
        private static string memo = "Testing: WebServices.CSharp";
        private static string cvvData = "123";
        private static decimal purchase = 2.25m;
        private static string operatorID = "test";

        // VISA Partial Auth Test Card
        private static string swipedCreditTrack2 = "4003000123456781=15125025432198712345";
        private static string keyedCreditAcctNo = "4003000123456781";
        private static string keyedCreditExpDate = "1215";
        
        // Gift Test Card
        private static string swipedGiftTrack2 = "6050110010021825160=250110115";
        private static string keyedGiftAcctNo = "6050110010021825160";
        private static string keyedGiftExpDate = "0125";

        public void Run()
        {
            CreditSaleSwiped();

            CreditReturnSwiped();

            CreditSaleKeyed();

            CreditReturnKeyed();

            CreditSaleSwipedThenCreditReturnByRecordNo();

            CreditSaleSwipedThenCreditAdjustByRecordNo();

            // We include PrePaid transactions if you want to integrate to MercuryGift in the future 

            PrePaidBalanceSwiped();

            PrePaidNoNSFSaleSwiped();

            PrePaidReloadSwiped();

            PrePaidBalanceKeyed();

            PrePaidNoNSFSaleKeyed();

            PrePaidReloadKeyed();

            Console.Write("End of samples");
            Console.ReadLine();
        }

        private static void CreditSaleSwiped()
        {
            Console.Write("Hit Enter to run Credit Sale (Swiped)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "Sale");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("PartialAuth", "Allow");
            requestDictionary.Add("Track2", swipedCreditTrack2);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "Sale");
        }

        private static void CreditReturnSwiped()
        {
            Console.Write("Hit Enter to run Credit Return (Swiped)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "Return");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("Track2", swipedCreditTrack2);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "Return");
        }

        private static void CreditSaleKeyed()
        {
            Console.Write("Hit Enter to run Credit Sale (Keyed)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "Sale");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("PartialAuth", "Allow");
            requestDictionary.Add("AcctNo", keyedCreditAcctNo);
            requestDictionary.Add("ExpDate", keyedCreditExpDate);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("CVVData", cvvData);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "Sale");
        }

        private static void CreditReturnKeyed()
        {
            Console.Write("Hit Enter to run Credit Return (Keyed)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "Return");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("AcctNo", keyedCreditAcctNo);
            requestDictionary.Add("ExpDate", keyedCreditExpDate);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("CVVData", cvvData);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "Return");
        }

        private static void CreditSaleSwipedThenCreditReturnByRecordNo()
        {
            Console.Write("Hit Enter to run Credit Sale (Swiped) then Credit ReturnByRecordNo");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "Sale");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("PartialAuth", "Allow");
            requestDictionary.Add("Track2", swipedCreditTrack2);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "Sale");

            // For approved transactions, use RecordNo
            if (responseDictionary.ContainsKey("CmdStatus")
                && responseDictionary["CmdStatus"] == "Approved")
            {
                invoiceNo = NewInvoiceNo();

                // RecordNo from Credit Sale response
                string recordNo = responseDictionary["RecordNo"];

                requestDictionary.Clear();
                requestDictionary.Add("MerchantID", merchantID);
                requestDictionary.Add("TranType", "Credit");
                requestDictionary.Add("TranCode", "ReturnByRecordNo");
                requestDictionary.Add("InvoiceNo", invoiceNo);
                requestDictionary.Add("RefNo", invoiceNo);
                requestDictionary.Add("Memo", memo);
                requestDictionary.Add("Frequency", "OneTime");
                requestDictionary.Add("RecordNo", recordNo);
                requestDictionary.Add("Purchase", purchase);
                requestDictionary.Add("OperatorID", operatorID);

                responseDictionary = ProcessCreditTransaction(requestDictionary, password);

                DisplayResponseKeyValuePairs(responseDictionary, "Credit", "ReturnByRecordNo");
            }
        }

        private static void CreditSaleSwipedThenCreditAdjustByRecordNo()
        {
            Console.Write("Hit Enter to run Credit Sale (Swiped) then Credit AdjustByRecordNo");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "Sale");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("PartialAuth", "Allow");
            requestDictionary.Add("Track2", swipedCreditTrack2);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "Sale");

            // For approved transactions, use RecordNo
            if (responseDictionary.ContainsKey("CmdStatus")
                && responseDictionary["CmdStatus"] == "Approved")
            {
                // RecordNo from Credit Sale response
                string recordNo = responseDictionary["RecordNo"];
                // RefNo from the Credit Sale response
                string refNo = responseDictionary["RefNo"];
                // AuthCode from the Credit Sale response
                string authCode = responseDictionary["AuthCode"];

                requestDictionary.Clear();
                requestDictionary.Add("MerchantID", merchantID);
                requestDictionary.Add("TranType", "Credit");
                requestDictionary.Add("TranCode", "AdjustByRecordNo");
                requestDictionary.Add("InvoiceNo", refNo);
                requestDictionary.Add("RefNo", refNo);
                requestDictionary.Add("Memo", memo);
                requestDictionary.Add("Frequency", "OneTime");
                requestDictionary.Add("RecordNo", recordNo);
                requestDictionary.Add("Purchase", purchase);
                requestDictionary.Add("AuthCode", authCode);
                requestDictionary.Add("OperatorID", operatorID);

                responseDictionary = ProcessCreditTransaction(requestDictionary, password);

                DisplayResponseKeyValuePairs(responseDictionary, "Credit", "AdjustByRecordNo");
            }
        }
     
        private static void PrePaidBalanceSwiped()
        {
            Console.Write("Hit Enter to run PrePaid Balance (Swiped)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("IpPort", "9100");
            requestDictionary.Add("TranType", "PrePaid");
            requestDictionary.Add("TranCode", "Balance");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Track2", swipedGiftTrack2);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessGiftTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "PrePaid", "Balance");
        }

        private static void PrePaidNoNSFSaleSwiped()
        {
            Console.Write("Hit Enter to run PrePaid NoNSFSale (Swiped)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("IpPort", "9100");
            requestDictionary.Add("TranType", "PrePaid");
            requestDictionary.Add("TranCode", "NoNSFSale");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Track2", swipedGiftTrack2);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessGiftTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "PrePaid", "NoNSFSale");
        }

        private static void PrePaidReloadSwiped()
        {
            Console.Write("Hit Enter to run PrePaid Reload (Swiped)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("IpPort", "9100");
            requestDictionary.Add("TranType", "PrePaid");
            requestDictionary.Add("TranCode", "Reload");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Track2", swipedGiftTrack2);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessGiftTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "PrePaid", "Reload");
        }

        private static void PrePaidBalanceKeyed()
        {
            Console.Write("Hit Enter to run PrePaid Balance (Keyed)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("IpPort", "9100");
            requestDictionary.Add("TranType", "PrePaid");
            requestDictionary.Add("TranCode", "Balance");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("AcctNo", keyedGiftAcctNo);
            requestDictionary.Add("ExpDate", keyedGiftExpDate);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessGiftTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "PrePaid", "Balance");
        }

        private static void PrePaidNoNSFSaleKeyed()
        {
            Console.Write("Hit Enter to run PrePaid NoNSFSale (Keyed)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("IpPort", "9100");
            requestDictionary.Add("TranType", "PrePaid");
            requestDictionary.Add("TranCode", "NoNSFSale");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("AcctNo", keyedGiftAcctNo);
            requestDictionary.Add("ExpDate", keyedGiftExpDate);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessGiftTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "PrePaid", "NoNSFSale");
        }

        private static void PrePaidReloadKeyed()
        {
            Console.Write("Hit Enter to run PrePaid Reload (Keyed)");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("IpPort", "9100");
            requestDictionary.Add("TranType", "PrePaid");
            requestDictionary.Add("TranCode", "Reload");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("AcctNo", keyedGiftAcctNo);
            requestDictionary.Add("ExpDate", keyedGiftExpDate);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessGiftTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "PrePaid", "Reload");
        }

        private static string NewInvoiceNo()
        {
            return DateTime.Now.ToString("yyMMddhhmmssfff");
        }

        private static Dictionary<string, string> ProcessCreditTransaction(Dictionary<string, object> requestDictionary, string password)
        {
            // Build XML Request from KeyValuePairs
            string xmlRequest = XMLHelper.BuildXMLRequest(requestDictionary).ToString();
            string xmlResponse = string.Empty;

            using (MercuryWebServices.wsSoapClient client = new MercuryWebServices.wsSoapClient())
            {
                Console.WriteLine("Processing Credit Transaction...");
                xmlResponse = client.CreditTransaction(xmlRequest, password);
            }

            // Parse XML Response into KeyValuePairs
            return XMLHelper.ParseXMLResponse(xmlResponse);
        }

        private static Dictionary<string, string> ProcessGiftTransaction(Dictionary<string, object> requestDictionary, string password)
        {
            // Build XML Request from KeyValuePairs
            string xmlRequest = XMLHelper.BuildXMLRequest(requestDictionary).ToString();
            string xmlResponse = string.Empty;

            using (MercuryWebServices.wsSoapClient client = new MercuryWebServices.wsSoapClient())
            {
                Console.WriteLine("Processing Gift Transaction...");
                xmlResponse = client.GiftTransaction(xmlRequest, password);
            }

            // Parse XML Response into KeyValuePairs
            return XMLHelper.ParseXMLResponse(xmlResponse);
        }

        private static void DisplayResponseKeyValuePairs(Dictionary<string, string> responseDictionary, string tranType, string tranCode)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("--- Response Key Value Pairs for {0} {1} ---", tranType, tranCode));

            foreach (KeyValuePair<string, string> kvp in responseDictionary)
            {
                Console.WriteLine(string.Format("{0}:{1};", kvp.Key, kvp.Value));
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
