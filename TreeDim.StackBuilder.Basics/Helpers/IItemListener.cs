using System;

namespace treeDiM.StackBuilder.Basics
{
    public interface IItemListener
    {
        void Update(ItemBase itemFrom);
        void Kill(ItemBase itemFrom);
    }
}
