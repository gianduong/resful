using Dapper;
using MISA.Common.Entities;
using MISA.DL.interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
        public bool CheckEmailExists(string email)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_CheckEmployeeEmailExists";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@d_Email", email);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        public bool CheckEmployeeCodeExist(string Code)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_CheckEmployeeCodeExists";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@d_EmployeeCode", Code);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }              
        }

        public bool CheckIdentifyNumberExists(string IdentifyNumber)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_CheckEmployeeIdentifyNumberExists";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@d_IdentifyNumber", IdentifyNumber);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public string GenEmployeeCode()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_GetEmployeeCode";
                var res = _dbConnection.QueryFirstOrDefault<String>(sqlCommand, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public IEnumerable<Employee> SearchEmployees(string name)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@d_name", name);
                var sqlCommand = $"Proc_SearchEmployeeByCodeOrName";
                var entities = _dbConnection.Query<Employee>(sqlCommand, dynamic, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public IEnumerable<Employee> SearchByDepartmentId(Guid department)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@d_DepartmentId", department.ToString());
                var sqlCommand = $"Proc_SearchEmployeeByDepartmentId";
                var entities = _dbConnection.Query<Employee>(sqlCommand, dynamic, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }
    }
}
