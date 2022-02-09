using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Execute
    {
        public const string _cs = @"Server=Z36-15\SQLEXPRESS;Database=MUSTERI;User Id=sa;Password=12345678;";
        public DataTable executeDT(string _sql, SqlParameter[] _params, bool isProcedure, ref string _exceptionMessage)
        {
            DataTable dtResult = new DataTable();
            _exceptionMessage = "";

            try
            {
                SqlConnection _con = new SqlConnection(_cs);
                SqlCommand _cmd = new SqlCommand(_sql, _con);
                if (_params != null) _cmd.Parameters.AddRange(_params);
                if (isProcedure == true) _cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
                _adapter.Fill(dtResult);
            }
            catch (Exception ex)
            {
                dtResult = null;
                _exceptionMessage = "Bir hata oluştu. Lütfen sistem yöneticinize haber veriniz! \n [ " + ex.Message + " ]";
            }
            return dtResult;
        }
        public bool execute(string _sql, SqlParameter[] _params, bool isProcedure, ref string _exceptionMessage)
        {
            bool result = true;
            _exceptionMessage = "";
            SqlConnection _con = new SqlConnection(_cs);

            try
            {
                _con.Open();
                SqlCommand _cmd = new SqlCommand(_sql, _con);
                if (_params != null) _cmd.Parameters.AddRange(_params);
                if (isProcedure == true) _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                _exceptionMessage = "Bir hata oluştu. Lütfen sistem yöneticinize haber veriniz! \n [ " + ex.Message + " ]";
            }
            finally
            {
                _con.Close();
            }
            return result;
        }
    }
}
