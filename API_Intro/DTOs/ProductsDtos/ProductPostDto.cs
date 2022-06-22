using FluentValidation;

namespace API_Intro.DTOs
{
    public class ProductPostDto
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public bool IsStatus { get; set; }
    }

    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>

    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Bosh Data daxil etmek olmaz").MaximumLength(30).WithMessage("30 xarakterden artiq yazma!");
        }
    }
}
