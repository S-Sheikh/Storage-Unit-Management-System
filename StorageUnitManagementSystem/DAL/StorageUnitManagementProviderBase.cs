using System.Collections.Generic;
using StorageUnitManagementSystem.BL.Classes;
//
namespace StorageUnitManagementSystem.DAL
{
    public abstract class StorageUnitManagementProviderBase
    {
        /// <summary>
        /// This method gets the list of all the business objects from the StorageUnit datastore.
        /// It returns the list of business objects
        /// </summary>
        public abstract List<StorageUnit> SelectAll();

        /// <summary>
        /// This method gets a single StorageUnit object from the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was loaded from datastore, or
        /// -1 to indicate that no StorageUnit was loaded from the datastore (not found).
        /// </summary>
        /// <param name="ID">The ID of the StorageUnit to load from the datastore.</param>
        /// <param name="StorageUnit">The StorageUnit object loaded from the datastore.</param>
        public abstract int SelectStorageUnit(string ID, ref StorageUnit StorageUnit);

        /// <summary>
        /// This method inserts a row in the StorageUnit datastore. 
        /// It returns 0 to indicate the StorageUnit was inserted into datastore, or
        /// -1 to indicate the StorageUnit was not inserted because a duplicate was found
        /// </summary>
        /// <param name="StorageUnit">The StorageUnit object to add to the StorageUnit datastore.</param>
        public abstract int Insert(StorageUnit StorageUnit);

        /// <summary>
        /// This method updates a row in the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was found and updated successfully, or
        ///  -1 to indicate the StorageUnit was not updated because the record was not found
        /// </summary>
        /// <param name="StorageUnit">The new StorageUnit data for the row in the StorageUnit datastore.</param>
        public abstract int Update(StorageUnit StorageUnit);

        /// <summary>
        /// This method deletes a row in the StorageUnit datastore.
        /// It returns 0 to indicate the StorageUnit was found and deleted successfully, or
        ///  -1 to indicate the StorageUnit was not deleted because the record was not found
        /// </summary>
        /// <param name="ID">The StorageUnit ID of the StorageUnit to delete in the StorageUnit datastore.</param>
        public abstract int Delete(string ID);

        /// <summary>
        /// This method determines if a given StorageUnit exists in the StorageUnit datastore.
        /// It returns true to indicate the StorageUnit was foundy, or
        ///  false to indicate the StorageUnit was not found
        /// </summary>
        /// <param name="ID">The StorageUnit ID of the StorageUnit to search in the StorageUnit datastore.</param>
        public abstract bool DoesExist(string ID);
    }
}
