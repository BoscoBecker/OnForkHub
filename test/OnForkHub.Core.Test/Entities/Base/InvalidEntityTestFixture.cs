using OnForkHub.Core.Entities.Base;
using OnForkHub.Core.Validations;

namespace OnForkHub.Core.Test.Entities.Base;

public class InvalidEntityTestFixture : BaseEntity
{
    public InvalidEntityTestFixture()
        : base() { }

    public InvalidEntityTestFixture(long id, DateTime createdAt, DateTime? updatedAt = null)
        : base(id, createdAt, updatedAt) { }

    public void ExecuteUpdate()
    {
        Validate();
        Update();
    }

    public override ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        ValidationResult.ThrowErrorIf(() => Id <= 0, "Id must be greater than zero");
        return validationResult;
    }
}