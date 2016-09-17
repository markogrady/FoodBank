using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Dto.Attribute;

namespace FoodBank.Core.Business.Product
{
    public interface IAttributeBusiness
    {
        Task CreateUpdateAttribute(AttributeEditModel model);
        Task<AttributeEditModel> GetAttribute(Guid id);

    }
}
