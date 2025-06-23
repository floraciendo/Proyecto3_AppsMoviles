using System;
using SQLite;

namespace FinanceTracker.MVVM.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Glosa { get; set; }

        public float Monto { get; set; }

        public DateTime Fecha { get; set; }

        public bool EsIngreso { get; set; }
    }
}