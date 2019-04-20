using System;
namespace WebApi.Interfaces
{
    public interface IAnswers
    {
        Guid Id { get; set; }
        string Content { get; set; }
        int AnswerRate { get; set; }
    }
}
