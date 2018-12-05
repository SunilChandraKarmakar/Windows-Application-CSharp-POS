using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductPrice:POPBaseClass
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into productPrice(productId, unitId, price) 
                                          values(@productId, @unitId, @price)");
            DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            DataBaseHide.Parameters.AddWithValue("@unitId", UnitId);
            DataBaseHide.Parameters.AddWithValue("@price", Price);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update productPrice set productId = @productId, unitId = @unitId, price = @price where id = @id");
            DataBaseHide.Parameters.AddWithValue("id", Id);
            DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            DataBaseHide.Parameters.AddWithValue("@unitId", UnitId);
            DataBaseHide.Parameters.AddWithValue("@price", Price);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from productPrice where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from productPrice where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select id, productId, unitId, price from productPrice where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                UnitId = Convert.ToInt32(DataReader["unitId"]);
                Price = Convert.ToDouble(DataReader["price"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select productPrice.id, product.name as productName, unit.name as unitName, productPrice.price
                                            from ((productPrice left join product on productPrice.productId = product.id)
                                            left join unit on productPrice.unitId = unit.id) where productPrice.id > 0");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " and (productPrice.price like @search or product.name like @search or unit.name like @search)";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (ProductId > 0)
            {
                DataBaseHide.CommandText += " and product.id = @productId";
                DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            }

            if (UnitId > 0)
            {
                DataBaseHide.CommandText += " and unit.id = @unitId";
                DataBaseHide.Parameters.AddWithValue("@unitId", UnitId);
            }
            return ExicuteDataSet(DataBaseHide);
        }

    }
}
