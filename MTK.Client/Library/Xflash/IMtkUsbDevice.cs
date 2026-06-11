using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace mtkclient.library.xflash
{
    internal interface IMtkUsbDevice : IMtkDevice, IDisposable
    {
        Task<int> SendControlMessageAsync(
            byte requestType,
            byte request,
            ushort value,
            ushort index,
            byte[] data,
            CancellationToken cancellationToken
        );

        Task ResetAsync();
    }
}
