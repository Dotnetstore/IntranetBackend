using MediatR;
using Organization.Abstractions;
using Shared.Organization;

namespace Organization.Queries.OwnCompanyGet;

internal sealed class GetOwnCompanyQueryHandler : IRequestHandler<GetOwnCompanyQuery, IEnumerable<OwnCompanyDTO>>
{
    private readonly IOwnCompanyRepository _ownCompanyRepository;
    private readonly GetOwnCompanyQueryValidator _getOwnCompanyQueryValidator;

    public GetOwnCompanyQueryHandler(
        IOwnCompanyRepository ownCompanyRepository)
    {
        _ownCompanyRepository = ownCompanyRepository;

        _getOwnCompanyQueryValidator = new GetOwnCompanyQueryValidator();
    }

    async Task<IEnumerable<OwnCompanyDTO>> IRequestHandler<GetOwnCompanyQuery, IEnumerable<OwnCompanyDTO>>.Handle(
        GetOwnCompanyQuery request, CancellationToken cancellationToken)
    {
        var validationResult = (await _getOwnCompanyQueryValidator.ValidateAsync(request, cancellationToken));

        if (!validationResult.IsValid)
        {
            throw new GetOwnCompanyQueryInvalidException(validationResult.ToString());
        }
        
        return await _ownCompanyRepository.GetAsync(request, cancellationToken);
    }
}