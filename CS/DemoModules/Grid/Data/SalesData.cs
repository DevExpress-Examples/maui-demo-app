using System;
using System.Collections.Generic;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class SalesData {
        public string Country { get; set; }
        public double ActualSales { get; set; }
        public double TargetSales { get; set; }
        public double AverageMonthlySales { get; set; }
        public double AverageMonthlyQuantitySold { get; set; }
    }

    static class SalesDataGenerator {
        static string[] countries = new string[] { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", 
            "Anguilla", "Antarctica", "Antigua & Barbuda", "Argentina", "Armenia", "Aruba (neth.)", "Australia", "Austria", "Azerbaijan", "Azores (port.)", "Bahamas", 
            "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia And Herzegovina", "Botswana", "Brazil", 
            "British Virgin Islands", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", 
            "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", 
            "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands", "Fiji", "Finland", "Fmr Yug Rep Macedonia", "France", "French Guiana", "French Polynesia", 
            "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guinea", "Guinea Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", 
            "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Iraq-Saudi Arabia Neutral Zone", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", 
            "Korea Dem.People's Rep.", "Korea, Republic Of", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya Arab Jamahiriy", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", 
            "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mexico", "Micronesia, Fed Stat", "Moldova, Republic Of", "Monaco", "Mongolia", "Morocco", 
            "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau Islands", 
            "Panama", "Panama Canal Zone", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saint Lucia", "San Marino", 
            "Sao Tome & Principe", "Saudi Arabia", "Senegal", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "Spain", "Sri Lanka", "St.Kitts & Nevis", 
            "St.Vinct & Grenadine", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Rep.", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad & Tobago", "Tunisia", 
            "Turkey", "Turkmenistan", "Turks And Caicos Islands", "Tuvalu", "U.S. Virgin Islands", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City (Holy See)", 
            "Venezuela", "Vietnam", "Western Sahara", "Western Samoa", "Yemen", "Yugoslavia", "Zaire", "Zambia", "Zimbabwe" };
        
        public static List<SalesData> CreateData() {
            List<SalesData> list = new List<SalesData>(countries.Length);
            Random random = new Random();
            for(int i = 0; i < countries.Length; i++) {
                SalesData item = new SalesData();
                item.Country = countries[i];
                item.ActualSales = random.Next(1000000, 10000000);
                item.TargetSales = random.Next((int)(item.ActualSales / 2), (int)(item.ActualSales * 2));
                item.AverageMonthlySales = item.ActualSales / 12;
                item.AverageMonthlyQuantitySold = random.Next(300000, 1000000);
                list.Add(item);
            }
            return list;
        }
    }
}
