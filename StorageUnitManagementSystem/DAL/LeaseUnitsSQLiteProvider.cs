﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageUnitManagementSystem.BL.Classes;
using System.Data.SQLite;
using System.Data;

namespace StorageUnitManagementSystem.DAL
{
   public class LeaseUnitsSQLiteProvider : LeaseUnitsProviderBase
    {
        private string _conStr = "Data Source=c:\\DataStores\\StorageUnitManagementDB.db;Version=3;";
        private SQLiteConnection _sqlCon;

        public override List<LeaseUnits> SelectAll()
        {
            //
            //Method Name : List<Client> SelectAll()
            //Purpose     : Try to get all the Client objects from the datastore
            //Re-use      : None
            //Input       : None        
            //Output      : - ref List<Client>
            //                - the list that will contain the Client objects loaded from datastore         
            //

            List<LeaseUnits> LeaseUnits; // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr);  // new connection
                bool bRead = false;
                LeaseUnits = new List<LeaseUnits>(); // this ensures that if there are no records,
                                              // the returned list will not be null, but
                                              // it will be empty (Count = 0)

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM LeaseUnits";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read(); // Priming read (must have 2nd read in loop)
                while (bRead == true) // false indicates no more rows/records4\4
                {
                    LeaseUnits LeaseUnit = new LeaseUnits();
                    //unit.Address = new Address();
                    //unit.Phone = new Phone();
                    LeaseUnit.Client = new Client();
                    LeaseUnit.StorageUnit = new StorageUnit();

                    LeaseUnit.Client.idNumber = Convert.ToString(sdr["ClientID"]);
                    LeaseUnit.Client.FirstName = Convert.ToString(sdr["ClientName"]);
                    LeaseUnit.Client.LastName = Convert.ToString(sdr["ClientSurName"]);
                    LeaseUnit.StorageUnit.UnitId = Convert.ToString(sdr["UnitID"]);
                    LeaseUnit.StorageUnit.UnitClassification = Convert.ToString(sdr["UnitClass"]);
                    LeaseUnit.StorageUnit.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);
                    LeaseUnit.NoOfUnits = Convert.ToInt32(sdr["NoOfUnits"]);
                    LeaseUnit.ClientWaitingList =(Convert.ToInt16(sdr["ClientWaitingList"])==1) ? true:false;
                    LeaseUnit.AvailableUnits = Convert.ToInt32(sdr["AvailableUnits"]);
                    LeaseUnit.TypeOfPayment = Convert.ToString(sdr["TypeOfPayment"]);
                    LeaseUnit.DateOfPayment= Convert.ToString(sdr["DatePaid"]);
                    LeaseUnit.DateOfContractStart = Convert.ToString(sdr["DateOfContractStart"]);
                    LeaseUnit.DateOfContractEnd = Convert.ToString(sdr["DateOfContractEnd"]);
                    LeaseUnit.AmountDeposited = Convert.ToString(sdr["AmountDeposited"]);
                    LeaseUnit.AmountOwed = Convert.ToString(sdr["AmountOwed"]);
                    LeaseUnit.AmountPaid = Convert.ToString(sdr["AmountPaid"]);
                    LeaseUnit.ClientCurrentTotal = Convert.ToString(sdr["ClientCurrentTotal"]);
                    LeaseUnit.UnitLeased = (Convert.ToInt16(sdr["UnitLeased"])==1) ? true:false;
                    LeaseUnits.Add(LeaseUnit);
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
            return LeaseUnits; // Single return
        } // end method

