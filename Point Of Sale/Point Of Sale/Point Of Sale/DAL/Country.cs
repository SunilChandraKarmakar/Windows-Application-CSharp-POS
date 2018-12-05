using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class Country:POPBaseClass
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public bool Insert()
		{
			DataBaseHide = CommandBuilder(@"insert into country(name) values(@name)");
			DataBaseHide.Parameters.AddWithValue("@name", Name);
			return ExecuteNq(DataBaseHide);
		}
		public bool Update()
		{
			DataBaseHide = CommandBuilder(@"update country set name = @name where id = @id");
			DataBaseHide.Parameters.AddWithValue("@id", Id);
			DataBaseHide.Parameters.AddWithValue("@name", Name);
			return ExecuteNq(DataBaseHide);
		}
		public bool Delete(string ids = "")
		{
			if (ids == "")
			{
				DataBaseHide = CommandBuilder(@"delete from country where id = @id");
				DataBaseHide.Parameters.AddWithValue("@id", Id);
			}
			else
			{
				DataBaseHide = CommandBuilder(@"delete from country where id in (" + ids + ")");
			}
			return ExecuteNq(DataBaseHide);
		}
		public bool SelectById()
		{
			DataBaseHide = CommandBuilder(@"select id, name from country where id = @id");
			DataBaseHide.Parameters.AddWithValue("@id", Id);

			DataReader = ExecuteDataReader(DataBaseHide);

			while (DataReader.Read())
			{
				Name = DataReader["name"].ToString();
				return true;
			}
			return false;
		}
		public DataSet Select()
		{
			DataBaseHide = CommandBuilder(@"select id, name from country");
			if (!string.IsNullOrEmpty(Search))
			{
				DataBaseHide.CommandText += " where country.name like @search";
				DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
			}
			return ExicuteDataSet(DataBaseHide);
		}
	}
}
