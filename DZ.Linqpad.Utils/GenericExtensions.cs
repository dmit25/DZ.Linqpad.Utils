using System;
using System.Collections.Generic;

namespace DZ.Linqpad.Utils
{
    public static class GenericExtensions
    {
        public static TOut Apply<TIn, TOut>(
            this TIn input,
            Func<TIn, TOut> func
            )
        {
            return func(input);
        }

        public static TOut Apply<TIn, TIn1, TOut>(
            this TIn input,
            Func<TIn, TIn1, TOut> func,
            TIn1 input1
            )
        {
            return func(input, input1);
        }

        public static TOut Apply<TIn, TIn1, TIn2, TOut>(
            this TIn input,
            Func<TIn, TIn1, TIn2, TOut> func,
            TIn1 input1,
            TIn2 input2
            )
        {
            return func(input, input1, input2);
        }

        public static TOut Apply<TIn, TIn1, TIn2, TIn3, TOut>(
            this TIn input,
            Func<TIn, TIn1, TIn2, TIn3, TOut> func,
            TIn1 input1,
            TIn2 input2,
            TIn3 input3
            )
        {
            return func(input, input1, input2, input3);
        }

        public static TOut Apply<TIn, TIn1, TIn2, TIn3, TIn4, TOut>(
            this TIn input,
            Func<TIn, TIn1, TIn2, TIn3, TIn4, TOut> func,
            TIn1 input1,
            TIn2 input2,
            TIn3 input3,
            TIn4 input4
            )
        {
            return func(input, input1, input2, input3, input4);
        }


        public static void Apply<TIn, TOut>(
            this TIn input,
            Action<TIn> func
            )
        {
            func(input);
        }

        public static void Apply<TIn, TIn1>(
            this TIn input,
            Action<TIn, TIn1> func,
            TIn1 input1
            )
        {
            func(input, input1);
        }

        public static void Apply<TIn, TIn1, TIn2>(
            this TIn input,
            Action<TIn, TIn1, TIn2> func,
            TIn1 input1,
            TIn2 input2
            )
        {
            func(input, input1, input2);
        }

        public static void Apply<TIn, TIn1, TIn2, TIn3>(
            this TIn input,
            Action<TIn, TIn1, TIn2, TIn3> func,
            TIn1 input1,
            TIn2 input2,
            TIn3 input3
            )
        {
            func(input, input1, input2, input3);
        }

        public static void Apply<TIn, TIn1, TIn2, TIn3, TIn4>(
            this TIn input,
            Action<TIn, TIn1, TIn2, TIn3, TIn4> func,
            TIn1 input1,
            TIn2 input2,
            TIn3 input3,
            TIn4 input4
            )
        {
            func(input, input1, input2, input3, input4);
        }

        public static void ForEach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (var x1 in input)
            {
                action(x1);
            }
        }
    }
}