using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Ledger:POPBaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gander { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }

        public bool Insert()
        {
            DataBaseHide = CommandBuilder(@"insert into ledger (name, contact, email, password,
                                                               gander, dateOfBirth, address,
                                                               cityId,createDate,image,type) 
                                          values(@name, @contact, @email, @password, @gander, 
                                                 @dateOfBirth, @address, @cityId, @createDate, 
                                                 @image, @type)");
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@contact", Contact);
            DataBaseHide.Parameters.AddWithValue("@email", Email);
            DataBaseHide.Parameters.AddWithValue("@password", Password);
            DataBaseHide.Parameters.AddWithValue("@gander", Gander);
            DataBaseHide.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            DataBaseHide.Parameters.AddWithValue("@address", Address);
            DataBaseHide.Parameters.AddWithValue("@cityId", CityId);
            DataBaseHide.Parameters.AddWithValue("@createDate", CreateDate);
            DataBaseHide.Parameters.AddWithValue("@image", Image);
            DataBaseHide.Parameters.AddWithValue("@type", Type);
            return ExecuteNq(DataBaseHide);
        }
        public bool Update()
        {
            DataBaseHide = CommandBuilder(@"update ledger set name = @name, contact = @contact, 
                                                              email = @email, password = @password,
                                                              gander = @gander, dateOfBirth = @dateOfBirth,
                                                              address = @address, cityId = @cityId,
                                                              createDate = @createDate, 
                                                              image = @image, type = @type where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);
            DataBaseHide.Parameters.AddWithValue("@name", Name);
            DataBaseHide.Parameters.AddWithValue("@contact", Contact);
            DataBaseHide.Parameters.AddWithValue("@email", Email);
            DataBaseHide.Parameters.AddWithValue("@password", Password);
            DataBaseHide.Parameters.AddWithValue("@gander", Gander);
            DataBaseHide.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            DataBaseHide.Parameters.AddWithValue("@address", Address);
            DataBaseHide.Parameters.AddWithValue("@cityId", CityId);
            DataBaseHide.Parameters.AddWithValue("createDate", CreateDate);
            DataBaseHide.Parameters.AddWithValue("@image", Image);
            DataBaseHide.Parameters.AddWithValue("@type", Type);
            return ExecuteNq(DataBaseHide);
        }
        public bool Delete(string ids = "")
        {
            if (ids == "")
            {
                DataBaseHide = CommandBuilder(@"delete from ledger where id = @id");
                DataBaseHide.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                DataBaseHide = CommandBuilder(@"delete from ledger where id in (" + ids + ")");
            }
            return ExecuteNq(DataBaseHide);
        }
        public bool SelectById()
        {
            DataBaseHide = CommandBuilder(@"select id, name, contact, email, password, gander, dateOfBirth,
                                         address, cityId, createDate, image, type from ledger where id = @id");
            DataBaseHide.Parameters.AddWithValue("@id", Id);

            DataReader = ExecuteDataReader(DataBaseHide);

            while (DataReader.Read())
            {
                Name = DataReader["name"].ToString();
                Contact = DataReader["contact"].ToString();
                Email = DataReader["email"].ToString();
                Password = DataReader["password"].ToString();
                Gander = DataReader["gander"].ToString();
                DateOfBirth = Convert.ToDateTime(DataReader["dateOfBirth"]);
                Address = DataReader["address"].ToString();
                CityId = Convert.ToInt32(DataReader["cityId"]);
                CreateDate = Convert.ToDateTime(DataReader["createDate"]);

                Type = DataReader["type"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            DataBaseHide = CommandBuilder(@"select ledger.id, ledger.name, ledger.contact, ledger.email, ledger.password, ledger.gander, ledger.address, city.name as City, ledger.dateOfBirth, ledger.createDate, ledger.type, ledger.image
                                            from ledger, city
                                            where ledger.cityId = city.id");
            if (!string.IsNullOrEmpty(Search))
            {
                DataBaseHide.CommandText += " and (ledger.name like @search or ledger.contact like @search or ledger.email like @search or ledger.gander like @search or ledger.address like @search or city.name like @search or ledger.type like @search)";
                DataBaseHide.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExicuteDataSet(DataBaseHide);
        }
    }
}
