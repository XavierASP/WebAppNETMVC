using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;
using WebAppNETMVC.IService;
using WebAppNETMVC.Repository;

namespace WebAppNETMVC.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public IMapper _mapper { get; }

        public CustomerService(ICustomerRepository customerRepository,IMapper mapper) 
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderByField"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public CustomerBOResponseWithPaging GetAll(int pageIndex = 0, int pageSize = 10, string orderByField = "", string orderBy = "")
        {
            var customers = _customerRepository.GetAll();
            

            switch (orderBy.ToUpper())
            {
                case "ASC":
                    switch (orderByField.ToUpper())
                    {
                        case "FIRSTNAME":
                            customers = customers.OrderBy(customer => customer.first_name);
                            break;
                        case "LASTNAME":
                            customers = customers.OrderBy(customer => customer.last_name);
                            break;
                        case "PHONE":
                            customers = customers.OrderBy(customer => customer.phone);
                            break;
                        case "EMAIL":
                            customers = customers.OrderBy(customer => customer.email);
                            break;
                        case "STREET":
                            customers = customers.OrderBy(customer => customer.street);
                            break;
                        case "CITY":
                            customers = customers.OrderBy(customer => customer.city);
                            break;
                        case "STATE":
                            customers = customers.OrderBy(customer => customer.state);
                            break;
                    }
                    break;
                case "DESC":
                    switch (orderByField.ToUpper())
                    {
                        case "FIRSTNAME":
                            customers = customers.OrderByDescending(customer => customer.first_name);
                            break;
                        case "LASTNAME":
                            customers = customers.OrderByDescending(customer => customer.last_name);
                            break;
                        case "PHONE":
                            customers = customers.OrderByDescending(customer => customer.phone);
                            break;
                        case "EMAIL":
                            customers = customers.OrderByDescending(customer => customer.email);
                            break;
                        case "STREET":
                            customers = customers.OrderByDescending(customer => customer.street);
                            break;
                        case "CITY":
                            customers = customers.OrderByDescending(customer => customer.city);
                            break;
                        case "STATE":
                            customers = customers.OrderByDescending(customer => customer.state);
                            break;
                    }
                    break;
                default:
                    customers = customers.OrderBy(customer => customer.first_name);
                    break;
            }
            if (pageIndex < 0) 
            {
                pageIndex = 0;
            }
            if (pageIndex >= Math.Ceiling(Convert.ToDecimal(customers.Count()) / pageSize) )
            {
                pageIndex = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(customers.Count()) / pageSize))-1;
            }

            var pagingCustomers = (from customer in customers select customer).
                Skip(pageIndex * pageSize).
                Take(pageSize);

            var customersDTO = _mapper.Map<IEnumerable<CustomerBOResponse>>(pagingCustomers);

            var lsCustomersDTO = new CustomerBOResponseWithPaging();
            lsCustomersDTO.Customers = customersDTO;
            lsCustomersDTO.TotalCount = customers.Count();
            lsCustomersDTO.PageIndex = pageIndex;
            lsCustomersDTO.PageSize = pageSize;

            return lsCustomersDTO;
        }

        public CustomerBOResponse GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return _mapper.Map<CustomerBOResponse>(customer);
        }
        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public CustomerBOResponse Add(CustomerBORequest customerBORequest)
        {
            var customerRequest = _mapper.Map<customer>(customerBORequest);
            customer customer = _customerRepository.Add(customerRequest);
            return _mapper.Map<CustomerBOResponse>(customer);
        }

        public CustomerBOResponse Update(CustomerBORequest customerBORequest)
        {
            var customerRequest = _mapper.Map<customer>(customerBORequest);
            var customer = _customerRepository.Update(customerRequest);
            return _mapper.Map<CustomerBOResponse>(customer);
        }
    }
}
