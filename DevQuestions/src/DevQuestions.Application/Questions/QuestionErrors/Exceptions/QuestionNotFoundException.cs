using DevQuestions.Application.Exceptions;
using SubSystems;

namespace DevQuestions.Application.Questions.QuestionErrors.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
    public QuestionNotFoundException(params Error[] errors)
        : base(errors)
    {
    }
}