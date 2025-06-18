﻿P_W01 Explain problems in the following code

<pre lang="csharp">
using CodeProblems;

var person = new PersonName("Maria", "Curie", "Skłodowska");
foreach (var part in person)
    Console.WriteLine(part.ToUpper());

var logger = new FileLogger("log.txt");
logger.Log("Program started");
logger.Log("Processing data...");

var values = new List<int> { 1, 2, 3, 4, 5 };
foreach (var value in values)
{
    if (value % 2 == 0)
        values.Remove(value);
}

namespace CodeProblems
{
    public class PersonName : IEnumerable<string>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }

        public PersonName(string first, string last, string middle = null)
        {
            FirstName = first;
            LastName = last;
            MiddleName = middle;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return FirstName;
            yield return MiddleName;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    public class FileLogger : IDisposable
    {
        private readonly StreamWriter _writer;

        public FileLogger(string path) => _writer = new StreamWriter(path);

        public void Log(string message) => _writer.WriteLine($"{DateTime.Now}: {message}");

        public void Dispose()
        {

        }
    }
}
</pre>

**Your answers:**
Description: the code creates a person object and prints out parts of the name in uppercase, then it logs a couple of messages to a file, and finally tries to remove even numbers from a list.

Issues: the PersonName class doesn’t return the last name when looping through it, which is a mistake. The FileLogger class has an empty Dispose method, so the file stream won’t actually be closed which could lead to data not being saved properly. The code also tries to change a list while looping through it with foreach, which causes an error. A better way would be to use something like RemoveAll. Lastly, the list is missing its type which would normally be List<int> instead of just List.
