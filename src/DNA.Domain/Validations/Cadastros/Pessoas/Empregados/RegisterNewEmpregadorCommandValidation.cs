using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class RegisterNewEmpregadorCommandValidation : EmpregadoValidation<RegisterNewEmpregadoCommand>
    {
        public RegisterNewEmpregadorCommandValidation()
        {
            ValidateNome();
            ValidateSobrenome();
            ValidateCargo();
            ValidateDataAdmissao();
            ValidateDataAncimento();
            ValidateId();
        }
    }
}
