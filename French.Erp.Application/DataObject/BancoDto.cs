using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace French.Erp.Application.DataObject
{

    public class BancoDto
    {
        [JsonPropertyName("bancoId")]
        [Required(ErrorMessage = "O ID do banco é obrigatório")]
        public int BancoId { get; set; }

        [JsonPropertyName("codigo")]
        [Required(ErrorMessage = "O código é obrigatório")]
        [StringLength(10, ErrorMessage = "Código deve ter no máximo 10 caracteres")]
        public string Codigo { get; set; } = string.Empty;

        [JsonPropertyName("apelido")]
        [Required(ErrorMessage = "O apelido é obrigatório")]
        [StringLength(50, ErrorMessage = "Apelido deve ter no máximo 50 caracteres")]
        public string Apelido { get; set; } = string.Empty;

        [JsonPropertyName("nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        [Required(ErrorMessage = "O status é obrigatório")]
        public bool Status { get; set; }
    }
}
