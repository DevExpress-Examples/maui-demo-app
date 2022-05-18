using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Maui.DemoModules.Drawer.Data;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.ViewModels {
    public class PullToRefreshViewModel : NotificationObject {
        readonly MailMessagesRepository repository;

        public PullToRefreshViewModel(MailMessagesRepository repository) {
            this.repository = repository;
            ItemSource = GetSortedMessages(this.repository);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }

        IList<MailData> itemSource;
        public IList<MailData> ItemSource {
            get => this.itemSource;
            set => SetProperty(ref this.itemSource, value);
        }

        bool isRefreshing = false;
        public bool IsRefreshing {
            get => this.isRefreshing;
            set => SetProperty(ref this.isRefreshing, value);
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get => this.pullToRefreshCommand;
            set => SetProperty(ref this.pullToRefreshCommand, value);
        }

        void ExecutePullToRefreshCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                this.repository.GenerateMessages();
                ItemSource = GetSortedMessages(this.repository);
                IsRefreshing = false;
            });
        }

        IList<MailData> GetSortedMessages(MailMessagesRepository repository) {
            return repository.MailMessages.OrderByDescending(x => x.SentDate).ToList();
        }
    }
}
