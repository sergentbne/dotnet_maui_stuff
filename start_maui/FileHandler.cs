using System;
using System.Numerics;
using Microsoft.Data.Sqlite;


namespace start_maui;

public static class FileHandler
{
    private static readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
    private static SqliteConnection? sqlconnection;

    public static void BeginConnection()
    {
        sqlconnection = new SqliteConnection($"Data Source={dbPath}");
        return;
    }
    public static void StopConnection()
    {
        sqlconnection?.Close();
        sqlconnection?.Dispose();
        return;
    }
    public static void InsertData()
    {
        var command = sqlconnection?.CreateCommand();
        command.CommandText
    }

}
