using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfManagerment.DataAccess.DataEntity
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string Awatar { get; set; }
        public int Gender { get; set; }
    }
}
