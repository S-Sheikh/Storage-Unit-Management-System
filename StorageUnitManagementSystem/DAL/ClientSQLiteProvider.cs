using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using StorageUnitManagementSystem.BL.Classes;

namespace ClientManagementSystem.DAL
{
    public class ClientSQLiteProvider : ClientProviderBase
    {

private string _conStr = CreateDatabase.ConStr;
        private SQLiteConnection _sqlCon;

        public override List<Client> SelectAll()
        {
            //
            //Method Name : List<Client> SelectAll()
            //Purpose     : Try to get all the Client objects from the datastore
            //Re-use      : None
            //Input       : None        
            //Output      : - ref List<Client>
            //                - the list that will contain the Client objects loaded from datastore         
            //

            List<Client> Clients; // will be returned, thus can not be declared in try block

            try
            {
                _sqlCon = new SQLiteConnection(_conStr);  // new connection
                bool bRead = false;
                Clients = new List<Client>(); // this ensures that if there are no records,
                                              // the returned list will not be null, but
                                              // it will be empty (Count = 0)

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM Clients";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read(); // Priming read (must have 2nd read in loop)
                while (bRead == true) // false indicates no more rows/records4\4
                {
                    Client Client = new Client();
                    //unit.Address = new Address();
                    //unit.Phone = new Phone();
                    Client.Address = new Address();

                    Client.idNumber = Convert.ToString(sdr["clientID"]);
                    Client.FirstName = Convert.ToString(sdr["clientFirstNames"]);
                    Client.LastName = Convert.ToString(sdr["clientLastName"]);
                    Client.DateOfBirth = Convert.ToString(sdr["clientDateOfBirth"]);
                    Client.Cellphone = Convert.ToString(sdr["clientCellphone"]);
                    Client.EMailAddress = Convert.ToString(sdr["clientEmail"]);
                    Client.Telephone = Convert.ToString(sdr["clientTelephone"]);
                    Client.Address.Line1 = Convert.ToString(sdr["clientALine1"]);
                    Client.Address.Line2 = Convert.ToString(sdr["clientALine2"]);
                    Client.Address.City = Convert.ToString(sdr["clientACity"]);
                    Client.Address.Province = Convert.ToString(sdr["clientAProvince"]);
                    Client.Address.PostalCode = Convert.ToString(sdr["clientPostalCode"]);
                    Client.Archived = (Convert.ToInt16(sdr["clientArchived"]) == 1) ? true : false;//First Converts Object to Int16 and then Int16 to Boolean Value

                    Clients.Add(Client);
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
            return Clients; // Single return
        } // end method

        public override int SelectClient(string ID, ref Client Client)
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
                Client = new Client();

                _sqlCon.Open(); // open connection
                string selectQuery = "SELECT * FROM Clients WHERE [clientID] = '" + ID + "'";
                SQLiteCommand sqlCommand = new SQLiteCommand(selectQuery, _sqlCon); // setup command
                SQLiteDataReader sdr = sqlCommand.ExecuteReader();
                bRead = sdr.Read();
                if (bRead == true) // false indicates no row/record read
                {
                    Client.idNumber = Convert.ToString(sdr["clientID"]);
                    Client.FirstName = Convert.ToString(sdr["clientFirstNames"]);
                    Client.LastName = Convert.ToString(sdr["clientLastName"]);
                    Client.DateOfBirth = Convert.ToString(sdr["clientDateOfBirth"]);
                    Client.Cellphone = Convert.ToString(sdr["clientCellphone"]);
                    Client.EMailAddress = Convert.ToString(sdr["clientEmail"]);
                    Client.Telephone = Convert.ToString(sdr["clientTelephone"]);
                    Client.Address.Line1 = Convert.ToString(sdr["clientALine1"]);
                    Client.Address.Line2 = Convert.ToString(sdr["clientALine2"]);
                    Client.Address.City = Convert.ToString(sdr["clientACity"]);
                    Client.Address.Province = Convert.ToString(sdr["clientAProvince"]);
                    Client.Address.PostalCode = Convert.ToString(sdr["clientPostalCode"]);
                    Client.Archived = (Convert.ToInt16(sdr["clientArchived"]) == 1) ? true : false;//First Converts Object to Int16 and then Int16 to Boolean Value
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


        public override int Insert(Client Client)
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

                doesExist = DoesExist(Client.idNumber);
                if (doesExist == false)
                {
                    //TO:DO 
                    _sqlCon = new SQLiteConnection(_conStr); // new connection
                    _sqlCon.Open(); // open connection
                    string insertQuery = "INSERT INTO Clients([clientID], [clientFirstNames], [clientLastName], " +
                                         "[clientDateOfBirth],[clientCellphone],[clientEmail],[clientTelephone]," +
                                         "[clientALine1],[clientALine2],[clientACity],[clientAProvince]," +
                                         "[clientPostalCode],[clientArchived] ) VALUES(" +
                                         "@clientID, @clientFirstNames, @clientLastName, @clientDateOfBirth,@clientCellphone,@clientEmail," +
                                         "@clientTelephone,@clientALine1,@clientALine2,@clientACity,@clientAProvince," +
                                         "@clientPostalCode,@clientArchived)";
                    SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, _sqlCon); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@clientID",DbType.String),
                        new SQLiteParameter("@clientFirstNames",DbType.String),
                        new SQLiteParameter("@clientLastName", DbType.String),
                        new SQLiteParameter("@clientDateOfBirth", DbType.String),
                        new SQLiteParameter("@clientCellphone",DbType.String),
                        new SQLiteParameter("@clientEmail",DbType.String),
                        new SQLiteParameter("@clientTelephone",DbType.String),
                        new SQLiteParameter("@clientALine1",DbType.String),
                        new SQLiteParameter("@clientALine2",DbType.String),
                        new SQLiteParameter("@clientACity",DbType.String),
                        new SQLiteParameter("@clientAProvince",DbType.String),
                        new SQLiteParameter("@clientPostalCode",DbType.String),
                        new SQLiteParameter("@clientArchived",DbType.Int16)

                    };
                    sqlParams[0].Value = Client.idNumber; // Populate SQLiteParameters from Client
                    sqlParams[1].Value = Client.FirstName;
                    sqlParams[2].Value = Client.LastName;
                    sqlParams[3].Value = Client.DateOfBirth;
                    sqlParams[4].Value = Client.Cellphone;
                    sqlParams[5].Value = Client.EMailAddress;
                    sqlParams[6].Value = Client.Telephone;
                    sqlParams[7].Value = Client.Address.Line1;
                    sqlParams[8].Value = Client.Address.Line2;
                    sqlParams[9].Value = Client.Address.City;
                    sqlParams[10].Value = Client.Address.Province;
                    sqlParams[11].Value = Client.Address.PostalCode;
                    sqlParams[12].Value = Client.Archived ? 1 : 0;// ? 1 : 0 Converts Boolean to Int16 for Database Storage 
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

        public override int Update(Client Client)
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
                string updateQuery = string.Format("UPDATE Clients SET [clientID]=@clientID, [clientFirstNames]=@clientFirstNames, " +
                                         "[clientLastName]=@clientLastName,[clientDateOfBirth]=@clientDateOfBirth," +
                                                   "[clientCellphone]=@clientCellphone,[clientEmail]=@clientEmail," +
                                                   "[clientTelephone]=@clientTelephone,[clientALine1]=@clientALine1," +
                                                   "[clientALine2]=@clientALine2,[clientACity]=@clientACity," +
                                                   "[clientAProvince]=@clientAProvince,[clientPostalCode]=@clientPostalCode," +
                                                   "[clientArchived]=@clientArchived WHERE " +
                                         "[clientID] = '{0}'", Client.idNumber);
                SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, _sqlCon); // setup command
                SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                {
                        new SQLiteParameter("@clientID",DbType.String),
                        new SQLiteParameter("@clientFirstNames",DbType.String),
                        new SQLiteParameter("@clientLastName", DbType.String),
                        new SQLiteParameter("@clientDateOfBirth", DbType.String),
                        new SQLiteParameter("@clientCellphone",DbType.String),
                        new SQLiteParameter("@clientEmail",DbType.String),
                        new SQLiteParameter("@clientTelephone",DbType.String),
                        new SQLiteParameter("@clientALine1",DbType.String),
                        new SQLiteParameter("@clientALine2",DbType.String),
                        new SQLiteParameter("@clientACity",DbType.String),
                        new SQLiteParameter("@clientAProvince",DbType.String),
                        new SQLiteParameter("@clientPostalCode",DbType.String),
                        new SQLiteParameter("@clientArchived",DbType.Int16)

                };
                sqlParams[0].Value = Client.idNumber; // Populate SQLiteParameters from Client
                sqlParams[1].Value = Client.FirstName;
                sqlParams[2].Value = Client.LastName;
                sqlParams[3].Value = Client.DateOfBirth;
                sqlParams[4].Value = Client.Cellphone;
                sqlParams[5].Value = Client.EMailAddress;
                sqlParams[6].Value = Client.Telephone;
                sqlParams[7].Value = Client.Address.Line1;
                sqlParams[8].Value = Client.Address.Line2;
                sqlParams[9].Value = Client.Address.City;
                sqlParams[10].Value = Client.Address.Province;
                sqlParams[11].Value = Client.Address.PostalCode;
                sqlParams[12].Value = Client.Archived ? 1 : 0;// ? 1 : 0 Converts Boolean to Int16 for Database Storage 
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
                string deleteQuery = string.Format("DELETE FROM Clients WHERE [clientID] = '{0}'", ID);
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
                string selectQuery = "SELECT * FROM Clients WHERE [clientID] = '" + ID + "'";
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
