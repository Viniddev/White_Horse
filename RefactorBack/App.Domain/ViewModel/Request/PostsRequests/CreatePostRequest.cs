using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.PostsRequests;

public class CreatePostRequest
{
    [Required]
    public Guid CreatorId { get; set; }
    [Required]
    [MaxLength(120)]
    public string Topic { get; set; } = string.Empty;
    [Required]
    [MaxLength(600)]
    public string Content { get; set; } = string.Empty;
}
