using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageUnitManagementSystem.BL.Classes;
namespace StorageUnitManagementSystem.DAL
{
    public abstract class UserProviderBase
    {
        /// <summary>
        /// This method gets the list of all the business objects from the User datastore.
        /// It returns the list of business objects
        /// </summary>
        public abstract List<User> SelectAll();

        /// <summary>
        /// This method gets a single User object from the User datastore.
        /// It returns 0 to indicate the User was loaded from datastore, or
        /// -1 to indicate that no User was loaded from the datastore (not found).
        /// </summary>
        /// <param name="ID">The ID of the User to load from the datastore.</param>
        /// <param name="User">The User object loaded from the datastore.</param>
        public abstract int SelectUser(string ID, ref User User);

        /// <summary>
        /// This method inserts a row in the User datastore. 
        /// It returns 0 to indicate the User was inserted into datastore, or
        /// -1 to indicate the User was not inserted because a duplicate was found
        /// </summary>
        /// <param name="User">The User object to add to the User datastore.</param>
        public abstract int Insert(User User);

        /// <summary>
        /// This method updates a row in the User datastore.
        /// It returns 0 to indicate the User was found and updated successfully, or
        ///  -1 to indicate the User was not updated because the record was not found
        /// </summary>
        /// <param name="User">The new User data for the row in the User datastore.</param>
        public abstract int Update(User User);

        /// <summary>
        /// This method deletes a row in the User datastore.
        /// It returns 0 to indicate the User was found and deleted successfully, or
        ///  -1 to indicate the User was not deleted because the record was not found
        /// </summary>
        /// <param name="ID">The User ID of the User to delete in the User datastore.</param>
        public abstract int Delete(string ID);

        /// <summary>
        /// This method determines if a given User exists in the User datastore.
        /// It returns true to indicate the User was foundy, or
        ///  false to indicate the User was not found
        /// </summary>
        /// <param name="ID">The User ID of the User to search in the User datastore.</param>
        public abstract bool DoesExist(string ID);
    }
}
