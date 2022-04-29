using System.Security.Claims;

namespace Autenticacao_API.Extensoes
{
    public static class UsuarioClaim
    {
        public static string ObterCodigoUsuarioClaim(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                return null;

            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
