using System.Collections.Generic;

namespace BanKai.Basic.Common
{
#pragma warning disable 162
    // ReSharper disable HeuristicUnreachableCode
    // ReSharper disable LoopCanBeConvertedToQuery

    internal class ImplIteratorUsingYieldDemoClass
    {
        public IEnumerable<int> GetOneToTen()
        {
            for (int i = 1; i <= 10; ++i)
            {
                yield return i;
            }
        }

        public IEnumerable<int> GetOneToThreeWithMultipleYields()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public IEnumerable<int> GetOnToThreeButBreakingAtTwo()
        {
            yield return 1;
            yield return 2;
            yield break;
            yield return 3;
        }

        public IEnumerable<int> GetEvenNumber(IEnumerable<int> getOneToTen)
        {
            foreach (int numberInCollection in getOneToTen)
            {
                if (numberInCollection % 2 == 0)
                {
                    yield return numberInCollection;
                }
            }
        }
    }

    // ReSharper restore LoopCanBeConvertedToQuery
    // ReSharper restore HeuristicUnreachableCode
#pragma warning restore 162
}