using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Interfaces.INotificationsServices {
    public interface ISetNotificationServices {
        public void SetNotification(string ReqID, string type_id, int toUserID, int OwnerUserID, DateTime Time);
        public void SetNotificationForDepartment(string ReqID, string type_id, int DepartmentID, int OwnerUserID, DateTime Time);
    }
}
