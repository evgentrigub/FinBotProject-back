using System;
using WebApi.Interfaces;

namespace WebApi.Entities
{
    public class Answers : IAnswers
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int AnswerRate { get; set; }
    }
}