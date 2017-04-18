using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventList
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.AddressChanged += new EventHandler<AddressChangedEventArgs>(p_AddressChanged);
            p.AddAddress(new Address { Street = "南京东路100号" });
            Console.ReadKey();
        }

        static void p_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            switch (e.ChangeType)
            {
                case ChangeType.Added:
                    Console.WriteLine("Address: Add {0}", e.ChangeItem.Street);
                    break;
                case ChangeType.Removed:
                    Console.WriteLine("Address: Removed {0}", e.ChangeItem.Street);
                    break;
                case ChangeType.Replaced:
                    Console.WriteLine("Address: Replaced {0} with {1}", e.ChangeItem, e.ReplaceWith);
                    break;
                case ChangeType.Cleared:
                    Console.WriteLine("Address: clear address ");
                    break;
                default:
                    break;
            }
        }
    }
}
