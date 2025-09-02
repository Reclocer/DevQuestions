namespace DtoQuestion.Contracts;

public record AddAnswerDto(Guid UserId, string Title, string Text);