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
        _connection.Execute("CREATE TABLE IF NOT EXIST flashcard(id AUTOINCREMENT, name varchar(50))");
        _connection.Close();
    }
    void Add()
    {

    }

}