namespace Leden.API.Validators;

public class LidValidator : AbstractValidator<Lid>{

    public LidValidator(){
        RuleFor(l => l.Naam).NotEmpty().WithMessage("De familienaam moet ingevuld zijn");
        RuleFor(l => l.Voornaam).NotEmpty().WithMessage("De voornaam moet ingevuld zijn");
        RuleFor(l => l.Tak).NotNull().WithMessage("Er moet een tak ingevuld zijn waar het lid in zit");
        RuleFor(l => l.Groep).NotNull().WithMessage("Er moet een groep ingevuld zijn waar het lid in zit");
        RuleFor(l => l.Adres1).NotEmpty().WithMessage("Er moet minstens 1 adres ingevuld zijn");
        RuleFor(l => l.Email).NotEmpty().WithMessage("Er moet een e-mailadres ingevuld zijn");
        RuleFor(l => l.Geboortedatum).NotEmpty().WithMessage("Er moet een geboortedatum ingevuld zijn");
    }
}