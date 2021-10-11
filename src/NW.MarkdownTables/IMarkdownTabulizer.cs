using System.Collections.Generic;
using NW.MarkdownTables.Strategies;

namespace NW.MarkdownTables
{
    public interface IMarkdownTabulizer
    {

        string ToMarkdownRow
            (bool smallerFontSize, params string[] values);
        string ToMarkdownHeader
            (bool smallerFontSize, params string[] values);
        string ToMarkdownRow<T>(bool smallerFontSize, T obj);
        string ToMarkdownHeader<T>(bool smallerFontSize, T obj);
        string ToMarkdownTable<T>(bool smallerFontSize, T obj);
        string ToMarkdownTable<T>
            (bool smallerFontSize, NullHandlingStrategies strategy, List<T> rows);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 11.10.2021
*/