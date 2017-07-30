using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Webapi.Services;
using System.Collections.Generic;
using Webapi.Controllers;

namespace Test
{
    [TestClass]
    public class MemberServiceTests
    {
        [TestMethod]
        public void AddMembersTests_Success()
        {
            //Arrange
            var lstMembers = new List<Datasource.Member>();

            var member = new Datasource.Member()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@gmail.com",
                DateOfBirth = "2012/07/04"
            };
            lstMembers.Add(member);

            var mockRepo = new Mock<IMemberService>();
            mockRepo.Setup(x => x.AddMembers(null)).Returns(lstMembers);

            var memberService = new MemberService();
            var returnData = memberService.AddMembers(member);  

            //Assert
            Assert.IsTrue(returnData.Count > 0);
            Assert.IsFalse(returnData.Count <= 0);
            Assert.AreEqual(lstMembers[0].MemberId, returnData[0].MemberId);
            Assert.AreEqual(lstMembers[0].FirstName, returnData[0].FirstName);
            Assert.AreEqual(lstMembers[0].LastName, returnData[0].LastName);
            Assert.AreEqual(lstMembers[0].Email, returnData[0].Email);
            Assert.AreEqual(lstMembers[0].DateOfBirth, returnData[0].DateOfBirth);
        }
    }
}
