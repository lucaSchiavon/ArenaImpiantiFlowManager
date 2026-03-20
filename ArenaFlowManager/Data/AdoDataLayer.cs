using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace ArenaFlowManager.Data
{
    public class AdoDataLayer : IDisposable
    {
        // Stringa di connessione usata da tutte le funzioni
        private string _connectionString;
        private SqlConnection _connection;
        // Tabella degli sqlParameter da aggiungere al command. La key è il ParameterName
        private Hashtable _parameterList = new Hashtable();
        private DbDataReader _dr;
        public AdoDataLayer(string connectionString)
        {
            ClearParameters();
            _connectionString = connectionString;

        }


        #region gestione parametri
        public void ClearParameters()
        {
            _parameterList.Clear();
        }

        public void AddOrReplaceParameter(string name, object value, SqlDbType sqlDbType = SqlDbType.NVarChar, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter sqlParameter = new SqlParameter(name, value);
            sqlParameter.Direction = direction;
            sqlParameter.SqlDbType = sqlDbType;

            switch (sqlParameter.SqlDbType)
            {
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                case SqlDbType.VarChar:
                    sqlParameter.Size = -1;
                    break;
            }

            if (!_parameterList.ContainsKey(name))
            {
                _parameterList.Add(name, sqlParameter);
            }
            else
            {
                _parameterList[name] = sqlParameter;
            }
        }

        public object GetParameterValue(string name)
        {
            if (_parameterList.ContainsKey(name))
            {
                return ((SqlParameter)_parameterList[name]).Value;
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region Connection
        private void OpenConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }


            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_dr != null && !_dr.IsClosed)
            {
                _dr.Close();
            }

            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open || _connection.State == ConnectionState.Broken)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }
        #endregion




        #region Datatable
        /// <summary>
        /// ritorna un datatable con i risultati della query non parametrica o SP a cui vengono passati parametri
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();

            OpenConnection();
            //conn.Open();
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                foreach (DictionaryEntry de in _parameterList)
                {
                    command.Parameters.Add((SqlParameter)de.Value);
                }
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
        /// <summary>
        /// ritora un datatable con i risultati della query parametrica o SP a cui vengono passati parametri
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string queryString, CommandType commandType = CommandType.Text)
        {

            OpenConnection();
            SqlCommand command = new SqlCommand(queryString, _connection);
            command.CommandType = commandType;
            foreach (DictionaryEntry de in _parameterList)
            {
                command.Parameters.Add((SqlParameter)de.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            // Disassocio la lista di parametri dal command
            command.Parameters.Clear();
            command.Dispose();
            adapter.Dispose();

            return datatable;

        }
        #endregion


        #region ExecuteNonQuery
        /// <summary>
        /// esegue una query non parametrica
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query)
        {
            int result = 0;

            OpenConnection();

            //conn.Open();
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                foreach (DictionaryEntry de in _parameterList)
                {
                    command.Parameters.Add((SqlParameter)de.Value);
                }
                result = command.ExecuteNonQuery();
            }

            return result;
        }

        /// <summary>
        /// esegue una query parametrica o SP a cui vengono passati parametri
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public void ExecuteNonQuery(string queryString, CommandType commandType = CommandType.Text)
        {

            OpenConnection();
            SqlCommand command = new SqlCommand(queryString, _connection);
            command.CommandType = commandType;

            foreach (DictionaryEntry de in _parameterList)
            {
                command.Parameters.Add((SqlParameter)de.Value);
            }
            command.ExecuteNonQuery();
            // Disassocio la lista di parametri dal command
            command.Parameters.Clear();
            command.Dispose();



        }
        #endregion


        #region ExecuteScalar
        /// <summary>
        /// ritorna un valore scalare di una query non parametrica
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query)
        {
            object result = null;
            OpenConnection();
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                foreach (DictionaryEntry de in _parameterList)
                {
                    command.Parameters.Add((SqlParameter)de.Value);
                }
                result = command.ExecuteScalar();
            }

            return result;
        }
        /// <summary>
        /// ritorna un valore scalare di una query parametrica o SP a cui vengono passati parametri
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string queryString, CommandType commandType = CommandType.Text)
        {

            //using (_connection)
            //{
            //SqlCommand command = new SqlCommand(queryString, _connection);


            OpenConnection();
            object returnValue = null;
            using (SqlCommand command = new SqlCommand(queryString, _connection))
            {
                command.CommandType = commandType;
                foreach (DictionaryEntry de in _parameterList)
                {
                    command.Parameters.Add((SqlParameter)de.Value);
                }
                command.ExecuteScalar();
                // Disassocio la lista di parametri dal command
                //command.Parameters.Clear();
                //command.Dispose();

            }

            return returnValue;
            //}

        }
        #endregion


        #region ExecuteReader
        /// <summary>
        /// ritorna un datareader di una query non parametrica
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string query)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand(query, _connection);
            foreach (DictionaryEntry de in _parameterList)
            {
                command.Parameters.Add((SqlParameter)de.Value);
            }
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// ritorna un datareader di una query parametrica o SP a cui vengono passati parametri
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string queryString, CommandType commandType = CommandType.Text)
        {
            DbDataReader dr;
            // Uso la connection esterna altrimenti si eliminerebbe alla fine del metodo rendendo
            // inutilizzabile i DataReader
            OpenConnection();

            SqlCommand command = new SqlCommand(queryString, _connection);
            command.CommandTimeout = 1800;
            command.CommandType = commandType;
            foreach (DictionaryEntry de in _parameterList)
            {
                command.Parameters.Add((SqlParameter)de.Value);
            }

            dr = command.ExecuteReader();
            // Disassocio la lista di parametri dal command
            command.Parameters.Clear();
            command.Dispose();

            return dr;

        }
        #endregion




        #region Idisposable support

        // IDisposable
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {

            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    CloseConnection();
                    _parameterList.Clear();
                    _parameterList = null;
                }

                // Free unmanaged resources (unmanaged objects) and override Finalize() below.
                // Set large fields to null.
                disposedValue = true;
            }
        }

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion



    }
}
