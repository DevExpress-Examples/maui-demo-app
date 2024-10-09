using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;
using SQLite;

namespace DemoCenter.Maui.DemoModules.CollectionView.Data {
    [Table("Customers")]
    public class Contact : NotificationObject {
        static readonly Dictionary<int, string> photoById = new() {
            { 1, "photo0" },
            { 2, "photo28" },
            { 3, "photo27" },
            { 4, "photo30" },
            { 5, "photo29" },
            { 6, "photo26" },
            { 7, "photo16" },
            { 8, "photo21" },
            { 9, "photo14" },
            { 10, "photo10" },
            { 11, "photo31" },
            { 12, "photo2" },
            { 13, "photo34" },
            { 14, "photo35" },
            { 15, "photo37" },
            { 16, "photo40" },
            { 17, "photo42" },
            { 18, "photo44" },
            { 19, "photo47" },
            { 20, "photo23" },
        };
        static ImageSource noPhotoImageSource = ImageSource.FromFile("collectionview_crud_noavatar");

        int? id;
        string firstName;
        string lastName;
        string company;
        string address;
        string city;
        string state;
        string email;
        int zipcode;
        string homephone;
        ImageSource image;

        [PrimaryKey, AutoIncrement, NotNull, Column("ID")]
        public int? ID {
            get => this.id;
            set => SetProperty(ref this.id, value);
        }

        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName {
            get => this.firstName;
            set => SetProperty(ref this.firstName, value);
        }
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName {
            get => this.lastName;
            set => SetProperty(ref this.lastName, value);
        }
        public string Company {
            get => this.company;
            set => SetProperty(ref this.company, value);
        }
        public string Address {
            get => this.address;
            set => SetProperty(ref this.address, value);
        }
        public string City {
            get => this.city;
            set => SetProperty(ref this.city, value);
        }
        public string State {
            get => this.state;
            set => SetProperty(ref this.state, value);
        }
        public int ZipCode {
            get => this.zipcode;
            set => SetProperty(ref this.zipcode, value);
        }
        public string HomePhone {
            get => this.homephone;
            set => SetProperty(ref this.homephone, value);
        }
        public string Email {
            get => this.email;
            set => SetProperty(ref this.email, value);
        }

        [Ignore]
        public ImageSource PhotoImageSource {
            get {
                if (this.image is not null)
                    return this.image;
                if (!this.id.HasValue || this.id is < 0 or > 20)
                    return this.image = noPhotoImageSource;
                if (photoById.TryGetValue(this.id.Value, out var photo))
                    return this.image = ImageSource.FromFile(photo);
                return this.image = noPhotoImageSource;
            }
        }
    }
}