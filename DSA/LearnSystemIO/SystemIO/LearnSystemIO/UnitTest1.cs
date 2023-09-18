namespace LearnSystemIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new MemoryStream(byteArr);
            byte[] bufferToPopulate = new byte[100];
            int bufferRead = s.Read(bufferToPopulate, 19, 80);

            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bufferRead, 80);
        }
        [TestMethod]
        public void CreateANewMemoryStreamFromBytes()
        {
            //arrange
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new MemoryStream(); //empty stream
            //act write to stream s using data in byteArr
            s.Write(byteArr, 0, 100);
            s.Position = 0;

            //assert
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(0, s.Position);
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
        }
        [TestMethod]
        public void CreateANewFileStreamFromBytes()
        {
            //arrange
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new FileStream("out.bin", FileMode.OpenOrCreate); //empty stream
            //act write to stream s using data in byteArr
            s.Write(byteArr, 0, 100);
            s.Position = 0;

            //assert
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(0, s.Position);
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
            s.Flush();
            s.Close();
        }
        [TestMethod]
        public void WritePrimitiveData()
        {
            //arrange:
            // create file stream to store binary data at binary.bin
            // construct binarywriter with above stream
            char a = 'a';
            string b = "Hello";
            decimal c = decimal.MaxValue;
            Int64 d = Int64.MaxValue;
            Int32 e = Int32.MaxValue;
            double f = Double.MaxValue;
            Stream fileStream = new FileStream("binary.bin", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fileStream);

            //act:
            //write char, decimal, int64, int32, write double
            //dont forget to flush and close the file
            bw.Write(a);
            bw.Write(b);
            bw.Write(c);
            bw.Write(d);
            bw.Write(e);
            bw.Write(f);
            bw.Close();
            bw.Flush();

            //assert:
            int inputDataByteCount = 43;
            var testFile = new FileInfo("binary.bin");
            Assert.AreEqual(inputDataByteCount, testFile.Length);

            BinaryReader br = new BinaryReader(fileStream);

            Assert.AreEqual(a, br.ReadChar());
            Assert.AreEqual(b, br.ReadString());
            Assert.AreEqual(c, br.ReadDecimal());
            Assert.AreEqual(d, br.ReadInt64());
            Assert.AreEqual(e, br.ReadInt32());
            Assert.AreEqual(f, br.ReadDouble());
            fileStream.Close();
            br.Close();
        }
        [TestMethod]
        public void CopyPrimitiveData()
        {
            //arrange:
            // create file stream to store binary data at binary.bin
            // construct binarywriter with above stream
            char a = 'a';
            string b = "Hello";
            decimal c = decimal.MaxValue;
            Int64 d = Int64.MaxValue;
            Int32 e = Int32.MaxValue;
            double f = Double.MaxValue;
            Stream fileStream = new FileStream("binary.bin", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fileStream);

            //act:
            //write char, decimal, int64, int32, write double
            //dont forget to flush and close the file
            bw.Write(a);
            bw.Write(b);
            bw.Write(c);
            bw.Write(d);
            bw.Write(e);
            bw.Write(f);
            bw.Flush();
            fileStream.Close();
            bw.Close();
            //assert:
            int inputDataByteCount = 43;
            var testFile = new FileInfo("binary.bin");

            Assert.AreEqual(inputDataByteCount, testFile.Length);
            Stream s2 = new FileStream("binary.bin", FileMode.Open);
            Stream newS2 = new FileStream("binary(copy).bin", FileMode.OpenOrCreate);

            s2.CopyTo(newS2);
            BinaryReader newBR = new BinaryReader(newS2);


            Assert.AreEqual(a, newBR.ReadChar());
            Assert.AreEqual(b, newBR.ReadString());
            Assert.AreEqual(c, newBR.ReadDecimal());
            Assert.AreEqual(d, newBR.ReadInt64());
            Assert.AreEqual(e, newBR.ReadInt32());
            Assert.AreEqual(f, newBR.ReadDouble());
            s2.Close();
            newBR.Close();
        }
        [TestMethod]
        public void TestParsingStringToWinnerInstance()
        {
            string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);

            Assert.AreEqual(1, w.Index);
            Assert.AreEqual(1928, w.Year);
            Assert.AreEqual(44, w.Age);
            Assert.AreEqual("\"Emil Jannings\"", w.Name);
            Assert.AreEqual("\"The Last Command, The Way of All Flesh\"", w.Movie);
        }
        [TestMethod]
        public void CreateAListOfWinnerFromCsvFile()
        {
            List<Winner> winners = new List<Winner>();
            using (StreamReader sr = new StreamReader(@"c:\test\oscar_age_male.csv"))
            {
                string line;
                //read and display lines from the file until the end
                // of the file is reached
                sr.ReadLine(); //skip the first line
                while((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0) break;
                    winners.Add(new Winner(line));
                }
            }
            Assert.AreEqual(89, winners.Count);
            Assert.AreEqual(76, winners.Max(w => w.Age));
            Assert.AreEqual(29, winners.Min(w => w.Age));
            Assert.AreEqual(1928, winners.Min(w => w.Year));

            var sw = new StreamWriter(@"C:\test\oscar_age_male.csv");
            sw.WriteLine($"{"Actor", 20}");
            foreach(var item in multi)
        }
    }
}