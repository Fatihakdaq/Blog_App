using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
	public class LoginViewModel
	{
		// Email alanı:
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[EmailAddress]  // Girilen değerin geçerli bir e-posta formatında olması gerektiğini belirtir.
		[Display(Name = "Eposta")]  // Formda görüntülenecek etiketi belirtir (Türkçe olarak "Eposta" yazılacaktır).
		public string? Email { get; set; }

		// Password (Parola) alanı:
		[Required]  // Bu alanın da boş geçilemeyeceğini belirtir.
		[StringLength(10, ErrorMessage = "{0} alanı en az {2} karekter uzunluğunda olmalıdır.", MinimumLength = 6)]
		// Parola alanının en fazla 10 karakter ve en az 6 karakter olması gerektiğini belirtir.
		[DataType(DataType.Password)]  // Bu alanın parolanın gizlenmesi gerektiğini belirtir (örn. HTML'de <input type="password">).
		[Display(Name = "Parola")]  // Formda görüntülenecek etiketi belirtir (Türkçe olarak "Parola" yazılacaktır).
		public string? Password { get; set; }
	}
}
