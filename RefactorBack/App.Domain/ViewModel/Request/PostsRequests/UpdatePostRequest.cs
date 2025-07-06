using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.PostsRequests;

public class UpdatePostRequest
{
    [Required]
    public Guid PostId { get; set; }

    [Required]
    [MaxLength(600)]
    public string Content { get; set; } = string.Empty;
}
