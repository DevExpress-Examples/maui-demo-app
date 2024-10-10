using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Maui.DemoModules.Drawer.Data;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.ViewModels {
    public class LoadMoreViewModel : NotificationObject {
        readonly MailMessagesRepository repository;
        DateTime currentDate = DateTime.Now;
        readonly Random random;

        public LoadMoreViewModel(MailMessagesRepository repository) {
            this.random = new Random((int)DateTime.Now.Ticks);
            this.repository = repository;
            ItemSource = new ObservableCollection<MailData>();
            LoadData();
            LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        public ObservableCollection<MailData> ItemSource { get; }

        bool isRefreshing;
        public bool IsRefreshing {
            get => this.isRefreshing;
            set => SetProperty(ref this.isRefreshing, value);
        }

        ICommand loadMoreCommand;
        public ICommand LoadMoreCommand {
            get => this.loadMoreCommand;
            set => SetProperty(ref this.loadMoreCommand, value);
        }

        void ExecuteLoadMoreCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                LoadData();
                IsRefreshing = false;
            });
        }

        void LoadData() {
            foreach (MailData mail in this.repository.MailMessages) {
                this.currentDate = this.currentDate.AddMinutes(-1 * this.random.Next(5, 240));
                ItemSource.Add(new MailData() {
                    Body = mail.Body,
                    Folders = mail.Folders,
                    SenderEmail = mail.SenderEmail,
                    SenderName = mail.SenderName,
                    SentDate = this.currentDate,
                    Subject = mail.Subject,
                });
            }
        }
    }
}
