using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomerLogin;
using Azure.Security.KeyVault.Keys;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace TestCustomerLogin
{
    [TestClass]
    public class CustomersDBAzureStorageTest
    {
        private string _tenantID;
        private string _clientID;
        private string _ClientSecret;
        private string _tableConnStr;
        private string _tableName;
        private string _keyVaultUri;
        private KeyClient _keyClient;
        private CryptographyClient _key;
        private TableServiceClient _tableServiceClient;
        [TestInitialize]
        public void init()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .Build();

            _tenantID = config["Azure:TenantID"];
            _clientID = config["Azure:ClientID"];
            _ClientSecret = config["Azure:ClientSecret"];
            _tableConnStr = config["Azure:TableConnStr"];
            _tableName = config["Azure:TableName"] + Guid.NewGuid().ToString().Substring(0, 4);
            _keyVaultUri = config["Azure:KeyVaultUri"];
            //code to create table: _TableName
            _tableServiceClient = new TableServiceClient(_tableConnStr);
            _tableServiceClient.CreateTableIfNotExists(_tableName);
            // create key client
            _keyClient = new KeyClient( new Uri(_keyVaultUri), new ClientSecretCredential(_tenantID, _clientID, _ClientSecret));
            _key = _keyClient.GetCryptographyClient("mssa");
        }
        [TestMethod]
        public void EncDecWithKeyVault()
        {
            var plainText = "HelloWorld";
            byte[] encryptedResult = _key.Encrypt(EncryptionAlgorithm.RsaOaep, Encoding.UTF8.GetBytes(plainText)).Ciphertext;
            byte[] decryptedBytes = _key.Decrypt(EncryptionAlgorithm.RsaOaep, encryptedResult).Plaintext;
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            
        }
        [TestMethod]
        public void ConfirmTenantIDAndOtherVariables()
        {
            Assert.AreEqual("75202359-8ca2-4185-af85-e8d288e60729", _tenantID);
        }
        //insert and read back test
        [TestMethod]
        public void EntityInsertAndRetrieveTest()
        {
            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            var tableEntity = new TableEntity("x", "y")
            {
                {"Product", "Marker Set" },
                {"Price", 5.00 },
                {"Quantity", 21 }
            };
            _testTable.AddEntity(tableEntity);
            var result = _testTable.GetEntity<TableEntity>("x", "y").Value; //x-partitionkey, y-rowkey
            Assert.AreEqual("Marker Set", result.GetString("Product"));
            Assert.AreEqual(5.00, result.GetDouble("Price"));
            Assert.AreEqual(21, result.GetInt32("Quantity"));


        }
        [TestMethod]
        public void CustomerInsertAndRetrieveTest()
        {
            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            Customer testCustomer = new Customer("alice", "alice@live.com", "password", "11112222");
            _testTable.AddEntity(testCustomer);
            Customer result = _testTable.GetEntity<Customer>("alice@live.com", "alice");
            Assert.AreEqual(result.Name, testCustomer.Name);
            Assert.AreEqual(result.Email, testCustomer.Email);
            Assert.AreEqual(Convert.ToBase64String(result.PasswordHash), Convert.ToBase64String(testCustomer.PasswordHash));
            Assert.AreEqual(Convert.ToBase64String(result.CreditCardHash), Convert.ToBase64String(testCustomer.CreditCardHash));
        }
        public void CustomerInsertAndQueryTest()
        {
            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            Customer testCustomer1 = new Customer("bambi", "bambi@gmail.com", "password", "11112222");
            Customer testCustomer2 = new Customer("bambi", "bambi@yahoo.com", "password", "11112222");
            Customer testCustomer3 = new Customer("bambi", "bambi@outlook.com", "password", "11112222");
            _testTable.AddEntity(testCustomer1);
            _testTable.AddEntity(testCustomer2);
            _testTable.AddEntity(testCustomer3);
            var result = _testTable.Query<Customer>(filter: TableClient.CreateQueryFilter($"Name eq  bambi"));

            Assert.AreEqual(1, result.Where(c => c.Email == "bambi@gmail.com"));
            Assert.AreEqual(1, result.Where(c => c.Email == "bambi@outlook.com"));
            Assert.AreEqual(3, result.Where(c => c.Email == "bambi@gmail.com"));

        }
        [TestCleanup]
        public void Cleanup()
        {
            //code to delete table: _TableName
            //_tableServiceClient.DeleteTable(_tableName);
        }
    }
}
