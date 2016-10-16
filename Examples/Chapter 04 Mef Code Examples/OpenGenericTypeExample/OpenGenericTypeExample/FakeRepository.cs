using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace OpenGenericTypeExample
{
    [Export(typeof(IRepository<>))]
    public class FakeRepository<T> : IRepository<T> where T : class, IData<T>
    {
        IList<T> items;

        public int Count { get { return items.Count; } }

        public T FindById(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);    
        }

        public void Save(T item)
        {
            var existingItem = FindById(item.Id);
            if (existingItem == null)
            {
                items.Add(item);
            }
            else
            {
                existingItem.Update(item);
            }

		}

		/// <summary>
		/// Initializes a new instance of the FakeRepository class.
		/// </summary>
		public FakeRepository()
		{
			items = new List<T>();
		}
		[ImportingConstructor]
		public FakeRepository(IList<T> preLoadedItems)
		{
			if (preLoadedItems != null)
			{
				items = preLoadedItems;
			}
			else
			{
				items = new List<T>();
			}
		}
    }
}
