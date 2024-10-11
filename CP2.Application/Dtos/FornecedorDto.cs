using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {

        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Telefone { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } 

        public void Validator()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio")
                .MaximumLength(50).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no máximo 50 caracteres");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CNPJ)} deve ter no máximo 50 caracteres")
                .MaximumLength(14).WithMessage(x => $"O campo {nameof(x.CNPJ)} deve ter no máximo 14 caracteres");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio")
                .MaximumLength(11).WithMessage(x => $"O campo {nameof(x.Telefone)} deve ter no máximo 11 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio")
                .MaximumLength(70).WithMessage(x => $"O campo {nameof(x.Email)} deve ter no máximo 70 caracteres");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser vazio")
                .MaximumLength(200).WithMessage(x => $"O campo {nameof(x.Endereco)} deve ter no máximo 200 caracteres");

            RuleFor(x => x.CriadoEm)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser vazio")
                .LessThan(DateTime.Now).WithMessage(x => $"{nameof(x.CriadoEm)} não pode ser maior que a data atual");
       

         
        }
    }
}
