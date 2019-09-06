using CRUDUsingEFCore.Models;
using CRUDUsingEFCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CRUDUsingEFCore.Controllers
{
    public class HomeController : Controller
    {

        #region Variable Declarations
        private readonly AppDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public HomeController(IEmployeeRepository employeeRepository, AppDbContext context)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Index method
        // GET: Home
        public IActionResult Index() => View(_employeeRepository.GetAllEmployees());
        #endregion

        #region Details method
        // GET: Home/Details
        public IActionResult Details(int id) => View(_employeeRepository.GetEmployee(id));
        #endregion

        #region Save method
        // GET: Home/Save
        public IActionResult Save(int id)
        {
            ViewBag.DepartmentId = _context.Departments.Select(e => new SelectListItem()
            {
                Value = e.Id.ToString(),
                Text = e.Name.ToString()
            });

            var emp = _employeeRepository.GetEmployee(id);
            if (emp == null)
                emp = new Employee();

            return View(emp);
        }

        // POST: Home/Save
        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", _employeeRepository.SaveEmployee(employee));
            }
            return View(employee);
        }
        #endregion

        #region Delete method
        // GET: Home/Delete
        public IActionResult Delete(int id) => View(_employeeRepository.GetEmployee(id));

        // POST: Home/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id) => RedirectToAction("Index", _employeeRepository.DeleteEmployee(id));
        #endregion
    }
}
