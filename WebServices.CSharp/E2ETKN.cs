using System;
using System.Collections.Generic;

namespace WebServices.CSharp
{
    public class E2ETKN
    {
        // Transaction Varialbles
        private static string merchantID = "118725340908147";
        private static string password = "xyz";
        private static string invoiceNo = string.Empty;
        private static string memo = "Testing: WebServices.CSharp";
        private static string cvvData = "123";
        private static decimal purchase = 2.25m;
        private static string operatorID = "test";

        // VISA Partial Auth Test Card # 4005550000000480
        private static string swipedCreditTrack2EncryptedBlock = "91497BA2363B926730CD8BBC943D501865B56834F9A50EE4DD1385589335A4A2E9CCDE5F5398972D";
        private static string swipedCreditTrack2EncryptedKey = "9500030000039420016C";
        private static string keyedCreditEncryptedBlock = "B16BF4B39194A90BE726F588C28355F608BBF0695C27E8DC1AB453259186270537843A69A78439F5";
        private static string keyedCreditEncryptedKey = "9500030000039420016D";

        // Test Gift Card # 6050110010021825160
        private static string swipedGiftTrack2EncryptedBlock = "FFFBE71805C791341D15F948ECDFE50134B5903A9E12DBF8CB940547D0DB53BB";
        private static string swipedGiftTrack2EncryptedKey = "9500030000039420016E";
        private static string keyedGiftEncryptedBlock = "DB1E14F6686E2B7FE7C11765046ECA13B99971ED642BC1CEB8DF746A0692CC3AEE5425BC8E1FF126";
        private static string keyedGiftEncryptedKey = "9500030000039420016F";

        public void Run()
        {
            CreditSaleSwiped();

            CreditReturnSwiped();

            CreditSaleKeyed();

            CreditReturnKeyed();

            CreditSaleSwipedThenCreditReturnByRecordNo();

            CreditPreAuthSwipedThenCreditPreAuthCaptureByRecordNo();

            CreditPreAuthKeyedThenCreditPreAuthCaptureByRecordNo();

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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedCreditTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedCreditTrack2EncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedCreditTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedCreditTrack2EncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Keyed");
            requestDictionary.Add("EncryptedBlock", keyedCreditEncryptedBlock);
            requestDictionary.Add("EncryptedKey", keyedCreditEncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Keyed");
            requestDictionary.Add("EncryptedBlock", keyedCreditEncryptedBlock);
            requestDictionary.Add("EncryptedKey", keyedCreditEncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedCreditTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedCreditTrack2EncryptedKey);
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

        private static void CreditPreAuthSwipedThenCreditPreAuthCaptureByRecordNo()
        {
            Console.Write("Hit Enter to run Credit PreAuth (Swiped) then Credit PreAuthCaptureByRecordNo");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "PreAuth");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("PartialAuth", "Allow");
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedCreditTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedCreditTrack2EncryptedKey);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("Authorize", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "PreAuth");

            // For approved transactions, use RecordNo, AuthCode and AcqRedData
            if (responseDictionary.ContainsKey("CmdStatus")
                && responseDictionary["CmdStatus"] == "Approved")
            {
                invoiceNo = NewInvoiceNo();

                // RecordNo from Credit PreAuthCaptureByRecordNo response
                string recordNo = responseDictionary["RecordNo"];
                string authCode = responseDictionary["AuthCode"];
                string acqRefData = responseDictionary["AcqRefData"];

                requestDictionary.Clear();
                requestDictionary.Add("MerchantID", merchantID);
                requestDictionary.Add("TranType", "Credit");
                requestDictionary.Add("TranCode", "PreAuthCaptureByRecordNo");
                requestDictionary.Add("InvoiceNo", invoiceNo);
                requestDictionary.Add("RefNo", invoiceNo);
                requestDictionary.Add("Memo", memo);
                requestDictionary.Add("Frequency", "OneTime");
                requestDictionary.Add("RecordNo", recordNo);
                requestDictionary.Add("Purchase", purchase);
                requestDictionary.Add("Authorize", purchase);
                requestDictionary.Add("AuthCode", authCode);
                requestDictionary.Add("AcqRefData", acqRefData);
                requestDictionary.Add("OperatorID", operatorID);

                responseDictionary = ProcessCreditTransaction(requestDictionary, password);

                DisplayResponseKeyValuePairs(responseDictionary, "Credit", "PreAuthCaptureByRecordNo");
            }
        }

