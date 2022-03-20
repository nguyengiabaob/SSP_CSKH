using CSKH_SSP.DataModels;

namespace CSKH_SSP.Interfaces.IIncidentRequestServices
{
    public interface IIncidentRequestServices
    {
        public int AddIncident(RequestIncident requestIncident);
        public RequestIncident GetRequestIncident(string requestId);
    }
}
