using SubSystems;

namespace DevQuestions.Application.Questions.QuestionErrors;

public partial class Errors
{
    public static class Questions
    {
        public static Error ToManyQuestions()
        {
            return Error.Failure("question.too.many", "Пользователь не может открыть больше 3 вопросовю");
        }
    }
}