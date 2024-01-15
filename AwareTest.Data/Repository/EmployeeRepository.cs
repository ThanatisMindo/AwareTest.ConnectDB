using AwareTest.Data.IRepository;
using AwareTest.Model.Model;
using AwareTest.Model.Model.SqlModel;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace AwareTest.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppSettingsModel _appSettings;
        public EmployeeRepository(IOptions<AppSettingsModel> appSetting)
        {
            _appSettings = appSetting.Value;
        }

        public List<EmployeeModel> Select()
        {
            var result = new List<EmployeeModel>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = _appSettings.ServerName;
                builder.InitialCatalog = _appSettings.DatabaseName;
                builder.IntegratedSecurity = true;
                builder.TrustServerCertificate = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Employees";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(ToDataModel(reader));
                            }
                            reader.Close();

                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }
        private EmployeeModel ToDataModel(SqlDataReader reader)
        {
            var model = new EmployeeModel();
            model.EmployeeId = Convert.ToInt32(reader["EmployeeId"] == DBNull.Value ? null : reader["EmployeeId"]);
            model.FirstName = reader["FirstName"] == DBNull.Value ? null : Convert.ToString(reader["FirstName"]);
            model.LastName = reader["LastName"] == DBNull.Value ? null : Convert.ToString(reader["LastName"]);
            model.Title = reader["Title"] == DBNull.Value ? null : Convert.ToString(reader["Title"]);
            model.TitleOfCourtesy = reader["TitleOfCourtesy"] == DBNull.Value ? null : Convert.ToString(reader["TitleOfCourtesy"]);
            model.BirthDate = Convert.ToDateTime(reader["BirthDate"] == DBNull.Value ? null : reader["BirthDate"]);
            model.HireDate = Convert.ToDateTime(reader["HireDate"] == DBNull.Value ? null : reader["HireDate"]);
            model.Address = reader["Address"] == DBNull.Value ? null : Convert.ToString(reader["Address"]);
            model.City = reader["City"] == DBNull.Value ? null : Convert.ToString(reader["City"]);
            model.Region = reader["Region"] == DBNull.Value ? null : Convert.ToString(reader["Region"]);
            model.PostalCode = reader["PostalCode"] == DBNull.Value ? null : Convert.ToString(reader["PostalCode"]);
            model.Country = reader["Country"] == DBNull.Value ? null : Convert.ToString(reader["Country"]);
            model.HomePhone = reader["HomePhone"] == DBNull.Value ? null : Convert.ToString(reader["HomePhone"]);
            model.Extension = reader["Extension"] == DBNull.Value ? null : Convert.ToString(reader["Extension"]);
            model.Photo = (byte[])(reader["Photo"] == DBNull.Value ? null : reader["Photo"]);
            model.Notes = reader["Notes"] == DBNull.Value ? null : Convert.ToString(reader["Notes"]);
            model.PhotoPath = reader["PhotoPath"] == DBNull.Value ? null : Convert.ToString(reader["PhotoPath"]);
            model.ReportsTo = Convert.ToInt32(reader["ReportsTo"] == DBNull.Value ? null : reader["ReportsTo"]);
            return model;
        }

    }
}
