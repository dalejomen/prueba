namespace Ibero.Services.Avaya.Core.Models
{

    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Transaction
    {
        public string code { get; set; }
        public string message { get; set; }
        public Details details { get; set; }

    }
}
