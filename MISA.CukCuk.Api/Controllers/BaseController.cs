using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;
using MISA.BL;
using MISA.Common.Entities;
using MISA.BL.Exceptions;
using MISA.BL.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        IBaseBL<T> _baseBL;
        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var rs = _baseBL.GetAll();
            if (rs != null)
            {
                return Ok(rs);
            }
            else
                return NoContent();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var rs = _baseBL.GetById(id);
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

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            try
            {
                var rowAffects = _baseBL.Insert(entity);
                if (rowAffects > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<T> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "EmployeeCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {

                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500, mes);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] T entity)
        {
            try
            {
                var rowAffects = _baseBL.Update(entity);
                if (rowAffects > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                };
                return StatusCode(500, mes);
            }
        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var rowAffects = _baseBL.Delete(id);
                if (rowAffects > 0)
                {
                    return StatusCode(200, "good game!");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500, mes);
            }
        }
    }
}
