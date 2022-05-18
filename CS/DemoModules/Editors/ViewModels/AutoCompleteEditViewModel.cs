namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class AutoCompleteEditViewModel : ComboBoxEditViewModel {
        public AutoCompleteEditViewModel() {
            ShowHelpText = false;
        }

        protected override string DefaultHelpText { get => "Type a contact name or phone number"; }

    }
}

