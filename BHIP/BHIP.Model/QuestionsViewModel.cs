using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHIP.Model
{
    public class QuestionSectionViewModel
    {
        public int QuestionSectionID { get; set; }
        public string SectionName { get; set; }
        public int? SectionOrder { get; set; }
        public string SectionText { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
        public bool IsActive { get; set; }


    }
    public class QuestionsViewModel
    {
        public int QuestionID { get; set; }
        public int QuestionSectionID { get; set; }
        public int? QuestionNumber { get; set; }
        public int? QuestionOrder { get; set; }
        public string Question { get; set; }
        public string DropDown { get; set; }
        public string QuestionType { get; set; }
        public int AnswerID { get; set; }
        public string Answer { get; set; }

        public int MemberID { get; set; }
        public string SectionName { get; set; }
        public int CurrentYear { get; set; }
        public string QuestionName { get; set; }
        public bool IsRequired { get; set; }
        public string Class { get; set; }


        public QuestionSectionViewModel GetQuestionSection (string sectionName)
        {
            var dataSection = (from section in ContextPerRequest.CurrentData.QuestionSections
                               where section.SectionName == sectionName && section.IsActive == true
                               select new QuestionSectionViewModel
                               {
                                   FooterText = section.FooterText,
                                   HeaderText = section.HeaderText,
                                   IsActive = section.IsActive,
                                   QuestionSectionID = section.QuestionSectionID,
                                   SectionName = section.SectionName,
                                   SectionOrder = section.SectionOrder,
                                   SectionText = section.SectionText
                               }).FirstOrDefault<QuestionSectionViewModel>();

            return dataSection;
        }

        public IEnumerable<QuestionsViewModel> GetQuestions(int questionSection, int currentYear, int memberId)
        {
            var dataQuestions = (from Questions in ContextPerRequest.CurrentData.Questions
                                 join Answers in ContextPerRequest.CurrentData.QuestionAnswers on Questions.QuestionID equals Answers.QuestionID into _QuestionAnswers
                                 from QuestionAnswers in _QuestionAnswers.Where(Answers => Answers.CurrentYear == ProjectGlobals.CurrentYear && Questions.IsActive == true && Answers.MemberID == memberId).DefaultIfEmpty()
                                 where Questions.QuestionSectionID == questionSection && Questions.IsActive == true
                                 orderby Questions.QuestionOrder
                                 select new QuestionsViewModel
                                 {
                                     Answer = QuestionAnswers.Answer,
                                     DropDown = Questions.DropDown,
                                     AnswerID = QuestionAnswers.AnswerID == null ? 0 : QuestionAnswers.AnswerID,
                                     Question = Questions.Question1,
                                     QuestionID = Questions.QuestionID == null ? 0 : Questions.QuestionID,
                                     QuestionNumber = Questions.QuestionNumber,
                                     QuestionOrder = Questions.QuestionOrder,
                                     QuestionSectionID = Questions.QuestionSectionID == null ? 0 : Questions.QuestionSectionID,
                                     QuestionType = Questions.QuestionType,
                                     IsRequired = Questions.IsRequired,
                                     Class = Questions.Class
                                 });

            return dataQuestions;
        }

        //public IEnumerable<QuestionsViewModel> GetQuestions(string schoolType, int questionSection, int agreementNumber)
        //{

        //    var dataQuestions = (from Questions in ContextPerRequest.Current.ExpSumQuestions
        //                         join Answers in ContextPerRequest.Current.ExpSumQuestionAnswers on Questions.QuestionID equals Answers.QuestionID into _QuestionAnswers
        //                         from QuestionAnswers in _QuestionAnswers.Where(Answers => Answers.CurrentYear == ProjectGlobals.CurrentYear && Questions.IsActive == true && Answers.AgreementNumber == agreementNumber).DefaultIfEmpty()
        //                         where Questions.SchoolType == schoolType && Questions.QuestionSectionID == questionSection && Questions.IsActive == true
        //                         orderby Questions.QuestionOrder
        //                         select new QuestionsViewModel
        //                         {
        //                             QuestionID = Questions.QuestionID == null ? 0 : Questions.QuestionID,
        //                             QuestionSectionID = Questions.QuestionSectionID == null ? 0 : Questions.QuestionSectionID,
        //                             QuestionNumber = Questions.QuestionNumber,
        //                             QuestionOrder = Questions.QuestionOrder,
        //                             Question = Questions.Question,
        //                             Answer1 = Questions.Answer1,
        //                             Answer2 = Questions.Answer2,
        //                             Answer3 = Questions.Answer3,
        //                             Answer4 = Questions.Answer4,
        //                             Answer5 = Questions.Answer5,
        //                             QuestionType = Questions.QuestionType,
        //                             SchoolType = Questions.SchoolType,
        //                             AnswerID = QuestionAnswers.AnswerID == null ? 0 : QuestionAnswers.AnswerID,
        //                             Answer = QuestionAnswers.Answer
        //                         });

        //    return dataQuestions;
        //}

        //public void InitializeQuestions(string schoolType, int agreementNumber)
        //{

        //    var dataQuestions = (from Questions in ContextPerRequest.Current.ExpSumQuestions
        //                         select Questions.QuestionID).ToList();

        //    foreach (var item in dataQuestions)
        //    {
        //        ExpSumQuestionAnswer questionAnswer = new ExpSumQuestionAnswer
        //        {
        //            AgreementNumber = agreementNumber,
        //            Answer = null,
        //            CurrentYear = ProjectGlobals.CurrentYear,
        //            QuestionID = Convert.ToInt32(item)
        //        };
        //        ContextPerRequest.Current.ExpSumQuestionAnswers.Add(questionAnswer);
        //        ContextPerRequest.Current.SaveChanges();
        //    }
        //}

        //public bool CheckQuestions(string schoolType, int agreementNumber)
        //{
        //    var dataQuestions = (from Questions in ContextPerRequest.Current.ExpSumQuestionAnswers
        //                         where Questions.AgreementNumber == agreementNumber && Questions.CurrentYear == ProjectGlobals.CurrentYear
        //                         select Questions.QuestionID);

        //    if (dataQuestions.Count() > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //public void SaveQuestions(ExposureSummaryModel model, int agreementNumber)
        //{
        //    foreach (var item in model.RiskMainQuestions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //    foreach (var item in model.RiskActivityQuestions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //    foreach (var item in model.RiskProgramQuestions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //    foreach (var item in model.RiskHealthQuestions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //    foreach (var item in model.RiskAncillary1Questions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //    foreach (var item in model.RiskAncillary2Questions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //    foreach (var item in model.LossControlQuestions)
        //    {
        //        SaveQuestionData(agreementNumber, item.ControlId, ProjectGlobals.CurrentYear, item.ControlValue);

        //    }

        //}

        //public void SaveQuestionData(int agreementNumber, int questionID, int currentYear, string answer)
        //{
        //    var dataQuestionData = (from QuestionData in ContextPerRequest.Current.ExpSumQuestionAnswers
        //                            where QuestionData.AgreementNumber == agreementNumber &&
        //                            QuestionData.QuestionID == questionID &&
        //                            QuestionData.CurrentYear == currentYear
        //                            select QuestionData).FirstOrDefault();

        //    if (dataQuestionData != null)
        //    {
        //        dataQuestionData.Answer = answer;
        //        ContextPerRequest.Current.SaveChanges();
        //    }
        //    else
        //    {
        //        ExpSumQuestionAnswer question = new ExpSumQuestionAnswer
        //        {
        //            AgreementNumber = agreementNumber,
        //            Answer = answer,
        //            CurrentYear = currentYear,
        //            QuestionID = questionID
        //        };
        //        ContextPerRequest.Current.ExpSumQuestionAnswers.Add(question);
        //        ContextPerRequest.Current.SaveChanges();
        //    }

        //}

    }
}