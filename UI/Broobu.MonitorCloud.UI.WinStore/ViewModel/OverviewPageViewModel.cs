using DevExpress.Core;
using System.Collections.ObjectModel;

namespace Broobu.MonitorCloud.UI.WinStore.ViewModel
{
    /// <summary>
    /// A View Model for the OverviewPage.
    /// </summary>
    public class OverViewPageViewModel : BindableBase
    {
        public OverViewPageViewModel()
        {
            FirstName = "John";
            LastName = "Smith";
            OfficePhone = "(999) 108 77 66";
            PhoneNumbers = new ObservableCollection<PhoneNumber>{
                new PhoneNumber(){ Type="Work", Value="(720) 861-7141", IsRequired=true},
                new PhoneNumber(){ Type="Home"},
                new PhoneNumber(){ Type="Additional"},
            };
            Emails = new ObservableCollection<Email>{
                new Email(){ Type="Work", Value="JohnSmith@aol.com", IsRequired=true},
                new Email(){ Type="Home"},
            };
        }
        ObservableCollection<PhoneNumber> phoneNumbersCore;
        public ObservableCollection<PhoneNumber> PhoneNumbers
        {
            get
            {
                return phoneNumbersCore;
            }
            set
            {
                SetProperty(ref phoneNumbersCore, value, (s1, s2) => { OnPropertyChanged("PhoneNumbers"); });
            }
        }
        ObservableCollection<Email> emailsCore;
        public ObservableCollection<Email> Emails
        {
            get
            {
                return emailsCore;
            }
            set
            {
                SetProperty(ref emailsCore, value, (s1, s2) => { OnPropertyChanged("Emails"); });
            }
        }
        string photo = "ms-appx:///Assets/AbstractUser.jpg";
        public string Photo { get { return photo; } }
        string bio = "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat";
        public string Bio { get { return bio; } }
        string firstNameCore;
        public string FirstName
        {
            get { return firstNameCore; }
            set
            {
                SetProperty(ref firstNameCore, value, (s1, s2) =>
                {
                    OnPropertyChanged("DetailPageHeader");
                    OnPropertyChanged("FullName");
                });
            }
        }
        string lastNameCore;
        public string LastName
        {
            get { return lastNameCore; }
            set
            {
                SetProperty(ref lastNameCore, value, (s1, s2) =>
                {
                    OnPropertyChanged("DetailPageHeader");
                    OnPropertyChanged("FullName");
                });
            }
        }
        public string DetailPageHeader
        {
            get
            {
                return string.Format("{0} {1} Details", FirstName, LastName);
            }
        }
        public string FullName
        {
            get { return string.Join(", ", LastName, FirstName); }
        }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Contact(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
    public sealed class PhoneNumber : BindableBase
    {
        public bool IsRequired { get; internal set; }
        string typeCore;
        public string Type
        {
            get { return typeCore; }
            set { SetProperty(ref typeCore, value); }
        }
        string valueCore;
        public string Value
        {
            get { return valueCore; }
            set { SetProperty(ref valueCore, value); }
        }
    }
    public sealed class Email : BindableBase
    {
        public bool IsRequired { get; internal set; }
        string typeCore;
        public string Type
        {
            get { return typeCore; }
            set { SetProperty(ref typeCore, value); }
        }
        string valueCore;
        public string Value
        {
            get { return valueCore; }
            set { SetProperty(ref valueCore, value); }
        }
    }
}
