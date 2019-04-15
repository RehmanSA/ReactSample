using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleDAL.Model;
using SampleDAL.Model.Repository.Contracts;

namespace RepositoryAndReact.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<dynamic> Index()
        {
            return _employeeRepository.GetAllRecords();
        }
        [HttpPost]
        [Route("api/Employee/Create")]
        public TblEmployee Create(TblEmployee employee)
        {
            return _employeeRepository.Create(employee);
        }
        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public TblEmployee Details(int id)
        {
            return _employeeRepository.GetById(id);
        }
        [HttpPut]
        [Route("api/Employee/Edit")]
        public TblEmployee Edit(TblEmployee employee)
        {
            return _employeeRepository.Update(employee);
        }
        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public bool Delete(int id)
        {
            var result = _employeeRepository.GetById(id);
            _employeeRepository.Delete(result);
            return true;
        }
    }
}