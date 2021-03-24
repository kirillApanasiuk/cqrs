using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Interfaces.Common;

namespace ApplicationServices.Interfaces.Order
{
    public interface IOrderService:IEntityService<ChangeOrderDto>
    {
    }
}
