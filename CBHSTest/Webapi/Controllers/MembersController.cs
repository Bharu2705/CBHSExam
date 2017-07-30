using System;
using System.Collections.Generic;
using System.Web.Http;
using Webapi.Services;

namespace Webapi.Controllers
{
    public class MembersController : ApiController
    {
        #region Properties
        private MemberService _memberService;
        //Declaring Log4Net 
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MembersController));
        #endregion

        #region Constructor
        public MembersController(MemberService memberService)
        {
            _memberService = memberService;
        }
        #endregion

        #region ControllerMethod
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public List<Datasource.Member> AddMembers(Datasource.Member members)
        {
            try
            {
                //Call Member Service to Insert and Retrieve the members detail
                var lstMembers = _memberService.AddMembers(members);
                return lstMembers;
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
