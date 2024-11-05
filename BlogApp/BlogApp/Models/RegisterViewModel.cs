using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
	public class RegisterViewModel
	{
		// Kullanıcı adı
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[Display(Name = "Username")]  // Kullanıcı arayüzünde bu alan "Username" olarak gösterilecektir.
		public string? UserName { get; set; }

		// Ad Soyad
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[Display(Name = "Ad Soyad")]  // Kullanıcı arayüzünde bu alan "Ad Soyad" olarak gösterilecektir.
		public string? Name { get; set; }

		// Eposta
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[EmailAddress]  // Girilen değerin geçerli bir e-posta formatında olması gerektiğini belirtir.
		[Display(Name = "Eposta")]  // Kullanıcı arayüzünde bu alan "Eposta" olarak gösterilecektir.
		public string? Email { get; set; }

		// Parola
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[StringLength(10, ErrorMessage = "{0} alanı en az {2} karekter uzunluğunda olmalıdır.", MinimumLength = 6)]
		// Parola en az 6 karakter ve en fazla 10 karakter uzunluğunda olmalıdır.
		[DataType(DataType.Password)]  // Bu alanın parola olarak işlenmesi gerektiğini belirtir.
		[Display(Name = "Parola")]  // Kullanıcı arayüzünde bu alan "Parola" olarak gösterilecektir.
		public string? Password { get; set; }

		// Parola Onayı
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[DataType(DataType.Password)]  // Bu alanın parola olarak işlenmesi gerektiğini belirtir.
		[Compare(nameof(Password))]  // Bu alanın "Password" alanı ile aynı olması gerektiğini belirtir.
		[Display(Name = "Parola")]  // Kullanıcı arayüzünde bu alan "Parola" olarak gösterilecektir.
		public string? ConfirmPassword { get; set; }
	}
}
