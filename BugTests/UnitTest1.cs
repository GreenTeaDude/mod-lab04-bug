using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugPro;

namespace BugTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1_NewState()
        {
            Bug bug = new Bug();
            Assert.AreEqual(State.New, bug.GetState());
        }

        [TestMethod]
        public void Test2_Assign()
        {
            Bug bug = new Bug();
            bug.Assign();
            Assert.AreEqual(State.Open, bug.GetState());
        }

        [TestMethod]
        public void Test3_Analyze()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            Assert.AreEqual(State.Analysis, bug.GetState());
        }

        [TestMethod]
        public void Test4_Fix()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            Assert.AreEqual(State.Fixing, bug.GetState());
        }

        [TestMethod]
        public void Test5_Testing()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            Assert.AreEqual(State.Testing, bug.GetState());
        }

        [TestMethod]
        public void Test6_Close()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            bug.Close();
            Assert.AreEqual(State.Closed, bug.GetState());
        }

        [TestMethod]
        public void Test7_ReopenFromClosed()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            bug.Close();
            bug.Reopen();
            Assert.AreEqual(State.Open, bug.GetState());
        }

        [TestMethod]
        public void Test8_ReopenFromTesting()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            bug.Reopen();
            Assert.AreEqual(State.Open, bug.GetState());
        }

        [TestMethod]
        public void Test9_FullCycle()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            bug.Close();
            Assert.AreEqual(State.Closed, bug.GetState());
        }

        [TestMethod]
        public void Test10_DoubleReopen()
        {
            Bug bug = new Bug();
            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            bug.Close();
            bug.Reopen();
            bug.Analyze();
            Assert.AreEqual(State.Analysis, bug.GetState());
        }
    }
}
