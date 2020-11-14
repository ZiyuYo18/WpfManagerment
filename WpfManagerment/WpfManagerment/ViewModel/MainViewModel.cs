using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfManagerment.Comment;
using WpfManagerment.Model;

namespace WpfManagerment.ViewModel
{
    public class MainViewModel:NotifyBase
    {
        public UserModel UserInfo { get; set; }
        private string _searchText;

        public string SeachText
        {
            get { return _searchText; }
            set { _searchText = value;this.DoNotify(); }
        }
        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set { _mainContent = value; this.DoNotify(); }
        }
        public CommandBase NavChangedCommand { get; set; }
        public MainViewModel()
        {
            UserInfo = new UserModel();
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>((o) => true);

            DoNavChanged("FirstPageView");
        }
        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("WpfManagerment.View."+obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }

    }
}
