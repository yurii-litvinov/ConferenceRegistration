using ConferenceRegistration.Data;

namespace ConferenceRegistration.Pages;

[BindProperties]
public class RegistrationModel : PageModel
{
    private readonly ConferenceRegistrationDbContext context;

    public RegistrationModel(ConferenceRegistrationDbContext context)
        => this.context = context;

    public Participant Participant { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        context.Participants.Add(Participant);
        await context.SaveChangesAsync();

        return RedirectToPage("./Thanks", Participant);
    }
}
