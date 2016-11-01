using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageUnitManagementSystem.BL.Classes
{
    public class Address
    {
        private string _line1; //'x'x All correct according to UML/specs
       private string _line2;
        private string _city;
        private string _province;
        private string _postalCode;

        public string Line1 //'x Line1 according to UML/specs
        {
            //
            //Property Name : property string Line1
            //Purpose       : Public property to give access to _line1 instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _line1
            //Output        : string
            //                - value stored in _line1 instance variable
            //
            get { return _line1; } // end get
            set { _line1 = value; } // end set
        } // end property

        public string Line2 //'x Line2 according to UML/specs
        {
            //
            //Property Name : property string Line2
            //Purpose       : Public property to give access to _line2 instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _line2
            //Output        : string
            //                - value stored in _line2 instance variable
            //
            get { return _line2; } // end get
            set { _line2 = value; } // end set
        } // end property

        public string City //'x City according to UML/specs
        {
            //
            //Property Name : property string City
            //Purpose       : Public property to give access to _city instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _city
            //Output        : string
            //                - value stored in _city instance variable
            //
            get { return _city; } // end get
            set { _city = value; } // end set
        } // end property

        public string Province //'x Province according to UML/specs
        {
            //
            //Property Name : property string Province
            //Purpose       : Public property to give access to _province instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _province
            //Output        : string
            //                - value stored in _province instance variable
            //
            get { return _province; } // end get
            set { _province = value; } // end set
        } // end property

        public string PostalCode //'x PostalCode according to UML/specs
        {
            //
            //Property Name : property string PostalCode
            //Purpose       : Public property to give access to _postalCode instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _postalCode
            //Output        : string
            //                - value stored in _postalCode instance variable
            //
            get { return _postalCode; } // end get
            set { _postalCode = value; } // end set
        } // end property

        public Address() //'x Correct empty default const according to UML/specs
        {
            //
            //Method Name : Address()
            //Purpose     : Empty default constructor
            //Re-use      : none
            //Input       : None
            //Output      : None
            this.Line1 = Line1;
            this.Line2 = Line2;
            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
            //
        } // end method

        //'x 1st oc: header according to UML/specs
        public Address(string Line1, string Line2, string City, string Province, string PostalCode)
        {
            //
            //Method Name : Address(string Line1, string Line2, string Province, string PostalCode)
            //Purpose     : Update instance variables with user supplied values (method parameters)
            //Re-use      : none
            //Input       : - string Line1
            //                - user supplied value to update instance variable
            //              - string Line2
            //                - user supplied value to update instance variable
            //              - string City
            //                - user supplied value to update instance variable
            //              - string Province
            //                - user supplied value to update instance variable
            //              - string PostalCode
            //                - user supplied value to update instance variable
            //Output      : None
            //
            this.Line1 = Line1;
            this.Line2 = Line2;
            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
        } // end method

        public Address(string Line1, string Line2, string City)
            : this(Line1, Line2, City, "FS", "9301")
        {
            //
            //Method Name : Address(string Line1, string Line2)
            //Purpose     : Update instance variables with user supplied values (method parameters);
            //             assign default values to _province and _postalCode
            //Re-use      : Address(string Line1, string Line2, string Province, string PostalCode)
            //Input       : - string Line1
            //                - user supplied value to update instance variable
            //              - string Line2
            //                - user supplied value to update instance variable
            //              - string City
            //                - user supplied value to update instance variable
            //Output      : None
            //
        } // end method


        public override string ToString()
        {
            //
            //Method Name : string ToString()
            //Purpose     : Returns a string containing all the Address info
            //Re-use      : none
            //Input       : none
            //Output      : string
            //              - meaningful string containing all the Address info
            //
            return _line1 + ", " + _city + ", " + _province + ", " + _postalCode;//deleted line 2"
        } // end method
    }
}
