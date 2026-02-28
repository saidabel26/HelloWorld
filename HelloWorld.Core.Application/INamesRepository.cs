using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.Core.Application.Repositories
{
    public interface INamesRepository
    {
        Task InitializeAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetNamesAsync(CancellationToken cancellationToken = default);
        Task AddNameAsync(string name, CancellationToken cancellationToken = default);
    }
}