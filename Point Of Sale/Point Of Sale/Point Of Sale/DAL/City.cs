using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class City:POPBaseClass
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CountryId { get; set; }
		
		public bool Insert()
		{
			DataBaseHide = CommandBuilder(@"insert into city (name, countryId) values(@name, @countryId)");
			DataBaseHide.Parameters.AddWithValue("@name", Name);
			DataBaseHide.Parameters.AddWithValue("@countryId", CountryId);
			return ExecuteNq(DataBaseHide);
		}
		public bool Update()
		{
			DataBaseHide = CommandBuilder(@"update city set name = @name, countryId = @countryId where id = @id");
			DataBaseHide.Parameters.AddWithValue("@id", Id);
			DataBaseHide.Parameters.AddWithValue("@name", Name);
			DataBaseHide.Parameters.AddWithValue("@countryId", CountryId);
			return ExecuteNq(DataBaseHide);
		}
		public bool Delete(string ids = "")
		{
			if (ids == "")
			{
				DataBaseHide = CommandBuilder(@"delete from city where id = @id");
				DataBaseHide.Parameters.AddWithValue("@id", Id);
			}
			else
			{
				DataBaseHide = CommandBuilder(@"delete from city where id in (" + ids + ")");
			}
			return ExecuteNq(DataBaseHide);
		}
		public bool SelectById()
		{
			DataBaseHide = CommandBuilder(@"select id, name, countryId from city where id = @id");
			DataBaseHide.Parameters.AddWithValue("@id", Id);

			DataReader = ExecuteDataReader(DataBaseHide);

			while (DataReader.Read())
			{
				Name = DataReader["name"].ToString();
				CountryId = Convert.ToInt32(DataReader["countryId"]);
				return true;
			}
			return false;
		}
		public DataSet Select()
		{
			DataBaseHide = CommandBuilder(@"select city.id, city.name, country.name as country
								  from city
								  left join country on city.countryId = country.id where city.id > 0");
			if (!string.IsNullOrEmpty(Search))
			{
				DataBaseHide.CommandText += " and city.name like @search";
				DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
			}

			if (CountryId > 0)
			{
				DataBaseHide.CommandText += " and country.id = @countryId";
				DataBaseHide.Parameters.AddWithValue("@countryId", CountryId);
			}
			return ExicuteDataSet(DataBaseHide);
		}
	}
}
