using Datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Services
{
    public interface IMemberService
    {
        #region Interface Declarations
        List<Member> AddMembers(Member member);
        #endregion
    }
}
