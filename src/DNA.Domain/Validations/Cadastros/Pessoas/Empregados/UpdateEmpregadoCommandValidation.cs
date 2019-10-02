using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class UpdateEmpregadoCommandValidation : EmpregadoValidation<UpdateEmpregadoCommand>
    {
        public UpdateEmpregadoCommandValidation()
        {
            ValidateNome();
            ValidateSobrenome();
            ValidateCargo();
            ValidateDataNascimento();
            ValidateDataAdmissao();
            ValidateId();
        }
    }
}
