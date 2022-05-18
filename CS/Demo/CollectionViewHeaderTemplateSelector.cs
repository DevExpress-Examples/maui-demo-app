using System;
using DemoCenter.Maui.Models;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo
{
    class CollectionViewHeaderTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is not DemoItem demoItem)
                return null;
            if (demoItem.IsHeader) {
                return HeaderTemplate;
            } else {
                return ItemTemplate;
            }
        }

        public DataTemplate HeaderTemplate { get; set; }
        public DataTemplate ItemTemplate { get; set; }
    }
}

