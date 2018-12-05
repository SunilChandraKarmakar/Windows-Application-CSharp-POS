using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Product:POPBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into product(name, code, description, brandId, categoryId, price) 
                                          values(@name, @code, @description, @brandId, @categoryId, @price)");
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@code", Code);
            DataBaseHide.Parameters.AddWithValue("@description", Description);
            DataBaseHide.Parameters.AddWithValue("@brandId", BrandId);
            DataBaseHide.Parameters.AddWithValue("@categoryId", CategoryId);
            DataBaseHide.Parameters.AddWithValue("@price", Price);
            //DataBaseHide.Parameters.AddWithValue("@createDate", CreateDate);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update product set name = @name, code = @code, description = @description, brandId = @brandId, categoryId = @categoryId, price = @price, createDate = @createDate where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@code", Code);
            DataBaseHide.Parameters.AddWithValue("@description", Description);
            DataBaseHide.Parameters.AddWithValue("@brandId", BrandId);
            DataBaseHide.Parameters.AddWithValue("@categoryId", CategoryId);
            DataBaseHide.Parameters.AddWithValue("@price", Price);
            DataBaseHide.Parameters.AddWithValue("@createDate", CreateDate);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from product where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from product where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }

        public bool SelectById()
        {
            DataBaseHide =
                CommandBuilder(@"select id, name, code, description, brandId, categoryId, price, createDate from product where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Name = DataReader["name"].ToString();
                Code = DataReader["code"].ToString();
                Description = DataReader["description"].ToString();
                BrandId = Convert.ToInt32(DataReader["brandId"]);
                CategoryId = Convert.ToInt32(DataReader["categoryId"]);
                Price = Convert.ToDouble(DataReader["price"]);
                CreateDate = Convert.ToDateTime(DataReader["createDate"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select p.id, p.name, p.code, p.description, b.name as Brand, c.name as Category, p.price, p.createDate from 
                                            ((product as p left join brand as b on p.brandId = b.id)
                                                left join category as c on p.categoryId = c.id) where p.id > 0");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " and (p.name like @search or p.description like @search or p.code like @search or p.price like @search or p.createDate like @search)";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (BrandId > 0)
            {
                DataBaseHide.CommandText += " and b.id = @brandId";
                DataBaseHide.Parameters.AddWithValue("brandId", BrandId);
            }

            if (CategoryId > 0)
            {
                DataBaseHide.CommandText += " and c.id = @categoryId";
                DataBaseHide.Parameters.AddWithValue("@categoryId", CategoryId);
            }

            if (IsDateSearch)
            {
                DataBaseHide.CommandText += " and p.createDate between @dateFrom and @dateTo";
                DataBaseHide.Parameters.AddWithValue("dateFrom", DateFrom);
                DataBaseHide.Parameters.AddWithValue("dateTo", DateTo);
            }
            return ExicuteDataSet(DataBaseHide);
        }
    }
}
