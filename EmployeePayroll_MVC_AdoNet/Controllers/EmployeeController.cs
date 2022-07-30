namespace EmployeePayroll_MVC_AdoNet.Controllers
{
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ModelLayer.EmployeeModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeController : Controller
    {
        IEmpBL empBL;

        public EmployeeController(IEmpBL empBL)
        {
            this.empBL = empBL;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            List<GetAllEmployeeModel> emps = new List<GetAllEmployeeModel>();
            emps = empBL.GetAllEmployee().ToList();
            return View(emps);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(AddEmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                empBL.AddEmployee(emp);

                return RedirectToAction("Index");
            }

            return View(emp);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult UpdateEmployee(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            GetAllEmployeeModel emp = empBL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(int id, GetAllEmployeeModel getAllEmployeeModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    getAllEmployeeModel.Emp_Id = id;
                    empBL.UpdateEmployee(getAllEmployeeModel);
                    return RedirectToAction("Index");
                }
                return View(getAllEmployeeModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        [HttpGet]
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            GetAllEmployeeModel emp = empBL.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                    empBL.DeleteEmployee(id);
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
