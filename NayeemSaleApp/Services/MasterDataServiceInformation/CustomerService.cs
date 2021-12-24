using NayeemSaleApp.Data;
using NayeemSaleApp.Data.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using NayeemSaleApp.Data.Entity.MasterDataEntity;
using NayeemSaleApp.Services.MasterDataServiceInformation.Interfaces;

namespace NayeemSaleApp.Services.MasterDataServiceInformation
{
    public class CustomerService: ICustomerService
    {
        private readonly string _connectionString;

        public CustomerService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbConnection");
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetAllCustomer", sql))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<Customer>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToCustomer(reader));
                            }
                        }

                        return response;
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private Customer MapToCustomer(SqlDataReader reader)
        {
            try
            {
                return new Customer()
                {
                    Id = (int)reader["Id"],
                    customerName = reader["customerName"].ToString(),
                    contactNumber = reader["contactNumber"].ToString(),
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Customer> GetById(int? Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetCustomerById", sql))
                {

                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
                        Customer response = null;
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToCustomer(reader);
                            }
                        }
                        return response;
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public async Task<bool> Insert(Customer model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_InsertCustomer", con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@customerName", model.customerName));
                        cmd.Parameters.Add(new SqlParameter("@contactNumber", model.contactNumber));
                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<bool> Update(Customer model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_UpdateCustomer", con))
                {
                    try
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
                        cmd.Parameters.Add(new SqlParameter("@customerName", model.customerName));
                        cmd.Parameters.Add(new SqlParameter("@contactNumber", model.contactNumber));
                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            }
        }


        public async Task<bool> DeleteById(int? Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_DeleteCustomer", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
        }
    }
}
