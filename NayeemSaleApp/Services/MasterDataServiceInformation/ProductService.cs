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
    public class ProductService : IProductService
    {
        private readonly string _connectionString;

        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbConnection");
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetAllProduct", sql))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<Product>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToProduct(reader));
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

        private Product MapToProduct(SqlDataReader reader)
        {
            try
            {
                return new Product()
                {
                    Id = (int)reader["Id"],
                    productName = reader["productName"].ToString(),
                    productCode = reader["productCode"].ToString(),
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetById(int? Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetProductById", sql))
                {

                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
                        Product response = null;
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToProduct(reader);
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

        public async Task<bool> Insert(Product model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_InsertProduct", con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new SqlParameter("@Id", model.ProductId));
                        cmd.Parameters.Add(new SqlParameter("@productName", model.productName));
                        cmd.Parameters.Add(new SqlParameter("@productCode", model.productCode));
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

        public async Task<bool> Update(Product model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_UpdateProduct", con))
                {
                    try
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
                        cmd.Parameters.Add(new SqlParameter("@productName", model.productName));
                        cmd.Parameters.Add(new SqlParameter("@productCode", model.productCode));
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
                    using (SqlCommand cmd = new SqlCommand("Sp_DeleteProduct", con))
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
