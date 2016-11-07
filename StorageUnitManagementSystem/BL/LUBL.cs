using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageUnitManagementSystem.BL.Classes;
using StorageUnitManagementSystem.DAL;

namespace StorageUnitManagementSystem.BL
{
    class LUBL
    {
        private LeaseUnitsProviderBase providerBase;
        public LUBL(string Provider)
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
        public List<LeaseUnits> SelectAll()
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
        public int SelectLeaseUnit(string ID, ref LeaseUnits LeaseUnit)
        {
            return providerBase.SelectLeaseUnit(ID, ref LeaseUnit);
        } // end method

        /// <summary>
        /// This method inserts a row in the StorageUnit datastore. 
        /// It returns 0 to indicate the StorageUnit was inserted into datastore, or
        /// -1 to indicate the StorageUnit was not inserted because a duplicate was found
        /// </summary>
        /// <param name="StorageUnit">The StorageUnit object to add to the StorageUnit datastore.</param>
        public int Insert(LeaseUnits LeaseUnit)
        {
            return providerBase.Insert(LeaseUnit);
        } // end method

        /// <summary>
        /// This method updates a row in the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was found and updated successfully, or
        ///  -1 to indicate the StorageUnit was not updated because the record was not found
        /// </summary>
        /// <param name="StorageUnit">The new StorageUnit data for the row in the StorageUnit datastore.</param>
        public int Update(LeaseUnits LeaseUnit)
        {
            return providerBase.Update(LeaseUnit);
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
            if (Provider == "LeaseUnitsSQLiteProvider")
            {
                providerBase = new LeaseUnitsSQLiteProvider();
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
