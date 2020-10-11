using System;

namespace NW.MarkdownTabulizer
{
    public static class MessageCollection
    {

        // MarkdownTabulizer
        public static Func<string, string> CantHaveZeroItems = (name) => $"{name} can't have zero items.";
        public static Func<NullHandlingStrategies, string> ProvidedNullHandlingStrategyNotValid =
            (strategy) => $"The provided '{nameof(NullHandlingStrategies)}' strategy is not valid ('{strategy.ToString()}').";
        public static Func<OutputOptions, string> ProvidedOutputOptionNotValid =
            (option) => $"The provided '{nameof(OutputOptions)}' option is not valid ('{option.ToString()}').";

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.10.2020

*/
