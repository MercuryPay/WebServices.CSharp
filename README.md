WebServices.CSharp
====================

VS 2010 console application processing transactions to our web services platform.

3 step process to integrate to Mercury Web Services.

##Step 1: Build Request with Key Value Pairs
  
Create a Dictionary&lt;string, object&gt; variable and add all the Key Value Pairs.
  
```
Dictionary<string, object> requestDictionary = new Dictionary<string, object>();

requestDictionary.Add("MerchantID", merchantID);
requestDictionary.Add("LaneID", laneID);
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
requestDictionary.Add("EncryptedBlock", swipedCreditEncryptedBlock);
requestDictionary.Add("EncryptedKey", swipedCreditEncryptedKey);
requestDictionary.Add("Purchase", purchase);
requestDictionary.Add("OperatorID", operatorID);
```
  
##Step 2: Process the Transaction

a. Create a service reference to our testing URL @ https://w1.mercurydev.net/ws/ws.asmx.

b. Use XMLHelper.BuildXMLRequest(Dictionary<string, object) to create the XML Request string.

c. Call the CreditTransaction web method with XML Request string and Merchant Password.

```
string xmlRequest = XMLHelper.BuildXMLRequest(requestDictionary).ToString();
string xmlResponse = string.Empty;

using (MercuryWebServices.wsSoapClient client = new MercuryWebServices.wsSoapClient())
{
   xmlResponse = client.CreditTransaction(xmlRequest, password);
}
```

##Step 3: Parse the XML Response

Parse the XML Response using the XMLHelper.ParseXMLResponse(string xmlResponse) method.

This method returns a Dictionary&lt;string, string&gt;.

Approved transactions will have a CmdStatus equal to "Approved".

```
Dictionary<string, string> responseDictionary = XMLHelper.ParseXMLResponse(xmlResponse);

if (responseDictionary.ContainsKey("CmdStatus")
   && responseDictionary["CmdStatus"] == "Approved")
{
   // Approved logic goes here
}
else
{
   // Declined/Error logic goes here
}
```

###©2014 Mercury Payment Systems, LLC - all rights reserved.

Disclaimer:
This software and all specifications and documentation contained herein or provided to you hereunder (the "Software") are provided free of charge strictly on an "AS IS" basis. No representations or warranties are expressed or implied, including, but not limited to, warranties of suitability, quality, merchantability, or fitness for a particular purpose (irrespective of any course of dealing, custom or usage of trade), and all such warranties are expressly and specifically disclaimed. Mercury Payment Systems shall have no liability or responsibility to you nor any other person or entity with respect to any liability, loss, or damage, including lost profits whether foreseeable or not, or other obligation for any cause whatsoever, caused or alleged to be caused directly or indirectly by the Software. Use of the Software signifies agreement with this disclaimer notice.

[![Analytics](https://ga-beacon.appspot.com/UA-1785046-18/WebServices.CSharp/readme?pixel)](https://github.com/MercuryPay)
