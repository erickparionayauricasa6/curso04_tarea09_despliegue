using epariona_curso04_tarea02.Domain.Common;
using epariona_curso04_tarea02.Domain.Entities;
using MediatR;

namespace epariona_curso04_tarea02.Application.Features.Libros.Queries;

public record ObtenerTodosLibrosQuery() : IRequest<Result<IEnumerable<Libro>>>;

public class ObtenerTodosLibrosQueryHandler : IRequestHandler<ObtenerTodosLibrosQuery, Result<IEnumerable<Libro>>>
{
    private readonly IRepository<Libro> _repository;

    public ObtenerTodosLibrosQueryHandler(IRepository<Libro> repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Libro>>> Handle(ObtenerTodosLibrosQuery request, CancellationToken cancellationToken)
    {
        var libros = await _repository.GetAllAsync();
        return Result<IEnumerable<Libro>>.Success(libros);
    }
}
