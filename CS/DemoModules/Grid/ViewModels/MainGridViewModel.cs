using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Grid.ViewModels {
    public class MainGridViewModel : NotificationObject {
        readonly Command refreshCommand;
        readonly OrdersRepository repository;
        readonly MarketSimulator market;

        bool isRefreshing = false;
        public bool IsRefreshing {
            get { return this.isRefreshing; }
            set {
                if (this.isRefreshing != value) {
                    this.isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        bool isUpdateLocked = false;
        public bool IsUpdateLocked {
            get { return this.isUpdateLocked; }
            set {
                if (this.isUpdateLocked != value) {
                    this.isUpdateLocked = value;
                    OnPropertyChanged("IsUpdateLocked");
                }
            }
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get { return this.pullToRefreshCommand; }
            set {
                if (this.pullToRefreshCommand != value) {
                    this.pullToRefreshCommand = value;
                    OnPropertyChanged("PullToRefreshCommand");
                }
            }
        }

        ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get { return this.orders; }
            set {
                if (this.orders != value) {
                    this.orders = value;
                    OnPropertyChanged("Orders");
                }
            }
        }
        public ObservableCollection<Customer> Customers { get { return this.repository.Customers; } }
        public BindingList<Quote> Quotes { get { return this.market.Quotes; } }
        public Command SwipeButtonCommand { get; set; }
        public Command RefreshCommand { get { return this.refreshCommand; } }

        public MainGridViewModel(OrdersRepository repository) {
            this.repository = repository;
            Orders = repository.Orders;
            this.refreshCommand = new Command(ExecuteRefreshCommand);
            this.market = new MarketSimulator();
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }

        void ExecuteRefreshCommand() {
            this.repository.RefreshOrders();
            Orders = this.repository.Orders;
        }
        
        public void OnOrderRemove(int row) {
            Console.WriteLine("before" + Orders.Count);
            Orders.RemoveAt(row);
            Console.WriteLine("after" + Orders.Count);
        }

        bool marketSimulationOn;
        public void StartMarketSimulation() {
            if (this.marketSimulationOn)
                return;

            this.marketSimulationOn = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.5), SimulateMarketWorker);
        }

        public void StopMarketSimulation() {
            this.marketSimulationOn = false;
        }

        public void ForceSimulateMarketWorker() {
            SimulateNextStep();
        }

        bool SimulateMarketWorker() {
            if (!this.marketSimulationOn)
                return false;

            SimulateNextStep();
            return true;
        }

        void SimulateNextStep() {
            IsUpdateLocked = true;
            Device.BeginInvokeOnMainThread(() => {
                this.market.SimulateNextStep();
                IsUpdateLocked = false;
            });
        }

        void ExecutePullToRefreshCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                SimulateNextStep();
                IsRefreshing = false;
            });
        }
    }
}
