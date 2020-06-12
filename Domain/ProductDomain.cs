using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Models;

namespace Domain
{
    public class ProductDomain
    {
        public List<ViewProduct> GetByCategoryName(string _category)
        {
            var _list = new List<ViewProduct>();

            SqlCommand _command = new SqlCommand("select * from products where category='" + _category+"'");

            SqlDataReader _data = Utility.Query(_command);
            try
            {
                if (_data.HasRows)
                {
                    while (_data.Read())
                    {
                        ViewProduct p = new ViewProduct();
                        p.Id = _data.GetInt32(0);
                        p.Name = _data.GetString(1);
                        p.Category = _data.GetString(2);

                        _list.Add(p);
                    }
                }
            }
            catch (SqlException e)
            {
                _list.Add(new ViewProduct { Category = null, Id = null, Name = null });
            }
            Utility.CloseConnection();
            return _list;
        }
    }
}
