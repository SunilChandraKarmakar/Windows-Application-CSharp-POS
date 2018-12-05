using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Transaction:POPBaseClass
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public DateTime DateTime { get; set; }
        public int LedgerId { get; set; }
        public int EmployeeId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Remarks { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into [transaction](number, reference, dateTime, ledgerId, employeeId, debit, credit, remarks) 
                                          values(@number, @reference, @dateTime, @ledgerId, @employeeId, @debit, @credit, @remarks)");
            DataBaseHide.Parameters.AddWithValue("@number", Number);
            DataBaseHide.Parameters.AddWithValue("@reference", Reference);
            DataBaseHide.Parameters.AddWithValue("@dateTime", DateTime);
            DataBaseHide.Parameters.AddWithValue("@ledgerId", LedgerId);
            DataBaseHide.Parameters.AddWithValue("@employeeId", EmployeeId);
            DataBaseHide.Parameters.AddWithValue("@debit", Debit);
            DataBaseHide.Parameters.AddWithValue("@credit", Credit);
            DataBaseHide.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update transaction set number = @number, reference = @reference, dateTime = @dateTime, ledgerId= @ledgerId, employeeId = @employeeId, debit = @debit, credit = @credit, remarks = @remarks where id = @id");
            DataBaseHide.Parameters.AddWithValue("@number", Number);
            DataBaseHide.Parameters.AddWithValue("@reference", Reference);
            DataBaseHide.Parameters.AddWithValue("@dateTime", DateTime);
            DataBaseHide.Parameters.AddWithValue("@ledgerId", LedgerId);
            DataBaseHide.Parameters.AddWithValue("@employeeId", EmployeeId);
            DataBaseHide.Parameters.AddWithValue("@debit", Debit);
            DataBaseHide.Parameters.AddWithValue("@credit", Credit);
            DataBaseHide.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from transaction where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from transaction where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select number, reference, dateTime, ledgerId, employeeId, debit, credit, remarks from transaction where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Number = DataReader["number"].ToString();
                Reference = DataReader["reference"].ToString();
                DateTime = Convert.ToDateTime(DataReader["dateTime"]);
                LedgerId = Convert.ToInt32(DataReader["ledgerId"]);
                EmployeeId = Convert.ToInt32(DataReader["employeeId"]);
                Debit = Convert.ToDouble(DataReader["debit"]);
                Credit = Convert.ToDouble(DataReader["credit"]);
                Remarks = DataReader["remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select number, reference, dateTime, ledgerId, employeeId, debit, credit, remarks from transaction");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " where transaction.number like @search or " +
                                            "transaction.reference like @search or " +
                                            "transaction.dateTime like @search or" +
                                            "transaction.ledgerId like @search or" +
                                            "transaction.employeeId like @search or" +
                                            "transaction.debit like @search or" +
                                            "transaction.credit like @search or" +
                                            "transaction.remarks like @search";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }

    }
}
