using Dapper;
using MISA.DL.interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class BaseDL<MISAEntity> :IBaseDL<MISAEntity>
    {
        protected String _connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database= 15B_MS2-34_cukcuk_NGDUONG;" +
               "User Id = dev;" +
               "Password= 12345678";

        // 2. Khởi tạo kết nối:
        protected IDbConnection _dbConnection;

        public IEnumerable<MISAEntity> GetAll()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{name}s";
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public IEnumerable<MISAEntity> GetTotal()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{name}s";
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public MISAEntity GetById(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"SELECT * FROM {tableName} WHERE {tableName}Id = '{entityId.ToString()}'";
                var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand);
                return entity;
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var storeName = $"Proc_Insert{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Update(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                
                var tableName = typeof(MISAEntity).Name;
                /*
                var entityIdPropertyName = $"{tableName}Id";
                var entityIdProperty = typeof(MISAEntity).GetProperty(entityIdPropertyName);
                if (entityIdProperty != null)
                    typeof(MISAEntity).GetProperty(entityIdPropertyName).SetValue(entity, entityId);
                */
                var storeName = $"Proc_Update{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Delete(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {

                var tableName = typeof(MISAEntity).Name;

                var sqlCommand = $"DELETE FROM {tableName} WHERE {tableName}Id = '{entityId.ToString()}'";
                var rowsAffect = _dbConnection.Execute(sqlCommand);
                return rowsAffect;
            }
        }

        public IEnumerable<MISAEntity> GetPaging(int pageIndex, int pageSize)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{name}Paging";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PageIndex", pageIndex);
                dynamicParameters.Add("@m_PageSize", pageSize);

                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }
    }
}
