using System.Collections.Generic;

namespace NW.MarkdownTabulizer
{
    public interface IMarkdownTabulizer
    {

        string ToMarkdownLine
            (bool smallerFontSize, bool isHeader, params string[] values);
        string ToMarkdown<T>
            (bool smallerFontSize, OutputOptions option, T obj);
        string ToMarkdownTable<T>
            (bool smallerFontSize, NullHandlingStrategies strategy, List<T> rows);

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/