using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Contracts
{
    public interface IDocumentTypeService
    {
        IQueryable<DocumentTypeListVM> GetDocumentTypeList();
        DocumentTypeVM GetItem(int id);
        bool SaveItem(DocumentTypeVM model);
    }
}
