using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHIP.Model.Helper
{
    public class UserHelper
    {
        public static IEnumerable<SelectListItem> GetMembers(int memberId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");
            var dataMembers = from members in ContextPerRequest.CurrentData.Members
                              where members.TerminatedDate == null
                              orderby members.Name ascending
                              select members;
            returnValue = dataMembers.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.MemberId.ToString(),
                Selected = (u.MemberId == memberId)
            });

            return returnValue;
        }  
    }
}