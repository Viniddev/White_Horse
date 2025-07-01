using App.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.ResponsesFromPosts;

public class CreateResponseRequest
{
    [Required]
    public Guid CreatorId { get; set; }
    [Required]
    public Guid PostId { get; set; }
    [Required]
    [MaxLength(300)]
    public string Message { get; set; } = string.Empty;
}
