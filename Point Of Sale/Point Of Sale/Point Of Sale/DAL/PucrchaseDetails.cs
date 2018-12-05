using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class PucrchaseDetails:POPBaseClass
    {
        public int PucrchaseId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into pucrchaseDetails(pucrchaseId, productId, qty, rate) 
                                          values(@pucrchaseId, @productId, @qty, @rate)");
            DataBaseHide.Parameters.AddWithValue("@pucrchaseId", PucrchaseId);
            DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            DataBaseHide.Parameters.AddWithValue("@qty", Qty);
            DataBaseHide.Parameters.AddWithValue("@rate", Rate);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update pucrchaseDetails set pucrchaseId = @pucrchaseId, productId = @productId, qty = @qty, rate= @rate where pucrchaseId = @pucrchaseId");
            DataBaseHide.Parameters.AddWithValue("@pucrchaseId", PucrchaseId);
            DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            DataBaseHide.Parameters.AddWithValue("@qty", Qty);
            DataBaseHide.Parameters.AddWithValue("@rate", Rate);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from pucrchaseDetails where pucrchaseId = @pucrchaseId");
                DataBaseHide.Parameters.AddWithValue("@pucrchaseId", PucrchaseId);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from pucrchaseDetails where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select pucrchaseId, productId, qty, rate from pucrchaseDetails where pucrchaseId = @pucrchaseId");
            DataBaseHide.Parameters.AddWithValue("@pucrchaseId", PucrchaseId);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                ProductId = Convert.ToInt32(DataReader["productId"]);
                Qty = Convert.ToInt32(DataReader["qty"]);
                Rate = Convert.ToDouble(DataReader["rate"].ToString());
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select pucrchaseId, productId, qty, rate from pucrchaseDetails");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " where pucrchaseDetails.pucrchaseId like @search or " +
                                            "pucrchaseDetails.productId like @search or " +
                                            "pucrchaseDetails.qty like @search or" +
                                            "pucrchaseDetails.rate like @search";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }
    }
}

