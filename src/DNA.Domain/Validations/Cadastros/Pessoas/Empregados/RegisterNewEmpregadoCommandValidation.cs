using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class RegisterNewEmpregadoCommandValidation : EmpregadoValidation<RegisterNewEmpregadoCommand>
    {
        public RegisterNewEmpregadoCommandValidation()
        {
            ValidateNome();
            ValidateSobrenome();
            ValidateCargo();
            ValidateDataNascimento();
            ValidateDataAdmissao();
           
        }
    }
}
