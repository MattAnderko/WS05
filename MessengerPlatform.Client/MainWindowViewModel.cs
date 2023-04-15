using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MessengerPlatform.Models;

namespace MessengerPlatform.Client
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Message> Messages { get; set; }

        private Message selectedMessage;

        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                if (value != null)
                {
                    //selectedMessage = new Message()
                    //{
                    //    MessageName = value.MessageName,
                    //    MessageId = value.MessageId
                    //};
                    //OnPropertyChanged();
                    //(DeleteMessageCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateMessageCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Messages = new RestCollection<Message>("http://localhost:53910/", "Message", "hub");
                CreateMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message(SelectedMessage.Sender, SelectedMessage.MessageContent, SelectedMessage.SendingDate));
                });
            }
        }
    }
}
