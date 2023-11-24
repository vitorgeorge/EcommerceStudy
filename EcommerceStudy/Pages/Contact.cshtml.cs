using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Display(Name = "Primeiro nome*")]
        public string PrimeiroNome { get; set; } = "";
        [BindProperty]
        [Required(ErrorMessage = "Segundo nome necessário")]
        [Display(Name = "Ultimo nome*")]
        public string UltimoNome { get; set; } = "";
        [BindProperty]
        [Required(ErrorMessage = "Email necessário")]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; } = "";
        
        [BindProperty] public string Telefone { get; set; } = "";
        [BindProperty, Required]
        [Display(Name = "Status*")]
        public string Status { get; set; } = "";
        [BindProperty]
        [MinLength(5, ErrorMessage ="A mensagem deve ter no mínimo 5 caracteres")]
        [MaxLength(1024, ErrorMessage = "A mensagem deve ter no máximo 1024 caracteres")]
        [Required(ErrorMessage = "Mensagem necessária")]
        [Display(Name = "Mensagem*")]
        public string Mensagem { get; set; } = "";

        public List<SelectListItem> SubjectList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Status do pedido", Text = "Status do pedido" },
            new SelectListItem { Value = "Pedido de reembolso", Text = "Pedido de reembolso" },
            new SelectListItem { Value = "Vaga de trabalho", Text = "Vaga de trabalho" },
            new SelectListItem { Value = "Outro", Text = "Outro" },
        };

        public string MensagemSucesso { get; set; } = "";

        public string MensagemErro { get; set; } = "";

        public void OnPost()
        {
           
            if (!ModelState.IsValid)
            {
                MensagemErro = "Por favor complete todos os campos necessários";
                return;
            }

            if (Telefone == null) Telefone = "";

            try
            {
                string stringDeConexao = "";
            }
            catch ( Exception ex)
            {
                MensagemErro = ex.Message;
                return;
            }
            MensagemSucesso = "Sua mensagem foi recebida com sucesso";

            PrimeiroNome = "";
            UltimoNome = "";
            Email = "";
            Telefone = "";
            Status = "";
            Mensagem = "";

            ModelState.Clear();

        }
    }
}
