using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeShenaningans.DesignPatterns.Behavioral;

abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();

    // Returns the current element
    public abstract object Current();

    // Move forward to next element
    public abstract bool MoveNext();

    // Rewinds the Iterator to the first element
    public abstract void Reset();
}

abstract class IteratorAggregate : IEnumerable
{
    // Returns an Iterator or another IteratorAggregate for the implementing
    // object.
    public abstract IEnumerator GetEnumerator();
}

// Concrete Iterators implement various traversal algorithms. These classes
// store the current traversal position at all times.
class EventIterator : Iterator
{
    private EventCollection _collection;

    // Stores the current traversal position. An iterator may have a lot of
    // other fields for storing iteration state, especially when it is
    // supposed to work with a particular kind of collection.
    private int _position = -1;

    private bool _reverse = false;

    public EventIterator(EventCollection collection)
    {
        this._collection = collection;
    }

    public override object Current()
    {
        return this._collection.getItems()[_position];
    }

    public override bool MoveNext()
    {
        int updatedPosition = this._position + (this._reverse ? -1 : 1);

        if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
        {
            this._position = updatedPosition;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset()
    {
        this._position = 0;
    }
}

public interface IEvent
{
    public string Name { get; set; }

    public string ExecuteEvent();
}

public class EncounterEvent : IEvent
{
    public string Name { get; set; }
    public EncounterEvent(string name)
    {
        this.Name = name;
    }
    public string ExecuteEvent()
    {
        return $"Executing encounter event: {this.Name}";
    }
}


public class PlayerEvent : IEvent
{
    public string Name { get; set; }
    public PlayerEvent(string name)
    {
        this.Name = name;
    }
    public string ExecuteEvent()
    {
        return $"Executing player event: {this.Name}";
    }
}


// Concrete Collections provide one or several methods for retrieving fresh
// iterator instances, compatible with the collection class.
class EventCollection : IteratorAggregate
{
    List<IEvent> _collection = new List<IEvent>();

    public List<IEvent> getItems()
    {
        return _collection;
    }

    public void AddItem(IEvent item)
    {
        this._collection.Add(item);
    }

    public override IEnumerator GetEnumerator()
    {
        return new EventIterator(this);
    }
}