using AutoMapper;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppNETMVC.DTO;
using WebAppNETMVC.Filters;
using WebAppNETMVC.IService;
using WebAppNETMVC.Repository;

namespace WebAppNETMVC.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
        //private readonly ILoginRepository _loginRepository;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        // private readonly BikeStoresContext _bikeStoresContext;

        public LoginController(ILoginRepository loginRepository, IMapper mapper, ILoginService loginService)//(BikeStoresContext bikeStoresContext, IMapper mapper)//(ILoginRepository loginRepository,IMapper mapper)
        {
            // _loginRepository = loginRepository;
            _loginService = loginService;
            _mapper = mapper;
            //_bikeStoresContext = bikeStoresContext;
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserBORequest userBORequest)
        {
            if (ModelState.IsValid)
            {
                UserBOResponse userBOResponse = _loginService.SignUp(userBORequest);
                if (userBOResponse != null)
                    return RedirectToAction("Index", "Login");
                else
                    return View();
            }
            else
            {
                return View();
            }
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginBORequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LoginBORequest loginBORequest)
        {
            if (ModelState.IsValid)
            {
                //var loginRequest = _mapper.Map<LoginRequest>(loginBORequest);
                var result = _loginService.ValidateUser(loginBORequest);
                //var result = _loginRepository.ValidateUser(loginBORequest);
                var response = _mapper.Map<LoginBOResponse>(result);
                if (response.status_code == 1)
                {
                    TempData["user"] = response;
                    //Inbuild forms authentication cookie which will be validated by [Authorize]
                    FormsAuthentication.SetAuthCookie(response.username, false);

                    //! Manually created cookie,
                    //x HttpCookie httpCookie = new HttpCookie("cookie");
                    //x httpCookie.Values.Add("username", response.username);
                    //x httpCookie.Values.Add("id", response.user_id.ToString());
                    //x Response.Cookies.Add(httpCookie);

                    //Session["user"] = response.user_id;
                    return RedirectToAction("Index", "Customer");
                }
                else if (response.status_code == 0)
                {
                    ViewBag.error = response.status_description;
                    //ModelState.AddModelError("", "invalid Username or Password");
                    return View();
                }
                else //if (response.status_code == -1)
                {
                    ViewBag.error = response.status_description;
                    //ModelState.AddModelError("", "invalid Username or Password");
                    return View();
                }
            }
            else
            {

                return View();
            }



        }
    }
}