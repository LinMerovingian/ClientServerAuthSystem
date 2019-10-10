using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if TARGET_LINUX
using Mono.Data.Sqlite;
using sqliteConnection  = Mono.Data.Sqlite.SqliteConnection;
using sqliteCommand = Mono.Data.Sqlite.SqliteCommand;
using sqliteDataReader = Mono.Data.Sqlite.SqliteDataReader;
#endif

#if TARGET_WINDOWS
using System.Data.SQLite;
using sqliteConnection = System.Data.SQLite.SQLiteConnection;
using sqliteCommand = System.Data.SQLite.SQLiteCommand;
using sqliteDataReader = System.Data.SQLite.SQLiteDataReader;
#endif

namespace Server
{
    public class SQLDatabase
    {
        String m_DataBaseName;
        sqliteConnection m_Connection;
        List<SQLTable> m_TableList;
        
        public SQLDatabase(String dataBaseName)
        {
            m_DataBaseName = dataBaseName;
            m_TableList = new List<SQLTable>();
            CreateNew();
        }
        
        public void CreateNew()
        {
            try
            {
                sqliteConnection.CreateFile(m_DataBaseName);

                m_Connection = new sqliteConnection("Data Source=" + m_DataBaseName + ";Version=3;FailIfMissing=True");
                m_Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create DB failed: " + ex);
            }
        }
        
        public void Open()
        {
            try
            {
                m_Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open existing DB failed: " + ex);
            }
        }
        
        public LoginTable addLoginTable(String tableName, string tableColumns)
        {
            LoginTable newTable = new LoginTable(m_Connection, tableName, tableColumns);
            m_TableList.Add(newTable);
            return newTable;
        }
        
        public UsersTable addUsersTable(String tableName, string tableColumns)
        {
            UsersTable newTable = new UsersTable(m_Connection, tableName, tableColumns);
            m_TableList.Add(newTable);
            return newTable;
        }
        
        public IdTable addIDTable(String tableName, string tableColumns)
        {
            IdTable newTable = new IdTable(m_Connection, tableName, tableColumns);
            m_TableList.Add(newTable);
            return newTable;
        }
    }
}