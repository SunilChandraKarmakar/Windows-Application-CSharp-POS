using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductImage:POPBaseClass
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into productImage(productId, image, title) 
                                          values(@productId, @image, @title)");
            DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            DataBaseHide.Parameters.AddWithValue("@image", Image);
            DataBaseHide.Parameters.AddWithValue("@title", Title);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update productImage set productId = @productId, image = @image, title = @title where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            DataBaseHide.Parameters.AddWithValue("@image", Image);
            DataBaseHide.Parameters.AddWithValue("@title", Title);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from productImage where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from productImage where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select id, productId, image, title from productImage where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                ProductId = Convert.ToInt32(DataReader["productId"]);

                Title = DataReader["title"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select productImage.id, product.name as Product, productImage.image, productImage.title from productImage
                                            left join product on productImage.productId = product.id where productImage.id > 0");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " and productImage.title like @search";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (ProductId > 0)
            {
                DataBaseHide.CommandText += " and product.id = @productId";
                DataBaseHide.Parameters.AddWithValue("@productId", ProductId);
            }
            return ExicuteDataSet(DataBaseHide);
        }

    }
}
