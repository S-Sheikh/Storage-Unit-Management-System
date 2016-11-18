using System.Collections.Generic;
using StorageUnitManagementSystem.BL.Classes;
using StorageUnitManagementSystem.DAL;

//Programmer  : Shahbaaz Sheikh; Student Number: 214066614
//Purpose     : Publicall exposed methods to be used in PL

namespace StorageUnitManagementSystem.BL
{
    public class SUBL
    {
        private StorageUnitManagementProviderBase providerBase;

        public SUBL(string Provider)
        {
            //
            //Method Name : SUBL(string Provider)
            //Purpose     : Overloaded constructor; invoke _SetupProviderBase to setup data provider
            //Re-use      : _SetupProviderBase()
            //Input       : string Provider
            //              - The name of the data provider to use
            //Output      : None
            //
            _SetupProviderBase(Provider);
        } // end method

        /// <summary>
        /// This method gets the list of all the business objects from the StorageUnit datastore.
        /// It returns the list of business objects
        /// </summary>
        public List<StorageUnit> SelectAll()
        {
            return providerBase.SelectAll();
        } // end method

        /// <summary>
        /// This method gets a single StorageUnit object from the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was loaded from the datastore, or
        /// -1 to indicate that no StorageUnit was loaded from the datastore.
        /// </summary>
        /// <param name="ID">The StorageUnit ID of the StorageUnit to load from the datastore.</param>
        /// <param name="StorageUnit">The StorageUnit object loaded from the datastore.</param>
        public int SelectStorageUnit(string ID, ref StorageUnit StorageUnit)
        {
            return providerBase.SelectStorageUnit(ID, ref StorageUnit);
        } // end method

        /// <summary>
        /// This method inserts a row in the StorageUnit datastore. 
        /// It returns 0 to indicate the StorageUnit was inserted into datastore, or
        /// -1 to indicate the StorageUnit was not inserted because a duplicate was found
        /// </summary>
        /// <param name="StorageUnit">The StorageUnit object to add to the StorageUnit datastore.</param>
        public int Insert(StorageUnit StorageUnit)
        {
            return providerBase.Insert(StorageUnit);
        } // end method

        /// <summary>
        /// This method updates a row in the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was found and updated successfully, or
        ///  -1 to indicate the StorageUnit was not updated because the record was not found
        /// </summary>
        /// <param name="StorageUnit">The new StorageUnit data for the row in the StorageUnit datastore.</param>
        public int Update(StorageUnit StorageUnit)
        {
            return providerBase.Update(StorageUnit);
        } // end method

        /// <summary>
        /// This method deletes a row in the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was found and deleted successfully, or
        ///  -1 to indicate the StorageUnit was not deleted because the record was not found
        /// </summary>
        /// <param name="ID">The StorageUnit ID of the StorageUnit to delete in the StorageUnit datastore.</param>
        public int Delete(string ID)
        {
            return providerBase.Delete(ID);
        } // end method

        /// <summary>
        /// This method determines if a given StorageUnit exists in the StorageUnit datastore.
        /// It returns true to indicate the StorageUnit was foundy, or
        ///  false to indicate the StorageUnit was not found
        /// </summary>
        /// <param name="ID">The StorageUnit ID of the StorageUnit to search in the StorageUnit datastore.</param>
        public bool DoesExist(string ID)
        {
            return providerBase.DoesExist(ID);
        } // end method

        private void _SetupProviderBase(string Provider)
        {
            //
            //Method Name : void _SetupProviderBase()
            //Purpose     : Helper method to select the correct data provider
            //Re-use      : None
            //Input       : string Provider
            //              - The name of the data provider to use
            //Output      : None
            //
            if (Provider == "StorageUnitSQLiteProvider")
            {
                providerBase = new StroageUnitManagementSQLiteProvider();
            } // end if
            else
            {
                //if (Provider == "StorageUnitXMLProvider")
                //{
                //    providerBase = new StorageUnitXMLProvider();
                //} // end if
                //    else
                //    {
                //        if (Provider == "StorageUnitCSVProvider")
                //        {
                //            providerBase = new StorageUnitCSVProvider();
                //        } // end if
                //    } // end else
            } // end else
        } // end method
    }
}
