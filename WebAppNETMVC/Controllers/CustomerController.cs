using AutoMapper;
using System;
using System.Web.Mvc;
using System.Web.Security;
using WebAppNETMVC.DTO;
using WebAppNETMVC.Filters;
using WebAppNETMVC.IService;

namespace WebAppNETMVC.Controllers
{
    [UserExceptionFilter]
    //[HandleError(View ="Error", ExceptionType = typeof(NotImplementedException))]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;



        //private readonly BikeStoresEntities bikeStoresEntities;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
            //bikeStoresEntities = new BikeStoresEntities();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [Authorize]
        public void LogOut() 
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        [Authorize]
        public ActionResult Add([Bind(Exclude = "customer_id")] CustomerBORequest customerBORequest)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.Add(customerBORequest);

                //!Key-Information
                //!Commenting because viewbag is used to transfer data from action methods to view only, it can used to transfer data from one action methods to another.
                //!The scope of ViewBag is permitted to the current request and the value of ViewBag will become null while redirecting.
                //Todo: Need to change to TempData
                //x ViewBag.Message = "Added Successfully.";
                TempData["Message"] = "Added Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                //return new HttpNotFoundResult(Convert.ToString(HttpStatusCode.NotFound));
                return View();
            }
            else
            {
                return View(customer);
            }
            
        }

        [Authorize]
        public ActionResult Edit(CustomerBORequest customerBORequest)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.Update(customerBORequest);
                TempData["Message"] = "Updated Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(CustomerBORequest customerBORequest)
        {
            _customerService.Delete(customerBORequest.customer_id);
            TempData["Message"] = "Deleted Successfully.";
            return RedirectToAction("Index");
        }
        /// <summary>
        /// To get the customer list
        /// (Note: Authorize attribute is required while using the forms authentication, if authorize attribute is not used then this action will be called without login.)
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderByField"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        // GET: Customer
        [Authorize]
        public ActionResult Index(int pageIndex = 0, int pageSize = 10, string orderByField = "", string orderBy = "", bool isPartial = false)
        {
            //When user clicks on the table header, need to sort the data
            if (!string.IsNullOrEmpty(orderBy) && orderBy == "ASC")
            {
                ViewBag.OrderBy = "DESC";
                orderBy = ViewBag.OrderBy;
            }
            else if (!string.IsNullOrEmpty(orderBy) && orderBy == "DESC")
            {
                ViewBag.OrderBy = "ASC";
                orderBy = ViewBag.OrderBy;
            }
            //Data will be in ascending format when it will be loaded for the first time.
            else
            {
                ViewBag.OrderBy = "ASC";
                orderBy = ViewBag.OrderBy;
                orderByField = "FIRSTNAME";
            }


            var customers = _customerService.GetAll(pageIndex, pageSize, orderByField, orderBy);

            var user = TempData["user"] as LoginBOResponse;

            ViewData["Customers"] = customers;
            ViewData["User"] = user;
            ViewBag.TotalCount = customers.TotalCount;
            ViewBag.PageIndex = customers.PageIndex;
            ViewBag.PageSize = customers.PageSize;
            //isPartial? return PartialView("_Customer",customers):return View();
            if (isPartial)
            {
                return PartialView("_Customer");
            }
            
            else 
            {
                return View();
            }
            
            //return PartialView("_Customers");

        }
    }
}