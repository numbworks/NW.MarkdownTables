using System;

namespace NW.MarkdownTables
{
    public static class MessageCollection
    {

        # region MarkdownTabulizer
        
        public static Func<string, string> CantHaveZeroItems = (name) => $"{name} can't have zero items.";
        public static Func<NullHandlingStrategies, string> ProvidedNullHandlingStrategyNotValid =
            (strategy) => $"The provided '{nameof(NullHandlingStrategies)}' strategy is not valid ('{strategy.ToString()}').";

        #endregion

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2021

*/
