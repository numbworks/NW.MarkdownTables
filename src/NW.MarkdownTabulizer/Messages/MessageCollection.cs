using System;

namespace NW.MarkdownTabulizer
{
    public static class MessageCollection
    {

        // MarkdownTabulizer
        public static Func<string, string> CantHaveZeroItems = (name) => $"{name} can't have zero items.";
        public static Func<NullHandlingStrategies, string> ProvidedNullHandlingStrategyNotValid =
            (strategy) => $"The provided '{nameof(NullHandlingStrategies)}' strategy is not valid ('{strategy.ToString()}').";

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
