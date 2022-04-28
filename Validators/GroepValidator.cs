namespace Leden.API.Validators;

public class GroepValidator : AbstractValidator<Groep>{

    public GroepValidator(){
        RuleFor(t => t.GroepNaam).NotEmpty().WithMessage("Geef een naam op voor de groep die je wilt toevoegen");
        RuleFor(g => g.Email).NotEmpty().WithMessage("Vul het e-mailadres van je groep in");
        RuleFor(g => g.Oprichtingsdatum).NotEmpty().WithMessage("Kies een datum wanneer dat je groep opgericht is");
        RuleFor(g => g.Adres).NotEmpty().WithMessage("Geef een adres waar je lokaal gelegen is op");
        RuleFor(g => g.Postcode).NotEmpty().WithMessage("Geef de postcode van je gemeente in");
        RuleFor(g => g.Gemeente).NotEmpty().WithMessage("Vul een gemeente in");
        RuleFor(g => g.Groepsleider1).NotEmpty().WithMessage("Vul minstens 1 groepsleider in");
        RuleFor(g => g.Secretaris).NotEmpty().WithMessage("Vul de naam van je secretaris in");
        RuleFor(g => g.Penningmeester).NotEmpty().WithMessage("Vul de naam van je penningmeester in");
    }
}