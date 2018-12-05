using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Pucrchase:POPBaseClass
    {
        //public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }

        //public int SupplierId { get; set; }
        public int EmployeeId { get; set; }
        public int LedgerId { get; set; }
        public double Total { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into pucrchase (dateTime, employeeId, ledgerId, total, vat, discount) 
                                          values(@dateTime, @employeeId, @ledgerId, @total, @vat, @discount) select @@identity");
            //DataBaseHide.Parameters.AddWithValue("@number", Number);
            DataBaseHide.Parameters.AddWithValue("@dateTime", DateTime);
            //DataBaseHide.Parameters.AddWithValue("@supplierId", SupplierId);
            DataBaseHide.Parameters.AddWithValue("@employeeId", EmployeeId);
            DataBaseHide.Parameters.AddWithValue("@ledgerId", LedgerId);
            DataBaseHide.Parameters.AddWithValue("@total", Total);
            DataBaseHide.Parameters.AddWithValue("@vat", Vat);
            DataBaseHide.Parameters.AddWithValue("@discount", Discount);
            return ExecuteSaclar(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update pucrchase set dateTime = @dateTime, employeeId= @employeeId, ledgerId = @ledgerId, total = @total, vat = @vat, discount = @discount where number = @number");
            //DataBaseHide.Parameters.AddWithValue("@number", Number);
            DataBaseHide.Parameters.AddWithValue("@dateTime", DateTime);
            //DataBaseHide.Parameters.AddWithValue("@supplierId", SupplierId);
            DataBaseHide.Parameters.AddWithValue("@employeeId", EmployeeId);
            DataBaseHide.Parameters.AddWithValue("@ledgerId", LedgerId);
            DataBaseHide.Parameters.AddWithValue("@total", Total);
            DataBaseHide.Parameters.AddWithValue("@vat", Vat);
            DataBaseHide.Parameters.AddWithValue("@discount", Discount);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from pucrchase where number = @number");
                DataBaseHide.Parameters.AddWithValue("@number", Number);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from pucrchase where number in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select number, dateTime, employeeId, ledgerId, total, vat, discount from pucrchase where number = @number");
            DataBaseHide.Parameters.AddWithValue("@id", Number);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                //Number = DataReader["number"].ToString();
                DateTime = Convert.ToDateTime(DataReader["dateTime"]);
                //SupplierId = Convert.ToInt32(DataReader["supplierId"]);
                EmployeeId = Convert.ToInt32(DataReader["employeeId"]);
                LedgerId = Convert.ToInt32(DataReader["ledgerId"]);
                Total = Convert.ToDouble(DataReader["total"]);
                Vat = Convert.ToDouble(DataReader["vat"]);
                Discount = Convert.ToDouble(DataReader["discount"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select pucrchase.number, employee.name as Employ, ledger.name as ledger, pucrchase.dateTime, pucrchase.vat, pucrchase.discount, pucrchase.total
                                            from  ((pucrchase
                                            left join employee on pucrchase.employeeId =  employee.id)
                                            left join ledger on pucrchase.ledgerId = ledger.id) where pucrchase.number > 0");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " and (pucrchase.number like @search or employee.name like @search or ledger.name like @search or pucrchase.vat like @search or pucrchase.discount like @search or pucrchase.total like @search)";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }

    }
}
