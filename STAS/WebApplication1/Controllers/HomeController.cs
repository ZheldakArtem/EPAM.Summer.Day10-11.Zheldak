using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Model1 contex=new Model1();
            Message d=new Message()
            {
                MessageId = 1,
                Date = DateTime.Now,
                Text = "wef",
                UserFrom = new User(),
                UserTo = new User()
           
            };
            
            contex.Messages.Add(d);
            return View();
        }
    }
}