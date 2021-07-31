using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Async_Await
{
    class DataSource 
    {

        private SqlConnectionStringBuilder builder;

        private static DataSource _intance;
        protected DataSource()
        {
            builder = new SqlConnectionStringBuilder();
        }

        public static DataSource Intances()
        {
           if(_intance == null)
                _intance = new DataSource();
            
            
          //  _intance = _intance ?? new DataSource();
            
            return _intance;
        }
        public string GetDataSourceSever()
        {
            builder.DataSource = @"DESKTOP-OQFEFQ5";

            builder.InitialCatalog = "Async_Await";

            builder.IntegratedSecurity = true;

            return builder.ConnectionString;
        }




    }
}
