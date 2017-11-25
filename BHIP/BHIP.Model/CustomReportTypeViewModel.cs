using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcPaging;

namespace BHIP.Model
{
    public class CustomReportTypeGrid
    {
        public int CustomReportTypeID { get; set; }
        public string Description { get; set; }
    }

    public class CustomReportTypeViewModel
    {
        public int CustomReportTypeID { get; set; }
        public string Description { get; set; }
        public DateTime DateDeleted { get; set; }
        public bool IsActive { get; set; }
        public IPagedList<CustomReportTypeGrid> CustomReportTypeGridList { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
        public string[] SelectedRoles { get; set; }

        public IPagedList<CustomReportTypeGrid> GetCustomReportType(int currentPageIndex, int defaultPageSize)
        {
            IPagedList<CustomReportTypeGrid> customData = null;

            var dataGrid = (from custom in ContextPerRequest.CurrentData.CustomReportTypes
                            where custom.IsActive == true
                            select new CustomReportTypeGrid
                            {
                                CustomReportTypeID = custom.CustomReportTypeID,
                                Description = custom.Description
                            }
                            );
            customData = dataGrid.OrderBy(x => new { x.Description }).ToPagedList(currentPageIndex, defaultPageSize);
            return customData;

        }

        public CustomReportTypeViewModel GetACustomReportType(int id)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomReportTypes
                        where custom.CustomReportTypeID == id && custom.IsActive == true
                        select new CustomReportTypeViewModel
                        {
                            CustomReportTypeID = custom.CustomReportTypeID,
                            Description = custom.Description
                        }).FirstOrDefault();

            data.RolesList = GetEditRoles(id);

            return data;
        }

        public void AddCustomType(CustomReportTypeViewModel model)
        {
            CustomReportType custom = new CustomReportType
            {
                Description = model.Description,
                IsActive = true
            };

            ContextPerRequest.CurrentData.CustomReportTypes.Add(custom);
            ContextPerRequest.CurrentData.SaveChanges();

            SaveRoles(custom.CustomReportTypeID, model.SelectedRoles);
        }

        public void EditParamType(CustomReportTypeViewModel model)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomReportTypes
                        where custom.CustomReportTypeID == model.CustomReportTypeID
                        select custom).FirstOrDefault();

            if (data != null)
            {
                data.Description = model.Description;

                ContextPerRequest.CurrentData.SaveChanges();

                SaveRoles(model.CustomReportTypeID, model.SelectedRoles);
            }
        }

        public void DeleteCustomType(int customReportTypeId)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomReportTypes
                        where custom.CustomReportTypeID == customReportTypeId
                        select custom).FirstOrDefault();

            if (data != null)
            {
                data.DateDeleted = DateTime.Now;
                data.IsActive = false;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetEditRoles(int customReportTypeId)
        {
            var customTypes = (from custom in ContextPerRequest.CurrentData.CustomRoles
                               where custom.CustomReportTypeID == customReportTypeId
                               select custom.RoleId).ToList();

            IEnumerable<SelectListItem> returnValue;

            var query = (from roles in ContextPerRequest.CurrentData.AspNetRoles
                         select roles);

            returnValue = query.ToList().Select(u => new SelectListItem
            {
                Selected = customTypes.Contains(u.Id),
                Text = u.Name,
                Value = u.Id
            });

            return returnValue;
        }

        public void SaveRoles(int customReportTypeId, string[] selectedRoles)
        {
            var dataDeleteMenuRoles = (from roles in ContextPerRequest.CurrentData.CustomRoles
                                       where roles.CustomReportTypeID == customReportTypeId
                                       select roles);
            foreach (var item in dataDeleteMenuRoles)
            {

                ContextPerRequest.CurrentData.CustomRoles.Remove(item);
            }
            ContextPerRequest.CurrentData.SaveChanges();

            foreach (string item in selectedRoles)
            {
                CustomRole customRole = new CustomRole
                {
                    CustomReportTypeID = customReportTypeId,
                    RoleId = item
                };

                ContextPerRequest.CurrentData.CustomRoles.Add(customRole);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

    }
}