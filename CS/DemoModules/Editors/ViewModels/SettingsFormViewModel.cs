using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class SettingsFormViewModel : NotificationObject {
        public SettingsFormViewModel() {
            Language = "English";
            VibrationMode = "Default";
        }

        string language;
        public string Language {
            get => this.language;
            set => SetProperty(ref this.language, value);
        }
        List<string> blacklist = new();

        bool isPrivateChatEnabled = true;
        public bool IsPrivateChatEnabled {
            get => this.isPrivateChatEnabled;
            set => SetProperty(ref this.isPrivateChatEnabled, value);
        }
        bool isGroupChatEnabled;
        public bool IsGroupChatEnabled {
            get => this.isGroupChatEnabled;
            set => SetProperty(ref this.isGroupChatEnabled, value);
        }
        bool isSoundEnabled = true;
        public bool IsSoundEnabled {
            get => this.isSoundEnabled;
            set => SetProperty(ref this.isSoundEnabled, value);
        }
        string vibrationMode;
        public string VibrationMode {
            get => this.vibrationMode;
            set => SetProperty(ref this.vibrationMode, value);
        }
        string bio;
        public string Bio {
            get => this.bio;
            set => SetProperty(ref this.bio, value);
        }
        public List<string> Blacklist {
            get => this.blacklist;
            set => SetProperty(ref this.blacklist, value);
        }
        public List<string> VibrationModes { get; } = new() {
            "Disabled", "Default", "Short", "Long", "Only in Silent Mode"
        };
        public List<string> Contacts { get; } = new() {
            "Bruce Cambell", "Andrea Deville", "Anita Ryan", "George Bunkelman", "Anita Cardle", "Andrew Carter", "Almas Basinger", "Carolyn Baker", "Anthony Rounds"
        };
        public List<string> Languages { get; } = new() {
            "English", "German", "French", "Spanish", "Italian", "Russian", "Chinese", "Japanese"
        };
    }
}