using System;
using MySql.Data.MySqlClient;


namespace Test.TestCS
{
    internal class Hello
    {

        static void Main(String[] args) {

            Console.WriteLine("hello");
            MySqlOp();
            Console.ReadKey();
        }
        //数据库操作
        static void MySqlOp()
        {
            //MySQL连接字符串
            string conStr = "server=localhost;port=3307;user =root;password=root;database=student_manage_system";
            //MySQL连接对象
            MySqlConnection con = new MySqlConnection(conStr);
            //MySQL命令对象
            MySqlCommand cmd = null;
            try
            {
                con.Open();
                //查询操作
                string queryStr = "select * from course_information;";
                cmd = new MySqlCommand(queryStr, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                //遍历读出的dr的数据
                while (dr.Read())
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(dr[j].ToString() + "  ");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("操作错误！");
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

    }
}