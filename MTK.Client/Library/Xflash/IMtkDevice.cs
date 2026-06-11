using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace mtkclient
{
    internal interface IMtkDevice : IDisposable
    {
        Task ConnectAsync();

        Task<int> ReadAsync(byte[] buff, int offset, int len, CancellationToken cancellationToken);

        Task WriteAsync(byte[] buff, int offset, int len, CancellationToken cancellationToken);
    }
}
