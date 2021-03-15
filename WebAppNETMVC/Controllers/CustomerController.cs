using AutoMapper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppNETMVC.DTO;
using WebAppNETMVC.IService;
using WebAppNETMVC.Repository;

namespace WebAppNETMVC.Controllers
{
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
        public ActionResult Add(CustomerBORequest customerBORequest)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.Add(customerBORequest);
                ViewBag.Message = "Added Successfully.";
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
                ViewBag.Message = "Updated Successfully.";
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
            ViewBag.Message = "Deleted Successfully.";
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
        public ActionResult Index(int pageIndex = 0, int pageSize = 10, string orderByField = "", string orderBy = "")
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

            return View();
            //return PartialView("_Customers");

        }
    }
}