﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebService.ReturnModels
{
    public class ContentOfOutgoingTransaction
    {
        public int id { get; set; }

        public int Fruit { get; set; }

        public int ProcessedOutgoingTransaction { get; set; }

        public ContentOfOutgoingTransaction(int id, int Fruit, int ProcessedOutgoingTransaction)
        {
            this.id = id;
            this.Fruit = Fruit;
            this.ProcessedOutgoingTransaction = ProcessedOutgoingTransaction;
        }

    }
}