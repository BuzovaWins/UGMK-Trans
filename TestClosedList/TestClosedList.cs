using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedList;
using System.IO;

namespace TestClosedList
{
    public class TestClosedList
    {
        public string getTestFileOutput()
        {
            var fileName = "test.txt";

            if (!File.Exists(fileName))
                return "";

            var sr = new StreamReader(fileName);

            string content = sr.ReadToEnd();
            return content;
        }

        [Test]
        public void MoveNextOnEmptyList_ThenException()
        {
            var list = new ClosedListImpl<string>();            

            Assert.Throws<Exception>(() => list.MoveNext());
        }

        [Test]
        public void MoveNextOnEmptyList_ThenZeroHeadReached()
        {
            MoveNextOnEmptyList_ThenException();

            Assert.AreEqual("", getTestFileOutput());
        }

        [Test]
        public void MoveBackOnEmptyList_ThenException()
        {
            var list = new ClosedListImpl<string>();

            Assert.Throws<Exception>(() => list.MoveBack());
        }

        [Test]
        public void MoveBackOnEmptyList_ThenZeroHeadReached()
        {
            MoveBackOnEmptyList_ThenException();

            Assert.AreEqual("", getTestFileOutput());
        }

        [Test]
        public void CurrentOn1ItemList_ThenFirstValue()
        {
            var list = new ClosedListImpl<string>() { "1" };

            Assert.AreEqual("1", list.Current);
        }

        [Test]
        public void CurrentOn1ItemList_ThenZeroHeadReached()
        {
            var list = new ClosedListImpl<string>() { "1" };
            var c = list.Current;

            Assert.AreEqual("", getTestFileOutput());
        }

        [Test]
        public void Move1NextOn1ItemList_ThenSameValue()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveNext();

            Assert.AreEqual("1", list.Current);
        }

        [Test]
        public void Move1NextOn1ItemList_Then1HeadReached()
        {
            var list = new ClosedListImpl<string>() { "1" };
                list.MoveNext();

            Assert.AreEqual("We meet head item\r\n", getTestFileOutput());
        }

        [Test]
        public void Move1BackOn1ItemList_ThenSameValue()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveBack();

            Assert.AreEqual("1", list.Current);
        }

        [Test]
        public void Move1BackOn1ItemList_Then1HeadReached()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveBack();

            Assert.AreEqual("We meet head item\r\n", getTestFileOutput());
        }

        [Test]
        public void Move2NextOn1ItemList_ThenSameValue()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveNext();
            list.MoveNext();

            Assert.AreEqual("1", list.Current);
        }

        [Test]
        public void Move2BackOn1ItemList_ThenSameValue()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveBack();
            list.MoveBack();

            Assert.AreEqual("1", list.Current);
        }

        [Test]
        public void Move2NextOn1ItemList_Then2HeadReached()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveNext();
            list.MoveNext();

            Assert.AreEqual("We meet head item\r\nWe meet head item\r\n", getTestFileOutput());
        }

        [Test]
        public void Move2BackOn1ItemList_Then2HeadReached()
        {
            var list = new ClosedListImpl<string>() { "1" };
            list.MoveBack();
            list.MoveBack();

            Assert.AreEqual("We meet head item\r\nWe meet head item\r\n", getTestFileOutput());
        }
    }
}