        public override int SelectLeaseUnit(string ID, ref LeaseUnits LeaseUnit)
        {
            //
            //Method Name : int SelectSalaryEmployee(string ID, ref Client Client)
            //Purpose     : Try to get a single Client object from the Client datastore
            //Re-use      : 
            //Input       : string ID
            //              - The ID of the Client to load from the datastore
            //              ref Client Client
            //              - The Client object loaded from the datastore
            //Output      : - int
            //                0 : Client loaded from datastore
            //               -1 : no Client was loaded from the datastore (not found)
            //

            int rc = 0;  // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr); // new connection
                bool bRead = false;
                LeaseUnit = new LeaseUnits();

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM LeaseUnits WHERE [ClientID] = '" + ID + "'";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read();
                if (bRead == true) // false indicates no row/record read
                {

                    LeaseUnit.Client.idNumber = Convert.ToString(sdr["ClientID"]);
                    LeaseUnit.Client.FirstName = Convert.ToString(sdr["ClientName"]);
                    LeaseUnit.Client.LastName = Convert.ToString(sdr["ClientSurName"]);
                    LeaseUnit.StorageUnit.UnitId = Convert.ToString(sdr["UnitID"]);
                    LeaseUnit.StorageUnit.UnitClassification = Convert.ToString(sdr["UnitClass"]);
                    LeaseUnit.StorageUnit.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);
                    LeaseUnit.NoOfUnits = Convert.ToInt32(sdr["NoOfUnits"]);
                    LeaseUnit.ClientWaitingList = (Convert.ToInt16(sdr["ClientWaitingList"]) == 1) ? true : false;
                    LeaseUnit.AvailableUnits = Convert.ToInt32(sdr["AvailableUnits"]);
                    LeaseUnit.TypeOfPayment = Convert.ToString(sdr["TypeOfPayment"]);
                    LeaseUnit.DateOfPayment = Convert.ToString(sdr["DatePaid"]);
                    LeaseUnit.DateOfContractStart = Convert.ToString(sdr["DateOfContractStart"]);
                    LeaseUnit.DateOfContractEnd = Convert.ToString(sdr["DateOfContractEnd"]);
                    LeaseUnit.AmountDeposited = Convert.ToString(sdr["AmountDeposited"]);
                    LeaseUnit.AmountOwed = Convert.ToString(sdr["AmountOwed"]);
                    LeaseUnit.AmountPaid = Convert.ToString(sdr["AmountPaid"]);
                    LeaseUnit.ClientCurrentTotal = Convert.ToString(sdr["ClientCurrentTotal"]);
                    LeaseUnit.UnitLeased = (Convert.ToInt16(sdr["UnitLeased"]) == 1) ? true : false;
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

        public override int Insert(LeaseUnits LeaseUnit)
        {
            //
            //Method Name : int Insert(Client Client)
            //Purpose     : Try to insert a row in the Client datastore
            //Re-use      : DoesExist()
            //Input       : Client Client
            //              - The Client object to add to the Client datastore
            //Output      : - int
            //                0 : Client inserted into datastore
            //               -1 : Client not inserted because a duplicate was found
            //
            int rc = 0; // will be returned, thus can not be declared in try block

            try
            {
                bool doesExist = false;
                int rowsAffected = 0;

                doesExist = DoesExist(LeaseUnit.Client.idNumber);
                if (doesExist == false)
                {
                    //TO:DO 
                    _sqlCon = new SQLiteConnection(_conStr); // new connection
                    _sqlCon.Open(); // open connection
                    string insertQuery = "INSERT INTO LeaseUnits([ClientID], [ClientName], [ClientSurname], " +
                                         "[UnitID],[UnitClass],[UnitPrice],[NoOfUnits]," +
                                         "[ClientWaitingList],[AvailableUnits],[TypeOfPayment],[DatePaid]," +
                                         "[DateOfContractStart],[DateOfContractEnd],[AmountDeposit],[AmountOwed]," +
                                         "[AmountPaid],[ClientCurrentTotal],[UnitLeased] ) VALUES(" +
                                         "@ClientID, @ClientName, @ClientSurname, @UnitID,@UnitClass,@UnitPrice," +
                                         "@NoOfUnits,@ClientWaitingList,@AvailableUnits,@TypeOfPayment,@DatePaid," +
                                         "@DateOfContractStart,@DateOfContractEnd,@AmountDeposit,@AmountOwed,@AmountPaid," +
                                         "@ClientCurrentTotal,@UnitLeased)";
                    SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, _sqlCon); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@ClientID",DbType.String),
                        new SQLiteParameter("@ClientName",DbType.String),
                        new SQLiteParameter("@ClientSurname", DbType.String),
                        new SQLiteParameter("@UnitID", DbType.String),
                        new SQLiteParameter("@UnitClass",DbType.String),
                        new SQLiteParameter("@UnitPrice",DbType.Double),
                        new SQLiteParameter("@NoOfUnits",DbType.String),
                        new SQLiteParameter("@ClientWaitingList",DbType.String),
                        new SQLiteParameter("@AvailableUnits",DbType.String),
                        new SQLiteParameter("@TypeOfPayment",DbType.String),
                        new SQLiteParameter("@DatePaid",DbType.String),
                        new SQLiteParameter("@DateOfContractStart",DbType.String),
                        new SQLiteParameter("@DateOfContractEnd",DbType.String),
                        new SQLiteParameter("@AmountDeposit",DbType.String),
                        new SQLiteParameter("@AmountOwed", DbType.String),
                        new SQLiteParameter("@AmountPaid", DbType.String),
                        new SQLiteParameter("@ClientCurrentTotal", DbType.String),
                        new SQLiteParameter("@UnitLeased", DbType.Int16),

                };
                    sqlParams[0].Value = LeaseUnit.Client.idNumber; // Populate SQLiteParameters from Client
                    sqlParams[1].Value = LeaseUnit.Client.FirstName;
                    sqlParams[2].Value = LeaseUnit.Client.LastName;
                    sqlParams[3].Value = LeaseUnit.StorageUnit.UnitId;
                    sqlParams[4].Value = LeaseUnit.StorageUnit.UnitClassification;
                    sqlParams[5].Value = LeaseUnit.StorageUnit.UnitPrice;
                    sqlParams[6].Value = LeaseUnit.NoOfUnits;
                    sqlParams[7].Value = LeaseUnit.ClientWaitingList;
                    sqlParams[8].Value = LeaseUnit.AvailableUnits;
                    sqlParams[9].Value = LeaseUnit.TypeOfPayment;
                    sqlParams[10].Value = LeaseUnit.DateOfPayment;
                    sqlParams[11].Value = LeaseUnit.DateOfContractStart;
                    sqlParams[12].Value = LeaseUnit.DateOfContractEnd;
                    sqlParams[13].Value = LeaseUnit.AmountDeposited;
                    sqlParams[14].Value = LeaseUnit.AmountOwed;
                    sqlParams[15].Value = LeaseUnit.AmountPaid;
                    sqlParams[16].Value = LeaseUnit.ClientCurrentTotal;
                    sqlParams[17].Value = LeaseUnit.UnitLeased ? 1 : 0;// ? 1 : 0 Converts Boolean to Int16 for Database Storage 
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

        public override int Update(LeaseUnits LeaseUnit)
        {
            //
            //Method Name : int Update(Client Client)
            //Purpose     : Try to update a row in the Client datastore
            //Re-use      : None
            //Input       : Client Client
            //              - The new Client data for the row in the Client datastore
            //Output      : - int
            //                0 : Client found and updated successfully
            //               -1 : Client not updated because the record was not found
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
                string updateQuery = string.Format("UPDATE LeaseUnits SET [ClientID]=@ClientID, [ClientName]=@ClientName, " +
                                         "[clientSurname]=@clientSurname,[UnitID]=@UnitID," +
                                                   "[UnitClass]=@UnitClass,[UnitPrice]=@UnitPrice," +
                                                   "[NoOfUnits]=@NoOfUnits,[ClientWaitingList]=@ClientWaitingList," +
                                                   "[AvailableUnits]=@AvailableUnits,[TypeOfPayment]=@TypeOfPayment," +
                                                   "[DatePaid]=@DatePaid,[DateOfContractStart]=@DateOfContractStart," +
                                                   "[DateOfContractEnd]=@DateOfContractEnd,[AmountDeposit]=@AmountDeposit," +
                                                   "[AmountOwed]=@AmountOwed,[AmountPaid]=@AmountPaid,[ClientCurrentTotal]=@ClientCurrentTotal," +
                                                   "[UnitLeased]=@UnitLeased WHERE " +
                                         "[ClientID] = '{0}'", LeaseUnit.Client.idNumber);
                SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, _sqlCon); // setup command
                SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                {
                           new SQLiteParameter("@ClientID",DbType.String),
                        new SQLiteParameter("@ClientName",DbType.String),
                        new SQLiteParameter("@ClientSurname", DbType.String),
                        new SQLiteParameter("@UnitID", DbType.String),
                        new SQLiteParameter("@UnitClass",DbType.String),
                        new SQLiteParameter("@UnitPrice",DbType.String),
                        new SQLiteParameter("@NoOfUnits",DbType.String),
                        new SQLiteParameter("@ClientWaitingList",DbType.String),
                        new SQLiteParameter("@AvailableUnits",DbType.String),
                        new SQLiteParameter("@TypeOfPayment",DbType.String),
                        new SQLiteParameter("@DatePaid",DbType.String),
                        new SQLiteParameter("@DateOfContractStart",DbType.String),
                        new SQLiteParameter("@DateOfContractEnd",DbType.Int16),
                        new SQLiteParameter("@AmountDeposit",DbType.String),
                        new SQLiteParameter("@AmountOwed", DbType.String),
                        new SQLiteParameter("@AmountPaid", DbType.String),
                        new SQLiteParameter("@ClientCurrentTotal", DbType.String),
                        new SQLiteParameter("@UnitLeased", DbType.Int16),

                };
                sqlParams[0].Value = LeaseUnit.Client.idNumber; // Populate SQLiteParameters from Client
                sqlParams[1].Value = LeaseUnit.Client.FirstName;
                sqlParams[2].Value = LeaseUnit.Client.LastName;
                sqlParams[3].Value = LeaseUnit.StorageUnit.UnitId;
                sqlParams[4].Value = LeaseUnit.StorageUnit.UnitClassification;
                sqlParams[5].Value = LeaseUnit.StorageUnit.UnitPrice;
                sqlParams[6].Value = LeaseUnit.NoOfUnits;
                sqlParams[7].Value = LeaseUnit.ClientWaitingList;
                sqlParams[8].Value = LeaseUnit.AvailableUnits;
                sqlParams[9].Value = LeaseUnit.TypeOfPayment;
                sqlParams[10].Value = LeaseUnit.DateOfPayment;
                sqlParams[11].Value = LeaseUnit.DateOfContractStart;
                sqlParams[12].Value = LeaseUnit.DateOfContractEnd;
                sqlParams[13].Value = LeaseUnit.AmountDeposited;
                sqlParams[14].Value = LeaseUnit.AmountOwed;
                sqlParams[15].Value = LeaseUnit.AmountPaid;
                sqlParams[16].Value = LeaseUnit.ClientCurrentTotal;
                sqlParams[17].Value = LeaseUnit.UnitLeased ? 1 : 0;// ? 1 : 0 Converts Boolean to Int16 for Database Storage 
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
            //Purpose     : Try to delete a row from the Client datastore
            //Re-use      : None
            //Input       : string ID
            //              - the ID of the Client to delete in the Client datastore
            //Output      : - int
            //                0 : Client found and deleted successfully
            //               -1 : Client not deleted because the record was not found
            //
            int rc = 0;  // will be returned, thus can not be declared in try block

            try
            {
                int rowsAffected = 0;

                _sqlCon = new SQLiteConnection(_conStr); // New connection
                _sqlCon.Open(); // Open connection
                string deleteQuery = string.Format("DELETE FROM LeaseUnits WHERE [ClientID] = '{0}'", ID);
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
            //Purpose     : Determines if a given Client exists in the Client datastore.
            //Re-use      : None
            //Input       : string ID
            //              - the ID of the Client to search in the Client datastore
            //Output      : - bool
            //                true : Client found
            //               false : Client not found
            //
            bool rc = false;  // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr); // new connection
                bool bRead = false;

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM LeaseUnits WHERE [ClientID] = '" + ID + "'";
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