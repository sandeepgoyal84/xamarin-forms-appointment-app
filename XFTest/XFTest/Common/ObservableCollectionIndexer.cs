using System.Collections.ObjectModel;

namespace XFTest.Common
{
    public class ObservableCollectionIndexer<T>
    {
        // Declare an array to store the data elements.
        public ObservableCollection<T> collection;

        public ObservableCollectionIndexer(ObservableCollection<T> collection)
        {
            this.collection = collection;
        }

        public ObservableCollectionIndexer()
        {
            this.collection = new ObservableCollection<T>();
        }

        // Define the indexer to allow client code to use [] notation.
        public T this[int i] => collection[i];

        public void Add(T value)
        {
            collection.Add(value);
        }
    }
}