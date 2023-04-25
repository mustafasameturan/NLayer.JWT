using System.Linq.Expressions;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using NLayerJWT.Core.Repositories;
using NLayerJWT.Core.Services;
using NLayerJWT.Core.UnitOfWork;
using SharedLibrary.DTOs;

namespace NLayerJWT.Service.Services;

public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<TEntity> _repository;

    public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<Response<TDto>> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
        {
            return Response<TDto>.Fail("Id not found", 404, true);
        }

        return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
    }

    public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
    {
        var entity = ObjectMapper.Mapper.Map<List<TDto>>(await _repository.GetAllAsync());

        return Response<IEnumerable<TDto>>.Success(entity, 200);
    }

    public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
    {
        var list = _repository.Where(predicate);

        return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
    }

    public async Task<Response<TDto>> AddAsync(TDto entity)
    {
        var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

        await _repository.AddAsync(newEntity);

        await _unitOfWork.CommitAsync();

        var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

        return Response<TDto>.Success(newDto, 200);
    }

    public async Task<Response<NoDataDto>> Remove(int id)
    {
        var isExistEntity = await _repository.GetByIdAsync(id);

        if (isExistEntity == null)
        {
            return Response<NoDataDto>.Fail("Id not found", 404, true);
        }
        
        _repository.Remove(isExistEntity);

        await _unitOfWork.CommitAsync();

        return Response<NoDataDto>.Success(200);
    }

    public async Task<Response<NoDataDto>> Update(TDto entity, int id)
    {
        var isExistEntity = await _repository.GetByIdAsync(id);

        if (isExistEntity == null)
        {
            return Response<NoDataDto>.Fail("Id not found", 404, true);
        }

        var updatedEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

        _repository.Update(updatedEntity);

        await _unitOfWork.CommitAsync();

        return Response<NoDataDto>.Success(204);
    }
}