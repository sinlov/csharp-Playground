using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FastCodeZoo.Structure
{
    public class CapacityLinkedDictionary<TK, TV>
    {
        private const int DefaultCapacity = 255;
        private readonly ReaderWriterLockSlim _locker;
        private readonly IDictionary<TK, TV> _dictionary;
        private readonly LinkedList<TK> _linkedList;
        private int _capacity;

        public CapacityLinkedDictionary() : this(DefaultCapacity)
        {
        }

        public CapacityLinkedDictionary(int capacity)
        {
            _locker = new ReaderWriterLockSlim();
            _capacity = capacity > 0 ? capacity : DefaultCapacity;
            _dictionary = new Dictionary<TK, TV>();
            _linkedList = new LinkedList<TK>();
        }

        public int Count
        {
            get
            {
                _locker.EnterReadLock();
                try
                {
                    return _dictionary.Count;
                }
                finally
                {
                    _locker.ExitReadLock();
                }
            }
        }

        public int Capacity
        {
            get
            {
                _locker.EnterReadLock();
                try
                {
                    return _capacity;
                }
                finally
                {
                    _locker.ExitReadLock();
                }
            }
            set
            {
                _locker.EnterUpgradeableReadLock();
                try
                {
                    if (value > 0 && _capacity != value)
                    {
                        _locker.EnterWriteLock();
                        try
                        {
                            _capacity = value;
                            while (_linkedList.Count > _capacity)
                            {
                                _linkedList.RemoveLast();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.Error.WriteLine(e);
                            // Debug.LogError(e);
                        }
                        finally
                        {
                            _locker.ExitWriteLock();
                        }
                    }
                }
                finally
                {
                    _locker.ExitUpgradeableReadLock();
                }
            }
        }

        public ICollection<TK> LinkKeys
        {
            get
            {
                _locker.EnterReadLock();
                try
                {
                    return _linkedList.ToArray();
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    // Debug.LogError(e);
                }
                finally
                {
                    _locker.ExitReadLock();
                }

                return null;
            }
        }

        public ICollection<TK> Keys
        {
            get
            {
                _locker.EnterReadLock();
                try
                {
                    return _dictionary.Keys;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    // Debug.LogError(e);
                }
                finally
                {
                    _locker.ExitReadLock();
                }

                return null;
            }
        }

        public ICollection<TV> Values
        {
            get
            {
                _locker.EnterReadLock();
                try
                {
                    return _dictionary.Values;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    // Debug.LogError(e);
                }
                finally
                {
                    _locker.ExitReadLock();
                }

                return null;
            }
        }

        public Dictionary<TK, TV> CopyDic()
        {
            Dictionary<TK, TV> copyDic = null;
            _locker.EnterReadLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    return null;
                }

                copyDic = new Dictionary<TK, TV>(_dictionary);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                // Debug.LogError(e);
            }
            finally
            {
                _locker.ExitReadLock();
            }

            return copyDic;
        }

        public void Set(TK key, TV value)
        {
            _locker.EnterWriteLock();
            try
            {
                _dictionary[key] = value;

                if (_linkedList.Contains(key))
                {
                    return;
                }

                if (_linkedList.Count >= _capacity)
                {
                    _dictionary.Remove(_linkedList.First.Value);
                    _linkedList.RemoveFirst();
                }

                _linkedList.AddLast(key);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                // Debug.LogError(e);
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public void SetRange(IDictionary<TK, TV> items)
        {
            if (items == null || items.Count == 0)
            {
                return;
            }

            _locker.EnterWriteLock();

            try
            {
                foreach (KeyValuePair<TK, TV> keyValuePair in items)
                {
                    _dictionary[keyValuePair.Key] = keyValuePair.Value;
                    if (_linkedList.Contains(keyValuePair.Key))
                    {
                        continue;
                    }

                    if (_linkedList.Count >= _capacity)
                    {
                        _dictionary.Remove(_linkedList.First.Value);
                        _linkedList.RemoveFirst();
                    }

                    _linkedList.AddLast(keyValuePair.Key);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                // Debug.LogError(e);
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }


        public bool ContainsKey(TK key)
        {
            _locker.EnterReadLock();
            try
            {
                return _dictionary.Count != 0 && _dictionary.ContainsKey(key);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                // Debug.LogError(e);
            }
            finally
            {
                _locker.ExitReadLock();
            }

            return false;
        }

        public bool TryGet(TK key, out TV value)
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    value = default;
                    return false;
                }

                return _dictionary.TryGetValue(key, out value);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                // Debug.LogError(e);
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }

            value = default;
            return false;
        }

        public TK FirstKey()
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    return default;
                }

                return _linkedList.First.Value;
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }
        }

        public TV FirstValue()
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    return default;
                }

                TK firstKey = _linkedList.First.Value;
                if (_dictionary.TryGetValue(firstKey, out TV value))
                {
                    return value;
                }

                return default;
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }
        }

        public TK LastKey()
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    return default;
                }

                return _linkedList.Last.Value;
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }
        }

        public TV LastValue()
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    return default;
                }

                TK lastKey = _linkedList.Last.Value;
                if (_dictionary.TryGetValue(lastKey, out TV value))
                {
                    return value;
                }

                return default;
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }
        }

        public bool Remove(TK key)
        {
            if (!TryGet(key, out _))
            {
                return false;
            }

            _locker.EnterWriteLock();
            try
            {
                return _dictionary.Remove(key) && _linkedList.Remove(key);
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public void Clean()
        {
            _locker.EnterWriteLock();
            try
            {
                if (_dictionary.Count == 0)
                {
                    return;
                }

                _dictionary.Clear();
                _linkedList.Clear();
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }
    }
}