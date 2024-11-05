using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
	public class PostCreateViewModel
	{
		// Posta özel tanımlayıcı (ID)
		public int PostId { get; set; }

		// Başlık
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[Display(Name = "Başlık")]  // Kullanıcı arayüzünde bu alan "Başlık" olarak gösterilecektir.
		public string? Title { get; set; }

		// Açıklama
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[Display(Name = "Açıklama")]  // Kullanıcı arayüzünde bu alan "Açıklama" olarak gösterilecektir.
		public string? Description { get; set; }

		// İçerik
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[Display(Name = "İçerik")]  // Kullanıcı arayüzünde bu alan "İçerik" olarak gösterilecektir.
		public string? Content { get; set; }

		// URL
		[Required]  // Bu alanın boş geçilemeyeceğini belirtir.
		[Display(Name = "Url")]  // Kullanıcı arayüzünde bu alan "Url" olarak gösterilecektir.
		public string? Url { get; set; }

		// Gönderi aktif mi?
		public bool IsActive { get; set; }  // Bu alan gönderinin aktif olup olmadığını belirtir.
	}
}
