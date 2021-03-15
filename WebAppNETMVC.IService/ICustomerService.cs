using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;

namespace WebAppNETMVC.IService
{
    public interface ICustomerService
    {
        CustomerBOResponseWithPaging GetAll(int pageIndex = 0, int pageSize = 10, string orderByField = "", string orderBy = "");
        
        void Delete(int id);

        CustomerBOResponse Add(CustomerBORequest customerBORequest);

        CustomerBOResponse Update(CustomerBORequest customerBORequest);

        CustomerBOResponse GetById(int id);
    }
}
