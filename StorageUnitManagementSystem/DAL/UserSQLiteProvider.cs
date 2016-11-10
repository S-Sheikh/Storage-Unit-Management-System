using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using StorageUnitManagementSystem.DAL;
using StorageUnitManagementSystem.BL.Classes;


namespace StorageUnitManagementSystem.DAL
{
    public class UserSQLiteProvider : UserProviderBase
    {
        private string _conStr = "Data Source=c:\\DataStores\\StorageUnitManagementDB.db;Version=3;";
        private SQLiteConnection _sqlCon;

        public override List<User> SelectAll()
        {
            //
            //Method Name : List<StorageUnit> SelectAll()
            //Purpose     : Try to get all the StorageUnit objects from the datastore
            //Re-use      : None
            //Input       : None        
            //Output      : - ref List<StorageUnit>
            //                - the list that will contain the StorageUnit objects loaded from datastore         
            //

            List<User> User; // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr);  // new connection
                bool bRead = false;
                User = new List<User>(); // this ensures that if there are no records,
                                          // the returned list will not be null, but
                                          // it will be empty (Count = 0)

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM Users";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read(); // Priming read (must have 2nd read in loop)
                while (bRead == true) // false indicates no more rows/records4\4
                {
                    User user = new User();

                    user.Id = Convert.ToString(sdr["UId"]);
                    user.UserName = Convert.ToString(sdr["UName"]);
                    
                    user.Password = Convert.ToString(sdr["UPassword"]);
                    user.Role = Convert.ToString(sdr["UPosition"]);

                    User.Add(user);
                    bRead = sdr.Read(); // Priming read (must have 1st read before loop)
                } // end while
                sdr.Close(); // close reader
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                _sqlCon.Close();  // Close connection
            } // end finally
            return User; // Single return
        } // end method

