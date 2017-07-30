using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datasource;

namespace Webapi.Services
{
    public class MemberService : IMemberService
    {
        #region Properties
        //Declaring Log4Net 
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MemberService));
        #endregion

        #region Service Methods
        public List<Member> AddMembers(Member member)
        {
            try
            {
                if (member != null)
                    //Insert the members detail : MemberId, FirstName, LastName, Email, DateOfBirth
                    Data.AddMember(member);

                //Retrieve the members detail
                var retrieveMembers = Data.GetMembers();
                return retrieveMembers;
            }
            catch(Exception ex)
            {
                //Log the error information
                logger.Error(ex.Message);
                return null;
            }
        }
        #endregion
    }
}