using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class POPBaseClass
    {
        protected string _error;

        public string Error
        {
            get { return _error; }
        }

        protected SqlConnection FirstSqlConnection = new SqlConnection("Data Source=DESKTOP-L3GVK38;Initial Catalog=Point-Of-Sale;Integrated Security=True");

        private bool Connection()
        {
            if (DataReader != null && !DataReader.IsClosed)
                DataReader.Close();

            if (FirstSqlConnection.State == ConnectionState.Open)
                return true;
            try
            {
                FirstSqlConnection.Open();
                return true;
            }
            catch (Exception errorShow)
            {

                _error = errorShow.Message;
            }
            return false;
        }

        public string Search { get; set; }
        public bool IsDateSearch { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double AmmountFrom { get; set; }
        public double AmmountTo { get; set; }


        protected bool ExecuteNq(SqlCommand firstSqlCommand)
        {
            if (!Connection())
                return false;
            
            try
            {
                firstSqlCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception errorShow)
            {
                _error = errorShow.Message;
            }
            return false;
        }

        public int LastId { get; set; }
        protected bool ExecuteSaclar(SqlCommand firstSqlCommand)
        {
            if (!Connection())
                return false;

            try
            {
                LastId = Convert.ToInt32(firstSqlCommand.ExecuteScalar());
                return true;

            }
            catch (Exception errorShow)
            {
                _error = errorShow.Message;
            }
            return false;
        }

        protected SqlCommand DataBaseHide { get; set; }

        protected SqlCommand CommandBuilder(string sql)
        {
            SqlCommand firstSqlCommand = new SqlCommand();
            firstSqlCommand.Connection = FirstSqlConnection;
            firstSqlCommand.CommandText = sql;
            return firstSqlCommand;
        }

        protected SqlDataReader DataReader { get; set; }

        protected SqlDataReader ExecuteDataReader(SqlCommand cmd)
        {
            if (!Connection())
                return null;

            return cmd.ExecuteReader();
        }

        protected DataSet ExicuteDataSet(string sql)
        {
            if (!Connection())
                return null;

            SqlCommand firstSqlCommand = new SqlCommand();
            firstSqlCommand.Connection = FirstSqlConnection;
            firstSqlCommand.CommandText = sql;

            SqlDataAdapter dataAdd = new SqlDataAdapter(firstSqlCommand);
            DataSet dataSet = new DataSet();
            dataAdd.Fill(dataSet);
            return dataSet;
        }

        protected DataSet ExicuteDataSet(SqlCommand firstSqlCommand)
        {
            if (!Connection())
                return null;

            SqlDataAdapter dataAdd = new SqlDataAdapter(firstSqlCommand);
            DataSet dataSet = new DataSet();
            dataAdd.Fill(dataSet);
            return dataSet;
        }
    }
}
