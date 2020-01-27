using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaXamarin
{
    public class MainPageVM : clsVMBase
    {
        private string name;

        public string Name
        {
            get => name;
            set => NotifyPropertyChanged("Name");
        }
    
        public ICommand EnterCommand => new Command(EnterCommandExecute);

        public async void EnterCommandExecute()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Alert",
                    "You have been alerted",
                    "OK");
                return;
            }
            //throw new NotImplementedException();
        }
    }
}