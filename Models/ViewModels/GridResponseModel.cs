using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.ViewModels
{
    public class GridResponseModel<T> where T : class
    {
        public int page { get; set; }
        public int size { get; set; }
        public int total_pages { get; set; }

        private object _data;
        public object data
        {
            get
            {
                return _data ?? pagedData;
            }
            set
            {
                _data = value;
            }
        }
        public IEnumerable<T> pagedData { get; set; }
        public GridResponseModel(GridRequestModel request, IQueryable<T> source, bool storeToPagedData = false)
        {
            this.page = request.page;
            this.size = request.size;

            if (source != null && request.size > 0)
            {
                total_pages = (int)Math.Ceiling((decimal)source.Count() / size);
            }

            if (storeToPagedData)
            {
                pagedData = source.Skip((page - 1) * size).Take(size).ToArray();
            }
            else
            {
                data = source.Skip((page - 1) * size).Take(size);
            }
        }

    }
}
