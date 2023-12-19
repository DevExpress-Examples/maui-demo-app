using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Editors;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public partial class AccountFormViewModel : NotificationObject {

        [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$")]
        private static partial Regex PasswordRegex();

        BoxMode selectedBoxMode;
        public BoxMode SelectedBoxMode {
            get { return selectedBoxMode; }
            set { SetProperty(ref selectedBoxMode, value); }
        }

        string notes = "";
        public string Notes {
            get { return notes; }
            set { SetProperty(ref notes, value); }
        }
        bool notesHasError;
        public bool NotesHasError {
            get { return notesHasError; }
            set { SetProperty(ref notesHasError, value); }
        }

        string email;
        public string Email {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        bool emailHasError;
        public bool EmailHasError {
            get { return emailHasError; }
            set { SetProperty(ref emailHasError, value); }
        }

        DateTime? birthDate;
        public DateTime? BirthDate {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value); }
        }

        bool birthDateHasError;
        public bool BirthDateHasError {
            get { return birthDateHasError; }
            set { SetProperty(ref birthDateHasError, value); }
        }

        string phone;
        public string Phone {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        bool phoneHasError;
        public bool PhoneHasError {
            get { return phoneHasError; }
            set { SetProperty(ref phoneHasError, value); }
        }

        string login = "";
        public string Login {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        bool loginHasError;
        public bool LoginHasError {
            get { return loginHasError; }
            set { SetProperty(ref loginHasError, value); }
        }

        string password = "";
        public string Password {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        bool passwordHasError;
        public bool PasswordHasError {
            get { return passwordHasError; }
            set { SetProperty(ref passwordHasError, value); }
        }

        public IList<BoxMode> BoxModes { get; }

        public AccountFormViewModel() {
            BoxModes = new List<BoxMode> {
                BoxMode.Outlined,
                BoxMode.Filled
            };
            SelectedBoxMode = BoxModes[0];
        }

        public bool Validate() {
            EmailHasError = string.IsNullOrEmpty(Email);
            LoginHasError = string.IsNullOrEmpty(Login);
            PasswordHasError = !CheckPassword();
            BirthDateHasError = BirthDate == null;
            PhoneHasError = Phone == null || Phone.Length != 10;
            NotesHasError = Notes.Length > 100;
            return !(NotesHasError || PhoneHasError || EmailHasError || LoginHasError || PasswordHasError);
        }

        bool CheckPassword() {
            return PasswordRegex().IsMatch(password);
        }
    }
}
