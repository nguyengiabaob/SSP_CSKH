using CSKH_SSP.DataModels;
using CSKH_SSP.Helpers;
using CSKH_SSP.Interfaces.IIncidentRequestServices;
using System.Linq;

namespace CSKH_SSP.Services.IncidentRequestServices
{
    public class IncidentRequestServices : IIncidentRequestServices
    {

        readonly DataContext _dataContext;

        public IncidentRequestServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int AddIncident(RequestIncident requestIncident)
        {
            _dataContext.RequestIncident.Add(requestIncident);
            return _dataContext.SaveChanges();
            //return 1;
        }

        public RequestIncident GetRequestIncident(string requestId)
        {
            return _dataContext.RequestIncident.Where(x => x.RequestId == requestId).FirstOrDefault();
            //return 1;
        }


    }
}
