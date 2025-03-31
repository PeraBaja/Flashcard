using System.ComponentModel.DataAnnotations;
namespace Flashcards.Models;

class Flashcard
{
    public ulong Id { get; set; }

    public required ulong StackId { get; set; }

    [MaxLengthAttribute(350, ErrorMessage = "Front cannot be more than 350 characters long")]
    public required string Front { get; set; }
    [MaxLengthAttribute(350, ErrorMessage = "Reverse cannot be more than 350 characters long")]
    public required string Reverse { get; set; }
}