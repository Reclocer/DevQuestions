using DevQuestions.Application.Exceptions;
using SubSystems;

namespace DevQuestions.Application.Questions.QuestionErrors.Exceptions;

public class QuestionValidationException : BadRequestException
{
    public QuestionValidationException(params Error[] errors)
        : base(errors)
    {
    }
}