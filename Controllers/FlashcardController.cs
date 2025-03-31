using Dapper;
using Microsoft.Data.Sqlite;
using Flashcards.Models;
namespace Flashcards.Controller;
class FlashcardController(string dbConnection, StackController stackController)
{
    readonly SqliteConnection _connection = new(dbConnection);

    public void CreateTable()
    {
        _connection.Open();
        _connection.Execute("CREATE TABLE IF NOT EXISTS flashcards(id INTEGER PRIMARY KEY AUTOINCREMENT, stackId int, front varchar(350), reverse varchar(350))");
        _connection.Close();
    }
    public void Add(string front, string reverse, string stackName)
    {
        var stack = stackController.GetBy(stackName, this);
        Flashcard flashcard = new() { StackId = stack.Id, Front = front, Reverse = reverse };
        _connection.Open();
        _connection.Execute("INSERT INTO flashcards (front, reverse, stackId) VALUES($Front, $Reverse, $StackId)", flashcard);
        _connection.Close();

    }
    public IEnumerable<Flashcard> GetFlashcardsBy(string stackName)
    {
        ulong stackId = stackController.GetStackIdWith(stackName);
        _connection.Open();
        var flashcards = _connection.Query<Flashcard>("SELECT * FROM flashcards WHERE stackId = $Id", new { Id = stackId });
        _connection.Close();
        return flashcards;
    }
}