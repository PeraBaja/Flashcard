namespace Flashcards.Models;
class FlaschardDTO(Flashcard flashcard)
{
    public required ulong Id;
    public readonly string Front = flashcard.Front;

    public readonly string Reverse = flashcard.Reverse;
}