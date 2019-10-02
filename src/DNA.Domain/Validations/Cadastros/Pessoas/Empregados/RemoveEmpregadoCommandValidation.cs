using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class RemoveEmpregadoCommandValidation : EmpregadoValidation<RemoveEmpregadoCommand>
    {
        public RemoveEmpregadoCommandValidation()
        {
            ValidateId();
        }
    }
}
