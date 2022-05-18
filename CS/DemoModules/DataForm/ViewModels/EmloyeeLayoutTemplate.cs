using System.Collections.Generic;

namespace DemoCenter.Maui.DemoModules.DataForm.ViewModels {

    public partial class EmployeeFormViewModel {
        public class EmloyeeLayoutTemplate {
            Dictionary<string, int> template;

            public EmloyeeLayoutTemplate(Dictionary<string, int> template) {
                this.template = template;
            }

            public int GetFieldOrder(string fieldName) {
                if (this.template.ContainsKey(fieldName)) {
                    return this.template[fieldName];
                }
                else {
                    return -1;
                }
            }

            public static implicit operator EmloyeeLayoutTemplate(Dictionary<string, int> dictionary) {
                return new EmloyeeLayoutTemplate(dictionary);
            }

            public static EmloyeeLayoutTemplate TabletHorizontal { get; } = new Dictionary<string, int> {
                { nameof(EmployeeInfo.Photo), 0 },    { nameof(EmployeeInfo.FirstName),         0 },
                                                      { nameof(EmployeeInfo.LastName),          1 },
                                                      { nameof(EmployeeInfo.BirthDate),         2 },
                { nameof(EmployeeInfo.Position), 4 }, { nameof(EmployeeInfo.HireDate),          4 },
                { nameof(EmployeeInfo.Notes),    5 },
                { nameof(EmployeeInfo.Address),  6 }, { nameof(EmployeeInfo.HomePhoneNumber),   6 },
                { nameof(EmployeeInfo.City),     7 }, { nameof(EmployeeInfo.MobilePhoneNumber), 7 },
                { nameof(EmployeeInfo.State),    8 }, { nameof(EmployeeInfo.Email),             8 },
                { nameof(EmployeeInfo.Zip),      9 }, { nameof(EmployeeInfo.Skype),             9 }
            };

            public static EmloyeeLayoutTemplate TabletVertical { get; } = new Dictionary<string, int> {
                { nameof(EmployeeInfo.Photo),              0 }, { nameof(EmployeeInfo.FirstName),         0 },
                                                                { nameof(EmployeeInfo.LastName),          1 },
                                                                { nameof(EmployeeInfo.BirthDate),         2 },
                { nameof(EmployeeInfo.Position),           4 },
                { nameof(EmployeeInfo.Notes),              5 },
                { nameof(EmployeeInfo.Address),            6 },
                { nameof(EmployeeInfo.City),               7 },
                { nameof(EmployeeInfo.State),              8 },
                { nameof(EmployeeInfo.Zip),                9 },
                { nameof(EmployeeInfo.HireDate),          10 },
                { nameof(EmployeeInfo.HomePhoneNumber),   11 },
                { nameof(EmployeeInfo.MobilePhoneNumber), 12 },
                { nameof(EmployeeInfo.Email),             13 },
                { nameof(EmployeeInfo.Skype),             14 }
            };

            public static EmloyeeLayoutTemplate PhoneVertical { get; } = new Dictionary<string, int> {
                { nameof(EmployeeInfo.Photo),              0 },
                { nameof(EmployeeInfo.FirstName),          1 },
                { nameof(EmployeeInfo.LastName),           2 },
                { nameof(EmployeeInfo.BirthDate),          3 },
                { nameof(EmployeeInfo.Position),           4 },
                { nameof(EmployeeInfo.Notes),              5 },
                { nameof(EmployeeInfo.Address),            6 },
                { nameof(EmployeeInfo.City),               7 },
                { nameof(EmployeeInfo.State),              8 },
                { nameof(EmployeeInfo.Zip),                9 },
                { nameof(EmployeeInfo.HireDate),          10 },
                { nameof(EmployeeInfo.HomePhoneNumber),   11 },
                { nameof(EmployeeInfo.MobilePhoneNumber), 12 },
                { nameof(EmployeeInfo.Email),             13 },
                { nameof(EmployeeInfo.Skype),             14 }
            };

            public static EmloyeeLayoutTemplate PhoneHorizontal => TabletVertical;
        }
    }
}
