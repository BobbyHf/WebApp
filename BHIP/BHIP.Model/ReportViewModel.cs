using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BHIP.Model.Helper;

namespace BHIP.Model
{
    public class ReportViewModel
    {
        public int ReportID { get; set; }
        public int AgreementNumber { get; set; }
        [Display(Name = "Report Type")]
        public int? ReportTypeID { get; set; }
        public string ReportTypeName { get; set; }
        [Display(Name = "Report Name")]
        public string ReportName { get; set; }
        [Display(Name = "Report Title")]
        public string ReportTitle { get; set; }
        [Display(Name = "Report Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ContactName { get; set; }
        public int DistID { get; set; }

        public IEnumerable<ReportParamViewModel> ParamList { get; set; }

        public IEnumerable<SelectListItem> ReportList { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }

        public ReportViewModel()
        {
            CustomDistrictList = GetCustomDistrictList();
        }
        public ReportViewModel(int id)
        {
            ReportList = GetReportsByType(id, 0);
        }

        public ReportViewModel(int id, int rptID)
        {
            ReportID = rptID;

            ReportList = GetReportsByType(id, rptID);
            if (rptID > 0)
            {
                GetReport(rptID);
                ParamList = GetReportParams(rptID);
            }
        }

        public IEnumerable<SelectListItem> GetReportsByType(int ReportTypeID, int reportID)
        {
            IEnumerable<SelectListItem> returnValue;
            string userId = HttpContext.Current.User.Identity.GetUserId();


            var dataReport = from Reports in ContextPerRequest.CurrentData.ReportTrusts
                             join trustReportRole in ContextPerRequest.CurrentData.ReportRoles on Reports.ReportID equals trustReportRole.ReportId
                             where Reports.ReportTypeID == ReportTypeID &&
                             (from user in ContextPerRequest.CurrentData.AspNetUsers where user.Id == userId && user.AspNetRoles.Any(r => r.Id == trustReportRole.RoleId) select user.Id).Contains(userId)
                             orderby Reports.ReportTitle
                             select new
                             {
                                 ReportID = Reports.ReportID,
                                 ReportTitle = Reports.ReportTitle
                             };

            returnValue = dataReport.ToList().Select(u => new SelectListItem
            {
                Text = u.ReportTitle,
                Value = u.ReportID.ToString(),
                Selected = (u.ReportID == reportID)

            });

            return returnValue;
        }

        public IEnumerable<SelectListItem> GetReporTypes(int reportTypeID)
        {
            IEnumerable<SelectListItem> returnValue;

            var dataReportType = from reportType in ContextPerRequest.CurrentData.ReportTypes
                                 orderby reportType.TypeName
                                 select new
                                 {
                                     ReportTypeID = reportType.ReportTypeID,
                                     ReportTypeName = reportType.TypeName
                                 };
            returnValue = dataReportType.ToList().Select(u => new SelectListItem
            {
                Text = u.ReportTypeName,
                Value = u.ReportTypeID.ToString(),
                Selected = (u.ReportTypeID == reportTypeID)
            });

            return returnValue;
        }

        public ReportViewModel GetReport(ReportViewModel model)
        {
            var dataReport = (from Reports in ContextPerRequest.CurrentData.ReportTrusts
                              where Reports.ReportID == model.ReportID
                              select Reports).FirstOrDefault();
            model.ReportID = dataReport.ReportID;
            model.ReportTypeID = dataReport.ReportTypeID;
            model.ReportName = dataReport.ReportName;
            model.ReportTitle = dataReport.ReportTitle;
            model.Description = dataReport.Description;

            return model;
        }

        public void GetReport(int reportId)
        {
            var dataReport = (from Reports in ContextPerRequest.CurrentData.ReportTrusts
                              where Reports.ReportID == reportId
                              select Reports).FirstOrDefault();
            ReportID = dataReport.ReportID;
            ReportTypeID = dataReport.ReportTypeID;
            ReportName = dataReport.ReportName;
            ReportTitle = dataReport.ReportTitle;
            Description = dataReport.Description;
        }
        public IEnumerable<ReportParamViewModel> GetReportParams(int ReportID)
        {
            return from RptParams in ContextPerRequest.CurrentData.ReportParams
                   join RptParamTypes in ContextPerRequest.CurrentData.ReportParamTypes
                   on RptParams.ReportParamTypeID equals RptParamTypes.ReportParamTypeID
                   where RptParams.ReportID == ReportID
                   orderby RptParams.DisplayOrder
                   select new ReportParamViewModel
                   {
                       ParamDescription = RptParamTypes.Description,
                       ParamName = RptParams.ParamName,
                       ParamTitle = RptParams.ParamTitle,
                       ParamWidth = RptParams.ParamWidth ?? 0,
                       ReportParamID = RptParams.ReportParamID,
                       DropSQL = RptParams.DropSQL
                   };
        }

        public IEnumerable<ReportViewModel> GetReports()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();

            return from reports in ContextPerRequest.CurrentData.ReportTrusts
                   join reportType in ContextPerRequest.CurrentData.ReportTypes
                   on reports.ReportTypeID equals reportType.ReportTypeID
                   orderby reportType.TypeName
                   select new ReportViewModel
                   {
                       ReportID = reports.ReportID,
                       ReportTypeName = reportType.TypeName,
                       ReportName = reports.ReportName,
                       ReportTitle = reports.ReportTitle,
                       Description = reports.Description
                   };
        }
        public IEnumerable<SelectListItem> GetData(string sqlStatement)
        {
            IEnumerable<SelectListItem> returnValue;

            string[] list = new string[1];

            var dataData = ContextPerRequest.CurrentData.Database.SqlQuery<ReportDropDownn>(sqlStatement, list);

            returnValue = dataData.ToList().Select(u => new SelectListItem
            {
                Text = u.Text,
                Value = u.Value.ToString()

            });

            return returnValue;
        }

        public IEnumerable<SelectListItem> GetRoles()
        {
            IEnumerable<SelectListItem> returnValue;

            var query = (from roles in ContextPerRequest.CurrentData.AspNetRoles
                         select roles);

            returnValue = query.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id
            });

