using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace BHIP.Model.Helper
{
    public static class QuestionHelper
    {

        public static MvcHtmlString DisplayQuestions(this HtmlHelper htmlHelper, string sectionName, int currentYear, int memberId, string questionName)
        {
            QuestionsViewModel model = new QuestionsViewModel();

            // get the section information.
            QuestionSectionViewModel sectionModel = new QuestionSectionViewModel();
            sectionModel = model.GetQuestionSection(sectionName);

            // the top level div tag
            TagBuilder divBuilder = new TagBuilder("div");

            // the section name div tag
            TagBuilder divSectionName = new TagBuilder("div");

            // check to see if there is a question description to add.
            if (sectionModel != null)
            {
                if (sectionModel.SectionText != null)
                {
                    divSectionName.InnerHtml += sectionModel.SectionText;
                    divBuilder.InnerHtml += divSectionName.ToString();
                }
            }
            else
            {
                divSectionName.InnerHtml += string.Empty;
                divBuilder.InnerHtml += divSectionName.ToString();
            }

            // the question section header text.
            TagBuilder divSectionHeader = new TagBuilder("div");

            // check to see if there is header text to add.
            if (sectionModel != null)
            {
                if (sectionModel.HeaderText != null)
                {
                    divSectionHeader.InnerHtml += sectionModel.HeaderText;
                    divBuilder.InnerHtml += divSectionHeader.ToString();
                }
            }
            else
            {
                divSectionHeader.InnerHtml += string.Empty;
                divBuilder.InnerHtml += divSectionHeader.ToString();
            }

            //IEnumerable<QuestionsViewModel> questions = model.GetQuestions(sectionModel.QuestionSectionID, currentYear, memberId);

            //HtmlTable htmlTable = new HtmlTable();
            TagBuilder htmlTable = new TagBuilder("table");
            htmlTable.MergeAttribute("width", "100%");
            //htmlTable.Width = "100%";
            int rowCount = 0;

            foreach (var item in model.GetQuestions(sectionModel.QuestionSectionID, currentYear, memberId))
            {
                //HtmlTableRow rows = new HtmlTableRow();
                TagBuilder rows = new TagBuilder("tr");

                //HtmlInputHidden col1Hidden = new HtmlInputHidden();
                TagBuilder col1Hidden = new TagBuilder("input");
                col1Hidden.MergeAttribute("type", "hidden");
                col1Hidden.MergeAttribute("value", item.QuestionID.ToString());
                //col1Hidden.Value = item.QuestionID.ToString();

                //HtmlTableCell column1 = new HtmlTableCell();
                TagBuilder column1 = new TagBuilder("td");
                column1.Attributes.Add("class", "nodisplay");
                column1.InnerHtml += col1Hidden;

                //HtmlTableCell column2 = new HtmlTableCell();
                TagBuilder column2 = new TagBuilder("td");
                column2.Attributes.Add("class", "nodisplay");
                column2.InnerHtml += item.QuestionID.ToString();

                //HtmlTableCell column3 = new HtmlTableCell();
                TagBuilder column3 = new TagBuilder("td");
                if (item.QuestionNumber == null)
                {
                    column3.InnerHtml += string.Empty;
                }
                else
                {
                    column3.InnerHtml += item.QuestionNumber + ".";
                }

                //HtmlTableCell column4 = new HtmlTableCell();
                TagBuilder column4 = new TagBuilder("td");
                if (item.QuestionType != "LTB")
                {
                    if (item.QuestionNumber == null)
                    {
                        TagBuilder spanCol4 = new TagBuilder("span");
                        spanCol4.MergeAttribute("class", "QuestionTextItalic");
                        spanCol4.InnerHtml += item.Question;
                        column4.InnerHtml += spanCol4;
                    }
                    else
                    {
                        TagBuilder spanCol4 = new TagBuilder("span");
                        if (item.Class != null)
                        {
                            spanCol4.MergeAttribute("class", "QuestionText " + item.Class);
                        }
                        else
                        {
                            spanCol4.MergeAttribute("class", "QuestionText");
                        }
                        spanCol4.InnerHtml = item.Question;
                        column4.InnerHtml += spanCol4;
                    }

                }

                TagBuilder column5 = new TagBuilder("td");

                if (item.QuestionType == "DD")
                {
                    // do a drop down list.
                    string[] dropDown = item.DropDown.ToString().Split('|');

                    TagBuilder selectBuilder = new TagBuilder("select");
                    selectBuilder.GenerateId(questionName + "[" + rowCount + "].ControlValue");
                    selectBuilder.MergeAttribute("name", questionName + "[" + rowCount + "].ControlValue", true);

                    if (item.IsRequired)
                    {
                        selectBuilder.MergeAttribute("data-val", "true");
                        selectBuilder.MergeAttribute("data-val-required", "*");
                    }

                    if (item.Class != null)
                    {
                        selectBuilder.MergeAttribute("class", "form-control  error-block " + item.Class);
                    }
                    else
                    {
                        selectBuilder.MergeAttribute("class", "form-control  error-block");
                    }

                    StringBuilder optionsBuilder = new StringBuilder();

                    foreach (var textItem in dropDown)
                    {
                        TagBuilder optionBuilder = new TagBuilder("option");
                        object itemValue = textItem;
                        object itemKey = textItem;

                        optionBuilder.MergeAttribute("value", itemValue.ToString());
                        optionBuilder.SetInnerText(itemKey.ToString());

                        if (textItem == item.Answer)
                        {
                            optionBuilder.MergeAttribute("selected", "selected");
                        }
                        optionsBuilder.AppendLine(MvcHtmlString.Create(
                            optionBuilder.ToString(TagRenderMode.Normal)).ToString());
                    }

                    selectBuilder.InnerHtml = optionsBuilder.ToString();
                    //selDropDown.Name = questionName + "[" + rowCount + "].ControlValue";
                    //selDropDown.ID = questionName + "_" + rowCount + "_ControlValue";
                    //selDropDown.Attributes.Add("value", dropDown[0]);
                    //selDropDown.Attributes.Add("data-val", "true");
                    //selDropDown.Attributes.Add("data-val-required", "*");

                    column5.InnerHtml += selectBuilder;

                    TagBuilder questionHidden = new TagBuilder("input");
                    questionHidden.MergeAttribute("type", "hidden");
                    questionHidden.MergeAttribute("id", questionName + "_" + rowCount + "_ControlId");
                    questionHidden.MergeAttribute("name", questionName + "[" + rowCount + "].ControlId");
                    questionHidden.MergeAttribute("value", item.QuestionID.ToString());
                    column5.InnerHtml += questionHidden;

                    if (item.IsRequired)
                    {
                        TagBuilder spanQuestionError = new TagBuilder("span");
                        spanQuestionError.MergeAttribute("class", "field-validation-valid");
                        spanQuestionError.MergeAttribute("data-valmsg-for", questionName + "[" + rowCount + "].ControlValue");
                        spanQuestionError.MergeAttribute("data-valmsg-replace", "true");
                        column5.InnerHtml += spanQuestionError;
                    }

                }
                else if (item.QuestionType == "YN" && item.QuestionNumber != null) // the question is a radio button with a number assigned to it.
                {
                    TagBuilder radQuestionYes = new TagBuilder("input");
                    radQuestionYes.MergeAttribute("class", "QuestionRadio");
                    radQuestionYes.MergeAttribute("name", questionName + "[" + rowCount + "].ControlValue");
                    radQuestionYes.MergeAttribute("id", questionName + "[" + rowCount + "].ControlValue");
                    radQuestionYes.MergeAttribute("value", "Yes");
                    radQuestionYes.MergeAttribute("type", "radio");

                    if (item.IsRequired)
                    {
                        radQuestionYes.MergeAttribute("data-val", "true");
                        radQuestionYes.MergeAttribute("data-val-required", "*");
                    }

                    if (item.Answer == "Yes")
                    {
                        radQuestionYes.MergeAttribute("checked", "true");
                    }
                    column5.InnerHtml += radQuestionYes;

                    TagBuilder spanQuestionYes = new TagBuilder("span");
                    spanQuestionYes.InnerHtml = "&nbsp;Yes&nbsp;";
                    column5.InnerHtml += spanQuestionYes;

                    TagBuilder radQuestionNo = new TagBuilder("input");

                    if (item.Class != null)
                    {
                        radQuestionNo.MergeAttribute("class", "QuestionRadio " + item.Class);
                    }
                    else
                    {
                        radQuestionNo.MergeAttribute("class", "QuestionRadio");
                    }
                    radQuestionNo.MergeAttribute("name", questionName + "[" + rowCount + "].ControlValue");
                    radQuestionNo.MergeAttribute("id", questionName + "[" + rowCount + "].ControlValue");
                    radQuestionNo.MergeAttribute("value", "No");

                    if (item.Answer == "No")
                    {
                        radQuestionYes.MergeAttribute("checked", "true");
                    }
                    column5.InnerHtml += radQuestionYes;

                    TagBuilder spanQuestionNo = new TagBuilder("span");
                    spanQuestionNo.InnerHtml = "&nbsp;No&nbsp;";
                    column5.InnerHtml += spanQuestionNo;

                    if (item.IsRequired)
                    {
                        TagBuilder spanQuestionError = new TagBuilder("span");
                        spanQuestionError.MergeAttribute("class", "field-validation-valid");
                        spanQuestionError.MergeAttribute("data-valmsg-for", questionName + "[" + rowCount + "].ControlValue");
                        spanQuestionError.MergeAttribute("data-valmsg-replace", "true");
                        column5.InnerHtml += spanQuestionError;
                    }

                    TagBuilder questionHidden = new TagBuilder("input");
                    questionHidden.MergeAttribute("type", "hidden");
                    questionHidden.MergeAttribute("id", questionName + "_" + rowCount + "_ControlId");
                    questionHidden.MergeAttribute("name", questionName + "[" + rowCount + "].ControlId");
                    questionHidden.MergeAttribute("value", item.QuestionID.ToString());
                    column5.InnerHtml += questionHidden;
                }
                else if (item.QuestionType == "YN" && item.QuestionNumber == null) // the question is a radio button without a number assigned to it.
                {
                    TagBuilder radQuestionYes = new TagBuilder("input");
                    radQuestionYes.MergeAttribute("Name", questionName + "[" + rowCount + "].ControlValue");
                    radQuestionYes.MergeAttribute("Value", "Yes");
                    radQuestionYes.MergeAttribute("Type", "radio");

                    if (item.Class != null)
                    {
                        radQuestionYes.MergeAttribute("class", "QuestionRadio");
                    }
                    else
                    {
                        radQuestionYes.MergeAttribute("class", "QuestionRadio");
                    }
                    radQuestionYes.MergeAttribute("id", questionName + "[" + rowCount + "].ControlValue");

                    if (item.IsRequired)
                    {
                        radQuestionYes.MergeAttribute("data-val", "true");
                        radQuestionYes.MergeAttribute("data-val-required", "*");
                    }

                    if (item.Answer == "Yes")
                    {
                        //radQuestionYes.Checked = true;
                        radQuestionYes.MergeAttribute("Checked", "True");
                    }
                    column5.InnerHtml += radQuestionYes;

                    TagBuilder spanQuestionYes = new TagBuilder("span");
                    spanQuestionYes.InnerHtml = "&nbsp;Yes&nbsp;";
                    column5.InnerHtml += spanQuestionYes;

                    TagBuilder radQuestionNo = new TagBuilder("input");
                    radQuestionNo.MergeAttribute("Name", questionName + "[" + rowCount + "].ControlValue");
                    radQuestionNo.MergeAttribute("Value", "No");
                    radQuestionNo.MergeAttribute("Type", "radio");

                    if (item.Class != null)
                    {
                        radQuestionNo.MergeAttribute("class", "QuestionRadio " + item.Class);
                    }
                    else
                    {
                        radQuestionNo.MergeAttribute("class", "QuestionRadio");
                    }
                    radQuestionNo.MergeAttribute("id", questionName + "[" + rowCount + "].ControlValue");

                    if (item.Answer == "No")
                    {
                        radQuestionNo.MergeAttribute("Checked", "True");
                    }
                    column5.InnerHtml += radQuestionNo;

                    TagBuilder spanQuestionNo = new TagBuilder("span");
                    spanQuestionNo.InnerHtml = "&nbsp;No&nbsp;";
                    column5.InnerHtml += spanQuestionNo;

                    if (item.IsRequired)
                    {
                        TagBuilder spanQuestionError = new TagBuilder("span");
                        spanQuestionError.MergeAttribute("class", "field-validation-valid");
                        spanQuestionError.MergeAttribute("data-valmsg-for", questionName + "[" + rowCount + "].ControlValue");
                        spanQuestionError.MergeAttribute("data-valmsg-replace", "true");
                        column5.InnerHtml += spanQuestionError;
                    }

                    TagBuilder questionHidden = new TagBuilder("input");
                    questionHidden.MergeAttribute("type", "hidden");
                    questionHidden.MergeAttribute("id", questionName + "_" + rowCount + "_ControlId");
                    questionHidden.MergeAttribute("name", questionName + "[" + rowCount + "].ControlId");
                    questionHidden.MergeAttribute("value", item.QuestionID.ToString());
                    column5.InnerHtml += questionHidden;

                }
                else if (item.QuestionType == "TB" && item.QuestionNumber != null) // the question is a text box with a number assigned to it.
                {
                    TagBuilder questionHidden = new TagBuilder("input");
                    questionHidden.MergeAttribute("type", "hidden");
                    questionHidden.MergeAttribute("id", questionName + "_" + rowCount + "_ControlId");
                    questionHidden.MergeAttribute("name", questionName + "[" + rowCount + "].ControlId");
                    questionHidden.MergeAttribute("value", item.QuestionID.ToString());
                    column5.InnerHtml += questionHidden;


                    TagBuilder txtQuestion = new TagBuilder("input");

                    if (item.Class != null)
                    {
                        txtQuestion.MergeAttribute("class", "QuestionText form-control " + item.Class);
                    }
                    else
                    {
                        txtQuestion.MergeAttribute("class", "QuestionText form-control");
                    }
                    txtQuestion.MergeAttribute("id", questionName + "_" + rowCount + "_ControlValue");
                    txtQuestion.MergeAttribute("name", questionName + "[" + rowCount + "].ControlValue");
                    txtQuestion.MergeAttribute("value", (item.Answer == null ? "" : item.Answer));
                    if (item.IsRequired)
                    {
                        txtQuestion.MergeAttribute("data-val", "true");
                        txtQuestion.MergeAttribute("data-val-required", "*");
                    }

                    column5.InnerHtml += txtQuestion;

                    if (item.IsRequired)
                    {
                        TagBuilder spanQuestionError = new TagBuilder("span");
                        spanQuestionError.Attributes.Add("class", "field-validation-valid");
                        spanQuestionError.Attributes.Add("data-valmsg-for", questionName + "[" + rowCount + "].ControlValue");
                        spanQuestionError.Attributes.Add("data-valmsg-replace", "true");
                        column5.InnerHtml += spanQuestionError;
                    }

                }
                else if (item.QuestionType == "TB" && item.QuestionNumber == null) // the question is a text box without a number assigned to it.
                {
                    TagBuilder questionHidden = new TagBuilder("input");
                    questionHidden.MergeAttribute("type", "hidden");
                    questionHidden.MergeAttribute("id", questionName + "_" + rowCount + "_ControlId");
                    questionHidden.MergeAttribute("name", questionName + "[" + rowCount + "].ControlId");
                    questionHidden.MergeAttribute("value", item.QuestionID.ToString());
                    column5.InnerHtml += questionHidden;

                    TagBuilder txtQuestion = new TagBuilder("input");

                    if (item.Class != null)
                    {
                        txtQuestion.MergeAttribute("class", "QuestionText form-control " + item.Class);
                    }
                    else
                    {
                        txtQuestion.MergeAttribute("class", "QuestionText form-control");
                    }
                    txtQuestion.MergeAttribute("id", questionName + "[" + rowCount + "].ControlValue");
                    txtQuestion.MergeAttribute("name", questionName + "[" + rowCount + "].ControlValue");
                    txtQuestion.MergeAttribute("value", (item.Answer == null ? "" : item.Answer));

                    if (item.IsRequired)
                    {
                        txtQuestion.MergeAttribute("data-val", "true");
                        txtQuestion.MergeAttribute("data-val-required", "*");
                    }

                    column5.InnerHtml += txtQuestion;

                    if (item.IsRequired)
                    {
                        TagBuilder spanQuestionError = new TagBuilder("span");
                        spanQuestionError.Attributes.Add("class", "field-validation-valid");
                        spanQuestionError.Attributes.Add("data-valmsg-for", questionName + "[" + rowCount + "].ControlValue");
                        spanQuestionError.Attributes.Add("data-valmsg-replace", "true");
                        column5.InnerHtml += spanQuestionError;
                    }


                }
                else if (item.QuestionType == "BK") // no question, just print a blank row in the table.
                {
                    TagBuilder spanQuestionBlank = new TagBuilder("span");
                    spanQuestionBlank.InnerHtml = "&nbsp;";
                    column5.InnerHtml += spanQuestionBlank;

                }
                else if (item.QuestionType == "LTB" && item.QuestionNumber == null)
                {
                    TagBuilder questionHidden = new TagBuilder("input");
                    questionHidden.MergeAttribute("type", "hidden");
                    questionHidden.MergeAttribute("id", questionName + "_" + rowCount + "_ControlId");
                    questionHidden.MergeAttribute("name", questionName + "[" + rowCount + "].ControlId");
                    questionHidden.MergeAttribute("value", item.QuestionID.ToString());
                    column5.InnerHtml += questionHidden;

                    //HtmlInputText txtQuestion = new HtmlInputText("text");
                    //txtQuestion.Attributes.Add("type", "text");
                    //txtQuestion.Attributes.Add("class", "QuestionText");
                    //txtQuestion.Attributes.Add("style", "width:100%; margin-left: 20px;");
                    //txtQuestion.ID = questionName + "_" + rowCount + "_ControlValue";
                    //txtQuestion.Name = questionName + "[" + rowCount + "].ControlValue";
                    //txtQuestion.Attributes.Add("value", (item.Answer == null ? "" : item.Answer));
                    //txtQuestion.Attributes.Add("data-val", "true");
                    //txtQuestion.Attributes.Add("data-val-required", "*");
                    //column5.Controls.Add(txtQuestion);

                    TagBuilder txtQuestion = new TagBuilder("input");
                    txtQuestion.MergeAttribute("type", "text");

                    if (item.Class != null)
                    {
                        txtQuestion.MergeAttribute("class", "QuestionText form-control " + item.Class);
                    }
                    else
                    {
                        txtQuestion.MergeAttribute("class", "QuestionText form-control");
                    }
                    txtQuestion.MergeAttribute("style", "width:100%; margin-left: 20px;");
                    txtQuestion.MergeAttribute("id", questionName + "[" + rowCount + "].ControlValue");
                    txtQuestion.MergeAttribute("name", questionName + "[" + rowCount + "].ControlValue");
                    txtQuestion.MergeAttribute("value", (item.Answer == null ? "" : item.Answer));
                    if (item.IsRequired)
                    {
                        txtQuestion.MergeAttribute("data-val", "true");
                        txtQuestion.MergeAttribute("data-val-required", "*");
                    }

                    column5.InnerHtml += txtQuestion;

                    if (item.IsRequired)
                    {
                        TagBuilder spanQuestionError = new TagBuilder("span");
                        spanQuestionError.Attributes.Add("class", "field-validation-valid");
                        spanQuestionError.Attributes.Add("data-valmsg-for", questionName + "[" + rowCount + "].ControlValue");
                        spanQuestionError.Attributes.Add("data-valmsg-replace", "true");
                        column5.InnerHtml += spanQuestionError;
                    }


                }
                else if (item.QuestionType == "PTB" && item.QuestionNumber == null)
                {
                //    HtmlGenericControl questionHidden = new HtmlGenericControl("input");
                //    questionHidden.Attributes.Add("type", "hidden");
                //    questionHidden.Attributes.Add("id", questionName + "_" + rowCount + "_ControlId");
                //    questionHidden.Attributes.Add("name", questionName + "[" + rowCount + "].ControlId");
                //    questionHidden.Attributes.Add("value", item.QuestionID.ToString());
                //    column5.Controls.Add(questionHidden);

                //    HtmlInputText txtQuestion = new HtmlInputText("text");
                //    txtQuestion.Attributes.Add("type", "text");
                //    txtQuestion.Attributes.Add("class", "QuestionText");
                //    txtQuestion.Attributes.Add("style", "width:50px;text-align:right;");
                //    txtQuestion.ID = questionName + "_" + rowCount + "_ControlValue";
                //    txtQuestion.Name = questionName + "[" + rowCount + "].ControlValue";
                //    txtQuestion.Attributes.Add("value", (item.Answer == null ? "" : item.Answer));
                //    //txtQuestion.Attributes.Add("data-val", "true");
                //    //txtQuestion.Attributes.Add("data-val-required", "*");
                //    column5.Controls.Add(txtQuestion);

                //    HtmlGenericControl spanPercentage = new HtmlGenericControl("span");
                //    spanPercentage.InnerHtml = "%";
                //    column5.Controls.Add(spanPercentage);
                //    column5.Align = "right";

                }

                column5.MergeAttribute("valign", "top");

                rows.InnerHtml += column1;
                rows.InnerHtml += column2;
                rows.InnerHtml += column3;
                if (item.QuestionType != "LTB")
                {
                    rows.InnerHtml += column4;
                    column5.MergeAttribute("width", "15%");
                    column5.MergeAttribute("align", "right");
                }
                else
                {
                    column5.MergeAttribute("colspan", "2");
                }
                rows.InnerHtml += column5;

                htmlTable.InnerHtml += rows;

                if (item.QuestionType != "BK")
                {
                    rowCount++;
                }

            }


            divBuilder.InnerHtml += htmlTable;

            // the question section footer text.
            TagBuilder divSectionFooter = new TagBuilder("div");

            // check to see if there is footer text to add.
            if (sectionModel.FooterText != null)
            {
                divSectionFooter.InnerHtml += sectionModel.FooterText;
                divBuilder.InnerHtml += divSectionFooter.ToString();
            }

            return MvcHtmlString.Create(divBuilder.ToString(TagRenderMode.Normal).ToString());
        }

    }
}