using AuthServer.Core.DTOs;
using FluentValidation;

namespace AuthServer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(200).WithMessage("{PropertyName} can not be longer than 200 characters");

            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.Stock).InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            
            RuleFor(x => x.UserId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(200).WithMessage("{PropertyName} can not be longer than 200 characters");
        }
    }
}
