using System.Collections.Generic;
using ConsoleTables;

public static class LinqExtentions{
    public static void Dump<T>(this IEnumerable<T> source){ 
        ConsoleTable.From(source).Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Alternative);
    }
}