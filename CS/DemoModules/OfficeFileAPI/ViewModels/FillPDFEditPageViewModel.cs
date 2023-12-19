using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using DevExpress.Pdf;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DemoCenter.Maui.DemoModules.OfficeFileAPI.ViewModels;

[QueryProperty(nameof(Document), "Document")]
public class FillPDFEditPageViewModel : BindableBase {
    #region fields
    PdfDocumentProcessor CurrentDocumentProcessor;
    string document;
    Dictionary<string, object> editedObject;
    List<EditedItemModel> properties;
    #endregion fields
    #region properties
    public string Document {
        get {
            return document;
        }
        set {
            document = value;
            RaisePropertyChanged();
            if (document != null)
                LoadForms();
        }
    }

    public ICommand SaveEditsCommand {
        get;
        set;
    }
    public Dictionary<string, object> EditedObject {
        get {
            return editedObject;
        }
        set {
            editedObject = value;
            RaisePropertyChanged();
        }
    }
    public List<EditedItemModel> Properties {
        get {
            return properties;
        }
        set {
            properties = value;
            RaisePropertyChanged();
        }
    }
    #endregion properties
    public FillPDFEditPageViewModel() {
        SaveEditsCommand = new Command(SaveEdits);
    }

    private void LoadForms() {
        CurrentDocumentProcessor = new PdfDocumentProcessor();
        CurrentDocumentProcessor.LoadDocument(Document);
        PdfDocumentFacade documentFacade = CurrentDocumentProcessor.DocumentFacade;
        Dictionary<string, object> dataModel = new Dictionary<string, object>();
        List<EditedItemModel> newEditedProperties = new List<EditedItemModel>();
        EditedObject = documentFacade.AcroForm.GetFields()
                            .OrderByDescending(fieldFacade => fieldFacade.First().Rectangle.TopLeft.Y).ThenByDescending(field => field.First().Rectangle.TopLeft.X)
                            .ToDictionary(fieldFacade => fieldFacade.FullName, fieldFacade => {
                                if (fieldFacade.Type == PdfFormFieldType.Text) {
                                    PdfTextFormFieldFacade textFieldFacade = (PdfTextFormFieldFacade)fieldFacade;

                                    DateTime hintDate;
                                    if (DateTime.TryParse(textFieldFacade.Field.DefaultText, out hintDate)) {
                                        newEditedProperties.Add(new DateEditedItemModel(fieldFacade.FullName, textFieldFacade.Required));
                                        DateTime valueDate;
                                        if (DateTime.TryParse(textFieldFacade.Field.DefaultText, out valueDate))
                                            return (DateTime?)valueDate;
                                        return default(DateTime);
                                    } else if (!string.IsNullOrEmpty(textFieldFacade.Field.DefaultText) && textFieldFacade.Field.DefaultText.All(c => c == '0')) {
                                        newEditedProperties.Add(new MaskEditedItemModel(fieldFacade.FullName, textFieldFacade.Required, textFieldFacade.Field.DefaultText));
                                        return (object)((PdfTextFormFieldFacade)fieldFacade).Value ?? string.Empty;
                                    } else {
                                        newEditedProperties.Add(new EditedItemModel(fieldFacade.FullName, textFieldFacade.Required));
                                        return (object)((PdfTextFormFieldFacade)fieldFacade).Value ?? string.Empty;
                                    }
                                } else if (fieldFacade.Type == PdfFormFieldType.ComboBox) {
                                    PdfComboBoxFormFieldFacade comboBoxFieldFacade = (PdfComboBoxFormFieldFacade)fieldFacade;
                                    var comboBoxSource = ((PdfComboBoxFormFieldFacade)fieldFacade).Items.Select(item => item.Value);
                                    ComboBoxEditedItemModel comboBoxEditedItemModel = new ComboBoxEditedItemModel(fieldFacade.FullName, comboBoxFieldFacade.Required, comboBoxSource, DropDownShowMode.BottomSheet);
                                    newEditedProperties.Add(comboBoxEditedItemModel);
                                    return comboBoxFieldFacade.Value ?? string.Empty;
                                } else if (fieldFacade.Type == PdfFormFieldType.RadioGroup) {
                                    PdfRadioGroupFormFieldFacade radioGroupFormFieldFacade = (PdfRadioGroupFormFieldFacade)fieldFacade;
                                    var comboBoxSource = radioGroupFormFieldFacade.Items.Select(item => item.Value);
                                    ComboBoxEditedItemModel comboBoxEditedItemModel = new ComboBoxEditedItemModel(fieldFacade.FullName, radioGroupFormFieldFacade.Required, comboBoxSource, DropDownShowMode.Popup);
                                    newEditedProperties.Add(comboBoxEditedItemModel);
                                    return radioGroupFormFieldFacade.Value ?? string.Empty;
                                }
                                return null;
                            });
        Properties = newEditedProperties;
    }

    async void SaveEdits() {
        PdfAcroFormFacade acroForm = CurrentDocumentProcessor.DocumentFacade.AcroForm;
        foreach (var keyPair in EditedObject) {
            PdfFormFieldFacade field = acroForm.GetFormField(keyPair.Key);
            switch (field.Type) {
                case PdfFormFieldType.Text: {
                    ((PdfTextFormFieldFacade)field).Value = keyPair.Value == null ? null : keyPair.Value.ToString();
                    break;
                }
                case PdfFormFieldType.ComboBox: {
                    ((PdfComboBoxFormFieldFacade)field).Value = (string)keyPair.Value;
                    break;
                }
                case PdfFormFieldType.RadioGroup: {
                    ((PdfRadioGroupFormFieldFacade)field).Value = (string)keyPair.Value;
                    break;
                }
            }
        }

        CurrentDocumentProcessor.SaveDocument(Document);
        CurrentDocumentProcessor.CloseDocument();
        await Shell.Current.GoToAsync("..");
    }
}

public class EditedItemModel : BindableBase {
    public EditedItemModel(string propertyName, bool isRequired) {
        PropertyName = propertyName;
        IsRequired = isRequired;
    }
    public string PropertyName { get; set; }
    public bool IsRequired { get; set; }
}
public class MaskEditedItemModel : EditedItemModel {
    public MaskEditedItemModel(string propertyName, bool isRequired, string mask) : base(propertyName, isRequired) {
        Mask = mask;
    }
    public string Mask { get; set; }
}
public class DateEditedItemModel : EditedItemModel {
    public DateEditedItemModel(string propertyName, bool isRequired) : base(propertyName, isRequired) {
    }
}
public class ComboBoxEditedItemModel : EditedItemModel {
    public object ItemsSource {
        get;
        set;
    }
    public DropDownShowMode DropDownMode { get; set; }
    public ComboBoxEditedItemModel(string propertyName, bool isRequired, object itemsSource, DropDownShowMode dropDownMode = DropDownShowMode.Popup) : base(propertyName, isRequired) {
        ItemsSource = itemsSource;
        DropDownMode = dropDownMode;
    }
}