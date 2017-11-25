using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BHIP.Model
{
    public class DocumentViewModel
    {
        public int DocumentId { get; set; }
        public int RenewalId { get; set; }
        [Required(ErrorMessage = "Please select a document type.")]
        public long DocTypeId { get; set; }
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? LoadDate { get; set; }
        [Required(ErrorMessage = "Please enter a date.")]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EffectiveDate { get; set; }
        [Required(ErrorMessage = "Please upload a valid document. [docx,pdf,ppt,xlsx]")]
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string Media { get; set; }
        public string Name { get; set; }
        public byte[] FileUpload { get; set; }
        public HttpFileCollectionBase File { get; set;}
        public bool? Action { get; set; }
        public string PolicyYear { get; set; }
        public string DocumentType { get; set; }

        public DocumentViewModel GetDocument(int documentId)
        {
            var data = (from doc in ContextPerRequest.CurrentData.Documents
                        where doc.DocumentId == documentId
                        select new DocumentViewModel
                        {
                            Action = doc.Action,
                            DocTypeId = doc.DocTypeId,
                            DocumentId = doc.DocumentId,
                            EffectiveDate = doc.EffectiveDate,
                            Extension = doc.Extension,
                            FileName = doc.FileName,
                            FileUpload = doc.Document1,
                            LoadDate = doc.LoadDate,
                            Media = doc.Media,
                            Name = doc.FileName,
                            RenewalId = (int)doc.RenewalId
                        }).FirstOrDefault();

            return data;

        }

        public DocumentViewModel EditDocument(int documentId)
        {
            var data = (from doc in ContextPerRequest.CurrentData.Documents
                        where doc.DocumentId == documentId
                        select new DocumentViewModel
            {
                Action = doc.Action,
                DocTypeId = doc.DocTypeId,
                DocumentId = doc.DocumentId,
                EffectiveDate = doc.EffectiveDate,
                Extension = doc.Extension,
                FileName = doc.FileName,
                FileUpload = doc.Document1,
                LoadDate = doc.LoadDate,
                Media = doc.Media,
                Name = doc.FileName,
                RenewalId = (int)doc.RenewalId
            }).FirstOrDefault();

            return data;
        }
        public IEnumerable<DocumentViewModel> GetDocuments(int renewalId)
        {
            var data = (from docs in ContextPerRequest.CurrentData.Documents
                        join type in ContextPerRequest.CurrentData.DocumentTypes on docs.DocTypeId equals type.DocTypeId
                        where docs.RenewalId == renewalId
                        orderby type.DocType
                        select new DocumentViewModel
                        {
                            Action = docs.Action,
                            DocTypeId = docs.DocTypeId,
                            DocumentId = docs.DocumentId,
                            EffectiveDate = docs.EffectiveDate,
                            Extension = docs.Extension,
                            FileName = docs.FileName,
                            LoadDate = docs.LoadDate,
                            Media = docs.Media,
                            Name = "",
                            Path = "",
                            RenewalId = (int)docs.RenewalId,
                            DocumentType = type.DocType

                        });
            return data;
        }

        public IEnumerable<SelectListItem> GetDocumentTypeList(long DocTypeId)
        {
            IEnumerable<SelectListItem> returnValue;

            List<SelectListItem> _list = new List<SelectListItem>();
            _list.Insert(0, new SelectListItem() { Value = "0", Text = "Select", Selected = false });
            returnValue = new SelectList((IEnumerable<SelectListItem>)_list, "Value", "Text");

            var dataDocType = from tblDocTypes in ContextPerRequest.CurrentData.DocumentTypes
                              orderby tblDocTypes.DocType ascending
                              select tblDocTypes;
            returnValue = dataDocType.ToList().Select(u => new SelectListItem
            {
                Text = u.DocType,
                Value = u.DocTypeId.ToString(),
                Selected = (u.DocTypeId == DocTypeId)
            });

            return returnValue;

        }

        public void AddDocument(DocumentViewModel model)
        {
            Document doc = new Document
            {
                Action = model.Action,
                DocTypeId = model.DocTypeId,
                Document1 = model.FileUpload,
                EffectiveDate = model.EffectiveDate,
                Extension = model.Extension,
                FileName = model.FileName,
                LoadDate = DateTime.Now,
                Media = model.Media,
                RenewalId = model.RenewalId
            };

            ContextPerRequest.CurrentData.Documents.Add(doc);
            ContextPerRequest.CurrentData.SaveChanges();

        }

        public void SaveEditDocument(DocumentViewModel model)
        {
            var data = (from doc in ContextPerRequest.CurrentData.Documents
                        where doc.DocumentId == model.DocumentId
                        select doc).FirstOrDefault();

            if (data != null)
            {
                data.DocTypeId = model.DocTypeId;
                data.Document1 = model.FileUpload;
                data.EffectiveDate = model.EffectiveDate;
                data.Extension = model.Extension;
                data.FileName = model.FileName;

                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

        public void DeleteDocument(int documentId)
        {
            var data = (from doc in ContextPerRequest.CurrentData.Documents
                        where doc.DocumentId == documentId
                        select doc).FirstOrDefault();
            if (data != null)
            {
                ContextPerRequest.CurrentData.Documents.Remove(data);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }
    }

    public class DocumentTypeViewModel
    {
        public int DocTypeId { get; set; }
        [Required(ErrorMessage = "Please enter a document type name.")]
        public string DocType { get; set; }
        [Required(ErrorMessage = "Please enter a document type description.")]
        public string Description { get; set; }

        public void SaveDocumentType(DocumentTypeViewModel model)
        {
            if (model != null)
            {
                DocumentType doc = new DocumentType
                {
                    Description = model.Description,
                    DocType = model.DocType
                };

                ContextPerRequest.CurrentData.DocumentTypes.Add(doc);
                ContextPerRequest.CurrentData.SaveChanges();
            }
        }

    }
}