using System;
using System.Collections.Generic;
using System.Threading;

namespace FastCodeZoo.Structure
{
    public class LruCache<TKey, TValue>
    {
        private const int DefaultCapacity = 255;
        private readonly ReaderWriterLockSlim _locker;
        private readonly IDictionary<TKey, TValue> _dictionary;
        private readonly LinkedList<TKey> _linkedList;
        private int _capacity;

        public LruCache() : this(DefaultCapacity)
        {
        }

        public LruCache(int capacity)
        {
            _locker = new ReaderWriterLockSlim();
            _capacity = capacity > 0 ? capacity : DefaultCapacity;
            _dictionary = new Dictionary<TKey, TValue>();
            _linkedList = new LinkedList<TKey>();
        }

        public void Set(TKey key, TValue value)
        {
            _locker.EnterWriteLock();
            try
            {
                _dictionary[key] = value;
                _linkedList.Remove(key);
                _linkedList.AddFirst(key);
                if (_linkedList.Count > _capacity)
                {
                    _dictionary.Remove(_linkedList.Last.Value);
                    _linkedList.RemoveLast();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public void SetRange(IDictionary<TKey, TValue> items)
        {
            if (items == null || items.Count == 0)
            {
                return;
            }

            _locker.EnterWriteLock();

            try
            {
                foreach (KeyValuePair<TKey, TValue> keyValuePair in items)
                {
                    _dictionary[keyValuePair.Key] = keyValuePair.Value;
                    _linkedList.Remove(keyValuePair.Key);
                    _linkedList.AddFirst(keyValuePair.Key);
                    if (_linkedList.Count > _capacity)
                    {
                        _dictionary.Remove(_linkedList.Last.Value);
                        _linkedList.RemoveLast();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                _locker.ExitWriteLock();
            }
        }

        public bool TryGet(TKey key, out TValue value)
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                bool b = _dictionary.TryGetValue(key, out value);
                if (b)
                {
                    _locker.EnterWriteLock();
                    try
                    {
                        _linkedList.Remove(key);
                        _linkedList.AddFirst(key);
                    }
                    finally
                    {
                        _locker.ExitWriteLock();
                    }
                }

                return b;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }

            value = default;
            return false;
        }

        public TKey FirstKey()
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                return _linkedList.First.Value;
            }
            finally
            {
                _locker.ExitUpgradeableReadLock();
            }
        }

        public TValue FirstValue()
        {
            _locker.EnterUpgradeableReadLock();
            try
            {
                TKey firstKey = _linkedList.First.Value;
                if (_dictionary.TryGetValue(firstKey, out TValue value))
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

        public bool Remove(TKey key)
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

        public bool ContainsKey(TKey key)
        {
            _locker.EnterReadLock();
            try
            {
                return _dictionary.ContainsKey(key);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                _locker.ExitReadLock();
            }

            return false;
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

        public ICollection<TKey> Keys
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
                }
                finally
                {
                    _locker.ExitReadLock();
                }

                return null;
            }
        }

        public ICollection<TValue> Values
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
                }
                finally
                {
                    _locker.ExitReadLock();
                }

                return null;
            }
        }

        public Dictionary<TKey, TValue> CopyDic()
        {
            Dictionary<TKey, TValue> copyDic = null;
            _locker.EnterReadLock();
            try
            {
                copyDic = new Dictionary<TKey, TValue>(_dictionary);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                _locker.ExitReadLock();
            }

            return copyDic;
        }
    }
}