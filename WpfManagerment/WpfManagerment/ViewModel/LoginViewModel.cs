using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfManagerment.Comment;
using WpfManagerment.DataAccess;
using WpfManagerment.Model;

namespace WpfManagerment.ViewModel
{
    public class LoginViewModel:NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        //关闭按钮得命令
        public CommandBase CloseWindowCommand { get; set; }
        //登录按钮得命令
        public CommandBase LoginCommand { get; set; }
        private string _errorMessege;

        public string ErrorMessege
        {
            get { return _errorMessege; }
            set { _errorMessege = value; this.DoNotify(); }
        }

        public LoginViewModel()
        {
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
             {
                 (o as Window).Close();
             });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

            //初始化LoginModel
            //this.LoginModel = new LoginModel();
            //this.LoginModel.UserName = "admin";
            //this.LoginModel.Password = "123";

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        }
        private void DoLogin(object o)
        {
            this.ErrorMessege = "";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessege = "请输入用户名！！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessege = "请输入密码！！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMessege = "请输入验证码！！";
                return;
            }
            Task.Run(new Action(() => { 
                try { 
                    var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.Password);
                    if(user == null)
                    {
                        throw new Exception("登录失败！用户名或者密码失败！！");
                    }
                    GlobalValues.UserInfo = user;

                    Application.Current.Dispatcher.Invoke(new Action(() => {
                        (o as Window).DialogResult = true;
                    }));
                }catch(Exception ex)
                {
                    this.ErrorMessege = ex.Message;
                }
             }));
        }
    }
}