        public override int SelectUser(string ID, ref User User)
        {
            //
            //Method Name : int SelectStorageUnit(string ID, ref StorageUnit StorageUnit)
            //Purpose     : Try to get a single StorageUnit object from the StorageUnit datastore
            //Re-use      : 
            //Input       : string ID
            //              - The ID of the StorageUnit to load from the datastore
            //              ref StorageUnit StorageUnit
            //              - The StorageUnit object loaded from the datastore
            //Output      : - int
            //                0 : StorageUnit loaded from datastore
            //               -1 : no StorageUnit was loaded from the datastore (not found)
            //

            int rc = 0;  // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr); // new connection
                bool bRead = false;
                User = new User();

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM Users WHERE [UId] = '" + ID + "'";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read();
                if (bRead == true) // false indicates no row/record read
                {
                    User.Id = Convert.ToString(sdr["UId"]);
                    User.UserName = Convert.ToString(sdr["UName"]);
                    
                    User.Password = Convert.ToString(sdr["UPassword"]);
                    User.Role = Convert.ToString(sdr["UPosition"]);
                    rc = 0;
                } // end if
                else
                {

                    rc = -1;
                } // end else
                sdr.Close();  // close reader
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                _sqlCon.Close();  // Close connection
            } // end finally
            return rc; // single return
        } // end method

        public override int Insert(User User)
        {
            //
            //Method Name : int Insert(StorageUnit StorageUnit)
            //Purpose     : Try to insert a row in the StorageUnit datastore
            //Re-use      : DoesExist()
            //Input       : StorageUnit StorageUnit
            //              - The StorageUnit object to add to the StorageUnit datastore
            //Output      : - int
            //                0 : StorageUnit inserted into datastore
            //               -1 : StorageUnit not inserted because a duplicate was found
            //
            int rc = 0; // will be returned, thus can not be declared in try block

            try
            {
                bool doesExist = false;
                int rowsAffected = 0;

                doesExist = DoesExist(User.Id);
                if (doesExist == false)
                {
                    //TO:DO 
                    _sqlCon = new SQLiteConnection(_conStr); // new connection
                    _sqlCon.Open(); // open connection
                    string insertQuery = "INSERT INTO Users([UId], [UserName], " +
                                         "[UPassword], [UPosition] ) VALUES(" +
                                         "@UId, @UName, @UPassword, @UPosition" +
                                         ")";
                    SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, _sqlCon); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@UId",DbType.String),
                        new SQLiteParameter("@UName",DbType.String),
                        
                        new SQLiteParameter("@UPassword", DbType.String),
                        new SQLiteParameter("@UPosition",DbType.String),

                    };
                    sqlParams[0].Value = User.Id; // Populate SQLiteParameters from StorageUnit
                    sqlParams[1].Value = User.UserName;
                    
                    sqlParams[3].Value = User.Password;
                    sqlParams[4].Value = User.Role;

                    sqlCommand.Parameters.AddRange(sqlParams);
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected == 1) // Test rowsAffected
                    {
                        // 1 row affected, thus 1 row added to datastore, thus success
                        rc = 0;
                    } // end if  
                } // end if
                else
                {
                    rc = -1;
                } // end else

            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                _sqlCon.Close();  // Close connection
            } // end finally
            return rc; // Single return
        } // end method

        public override int Update(User User)
        {
            //
            //Method Name : int Update(StorageUnit StorageUnit)
            //Purpose     : Try to update a row in the StorageUnit datastore
            //Re-use      : None
            //Input       : StorageUnit StorageUnit
            //              - The new StorageUnit data for the row in the StorageUnit datastore
            //Output      : - int
            //                0 : StorageUnit found and updated successfully
            //               -1 : StorageUnit not updated because the record was not found
            //
            int rc = 0; // will be returned, thus can not be declared in try block
            try
            {
                int rowsAffected = 0;
                _sqlCon = new SQLiteConnection(_conStr); // New connection
                _sqlCon.Open(); // open connection
                //
                // REMEMBER: DO NOT update primary key (ID)!!!
                //

                //
                // A better option would be to only update the fields that actually changed
                //
                string updateQuery = string.Format("UPDATE Users SET [UName]=@UName, " +
                                         "[UPassword]=@UPassword,[UPosition]=@UPosition" +
                                                   " WHERE " +
                                         "[UId] = '{0}'", User.Id);
                SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, _sqlCon); // setup command
                SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                {
                        new SQLiteParameter("@UId",DbType.String),
                        new SQLiteParameter("@UName",DbType.String),
                        
                        new SQLiteParameter("@UPassword", DbType.String),
                        new SQLiteParameter("@UPosition",DbType.String),

                };
                sqlParams[0].Value = User.Id; // Populate SQLiteParameters from StorageUnit
                sqlParams[1].Value = User.UserName;
                
                sqlParams[3].Value = User.Password;
                sqlParams[4].Value = User.Role;

                sqlCommand.Parameters.AddRange(sqlParams);
                rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 0) // Test rowsAffected
                {
                    // 0 rows affected, thus NO row updated in datastore, thus not found, thus failure
                    rc = -1;
                } // end if
                else
                {
                    // 1 row affected, thus 1 row updated in datastore, thus success
                    rc = 0;
                } // end else
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                _sqlCon.Close();  // Close connection
            } // end finally
            return rc; // single return
        } // end method

        public override int Delete(string ID)
        {
            //
            //Method Name : int Delete(string ID)
            //Purpose     : Try to delete a row from the StorageUnit datastore
            //Re-use      : None
            //Input       : string ID
            //              - the ID of the StorageUnit to delete in the StorageUnit datastore
            //Output      : - int
            //                0 : StorageUnit found and deleted successfully
            //               -1 : StorageUnit not deleted because the record was not found
            //
            int rc = 0;  // will be returned, thus can not be declared in try block

            try
            {
                int rowsAffected = 0;

                _sqlCon = new SQLiteConnection(_conStr); // New connection
                _sqlCon.Open(); // Open connection
                string deleteQuery = string.Format("DELETE FROM Users WHERE [UId] = '{0}'", ID);
                SQLiteCommand sqlCommand = new SQLiteCommand(deleteQuery, _sqlCon); // setup command
                rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 0) // Test rowsAffected
                {
                    // 0 rows affected, thus NO row updated in datastore, thus not found, thus failure
                    rc = -1;
                } // end if
                else
                {
                    // 1 row affected, thus 1 row updated in datastore, thus success
                    rc = 0;
                } // end else
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                _sqlCon.Close();  // Close connection
            } // end finally
            return rc; // Single return
        } // end method

        public override bool DoesExist(string ID)
        {
            //
            //Method Name : bool DoesExist(string ID)
            //Purpose     : Determines if a given StorageUnit exists in the StorageUnit datastore.
            //Re-use      : None
            //Input       : string ID
            //              - the ID of the StorageUnit to search in the StorageUnit datastore
            //Output      : - bool
            //                true : StorageUnit found
            //               false : StorageUnit not found
            //
            bool rc = false;  // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr); // new connection
                bool bRead = false;

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM Users WHERE [UId] = '" + ID + "'";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read();
                if (bRead == true) // false indicates no row/record read
                {
                    rc = true;
                } // end if
                else
                {
                    rc = false;
                } // end else
                sdr.Close();  // close reader
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                _sqlCon.Close();  // Close connection
            } // end finally
            return rc; // single return
        } // end method
    }
}
