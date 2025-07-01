using App.Domain.Entities;
using App.Domain.Repository;
using App.Domain.Repository.Base;
using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.ResponsesFromPosts;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.PostResponse;

namespace App.Application.Usecases.ResponsesService;

public class ResponsesService(IResponsesRepository _responsesRepository, IUnitOfWork _unitOfWork) : IResponsesService
{
    public async Task<BaseResponse<bool>> DeleteResponse(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _responsesRepository.DeleteAsync(Id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return response is not null
           ? new BaseResponse<bool>(true, 200, "Resposta deletada com sucesso")
           : new BaseResponse<bool>(false, 404, "Resposta nao encontrada no sistema");
    }

    public async Task<PagedResponse<List<PostRequestResponse>>> GetAllResponses(PagedRequest request, CancellationToken cancellationToken)
    {
        var response = await _responsesRepository.GetAllAsync(cancellationToken) ?? [];

        if (response.Count > 0)
        {
            var listUsersResponse = response.Select(x => new PostRequestResponse(x)).ToList();
            return new PagedResponse<List<PostRequestResponse>>(listUsersResponse, listUsersResponse.Count, listUsersResponse.Count, request.PageNumber);
        }

        return new PagedResponse<List<PostRequestResponse>>(null, 0, 0, 1);
    }

    public async Task<BaseResponse<PostRequestResponse>> GetResponseById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _responsesRepository.GetByIdAsync(Id, cancellationToken);

        return response is not null
            ? new BaseResponse<PostRequestResponse>(new PostRequestResponse(response), 200, "Resposta encontrada")
            : new BaseResponse<PostRequestResponse>(null, 404, "Resposta nao encontrada no sistema");
    }

    public async Task<BaseResponse<PostRequestResponse>> RespondPost(CreateResponseRequest request, CancellationToken cancellationToken)
    {
        var response = await _responsesRepository.CreateAsync(new Responses(request), cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return response is not null
            ? new BaseResponse<PostRequestResponse>(new PostRequestResponse(response), 201, "Success.")
            : new BaseResponse<PostRequestResponse>(null, 500, "Erro inesperado ao salvar a entidade no banco.");
    }

    public Task<BaseResponse<bool>> UpdateResponse(CreateResponseRequest responseInfo, CancellationToken cancellationToken)
    {
        var response = _responsesRepository.UpdateAsync(new Responses(responseInfo), cancellationToken);
        _unitOfWork.CommitAsync(cancellationToken);

        return response is not null
            ? Task.FromResult(new BaseResponse<bool>(true, 200, "Resposta atualizada com sucesso"))
            : Task.FromResult(new BaseResponse<bool>(false, 404, "Resposta nao encontrada no sistema"));
    }
}
