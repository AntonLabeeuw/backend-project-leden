namespace Leden.API.Validators;

public class TakValidator : AbstractValidator<Tak>{

    public TakValidator(){
        RuleFor(t => t.TakNaam).NotEmpty().WithMessage("Geef een naam op voor de tak die je wilt toevoegen");
    }
}