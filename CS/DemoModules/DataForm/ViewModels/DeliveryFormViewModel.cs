using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.DataForm;

namespace DemoCenter.Maui.DemoModules.DataForm.ViewModels {
    public class DeliveryInfo : IDataErrorInfo {
        const string leftColumnWidth = "40";

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editorsname")]
        [DataFormItemPosition(RowOrder = 0)]
        [DataFormTextEditor(InplaceLabelText = "First name")]
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelText = "")]
        [DataFormItemPosition(RowOrder = 1)]
        [DataFormTextEditor(InplaceLabelText = "Last name")]
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editorslocation")]
        [DataFormItemPosition(RowOrder = 2)]
        [DataFormTextEditor(InplaceLabelText = "Address")]
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelText = "")]
        [DataFormItemPosition(RowOrder = 3)]
        [DataFormTextEditor(InplaceLabelText = "City")]
        [Required(ErrorMessage = "City cannot be empty")]
        public string City { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.65*", LabelText = "")]
        [DataFormItemPosition(RowOrder = 4, ItemOrderInRow = 0)]
        [DataFormTextEditor(InplaceLabelText = "State")]
        [Required(ErrorMessage = "State cannot be empty")]
        public string State { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.35*", EditorMaxWidth = 150, IsLabelVisible = false)]
        [DataFormItemPosition(RowOrder = 4, ItemOrderInRow = 1)]
        [DataFormNumericEditor(InplaceLabelText = "Zip")]
        [RegularExpression(@"(^\d{5}$)|(^\d{5}-\d{4}$)", ErrorMessage = "Invalid zip-code")]
        [Required(ErrorMessage = "Required")]
        public int? Zip { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.3*", LabelIcon = "editorsphone", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 6)]
        [DataFormTextEditor(InplaceLabelText = "Code", Keyboard = "Numeric")]
        [Required(ErrorMessage = "Required")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "Phone code must be 3 numbers length")]
        public string PhoneCode { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.7*", IsLabelVisible = false)]
        [DataFormItemPosition(RowOrder = 6)]
        [DataFormMaskedEditor(Mask = "000-0000", InplaceLabelText = "Phone number", Keyboard = "Telephone")]
        [Required(ErrorMessage = "Number cannot be empty")]
        [StringLength(maximumLength: 10, MinimumLength = 7, ErrorMessage = "Phone number must be 7 to 10 numbers length")]
        public string PhoneNumber { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editorsemail", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 7)]
        [DataFormTextEditor(InplaceLabelText = "Email", Keyboard = "Email")]
        public string Email { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editorscalendar", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 9)]
        [DisplayFormat(DataFormatString = "d")]
        [DataFormDateEditor]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.Date;

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editorstime", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 10, ItemOrderInRow = 0)]
        [DisplayFormat(DataFormatString = "t")]
        [DataFormTimeEditor]
        public DateTime DeliveryTimeFrom { get; set; } = DateTime.Now;

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, IsLabelVisible = false)]
        [DataFormItemPosition(RowOrder = 10, ItemOrderInRow = 1)]
        [DisplayFormat(DataFormatString = "t")]
        [DataFormTimeEditor]
        public DateTime DeliveryTimeTo { get; set; } = DateTime.Now.AddHours(1);

        string IDataErrorInfo.Error => String.Empty;

        string IDataErrorInfo.this[string columnName] {
            get {
                if (columnName == nameof(DeliveryTimeTo)
                    && !CheckIsDeliveryTimeCorrect()) {
                    return "The end time cannot be less than the start time";
                }
                if (columnName == nameof(DeliveryDate) && DeliveryDate < DateTime.Now.Date) {
                    return "Delivery cannot be earlier than today";
                }
                return String.Empty;
            }
        }

        public bool CheckIsDeliveryTimeCorrect() {
            return DeliveryTimeTo > DeliveryTimeFrom;
        }
    }
    public class DeliveryFormViewModel : NotificationObject {
        public DeliveryInfo Model { get; set; }

        public DeliveryFormViewModel() {
            Model = new DeliveryInfo();
        }

        Dictionary<string, bool> fieldNamesToReorder = new Dictionary<string, bool>() {
            { nameof(DeliveryInfo.LastName), true },
            { nameof(DeliveryInfo.City), true },
            { nameof(DeliveryInfo.DeliveryTimeFrom), true },
            { nameof(DeliveryInfo.DeliveryTimeTo), false },
        };

        bool isVertical = true;

        public void Rotate(DataFormView dataForm, bool newIsVertical) {
            if (newIsVertical != isVertical) {
                if (dataForm.Items != null) {
                    isVertical = newIsVertical;
                    foreach (KeyValuePair<string, bool> fieldName in fieldNamesToReorder) {
                        DataFormItem item = dataForm.Items.FirstOrDefault(i => i.FieldName == fieldName.Key);
                        int modifier = newIsVertical ? 1 : -1;
                        if (item != null) {
                            item.RowOrder += modifier;
                            if (fieldName.Value)
                                item.IsLabelVisible = newIsVertical;
                        }
                    }
                }
            }
        }
    }
}
