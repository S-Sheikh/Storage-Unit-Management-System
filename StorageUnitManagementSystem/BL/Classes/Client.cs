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
            //
            //Property Name : constructor Client
            //Purpose       : Public property to give access to _address instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _line1
            //Output        : string
            //                - value stored in _line1 instance variable
            //
            _address = new Address();
        }//end constructor
        public string idNumber
        {
            //
            //Property Name : property string idNumber
            //Purpose       : Public property to give access to _idNumber instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _idNumber
            //Output        : string
            //                - value stored in _idNamber instance variable
            //
            get { return _idNumber; }//end get
            set{  _idNumber = value;}//end set
        }//end property

        public string FirstName
        {
            //
            //Property Name : property string Firstname
            //Purpose       : Public property to give access to _firstName instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _firstName
            //Output        : string
            //                - value stored in _firstName instance variable
            //
            get { return _firstName; }
            set { _firstName = value; }
        }// end property

        public string LastName
        {
            //
            //Property Name : property string LastName
            //Purpose       : Public property to give access to _lastName instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _lastName
            //Output        : string
            //                - value stored in _lastName instance variable
            //
            get { return _lastName; }//end get
            set { _lastName = value; }//end set
        }//end property

        public string DateOfBirth
        {
            //
            //Property Name : property string DateOfBirth
            //Purpose       : Public property to give access to _dateOfBirth instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _dateOfBirth
            //Output        : string
            //                - value stored in _dateOfBirth instance variable
            //
            get { return _dateOfBirth; }//end get
            set { _dateOfBirth = value; }//end set
        }//end property


        public string Cellphone
        {
            //
            //Property Name : property string Cellphone
            //Purpose       : Public property to give access to _cellphone instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _cellphone
            //Output        : string
            //                - value stored in _cellphone instance variable
            //
            get { return _cellphone; }//end get
            set { _cellphone = value; }//end set
        }//end property
        public string Telephone
        {
            //
            //Property Name : property string Telephone
            //Purpose       : Public property to give access to _telephone instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _telephone
            //Output        : string
            //                - value stored in _telephone instance variable
            //
            get { return _telephone; }//end get
            set { _telephone = value; }//end set
        }//end property

        public Address Address
        {//
            //Property Name : property string Address
            //Purpose       : Public property to give access to _address instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _address
            //Output        : string
            //                - value stored in _address instance variable
            //
            get { return _address; }//end get
            set { _address = value; }//end set
        }//end property

        public string EMailAddress
        {
            //
            //Property Name : property string EmailAddress
            //Purpose       : Public property to give access to _emailAddress instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _emailAddress
            //Output        : string
            //                - value stored in _emailAddress instance variable
            //
            get { return _eMailAddress; }//end get
            set { _eMailAddress = value; }//end set
        }//end property

        public bool Archived
        {//
            //Property Name : property string Archived
            //Purpose       : Public property to give access to _archived instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _archived
            //Output        : string
            //                - value stored in _archived instance variable
            //
            get { return _archived; }
            set { _archived = value; }
        }//end property

       
    }//end class
}//end namespace
