using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Base.ViewModel;


namespace message_queue.ViewModel
{
    class MainViewModel : Base.ViewModel.BaseViewModel
    {
        private string _name;
        private string _emote;

        public string Name { get { return _name; } set { _name = value; ChangeProperty("Name"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }

        public Command CheckCommand { get; set; }

        public MainViewModel()
        {
            CheckCommand = new Command(Check);     
        }

        public void Check(object window)
        {
            // TODO
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
