using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace SparkReport.NET
{
    /// <summary>
    /// Class for report parameters
    /// </summary>
    public class ReportParameters : IDictionary<string, string?>
    {
        private readonly IDictionary<string, string?> _parameters = new Dictionary<string, string?>();
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? this[string key] { get => _parameters[key]; set => _parameters[key] = value; }

        /// <summary>
        /// Keys
        /// </summary>
        public ICollection<string> Keys => _parameters.Keys;

        /// <summary>
        /// Values
        /// </summary>
        public ICollection<string?> Values => _parameters.Values;

        /// <summary>
        /// Count
        /// </summary>
        public int Count => _parameters.Count;

        /// <summary>
        /// IsReadOnly
        /// </summary>
        public bool IsReadOnly => _parameters.IsReadOnly;

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string? value) => _parameters.Add(key, value);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<string, string?> item) => _parameters.Add(item.Key, item.Value);

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear() => _parameters.Clear();

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<string, string?> item) => _parameters.Contains(item);

        /// <summary>
        /// ContainsKey
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key) => _parameters.ContainsKey(key);

        /// <summary>
        /// CopyTo
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<string, string?>[] array, int arrayIndex) => _parameters.CopyTo(array, arrayIndex);

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, string?>> GetEnumerator() => _parameters.GetEnumerator();

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key) => _parameters.Remove(key);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, string?> item) => _parameters.Remove(item);

        /// <summary>
        /// TryGetValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value) => _parameters.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => _parameters.GetEnumerator();
    }
}
