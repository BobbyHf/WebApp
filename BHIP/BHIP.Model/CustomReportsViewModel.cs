
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using Microsoft.AspNet.Identity;
namespace BHIP.Model
{
    public class CustomParamViewModel
    {
        public int CustomParamID { get; set; }
        public int CustomReportID { get; set; }
        [Display(Name = "Parameter Type:")]
        [Required(ErrorMessage = "Enter the parameter type")]
        public int CustomParamTypeID { get; set; }
        [Display(Name = "Parameter Name:")]
        [Required(ErrorMessage = "Enter the parameter name")]
        public string ParamName { get; set; }
        [Display(Name = "Parameter Title:")]
        [Required(ErrorMessage = "Enter the parameter title")]
        public string ParamTitle { get; set; }
        [Display(Name = "Parameter Width:")]
        public int ParamWidth { get; set; }
        [Display(Name = "Display Order:")]
        public int DisplayOrder { get; set; }
        [Display(Name = "SQL Statement:")]
        public string DropSQL { get; set; }
        public string PropType { get; set; }

        public IEnumerable<CustomParamGrid> GetParamGridList(int customReportId)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomParams
                        where custom.CustomReportID == customReportId
                        orderby custom.DisplayOrder
                        select new CustomParamGrid
                        {
                            CustomParamID = custom.CustomParamID,
                            ParamName = custom.ParamName,
                            ParamTitle = custom.ParamTitle
                        });

