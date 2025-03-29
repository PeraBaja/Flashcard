using System.ComponentModel.DataAnnotations;
namespace Flashcard.Models;

class FlashcardStack
{
    public Stack<Flashcard> Flashcards { get; set; } = new();

    [MaxLengthAttribute(50, ErrorMessage = "Name cannot be more than 50 characters long")]
    public required string Name { get; set; }
}