using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Employee:POPBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into employee(name, contact, email, password, type) 
                                          values(@name, @contact, @email, @password, @type)");
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@contact", Contact);
            DataBaseHide.Parameters.AddWithValue("@email", Email);
            DataBaseHide.Parameters.AddWithValue("@password", Password);
            DataBaseHide.Parameters.AddWithValue("@type", Type);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update employee set name = @name, contact = @contact, email = @email, password = @password, type = @type where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@contact", Contact);
            DataBaseHide.Parameters.AddWithValue("@email", Email);
            DataBaseHide.Parameters.AddWithValue("@password", Password);
            DataBaseHide.Parameters.AddWithValue("@type", Type);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from employee where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from employee where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }

        public bool SelectById()
        {
            DataBaseHide =
                CommandBuilder(@"select id, name, contact, email, password, type from employee where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Name = DataReader["name"].ToString();
                Contact = DataReader["contact"].ToString();
                Email = DataReader["email"].ToString();
                Password = DataReader["password"].ToString();
                Type = DataReader["type"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select id, name, contact, email, password, type from employee");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " where employee.name like @search or " +
                                            "employee.contact like @search or " +
                                            "employee.email like @search or " +
                                            "employee.password like @search or " +
                                            "employee.type like @search";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }
    }
}
