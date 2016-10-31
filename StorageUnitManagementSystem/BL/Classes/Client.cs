using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageUnitManagementSystem.BL.Classes
{
    public class Client
    {
        private string _idNumber;
        private string _firstNames;
        private string _lastName;
        private string _dateOfBirth;
        private string _telephone;
        private string _cellphone;
        private bool _archived;
        private string _eMailAddress;
        private Address _address;

        public bool Archived
        {
            get { return _archived; }
            set { _archived = value; }
        }

        

        public Client()
        {
        }

        public Client(string idNumber, string firstNames, string lastName,
            string dateOfBirth, string telephone, string cellphone,
            string eMailAddress, Address address, bool archived)
        {
            _idNumber = idNumber;
            _firstNames = firstNames;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _telephone = telephone;
            _cellphone = cellphone;
            _archived = archived;
            _eMailAddress = eMailAddress;
            _address = new Address();
            this.Address.City = address.City;
            this.Address.Line1 = address.Line1;
            this.Address.Line2 = address.Line2;
            this.Address.PostalCode = address.PostalCode;
            this.Address.Province = address.Province;
        }

        public string idNumber
        {
            get { return _idNumber; }
            set { _idNumber = value; }
        }

        public string FirstNames
        {
            get { return _firstNames; }
            set { _firstNames = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string EMailAddress
        {
            get { return _eMailAddress; }
            set { _eMailAddress = value; }
        }

    }
}
