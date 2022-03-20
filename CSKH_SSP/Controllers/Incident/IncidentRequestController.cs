using CSKH_SSP.DataModels;
using CSKH_SSP.Interfaces.IIncidentRequestServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSKH_SSP.Controllers.IncidentRequest
{
    [Authorize]
    public class IncidentRequestController : Controller
    {

        private readonly IIncidentRequestServices _incidentServices;

        public IncidentRequestController(IIncidentRequestServices incidentServices)
        {
            _incidentServices = incidentServices;
        }

        [Authorize]
        [HttpPost]
        public int AddIncident(RequestIncident incident)
        {

            return _incidentServices.AddIncident(incident);
        }


        public int Test(string id)
        {
            var a = id;
            return 1;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
