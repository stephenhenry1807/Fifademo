using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/EA")]
    //[Authorize(Roles = "Admin")]
    public class EAController : Controller
    {

        //[Authorize(Roles = "Admin")]
        public string ApiSearch()
        {
            var url = "https://www.easports.com/fifa/ultimate-team/api/fut/item";

            var textFromFile = (new System.Net.WebClient()).DownloadString(url);

            return textFromFile;
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet("{search}")]
        public IActionResult ApiSearch([FromRoute] string search)
        {

            var url = "https://www.easports.com/fifa/ultimate-team/api/fut/item";
            var searcha = "?name='" + search;

            var urlsearch = url + searcha;

            var textFromFile = (new System.Net.WebClient()).DownloadString(urlsearch);

            return Content(textFromFile);
        }

    }
}