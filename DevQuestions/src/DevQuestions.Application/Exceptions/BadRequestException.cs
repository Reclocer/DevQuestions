using System.Text.Json;
using SubSystems;

namespace DevQuestions.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(params Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}