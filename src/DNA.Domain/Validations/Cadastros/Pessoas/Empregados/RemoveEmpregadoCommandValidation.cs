using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class RemoveEmpregadoCommandValidation : EmpregadoValidation<EmpregadoCommand>
    {
        public RemoveEmpregadoCommandValidation()
        {
            ValidateId();
        }
    }
}
