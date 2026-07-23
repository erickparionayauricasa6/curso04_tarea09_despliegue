using epariona_curso04_tarea02.Domain.Common;
using epariona_curso04_tarea02.Domain.Entities;
using MediatR;

namespace epariona_curso04_tarea02.Application.Features.Libros.Queries;

public record ObtenerLibroQuery(int Id) : IRequest<Result<Libro>>;

public class ObtenerLibroQueryHandler : IRequestHandler<ObtenerLibroQuery, Result<Libro>>
{
    private readonly IRepository<Libro> _repository;

    public ObtenerLibroQueryHandler(IRepository<Libro> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Libro>> Handle(ObtenerLibroQuery request, CancellationToken cancellationToken)
    {
        var libro = await _repository.GetByIdAsync(request.Id);
        if (libro == null)
            return Result<Libro>.Failure("Libro no encontrado");

        return Result<Libro>.Success(libro);
    }
}
