using System.Linq;
using Models.Context;

namespace Models.Contracts
{
    public interface ILibraryService
    {
        IQueryable<Library> Select(int source_type, int? parent_id, string title);
        Library GetByID(int id);
        bool Save(Library model);
    }
}
