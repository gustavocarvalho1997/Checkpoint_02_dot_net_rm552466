using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }


        public void Validator()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio")
            .MaximumLength(50).WithMessage(x => $"O campo {nameof(x.Nome)} deve conter no máximo 50 caracteres");

            RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio")
            .MinimumLength(10).WithMessage(x => $"O campo {nameof(x.Telefone)} deve conter no minimo 10 caracteres")
            .MaximumLength(11).WithMessage(x => $"O campo {nameof(x.Telefone)} deve conter no máximo 11 caracteres");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio")
            .MaximumLength(70).WithMessage(x => $"O campo {nameof(x.Email)} deve ter no máximo 70 caracteres"); ;

            RuleFor(x => x.Endereco)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser vazio")
            .MaximumLength(200).WithMessage(x => $"O campo {nameof(x.Endereco)} deve ter no máximo 200 caracteres");

            RuleFor(x => x.CriadoEm)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser vazio")
            .LessThan(DateTime.Now).WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser maior que a data atual"); ;

            RuleFor(x => x.DataNascimento)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataNascimento)} não pode ser vazio")
            .LessThan(DateTime.Now).WithMessage(x => $"O campo {nameof(x.DataNascimento)} foi preenchido com uma data inválida");

            RuleFor(x => x.DataContratacao)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataContratacao)} não pode ser vazio")
            .GreaterThanOrEqualTo(x => x.DataNascimento).WithMessage(x => $"O campo {nameof(x.DataContratacao)} deve ser preenchido com data posterior ao nascimento");

            RuleFor(x => x.ComissaoPercentual)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.ComissaoPercentual)} não pode ser vazio")
            .InclusiveBetween(0, 100).WithMessage(x => $"O campo {nameof(x.ComissaoPercentual)} deve ser de 0 a 100");

            RuleFor(x => x.MetaMensal)
            .NotEmpty().WithMessage(x => $"O campo {nameof(x.MetaMensal)} não pode ser vazio")
            .GreaterThanOrEqualTo(0).WithMessage(x => $"O campo {nameof(x.MetaMensal)} deve ser 0 ou positivo");






        }
    }
}
