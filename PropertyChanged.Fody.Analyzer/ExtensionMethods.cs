﻿global using static ExtensionMethods;

using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

static class ExtensionMethods
{
    public static IncrementalValuesProvider<TSource> ExceptNullItems<TSource>(this IncrementalValuesProvider<TSource?> source)
    {
        return source.Where(static item => item is not null)!;
    }

    public static IEnumerable<BaseTypeSyntax> GetInterfaceTypeCandidates(this BaseListSyntax? baseListSyntax, string name = "INotifyPropertyChanged")
    {
        return baseListSyntax == null ? Enumerable.Empty<BaseTypeSyntax>() : baseListSyntax.Types.Where(type => type.ToString().Equals(name));
    }

    public static string? NullIfEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value) ? null : value;
    }

    [Conditional("DEBUG")]
    public static void Log(string message)
    {
        // File.AppendAllText(@"c:\temp\generator.log", $"{DateTime.Now}: {message}\r\n");
    }
}
