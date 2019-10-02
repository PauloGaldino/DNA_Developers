using DNA.Domain.Validations.Cadastros.Pessoas.Empregados;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Empregados
{
    public class RemoveEmpregadoCommand : EmpregadoCommand
    {
        public RemoveEmpregadoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveEmpregadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
