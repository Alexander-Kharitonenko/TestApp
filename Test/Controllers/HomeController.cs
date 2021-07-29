using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabase DataContext;
        public HomeController(IDatabase dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AllItems()
        {
            ViewModel model = new ViewModel() { AllItems = await DataContext.GetAlltems() };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddItems()
        {
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItems(ViewModelForForm request)
        {
            bool result = await DataContext.AddNewItems(request.Name);
            if (result)
            {
                return RedirectToAction(nameof(AllItems));
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteItems()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItems(ViewModelForForm request)
        {
            ConcurrentDictionary<Guid, string> AllEntity = await DataContext.GetAlltems();
            KeyValuePair<Guid, string> result = AllEntity.FirstOrDefault(el => el.Value.Contains(request.Name));
            if (result.Value != null) 
            {
              var isValid = await DataContext.RemoveByIndex(result.Key);
                if (isValid) 
                {
                    return RedirectToAction(nameof(AllItems));
                }
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateItems()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItems(ViewModelForForm request)
        {
            ConcurrentDictionary<Guid, string> AllEntity = await DataContext.GetAlltems();
            KeyValuePair<Guid, string> result = AllEntity.FirstOrDefault(el => el.Value.Contains(request.comparisonName));
            if (result.Value != null)
            {
                var isValid = await DataContext.UpdateByIndex(result.Key, request.Name , request.comparisonName);
                if (isValid)
                {
                    return RedirectToAction(nameof(AllItems));
                }
            }
            return View(request);
        }
    }
}
