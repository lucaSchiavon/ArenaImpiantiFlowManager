using ArenaFlowManager.Data;
using ArenaFlowManager.Models;
using ArenaFlowManager.Models.Clienti;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace ArenaFlowManager.Repositories
{
    public class ContattiRepository
    {
        private readonly string _connectionString;
        public ContattiRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool EliminaContatto(int idContattoCliente)
        {
            string query = "DELETE FROM [AnagraficaClienti_Contatti] WHERE [idContattoCliente]=@idContattoCliente";
            using (var dal = new AdoDataLayer(_connectionString))
            {
                dal.AddOrReplaceParameter("@idContattoCliente", idContattoCliente, System.Data.SqlDbType.Int);
                int rowsAffected = dal.ExecuteNonQuery(query);
                return rowsAffected > 0;
            }
        }

        public int InsertContatto(AnagraficaClienti_Contatto contatto)
    {
        string query = @"INSERT INTO [AnagraficaClienti_Contatti] ([idAnagraficaCliente],[idTipoContatto],[Contatto],[NotaContatto],[DataRecord] )
        VALUES (@idAnagraficaCliente,@idTipoContatto,@Contatto,@NotaContatto,@DataRecord); SELECT SCOPE_IDENTITY();";
        using (var dal = new AdoDataLayer(_connectionString))
        {
            dal.AddOrReplaceParameter("@idAnagraficaCliente", contatto.IdAnagraficaCliente, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idTipoContatto", contatto.IdTipoContatto , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@Contatto", contatto.Contatto ?? "", System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@NotaContatto", contatto.NotaContatto ?? "", System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@DataRecord", DateTime.Now, System.Data.SqlDbType.DateTime2);
          
            object id = dal.ExecuteScalar(query);
            return Convert.ToInt32(id);
        }
    }

    public void UpdateContatto(AnagraficaClienti_Contatto contatto)
    {
        string query = @"UPDATE [AnagraficaClienti_Contatti] SET [idAnagraficaCliente]=@idAnagraficaCliente,[idTipoContatto]=@idTipoContatto,[Contatto]=@Contatto,[NotaContatto]=@NotaContatto,[DataRecord]=@DataRecord WHERE [idContattoCliente]=@idContattoCliente";
        using (var dal = new AdoDataLayer(_connectionString))
        {
                dal.AddOrReplaceParameter("@idContattoCliente", contatto.IdContattoCliente, System.Data.SqlDbType.Int);
                dal.AddOrReplaceParameter("@idAnagraficaCliente", contatto.IdAnagraficaCliente, System.Data.SqlDbType.Int);
                dal.AddOrReplaceParameter("@idTipoContatto", contatto.IdTipoContatto, System.Data.SqlDbType.Int);
                dal.AddOrReplaceParameter("@Contatto", contatto.Contatto ?? "", System.Data.SqlDbType.NVarChar);
                dal.AddOrReplaceParameter("@NotaContatto", contatto.NotaContatto ?? "", System.Data.SqlDbType.NVarChar);
                dal.AddOrReplaceParameter("@DataRecord", DateTime.Now, System.Data.SqlDbType.DateTime2);
                dal.ExecuteNonQuery(query);
        }
    }

        public List<AnagraficaClienti_Contatto> GetContatti(int IdCliente)
        {
            var lista = new List<AnagraficaClienti_Contatto>();
           
            string query = @"SELECT [idContattoCliente],[TipoContatto],[Contatto],[NotaContatto] FROM [Visualizzazione3]";
            query += " where  idAnagraficaCliente=" + IdCliente;
            query += " order by Contatto";

            using (var dal = new AdoDataLayer(_connectionString))
            {
                //if (!string.IsNullOrWhiteSpace(ricerca))
                //{
                //    dal.AddOrReplaceParameter("@search", "%" + ricerca + "%", System.Data.SqlDbType.NVarChar);
                //}
                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var dto = new AnagraficaClienti_Contatto();
                    foreach (PropertyInfo prop in typeof(AnagraficaClienti_Contatto).GetProperties())
                    {
                        if (dt.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(dto, System.Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
                        }
                    }
                    lista.Add(dto);
                }
            }
            return lista;
        }
        public List<AnagraficaClienti_Contatto> GetContatto(int IdContatto)
        {
            var lista = new List<AnagraficaClienti_Contatto>();
            
            string query = @"SELECT * FROM [Visualizzazione3] ";
          
                query += "WHERE idContattoCliente=" + IdContatto;
           
            using (var dal = new AdoDataLayer(_connectionString))
            {
               
                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var dto = new AnagraficaClienti_Contatto();
                    foreach (PropertyInfo prop in typeof(AnagraficaClienti_Contatto).GetProperties())
                    {
                        if (dt.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(dto, System.Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
                        }
                    }
                    lista.Add(dto);
                }
            }
            return lista;
        }
       
        public List<ComboItem> GetCboTipoContattoItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [idTipoContatto],[TipoContatto] FROM [STA-TipiContatto] order by Ordine";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["idTipoContatto"].ToString(), Text = row["TipoContatto"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }
       

    }
}