            return data;
        }

        public IEnumerable<CustomParamViewModel> GetParamList(int customReportId)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomParams
                        join param in ContextPerRequest.CurrentData.CustomParamTypes
                        on custom.CustomParamTypeID equals param.CustomParamTypeID
                        where custom.CustomReportID == customReportId
                        orderby custom.DisplayOrder
                        select new CustomParamViewModel
                        {
                            CustomParamTypeID = custom.CustomParamTypeID,
                            CustomReportID = custom.CustomReportID,
                            DisplayOrder = custom.DisplayOrder ?? 0,
                            DropSQL = custom.DropSQL,
                            ParamWidth = custom.ParamWidth ?? 0,
                            CustomParamID = custom.CustomParamID,
                            ParamName = custom.ParamName,
                            ParamTitle = custom.ParamTitle,
                            PropType = param.Description
                        });

            return data;
        }

        public IEnumerable<SelectListItem> GetParameterTypeSelect(int customParamTypeId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select One", Selected = true });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataCustom = from custom in ContextPerRequest.CurrentData.CustomParamTypes
                             where custom.IsActive == true
                             orderby custom.Description
                             select custom;
            returnValue = dataCustom.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.CustomParamTypeID.ToString(),
                Selected = (u.CustomParamTypeID == customParamTypeId)
            });

            return returnValue;

        }

        public CustomParamViewModel GetCustomParam(int customParamId)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomParams
                        where custom.CustomParamID == customParamId
                        select new CustomParamViewModel
                        {
                            CustomParamID = custom.CustomParamID,
                            CustomParamTypeID = custom.CustomParamTypeID,
                            CustomReportID = custom.CustomReportID,
                            DisplayOrder = custom.DisplayOrder ?? 0,
                            DropSQL = custom.DropSQL,
                            ParamName = custom.ParamName,
                            ParamTitle = custom.ParamTitle,
                            ParamWidth = custom.ParamWidth ?? 0
                        }).FirstOrDefault();

            return data;
        }

        public void AddParameter(CustomParamViewModel model)
        {
            CustomParam param = new CustomParam
            {
                CustomParamTypeID = model.CustomParamTypeID,
                CustomReportID = model.CustomReportID,
                DisplayOrder = model.DisplayOrder,
                DropSQL = model.DropSQL,
                ParamName = model.ParamName,
                ParamTitle = model.ParamTitle,
                ParamWidth = model.ParamWidth
            };

            ContextPerRequest.CurrentData.CustomParams.Add(param);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void DeleteParameter(int id)
        {
            var data = (from param in ContextPerRequest.CurrentData.CustomParams
                        where param.CustomParamID == id
                        select param).FirstOrDefault();

            if (data != null)
            {
                ContextPerRequest.CurrentData.CustomParams.Remove(data);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void EditParamter(CustomParamViewModel model)
        {
            var data = (from param in ContextPerRequest.CurrentData.CustomParams
                        where param.CustomParamID == model.CustomParamID
                        select param).FirstOrDefault();

            if (data != null)
            {
                data.CustomParamTypeID = model.CustomParamTypeID;
                data.CustomReportID = model.CustomReportID;
                data.DisplayOrder = model.DisplayOrder;
                data.DropSQL = model.DropSQL;
                data.ParamName = model.ParamName;
                data.ParamTitle = model.ParamTitle;
                data.ParamWidth = model.ParamWidth;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

    }

    public class CustomParamGrid
    {
        public int CustomParamID { get; set; }
        public string ParamName { get; set; }
        public string ParamTitle { get; set; }
    }

    public class CustomParamTypeGrid
    {
        public int CustomParamTypeID { get; set; }
        public string Description { get; set; }

        public void GetParamGird(int customReportId)
        {

        }
    }
    public class CustomParamTypeViewModel
    {
        public int CustomParamTypeID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DeletedDate { get; set; }
        public IPagedList<CustomParamTypeGrid> CustomParamTypeGridList { get; set; }
        public int PageSize { get; set; }


        public IPagedList<CustomParamTypeGrid> GetCustomParamType(int currentPageIndex, int defaultPageSize)
        {
            IPagedList<CustomParamTypeGrid> customData = null;

            var dataGrid = (from custom in ContextPerRequest.CurrentData.CustomParamTypes
                            where custom.IsActive == true
                            select new CustomParamTypeGrid
                            {
                                CustomParamTypeID = custom.CustomParamTypeID,
                                Description = custom.Description
                            }
                            );
            customData = dataGrid.OrderBy(x => new { x.Description }).ToPagedList(currentPageIndex, defaultPageSize);
            return customData;

        }

        public CustomParamTypeViewModel GetACustomParamType(int id)
        {
            var data = (from param in ContextPerRequest.CurrentData.CustomParamTypes
                        where param.CustomParamTypeID == id && param.IsActive == true
                        select new CustomParamTypeViewModel
                        {
                            CustomParamTypeID = param.CustomParamTypeID,
                            Description = param.Description
                        }).FirstOrDefault();

            return data;
        }

        public void AddParamType(CustomParamTypeViewModel model)
        {
            CustomParamType custom = new CustomParamType
            {
                Description = model.Description,
                IsActive = true
            };

            ContextPerRequest.CurrentData.CustomParamTypes.Add(custom);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void EditParamType(CustomParamTypeViewModel model)
        {
            var data = (from param in ContextPerRequest.CurrentData.CustomParamTypes
                        where param.CustomParamTypeID == model.CustomParamTypeID
                        select param).FirstOrDefault();

            if (data != null)
            {
                data.Description = model.Description;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void DeleteParamType(int customParamTypeId)
        {
            var data = (from param in ContextPerRequest.CurrentData.CustomParamTypes
                        where param.CustomParamTypeID == customParamTypeId
                        select param).FirstOrDefault();

            if (data != null)
            {
                data.DateDeleted = DateTime.Now;
                data.IsActive = false;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
    }
    public class CustomReportGrid
    {
        public int CustomReportID { get; set; }
        public int CustomReportTypeID { get; set; }
        public string ReportName { get; set; }
        public DateTime DateCreated { get; set; }


    }
    public class CustomReportsViewModel
    {
        public int CustomReportID { get; set; }
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Enter the report name")]
        public string ReportName { get; set; }
        [Display(Name = "Query:")]
        [Required(ErrorMessage = "Enter the report query")]
        public string ReportQuery { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
        [Display(Name = "Active?:")]
        public bool IsActive { get; set; }
        [Display(Name = "Report Type:")]
        [Required(ErrorMessage = "Select report type")]
        public int CustomReportTypeID { get; set; }

        public IPagedList<CustomReportGrid> CustomReportGridList { get; set; }
        public int PageSize { get; set; }
        public string CustomReportTypeSelected { get; set; }
        public IEnumerable<SelectListItem> CustomReportTypeSelect { get; set; }
        public IEnumerable<CustomParamGrid> ParamGridList { get; set; }
        public IEnumerable<CustomParamViewModel> ParamList { get; set; }
        public IPagedList<CustomReportGrid> GetCustomReports(int currentPageIndex, int defaultPageSize, string ids = "")
        {
            IPagedList<CustomReportGrid> customData = null;

            string userId = HttpContext.Current.User.Identity.GetUserId();

            IQueryable<CustomReportGrid> dataGrid;

            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                if ((ids + "").Length > 0)
                {
                    List<int> reportTypes = ids.Split(',').Select(int.Parse).ToList();
                    dataGrid = (from custom in ContextPerRequest.CurrentData.CustomReports
                                where reportTypes.Contains(custom.CustomReportTypeID ?? 0) && custom.IsActive == true
                                select new CustomReportGrid
                                {
                                    CustomReportID = custom.CustomReportID,
                                    DateCreated = custom.DateCreated,
                                    ReportName = custom.ReportName
                                }
                                    ).Distinct();
                }
                else
                {
                    dataGrid = (from custom in ContextPerRequest.CurrentData.CustomReports
                                where custom.IsActive == true
                                select new CustomReportGrid
                                {
                                    CustomReportID = custom.CustomReportID,
                                    DateCreated = custom.DateCreated,
                                    ReportName = custom.ReportName
                                }
                                    ).Distinct();
                }
            }
            else
            {
                dataGrid = (from custom in ContextPerRequest.CurrentData.CustomReports
                            join roles in ContextPerRequest.CurrentData.CustomRoles on custom.CustomReportTypeID equals roles.CustomReportTypeID
                            where ((from user in ContextPerRequest.CurrentData.AspNetUsers where user.Id == userId && user.AspNetRoles.Any(r => r.Id == roles.RoleId) select user.Id).Contains(userId)
                            && custom.IsActive == true)
                            select new CustomReportGrid
                            {
                                CustomReportID = custom.CustomReportID,
                                DateCreated = custom.DateCreated,
                                ReportName = custom.ReportName
                            }
                                ).Distinct();
            }
            customData = dataGrid.OrderBy(x => new { x.ReportName }).ToPagedList(currentPageIndex, defaultPageSize);
            return customData;

        }

        public CustomReportsViewModel GetCustomReport(int customReportId)
        {

            var data = (from custom in ContextPerRequest.CurrentData.CustomReports
                        where custom.CustomReportID == customReportId
                        select new CustomReportsViewModel
                        {
                            CustomReportID = custom.CustomReportID,
                            DateCreated = custom.DateCreated,
                            DateDeleted = custom.DateDeleted,
                            ReportName = custom.ReportName,
                            ReportQuery = custom.ReportQuery,
                            IsActive = custom.IsActive,
                            CustomReportTypeID = custom.CustomReportTypeID ?? 0
                        }
                            ).FirstOrDefault();
            CustomParamViewModel modelParam = new CustomParamViewModel();

            data.ParamGridList = modelParam.GetParamGridList(customReportId);
            data.ParamList = modelParam.GetParamList(customReportId);

            return data;
        }

        public IEnumerable<SelectListItem> GetCustomReportTypeSelect(int customReportTypeId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select One", Selected = true });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataCustom = from custom in ContextPerRequest.CurrentData.CustomReportTypes
                             where custom.IsActive == true
                             orderby custom.Description
                             select custom;
            returnValue = dataCustom.ToList().Select(u => new SelectListItem
            {
                Text = u.Description,
                Value = u.CustomReportTypeID.ToString(),
                Selected = (u.CustomReportTypeID == customReportTypeId)

            });

            return returnValue;

        }

        public void AddCustomReport(CustomReportsViewModel model)
        {
            CustomReport report = new CustomReport
            {
                DateCreated = DateTime.Now,
                IsActive = true,
                ReportName = model.ReportName,
                ReportQuery = model.ReportQuery,
                CustomReportTypeID = model.CustomReportTypeID
            };

            ContextPerRequest.CurrentData.CustomReports.Add(report);
            ContextPerRequest.CurrentData.SaveChanges();
        }

        public void EditCustomReport(CustomReportsViewModel model)
        {
            var data = (from report in ContextPerRequest.CurrentData.CustomReports
                        where report.CustomReportID == model.CustomReportID
                        select report).FirstOrDefault();

            if (data != null)
            {
                data.IsActive = model.IsActive;
                data.ReportName = model.ReportName;
                data.ReportQuery = model.ReportQuery;
                data.CustomReportTypeID = model.CustomReportTypeID;
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void DeleteCustomReport(int id)
        {
            var data = (from report in ContextPerRequest.CurrentData.CustomReports
                        where report.CustomReportID == id
                        select report).FirstOrDefault();

            if (data != null)
            {
                ContextPerRequest.CurrentData.CustomReports.Remove(data);
                ContextPerRequest.CurrentData.SaveChanges();
            }
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
    }
}