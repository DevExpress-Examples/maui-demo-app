using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Editors;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class AccountFormViewModel : NotificationObject {
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
        bool notesHasError = false;
        public bool NotesHasError {
            get { return notesHasError; }
            set { SetProperty(ref notesHasError, value); }
        }

        string email;
        public string Email {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        bool emailHasError = false;
        public bool EmailHasError {
            get { return emailHasError; }
            set { SetProperty(ref emailHasError, value); }
        }

        DateTime? birthDate;
        public DateTime? BirthDate {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value); }
        }

        bool birthDateHasError = false;
        public bool BirthDateHasError {
            get { return birthDateHasError; }
            set { SetProperty(ref birthDateHasError, value); }
        }

        string phone;
        public string Phone {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        bool phoneHasError = false;
        public bool PhoneHasError {
            get { return phoneHasError; }
            set { SetProperty(ref phoneHasError, value); }
        }

        string login = "";
        public string Login {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        bool loginHasError = false;
        public bool LoginHasError {
            get { return loginHasError; }
            set { SetProperty(ref loginHasError, value); }
        }

        string password = "";
        public string Password {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        bool passwordHasError = false;
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
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$");
        }
    }
}
