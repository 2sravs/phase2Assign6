using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConAppAssign
//{
//    internal class Program
//    {
//        static SqlDataReader reader;
//        static SqlCommand cmd;
//        static SqlConnection con;
//        static string conStr = "server=SRAVS;database=ProductInvetory1Db;trusted_connection=true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conStr);
//                cmd = new SqlCommand("select * from Prds", con);
//                con.Open();
//                reader = cmd.ExecuteReader();
//                Console.WriteLine("Products ID \t Product Name \t Products Price \t Products quantity \t Manufactoring date \tExpiry date");
//                while (reader.Read())
//                {
//                    Console.WriteLine(reader["PId"] + "\t\t");
//                    Console.WriteLine(reader["Pname"] + "\t\t");
//                    Console.WriteLine(reader["PPrice"] + "\t\t");
//                    Console.WriteLine(reader["PQty"] + "\t\t");
//                    Console.WriteLine(reader["MfDate"] + "\t");
//                    Console.WriteLine(reader["ExpDate"] + "\t");

//                    Console.WriteLine("\n");
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                Console.ReadKey();
//            }
//        }
//   
//
namespace ConAppAssign
{
    internal class program
    {
        static SqlDataReader reader;
        static SqlCommand cmd;
        static SqlConnection con;
        static string conStr = "server=SRAVS;database=ProductInvetory1DB;trusted_connection=true;";
        static void Main(string[] args)
        {            
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand();
            start:
                Console.WriteLine("1.View Products 2.Add New Product 3.Update Product Quantity 4.Remove Product \nEnter your choice: ");
                int options = int.Parse(Console.ReadLine());

                switch (options)
                {
                    case 1:
                        {
                            ViewProductInventory();
                            break;
                        }
                    case 2:
                        {
                            AddNewProduct();
                            break;
                        }
                    case 3:
                        {
                            UpdateProductQuantity();
                            break;
                        }
                    case 4:
                        {
                            RemoveProduct();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            return;
                        }
                }
                Console.WriteLine("Do you want to continue? Y/N");
                string ch = Console.ReadLine().ToLower();
                if (ch == "y")
                {
                    goto start;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        static void ViewProductInventory()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Prds";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("ID: " + reader["PId"]);
                Console.WriteLine("Product Name: " + reader["PName"]);
                Console.WriteLine("Price: " + reader["PPrice"]);
                Console.WriteLine("Quantity: " + reader["PQty"]);
                Console.WriteLine("Manufactured Date: " + reader["MfDate"]);
                Console.WriteLine("Expiration Date: " + reader["ExpDate"]);
                Console.WriteLine("*********************************************");
            }
            con.Close();
        }
        static void AddNewProduct()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Prds values (@pid,@pname,@price,@quantity,@mfdate,@expdate)";
            Console.WriteLine("Enter Product Id: ");
            cmd.Parameters.AddWithValue("@pid", int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Product Name: ");
            cmd.Parameters.AddWithValue("@pname", Console.ReadLine());
            Console.WriteLine("Enter Product Price: ");
            cmd.Parameters.AddWithValue("@price", double.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Product Quantity: ");
            cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Product Manufacturing Date: ");
            cmd.Parameters.AddWithValue("@mfdate", Console.ReadLine());
            Console.WriteLine("Enter Product Expiration Date: ");
            cmd.Parameters.AddWithValue("@expdate", Console.ReadLine());
            int num = cmd.ExecuteNonQuery();
            if (num >= 1)
            {
                Console.WriteLine("Product inserted!!");
            }
            con.Close();
        }
        static void UpdateProductQuantity()
        {
            int PId;
            Console.WriteLine("Enter Product ID to update quantity: ");
            PId = int.Parse(Console.ReadLine());
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Prds where PId=@pid";
            cmd.Parameters.AddWithValue("@pid", PId);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                con.Open();
                cmd.CommandText = "update Products set Quantity = @quantity where PId = @pid";
                Console.WriteLine("Enter new Quantity: ");
                cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Product Updated!!");
            }
            else
            {
                Console.WriteLine($"No such id {PId} exist in database");
            }
            con.Close();
        }
        static void RemoveProduct()
        {
            int rid;
            Console.WriteLine("Enter Product ID to Remove Product: ");
            rid = int.Parse(Console.ReadLine());
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Prds where PId=@rid";
            cmd.Parameters.AddWithValue("@rid", rid);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                con.Open();
                cmd.CommandText = "delete from Prds where PId = @rid";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Product Removed!!");
            }
            else
            {
                Console.WriteLine($"No such id {rid} exist in database");
            }
            con.Close();
            Console.ReadKey();
        }
       
    }
}
    
