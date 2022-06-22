using FluentValidation;

namespace API_Intro.DTOs.CategoryDtos
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }
    public class CategoryPostDtoValidstor : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidstor()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Bosh gondermek olmaz").MaximumLength(30).WithMessage("30 xarakterden artiq yazi yazma");
        }
    }
}
