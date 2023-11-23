using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EcommerceStudy.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        [Required(ErrorMessage = "Primeiro nome necessário")]
        public string PrimeiroNome { get; set; } = "";
        [BindProperty]
        public string UltimoNome { get; set; } = "";
        [BindProperty]
        public string Email { get; set; } = "";
        
        [BindProperty] public string Telefone { get; set; } = "";
        [BindProperty] public string Status { get; set; } = "";
        [BindProperty] public string Mensagem { get; set; } = "";

        public string MensagemSucesso { get; set; } = "";

        public string MensagemErro { get; set; } = "";

        public void OnPost()
        {
            PrimeiroNome = Request.Form["primeironome"];
            UltimoNome = Request.Form["ultimonome"];
            Email = Request.Form["email"];
            Telefone = Request.Form["telefone"];
            Status = Request.Form["status"];
            Mensagem = Request.Form["mensagem"];

            if (PrimeiroNome.Length == 0 || UltimoNome.Length == 0 ||
                Email.Length == 0 || Status.Length == 0 ||
                Mensagem.Length == 0)
            {
                MensagemErro = "Por favor complete todos os campos necessários";
                return;
            }
            MensagemSucesso = "Sua mensagem foi recebida com sucesso";

            PrimeiroNome = "";
            UltimoNome = "";
            Email = "";
            Telefone = "";
            Status = "";
            Mensagem = "";

        }
    }
}
