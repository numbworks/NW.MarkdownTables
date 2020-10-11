using System;
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
        public string ToMarkdownTable
            (bool smallerFontSize, bool isHeader, params string[] values)
        {

            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length == 0)
                throw new ArgumentException(MessageCollection.CantHaveZeroItems.Invoke(nameof(values)));

            string line = $"|{string.Join("|", values)}|";

            if (smallerFontSize)
                line = $"|<sub>{string.Join("</sub>|<sub>", values)}</sub>|";

            if (isHeader)
            {

                line += Environment.NewLine;
                line += CreateMarkdownRow("---", (uint)values.Length);

            }

            return line;

        }
        public string ToMarkdownTable<T>(List<T> rows, bool smallerFontSize, NullHandlingStrategies strategy)
        {

            if (rows == null)
                throw new ArgumentNullException(nameof(rows));
            if (rows.Count == 0)
                throw new ArgumentException(MessageCollection.CantHaveZeroItems.Invoke(nameof(rows)));
            if (!GetEnumValues(typeof(NullHandlingStrategies)).Contains(strategy.ToString()))
                throw new ArgumentException(MessageCollection.ProvidedNullHandlingStrategyNotValid.Invoke(strategy));

            if (strategy == NullHandlingStrategies.RemoveNulls)
                rows = rows.Where(row => row != null).ToList();

            string str = ToMarkdownTable<T>(smallerFontSize, true, rows[0]);

            if (rows.Count > 1)
            {

                str += Environment.NewLine;
                foreach (T row in rows)
                    str += ProcessRow<T>(row, smallerFontSize, strategy);

            }

            return str;

        }
        public string ToMarkdownTable<T>
            (bool smallerFontSize, bool isHeader, T obj)
        {

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (isHeader)
                return ToMarkdownTable(smallerFontSize, true, GetPropertyNames<T>(obj));
            else
                return ToMarkdownTable(smallerFontSize, false, GetPropertyValues<T>(obj));

        }

        // Methods (private)
        private string CreateMarkdownRow(string token, uint length, bool includeSubTags = false)
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
        private string[] GetEnumValues(Type t)
            => Enum.GetNames(t);
        private uint GetPropertyCount(Type t)
            => (uint)t.GetProperties().Length;
        private string ProcessRow<T>(T row, bool smallerFontSize, NullHandlingStrategies strategy)
        {

            string str = string.Empty;

            if (row == null && strategy == NullHandlingStrategies.ReplaceNullsWithEmptyObjects)
                str += CreateMarkdownRow("null", GetPropertyCount(typeof(T)), smallerFontSize);
            else
                str += ToMarkdownTable<T>(smallerFontSize, false, row);

            str += Environment.NewLine;

            return str;

        }

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
