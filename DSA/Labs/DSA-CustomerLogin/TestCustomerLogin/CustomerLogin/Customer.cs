using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class Customer : ITableEntity
    {
        private CryptoHelper _cryptoHelper = new();
        public Customer(string name,string email, string password, string creditCard)
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            Name = name;
            Email = email;
            PasswordHash = _cryptoHelper.ComputeHash(password, Salt);
            CreditCardHash = _cryptoHelper.EncryptCreditCard(password,creditCard).Result;
        }
        public Customer() // default ctor is req. when TableClient deserialize json into new instance of customer
        {
            //intentionally left empty
        }

        //Json deserializer will match json prop to the public fields below
        public byte[] Salt;
        public string Name;
        public string Email;
        public byte[] PasswordHash;
        public byte[] CreditCardHash;

        //below are props required to implement ITableEntity        
        public string PartitionKey { get => Email; set => this.Email = value; }
        public string RowKey { get => Name; set => this.Name = value; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }


}
