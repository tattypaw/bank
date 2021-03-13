
using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            var conn_str =
                "Server=mysql60.hostland.ru;Database=host1323541_itstep36;Uid=host1323541_itstep;Pwd=269f43dc;";
            var connection = new MySqlConnection(conn_str);
            connection.Open();
            
            var sql = "INSERT INTO table_bank_client (fist_name, last_name, patronymic, telephone) VALUES ('Savelieva', 'Isidora', 'Sidorovna', '8(3952)606-606')";
            var command = new MySqlCommand
            {
                Connection = connection, CommandText = sql
            };
            command.CommandText = sql;
            var res = command.ExecuteNonQuery();
            if (res == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данные о клиенте не добавились");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Данные о клиенте добавились");
                Console.ResetColor();
            }
            connection.Close();
            connection.Open();
            sql = "INSERT INTO table_bank_chetvklad (table_bank_chetvklad.number, id_client, table_bank_chetvklad.sum, id_vklad, validity, table_bank_chetvklad.date) VALUES ('565642', '15', '3000000', '1', '36', '2020-02-20')";
            command.CommandText = sql;
            res = command.ExecuteNonQuery();
            if (res == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данные о вкладе не добавились");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Данные о вкладе добавились");
                Console.ResetColor();
            }
            connection.Close();
            connection.Open();
            sql = "INSERT INTO table_bank_chetcredit (table_bank_chetcredit.number, id_client, table_bank_chetcredit.sum, id_credit, validity, table_bank_chetcredit.date) VALUES ('676763', '15', '5000000', '1', '30', '2020-02-20')";
            command.CommandText = sql;
           res = command.ExecuteNonQuery();
            if (res == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данные о кредите не добавились");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Данные о кредите добавились");
                Console.ResetColor();
            }
            connection.Close();
          
            connection.Open();
            Console.WriteLine("Введите фамилию клиента: ");
            var name = Console.ReadLine();
            Console.WriteLine("Вывод информации по кредитам.");
            sql = $"SELECT fist_name, last_name, patronymic, telephone, table_bank_chetcredit.sum, table_bank_chetcredit.number FROM table_bank_client, table_bank_chetcredit WHERE table_bank_client.fist_name = '{name}' AND table_bank_chetcredit.id_client=table_bank_client.id ;";
            
            var result = command.ExecuteReader();
            
            while (result.Read())
            {
                var tempFirstName = result.GetString("fist_name");
                var tempLastName = result.GetString("last_name");
                var tempPatronymic = result.GetString("patronymic");
                var tempTelephone = result.GetString("telephone");
                var tempSum = result.GetInt32("table_bank_chetcredit.sum");
                var tempNumber = result.GetFloat("table_bank_chetcredit.number");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{tempFirstName} - {tempNumber:G}");
            }
            connection.Close();
            connection.Open();
            Console.WriteLine("Вывод информации по вкладам.");
            sql = $"SELECT fist_name, last_name, patronymic, telephone, table_bank_chetvklad.sum, table_bank_chetvklad.number FROM table_bank_client, table_bank_chetvklad WHERE table_bank_client.fist_name = '{name}' AND table_bank_chetvklad.id_client=table_bank_client.id ;";
            
            var result2 = command.ExecuteReader();
            
            while (result2.Read())
            {
                var temp2FirstName = result2.GetString("fist_name");
                var temp2LastName = result2.GetString("last_name");
                var temp2Patronymic = result2.GetString("patronymic");
                var temp2Telephone = result2.GetString("telephone");
                var temp2Sum = result2.GetInt32("table_bank_chetvklad.sum");
                var temp2Number = result2.GetFloat("table_bank_chetvklad.number");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{temp2FirstName} - {temp2Number:G}");
            }
            Console.ResetColor();
            connection.Close();
            
        }
    }
}