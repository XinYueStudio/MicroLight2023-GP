﻿/************************************************************************************
Copyright      :   Copyright 2017 MicroLight, LLC. All Rights reserved.
Description    :   OrderedIndexedTable.cs 
ProjectName    :   MicroLight
ProductionDate :   2017-12-04 11:51:20
Author         :   T-CODE
************************************************************************************/
using System.Collections.Generic;

namespace MicroLight.UnityPlugin.Utility
{
    public class OrderedIndexedTable<TKey, TValue> : IndexedTable<TKey, TValue>
    {
        public OrderedIndexedTable() : base() { }

        public OrderedIndexedTable(int capacity) : base(capacity) { }

        public void Insert(int index, TKey key, TValue value)
        {
            m_Dictionary.Add(key, index); // exception here if already contains key
            m_KeyList.Insert(index, key);
            m_ValueList.Insert(index, value);

            for (int i = index + 1, imax = m_Dictionary.Count; i < imax; ++i)
            {
                m_Dictionary[m_KeyList[i]] = i;
            }
        }

        public void Insert(int index, KeyValuePair<TKey, TValue> item)
        {
            Insert(index, item.Key, item.Value);
        }

        public override void RemoveAt(int index)
        {
            m_Dictionary.Remove(m_KeyList[index]);
            m_KeyList.RemoveAt(index);
            m_ValueList.RemoveAt(index);

            for (int i = index, imax = m_Dictionary.Count; i < imax; ++i)
            {
                m_Dictionary[m_KeyList[i]] = i;
            }
        }

        public TKey GetFirstKey() { return m_KeyList[0]; }

        public bool TryGetFirstKey(out TKey item)
        {
            if (m_Dictionary.Count == 0)
            {
                item = default(TKey);
                return false;
            }
            else
            {
                item = GetFirstKey();
                return true;
            }
        }

        public TKey GetLastKey() { return m_KeyList[m_KeyList.Count - 1]; }

        public bool TryGetLastKey(out TKey item)
        {
            if (m_Dictionary.Count == 0)
            {
                item = default(TKey);
                return false;
            }
            else
            {
                item = GetLastKey();
                return true;
            }
        }

        public TValue GetFirstValue() { return m_ValueList[0]; }

        public bool TryGetFirstValue(out TValue item)
        {
            if (m_Dictionary.Count == 0)
            {
                item = default(TValue);
                return false;
            }
            else
            {
                item = GetFirstValue();
                return true;
            }
        }

        public TValue GetLastValue() { return m_ValueList[m_ValueList.Count - 1]; }

        public bool TryGetLastValue(out TValue item)
        {
            if (m_Dictionary.Count == 0)
            {
                item = default(TValue);
                return false;
            }
            else
            {
                item = GetLastValue();
                return true;
            }
        }
    }
}