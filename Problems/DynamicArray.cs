using System;

public class DynamicArray<T>
{
    private T[] array;
    private int capacity;
    private int count;

    public DynamicArray(int initialCapacity)
    {
        if (initialCapacity <= 0)
        {
            throw new ArgumentException("Initial capacity must be greater than zero.");
        }

        this.capacity = initialCapacity;
        this.array = new T[capacity];
        this.count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(int index, T item)
    {
        if (index < 0 || index > count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        
        if (count == array.Length)
        {
            ResizeArray();
        }

        
        for (int i = count; i > index; i--)
        {
            array[i] = array[i - 1];
        }

        
        array[index] = item;

        
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return array[index];
        }
    }

    private void ResizeArray()
    {
        int newCapacity = array.Length + 10; // Increase by a fixed amount
        T[] newArray = new T[newCapacity];
        Array.Copy(array, newArray, count);
        array = newArray;
    }
}
