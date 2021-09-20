using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageNuGetPackage.Receiver
{
    public interface IStorageReceiver<T>
    {
        Task<IEnumerable<T>> GetAllPersons();
    }
}
