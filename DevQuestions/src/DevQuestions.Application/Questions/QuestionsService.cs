using DevQuections.Domain.Questions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.QuestionErrors;
using DevQuestions.Application.Questions.QuestionErrors.Exceptions;
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

    public QuestionsService(
        IQuestionsRepository questionsRepository, 
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _validator = validator;
        _logger = logger;
    }
    
    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        //Валидация входных данных 
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new QuestionValidationException(validationResult.ToErrors());
        }
        
        //Валидация бизнес логики
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenedUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            throw new ToManyQuestionsException();
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