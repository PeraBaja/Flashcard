namespace Flashcards.Models;
class FlaschardDTO(Flashcard flashcard)
{
    public ulong Id;
    public readonly string Front = flashcard.Front;

    public readonly string Reverse = flashcard.Reverse;
}