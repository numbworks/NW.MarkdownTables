using System;
using System.Collections.Generic;

namespace NW.MarkdownTables
{
    public enum NullHandlingStrategies
    {

        /// <summary>If one row is null, an <seealso cref="ArgumentNullException"/> will be thrown.</summary>
        ThrowException,

        /// <summary>All the null rows will be removed from the provided <seealso cref="List{T}"/> before processing it.</summary>
        RemoveNullItems,

        /// <summary>All the null rows will be replaced with null Markdown lines.</summary>
        ReplaceNullsWithNullMarkdownLines,

    }

}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
