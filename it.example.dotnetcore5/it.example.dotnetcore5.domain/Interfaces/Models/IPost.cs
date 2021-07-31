using System;

namespace it.example.dotnetcore5.domain.Interfaces.Models
{
    public interface IPost
    {
        int Id { get; set; }
        string Title { get; set; }
        string Text { get; set; }
        DateTime CreateDate { get; set; }
    }
}
