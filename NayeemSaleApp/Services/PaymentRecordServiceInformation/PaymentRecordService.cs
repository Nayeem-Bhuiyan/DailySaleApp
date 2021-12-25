using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NayeemSaleApp.Data.Entity.PaymentRecordEntity;
using NayeemSaleApp.Services.PaymentRecordServiceInformation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Services.PaymentRecordServiceInformation
{

    public class PaymentRecordService : IPaymentRecordService
    {
        private readonly string _connectionString;

        public PaymentRecordService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbConnection");
        }

        public async Task<IEnumerable<PaymentRecord>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetAllPaymentRecord", sql))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<PaymentRecord>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToPaymentRecord(reader));
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

        private PaymentRecord MapToPaymentRecord(SqlDataReader reader)
        {
            try
            {
                return new PaymentRecord()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    grossAmount = Convert.ToInt32(reader["grossAmount"]),
                    discountAmount = Convert.ToInt32(reader["discountAmount"]),
                    vatAmount = Convert.ToInt32(reader["vatAmount"]),
                    receiveTotal = Convert.ToInt32(reader["receiveTotal"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    payType = Convert.ToInt32(reader["payType"]),
                    remarks = reader["remarks"].ToString()
                };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<PaymentRecord> GetById(int? Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetPaymentRecordById", sql))
                {

                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", Id));
                        PaymentRecord response = null;
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToPaymentRecord(reader);
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

        public async Task<bool> Insert(PaymentRecord model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPaymentRecord", con))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@grossAmount", model.grossAmount));
                        cmd.Parameters.Add(new SqlParameter("@discountAmount", model.discountAmount));
                        cmd.Parameters.Add(new SqlParameter("@vatAmount", model.vatAmount));
                        cmd.Parameters.Add(new SqlParameter("@receiveTotal", model.receiveTotal));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", model.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@payType", model.payType));
                        cmd.Parameters.Add(new SqlParameter("@remarks", model.remarks));
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

        public async Task<bool> Update(PaymentRecord model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_UpdatePaymentRecord", con))
                {
                    try
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@grossAmount", model.grossAmount));
                        cmd.Parameters.Add(new SqlParameter("@discountAmount", model.discountAmount));
                        cmd.Parameters.Add(new SqlParameter("@vatAmount", model.vatAmount));
                        cmd.Parameters.Add(new SqlParameter("@receiveTotal", model.receiveTotal));
                        cmd.Parameters.Add(new SqlParameter("@CustomerId", model.CustomerId));
                        cmd.Parameters.Add(new SqlParameter("@payType", model.payType));
                        cmd.Parameters.Add(new SqlParameter("@remarks", model.remarks));
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
                    using (SqlCommand cmd = new SqlCommand("Sp_DeletePaymentRecord", con))
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
