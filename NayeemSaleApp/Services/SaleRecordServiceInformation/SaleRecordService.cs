using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NayeemSaleApp.Areas.Sale.Models;
using NayeemSaleApp.Data.Entity.SaleRecordEntity;
using NayeemSaleApp.Services.SaleRecordServiceInformation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Services.SaleRecordServiceInformation
{
    public class SaleRecordService : ISaleRecordService
    {
        private readonly string _connectionString;

        public SaleRecordService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbConnection");
        }

        public async Task<IEnumerable<SaleRecord>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetAllSaleRecord", sql))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<SaleRecord>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToSaleRecord(reader));
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

        private SaleRecord MapToSaleRecord(SqlDataReader reader)
        {
            try
            {
                return new SaleRecord()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    rate = Convert.ToInt32(reader["rate"]),
                    quantity = Convert.ToInt32(reader["quantity"]),
                    billDate = Convert.ToDateTime(reader["billDate"]),
                    boucherNumber = reader["boucherNumber"].ToString()
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CustomerBillSummary>> GetSellSummary()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetSaleCustomerSummary", sql))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<CustomerBillSummary>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToCustomerBillSummary(reader));
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
        private CustomerBillSummary MapToCustomerBillSummary(SqlDataReader reader)
        {
            try
            {
                return new CustomerBillSummary()
                {
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    customerName = reader["customerName"].ToString(),
                    contactNumber = reader["contactNumber"].ToString(),
                    grandTotal = Convert.ToDecimal(reader["grandTotal"]),
                    totalReceive = Convert.ToDecimal(reader["totalReceive"]),
                    totalDue = Convert.ToDecimal(reader["totalDue"])
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public async Task<SaleRecord> GetById(int? Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetSaleRecordById", sql))
                {

                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
                        SaleRecord response = null;
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToSaleRecord(reader);
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

        public async Task<bool> Insert(SaleRecord model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertSaleRecord", con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ProductId", model.ProductId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", model.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@rate", model.rate));
                        cmd.Parameters.Add(new SqlParameter("@quantity", model.quantity));
                        cmd.Parameters.Add(new SqlParameter("@billDate", model.billDate));
                        cmd.Parameters.Add(new SqlParameter("@boucherNumber", model.boucherNumber));
                        cmd.Parameters.Add(new SqlParameter("@createdAt", DateTime.Now));
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

        public async Task<bool> Update(SaleRecord model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_UpdateSaleRecord", con))
                {
                    try
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
                        cmd.Parameters.Add(new SqlParameter("@ProductId", model.ProductId));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", model.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@rate", model.rate));
                        cmd.Parameters.Add(new SqlParameter("@quantity", model.quantity));
                        cmd.Parameters.Add(new SqlParameter("@billDate", model.billDate));
                        cmd.Parameters.Add(new SqlParameter("@boucherNumber", model.boucherNumber));
                        cmd.Parameters.Add(new SqlParameter("@createdAt", DateTime.Now));
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
                    using (SqlCommand cmd = new SqlCommand("Sp_DeleteSaleRecord", con))
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
