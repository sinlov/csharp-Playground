using System;
using System.Collections.Generic;

namespace FastCodeZoo.LinQPlus
{
    public static class SearchPlus
    {
        /// <summary>
        /// please Sort Source before use this method
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="val">target</param>
        /// <param name="start">start index</param>
        /// <param name="end">end index</param>
        /// <param name="pos">insert position</param>
        /// <param name="reverse">is reverse</param>
        /// <returns>find index, if not found then return -1</returns>
        public static int BinarySearchMemberIndex
        (
            List<SearchItem> source,
            string val,
            int start,
            int end,
            ref int pos,
            bool reverse = false
        )
        {
            int temp = -1;
            if (source == null || source.Count == 0)
            {
                return temp;
            }

            while (start <= end)
            {
                var position = (start + end) / 2;
                if (String.Compare(val, source[position].Name, StringComparison.Ordinal) > 0)
                {
                    if (reverse)
                    {
                        end = position - 1;
                        pos = position;
                    }
                    else
                    {
                        start = position + 1;
                        pos = position;
                    }
                }
                else if (String.Compare(val, source[position].Name, StringComparison.Ordinal) < 0)
                {
                    if (reverse)
                    {
                        start = position + 1;
                        pos = position + 1;
                    }
                    else
                    {
                        end = position - 1;
                        pos = position;
                    }
                }
                else
                {
                    temp = position;
                    pos = position;
                    break;
                }
            }

            return temp;
        }
    }
}