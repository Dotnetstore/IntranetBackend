using ServiceStack.FluentValidation;

namespace Organization.Queries.OwnCompanyGet;

internal sealed class GetOwnCompanyQueryValidator : AbstractValidator<GetOwnCompanyQuery>
{
    public GetOwnCompanyQueryValidator()
    {
        RuleFor(q => q.Name)
            .MaximumLength(100);

        RuleFor(q => q.VATNumber)
            .MaximumLength(30);
    }
}