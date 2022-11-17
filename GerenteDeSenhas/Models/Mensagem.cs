using MimeKit;
using System.Text;
using System.Text.Unicode;

namespace GerenteDeSenhas.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }


        public Mensagem(IEnumerable<string> destinatario, string assunto,
            Guid usuarioId, string codigoDeAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress("",d)));
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/ativacao?UsuarioId={usuarioId}&CodigoDeAtivacao={codigoDeAtivacao}";
        }


    }
}
