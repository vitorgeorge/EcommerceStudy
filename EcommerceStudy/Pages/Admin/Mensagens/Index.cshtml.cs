using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace EcommerceStudy.Pages.Admin.Mensagens
{
    public class IndexModel : PageModel
    {

        public List<InfoMensagem> listMensagens = new List<InfoMensagem>();
        public void OnGet()
        {
            try
            {
                string stringConexao = "Data Source=.\\sqlexpress;Initial Catalog=studyshop;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(stringConexao))
                {
                    connection.Open();

                    string sql = "SELECT * FROM mensagens ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                InfoMensagem infoMensagem = new InfoMensagem();
                                infoMensagem.Id = reader.GetInt32(0);
                                infoMensagem.PrimeiroNome = reader.GetString(1);
                                infoMensagem.UltimoNome = reader.GetString(2);
                                infoMensagem.Email = reader.GetString(3);
                                infoMensagem.Telefone = reader.GetString(4);
                                infoMensagem.Assunto = reader.GetString(5);
                                infoMensagem.Mensagem = reader.GetString(6);
                                infoMensagem.CriadoEm = reader.GetDateTime(7).ToString("MM/dd/yyyy");

                                listMensagens.Add(infoMensagem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class InfoMensagem
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; } = "";
        public string UltimoNome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Assunto { get; set; } = "";
        public string Mensagem { get; set; } = "";
        public string CriadoEm { get; set; } = "";
    }
}
