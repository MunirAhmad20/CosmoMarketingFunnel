using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Finder_Test
{
    public class TestSession : ISession
    {
        private readonly Dictionary<string, byte[]> _data = new Dictionary<string, byte[]>();

        public TestSession(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }

        public bool IsAvailable { get; } = true;

        public IEnumerable<string> Keys => _data.Keys;

        public void Clear()
        {
            _data.Clear();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public void Remove(string key)
        {
            _data.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            _data[key] = value;
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return _data.TryGetValue(key, out value);
        }
    }

}
