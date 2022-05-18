using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.CollectionView;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    class ItemTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is EmployeeTask task))
                return null;

            return task.Completed ? CompletedDataTemplate : UncompletedDataTemplate; 
        }

        public DataTemplate CompletedDataTemplate { get; set; }
        public DataTemplate UncompletedDataTemplate { get; set; }
    }
}

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class CollectionViewDragDropView : ContentPage {
        public CollectionViewDragDropView() {
            InitializeComponent();
            ViewModel = new DragDropModel(new EmployeeTasksRepository());
            BindingContext = ViewModel;
        }

        DragDropModel ViewModel { get; }

        void DragItem(object sender, DragItemEventArgs e) {
            e.Allow = IsItemDraggable(e.DragItem);
        }

        void DragItemOver(object sender, DropItemEventArgs e) {
            e.Allow = IsItemDraggable(e.DropItem);
        }

        bool IsItemDraggable(object item) {
            return !((EmployeeTask)item).Completed;
        }
    }
}
