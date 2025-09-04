using System.Text.Json;
using SubSystems;

namespace DevQuestions.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(params Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}