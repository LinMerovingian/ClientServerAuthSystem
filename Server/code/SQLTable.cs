using System;
using System.Collections.Generic;

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
    public class SQLTable
    {
        public sqliteConnection m_Connection;
        public String m_TableName;
        String m_TableColumns;
        
        public SQLTable(sqliteConnection connection, String tableName, String tableColumns, bool createNew)
        {
            m_Connection = connection;
            m_TableName = tableName;
            m_TableColumns = tableColumns;

            if (createNew)
            {
                sqliteCommand command = new sqliteCommand("create table " + m_TableName + " (" + m_TableColumns + ")", m_Connection);

                command.Parameters.Add("@name", System.Data.DbType.String).Value = m_TableName;
                command.ExecuteNonQuery();
            }
        }
        
        public String getName()
        {
            return m_TableName;
        }
        
        public bool queryExists(String query, String field)
        {
            sqliteCommand command = new sqliteCommand("select * from " + m_TableName + " where " + field + " = @query", m_Connection);

            command.Parameters.Add("@query", System.Data.DbType.String).Value = query;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            sqliteDataReader reader = command.ExecuteReader();

            return reader.HasRows;
        }

        /*
         * Returns true if the query exists in the field in this table for entry name in column Name
         */
        public bool queryOtherFieldFromName(String name, String query, String field)
        {
            sqliteCommand command = new sqliteCommand("select " + field + " from " + m_TableName + " where name = @name", m_Connection);

            command.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            sqliteDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                if (reader[field].ToString() == query)
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Returns the string found at the field column for 'name' name
         */
        public String getStringFieldFromName(String name, String field)
        {
            sqliteCommand command = new sqliteCommand("select " + field + " from " + m_TableName + " where name = @name", m_Connection);

            command.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            sqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                String Debug = reader[field].ToString();
                return reader[field].ToString();
            }
            return null;
        }

        /*
         * Returns the int found at the field column for 'name' name
         */
        public int getIntFieldFromName(String name, String field)
        {
            sqliteCommand command = new sqliteCommand("select " + field + " from " + m_TableName + " where name = @name", m_Connection);

            command.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            sqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (int.TryParse(reader[field].ToString(), out int j))
                    {
                        return j;
                    }
                }
            }
            return -1;
        }

        /*
         * Returns the string found at the field column for 'id' id
         */
        public String getStringFieldFromId(int id, String field)
        {
            sqliteCommand command = new sqliteCommand("select " + field + " from " + m_TableName + " where id = @id", m_Connection);

            command.Parameters.Add("@id", System.Data.DbType.UInt32).Value = id;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            sqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return reader[field].ToString();
            }
            return null;
        }

        /*
         * Returns all the names of entrys where the field == query
         */
        public List<String> getNamesFromField(String field, String query)
        {
            List<String> returnList = new List<string>();

            try
            {
                sqliteCommand command = new sqliteCommand("select name from " + m_TableName + " where " + field + " = @query", m_Connection);

                command.Parameters.Add("@query", System.Data.DbType.String).Value = query;
                command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

                sqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    returnList.Add(reader["name"].ToString());
                }
            }
            catch { }

            return returnList;
        }

        /*
         * Returns all the names of entrys where the field == query for two queries
         */
        public List<String> getNamesFromTwoFields(String fieldOne, String queryOne, String fieldTwo, String queryTwo)
        {
            List<String> returnList = new List<string>();

            try
            {
                sqliteCommand command = new sqliteCommand("select name from " + m_TableName + " where " + fieldOne + " = @query1 and " + fieldTwo + " = @query2", m_Connection);

                command.Parameters.Add("@query1", System.Data.DbType.String).Value = queryOne;
                command.Parameters.Add("@query2", System.Data.DbType.String).Value = queryTwo;
                command.Parameters.Add("@field1", System.Data.DbType.String).Value = fieldOne;
                command.Parameters.Add("@field2", System.Data.DbType.String).Value = fieldTwo;

                sqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    returnList.Add(reader["name"].ToString());
                }
            } catch { }
            return returnList;
        }

        /*
         * Sets the field with the String data for the entry where 'name' == name
         */
        public void setFieldFromName(String name, String data, String field)
        {
            sqliteCommand command = new sqliteCommand("update " + m_TableName + " set " + field + " = @data where name = @name", m_Connection);

            command.Parameters.Add("@data", System.Data.DbType.String).Value = data;
            command.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            command.ExecuteNonQuery();
        }

        /*
         * Sets the field with the int data for the entry where 'name' == name
         */
        public void setFieldFromName(String name, int data, String field)
        {
            sqliteCommand command = new sqliteCommand("update " + m_TableName + " set " + field + " = @data where name = @name", m_Connection);

            command.Parameters.Add("@data", System.Data.DbType.Int32).Value = data;
            command.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            command.ExecuteNonQuery();
        }

        /*
         * Sets the field with the String data for the entry where 'id' == id
         */
        public void setFieldFromID(int id, String data, String field)
        {
            sqliteCommand command = new sqliteCommand("update " + m_TableName + " set " + field + " = @data where id = @id", m_Connection);

            command.Parameters.Add("@id", System.Data.DbType.UInt32).Value = id;
            command.Parameters.Add("@data", System.Data.DbType.String).Value = data;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            command.ExecuteNonQuery();
        }

        /*
         * Sets the field with the int data for the entry where 'id' == id
         */
        public void setFieldFromID(int id, int data, String field)
        {
            sqliteCommand command = new sqliteCommand("update " + m_TableName + " set " + field + " = @data where id = @id", m_Connection);

            command.Parameters.Add("@id", System.Data.DbType.UInt32).Value = id;
            command.Parameters.Add("@data", System.Data.DbType.UInt32).Value = data;
            command.Parameters.Add("@field", System.Data.DbType.String).Value = field;

            command.ExecuteNonQuery();
        }
        public virtual void AddEntry(string[] dataArray) { }
    }
    public class LoginTable : SQLTable
    {
        public LoginTable(sqliteConnection connection, String tableName, String tableColumns, bool createNew) : base(connection, tableName, tableColumns, createNew) { }
        
        public override void AddEntry(string[] dataArray)
        {
            try
            {
                sqliteCommand command = new sqliteCommand("insert into " + m_TableName + " values (@name, @password, @salt, @isLoggedIn, @id)", m_Connection);

                command.Parameters.Add("@name", System.Data.DbType.String).Value = dataArray[0];
                command.Parameters.Add("@password", System.Data.DbType.String).Value = dataArray[1];
                command.Parameters.Add("@salt", System.Data.DbType.String).Value = dataArray[2];
                command.Parameters.Add("@isLoggedIn", System.Data.DbType.String).Value = dataArray[3];
                command.Parameters.Add("@id", System.Data.DbType.UInt32).Value = dataArray[4];

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add: " + dataArray[0] + " to DB " + ex);
            }
        }
    }
    public class UsersTable : SQLTable
    {
        public UsersTable(sqliteConnection connection, String tableName, String tableColumns, bool createNew) : base(connection, tableName, tableColumns, createNew) { }
        
        public override void AddEntry(string[] dataArray)
        {
            try
            {
                sqliteCommand command = new sqliteCommand("insert into " + m_TableName + " values (@name, @id, @securityLevel)", m_Connection);

                command.Parameters.Add("@name", System.Data.DbType.String).Value = dataArray[0];
                command.Parameters.Add("@id", System.Data.DbType.UInt32).Value = dataArray[1];
                command.Parameters.Add("@securityLevel", System.Data.DbType.UInt32).Value = dataArray[2];

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add: " + dataArray[0] + " to DB " + ex);
            }
        }
    }
    
    public class IdTable : SQLTable
    {
        public IdTable(sqliteConnection connection, String tableName, String tableColumns, bool createNew) : base(connection, tableName, tableColumns, createNew) { }
        
        public void AddIDEntry(string name, int id)
        {
            try
            {
                sqliteCommand command = new sqliteCommand("insert into " + m_TableName + " values (@name, @id)", m_Connection);

                command.Parameters.Add("@name", System.Data.DbType.String).Value = name;
                command.Parameters.Add("@id", System.Data.DbType.Int32).Value = id;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add: " + name + " to DB " + ex);
            }
        }
    }
}

