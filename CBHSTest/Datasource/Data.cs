using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasource
{
    public static class Data
    {
        private static List<Member> members = new List<Member>();
        public static void AddMember(Member member)
        {
            members.Add(member);
        }
        public static List<Member> GetMembers()
        {
            return members;
        }
    }
}
