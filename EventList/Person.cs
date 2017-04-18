using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventList
{
    public class Person
    {
        private AddressCollection addresses;
        public event EventHandler<AddressChangedEventArgs> AddressChanged;

        public Person()
        {
            addresses = new AddressCollection();
            addresses.AddressChanged += new EventHandler<AddressChangedEventArgs>(addresses_Changed);

        }

        public Collection<Address> Addresses
        {
            get { return addresses; }
        }

        void addresses_Changed(object sender, AddressChangedEventArgs e)
        {
            EventHandler<AddressChangedEventArgs> temp = AddressChanged;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        public void AddAddress(Address address)
        {
            addresses.Add(address);
        }
    }
}
