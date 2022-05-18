using System;
using System.Collections.Generic;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.ViewModels;
using DevExpress.Utils;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.DemoModules.Drawer.Data {
    public class MailBoxFolder : NotificationObject {
        public MailBoxFolder(string name, string icon, bool showCount) {
            FolderName = name;
            Icon = String.Format("demodrawer_{0}", icon);
            ShowCount = showCount;
        }

        public string Icon { get; set; }
        public string FolderName { get; set; }
        public int Count { get; set; }
        public bool ShowCount { get; set; }

        bool isSelected = false;
        public bool IsSelected {
            get => this.isSelected;
            set {
                if (value == this.isSelected)
                    return;
                this.isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
    public class MailBoxOwner {
        public ImageSource Avatar { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
    public class MailData {
        Color contactColor = DXColor.Default;
        public Color CategoryColor => GetContactColor();
        public string SenderDisplay => String.Format("{0} ({1})", SenderName, SenderEmail);
        public string SenderAvatarText => SenderName.Substring(0, 1);
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public DateTime SentDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Folders { get; set; }

        internal Color GetContactColor() {
            if (this.contactColor == DXColor.Default) {
                this.contactColor = ContactColors.GetRandomColor();
            }
            return this.contactColor;
        }
    }

    public class MailMessagesRepository {
        public List<MailData> MailMessages { get; private set; }
        public List<MailBoxFolder> Folders { get; private set; }
        readonly Random random;

        public MailMessagesRepository() {
            this.random = new Random((int)DateTime.Now.Ticks);
            GenerateMessages();
            GenerateFolders();
            DistributeMailsByFolders();
        }

        void GenerateFolders() {
            Folders = new List<MailBoxFolder> {
                new MailBoxFolder("Inbox", "inbox_normal", true),
                new MailBoxFolder("Sent", "send_normal", false),
                new MailBoxFolder("Important", "important_normal", false),
                new MailBoxFolder("Draft", "draft_normal", false),
                new MailBoxFolder("Trash", "trash_normal", false)
            };
        }

        public void GenerateMessages() {
            MailMessages = new List<MailData>();
            MailMessages.Add(
                new MailData() {
                    SenderName = "Nancy Davolio",
                    Subject = "Choose between PPO and HMO Health Plan",
                    SenderEmail = "NancyDavolio@devexpress.com",
                    Body = "We need a final decision on whether we are planning on staying with a PPO Health Plan or we plan on switching to an HMO. We cannot proceed with compliance with the Affordable Health Act until we make this decision. John Heart: Samantha, I&#39;m still reviewing costs. I am not in a position to make a final decision at this point.",
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Andrew Fuller",
                    Subject = "Google AdWords Strategy",
                    SenderEmail = "AndrewFuller@devexpress.com",
                    Body = "Make final decision on whether we are going to increase our Google AdWord spend based on our 2013 marketing plan."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Janet Leverling",
                    Subject = "New Brochures",
                    SenderEmail = "JanetLeverling@devexpress.com",
                    Body = "Review and the new brochure designs and give final approval. John Heart: ve reviewed them all and forwarded an email with all changes we need to make to the brochures to comply with local regulations."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Margaret Peacock",
                    Subject = "Website Re-Design Plan",
                    SenderEmail = "MargaretPeacock@devexpress.com",
                    Body = "The changes in our brochure designs for 2013 require us to update key areas of our website."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Steven Buchanan",
                    Subject = "Non-Compete Agreements",
                    SenderEmail = "StevenBuchanan@devexpress.com",
                    Body = "Make final decision on whether our employees should sign non-compete agreements. Samantha Bright: Greta, we discussed this and we feel it is unnecessary to require non-compete agreements for employees."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Michael Suyama",
                    Subject = "Update Employee Files with New NDA",
                    SenderEmail = "MichaelSuyama@devexpress.com",
                    Body = "Management has approved new NDA. All employees must sign the new NDA and their employee files must be updated. Greta Sims: Having difficulty with a few employees. Will follow up by Email."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Robert King",
                    Subject = "Review Health Insurance Options Under the Affordable Care Act",
                    SenderEmail = "RobertKing@devexpress.com",
                    Body = "The changes in health insurance laws require that we review our existing coverage and update it to meet regulations. Samantha Bright will be point on this. Samantha Bright: Update - still working with the insurance company to update our coverages."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Laura Callahan",
                    Subject = "Give Final Approval for Refunds",
                    SenderEmail = "LauraCallahan@devexpress.com",
                    Body = "Refunds as a result of our 2013 TV recalls have been submitted. Need final approval to cut checks to customers. Samantha Bright: You can send the checks out mid-May."
                }
            );
            MailMessages.Add(
                new MailData() {
                    SenderName = "Anne Dodsworth",
                    Subject = "Decide on Mobile Devices to Use in the Field",
                    SenderEmail = "AnneDodsworth@devexpress.com",
                    Body = "We need to decide whether we are going to use Surface tablets in the field or go with iPad. I&#39;ve prepared the pros and cons based on feedback from everyon in the IT dept. Arthur Miller: Surface."
                }
            );
            GenerateRandomSentFromPeriod();
        }

        void GenerateRandomSentFromPeriod() {
            DateTime currentDate = DateTime.Now.Date.AddMinutes(this.random.Next(1, 560));
            foreach (MailData mail in MailMessages) {
                mail.SentDate = currentDate.AddMinutes(this.random.Next(1, 200));
            }
        }

        void DistributeMailsByFolders() {
            int maxValue = Folders.Count - 1;
            int maxMessagesCount = MailMessages.Count - 1;

            for (int i = 0; i <= maxValue; i++) {
                string folderName = Folders[i].FolderName;
                int countInFolder = this.random.Next(1, maxMessagesCount);

                for (int j = 0; j <= countInFolder; j++) {
                    int messageIndex = this.random.Next(0, maxMessagesCount);
                    if (MailMessages[messageIndex].Folders == null)
                        MailMessages[messageIndex].Folders = new List<string>();
                    if (!MailMessages[messageIndex].Folders.Contains(folderName)) {
                        MailMessages[messageIndex].Folders.Add(folderName);
                        Folders[i].Count++;
                    }
                }
            }
        }
    }
}
