using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResourceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceApplication.Controllers
{
    public class EmployeeController : Controller
    {
       
        public IEmployeeService EmployeeService { get; set; }

        public EmployeeController( IEmployeeService employeeService)
        {
            
            EmployeeService = employeeService;
        }

        public IActionResult Index()
        {
           // var displayData = _DbContext.EmployeeTable.ToList();
           var displayData = EmployeeService.GetEmployees();
            return View(displayData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {

               // await  _DbContext.EmployeeTable.AddAsync(employee);



               // await  _DbContext.SaveChangesAsync();

               EmployeeService.AddEmployee(employee);

                return RedirectToAction("Index");

            }

            return View(employee);


        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
               return RedirectToAction("Index");
            }

            //var employee = await _DbContext.EmployeeTable.SingleOrDefaultAsync(x => x.EmployeeId == id);

            var employee = EmployeeService.GetEmployee(id);
            return View(employee);

        }

        [HttpPost]
        public  IActionResult Edit(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {

               // _DbContext.Update(employee);
              //  await _DbContext.SaveChangesAsync();

                EmployeeService.UpdateEmployee(employee);

                return RedirectToAction("Index");

            }

            return View(employee);


        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            //var employee = await _DbContext.EmployeeTable.SingleOrDefaultAsync(x => x.EmployeeId == id);

            var employee = EmployeeService.GetEmployee(id);
            return View(employee);

        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            //var employee = await _DbContext.EmployeeTable.SingleOrDefaultAsync(x => x.EmployeeId == id);

            var employee = EmployeeService.GetEmployee(id);
            return View(employee);

        }


        [HttpPost]
        public IActionResult Delete(int id)
        {

            EmployeeService.DeleteEmployee(id);
            return RedirectToAction("Index")
                ;
        }

    }
}
