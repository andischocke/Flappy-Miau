﻿using Flappy_Miau.Models;
using SQLite;

namespace Flappy_Miau.Services;

public class Database
{
    private SQLiteAsyncConnection Connection { get; set; }

    public Database()
    {
        Connection = Connect();
        CreateTables();
    }

    private SQLiteAsyncConnection Connect()
    {
        string databaseName = "database.db3";
        string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
        SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        return new SQLiteAsyncConnection(databasePath, flags);
    }

    private void CreateTables()
    {
        Connection.CreateTableAsync<Score>();
    }

    public async Task<List<T>> ReadTable<T>() where T : new()
    {
        return await Connection.Table<T>().ToListAsync();
    }

    public async Task CreateItem<T>(T item)
    {
        await Connection.InsertAsync(item);
    }
}