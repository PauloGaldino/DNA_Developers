using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class UpdateEmpregadoCommandValidation : EmpregadoValidation<EmpregadoCommand>
    {
        public UpdateEmpregadoCommandValidation()
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
