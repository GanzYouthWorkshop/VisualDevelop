using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GEV.VisualDevelop.Implementation.ToolWindow.Implementation
{
    public class ToolWindowViewmodel : INotifyPropertyChanged
    {
        public bool WindowEnabled
        {
            get { return this.m_WindowEnabled; }
            set { this.m_WindowEnabled = value; this.NotifyPropertyChanged(); }
        }
        private bool m_WindowEnabled;

        public List<ImageLocal> Items
        {
            get { return this.m_Items; }
            set { this.m_Items = value; this.NotifyPropertyChanged(); }
        }
        private List<ImageLocal> m_Items;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
