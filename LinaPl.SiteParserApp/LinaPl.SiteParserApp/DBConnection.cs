using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinaPl.SiteParserApp
{
    class DBConnection
    {
        static SQLiteConnection conn = new SQLiteConnection();
        private static string _fileData { get; set; } = "D:\\Projects\\FilmDB.db";

        private static bool _isConnected;


        public static bool IsConnected
        {
            get => _isConnected;
            private set { _isConnected = value; }
        }


        public static void AddConnection()
        {
            conn.ConnectionString = @"Data Source=" + _fileData + ";New=True;Version=3";
            conn.Open();
            if (conn != null)
            {
                IsConnected = true;
            }
        }

        public static void AddDB(string nameFilm, string extract, string description)
        {
            if (IsConnected)
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO FilmsInfo (NameFilm, Extract, Description) values (@name, @ext, @desc)", conn);
                cmd.Parameters.AddWithValue("@name", nameFilm);
                cmd.Parameters.AddWithValue("@ext", extract);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CLoseConnection()
        {
            if (IsConnected)
            {
                conn.Close();
            }
            IsConnected = false;
        }

        public static bool KeyExist(string nameFilm)
        {
            bool validValue;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM FilmsInfo WHERE NameFilm=@NameFilm", conn);
            com.Parameters.AddWithValue("@NameFilm", nameFilm);
            com.ExecuteNonQuery();
            using (SQLiteDataReader dataReader = com.ExecuteReader())
            {
                validValue = dataReader.Read();
            }

            return validValue;
        }
    }
}
