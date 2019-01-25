using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Services
{
    public class DocumentTypeService : BaseService, IDocumentTypeService
    {
        private readonly ILogger logger;

        public DocumentTypeService(
            MainContext context,
            ILogger<DocumentTypeService> _logger)
        {
            this.db = context;
            logger = _logger;
        }
        public IQueryable<DocumentTypeListVM> GetDocumentTypeList()
        {
            return All<DocumentType>()
                .Select(d => new DocumentTypeListVM()
                {
                    Id = d.Id,
                    Label = d.Label,
                    IsActive = d.IsActive
                });
        }

        public DocumentTypeVM GetItem(int id)
        {
            return All<DocumentType>()
                .Where(d => d.Id == id)
                .Select(d => new DocumentTypeVM()
                {
                    Id = d.Id,
                    Label = d.Label,
                    IsActive = d.IsActive
                })
                .FirstOrDefault();
        }

        public bool SaveItem(DocumentTypeVM model)
        {
            var result = false;
            DocumentType entity = null;

            try
            {
                if (model.Id > 0)
                {
                    entity = All<DocumentType>().Find(model.Id);

                    if (entity != null)
                    {
                        entity.IsActive = model.IsActive;
                        entity.Label = model.Label;
                    }
                }
                else
                {
                    entity = new DocumentType()
                    {
                        IsActive = model.IsActive,
                        Label = model.Label,
                        DateCreated = DateTime.Now
                    };

                    db.DocumentTypes.Add(entity);
                }

                if (entity != null)
                {
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SaveItem");
            }

            return result;
        }
    }
}
