using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Unit:POPBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PrimaryQty { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into unit (name, description, primaryQty) 
                                          values(@name, @description, @primaryQty)");
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@description", Description);
            DataBaseHide.Parameters.AddWithValue("@primaryQty", PrimaryQty);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update unit set name = @name, description = @description, primaryQty = @primaryQty where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@description", Description);
            DataBaseHide.Parameters.AddWithValue("@primaryQty", PrimaryQty);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from unit where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from unit where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select id, name, description, primaryQty from unit where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Name = DataReader["name"].ToString();
                Description = DataReader["description"].ToString();
                PrimaryQty = Convert.ToInt32(DataReader["primaryQty"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select id, name, description, primaryQty from unit");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " where unit.name like @search or " +
                                            "unit.description like @search or " +
                                            "unit.primaryQty like @search";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }     

    }
}
