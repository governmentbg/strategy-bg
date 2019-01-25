using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
  public class StrategicDocumentPDFVM
  {
    public string Title { get; set; }
    public ICollection<StrategicDocumentCategoryRowVM> CategoryRows { get; set; }
    public int DocumentsCount { get; set; }


    public StrategicDocumentPDFVM()
    {
      CategoryRows = new List<StrategicDocumentCategoryRowVM>();
    }
  }
}
