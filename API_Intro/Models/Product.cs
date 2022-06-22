using API_Intro.DTOs;
using FluentValidation;

namespace API_Intro.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public bool? IsStatus { get; set; }
    }

    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Bos gonderme ").MaximumLength(30).WithMessage("30 xarakterden cox yazma ");
            RuleFor(p => p.Price).GreaterThanOrEqualTo(0).WithMessage("0 ve ya ondan boyuk eded daxil edin");
        }
    }
}
