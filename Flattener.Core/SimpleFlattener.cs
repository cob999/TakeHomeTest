using System;
using System.Collections.Generic;

namespace Flattener.Core
{
    public class SimpleFlattener : ICanFlattenArrays
    {
        public int[] Flatten(object input)
        {
            var workingResultSet = new List<int>();

            FlattenRecursively(input, workingResultSet);

            return workingResultSet.ToArray();
        }

        private static void FlattenRecursively(object input, ICollection<int> workingResultSet)
        {
            switch (input)
            {
                case Array a:
                    foreach (var item in a)
                    {
                        FlattenRecursively(item, workingResultSet);
                    }
                    break;

                case int i:
                    workingResultSet.Add(i);
                    break;

                default:
                    throw new InvalidOperationException("Input must be an integer or an array of integers.");
            }
        }
    }
}
