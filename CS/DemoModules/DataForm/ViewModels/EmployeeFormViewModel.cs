using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.DataForm;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.DemoModules.DataForm.ViewModels {
    public class EmployeeInfo : IDataErrorInfo {
        public EmployeeInfo() {
            FirstName = "Arvil";
            LastName = "Chase";
            BirthDate = DateTime.Parse("1978-06-26T00:00:00");
            Position = "Research and Development Engineer";
            HireDate = DateTime.Parse("1998-10-20T00:00:00");
            Notes = FirstName + " has been in the Audio/ Video industry since 1990. He has led DevAV as its CEO since 2003. " +
                    "When not working hard as the CEO, John loves to golf and bowl. He once bowled a perfect game of 300";
            Address = "351 S Hill St.";
            City = "Los Angeles";
            State = "CA";
            Zip = 90013;
            HomePhoneNumber = "(718) 193-6521";
            MobilePhoneNumber = HomePhoneNumber;
            Email = "Arvil_Chase@example.com";
            Skype = FirstName + LastName + "_DX_skype";

            Photo = ImageSource.FromResource("DemoCenter.Maui.DemoModules.DataForm.Images.arvil.jpg");
        }

        public ImageSource Photo { get; private set; }

        [Required(ErrorMessage = "First Name shouldn't be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name shouldn't be empty")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Address shouldn't be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City shouldn't be empty")]
        public string City { get; set; }

        [Required(ErrorMessage = "State shouldn't be empty")]
        public string State { get; set; }

        [RegularExpression(@"(^\d{5}$)|(^\d{5}-\d{4}$)", ErrorMessage = "Invalid zip-code")]
        public int? Zip { get; set; }

        [Required(ErrorMessage = "Number shouldn't be empty")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number should contain 10 characters")]
        public string HomePhoneNumber { get; set; }

        [Required(ErrorMessage = "Number shouldn't be empty")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number should contain 10 characters")]
        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }
        public string Skype { get; set; }

        string IDataErrorInfo.Error => String.Empty;
        string IDataErrorInfo.this[string columnName] => String.Empty;
    }

    public partial class EmployeeFormViewModel : NotificationObject, IPickerSourceProvider {
        readonly string[] positions = {
            "Chief Executive Officer", "Database Administrator", "Application Specialist",
            "Network Manager", "Network Administrator", "Marketing Manager",
            "Marketing Specialist", "Research and Development Engineer"
        };
        public EmployeeInfo Model { get; }

        bool firstLayout;
        bool isVertical;
        public bool IsVertical {
            get => this.isVertical;
            set => SetProperty(ref this.isVertical, value);
        }

        public EmployeeFormViewModel() {
            Model = new EmployeeInfo();
            IsVertical = true;
            this.firstLayout = true;
        }

        public void Rotate(DataFormView dataForm, bool newIsVertical) {
            if (newIsVertical != IsVertical || this.firstLayout) {
                this.firstLayout = false;

                if (dataForm.Items != null) {
                    IsVertical = newIsVertical;
                    foreach (DataFormItem item in dataForm.Items) {
                        int rowOrder = GetFieldOrder(item.FieldName);
                        if (rowOrder >= 0)
                            item.RowOrder = rowOrder;
                        if (item.FieldName == nameof(EmployeeInfo.Photo)) {
                            SetPhotoItemProperties(item);
                        }
                    }
                }
            }
        }

        public IEnumerable GetSource(string propertyName) {
            if (propertyName == nameof(EmployeeInfo.Position)) {
                return this.positions.ToList();
            }
            return null;
        }

        void SetPhotoItemProperties(DataFormItem item) {
            if (DeviceInfo.Idiom == DeviceIdiom.Phone && IsVertical) {
                item.RowSpan = 1;
            } else {
                item.RowSpan = 3;
            }
        }

        int GetFieldOrder(string fieldName) {
            if(DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                return IsVertical ?
                    EmloyeeLayoutTemplate.TabletVertical.GetFieldOrder(fieldName) :
                    EmloyeeLayoutTemplate.TabletHorizontal.GetFieldOrder(fieldName);
            } else {
                return IsVertical ?
                    EmloyeeLayoutTemplate.PhoneVertical.GetFieldOrder(fieldName) :
                    EmloyeeLayoutTemplate.PhoneHorizontal.GetFieldOrder(fieldName);
            }
        }
    }
}
