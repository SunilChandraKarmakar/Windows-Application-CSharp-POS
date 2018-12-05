using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Category:POPBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public bool Insert()
        {
            if (CategoryId > 0)
            {
                DataBaseHide = CommandBuilder(@"insert into category(name, description, categoryId) 
                                          values(@name, @description, @categoryId)");
                DataBaseHide.Parameters.AddWithValue("@categoryId", CategoryId);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"insert into category(name, description) 
                                          values(@name, @description)");
            }
           ;
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@description", Description);
          
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update category set name = @name, description = @description, categoryId = @categoryId where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@description", Description);
            DataBaseHide.Parameters.AddWithValue("@categoryId", CategoryId);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from category where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from category where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select id, name, description, categoryId from category where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Name = DataReader["name"].ToString();
                Description = DataReader["description"].ToString();
                CategoryId = Convert.ToInt32(DataReader["categoryId"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select category1.id, category1.name, category1.description, category2.name as category from category as category1 left join category as category2 on category1.categoryId = category2.id where category1.id > 0");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " and category1.name like @search or " +
                                            "category1.description like @search"; 
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (CategoryId > 0)
            {
                DataBaseHide.CommandText += " and category.id = @categoryId";
                DataBaseHide.Parameters.AddWithValue("categoryId", CategoryId);
            }
            return ExicuteDataSet(DataBaseHide);
        }
    }
}
