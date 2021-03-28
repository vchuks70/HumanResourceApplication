using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResourceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceApplication.Controllers
{
    public class MediaController : Controller
    {
        public MediaController(IMediaStackService mediaStackService)
        {
            MediaStackService = mediaStackService;
        }

        public IMediaStackService MediaStackService { get; set; }
        public async  Task<IActionResult> Index()
        {
            var result = await MediaStackService.GetData();
            return View(result);
        }
    }
}
