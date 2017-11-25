using BHIP.Model;
using BHIP.Model.Helper;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHIP.Controllers
{
    public class CustomReportsController : BaseController
    {
        // GET: Admin/CustomReports
        public ActionResult Index()
        {
           // LoginCaptureHelper.InsertCaptureDetails("CustomReports");
            // check to see if the user has logged in. If not get them out of here.
            if (!Security.IsValid("/customreports"))
            {
                return Redirect("~/");
            }

            CustomReportsViewModel model = new CustomReportsViewModel();
            model.CustomReportGridList = model.GetCustomReports(0, 10);
            return View(model);
        }

        public ActionResult AjaxPageGrid(int id, int? page = 0)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            CustomReportsViewModel model = new CustomReportsViewModel();


            model.CustomReportGridList = model.GetCustomReports(page ?? 0, 10);

            return PartialView("_Grid", model);
        }
        public ActionResult AjaxPage(int id, int? page, int size = 10, string sortOrder = "")
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            CustomReportsViewModel model = new CustomReportsViewModel();
            model.PageSize = size;
            model.CustomReportGridList = model.GetCustomReports(currentPageIndex, 10);


            return PartialView("_Grid", model);
        }
        public ActionResult RefreshReportGrid()
        {
            CustomReportsViewModel model = new CustomReportsViewModel();

            model.CustomReportGridList = model.GetCustomReports(0, 10);

            return PartialView("_Grid", model);
        }
        public ActionResult FilterReportGrid(string id)
        {
            CustomReportsViewModel model = new CustomReportsViewModel();

            model.CustomReportGridList = model.GetCustomReports(0, 10, id);

            return PartialView("_Grid", model);
        }
        public ActionResult RunReport(int id)
        {
            var data = (from custom in ContextPerRequest.CurrentData.CustomParams
                        where custom.CustomReportID == id
                        select custom);

            if (data == null)
            {
                // report doesn't have parameters so go run it.
                CustomReportRun(id);
                return RedirectToAction("CustomReports");
            }
            else
            {
                CustomReportsViewModel model = new CustomReportsViewModel();

                return View(model.GetCustomReport(id));
            }
        }

        public ActionResult ExecuteReport(int CustomReportID, List<string> ParamValue, List<string> ParamType, List<string> ParamName)
        {
            CustomReportRun(CustomReportID, ParamValue, ParamType, ParamName);

            return RedirectToAction("CustomReports");
        }

        public void CustomReportRun(int id, List<string> ParamValue = null, List<string> ParamType = null, List<string> ParamName = null)
        {
            string sqlCommand = string.Empty;

            var data = (from reports in ContextPerRequest.CurrentData.CustomReports
                        where reports.CustomReportID == id
                        select reports).FirstOrDefault();


            if (data != null)
            {
                String strConnString = ConfigurationManager.ConnectionStrings["DoQuery"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader rdr = null;

                sqlCommand = data.ReportQuery;

                if (ParamValue != null)
                {
                    for (int i = 0; i < ParamValue.Count(); i++)
                    {
                        if (ParamType[i] == "Year")
                        {
                            sqlCommand = sqlCommand.Replace("{" + ParamName[i] + "}", ParamValue[i]);
                        }
                        else if (ParamType[i] == "String")
                        {
                            sqlCommand = sqlCommand.Replace("{" + ParamName[i] + "}", "'" + ParamValue[i] + "'");
                        }
                        else if (ParamType[i] == "Integer")
                        {
                            sqlCommand = sqlCommand.Replace("{" + ParamName[i] + "}", ParamValue[i]);
                        }
                        else if (ParamType[i] == "DropDown")
                        {
                            sqlCommand = sqlCommand.Replace("{" + ParamName[i] + "}", ParamValue[i]);
                        }
                        else if (ParamType[i] == "Date")
                        {
                            sqlCommand = sqlCommand.Replace("{" + ParamName[i] + "}", "Convert(datetime, '" + ParamValue[i] + "')");
                        }
                        else
                        {
                            sqlCommand = sqlCommand.Replace("{" + ParamName[i] + "}", "'" + ParamValue[i] + "'");
                        }
                    }
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCommand;
                cmd.Connection = con;

                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();


                    using (var pck = new ExcelPackage())
                    {
                        // Add a new worksheet to the empty workbook
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                        // Load data from DataTable to the worksheet
                        ws.Cells["A1"].LoadFromDataReader((rdr), true);
                        ws.Cells.AutoFitColumns();

                        // Add some styling
                        using (ExcelRange rng = ws.Cells[1, 1, 1, rdr.FieldCount])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        Response.AddHeader("content-disposition", "attachment;filename=" + Guid.NewGuid().ToString() + ".xlsx");
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.BinaryWrite(pck.GetAsByteArray());
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            else
            {
                Response.End();
            }
        }
    }
}