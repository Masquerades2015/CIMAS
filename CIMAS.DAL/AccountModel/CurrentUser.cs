using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMAS.DAL.AccountModel
{
    public class CurrentUser
    {
        public string UserName { get; set; }
        public string TrueName { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string ReportYear { get; set; }
        public int TalentID { get; set; }
        public int EnterpriseID { get; set; }
        public int ExpertID { get; set; }
        public string IP { get; set; }
    }
}
