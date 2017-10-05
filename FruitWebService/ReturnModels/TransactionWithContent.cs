using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class TransactionWithContent
    {
        ProcessedIncomingTransactions incomingTransaction;
        List<ContentOfIncomingTransaction> contentOfTransaction;

        public TransactionWithContent(ProcessedIncomingTransactions incomingTransaction, List<ContentOfIncomingTransaction> contentOfTransaction)
        {
            this.incomingTransaction = incomingTransaction;
            this.contentOfTransaction = contentOfTransaction;
        }
    }
}