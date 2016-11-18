using StorageUnitManagementSystem.DAL;
using StorageUnitManagementSystem.BL.Classes;
using System.Collections.Generic;


namespace StorageUnitManagementSystem.BL
{
    class UBL
    {
        private UserProviderBase providerBase;
        public UBL(string Provider)
        {
            //
            //Method name : SUBL(string Provider)
            //Purpose     : Overloaded constructor; invoke _SetupProviderBase to setup data provider
            //Re-use      : _SetupProviderBase()
            //Input       : string Provider
            //              - The name of the data provider to use
            //Output      : None
            //
            _SetupProviderBase(Provider);
        } // end method

        /// <summary>
        /// This method gets the list of all the business objects from the User datastore.
        /// It returns the list of business objects
        /// </summary>
        public List<User> SelectAll()
        {
            return providerBase.SelectAll();
        } // end method

        public List<User> SelectAll(string name)//new Method for returning record using the name field
        {
            return providerBase.SelectAll();
        } // end method


        /// <summary>
        /// This method gets a single User object from the Client datastore.
        /// </summary>
        /// <param name="ID">The User ID of the User to load from the datastore.</param>
        /// <param name="User">The User object loaded from the datastore.</param>
        public int SelectUser(string ID, ref User User)
        {
            return providerBase.SelectUser(ID, ref User);
        } // end method

        public int SelectUserName(string Name, ref User User)
        {
            return providerBase.SelectUser(Name, ref User);
        } // end method

        /// <summary>
        /// This method inserts a row in the User datastore
        /// </summary>
        /// <param name="User">The User object to add to the User datastore.</param>
        public int Insert(User User)
        {
            return providerBase.Insert(User);
        } // end method

        /// <summary>
        /// This method updates a row in the User datastore.
        /// </summary>
        /// <param name="User">The new User data for the row in the User datastore.</param>
        public int Update(User User)
        {
            return providerBase.Update(User);
        } // end method

        /// <summary>
        /// This method deletes a row in the User datastore.
        /// </summary>
        /// <param name="ID">The User ID of the User to delete in the User datastore.</param>
        public int Delete(string ID)
        {
            return providerBase.Delete(ID);
        } // end method

        /// <summary>
        /// This method determines if a given User exists in the User datastore.
        /// It returns true to indicate the User was foundy, or
        ///  false to indicate the User was not found
        /// </summary>
        /// <param name="ID">The User ID of the User to search in the User datastore.</param>
        public bool DoesExist(string ID)
        {
            return providerBase.DoesExist(ID);
        } // end method

        private void _SetupProviderBase(string Provider)
        {
            //
            //Method name : void _SetupProviderBase()
            //Purpose     : Helper method to select the correct data provider
            //Re-use      : None
            //Input       : string Provider
            //              - The name of the data provider to use
            //Output      : None
            //
            if (Provider == "UserSQLiteProvider")
            {
                providerBase = new UserSQLiteProvider();
            } // end if
        } // end method
    }
}
