using System;
using SQLite;

namespace FinanceTracker.MVVM.Models;
public class Transaction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public bool IsIncome { get; set; }
}