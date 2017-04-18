using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventList
{
    public class AddressCollection : Collection<Address>
    {
        public event EventHandler<AddressChangedEventArgs> AddressChanged;

        protected override void InsertItem(int index, Address item)
        {
            base.InsertItem(index, item);

            EventHandler<AddressChangedEventArgs> temp = AddressChanged;
            if (temp != null)
            {
                temp(this, new AddressChangedEventArgs(ChangeType.Added, item, null));
            }
        }

        protected override void SetItem(int index, Address item)
        {
            Address replaced = Items[index];
            base.SetItem(index, item);

            EventHandler<AddressChangedEventArgs> temp = AddressChanged;
            if (temp != null)
            {
                temp(this, new AddressChangedEventArgs(ChangeType.Replaced, replaced, item));
            }
        }

        protected override void RemoveItem(int index)
        {
            Address removedItem = Items[index];
            base.RemoveItem(index);

            EventHandler<AddressChangedEventArgs> temp = AddressChanged;
            if (temp != null)
            {
                temp(this, new AddressChangedEventArgs(ChangeType.Removed, removedItem, null));
            }
        }

        protected override void ClearItems()
        {
            base.ClearItems();

            EventHandler<AddressChangedEventArgs> temp = AddressChanged;
            if (temp != null)
            {
                temp(this, new AddressChangedEventArgs(ChangeType.Cleared, null, null));
            }
        }

    }
    public class AddressChangedEventArgs : EventArgs
    {
        public readonly Address ChangeItem;
        public readonly ChangeType ChangeType;
        public readonly Address ReplaceWith;

        public AddressChangedEventArgs(ChangeType changeType, Address item, Address replacement)
        {
            ChangeType = changeType;
            ChangeItem = item;
            ReplaceWith = replacement;
        }
    }

    public enum ChangeType
    {
        Added,
        Removed,
        Replaced,
        Cleared
    };
}
