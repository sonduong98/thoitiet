using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WEB.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        protected int GetId(string title)
        {
            if (string.IsNullOrEmpty(title)) return 0;
            var idText = "0" + title.Substring(title.LastIndexOf('-') + 1);
            if (!idText.All(char.IsDigit)) return 0;
            return int.Parse(idText);
        }
    }
}