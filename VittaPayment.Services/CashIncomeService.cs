using Dapper;
using Microsoft.Data.SqlClient;
using VittaPayment.Services.Interfaces;
using VittaPayment.Shared.Models;

namespace VittaPayment.Services;

public class CashIncomeService(string connectionString) : ICashIncomeService
{
    public async Task AddCashIncomeAsync(CashIncome cashIncome)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql =
            "INSERT INTO CashIncome (IncomeNumber, IncomeDate, Amount, Balance) VALUES (@IncomeNumber, @IncomeDate, @Amount, @Balance)";
        await conn.ExecuteAsync(sql, cashIncome);
    }

    public async Task<CashIncome?> GetCashIncomeAsync(int incomeNumber)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "SELECT * FROM CashIncome WHERE IncomeNumber = @IncomeNumber";
        return await conn.QueryFirstOrDefaultAsync<CashIncome>(sql, new { IncomeNumber = incomeNumber });
    }

    public async Task<IEnumerable<CashIncome>> GetAllCashIncomesAsync()
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "SELECT * FROM CashIncome";
        return (await conn.QueryAsync<CashIncome>(sql)).AsList();
    }

    public async Task UpdateCashIncomeAsync(CashIncome cashIncome)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql =
            "UPDATE CashIncome SET IncomeDate = @IncomeDate, Amount = @Amount, Balance = @Balance WHERE IncomeNumber = @IncomeNumber";
        await conn.ExecuteAsync(sql, cashIncome);
    }

    public async Task DeleteCashIncomeAsync(int incomeNumber)
    {
        await using var conn = new SqlConnection(connectionString);
        await conn.OpenAsync();
        const string sql = "DELETE FROM CashIncome WHERE IncomeNumber = @IncomeNumber";
        await conn.ExecuteAsync(sql, new { IncomeNumber = incomeNumber });
    }
}