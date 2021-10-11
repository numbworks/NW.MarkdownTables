using System;
using System.Collections.Generic;
using NW.MarkdownTables.Strategies;

namespace NW.MarkdownTables
{
    /// <summary>The entry point of this library.</summary>
    public interface IMarkdownTabulizer
    {

        /// <summary>
        /// Creates a Markdown table row out of the provided <paramref name="values"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        string ToMarkdownRow(bool smallerFontSize, params string[] values);

        /// <summary>
        /// Creates a Markdown table row out of the provided <paramref name="obj"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string ToMarkdownRow<T>(bool smallerFontSize, T obj);

        /// <summary>
        /// Creates a Markdown table header out of the provided <paramref name="values"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        string ToMarkdownHeader(bool smallerFontSize, params string[] values);

        /// <summary>
        /// Creates a Markdown table header out of the provided <paramref name="obj"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string ToMarkdownHeader<T>(bool smallerFontSize, T obj);

        /// <summary>
        /// Creates a Markdown table out of the provided <paramref name="obj"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string ToMarkdownTable<T>(bool smallerFontSize, T obj);

        /// <summary>
        /// Creates a Markdown table out of the provided <paramref name="rows"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        string ToMarkdownTable<T>(bool smallerFontSize, NullHandlingStrategies strategy, List<T> rows);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 11.10.2021
*/