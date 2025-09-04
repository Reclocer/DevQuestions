using DevQuestions.Application.Exceptions;

namespace DevQuestions.Application.Questions.QuestionErrors.Exceptions;

public class ToManyQuestionsException : BadRequestException
{
    public ToManyQuestionsException()
        : base([Errors.Questions.ToManyQuestions()])
    {
    }
}