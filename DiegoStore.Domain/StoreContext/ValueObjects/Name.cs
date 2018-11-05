using FluentValidator;
using FluentValidator.Validation;

namespace DiegoStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve contar pelo menos 3 caracteres")
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve contar pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve contar no máximo 40 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve contar no máximo 40 caracteres")
                );
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}