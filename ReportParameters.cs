using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SparkReport.NET
{
    /// <summary>
    /// Represents a collection of report parameters.
    /// </summary>
    public class ReportParameters : IDictionary<string, string?>
    {
        private readonly IDictionary<string, string?> _parameters = new Dictionary<string, string?>();

        /// <summary>
        /// Returns the value associated with the specified key.
        /// </summary>
        public string? this[string key] { get => _parameters[key]; set => _parameters[key] = value; }

        /// <summary>
        /// Returns a collection containing the keys.
        /// </summary>
        public ICollection<string> Keys => _parameters.Keys;

        /// <summary>
        /// Returns a collection containing the values.
        /// </summary>
        public ICollection<string?> Values => _parameters.Values;

        /// <summary>
        /// Returns the number of elements.
        /// </summary>
        public int Count => _parameters.Count;

        /// <summary>
        /// Returns a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly => _parameters.IsReadOnly;

        /// <summary>
        /// Adds an element with the provided key and value.
        /// </summary>
        public void Add(string key, string? value) => _parameters.Add(key, value);

        /// <summary>
        /// Adds an element with the provided key and value.
        /// </summary>
        public void Add(KeyValuePair<string, string?> item) => _parameters.Add(item.Key, item.Value);

        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        public void Clear() => _parameters.Clear();

        /// <summary>
        /// Returns a value indicating whether the collection contains the specified key.
        /// </summary>
        public bool Contains(KeyValuePair<string, string?> item) => _parameters.Contains(item);

        /// <summary>
        /// Returns a value indicating whether the collection contains the specified key.
        /// </summary>
        public bool ContainsKey(string key) => _parameters.ContainsKey(key);

        /// <summary>
        /// Copies the elements of the collection to an array, starting at a particular array index.
        /// </summary>
        public void CopyTo(KeyValuePair<string, string?>[] array, int arrayIndex) => _parameters.CopyTo(array, arrayIndex);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<KeyValuePair<string, string?>> GetEnumerator() => _parameters.GetEnumerator();

        /// <summary>
        /// Removes the element with the specified key from the collection.
        /// </summary>
        public bool Remove(string key) => _parameters.Remove(key);

        /// <summary>
        /// Removes the element with the specified key from the collection.
        /// </summary>
        public bool Remove(KeyValuePair<string, string?> item) => _parameters.Remove(item.Key);

        /// <summary>
        /// Tries to get the value associated with the specified key.
        /// </summary>
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string? value) => _parameters.TryGetValue(key, out value);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
