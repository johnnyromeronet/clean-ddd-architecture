using AutoMapper;
using Clean.DDD.Architecture.Application.Features.BaseAsync.Commands;
using Clean.DDD.Architecture.Application.Features.BaseAsync.Queries;
using Clean.DDD.Architecture.Domain.Contracts.Persistence;
using Clean.DDD.Architecture.Domain.Entities.Base;
using Clean.DDD.Architecture.Domain.Exceptions;
using Clean.DDD.Architecture.Domain.Models.Base;
using Clean.DDD.Architecture.Domain.Models.Internal;
using MediatR;

namespace Clean.DDD.Architecture.Application.Features.BaseAsync
{
    public class BaseAsyncHandler<T, S, R>(S baseAsyncRepository, IMapper mapper) :
        IRequestHandler<GetAllAsyncQuery<T>, IEnumerable<T>>,
        IRequestHandler<GetByIdAsyncQuery<T>, T>,
        IRequestHandler<AddAsyncCommand<T>, ResponseModel>,
        IRequestHandler<DeleteAsyncCommand<T>, ResponseModel>,
        IRequestHandler<UpdateAsyncCommand<T>, ResponseModel>,
        IRequestHandler<RollbackCommand<T>, ResponseModel>
        where T : BaseModel
        where S : IBaseAsyncRepository<R>
        where R : BaseEntity
    {
        private readonly S _baseAsyncRepository = baseAsyncRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<T>> Handle(GetAllAsyncQuery<T> request, CancellationToken cancellationToken)
        {
            var entities = await _baseAsyncRepository.GetAllAsync(request.QueryParams);
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public async Task<T> Handle(GetByIdAsyncQuery<T> request, CancellationToken cancellationToken)
        {
            var entity = await _baseAsyncRepository.GetByIdAsync(request.Id, request.Enabled);
            return _mapper.Map<T>(entity);
        }

        public async Task<ResponseModel> Handle(AddAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<R>(request.Model);
            entity.IDate = request.Audit.IDate;
            entity.IUser = request.Audit.IUser;
            entity.IComments = request.Audit.IComments;
            entity.Enabled = true;

            return await _baseAsyncRepository.AddAsync(entity, request.Save);
        }

        public async Task<ResponseModel> Handle(DeleteAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = await _baseAsyncRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("La entidad no existe");

            if (request.Logical)
            {
                entity.UDate = request.Audit.UDate;
                entity.UUser = request.Audit.UUser;
                entity.UComments = request.Audit.UComments;
            }

            return await _baseAsyncRepository.DeleteAsync(entity, request.Save);
        }

        public async Task<ResponseModel> Handle(UpdateAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = await _baseAsyncRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("La entidad no existe");
            _mapper.Map(request.Model, entity);

            entity.UDate = request.Audit.UDate;
            entity.UUser = request.Audit.UUser;
            entity.UComments = request.Audit.UComments;

            return await _baseAsyncRepository.UpdateAsync(entity, request.Save);
        }

        public async Task<ResponseModel> Handle(RollbackCommand<T> request, CancellationToken cancellationToken)
        {
            return await _baseAsyncRepository.RollbackAsync();
        }
    }
}
