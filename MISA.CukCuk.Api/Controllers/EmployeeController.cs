using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.interfaces;
using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        IEmployeeBL _baseBL;
        public EmployeeController(IEmployeeBL baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }

        [HttpGet("getCode")]
        public IActionResult Get(String code)
        {
            var rs = _baseBL.GenNewEmployeeCode();
            // 4. Trả về cho Client:
            if (rs != null)
            {
                return Ok(rs);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("search")]
        public IActionResult Search(String name)
        {
            var rs = _baseBL.SearchEmployees(name);
            if(rs != null)
            {
                return Ok(rs);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("Paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            var rs = _baseBL.GetPaging(pageIndex, pageSize);
            if (rs != null)
            {
                return Ok(rs);
            }
            else
                return NoContent();
        }

        [HttpGet("CheckCodeExists")]
        public IActionResult checkCode(String code)
        {
            bool rs = _baseBL.CheckEmployeeCodeExist(code);

            return Ok(rs);
        }

        [HttpGet("searchByDepartmentId")]
        public IActionResult SearchByDepartmentId(Guid name)
        {
            var rs = _baseBL.SearchByDepartmentId(name);
            if (rs != null)
            {
                return Ok(rs);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
