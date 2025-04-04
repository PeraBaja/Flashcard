namespace Flashcard.Views;


class UserOption
{
    public readonly string action;
    public readonly string entity;

    readonly string[] _allowedActions = ["list", "delete", "modify", "add"];

    public UserOption(string userInput)
    {
        string[] args = userInput.Split(' ', 2);
        if (_allowedActions.Contains(args[0]) is false)
            throw new ArgumentException("Non existent action");


        if (args[1] == "study session" && args[0] is not "list")
            throw new ArgumentException("Action not valid on selected entity");

        action = args[0];
        entity = args[1];
    }
}