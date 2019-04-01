using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using System.Linq;

namespace WebCommon.Extensions
{
    public static class DataTablesExtension
    {
        public static DataTablesResponse GetResponse<T>(this IDataTablesRequest request, IQueryable<T> data, IQueryable<T> filteredData = null, int? recordCount = null) where T : class
        {
            if (filteredData == null)
            {
                filteredData = data;
            }

            var orderColums = request.Columns.Where(x => x.Sort != null);
            T[] dataPage = null;
            if (recordCount > 0)
            {
                dataPage = filteredData.ToArray();
            }
            else
            {
                if (filteredData.Count() > 0)
                {
                    dataPage = filteredData.OrderBy(orderColums).Skip(request.Start).Take((request.Length > 0) ? request.Length : filteredData.Count()).ToArray();
                }
                else
                {
                    dataPage = filteredData.ToArray();
                }
            }
            if (typeof(T).Implements(typeof(IDataTableRowNo)))
            {
                int row = 1;
                for (int i = 0; i < dataPage.Count(); i++)
                {
                    var item = dataPage[i];
                    var rowProperty = item.GetType().GetProperty("RowNo");
                    rowProperty.SetValue(item, request.Start + row);
                    row++;
                }
            }

            return DataTablesResponse.Create(request, recordCount ?? data.Count(), recordCount ?? filteredData.Count(), dataPage);
        }
    }

    public interface IDataTableRowNo
    {
        int RowNo { get; set; }
    }
}
