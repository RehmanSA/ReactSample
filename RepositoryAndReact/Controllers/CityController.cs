using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleDAL.Model.Repository.Contracts;

namespace RepositoryAndReact.Controllers
{
    public class CityController : Controller
    {
        private readonly ICity _cityRepository;

        public CityController(ICity CityRepository)
        {
            _cityRepository = CityRepository;
        }
        [HttpGet]
        [Route("api/City/CityInformations")]
        public IEnumerable<dynamic> CityInformations()
        {
            return _cityRepository.GetAllRecords();
        }
    }
}