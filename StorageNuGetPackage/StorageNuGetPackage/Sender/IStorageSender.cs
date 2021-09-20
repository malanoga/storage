using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageNuGetPackage.Sender
{
    public interface IStorageSender
    {
        Task<string> SaveRecord(Person p);
    }
}
