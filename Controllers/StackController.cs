using Dapper;
using Flashcards.Models;
using Microsoft.Data.Sqlite;
namespace Flashcards.Controller;

class StackController(string dbConnection)
{
    readonly SqliteConnection _connection = new(dbConnection);
    public void CreateTable()
    {
        _connection.Open();
        _connection.Execute("CREATE TABLE IF NOT EXISTS stacks(id INTEGER PRIMARY KEY AUTOINCREMENT, name varchar(50) UNIQUE)");
        _connection.Close();
    }
    public void Add(string name)
    {
        if (Exists(name)) throw new ArgumentException($"The stack with name '{name}' already exist");
        FlashcardStack stack = new() { Name = name };
        _connection.Open();
        _connection.Execute("INSERT INTO stacks (name) VALUES($Name)", stack);
        _connection.Close();
    }
    public bool Exists(string name)
    {
        _connection.Open();
        ulong quantityOf = _connection.ExecuteScalar<ulong>("SELECT Count(*) FROM stacks WHERE name = $Name ", new { Name = name });
        _connection.Close();
        return quantityOf != 0;
    }
    public void Delete(string name)
    {
        if (Exists(name) is false) throw new ArgumentException($"The stack with name '{name}' not exist");
        _connection.Open();
        _connection.Execute("DELETE FROM stacks WHERE name = $Name", new { Name = name });
        _connection.Close();
    }
    public FlashcardStack GetBy(string name, FlashcardController flashcardController)
    {
        if (Exists(name) is false) throw new ArgumentException($"The stack with name '{name}' not exist");
        _connection.Open();
        var stack = _connection.QuerySingle<FlashcardStack>("Select id, name FROM stacks WHERE name = $Name", new { Name = name });
        foreach (var flashcard in flashcardController.GetFlashcardsBy(name))
        {
            stack.Flashcards.Push(flashcard);
        }


        _connection.Close();
        return stack;
    }
    public ulong GetStackIdWith(string name)
    {
        if (Exists(name) is false) throw new ArgumentException($"The stack with name '{name}' not exist");
        _connection.Open();
        var stack = _connection.QuerySingle<FlashcardStack>("Select id FROM stacks WHERE name = $Name", new { Name = name });
        _connection.Close();
        return stack.Id;
    }
    public void Modify(string stackNameToModify, string? newName)
    {
        if (Exists(stackNameToModify)) throw new ArgumentException($"The stack with name '{stackNameToModify}' already exist");
        FlashcardStack stack = GetBy(stackNameToModify);
        _connection.Open();
        _connection.Execute("UPDATE stacks WHERE name = $Name", );
        _connection.Close();
    }


}