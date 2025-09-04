using DevQuestions.Application.FilesStorage;

namespace DevQuestions.Infrastucture.S3;

public class S3Provider : IFilesProvider
{
    public Task<string> UploadAsync(Stream stream, string key, string bucket) => throw new NotImplementedException();
}