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

        private string user;

        public string User
        {
            get { return user; }
            set
            {
                if (value != null)
                {
                    user = value;

                }
                OnPropertyChanged();
            }
        }
        private string newMessage;

        public string NewMessage
        {
            get { return newMessage; }
            set
            {
                if (value != null)
                {
                    newMessage = value;

                }
                OnPropertyChanged();
            }
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
                        selectedMessage = new Message(value.Sender, value.MessageContent, value.SendingDate);
               
                    }
                    OnPropertyChanged();
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
                Messages = new RestCollection<Message>("http://localhost:19932/", "message", "hub");
                ;
                CreateMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message(user, newMessage,System.DateTime.Now));
                });
            }
        }
    }
}
