// Sous licence de la .NET Foundation en vertu d'un ou plusieurs accords.
// La .NET Foundation vous accorde une licence pour ce fichier en vertu de la licence MIT.
#nullable disable

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace TheCatApiV2.Areas.Identity.Pages.Account
{
    public class ConfirmEmailChangeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ConfirmEmailChangeModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     Cette API prend en charge l'infrastructure d'interface utilisateur par défaut d'ASP.NET Core Identity et n'est pas destinée à être utilisée
        ///     directement depuis votre code. Cette API peut être modifiée ou supprimée dans les versions futures.
        /// </summary>
        [TempData]
        public string MessageStatut { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string code)
        {
            if (userId == null || email == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                MessageStatut = "Erreur lors du changement d'adresse e-mail.";
                return Page();
            }

            // Dans notre interface utilisateur, l'adresse e-mail et le nom d'utilisateur sont identiques, donc lorsque nous mettons à jour l'adresse e-mail
            // nous devons également mettre à jour le nom d'utilisateur.
            var setResultNomUtilisateur = await _userManager.SetUserNameAsync(user, email);
            if (!setResultNomUtilisateur.Succeeded)
            {
                MessageStatut = "Erreur lors du changement du nom d'utilisateur.";
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            MessageStatut = "Merci de confirmer votre changement d'adresse e-mail.";
            return Page();
        }
    }
}
