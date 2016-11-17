using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using StorageUnitManagementSystem.BL.Classes;

namespace StorageUnitManagementSystem.DAL
{
    class StroageUnitManagementSQLiteProvider : StorageUnitManagementProviderBase
    {
        private SQLiteConnection _sqlCon;
        private string _conStr = CreateDatabase.ConStr;
        public override List<StorageUnit> SelectAll()
        {
            //
            //Method Name : List<StorageUnit> SelectAll()
            //Purpose     : Try to get all the StorageUnit objects from the datastore
            //Re-use      : None
            //Input       : None        
            //Output      : - ref List<StorageUnit>
            //                - the list that will contain the StorageUnit objects loaded from datastore         
            //

            List<StorageUnit> StorageUnits; // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr);  // new connection
                bool bRead = false;
                StorageUnits = new List<StorageUnit>(); // this ensures that if there are no records,
                                                        // the returned list will not be null, but
                                                        // it will be empty (Count = 0)

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM StorageUnits";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read(); // Priming read (must have 2nd read in loop)
                while (bRead == true) // false indicates no more rows/records4\4
                {
                    StorageUnit StorageUnit = new StorageUnit();
                    //unit.Address = new Address();
                    //unit.Phone = new Phone();

                    StorageUnit.UnitId = Convert.ToString(sdr["suID"]);
                    StorageUnit.UnitClassification = Convert.ToString(sdr["suClassification"]);
                    StorageUnit.UnitPrice = Convert.ToDouble(sdr["suPrice"]);
                    StorageUnit.UnitSize = Convert.ToString(sdr["suSize"]);
                    StorageUnit.UnitArrears = (Convert.ToInt16(sdr["suArrears"]) == 1) ? true : false;//First Converts Object to Int16 and then Int16 to Boolean Value
                    StorageUnit.UnitOccupied = (Convert.ToInt16(sdr["suOccupied"]) == 1) ? true : false;
                    StorageUnit.UnitInAdvance = (Convert.ToInt16(sdr["suAdvance"]) == 1) ? true : false;
                    StorageUnit.UnitUpToDate = (Convert.ToInt16(sdr["suUpToDate"]) == 1) ? true : false;
                    StorageUnit.UnitOwnerId = Convert.ToString(sdr["suOwnerID"]);


                    StorageUnits.Add(StorageUnit);
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
            return StorageUnits; // Single return
        } // end method

        public override int SelectStorageUnit(string ID, ref StorageUnit StorageUnit)
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
                StorageUnit = new StorageUnit();

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM StorageUnits WHERE [suID] = '" + ID + "'";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read();
                if (bRead == true) // false indicates no row/record read
                {
                    StorageUnit.UnitId = Convert.ToString(sdr["suID"]);
                    StorageUnit.UnitClassification = Convert.ToString(sdr["suClassification"]);
                    StorageUnit.UnitPrice = Convert.ToDouble(sdr["suPrice"]);
                    StorageUnit.UnitSize = Convert.ToString(sdr["suSize"]);
                    StorageUnit.UnitOwnerId = Convert.ToString(sdr["suOwner"]);
                    StorageUnit.UnitArrears = (Convert.ToInt16(sdr["suArrears"]) == 1) ? true : false; //First Converts Object to Int16 and then Int16 to Boolean Value
                    StorageUnit.UnitOccupied = (Convert.ToInt16(sdr["suOccupied"]) == 1) ? true : false;
                    StorageUnit.UnitInAdvance = (Convert.ToInt16(sdr["suAdvance"]) == 1) ? true : false;
                    StorageUnit.UnitUpToDate = (Convert.ToInt16(sdr["suUpToDate"]) == 1) ? true : false;
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


        //public override int Insert(StorageUnit StorageUnit)
        //{
        //    //
        //    //Method Name : int Insert(StorageUnit StorageUnit)
        //    //Purpose     : Try to insert a row in the StorageUnit datastore
        //    //Re-use      : DoesExist()
        //    //Input       : StorageUnit StorageUnit
        //    //              - The StorageUnit object to add to the StorageUnit datastore
        //    //Output      : - int
        //    //                0 : StorageUnit inserted into datastore
        //    //               -1 : StorageUnit not inserted because a duplicate was found
        //    //
        //    int rc = 0; // will be returned, thus can not be declared in try block

        //    try
        //    {
        //        bool doesExist = false;
        //        int rowsAffected = 0;

        //        doesExist = DoesExist(StorageUnit.UnitId);
        //        if (doesExist == false)
        //        {
        //            //TO:DO 
        //            _sqlCon = new SQLiteConnection(_conStr); // new connection
        //            _sqlCon.Open(); // open connection
        //            string insertQuery = "INSERT INTO StorageUnits([suID], [suClassification], [suPrice], " +
        //                                 "[suSize],[suArrears],[suOccupied],[suAdvance],[suUpToDate] ) VALUES(" +
        //                                 "@seID, @suClassification, @suPrice, @suSize,@suArrears,@suOccupied," +
        //                                 "@suAdvance,@suUpToDate)";
        //            SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, _sqlCon); // setup command
        //            SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
        //            {
        //                new SQLiteParameter("@suID",DbType.String),
        //                new SQLiteParameter("@suClassification",DbType.String),
        //                new SQLiteParameter("@suPrice", DbType.VarNumeric),
        //                new SQLiteParameter("@suSize", DbType.String),
        //                new SQLiteParameter("@suArrears",DbType.Int16),
        //                new SQLiteParameter("@suOccupied",DbType.Int16),
        //                new SQLiteParameter("@suAdvance",DbType.Int16),
        //                new SQLiteParameter("@suUpToDate",DbType.Int16)

        //            };
        //            sqlParams[0].Value = StorageUnit.UnitId; // Populate SQLiteParameters from StorageUnit
        //            sqlParams[1].Value = StorageUnit.UnitClassification;
        //            sqlParams[2].Value = StorageUnit.UnitPrice;
        //            sqlParams[3].Value = StorageUnit.UnitSize;
        //            sqlParams[4].Value = StorageUnit.UnitArrears ? 1 : 0; // ? 1 : 0 Converts Boolean to Int16 for Database Storage 
        //            sqlParams[5].Value = StorageUnit.UnitOccupied ? 1 : 0;
        //            sqlParams[6].Value = StorageUnit.UnitInAdvance ? 1 : 0;
        //            sqlParams[7].Value = StorageUnit.UnitUpToDate ? 1 : 0;
        //            sqlCommand.Parameters.AddRange(sqlParams);
        //            rowsAffected = sqlCommand.ExecuteNonQuery();
        //            if (rowsAffected == 1) // Test rowsAffected
        //            {
        //                // 1 row affected, thus 1 row added to datastore, thus success
        //                rc = 0;
        //            } // end if  
        //        } // end if
        //        else
        //        {
        //            rc = -1;
        //        } // end else

        //    } // end try
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    } // end catch
        //    finally
        //    {
        //        _sqlCon.Close();  // Close connection
        //    } // end finally
        //    return rc; // Single return
        //} // end method


        //public override int Insert(StorageUnit StorageUnit)
        //{
        //    //
        //    //Method Name : int Insert(StorageUnit StorageUnit)
        //    //Purpose     : Try to insert a row in the StorageUnit datastore
        //    //Re-use      : DoesExist()
        //    //Input       : StorageUnit StorageUnit
        //    //              - The StorageUnit object to add to the StorageUnit datastore
        //    //Output      : - int
        //    //                0 : StorageUnit inserted into datastore
        //    //               -1 : StorageUnit not inserted because a duplicate was found
        //    //
        //    int rc = 0; // will be returned, thus can not be declared in try block

        //    try
        //    {
        //        bool doesExist = false;
        //        int rowsAffected = 0;

        //        doesExist = DoesExist(StorageUnit.UnitId);
        //        if (doesExist == false)
        //        {
        //            //TO:DO 
        //            _sqlCon = new SQLiteConnection(_conStr); // new connection
        //            _sqlCon.Open(); // open connection
        //            string insertQuery = "INSERT INTO StorageUnits([suID], [suClassification], [suPrice], " +
        //                                 "[suSize],[suArrears],[suOccupied],[suAdvance],[suUpToDate] ) VALUES(" +
        //                                 "@seID, @suClassification, @suPrice, @suSize,@suArrears,@suOccupied," +
        //                                 "@suAdvance,@suUpToDate)";
        //            SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, _sqlCon); // setup command
        //            SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
        //            {
        //                new SQLiteParameter("@suID",DbType.String),
        //                new SQLiteParameter("@suClassification",DbType.String),
        //                new SQLiteParameter("@suPrice", DbType.VarNumeric),
        //                new SQLiteParameter("@suSize", DbType.String),
        //                new SQLiteParameter("@suArrears",DbType.Int16),
        //                new SQLiteParameter("@suOccupied",DbType.Int16),
        //                new SQLiteParameter("@suAdvance",DbType.Int16),
        //                new SQLiteParameter("@suUpToDate",DbType.Int16)

        //            };
        //            sqlParams[0].Value = StorageUnit.UnitId; // Populate SQLiteParameters from StorageUnit
        //            sqlParams[1].Value = StorageUnit.UnitClassification;
        //            sqlParams[2].Value = StorageUnit.UnitPrice;
        //            sqlParams[3].Value = StorageUnit.UnitSize;
        //            sqlParams[4].Value = StorageUnit.UnitArrears ? 1 : 0; // ? 1 : 0 Converts Boolean to Int16 for Database Storage 
        //            sqlParams[5].Value = StorageUnit.UnitOccupied ? 1 : 0;
        //            sqlParams[6].Value = StorageUnit.UnitInAdvance ? 1 : 0;
        //            sqlParams[7].Value = StorageUnit.UnitUpToDate ? 1 : 0;
        //            sqlCommand.Parameters.AddRange(sqlParams);
        //            rowsAffected = sqlCommand.ExecuteNonQuery();
        //            if (rowsAffected == 1) // Test rowsAffected
        //            {
        //                // 1 row affected, thus 1 row added to datastore, thus success
        //                rc = 0;
        //            } // end if  
        //        } // end if
        //        else
        //        {
        //            rc = -1;
        //        } // end else

        //    } // end try
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    } // end catch
        //    finally
        //    {
        //        _sqlCon.Close();  // Close connection
        //    } // end finally
        //    return rc; // Single return
        //} // end method

