using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.DataForm;

namespace DemoCenter.Maui.DemoModules.DataForm.ViewModels {
    public class AccountInfo {
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; } = DateTime.Now.Date;

        [Required(ErrorMessage = "Number cannot be empty")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "The phone number should contain 10 characters")]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]

        public string Login { get; set; }

        [StringLength(64, MinimumLength = 8, ErrorMessage = "The password should contain at least 8 characters")]
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        public bool ReceiveNotification { get; set; }
    }

    public class AccountFormViewModel : NotificationObject {
        public AccountInfo Model { get; set; }

        bool isVertical;
        public bool IsVertical {
            get => isVertical;
            set => SetProperty(ref isVertical, value);
        }

        public AccountFormViewModel() {
            Model = new AccountInfo() { ReceiveNotification = true };
            IsVertical = true;
        }

        List<string> fieldNamesToReorder = new List<string>() {
            nameof(AccountInfo.LastName),
            nameof(AccountInfo.PhoneNumber),
            nameof(AccountInfo.Password),
        };

        public void Rotate(DataFormView dataForm, bool newIsVertical) {
            if (newIsVertical != IsVertical) {
                if (dataForm.Items != null) {
                    IsVertical = newIsVertical;
                    foreach (string fieldName in fieldNamesToReorder) {
                        DataFormItem item = dataForm.Items.FirstOrDefault(i => i.FieldName == fieldName);
                        int modifier = newIsVertical ? 1 : -1;
                        if (item != null)
                            item.RowOrder += modifier;
                    }
                }
            }
        }
    }
}
