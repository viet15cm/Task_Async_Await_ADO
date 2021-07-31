using Async_Await.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await.ClassMethol
{
    class GetData
    {
        public static Task<List<Teacher>> GetDataTeacher()
        {

            Task<List<Teacher>> task = new Task<List<Teacher>>(() => {
                try

                {
                    List<Teacher> teacher = new List<Teacher>();
                    using (SqlConnection connection = new SqlConnection(DataSource.Intances().GetDataSourceSever()))

                    using (SqlCommand command = new SqlCommand

                           ("SELECT * FROM dbo.teachers;", connection))

                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())

                        {

                            while (reader.Read())

                            {

                                var tc = new Teacher();

                                tc.Id = reader.GetGuid(0);
                                tc.Name = reader.GetString(1);
                                tc.Age = reader.GetInt32(2);
                                tc.Chairman = true; 
                                teacher.Add(tc);

                            }

                        }

                    }

                    Console.WriteLine("Mo va dong co so du lieu thanh cong.");

                    foreach (Teacher tc in teacher)
                    {
                        
                        
                        string sFormat = String.Format("Id:{0} Name: {1} Age: {2} :",

                                         tc.Id, tc.Name, tc.Age);

                        Console.WriteLine(sFormat);

                    }

                    return teacher;
                }

                catch (Exception ex)

                {

                    Console.WriteLine("Loi khi mo  ket noi:" + ex.Message);
                   
                }

                return null ;
            });
            task.Start();
            return task;
        }

        public static Task GetDataStudents()
        {

            Task task = new Task(() => {
                try

                {

                    List<Student> students = new List<Student>();



                    using (SqlConnection connection = new SqlConnection(DataSource.Intances().GetDataSourceSever()))

                    using (SqlCommand command = new SqlCommand

                           ("SELECT * FROM dbo.students;", connection))

                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())

                        {

                            while (reader.Read())

                            {

                                var tc = new Student();

                                tc.Id = reader.GetGuid(0);
                                tc.Name = reader.GetString(1);
                                tc.Age = reader.GetInt32(2);
                                tc.Gender = true;
                                tc.TeacherId = reader.GetGuid(4);
                                students.Add(tc);

                            }

                        }

                    }

                    Console.WriteLine("Mo va dong co so du lieu thanh cong.");

                    foreach (Student tc in students)
                    {

                       
                        string sFormat = String.Format("Id:{0} Name: {1} Age: {2} Gender {3} TeacherId {4} :",

                                         tc.Id, tc.Name, tc.Age, tc.Gender, tc.TeacherId);
                        

                        Console.WriteLine(sFormat);

                    }

                }

                catch (Exception ex)

                {

                    Console.WriteLine("Loi khi mo  ket noi:" + ex.Message);

                }


            });
            task.Start();
            return task;
        }


        public static void Run()
        {
           GetDataStudents();
            
           GetDataTeacher();

        }
    }
}
