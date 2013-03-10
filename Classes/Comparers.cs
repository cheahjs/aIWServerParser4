using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentOwl.BetterListView;

namespace aIWServerParser4.Classes
{
    public class ItemComparer : BetterListViewItemComparer
    {
        protected override int CompareSubItems(BetterListViewSubItem subItemA, BetterListViewSubItem subItemB, BetterListViewSortMethod sortMethod, int order)
        {
            if (subItemA == null || subItemB == null)
                return base.CompareSubItems(subItemA, subItemB, sortMethod, order);
            int valueA = 0;
            int valueB = 0;
            int result;
            if (!int.TryParse(subItemA.Text, out valueA) || !int.TryParse(subItemB.Text, out valueB))
                if (subItemA.Text.Split('/').Length != 2 || subItemB.Text.Split('/').Length != 2)
                    return base.CompareSubItems(subItemA, subItemB, sortMethod, order);
                else
                {
                    if (!int.TryParse(subItemA.Text.Split('/')[0], out valueA) || !int.TryParse(subItemB.Text.Split('/')[0], out valueB))
                        return base.CompareSubItems(subItemA, subItemB, sortMethod, order);
                    else
                    {
                        result = CompareValues(valueA, valueB, order);
                        return result != 0 ? result : base.CompareSubItems(subItemA, subItemB, sortMethod, order);
                    }
                }
            result = CompareValues(valueA, valueB, order);
            return result != 0 ? result : base.CompareSubItems(subItemA, subItemB, sortMethod, order);
        }
    }
}
