using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShowApp.WebUI.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public IActionResult Add(int ShowId,string UserId,string Content)
        {
            return Redirect("/Home/Index");
        }
    }
}