using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class PendingScheduleViewModel
    {
        public int MemberCoverageID { get; set; }
        public string Name { get; set; }
        public int CountPsychiatry { get; set; }
        public int CountProperty { get; set; }
        public int CountPrimaryCare { get; set; }
        public int CountVehicle { get; set; }
        public int CountDriverInfo { get; set; }

        public int CountOtherSchedules { get; set; }
        public IEnumerable<PendingScheduleViewModel> GetPendingSchedules()
        {
            var query = (from cov in ContextPerRequest.CurrentData.MemberCoverages
                         join mem in ContextPerRequest.CurrentData.Members on cov.MemberId equals mem.MemberId
                         select new PendingScheduleViewModel
                         {
                             MemberCoverageID = mem.MemberId,
                             Name = mem.Name,
                             CountPrimaryCare = (from primary in ContextPerRequest.CurrentData.PrimaryCareScheduleHolds
                                                 where primary.MemberCoverageID == cov.MemberCoverageID && primary.ScheduleStatusID != 4 && primary.ScheduleStatusID != 5
                                                 select primary.MemberCoverageID).Count(),
                             CountPsychiatry = (from psychiatry in ContextPerRequest.CurrentData.PsychiatryScheduleHolds
                                                where psychiatry.MemberCoverageID == cov.MemberCoverageID && psychiatry.ScheduleStatusID != 4 && psychiatry.ScheduleStatusID != 5
                                                select psychiatry.PsychiatryScheduleHoldID).Count(),
                             CountProperty = (from property in ContextPerRequest.CurrentData.PropertyScheduleHolds
                                              where property.MemberCoverageID == cov.MemberCoverageID && property.ScheduleStatusID != 4 && property.ScheduleStatusID != 5
                                              select property.PropertyScheduleHoldID).Count(),
                             CountVehicle = (from vehicles in ContextPerRequest.CurrentData.VehicleScheduleHolds
                                             where vehicles.MemberCoverageID == cov.MemberCoverageID && vehicles.ScheduleStatusID != 4 && vehicles.ScheduleStatusID != 5
                                             select vehicles.VehicleScheduleHoldID).Count(),
                             CountDriverInfo = (from driver in ContextPerRequest.CurrentData.DriverInfoScheduleHolds
                                                where driver.MemberCoverageID == cov.MemberCoverageID && driver.ScheduleStatusID != 4 && driver.ScheduleStatusID != 5
                                                select driver.DriverInfoScheduleHoldID).Count(),
                             CountOtherSchedules = (from driver in ContextPerRequest.CurrentData.OtherScheduleHolds
                                                    where driver.MemberCoverageID == cov.MemberCoverageID && driver.ScheduleStatusID != 4 && driver.ScheduleStatusID != 5
                                                    select driver.OtherScheduleHoldID).Count()
                         });

            return query;
        }

        public void VehicleApprove(string scheduleIds)
        {
            List<string> listPremiseID = new List<string>();

            //if (scheduleIds.Length > 0)
            //{
            //    listPremiseID = scheduleIds.Split(',').ToList();

            //    foreach (var item in listPremiseID)
            //    {
            //        int scheduleID = Convert.ToInt32(item.ToString());

            //        var query = (from vehicle in ContextPerRequest.CurrentData.VehicleScheduleHolds
            //                     where vehicle.VehicleScheduleHoldID == premiseID
            //                     select vehicle).FirstOrDefault();
            //        if (query != null)
            //        {
            //            query.RespParty = Security.GetUserIDRByID(query.AuthorUserID);
            //            query.StatusID = 4; // Final
            //            ContextPerRequest.Current.SaveChanges();
            //        }
            //    }
            //}

        }

    }
}