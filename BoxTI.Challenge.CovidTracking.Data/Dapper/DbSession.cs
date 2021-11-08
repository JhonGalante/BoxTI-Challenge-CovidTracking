using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Data.Dapper
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbSession()
        {
            Connection = new MySqlConnection("Server=localhost;Port=3306;Database=covidregistrydb;Uid=root;Pwd=root;charset=utf8;");
            Connection.Open();
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
