using System.Text.Json;

namespace TestHelper.Helpers.TestDbAsync;

public class AsyncEnumerator<T> : IAsyncEnumerator<T>, IDisposable
{
    private readonly IEnumerator<T> _enumerator;
    private Utf8JsonWriter? _utf8JsonWriter = new(new MemoryStream());

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        
        Dispose(disposing: false);
        
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        
        _utf8JsonWriter?.Dispose();
        _utf8JsonWriter = null;
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_utf8JsonWriter is not null)
        {
            await _utf8JsonWriter.DisposeAsync().ConfigureAwait(false);
        }

        _utf8JsonWriter = null;
    }

    public AsyncEnumerator(IEnumerator<T> enumerator) =>
        _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));

    public T Current => _enumerator.Current;

    public ValueTask<bool> MoveNextAsync() => new(_enumerator.MoveNext());
}