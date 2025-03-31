using Dapper;
using Flashcard.Models;
using Microsoft.Data.Sqlite;
namespace Flashcard.Controller;

class StackController(string dbConnection)
{
    readonly SqliteConnection _connection = new(dbConnection);
    readonly List<FlashcardStack> Stacks = [];
    void CreateTable()
    {
        _connection.Open();
        _connection.Execute("CREATE TABLE IF NOT EXIST stacks(id int AUTOINCREMENT, name varchar(50) UNIQUE)");
        _connection.Close();
    }
    void Add(string name)
    {
        if (Exists(name)) throw new ArgumentException($"The stack with name '{name}' already exist");
        FlashcardStack stack = new() { Name = name };
        _connection.Open();
        _connection.Execute("INSERT INTO stacks (name) VALUES($Name)", name);
        _connection.Close();
        Stacks.Add(stack);
    }
    bool Exists(string name)
    {
        _connection.Open();
        ulong quantityOf = _connection.ExecuteScalar<ulong>("SELECT Count(*) FROM coding_session WHERE name = @Name ", new { Name = name });
        _connection.Close();
        return quantityOf != 0;
    }

}