using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPAdressTest
{
    public class IPAddress
    {
        public byte[] addressByte { get; set; } = new byte[4];
        public int[] subnetMask { get; set; } = new int[4];
        byte[] broadCast = new byte[4];
        byte[] networkId = new byte[4];

        public IPAddress(string addressString)
        {
            //if (!IsValidAddress(addressString))
            //{
            //    throw new ArgumentException();
            //}
            addressByte = ParseAddress(addressString);
            SetSubnetMask(addressString);
        }

        public string ParseAddressEnd(string addressString) {
            string[] subnetIDArr = addressString.Split('/');
            return subnetIDArr[1];
        }

        public byte[] ParseAddress(string addressString)
        {
            string[] partsStrArr = addressString.Split('.');
            partsStrArr[3] = partsStrArr[3].Split('/')[0];
            byte[] partsByteArr = new byte[4];

            for(int i = 0; i < partsStrArr.Length; i++)
            {
                partsByteArr[i] = Convert.ToByte(partsStrArr[i]); 
            }
            return partsByteArr; // { 123, 123, 122, 0 }
        }
        //11111111.11111111.11111110.00000000

        public bool IsSameNetwork(IPAddress other)
        {
            
            for (int i = 0; i < 4; i++)
            {
                if ((addressByte[i] & subnetMask[i]) != (other.addressByte[i] & other.subnetMask[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public void SetSubnetMask(string addressString)
        {
            int subnet = Convert.ToInt16(ParseAddressEnd(addressString)); //get /23
            byte[] subnetArr = new byte[32];
            string tmpSubnetString;

            int firstIndex = 0;
            int secondIndex = 8;
            for(int i = 0; i < subnet; i++) // ex: subnet = /23
            {
                subnetArr[i] = 1; //populate subnetMask. Ex: /23 = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 }.
            }
            for(int i = 0; i < 4; i++)
            {
                tmpSubnetString = "";
                foreach (var item in subnetArr[firstIndex..secondIndex])
                {
                    tmpSubnetString += item.ToString();
                }
                firstIndex += 8;
                secondIndex += 8;
                subnetMask[i] = int.Parse(tmpSubnetString);
            }
        }
        public void IsValidAddress()
        {
            
        }
    }
}


//c# subnet calculator
// given a tcpip address in the following format: 123.123.123.123/23

//Task 1: 
// Parse the following:
// subnet address:
// 11111111.11111111.11111110.00000000
//Network ID: 123.123.122.0
//Network range: 123.123.122.0 - 123.123.123.255

//Task2:
// given tcpip address in the following format:
// 123.123.123.123/23
// determine if another ip address is in the same network.

//123.123.122.0
//11111111.11111111.11111110.00000000

//192.10.10.10
//192.10.54.32
//1111000.100011.1101101

//192.10.0.0
/*
input address 1
for (var item in address) {
    resultbyte[i] = addressbyte[i] & subnetmaskbyte[i]
}
input address 2

 subnetmask[] 
*/





/*
 *                  &
 *   123   1111 1101 1011 1011
 *      
 *   234   1001 1001 1100 1101
 *   656   1001 1001 1000 1001
 * 
 * 
 */