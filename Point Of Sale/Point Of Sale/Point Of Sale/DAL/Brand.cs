using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    class Brand:POPBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into brand(name, origin) values(@name, @origin)");
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@origin", Origin);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update brand set name = @name, origin = @origin where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@origin", Origin);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from brand where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from brand where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select id, name, origin from brand where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Name = DataReader["name"].ToString();
                Origin = DataReader["origin"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select id, name, origin from brand");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " where brand.name like @search or " +
                                            "brand.origin like @search";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }
    }
}