        private static void CreditPreAuthKeyedThenCreditPreAuthCaptureByRecordNo()
        {
            Console.Write("Hit Enter to run Credit PreAuth (Keyed) then Credit PreAuthCaptureByRecordNo");
            Console.ReadLine();

            invoiceNo = NewInvoiceNo();

            // Create Request KeyValuePairs
            Dictionary<string, object> requestDictionary = new Dictionary<string, object>();
            requestDictionary.Add("MerchantID", merchantID);
            requestDictionary.Add("TranType", "Credit");
            requestDictionary.Add("TranCode", "PreAuth");
            requestDictionary.Add("InvoiceNo", invoiceNo);
            requestDictionary.Add("RefNo", invoiceNo);
            requestDictionary.Add("Memo", memo);
            requestDictionary.Add("Frequency", "OneTime");
            requestDictionary.Add("RecordNo", "RecordNumberRequested");
            requestDictionary.Add("PartialAuth", "Allow");
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Keyed");
            requestDictionary.Add("EncryptedBlock", keyedCreditEncryptedBlock);
            requestDictionary.Add("EncryptedKey", keyedCreditEncryptedKey);
            requestDictionary.Add("Purchase", purchase);
            requestDictionary.Add("Authorize", purchase);
            requestDictionary.Add("OperatorID", operatorID);

            // Process Transaction and get Response KeyValuePairs           
            Dictionary<string, string> responseDictionary = ProcessCreditTransaction(requestDictionary, password);

            DisplayResponseKeyValuePairs(responseDictionary, "Credit", "PreAuth");

            // For approved transactions, use RecordNo, AuthCode and AcqRedData
            if (responseDictionary.ContainsKey("CmdStatus")
                && responseDictionary["CmdStatus"] == "Approved")
            {
                invoiceNo = NewInvoiceNo();

                // RecordNo from Credit PreAuthCaptureByRecordNo response
                string recordNo = responseDictionary["RecordNo"];
                string authCode = responseDictionary["AuthCode"];
                string acqRefData = responseDictionary["AcqRefData"];

                requestDictionary.Clear();
                requestDictionary.Add("MerchantID", merchantID);
                requestDictionary.Add("TranType", "Credit");
                requestDictionary.Add("TranCode", "PreAuthCaptureByRecordNo");
                requestDictionary.Add("InvoiceNo", invoiceNo);
                requestDictionary.Add("RefNo", invoiceNo);
                requestDictionary.Add("Memo", memo);
                requestDictionary.Add("Frequency", "OneTime");
                requestDictionary.Add("RecordNo", recordNo);
                requestDictionary.Add("Purchase", purchase);
                requestDictionary.Add("Authorize", purchase);
                requestDictionary.Add("AuthCode", authCode);
                requestDictionary.Add("AcqRefData", acqRefData);
                requestDictionary.Add("OperatorID", operatorID);

                responseDictionary = ProcessCreditTransaction(requestDictionary, password);

                DisplayResponseKeyValuePairs(responseDictionary, "Credit", "PreAuthCaptureByRecordNo");
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedGiftTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedGiftTrack2EncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedGiftTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedGiftTrack2EncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Swiped");
            requestDictionary.Add("EncryptedBlock", swipedGiftTrack2EncryptedBlock);
            requestDictionary.Add("EncryptedKey", swipedGiftTrack2EncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Keyed");
            requestDictionary.Add("EncryptedBlock", keyedGiftEncryptedBlock);
            requestDictionary.Add("EncryptedKey", keyedGiftEncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Keyed");
            requestDictionary.Add("EncryptedBlock", keyedGiftEncryptedBlock);
            requestDictionary.Add("EncryptedKey", keyedGiftEncryptedKey);
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
            requestDictionary.Add("EncryptedFormat", "MagneSafe");
            requestDictionary.Add("AccountSource", "Keyed");
            requestDictionary.Add("EncryptedBlock", keyedGiftEncryptedBlock);
            requestDictionary.Add("EncryptedKey", keyedGiftEncryptedKey);
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