        public override int Insert(StorageUnit StorageUnit)
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

                doesExist = DoesExist(StorageUnit.UnitId);
                if (doesExist == false)
                {
                    //TO:DO 
                    _sqlCon = new SQLiteConnection(_conStr); // new connection
                    _sqlCon.Open(); // open connection
                    string insertQuery = "INSERT INTO StorageUnits([suID], [suClassification], [suPrice], " +
                                         "[suSize],[suArrears],[suOccupied],[suAdvance],[suUpToDate],[suOwnerID] ) VALUES(" +
                                         "@suID, @suClassification, @suPrice, @suSize,@suArrears,@suOccupied," +
                                         "@suAdvance,@suUpToDate,@suOwnerID)";
                    SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, _sqlCon); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@suID",DbType.String),
                        new SQLiteParameter("@suClassification",DbType.String),
                        new SQLiteParameter("@suPrice", DbType.VarNumeric),
                        new SQLiteParameter("@suSize", DbType.String),
                        new SQLiteParameter("@suArrears",DbType.Int16),
                        new SQLiteParameter("@suOccupied",DbType.Int16),
                        new SQLiteParameter("@suAdvance",DbType.Int16),
                        new SQLiteParameter("@suUpToDate",DbType.Int16),
                        new SQLiteParameter("@suOwnerID",DbType.String),

                    };
                    sqlParams[0].Value = StorageUnit.UnitId;
                    sqlParams[1].Value = StorageUnit.UnitClassification;
                    sqlParams[2].Value = StorageUnit.UnitPrice;
                    sqlParams[3].Value = StorageUnit.UnitSize;
                    sqlParams[4].Value = StorageUnit.UnitArrears ? 1 : 0; // ? 1 : 0 Converts Boolean to Int16 for Database Storage 
                    sqlParams[5].Value = StorageUnit.UnitOccupied ? 1 : 0;
                    sqlParams[6].Value = StorageUnit.UnitInAdvance ? 1 : 0;
                    sqlParams[7].Value = StorageUnit.UnitUpToDate ? 1 : 0;
                    sqlParams[8].Value = StorageUnit.UnitOwnerId;

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

