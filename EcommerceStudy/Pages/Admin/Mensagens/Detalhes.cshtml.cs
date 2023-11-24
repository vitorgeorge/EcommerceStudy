using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace EcommerceStudy.Pages.Admin.Mensagens
{
    public class DetalhesModel : PageModel
    {
        public InfoMensagem mensagemInfo = new InfoMensagem();
        public void OnGet()
        {
            string requestId = Request.Query["id"];
            try
            {
                string stringConexao = "Data Source=.\\sqlexpress;Initial Catalog=studyshop;Integrated Security=True";

                using (SqlConnection conexao = new SqlConnection(stringConexao)) { 
                conexao.Open();
                    string sql = "SELECT * FROM mensagens WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, conexao))
                    {
                        command.Parameters.AddWithValue("@id", requestId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                mensagemInfo.Id = reader.GetInt32(0);
                                mensagemInfo.PrimeiroNome = reader.GetString(1);
                                mensagemInfo.UltimoNome = reader.GetString(2);
                                mensagemInfo.Email = reader.GetString(3);
                                mensagemInfo.Telefone = reader.GetString(4);
                                mensagemInfo.Assunto = reader.GetString(5);
                                mensagemInfo.Mensagem = reader.GetString(6);
                                mensagemInfo.CriadoEm = reader.GetDateTime(7).ToString("MM/dd/yyyy");
                            }
                            else
                            {
                                Response.Redirect("/Admin/Mensagens/Index");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("/Admin/Mensagens/Index");

            }
        }
    }
}
