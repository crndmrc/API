using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MusteriController : ApiController
    {
        // GET: api/Musteri
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Musteri/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet]
        public DataTable Read()
        {
            DataTable dt = new DataTable();
            Execute _execute = new Execute();
            string _hataMesaji = "";
            dt = _execute.executeDT("select * from MUSTERI",null,false,ref _hataMesaji);
            dt.TableName = "dtTable";
            return dt;

        }
        [HttpGet]
        [Route("api/Musteri/Create/{adi}")]
        public bool Create(string adi)
        {
            bool result = true;
            Execute _execute = new Execute();
            string _hataMesaji = "";
            List<SqlParameter> _params= new List<SqlParameter>();
            _params.Add(new SqlParameter("@adi",adi));
            result = _execute.execute("insert into MUSTERI(adi) Values(@adi)",_params.ToArray(), false, ref _hataMesaji);
            return result;
        }
        [HttpGet]
        [Route("api/Musteri/Update/{id}/{adi}")]
        public bool Update(int id,string adi)
        {
            bool result = true;
            Execute _execute = new Execute();
            string _hataMesaji = "";
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", id));
            _params.Add(new SqlParameter("@adi", adi));
            result = _execute.execute("update MUSTERI set adi=@adi where id=@id", _params.ToArray(), false,ref _hataMesaji);
            return result;
        }
        [HttpGet]
        [Route("api/Musteri/Delete/{id}")]
        public bool Delete(int id)
        {
            bool result = true;
            Execute _execute = new Execute();
            string _hataMesaji = "";
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", id));
            result = _execute.execute("delete from MUSTERI where id=@id", _params.ToArray(), false, ref _hataMesaji);
            return result;
        }
    }
}
