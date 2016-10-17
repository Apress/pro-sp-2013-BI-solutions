using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace EmployeeEntityModel.BdcModel1
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class Entity1Service
    {
        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity1</returns>
        public static Entity1 ReadItem(int id)
        {
            Entity1 entity = new Entity1();
            using (SqlConnection conn = new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=AdventureWorks2012"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("uspGetEmployeesById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BusinessEntityID", System.Data.SqlDbType.Int).Value = id;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entity.BusinessEntityID = Int32.Parse(reader[0].ToString());
                        entity.NationalIDNumber = reader.GetString(1);
                        entity.LoginID = reader.GetString(2);
                        entity.JobTitle = reader.GetString(3);
                        entity.BirthDate = DateTime.Parse(reader[4].ToString());
                        entity.MaritalStatus = char.Parse(reader[5].ToString());
                        entity.Gender = char.Parse(reader[6].ToString());
                        entity.HireDate = DateTime.Parse(reader[7].ToString());
                        entity.SalariedFlag = bool.Parse(reader[8].ToString());
                        entity.VacationHours = Int16.Parse(reader[9].ToString());
                        entity.SickLeaveHours = Int16.Parse(reader[10].ToString());
                        entity.CurrentFlag = bool.Parse(reader[11].ToString());
                        entity.ModifiedDate = DateTime.Parse(reader[12].ToString());
                    }
                }
            }
            return entity;

        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<Entity1> ReadList()
        {
            List<Entity1> entityList = new List<Entity1>();
            using (SqlConnection conn = new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=AdventureWorks2012"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("uspGetEmployees", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        entityList.Add(new Entity1
                        {
                            BusinessEntityID = Int32.Parse(reader[0].ToString()),
                            NationalIDNumber = reader.GetString(1),
                            LoginID = reader.GetString(2),
                            JobTitle = reader.GetString(3),
                            BirthDate = DateTime.Parse(reader[4].ToString()),
                            MaritalStatus = char.Parse(reader[5].ToString()),
                            Gender = char.Parse(reader[6].ToString()),
                            HireDate = DateTime.Parse(reader[7].ToString()),
                            SalariedFlag = bool.Parse(reader[8].ToString()),
                            VacationHours = Int16.Parse(reader[9].ToString()),
                            SickLeaveHours = Int16.Parse(reader[10].ToString()),
                            CurrentFlag = bool.Parse(reader[11].ToString()),
                            ModifiedDate = DateTime.Parse(reader[12].ToString())
                        });
                    }
                    reader.Close();
                }
            }
            return entityList;
        }

        public static void Update(Entity1 entity1, int parameter)
        {
            int ret = 0;
            using (SqlConnection conn = new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=AdventureWorks2012"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("uspSetEmployeesValueById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BusinessEntityID", System.Data.SqlDbType.Int).Value = parameter;
                    cmd.Parameters.Add("@NationalIDNumber", System.Data.SqlDbType.NVarChar).Value = entity1.NationalIDNumber;
                    cmd.Parameters.Add("@LoginID", System.Data.SqlDbType.NVarChar).Value = entity1.LoginID;
                    cmd.Parameters.Add("@JobTitle", System.Data.SqlDbType.NVarChar).Value = entity1.JobTitle;
                    cmd.Parameters.Add("@BirthDate", System.Data.SqlDbType.DateTime).Value = entity1.BirthDate;
                    cmd.Parameters.Add("@MaritalStatus", System.Data.SqlDbType.NChar).Value = entity1.MaritalStatus;
                    cmd.Parameters.Add("@Gender", System.Data.SqlDbType.NChar).Value = entity1.Gender;
                    cmd.Parameters.Add("@HireDate", System.Data.SqlDbType.DateTime).Value = entity1.HireDate;
                    cmd.Parameters.Add("@SalariedFlag", System.Data.SqlDbType.Bit).Value = entity1.SalariedFlag;
                    cmd.Parameters.Add("@VacationHours", System.Data.SqlDbType.SmallInt).Value = entity1.VacationHours;
                    cmd.Parameters.Add("@SickLeaveHours", System.Data.SqlDbType.SmallInt).Value = entity1.SickLeaveHours;
                    cmd.Parameters.Add("@CurrentFlag", System.Data.SqlDbType.Bit).Value = entity1.CurrentFlag;
                    cmd.Parameters.Add("@ModifiedDate", System.Data.SqlDbType.DateTime).Value = entity1.ModifiedDate;
                    ret = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
