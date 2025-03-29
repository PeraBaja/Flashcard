using Dapper;
using Microsoft.Data.Sqlite;
namespace Flashcard.Models;
class FlashcardController(string dbConnection)
{
    readonly SqliteConnection _connection = new(dbConnection);

    void CreateTable()
    {
        _connection.Open();
        _connection.Execute("CREATE TABLE IF NOT EXIST flashcard(id AUTOINCREMENT, name varchar(50))");
        _connection.Close();
    }
    void Add()
    {

    }

}