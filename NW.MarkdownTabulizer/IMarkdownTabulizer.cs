using System.Collections.Generic;

namespace NW.MarkdownTabulizer
{
    public interface IMarkdownTabulizer
    {
        string ToMarkdownTable(bool smallerFontSize, bool isHeader, params string[] values);
        string ToMarkdownTable<T>(bool smallerFontSize, bool isHeader, T obj);
        string ToMarkdownTable<T>(List<T> rows, bool smallerFontSize, NullHandlingStrategies strategy);
    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/