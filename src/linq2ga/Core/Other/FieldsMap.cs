using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using linq2ga.Enums;

namespace linq2ga.Core
{
    /// <summary>
    /// Provides relations between the Result Object members and Context Model members in the Select clause
    /// </summary>
    internal class FieldsMap: IEnumerable<FieldsMapItem>
    {
        #region public
        public IEnumerator<FieldsMapItem> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public void Add(FieldsMapItem item)
        {
            _collection.Add(item);
        }

        public void Remove(FieldsMapItem item)
        {
            _collection.Remove(item);
        }

        public void AddRange(IEnumerable<FieldsMapItem> items)
        {
            _collection.AddRange(items);
        }

        public FieldsMapItem FindByContextModelFieldName(string googleAnalyticsFieldName)
        {
            return _collection.First(x => x.ContextModelMemberName == googleAnalyticsFieldName);
        }

        public FieldsMapItem FindByResultObjectFieldName(string selectedObjectFieldName)
        {
            return _collection.First(x => x.ResultObjectMemberName == selectedObjectFieldName);
        }
        #endregion

        #region private
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        private List<FieldsMapItem> _collection = new List<FieldsMapItem>();
        #endregion
    }
}
