//using NayeemSaleApp.Data;
//using NayeemSaleApp.Data.Entity;
//using NayeemSaleApp.Services.CategoryServiceInformation.Interfaces;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace NayeemSaleApp.Services.CategoryServiceInformation
//{
//    public class CategoryService: ICategoryService
//    {
//        private readonly string _connectionString;

//        public CategoryService(IConfiguration configuration)
//        {
//            _connectionString = configuration.GetConnectionString("AppDbConnection");
//        }

//        public async Task<IEnumerable<Category>> GetAll()
//        {
//            using (SqlConnection sql = new SqlConnection(_connectionString))
//            {
//                using (SqlCommand cmd = new SqlCommand("Sp_GetAllCategory", sql))
//                {
//                    try
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        var response = new List<Category>();
//                        await sql.OpenAsync();

//                        using (var reader = await cmd.ExecuteReaderAsync())
//                        {
//                            while (await reader.ReadAsync())
//                            {
//                                response.Add(MapToCategory(reader));
//                            }
//                        }

//                        return response;
//                    }
//                    catch (System.Exception)
//                    {

//                        throw;
//                    }
//                }
//            }
//        }

//        private Category MapToCategory(SqlDataReader reader)
//        {
//            try
//            {
//                return new Category()
//                {
//                    Id = (int)reader["Id"],
//                    CategoryName = reader["CategoryName"].ToString(),
//                };
//            }
//            catch (System.Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<Category> GetById(int? Id)
//        {
//            using (SqlConnection sql = new SqlConnection(_connectionString))
//            {
//                using (SqlCommand cmd = new SqlCommand("Sp_GetCategoryById", sql))
//                {
                   
//                    try
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
//                        Category response = null;
//                        await sql.OpenAsync();

//                        using (var reader = await cmd.ExecuteReaderAsync())
//                        {
//                            while (await reader.ReadAsync())
//                            {
//                                response = MapToCategory(reader);
//                            }
//                        }
//                        return response;
//                    }
//                    catch (System.Exception)
//                    {
                        
//                        throw;
//                    }
//                }
//            }
//        }

//        public async Task<bool> Insert(Category model)
//        {
//            using (SqlConnection con = new SqlConnection(_connectionString))
//            {
//                using (SqlCommand cmd = new SqlCommand("Sp_InsertCategory", con))
//                {
//                    try
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        //cmd.Parameters.Add(new SqlParameter("@Id", model.CategoryId));
//                        cmd.Parameters.Add(new SqlParameter("@CategoryName", model.CategoryName));
//                        await con.OpenAsync();
//                        await cmd.ExecuteNonQueryAsync();
//                        return true;
//                    }
//                    catch (System.Exception)
//                    {
//                        throw;
//                    }
//                }
//            }
//        }

//        public async Task<bool> Update(Category model)
//        {
//            using (SqlConnection con = new SqlConnection(_connectionString))
//            {
//                using (SqlCommand cmd = new SqlCommand("Sp_UpdateCategory", con))
//                {
//                    try
//                    {

//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
//                        cmd.Parameters.Add(new SqlParameter("@CategoryName", model.CategoryName));
//                        await con.OpenAsync();
//                        await cmd.ExecuteNonQueryAsync();
//                        return true;
//                    }
//                    catch (System.Exception)
//                    {
//                        throw;
//                    }
//                }
//            }
//        }


//        public async Task<bool> DeleteById(int? Id)
//        {
//            using (SqlConnection con = new SqlConnection(_connectionString))
//            {
//                try
//                {
//                    using (SqlCommand cmd = new SqlCommand("Sp_DeleteCategory", con))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
//                        await con.OpenAsync();
//                        await cmd.ExecuteNonQueryAsync();
//                        return true;
//                    }
//                }
//                catch (System.Exception)
//                {
//                    return false;
//                    throw;
//                }
//            }
//        }
//    }
//}
