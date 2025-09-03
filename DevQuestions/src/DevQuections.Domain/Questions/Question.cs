namespace DevQuections.Domain.Questions;

public class Question
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public Guid UserId { get; set; }
    public Guid? ScreenshotId { get; set; }

    public List<Answer> Answer { get; set; } = [];

    public Answer? Solution { get; set; }

    public List<Guid> Tags { get; set; }

    public QuestionStatus Status { get; set; } = QuestionStatus.OPEN;

    public Question(
        Guid id,
        string title,
        string text,
        Guid userId,
        Guid? screenshotId,
        IEnumerable<Guid> tags)
    {
        Id = id;
        Title = title;
        Text = text;
        UserId = userId;
        ScreenshotId = screenshotId;
        Tags = tags.ToList();
    }
}