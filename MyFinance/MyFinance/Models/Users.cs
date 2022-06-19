using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MySqlConnector;

namespace MyFinance.Models
{
    public class Users
    {

        private int id;
        private double counter;

        public Users() { }
        public Users(int id, double counter)
        {
            this.id = id;
            this.counter = counter;
        }

                private static string connStr = "server=194.87.210.23;user=Sasha2;database=autoPodbor;password=Qazx1234;";

        public static bool Registration(string login, string pass, string passConf)
        {
            List<string> logins = new List<string>();
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT login FROM users";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                logins.Add(reader[0].ToString());
            }
            conn.Close();
            if (pass != passConf || login.Length <= 5 || pass.Length < 7 || logins.Contains(login) || login.Contains("-"))
            {
                return false;
            }
            else
            {
                conn.Open();
                string sql2 = $"INSERT INTO users VALUES('0','{login}','{GetHash(pass)}','0')";
                MySqlCommand command2 = new MySqlCommand(sql2, conn);
                command2.ExecuteNonQuery();

                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                File.WriteAllText(Path.Combine(folderPath, "accountInfo"), login);
                conn.Close();
                return true;
            }


        }
        public static double CheckCounter(string login)
        {
            double counters = 0;
            try
            {
                string passSql = string.Empty;
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = $"SELECT counter FROM users WHERE login ='{login}'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    counters = Convert.ToDouble(reader[0].ToString());
                    
                }
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return  counters;
        }
        public static bool Authorization(string login, string pass)
        {
            try
            {
                string passSql = string.Empty;
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = $"SELECT * FROM users WHERE login ='{login}'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    passSql = reader[2].ToString();
                }
                conn.Close();
                if (GetHash(pass) == passSql)
                {

                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    File.WriteAllText(Path.Combine(folderPath, "accountInfo"), login);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public static void SetState(string login,double digit,int dohodOrRashod)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql1 = string.Empty;
                sql1 = $"SELECT counter FROM users WHERE login='{login}'";
                MySqlCommand command1 = new MySqlCommand(sql1, conn);
                MySqlDataReader reader = command1.ExecuteReader();

                double counter=0;

                while (reader.Read())
                {
                   counter=Convert.ToDouble(reader[0].ToString());
                }
                conn.Close();
                if (dohodOrRashod == 1) { 
                    counter -= digit;
                }
                else{ 
                    counter += digit;
                }
                MySqlConnection conn1 = new MySqlConnection(connStr);
                conn.Open();
                string sql = string.Empty;
                sql = $"UPDATE users SET counter='{counter}' WHERE login ='{login}'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader1 = command.ExecuteReader();
                conn.Close();

            }
            catch (Exception ex)
            {
                new Exception("Error Network");
                Debug.Write("-------------------------------------------------------\n CATCH!!!!!!!!!!!!!!!!!" + ex.Message);
            }
        }

        private static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }



        public int Id { get=>this.id; set=>this.id=value; }
        public double Counter { get=>this.counter; set=>this.counter=value; }


    }
}
