﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace NW.MarkdownTabulizer
{
    public class MarkdownTabulizer : IMarkdownTabulizer
    {

        // Fields
        // Properties
        // Constructors
        public MarkdownTabulizer() { }

        // Methods (public)
        public string ToMarkdownRow
            (bool smallerFontSize, params string[] values)
        {

            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length == 0)
                throw new ArgumentException(MessageCollection.CantHaveZeroItems.Invoke(nameof(values)));

            return ToMarkdownLine(smallerFontSize, values);

        }
        public string ToMarkdownRow<T>(bool smallerFontSize, T obj)
        {

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return ToMarkdownRow(smallerFontSize, GetPropertyNames(obj));

        }
        public string ToMarkdownHeader
            (bool smallerFontSize, params string[] values)
        {

            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length == 0)
                throw new ArgumentException(MessageCollection.CantHaveZeroItems.Invoke(nameof(values)));

            string header = ToMarkdownLine(smallerFontSize, values);
            header += Environment.NewLine;
            header += CreateMarkdownRow("---", (uint)values.Length);

            return header;

        }
        public string ToMarkdownHeader<T>(bool smallerFontSize, T obj)
        {

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return ToMarkdownHeader(smallerFontSize, GetPropertyValues(obj));

        }
        public string ToMarkdownTable<T>(bool smallerFontSize, T obj)
        {

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return string.Join(
                    ToMarkdownRow(smallerFontSize, GetPropertyNames(obj)),
                    Environment.NewLine,
                    ToMarkdownHeader(smallerFontSize, GetPropertyValues(obj))
                );

        }
        public string ToMarkdownTable<T>
            (bool smallerFontSize, NullHandlingStrategies strategy, List<T> rows)
        {

            if (strategy != NullHandlingStrategies.DoNothing
                    && strategy != NullHandlingStrategies.RemoveNulls
                    && strategy != NullHandlingStrategies.ReplaceNullsWithNullMarkdownLines)
                throw new ArgumentException(MessageCollection.ProvidedNullHandlingStrategyNotValid.Invoke(strategy));
            if (rows == null)
                throw new ArgumentNullException(nameof(rows));
            if (rows.Count == 0)
                throw new ArgumentException(MessageCollection.CantHaveZeroItems.Invoke(nameof(rows)));

            if (strategy == NullHandlingStrategies.RemoveNulls)
                rows = rows.Where(row => row != null).ToList();

            string str = ToMarkdownHeader(smallerFontSize, rows[0]);
            if (rows.Count > 1)
            {

                str += Environment.NewLine;
                foreach (T row in rows)
                    str += ProcessRow(smallerFontSize, strategy, row);

            }

            return str;

        }

        // Methods (private)
        private string ToMarkdownLine
            (bool smallerFontSize, params string[] values)
        {

            string line = $"|{string.Join("|", values)}|";
            if (smallerFontSize)
                line = $"|<sub>{string.Join("</sub>|<sub>", values)}</sub>|";

            return line;

        }
        private string CreateMarkdownRow
            (string token, uint length, bool includeSubTags = false)
        {

            string[] repetitions = Enumerable.Repeat(token, (int)length).ToArray();

            if (includeSubTags)
                return $"|<sub>{string.Join("</sub>|<sub>", repetitions)}</sub>|";
            else
                return $"|{string.Join("|", repetitions)}|";

        }
        private string[] GetPropertyNames<T>(T obj)
            => obj.GetType().GetProperties().Select(property => property.Name).ToArray();
        private string[] GetPropertyValues<T>(T obj)
        {

            List<string> values = new List<string>();
            string[] propertyNames = GetPropertyNames(obj);
            foreach (string propertyName in propertyNames)
                values.Add(obj.GetType().GetProperty(propertyName).GetValue(obj, null)?.ToString() ?? "null");

            return values.ToArray();

        }
        private uint GetPropertyCount(Type t)
            => (uint)t.GetProperties().Length;
        private string ProcessRow<T>
            (bool smallerFontSize, NullHandlingStrategies strategy, T row)
        {

            string str = string.Empty;

            if (row == null 
                    && strategy == NullHandlingStrategies.ReplaceNullsWithNullMarkdownLines)
                str += CreateMarkdownRow("null", GetPropertyCount(typeof(T)), smallerFontSize);
            else
                str += ToMarkdownRow(smallerFontSize, row);

            str += Environment.NewLine;

            return str;

        }

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
