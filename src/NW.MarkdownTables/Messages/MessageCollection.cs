using System;
using NW.MarkdownTables.Strategies;

namespace NW.MarkdownTables.Messages
{
    ///<summary>Collects all the messages used for logging and exceptions.</summary>
    public static class MessageCollection
    {

        # region MarkdownTabulizer
        
        public static Func<string, string> CantHaveZeroItems = (name) => $"{name} can't have zero items.";
        public static Func<NullHandlingStrategies, string> ProvidedNullHandlingStrategyNotValid =
            (strategy) => $"The provided '{nameof(NullHandlingStrategies)}' strategy is not valid ('{strategy}').";

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 11.10.2021
*/