        public override int Update(StorageUnit StorageUnit)
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
                string updateQuery = string.Format("UPDATE StorageUnits SET [suClassification]=@suClassification, [suPrice]=@suPrice, " +
                                         "[suSize]=@suSize,[suArrears]=@suArrears,[suOwnerID]=@suOwnerID," +
                                                   "[suOccupied]=@suOccupied,[suAdvance]=@suAdvance," +
                                                   "[suUpToDate]=@suUpToDate WHERE " +
                                         "[suID] = '{0}'", StorageUnit.UnitId);
                SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, _sqlCon); // setup command
                SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                {
                        new SQLiteParameter("@suID",DbType.String),
                        new SQLiteParameter("@suClassification",DbType.String),
                        new SQLiteParameter("@suPrice", DbType.VarNumeric),
                        new SQLiteParameter("@suSize", DbType.String),
                        new SQLiteParameter("@suArrears",DbType.Int16),
                        new SQLiteParameter("@suOccupied",DbType.Int16),
                        new SQLiteParameter("@suAdvance",DbType.Int16),
                        new SQLiteParameter("@suUpToDate",DbType.Int16),
                        new SQLiteParameter("@suOwnerID",DbType.String) 

                };
                sqlParams[0].Value = StorageUnit.UnitId; // Populate SQLiteParameters from StorageUnit
                sqlParams[1].Value = StorageUnit.UnitClassification;
                sqlParams[2].Value = StorageUnit.UnitPrice;
                sqlParams[3].Value = StorageUnit.UnitSize;
                sqlParams[4].Value = StorageUnit.UnitArrears ? 1 : 0; // ? 1 : 0 Converts Boolean to Int16 for Database Storage 
                sqlParams[5].Value = StorageUnit.UnitOccupied ? 1 : 0;
                sqlParams[6].Value = StorageUnit.UnitInAdvance ? 1 : 0;
                sqlParams[7].Value = StorageUnit.UnitUpToDate ? 1 : 0;
                sqlParams[8].Value = StorageUnit.UnitOwnerId;
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
                string deleteQuery = string.Format("DELETE FROM StorageUnits WHERE [suID] = '{0}'", ID);
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
                string selectQuery = "SELECT * FROM StorageUnits WHERE [suID] = '" + ID + "'";
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




    } // end class
}
