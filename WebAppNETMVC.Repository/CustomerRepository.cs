using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppNETMVC.Data;

namespace WebAppNETMVC.Repository
{
    public class CustomerRepository : Repository<customer>, ICustomerRepository
    {
        public CustomerRepository(BikeStoresContext bikeStoresContext) : base(bikeStoresContext)
        {
        }
    }
}