            //return new SelectList(query, "Id", "Name" );
            return returnValue;

        }

        public IEnumerable<SelectListItem> GetEditRoles(int reportId)
        {
            var menuRoles = (from reportRoles in ContextPerRequest.CurrentData.ReportRoles
                             where reportRoles.ReportId == reportId
                             select reportRoles.RoleId).ToList();

            IEnumerable<SelectListItem> returnValue;

            var query = (from roles in ContextPerRequest.CurrentData.AspNetRoles
                         select roles);

            returnValue = query.ToList().Select(u => new SelectListItem
            {
                Selected = menuRoles.Contains(u.Id),
                Text = u.Name,
                Value = u.Id
            });

            return returnValue;
        }

        public void SaveEditReportRoles(int reportId, string[] selectedRoles)
        {
            var dataDeleteMenuRoles = (from roles in ContextPerRequest.CurrentData.ReportRoles
                                       where roles.ReportId == reportId
                                       select roles);
            foreach (var item in dataDeleteMenuRoles)
            {

                ContextPerRequest.CurrentData.ReportRoles.Remove(item);
            }
            ContextPerRequest.CurrentData.SaveChanges();

            foreach (string item in selectedRoles)
            {
                ReportRole reportRole = new ReportRole
                {
                    ReportId = reportId,
                    RoleId = item
                };

                ContextPerRequest.CurrentData.ReportRoles.Add(reportRole);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> DistrictInformationSelect { get; set; }

        public IEnumerable<SelectListItem> CustomDistrictList { get; set; }

        public IEnumerable<SelectListItem> GetCustomDistrictList()
        {
            //var agreementNumber = Security.GetAgreementNumber();
            var agreementNumber = 0;
            IEnumerable<SelectListItem> returnValue;


            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select One", Selected = false });

            if (agreementNumber > 998)
            {
                //returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
                //var dataDistricts = from DistrictInfo in ContextPerRequest.CurrentData.DistrictInformations
                //                    where DistrictInfo.DistStatus == "Current" && DistrictInfo.AgreementNumber < 900
                //                    orderby DistrictInfo.District
                //                    select DistrictInfo;
                //returnValue = dataDistricts.ToList().Select(u => new SelectListItem
                //{
                //    Text = u.District,
                //    Value = u.AgreementNumber.ToString()
                //});
            }
            else if (agreementNumber == 998)
            {
                //string userId = HttpContext.Current.User.Identity.GetUserId();
                //var contactName = HttpContext.Current.User.Identity.GetFullName(userId);

                //returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
                //var dataDistricts = from DistrictInfo in ContextPerRequest.CurrentData.DistrictInformations
                //                    where DistrictInfo.DistStatus == "Current" && DistrictInfo.AIRContact == contactName
                //                    orderby DistrictInfo.District
                //                    select DistrictInfo;
                //returnValue = dataDistricts.ToList().Select(u => new SelectListItem
                //{
                //    Text = u.District,
                //    Value = u.AgreementNumber.ToString()
                //});
            }
            else
            {
                //returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
                //var dataDistricts = from DistrictInfo in ContextPerRequest.CurrentData.DistrictInformations
                //                    where DistrictInfo.DistStatus == "Current" && DistrictInfo.AgreementNumber == agreementNumber
                //                    orderby DistrictInfo.District
                //                    select DistrictInfo;
                //returnValue = dataDistricts.ToList().Select(u => new SelectListItem
                //{
                //    Text = u.District,
                //    Value = u.AgreementNumber.ToString()
                //});
            }

            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            return returnValue;
        }

    }

    public class ReportParamViewModel
    {
        public int ReportParamID { get; set; }
        [Display(Name = "Parameter Name")]
        [Required(ErrorMessage = "Please enter the parameter name")]
        public string ParamName { get; set; }
        [Required(ErrorMessage = "Please enter the parameter name")]
        [Display(Name = "Parameter Title")]
        public string ParamTitle { get; set; }
        [Required(ErrorMessage = "Please enter the parameter width")]
        [Display(Name = "Parameter Width")]
        public int ParamWidth { get; set; }
        [Display(Name = "SQL Statement")]
        [DataType(DataType.MultilineText)]
        public string DropSQL { get; set; }
        [Display(Name = "Parameter Description")]
        [DataType(DataType.MultilineText)]
        public string ParamDescription { get; set; }
        public int ReportID { get; set; }
        public int ReportParamTypeID { get; set; }
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
        public IEnumerable<ReportParamType> ParamTypeList { get; set; }

        public string CallType { get; set; }


        public IEnumerable<SelectListItem> GetParamTypes()
        {
            IEnumerable<SelectListItem> returnValue;

            var dataReportParamType = from reportParamType in ContextPerRequest.CurrentData.ReportParamTypes
                                      orderby reportParamType.Description
                                      select new
                                      {

                                          ReportParamTypeID = reportParamType.ReportParamTypeID,
                                          Description = reportParamType.Description
                                      };
            returnValue = dataReportParamType.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.ReportParamTypeID.ToString(),
                Selected = (u.ReportParamTypeID == ReportParamTypeID)
            });

            return returnValue;
        }

        public ReportParam GetReportParam(int reportParamId)
        {
            var dataReportPar = (from reportParam in ContextPerRequest.CurrentData.ReportParams
                                 where reportParam.ReportParamID == reportParamId
                                 select reportParam).FirstOrDefault();

            return dataReportPar;
        }
    }

    public class ReportDropDownn
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}

