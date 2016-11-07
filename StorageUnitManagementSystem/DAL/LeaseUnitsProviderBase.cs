using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageUnitManagementSystem.BL.Classes;

namespace StorageUnitManagementSystem.DAL
{   
    public abstract class LeaseUnitsProviderBase
    {
        /// <summary>
        /// This method gets the list of all the business objects from the Client datastore.
        /// It returns the list of business objects
        /// </summary>
        public abstract List<LeaseUnits> SelectAll();

        /// <summary>
        /// This method gets a single Client object from the Client datastore.
        /// It returns 0 to indicate the Client was loaded from datastore, or
        /// -1 to indicate that no Client was loaded from the datastore (not found).
        /// </summary>
        /// <param name="ID">The ID of the Client to load from the datastore.</param>
        /// <param name="Client">The Client object loaded from the datastore.</param>
        public abstract int SelectLeaseUnit(string ID, ref LeaseUnits Client);


        /// <summary>
        /// This method inserts a row in the Client datastore. 
        /// It returns 0 to indicate the Client was inserted into datastore, or
        /// -1 to indicate the Client was not inserted because a duplicate was found
        /// </summary>
        /// <param name="Client">The Client object to add to the Client datastore.</param>
        public abstract int Insert(LeaseUnits LeaseUnits);

        /// <summary>
        /// This method updates a row in the Client datastore.
        /// It returns 0 to indicate the Client was found and updated successfully, or
        ///  -1 to indicate the Client was not updated because the record was not found
        /// </summary>
        /// <param name="Client">The new Client data for the row in the Client datastore.</param>
        public abstract int Update(LeaseUnits LeaseUnits);

        /// <summary>
        /// This method deletes a row in the Client datastore.
        /// It returns 0 to indicate the Client was found and deleted successfully, or
        ///  -1 to indicate the Client was not deleted because the record was not found
        /// </summary>
        /// <param name="ID">The Client ID of the Client to delete in the Client datastore.</param>
        public abstract int Delete(string ID);

        /// <summary>
        /// This method determines if a given Client exists in the Client datastore.
        /// It returns true to indicate the Client was foundy, or
        ///  false to indicate the Client was not found
        /// </summary>
        /// <param name="ID">The Client ID of the Client to search in the Client datastore.</param>
        public abstract bool DoesExist(string ID);
    }
}
