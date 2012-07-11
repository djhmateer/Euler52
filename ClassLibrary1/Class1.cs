using System;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace ClassLibrary1
{
    [TestFixture]
    public class E52Tests
    {
        [Test]
        public void ContainsSameDigits_TestCase_True()
        {
            bool result = E52.ContainsSameDigits(125874,251748);
            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsSameDigits_TestCaseBad_False()
        {
            bool result = E52.ContainsSameDigits(125873, 251748);
            Assert.False(result);
        }

        [Test]
        public void ContainsSameDigits_EdgeBad_False()
        {
            bool result = E52.ContainsSameDigits(111, 11);
            Assert.False(result);
        }

        [Test]
        public void ContainsSameDigits_EdgeBadb_False()
        {
            bool result = E52.ContainsSameDigits(1111, 1112);
            Assert.False(result);
        }

        [Test]
        public void DoubleContainsSameDigits_GivenGood_True()
        {
            bool result = E52.DoesFactor(125874,2);
            Assert.True(result);
        }

        [Test]
        public void FindSmallestInt_Given_Answer()
        {
            int result = E52.FindSmallestInt();
            Assert.AreEqual(1, result);
        }
    }

    public class E52
    {
        public static int FindSmallestInt()
        {
            for (int i = 10; i < 1000000; i++)
            {
                if (DoesFactor(i, 2))
                {
                    if (DoesFactor(i, 3))
                    {
                        if (DoesFactor(i, 4))
                        {
                            if (DoesFactor(i, 5))
                            {
                                if (DoesFactor(i, 6))
                                {
                                    return i;
                                }
                            }
                        }
                    }
                }
            }
            return -1;
        }

        public static bool DoesFactor(int a, int multiple)
        {
            int multiplied = a*multiple;
            if (!ContainsSameDigits(a, multiplied)) return false;
            return true;
        }

        public static bool ContainsSameDigits(int a, int b)
        {
            bool result = true;
            char[] arrayA = a.ToString().ToCharArray();
            char[] arrayB = b.ToString().ToCharArray();

            if (arrayA.Length != arrayB.Length) return false;

            foreach (var character in arrayA)
            {
                if (!arrayB.Contains(character)) return false;
            }
            foreach (var character in arrayB)
            {
                if (!arrayA.Contains(character)) return false;
            }
            return result;
        }
    }
}
