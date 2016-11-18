using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUnitManagementSystem.BL.Classes
{
    public class User
    {
        private string _id;
        private string _userName;
        private string _password;
        private string _role;

        public string UserName
        {

            //
            //Property Name : property string UserName 
            //Purpose       : Public property to give access to _userName variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _userName
            //Output        : string
            //                - value stored in _userName instance variable
            //
            get
            {
                return _userName;
            }//end get

            set
            {
                _userName = value;
            }//end set
        }

        public string Password
        {
            //
            //Property Name : property string Password
            //Purpose       : Public property to give access to _password instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _password
            //Output        : string
            //                - value stored in _password instance variable
            //
            get
            {
                return _password;
            }//end get

            set
            {
                _password = value;
            }//en set
        }//end property

        public string Role
        {
            //
            //Property Name : property string Role
            //Purpose       : Public property to give access to _role instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _role
            //Output        : string
            //                - value stored in _role instance variable
            //
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }

        public string Id
        {
            //
            //Property Name : property string Id
            //Purpose       : Public property to give access to _id instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _id
            //Output        : string
            //                - value stored in _id instance variable
            //
            get
            {
                return _id;
            }//end get

            set
            {
                _id = value;
            }//end set
        }//end property
    }//end class
}//namespace
