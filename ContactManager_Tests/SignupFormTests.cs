using ContactManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManager_Tests
{
    [TestClass]
    public class SignupFormTests
    {
        [TestMethod]
        public void TestValidEmail_IsSaved()
        {
            var saved = new SignupForm().Signup("J", "W", "wheelie33@gmail.com");

            Assert.IsTrue(saved);
        }

   

        [TestMethod]
        public void TestEmailMissingTld_IsNotSaved()
        {
            var saved = new SignupForm().Signup("J", "W", "wheelie33@gmail");
            Assert.IsFalse(saved);

        }


        [TestMethod]
        public void TestForSanity()
        {
            Assert.AreEqual(1, 1); ;
        }





        [TestMethod]
        public void TestEmailMissingAtSign_IsNotSaved()
        {
            var saved = new SignupForm().Signup("J", "W", "wheelie33gmail.com");
            Assert.IsFalse(saved);
        }


        [TestMethod]
        public void TestGenericData_IsSaved()
        {
            var saved = new SignupForm().Signup("J", "W", "wheelie33@gmail.com");
            Assert.IsTrue(saved);
        }


        [TestMethod]
        public void TestLongFirstName_IsNotSaved()
        {
            var saved = new SignupForm().Signup("JasonJasonJasonJasonJasonJason", "Whelehon", "wheelie33@gmail.com");
            Assert.IsFalse(saved);
        }

        [TestMethod]
        public void TestFirstNameContainsNonAlpha_IsNotSaved()
        {
            var saved = new SignupForm().Signup("12345", "Whelehon", "wheelie33@gmail.com");
            Assert.IsFalse(saved);
        }


        [TestMethod]
        public void TestLongLastName_IsNotSaved()
        {
            var saved = new SignupForm().Signup("J", "WhelehonWhelehonWhelehonWhelehon", "wheelie33@gmail.com");
            Assert.IsFalse(saved);
        }

        [TestMethod]
        public void TestHyphenatedLastName_IsSaved()
        {
            var saved = new SignupForm().Signup("J", "Smith-Johnson", "wheelie33@gmail.com");
            Assert.IsTrue(saved);
        }

        [TestMethod]
        public void TestInvalidEmail_IsNotSaved()
        {
            var saved = new SignupForm().Signup("J", "Whelehon", "wheelie33@gmailcom");
            Assert.IsFalse(saved);
        }

        [TestMethod]
        public void TestValidEmailKnownSpam_IsNotSaved()
        {
            var saved = new SignupForm().Signup("J", "W", "knownspam@spam.com");
            Assert.IsFalse(saved);
        }

        [TestMethod]
        public void TestHyphenatedLastName_LongerThan20Characters_IsNotSaved()
        {
            var saved = new SignupForm().Signup("J", "wwwwwwwwwwwwwwwwwwwwwwwww-wwwwwwwwwwwwwwwwwwwwwwwww", "wheelie33@gmail.com");
            Assert.IsFalse(saved);
        }


        //[TestMethod]
        //public void TestHypehatedLastName_EachPartLessThanMax_TotalIsGreaterThanMax_IsNotSaved()
        //{
        //    var saved = new SignupForm().Signup("J", "wwwwwwwwwwwwwwwwww-wwwwwwwwwwwwwwwwww", "wheelie33@gmail.com");
        //    Assert.IsFalse(saved);
        //}





        //[TestCase(@"NotAnEmail", false)]
        //[TestCase(@"@NotAnEmail", false)]
        //[TestCase(@"""test\\blah""@example.com", true)]
        //[TestCase(@"""test\blah""@example.com", false)]
        //[TestCase("\"test\\\rblah\"@example.com", true)]
        //[TestCase("\"test\rblah\"@example.com", false)]
        //[TestCase(@"""test\""blah""@example.com", true)]
        //[TestCase(@"""test""blah""@example.com", false)]
        //[TestCase(@"customer/department@example.com", true)]
        //[TestCase(@"$A12345@example.com", true)]
        //[TestCase(@"!def!xyz%abc@example.com", true)]
        //[TestCase(@"_Yosemite.Sam@example.com", true)]
        //[TestCase(@"~@example.com", true)]
        //[TestCase(@".wooly@example.com", false)]
        //[TestCase(@"wo..oly@example.com", false)]
        //[TestCase(@"pootietang.@example.com", false)]
        //[TestCase(@".@example.com", false)]
        //[TestCase(@"""Austin@Powers""@example.com", true)]
        //[TestCase(@"Ima.Fool@example.com", true)]
        //[TestCase(@"""Ima.Fool""@example.com", true)]
        //[TestCase(@"""Ima Fool""@example.com", true)]
        //[TestCase(@"Ima Fool@example.com", false)]
        //public void RFC822EmailAddressesAreValid(string email, bool expected)
        //{

        //    Assert.AreEqual(expected, _testSubject.Signup("J", "W", email)
        //      , "Problem with '" + email + "'. Expected "
        //      + expected + " but was not that.");
        //}

    }
}
