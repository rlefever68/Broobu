using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.LATI.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class UserProfile : ComposedObject<UserProfile>, IUserProfile
    {
        private ICulture _culture = new Culture();
        private DateTime _dateOfBirth;
        private IRegion _region;


        [OnDeserialized]
        private void InitFields(StreamingContext context)
        {
            if (_culture == null) _culture = new Culture();
        }

        [DataMember]
        public ICulture Culture
        {
            get { return _culture; }
            set { _culture = value; RaisePropertyChanged("Culture"); }
        }


        [DataMember]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; RaisePropertyChanged("DateOfBirth"); }
        }


        [DataMember]
        public IRegion Region
        {
            get { return _region; }
            set { _region = value; RaisePropertyChanged("Region"); }
        }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<UserProfile>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<UserProfile>.Validate(this);
        }
    }
}
