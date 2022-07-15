using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind_API.Datalayer;
using NorthWind_API.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace NorthWind_API
{
    [Route("api/[controller]")]
    //[ApiController]
    public class NWProductsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<Product> Get()
        {
            List<Product> PList = new List<Product>();
            try
            {
                string sql = "select p.ProductId, p.ProductName,p.UnitPrice as Price," +
                    "c.CategoryName,s.CompanyName as SupplierName from Products p " +
                    "inner join Suppliers s on p.SupplierId=s.SupplierId " +
                    "inner join Categories c on p.CategoryId=c.CategoryId";
                DataTable dt = DataAccess.GetDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    Product pr = new Product();
                    pr.ProductId = (int)dr["ProductId"];
                    pr.ProductName = (string)dr["ProductName"];
                    pr.CategoryName = (string)dr["CategoryName"];
                    pr.SupplierName = (string)dr["SupplierName"];
                    pr.Price = (decimal)dr["Price"];
                    PList.Add(pr);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PList;
        }
        // GET api/<controller>/prodid
        [HttpGet("{prodid}")]
        public PDetail GetProductDetail(int prodid)
        {
            PDetail pd = new PDetail();
            try
            {
                string sql = "select p.UnitsInStock, p.QuantityPerUnit, p.Discontinued " + "from Products p where p.ProductId=" + prodid;
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    pd.UnitsInStock = int.Parse(dt.Rows[0]["UnitsInStock"].ToString());
                    pd.QuantityPerUnit = dt.Rows[0]["QuantityPerUnit"].ToString();
                    pd.Discontinued = (bool)(dt.Rows[0]["Discontinued"]);
                }
            }
            catch (Exception)
            {
                throw;

            }

            return pd;
        }
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
