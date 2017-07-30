using System.Web.Services;
using Microsoft.Practices.Unity;
using Datasource;
using System.Data;
namespace Webservice.Services
{
    #region Service

    /// <summary>
    /// Summary description for MemberService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MemberService : BaseService<MemberService>
    {
        [Dependency]
        public ILogger Logger
        {
            get;
            set;
        }

        public MemberService()
            : base()
        {
        }

        /// <summary>
        /// Calls the AddMember method to add member data
        /// Returns List of member data to client
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        [WebMethod]
        public DataTable InsertMember(string firstName, string lastName, string email, string dateOfBirth)
        {
            var member = new Member();
            member.FirstName = firstName;
            member.LastName = lastName;
            member.Email = email;
            member.DateOfBirth = dateOfBirth;
            Data.AddMember(member);

            var memberList = Data.GetMembers();
            DataTable dt = HelperUtility.Utils.ConvertTo<Member>(memberList);
            return dt;
        }
    }
    #endregion
}
