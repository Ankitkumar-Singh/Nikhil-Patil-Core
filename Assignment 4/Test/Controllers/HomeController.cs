using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.RepositoryInterfaces;

namespace Test.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        #region Variable declarations
        /// <summary>The employee repository</summary>
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="HomeController"/> class.</summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public HomeController(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;
        #endregion

        #region Displays all employees
        /// <summary>Indexes this instance.</summary>
        [Route("/")]
        [Route("")]
        [Route("Index")]
        public IActionResult Index() => View(_employeeRepository.GetAllEmployees());
        #endregion

        #region Details method
        /// <summary>Detailses the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [Route("Details/{id?}")]
        public IActionResult Details(int id) => View(_employeeRepository.GetEmployee(id));
        #endregion

        #region Save method
        [HttpGet]
        [Route("Save/{id?}")]
        public IActionResult Save(int? id) => View(_employeeRepository.GetEmployee(id));

        [HttpPost]
        public RedirectToActionResult Save(Employee employee) => RedirectToAction("Index", _employeeRepository.SaveEmployee(employee));
        #endregion

        #region Delete method
        /// <summary>Deletes the specified employee.</summary>
        /// <param name="id">The identifier.</param>
        [HttpGet]
        [Route("Delete/{id?}")]
        public IActionResult Delete(int id) => View(_employeeRepository.GetEmployee(id));

        /// <summary>Confirms delete operation.</summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        public RedirectToActionResult DeleteConfirm(int id) => RedirectToAction("Index", _employeeRepository.DeleteEmployee(id));
        #endregion
    }
}