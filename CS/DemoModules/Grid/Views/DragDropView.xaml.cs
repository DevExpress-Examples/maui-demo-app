using System.Collections.Generic;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.DemoModules.CollectionView.Data;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class DragDropView : BaseGridContentPage {
        bool isAnimated;

        public DragDropView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return new EmployeeTasksRepository();
        }

        void Grid_DragRow(object sender, DragRowEventArgs e) {
            if (this.isAnimated) {
                e.Cancel = true;
                return;
            }
            e.Cancel = !IsItemDraggable(e.DragItem);
            this.isAnimated = !e.Cancel;
        }

        void Grid_DragRowOver(object sender, DropRowEventArgs e) {
            e.Cancel = !IsItemDraggable(e.DropItem);
        }

        void Grid_CompleteRowDragDrop(object sender, CompleteRowDragDropEventArgs e) {
            this.isAnimated = false;
        }

        bool IsItemDraggable(object item) {
            return !((EmployeeTask)item).Completed;
        }

        private void Grid_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Element != DataGridElement.Row || e.FieldName != "Completed" || this.isAnimated)
                return;
            IList<EmployeeTask> source = (IList<EmployeeTask>)this.grid.ItemsSource;
            EmployeeTask task = (EmployeeTask)e.Item;
            task.Status = task.Completed ? TaskStatus.Uncompleted : TaskStatus.Completed;
            int newRowHandle = task.Completed ? source.Count - 1 : 0;
            if (e.RowHandle == newRowHandle)
                return;
            this.isAnimated = true;
            Dispatcher.Dispatch(() => this.grid.MoveRow(e.RowHandle, newRowHandle, () => this.isAnimated = false));
        }

        void Grid_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e) {
            if (e.FieldName == nameof(EmployeeTask.Name) || e.FieldName == nameof(EmployeeTask.DueDate)) {
                if (((EmployeeTask)e.Item).Completed) {
                    e.TextDecorations = TextDecorations.Strikethrough;
                    e.FontColor = new Color(e.FontColor.Red, e.FontColor.Green, e.FontColor.Blue, 0.5f);
                }
            }
        }
    }
}