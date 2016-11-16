﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageUnitManagementSystem.BL.Classes
{
    public class CreateDatabase
    {
        public CreateDatabase()
        {
            CreateDb();
        }

        public static string Dir { get; } = System.IO.Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "StorageUnitManagementDB.db");

        public static string ConStr { get; private set; } = "Data Source=" + Dir + ";Version=3;";
        public static SQLiteConnection SqlCon { get; private set; }

        public static void CreateTableClients()
        {
            try
            {
                SqlCon = new SQLiteConnection(ConStr);
                SqlCon.Open();

                string query = "CREATE TABLE Clients (clientID TEXT PRIMARY KEY NOT NULL,"
                  + "clientFirstNames TEXT,"
                  + "clientLastName TEXT,"
                  + "clientDateOfBirth TEXT,"
                  + "clientCellPhone	TEXT,"
                  + "clientEmail	TEXT,"
                  + "clientTelephone	TEXT,"
                  + "clientALine1 TEXT,"
                  + "clientALine2 TEXT,"
                  + "clientACity TEXT,"
                  + "clientAProvince TEXT,"
                  + "clientPostalCode TEXT ,"
                  + "clientArchived	INTEGER DEFAULT 0 ,"
                  + "unitId TEXT); ";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, SqlCon); // setup command
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();  // Close connection
            } // end finally

        }

        public static void CreateTableLeaseUnits()
        {
            try
            {
                SqlCon = new SQLiteConnection(ConStr);
                SqlCon.Open();

                string query = "CREATE TABLE LeaseUnits (LeaseID TEXT PRIMARY KEY NOT NULL,"
                  + "ClientID TEXT,"
                  + "ClientName TEXT,"
                  + "ClientSurname TEXT,"
                  + "UnitID	TEXT,"
                  + "UnitClass	TEXT,"
                  + "UnitPrice	NUMERIC DEFAULT 0,"
                  + "NoOfUnits INT DEFAULT 0,"
                  + "ClientWaitingList INT DEFAULT 0,"
                  + "AvailableUnits TEXT,"
                  + "TypeOfPayment	TEXT,"
                  + "DatePaid	TEXT,"
                  + "DateOfContractStart TEXT,"
                  + "DateOfContractEnd TEXT,"
                  + "AmountDeposited TEXT,"
                  + "AmountOwed TEXT,"
                  + "AmountPaid	TEXT,"
                  + "ClientCurrentTotal	TEXT,"
                  + "UnitLeased INT DEFAULT 0,"
                  + "ClientAdded INT DEFAULT 0,"
                  + "TotalUnitPrice	TEXT,"
                  + "UnitSize TEXT); ";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, SqlCon); // setup command
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();  // Close connection
            } // end finally
        }

        public static void CreateTableStorageUnits()
        {
            try
            {
                SqlCon = new SQLiteConnection(ConStr);
                SqlCon.Open();

                string query = "CREATE TABLE StorageUnits (suID TEXT PRIMARY KEY NOT NULL,"
                  + "suClassification TEXT,"
                  + "suPrice NUMERIC,"
                  + "suSize TEXT,"
                  + "suArrears	INT DEFAULT 0,"
                  + "suOccupied	INT DEFAULT 0,"
                  + "suAdvance	INT DEFAULT 0,"
                  + "suUpToDate INT DEFAULT 0,"
                  + "suOwnerID TEXT DEFAULT '0'); ";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, SqlCon); // setup command
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();  // Close connection
            } // end finally
        }

        public static void CreateTableUsers()
        {
            try
            {
                SqlCon = new SQLiteConnection(ConStr);
                SqlCon.Open();

                string query = "CREATE TABLE Users (UId TEXT DEFAULT '0' PRIMARY KEY NOT NULL,"
                  + "UName TEXT DEFAULT 'ADMIN',"
                  + "USurname TEXT DEFAULT 'ADMIN',"
                  + "UPassword TEXT DEFAULT 'ADMIN',"
                  + "UPosition TEXT DEFAULT 'ADMIN');";
                SQLiteCommand sqlCommand = new SQLiteCommand(query, SqlCon); // setup command
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();  // Close connection
            } // end finally
        }

        public static void CreateDb()
        {
            ConStr = "Data Source=" + Dir + ";Version=3;";
            if (!File.Exists(Dir))
            {
                SQLiteConnection.CreateFile(Dir);
                if (TableExists("Clients") == false && TableExists("StorageUnits") == false &&
                    TableExists("LeaseUnits") == false && TableExists("Users") == false)
                {
                    CreateTableClients();
                    CreateTableStorageUnits();
                    CreateTableLeaseUnits();
                    CreateTableUsers();
                    InsertUsers();
                    for (int i = 1; i < 47; i++)
                    {
                        Insert(i.ToString(), "A", 650, "3,3,3");
                    }
                    for (int i = 47; i < 68; i++)
                    {
                        Insert(i.ToString(), "B", 750, "3,5,3");
                    }
                    for (int i = 68; i < 84; i++)
                    {
                        Insert(i.ToString(), "C", 950, "3,5,5");
                    }
                    for (int i = 84; i < 95; i++)
                    {
                        Insert(i.ToString(), "D", 1150, "3,7,3");
                    }
                    for (int i = 95; i < 106; i++)
                    {
                        Insert(i.ToString(), "E", 1250, "3,7,5");
                    }
                    for (int i = 106; i < 111; i++)
                    {
                        Insert(i.ToString(), "F", 400, "5,6,4");
                    }
                }
            }
        }

        public static void Insert(string unitID, string unitClass, double unitPrice, string unitSize)
        {
            int rc = 0;
            try
            {
                int rowsAffected = 0;
                //TO:DO 
                SqlCon = new SQLiteConnection(ConStr); // new connection
                SqlCon.Open(); // open connection
                string insertQuery = "INSERT INTO StorageUnits([suID], [suClassification], [suPrice], " +
                                     "[suSize]) VALUES(" +
                                     "@suID, @suClassification, @suPrice, @suSize)";
                SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, SqlCon); // setup command
                SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                {
                    new SQLiteParameter("@suID", DbType.String),
                    new SQLiteParameter("@suClassification", DbType.String),
                    new SQLiteParameter("@suPrice", DbType.VarNumeric),
                    new SQLiteParameter("@suSize", DbType.String),
                };
                sqlParams[0].Value = unitID; // Populate SQLiteParameters from StorageUnit
                sqlParams[1].Value = unitClass;
                sqlParams[2].Value = unitPrice;
                sqlParams[3].Value = unitSize;
                sqlCommand.Parameters.AddRange(sqlParams);
                rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 1) // Test rowsAffected
                {
                    // 1 row affected, thus 1 row added to datastore, thus success
                    rc = 0;
                }
                else
                {
                    rc = -1;
                } // end if  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }

        public static void InsertUsers()
        {
            int rc = 0;
            try
            {
                int rowsAffected = 0;
                //TO:DO 
                SqlCon = new SQLiteConnection(ConStr); // new connection
                SqlCon.Open(); // open connection
                string insertQuery = "INSERT INTO Users([UId], [UName],[USurname], [UPassword], " +
                                     "[UPosition]) VALUES(" +
                                     "@UId, @UName, @USurname,@UPassword, @UPosition)";
                SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, SqlCon); // setup command
                SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                {
                    new SQLiteParameter("@UId", DbType.String),
                    new SQLiteParameter("@UName", DbType.String),
                    new SQLiteParameter("@USurname", DbType.String),
                    new SQLiteParameter("@UPassword", DbType.String),
                    new SQLiteParameter("@UPosition", DbType.String)
                };
                sqlParams[0].Value = "ADMIN"; // Populate SQLiteParameters from StorageUnit
                sqlParams[1].Value = "ADMIN";
                sqlParams[2].Value = "ADMIN";
                sqlParams[3].Value = "ADMIN";
                sqlParams[4].Value = "ADMIN";
                sqlCommand.Parameters.AddRange(sqlParams);
                rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 1) // Test rowsAffected
                {
                    // 1 row affected, thus 1 row added to datastore, thus success
                    rc = 0;
                }
                else
                {
                    rc = -1;
                } // end if  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }

        public static bool TableExists(String tableName)
        {
            bool rc = false;
            try
            {
                SqlCon = new SQLiteConnection(ConStr);
                SqlCon.Open();

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = SqlCon;
                    cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
                    cmd.Parameters.AddWithValue("@name", tableName);

                    using (SQLiteDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                            rc = true;
                        else
                            rc = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();  // Close connection
            }

            return rc;
        }
    }
}
