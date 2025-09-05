using CSharpFunctionalExtensions;
using DevQuections.Domain.Questions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.FulltextSearch;
using DevQuestions.Application.Questions.QuestionErrors;
using DtoQuestion.Contracts;
using FluentValidation;
using Microsoft.Extensions.Logging;
using SubSystems;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;
    private readonly ISearchProvider _searchProvider;

    public QuestionsService(
        IQuestionsRepository questionsRepository, 
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _validator = validator;
        _logger = logger;
    }
    
    public async Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        //Валидация входных данных 
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            return validationResult.ToErrors();
        }
        
        //Валидация бизнес логики
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenedUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            return Errors.Questions.ToManyQuestions().ToFailure();
        }
        
        var questionId = Guid.NewGuid();
       
        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds);

        //Создание сущности question в базе данных
        await _questionsRepository.AddAsync(question, cancellationToken);

        // var indexResult = await _searchProvider.IndexQuestionAsync(question);
        //
        // if (indexResult.IsFailure)
        // {
        //     return indexResult.Error;
        // }

        _logger.LogInformation("Question created with id {questionId}", questionId);
        return questionId;
    }

    // public async Task<IActionResult> Update(Guid questionId, UpdateQuestionDto request,
    //     CancellationToken cancellationToken)
    // {
    //     
    // }
    //
    // public async Task<IActionResult> Delete(Guid questionId, CancellationToken cancellationToken)
    // {
    //     
    // }
    //
    // public async Task<IActionResult> SelectSolution(Guid questionId, Guid answerId,
    //     CancellationToken cancellationToken)
    // {
    //     
    // }
    //
    // public async Task<IActionResult> AddAnswer(Guid questionId, AddAnswerDto request, CancellationToken cancellationToken)
    // {
    //     
    // }
}