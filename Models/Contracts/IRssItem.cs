using System;

namespace Models.Contracts
{
    public interface IRssItem
    {
        int Id { get; set; }
        string Title { get; set; }

        string Description { get; set; }

        string Category { get; set; }

        DateTime PublishDate { get; set; }
    }
}
