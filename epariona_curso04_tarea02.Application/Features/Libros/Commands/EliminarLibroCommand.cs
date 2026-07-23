using epariona_curso04_tarea02.Domain.Common;
using epariona_curso04_tarea02.Domain.Entities;
using MediatR;

namespace epariona_curso04_tarea02.Application.Features.Libros.Commands;

public record EliminarLibroCommand(int Id) : IRequest<Result<bool>>;

public class EliminarLibroCommandHandler : IRequestHandler<EliminarLibroCommand, Result<bool>>
{
    private readonly IRepository<Libro> _repository;

    public EliminarLibroCommandHandler(IRepository<Libro> repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(EliminarLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = await _repository.GetByIdAsync(request.Id);
        if (libro == null)
            return Result<bool>.Failure("Libro no encontrado");

        await _repository.DeleteAsync(libro);
        return Result<bool>.Success(true);
    }
}
