using FinalADS.Application.Accounts.Contracts;
using FinalADS.Application.Accounts.ViewModels;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalADS.Application.Accounts.Queries
{
    public class AccountMySQLDapperQueries : IAccountQueries
    {
        public List<AccountDto> GetListPaginated(long customerId, int page = 0, int pageSize = 5)
        {
            string sql = @"
                    SELECT 
                        a.account_id AS id,
                        a.number,
                        a.balance,
                        a.locked
                    FROM 
                        account a
                    where
                        a.customer_id = @CustomerId
                    ORDER BY 
                        a.number ASC;";
            string connectionString = Environment.GetEnvironmentVariable("MYSQL_BANKING_CORE");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<AccountDto> accounts = connection
                    .Query<AccountDto>(sql, new
                    {
                        Page = page,
                        PageSize = pageSize,
                        CustomerId = customerId
                    })
                    .ToList();
                    return accounts;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return new List<AccountDto>();
                }
                finally
                {
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
