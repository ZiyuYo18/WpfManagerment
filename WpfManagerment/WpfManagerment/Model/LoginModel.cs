using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfManagerment.Comment;

namespace WpfManagerment.Model
{
    public class LoginModel:NotifyBase
    {
        //用户名
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            { 
                _userName = value;
                this.DoNotify();
            }
        }
        //密码
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNotify();
            }
        }
        //验证码
        private string _validationCode;

        public string ValidationCode
        {
            get { return _validationCode; }
            set
            {
                _validationCode = value;
                this.DoNotify();
            }
        }

        
        private string _realName;

        public string RealName
        {
            get { return _realName; }
            set
            {
                _realName = value;
                this.DoNotify();
            }
        }
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                this.DoNotify();
            }
        }
        private string _awatar;
        public string Awatar
        {
            get { return _awatar; }
            set
            {
                _awatar = value;
                this.DoNotify();
            }
        }
    }
}
