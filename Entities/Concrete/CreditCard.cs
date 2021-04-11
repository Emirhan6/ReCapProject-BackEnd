using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public int UserId { get; set; }
        public int CardNumber { get; set; }
        public string FullName { get; set; }
    }
}
