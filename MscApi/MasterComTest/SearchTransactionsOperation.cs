using MasterCard.Api.Mastercom;
using MasterCard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterComTest
{
    public class SearchTransactionsOperation : MasterComOperation
    {
        protected override void RunOperation()
        {
            RequestMap map = new RequestMap();
            map.Set("acquirerRefNumber", "05436847276000293995738");
            map.Set("primaryAccountNum", "5488888888887192");
            map.Set("transAmountFrom", "10000");
            map.Set("transAmountTo", "20050");
            map.Set("tranStartDate", "2017-10-01");
            map.Set("tranEndDate", "2017-10-01");
            Transactions response = Transactions.searchForTransaction(map);

            Out(response, "authorizationSummaryCount"); //-->1
            Out(response, "message"); //-->Search returned 1 records
            Out(response, "authorizationSummary[0].originalMessageTypeIdentifier"); //-->0110
            Out(response, "authorizationSummary[0].banknetDate"); //-->160107
            Out(response, "authorizationSummary[0].transactionAmountUsd"); //-->401.17
            Out(response, "authorizationSummary[0].primaryAccountNumber"); //-->5488888888887192
            Out(response, "authorizationSummary[0].processingCode"); //-->00
            Out(response, "authorizationSummary[0].transactionAmountLocal"); //-->000000010000
            Out(response, "authorizationSummary[0].authorizationDateAndTime"); //-->108125633
            Out(response, "authorizationSummary[0].track2"); //-->Y101
            Out(response, "authorizationSummary[0].authenticationId"); //-->111111
            Out(response, "authorizationSummary[0].cardAcceptorName"); //-->MASTERCARD
            Out(response, "authorizationSummary[0].cardAcceptorCity"); //-->SAINT LOUIS
            Out(response, "authorizationSummary[0].cardAcceptorState"); //-->MO
            Out(response, "authorizationSummary[0].track1"); //-->N
            Out(response, "authorizationSummary[0].currencyCode"); //-->840
            Out(response, "authorizationSummary[0].chipPresent"); //-->N
            Out(response, "authorizationSummary[0].transactionId"); //-->hqCnaMDqmto4wnL+BSUKSdzROqGJ7YELoKhEvluycwKNg3XTz/faIJhFDkl9hW081B5tTqFFiAwCpcocPdB2My4t7DtSTk63VXDl1CySA8Y
            Out(response, "authorizationSummary[0].clearingSummary[0].primaryAccountNumber"); //-->5488888888887192
            Out(response, "authorizationSummary[0].clearingSummary[0].transactionAmountLocal"); //-->2500
            Out(response, "authorizationSummary[0].clearingSummary[0].dateAndTimeLocal"); //-->170719010100
            Out(response, "authorizationSummary[0].clearingSummary[0].cardDataInputCapabililty"); //-->5
            Out(response, "authorizationSummary[0].clearingSummary[0].cardholderAuthenticationCapability"); //-->9
            Out(response, "authorizationSummary[0].clearingSummary[0].cardPresent"); //-->1
            Out(response, "authorizationSummary[0].clearingSummary[0].acquirerReferenceNumber"); //-->05413364365000000000667
            Out(response, "authorizationSummary[0].clearingSummary[0].cardAcceptorName"); //-->TEST MERCHANT NAME
            Out(response, "authorizationSummary[0].clearingSummary[0].currencyCode"); //-->840
            Out(response, "authorizationSummary[0].clearingSummary[0].transactionId"); //-->U7dImb1ncs24LKNU9dDpl+FHlPzyfYOOv/5PijTlO6wHH09l7aiVJ1KJHp3sWPUHH0l90J1U82DGrE3hq72ARA
            // This sample shows looping through authorizationSummary
            Console.WriteLine("This sample shows looping through authorizationSummary");
            foreach (Dictionary<String, Object> item in (List<Dictionary<String, Object>>)response["authorizationSummary"])
            {
                Out(item, "originalMessageTypeIdentifier");
                Out(item, "banknetDate");
                Out(item, "transactionAmountUsd");
                Out(item, "primaryAccountNumber");
                Out(item, "processingCode");
                Out(item, "transactionAmountLocal");
                Out(item, "authorizationDateAndTime");
                Out(item, "track2");
                Out(item, "authenticationId");
                Out(item, "cardAcceptorName");
                Out(item, "cardAcceptorCity");
                Out(item, "cardAcceptorState");
                Out(item, "track1");
                Out(item, "currencyCode");
                Out(item, "chipPresent");
                Out(item, "transactionId");
                Out(item, "clearingSummary");
            }
        }
    }
}
