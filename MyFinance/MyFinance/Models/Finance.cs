using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MySqlConnector;

namespace MyFinance.Models
{
    public class Finance
    {
        public int id;
        public double digit;
        public int dohodOrRashod;
        public string text;
        public string date;
        public string login;
        public string Login { get; set; }
        public int Id { get; set; }
        public double Digit { get; set; }
        public bool DohodOrRashod { get; set; }
        public string Text { get; set; }

        private static string connStr = "server=194.87.210.23;user=Sasha2;database=autoPodbor;password=Qazx1234;";

        public Finance() { }
        public Finance(int id, double digit, int dohodOrRashod, string text,string date,string login)
        {
            this.id = id;
            this.digit = digit;
            this.dohodOrRashod = dohodOrRashod;
            this.text = text;
            this.date = date;
            this.login = login;
        }


        public static bool AddFinance(double digit,string text, int dohodOrRashod)
        {
            string datestring=DateTime.Now.ToString("dd.MM.yy HH.mm.ss");
            MySqlConnection conn = new MySqlConnection(connStr);
            string login = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"));
            conn.Open();
            string sql = $"INSERT into finance VALUES ('0','{digit}','{dohodOrRashod}','{text}','{datestring}','{login}')";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            conn.Close();
            return true;
        }

        public List<Finance> ReadFinance(List<Finance> finance)
        {
            try
            {
                string connStr = "server=194.87.210.23;user=Sasha2;database=autoPodbor;password=Qazx1234;";
                MySqlConnection conn = new MySqlConnection(connStr);
                string login = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accountInfo"));
                conn.Open();
                string sql = $"SELECT * FROM finance WHERE login='{login}'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    finance.Add(new Finance(
                        Convert.ToInt32(reader[0].ToString()),
                        Convert.ToDouble(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString()

                    ));
                }
                reader.Close();
                conn.Close();
                return finance;
            }
            catch (Exception ex)
            {
                return finance;
            }


        }

        private static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

    }
}
