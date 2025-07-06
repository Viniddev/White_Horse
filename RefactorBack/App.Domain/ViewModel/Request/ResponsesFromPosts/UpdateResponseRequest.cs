using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.ResponsesFromPosts;

public class UpdateResponseRequest
{
    [Required]
    public Guid ResponseId { get; set; }

    [Required]
    [MaxLength(300)]
    public string Message { get; set; } = string.Empty;
}
