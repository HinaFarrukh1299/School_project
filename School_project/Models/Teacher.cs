using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace School_project.Models
{
    public class Teacher
    {
private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get {return "school";
            } }
        private static string Server { get {
                return "localhost" ; } }
        private static string Port { get {return "3306"; } }

        //conecting string is a series of credentials used to connect to the database

        protected static string ConnectionString
        {
            get
            {
                return "server= " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;



            }
        }

            ///This is the method thsat we actually use to get the databae
            /// <summary>
            /// Returns a connection to the school database
            /// </summary>
            /// <returns></returns>
            public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
        }

    }
