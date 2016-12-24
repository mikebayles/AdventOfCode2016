using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox;
using System.Linq;

namespace AdventTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestDay1()
        {
            Assert.AreEqual(5, new Day1("R2, L3").Part1());
            Assert.AreEqual(2, new Day1("R2, R2, R2").Part1());
            Assert.AreEqual(12, new Day1("R5, L5, R5, R3").Part1());

            Assert.AreEqual(4, new Day1("R8, R4, R4, R8").Part2());
        }

        [TestMethod]
        public void TestDay2()
        {
            Assert.AreEqual("1985", new Day2("ULL\nRRDDD\nLURDL\nUUUUD".Split('\n')).Part1());
            Assert.AreEqual("5DB3", new Day2("ULL\nRRDDD\nLURDL\nUUUUD".Split('\n')).Part2());
        }

        [TestMethod]
        public void TestDay3()
        {
            Assert.AreEqual(0, new Day3(new string[] { "5 10 15" }).Part1());
            Assert.AreEqual(6, new Day3("101 301 501\n102 302 502\n103 303 503\n201 401 601\n202 402 602\n203 403 603".Split('\n')).Part2());
        }

        [TestMethod]
        public void TestDay4()
        {
            Assert.AreEqual(123, new Day4(new string[] { "aaaaa-bbb-z-y-x-123[abxyz]" }).Part1());
            Assert.AreEqual(987, new Day4(new string[] { "a-b-c-d-e-f-g-h-987[abcde]" }).Part1());
            Assert.AreEqual(404, new Day4(new string[] { "not-a-real-room-404[oarel]" }).Part1());
            Assert.AreEqual(0, new Day4(new string[] { "totally-real-room-200[decoy]" }).Part1());

            Assert.AreEqual("very encrypted name", new Day4(new string[] { "" }).ShiftLetters("qzmt-zixmtkozy-ivhz", 343 % 26));
            Assert.AreEqual(-1, new Day4(new string[] { "qzmt-zixmtkozy-ivhz-343" }).Part2());
        }


        [TestMethod]
        public void TestDay5()
        {
            var obj = new Day5();
            Assert.IsTrue(Day5.MD5Hash("abc3231929").StartsWith("00000"));
            Assert.AreEqual("18f47a30", obj.Part1("abc"));
            Assert.AreEqual("05ace8e3", obj.Part2("abc"));
        }

        [TestMethod]
        public void TestDay6()
        {
            var input = "eedadn\ndrvtee\neandsr\nraavrd\natevrs\ntsrnev\nsdttsa\nrasrtv\nnssdts\nntnada\nsvetve\ntesnvt\nvntsnd\nvrdear\ndvrsen\nenarar".Split('\n');
            Assert.AreEqual("easter", new Day6(input).Part1());

            Assert.AreEqual("123", new Day6(new string[] { "123" }).Part1());
            Assert.AreEqual("1", new Day6("1123".Select(a => a.ToString()).ToArray()).Part1());
            Assert.AreEqual("2", new Day6("112223".Select(a => a.ToString()).ToArray()).Part1());

            Assert.AreEqual("3", new Day6("1123".Select(a => a.ToString()).ToArray()).Part2());
            Assert.AreEqual("3", new Day6("112223".Select(a => a.ToString()).ToArray()).Part2());
        }

        [TestMethod]
        public void TestDay7()
        {
            Assert.AreEqual(1, new Day7(new string[] { "abba[mnop]qrst" }).Part1());
            Assert.AreEqual(0, new Day7(new string[] { "abcd[bddb]xyyx" }).Part1());
            Assert.AreEqual(0, new Day7(new string[] { "aaaa[qwer]tyui" }).Part1());
            Assert.AreEqual(1, new Day7(new string[] { "ioxxoj[asdfgh]zxcvbn" }).Part1());
            Assert.AreEqual(2, new Day7(new string[] { "abba[mnop]qrst", "abcd[bddb]xyyx", "aaaa[qwer]tyui", "ioxxoj[asdfgh]zxcvbn" }).Part1());


            Assert.AreEqual(1, new Day7(new string[] { "aba[bab]xyz" }).Part2());
            Assert.AreEqual(0, new Day7(new string[] { "xyx[xyx]xyx" }).Part2());
            Assert.AreEqual(1, new Day7(new string[] { "aaa[kek]eke" }).Part2());
            Assert.AreEqual(1, new Day7(new string[] { "zazbz[bzb]cdb" }).Part2());

        }

        [TestMethod]
        public void TestDay9()
        {
            var obj = new Day9();
            Assert.AreEqual(9, obj.Part2Rec(new string[] { "(3x3)XYZ" }));
            Assert.AreEqual(20, obj.Part2Rec(new string[] { "X(8x2)(3x3)ABCY" }));
            Assert.AreEqual(241920, obj.Part2Rec(new string[] { "(27x12)(20x12)(13x14)(7x10)(1x12)A" }));
            Assert.AreEqual(445, obj.Part2Rec(new string[] { "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN" }));
        }
    }
}
