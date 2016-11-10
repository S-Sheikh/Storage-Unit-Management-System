using System.ComponentModel;
using System.Runtime.CompilerServices;
using StorageUnitManagementSystem.Annotations;

namespace StorageUnitManagementSystem.BL.Classes
{
    public class Client
    {
        private string _idNumber;
        private string _firstName;
        private string _lastName;
        private string _dateOfBirth;
        private string _cellphone;
        private string _telephone;
        private bool _archived;
        private string _eMailAddress;
        private Address _address;
      
        public Client()
        {
            _address = new Address();
        }
        public string idNumber
        {
            get { return _idNumber; }
            set{  _idNumber = value;}
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
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


        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
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

        public bool Archived
        {
            get { return _archived; }
            set { _archived = value; }
        }

       
    }
}
