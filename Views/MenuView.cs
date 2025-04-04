using Flashcards.Controller;
namespace Flashcards.Views;
class MenuView(FlashcardController flashcardController, StackController stackController)
{
    void Display()
    {
        Console.WriteLine("Welcome to the flashcard study app. Please select an option: " +
        "list (study sessions - stacks - flashcards) \n" +
        "add (flashcards - stacks) \n" +
        "delete (flashcards - stacks) \n" +
        "modify (flashcards - stacks) \n" +
        "study (the name of the stack you wanna study)");
    }
}