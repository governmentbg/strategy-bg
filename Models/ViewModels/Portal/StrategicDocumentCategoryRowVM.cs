using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
  public class StrategicDocumentCategoryRowVM
  {
    public string Title { get; set; }
    public ICollection<StrategicDocumentLinkRowVM> LinkRows { get; set; }

    public StrategicDocumentCategoryRowVM()
    {
      LinkRows = new List<StrategicDocumentLinkRowVM>();
    }



  }
}
