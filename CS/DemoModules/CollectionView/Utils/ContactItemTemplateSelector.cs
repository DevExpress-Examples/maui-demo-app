using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public class ContactItemTemplateSelector : DataTemplateSelector {
        public DataTemplate PhotoTemplate { get; set; }
        public DataTemplate IconTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is PhoneContact contact)
                return contact.HasPhoto ? PhotoTemplate : IconTemplate;
            if (item is CallInfo callInfo)
                return callInfo.Contact.HasPhoto ? PhotoTemplate : IconTemplate;

            return IconTemplate;
        }
    }
}