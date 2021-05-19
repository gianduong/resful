using MISA.BL.Exceptions;
using MISA.BL.interfaces;
using MISA.Common.Attributes;
using MISA.DL;
using MISA.DL.interfaces;
using System;
using System.Collections.Generic;

namespace MISA.BL
{
    public class BaseBL<MISAEntity> : IBaseBL<MISAEntity>
    {
        IBaseDL<MISAEntity> _baseDL;
        public BaseBL(IBaseDL<MISAEntity> baseDL)
        {
            _baseDL = baseDL;
        } 
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseDL.GetAll();
        }

        public IEnumerable<MISAEntity> GetPaging(int pageIndex, int pageSize)
        {
            BaseDL<MISAEntity> baseDL = new BaseDL<MISAEntity>();
            return baseDL.GetPaging( pageIndex, pageSize);
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseDL.GetById(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            // validate dữ liệu:
            Validate(entity);
            ValidateCustom(entity);
            return _baseDL.Insert(entity);
        }

        public int Update(MISAEntity entity)
        {
            return _baseDL.Update(entity);
        }

        public int Delete(Guid entityId)
        {
            return _baseDL.Delete(entityId);
        }
        void Validate(MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var prop in properties)
            {
                var attributeRequired = prop.GetCustomAttributes(typeof(Required), true);
                var attributeMaxLength = prop.GetCustomAttributes(typeof(MISAMaxLength), true);
                if (attributeRequired.Length > 0)
                {
                    //lay gia tri cua propery
                    var propetyValue = prop.GetValue(entity);
                    var properyType = prop.PropertyType;
                    if (prop.PropertyType == typeof(String) && String.IsNullOrEmpty(propetyValue.ToString()))
                    {
                        var msgError = (attributeRequired[0] as Required).msgError;
                        throw new GuardException<MISAEntity>(msgError, entity);
                    }
                }
                if (attributeMaxLength.Length > 0)
                {
                    //lay gia tri cua propery
                    var propetyValue = prop.GetValue(entity);
                    //lay ra do dai cho phep
                    var maxLength = (attributeMaxLength[0] as MISAMaxLength).MaxLength;
                    if (propetyValue.ToString().Length > maxLength)
                    {
                        throw new GuardException<MISAEntity>($"Thông tin {prop.Name} không được dài quá {maxLength} ký tự!", entity);
                    }
                }
            }
        }

        protected virtual void ValidateCustom(MISAEntity entity)
        {

        }
    }
}
