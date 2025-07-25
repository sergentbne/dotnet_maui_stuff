using Microsoft.Data.Sqlite;
//NOTE: IGNORER LES "NOT AVAILABLE" DE ANDROID. C'EST JUSTE PAS SUR L'ORDI

namespace start_maui;

public static class FileHandler
{
    private static readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
    private static SqliteConnection? sqlconnection;

    public static void BeginConnection()
    {
        sqlconnection = new SqliteConnection($"Data Source={dbPath}");
        string commandText = @"CREATE TABLE IF NOT EXISTS Checkboxes (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT,
    DueDate DATETIME,
    Checked BOOLEAN,
    CreationDate DATETIME,
    LastUpdate DATETIME
);
";

        var connection = sqlconnection.CreateCommand();
        connection.CommandText = commandText;
        connection.ExecuteNonQuery();
        return;
    }
    public static void StopConnection()
    {
        sqlconnection?.Close();
        sqlconnection?.Dispose();
        return;
    }
    public static void InsertData(string name, DateTime dueDate, bool is_checked, DateTime creationDate, DateTime lastUpdate)
    {
        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();

        FormattableString commandText =
        @"INSERT OR IGNORE INTO Checkboxes (Name, DueDate, Checked, CreationDate, LastUpdate)
        VALUES ({0}, {1}, {2}, {3}, {4});";
        commandText.Format(name, dueDate, is_checked, creationDate, lastUpdate);


        command.CommandText = commandText;
        command.ExecuteNonQuery();
    }
    public class RectangleData
    {
        public class RectangleData
        {
            public class RectangleData(string name, DateTime dueDate, bool is_checked, DateTime creationDate, DateTime lastUpdate)
            {
                // Private attributes
                private string name = name;
                private DateTime dueDate = dueDate;
                private bool is_checked = is_checked;
                private DateTime creationDate = creationDate;
                private DateTime lastUpdate = lastUpdate;

                // Public properties
                public string Name
                {
                    get { return name; }
                    set { name = value; }
                }

                public DateTime DueDate
                {
                    get { return dueDate; }
                    set { dueDate = value; }
                }

                public bool IsChecked
                {
                    get { return is_checked; }
                    set { is_checked = value; }
                }

                public DateTime CreationDate
                {
                    get { return creationDate; }
                    set { creationDate = value; }
                }

                public DateTime LastUpdate
                {
                    get { return lastUpdate; }
                    set { lastUpdate = value; }
                }
            }

        }


    }
    public static Get_data()
    {
        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();

        string commandText =
        @"SELECT * FROM Checkboxes;";


        command.CommandText = commandText;
        command.();
    }
}

