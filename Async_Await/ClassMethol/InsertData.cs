using Async_Await.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await.ClassMethol
{
    class InsertData
    {
        public static Task<int> InsertDataTeacher(Teacher tc)
        {

            Task<int> task = new Task<int>((x) => {

                var tc = (Teacher)x;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataSource.Intances().GetDataSourceSever()))

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.teachers(Id,Name,Age,ChairMan)" +

                           "VALUES(@Id,@Name,@Age,@ChairMan)", connection))
                    {
                        command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = tc.Id;

                        object dbName = tc.Name;

                        for(int i=0; i<=10; i++)
                        {
                            Thread.Sleep(100);
                            Console.WriteLine("InsertDataTeacher");
                        }

                        if (dbName == null)

                        {

                            dbName = DBNull.Value;

                        }
                        command.Parameters.Add("Name", SqlDbType.NVarChar, 30).Value = dbName;
                        object dbAge = tc.Age;

                        if (dbAge == null)

                        {

                            dbAge = DBNull.Value;

                        }

                        command.Parameters.Add("Age", SqlDbType.Int).Value = dbAge;

                        object dbChairMan = tc.Chairman;

                        if (dbChairMan == null)

                        {

                            dbChairMan = DBNull.Value;

                        }

                        command.Parameters.Add("ChairMan", SqlDbType.Bit).Value = dbChairMan;

                        connection.Open();

                        return command.ExecuteNonQuery();

                    }

                }

                catch (Exception ex)

                {

                    Console.WriteLine("Loi khi mo  ket noi:" + ex.Message);

                    return -1;

                }

            }, tc);
            task.Start();

            return task;

        }


        public static Task<int> InsertDataStudent(Student tc)
        {

            Task<int> task = new Task<int>((x) => {

                var tc = (Student)x;

                try
                {
                    using (SqlConnection connection = new SqlConnection(DataSource.Intances().GetDataSourceSever()))

                    using (SqlCommand command = new SqlCommand("INSERT INTO dbo.students(Id,Name,Age,Gender,TeacherId)" +

                           "VALUES(@Id,@Name,@Age,@Gender,@TeacherId)", connection))
                    {
                        command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = tc.Id;

                        object dbName = tc.Name;
                        for (int i = 0; i <= 10; i++)
                        {
                            Thread.Sleep(100);
                            Console.WriteLine("InsertDataStudent");
                        }


                        if (dbName == null)

                        {

                            dbName = DBNull.Value;

                        }
                        command.Parameters.Add("Name", SqlDbType.NVarChar, 30).Value = dbName;
                        object dbAge = tc.Age;

                        if (dbAge == null)

                        {

                            dbAge = DBNull.Value;

                        }

                        command.Parameters.Add("Age", SqlDbType.Int).Value = dbAge;

                        object dbGender = tc.Gender;

                        if (dbGender == null)

                        {

                            dbGender = DBNull.Value;

                        }

                        command.Parameters.Add("Gender", SqlDbType.Bit).Value = dbGender;


                        command.Parameters.Add("TeacherId", SqlDbType.UniqueIdentifier).Value = tc.TeacherId;
                        connection.Open();

                        return command.ExecuteNonQuery();

                    }

                }

                catch (Exception ex)

                {

                    Console.WriteLine("Loi khi mo  ket noi:" + ex.Message);

                    return -1;

                }

            }, tc);
            task.Start();

            return task;

        }

        public static void Run()
        {
            var a = InsertDataStudent(new Student()
            {
                Id = Guid.NewGuid(),
                Name = "Hoai Nam",
                Age = 30,
                Gender = true,
                TeacherId = new Guid("5c39d99b-b0de-4274-a335-adfdf5d1fcfa"),

            });

           
            var f = InsertDataTeacher(new Teacher()
            {
                Id = Guid.NewGuid(),
                Name = "Lam",
                Age = 30,
                Chairman = true,


            });

            
        }

    }
}
