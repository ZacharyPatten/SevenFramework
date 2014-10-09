// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seven.Structures
{
  public interface Graph<T> : Structure<T>
  {
    bool Adjacent(T a, T b);

    void Neighbors(T a, Foreach<T> function);

    void Add(T start, T end);

    void Remove(T start, T end);

    void Add(T node);

    void Remove(T node);
  }

  public class Graph_Quadtree<T> : Graph<T>
  {
    #region class

    public class Set_Hash<T>
    {
      #region class

      private class Node
      {
        private T _key;
        private Node _next;

        internal T Key { get { return _key; } set { _key = value; } }
        internal Node Next { get { return _next; } set { _next = value; } }

        internal Node(T key, Node next)
        {
          _key = key;
          _next = next;
        }
      }

      #endregion

      #region field

      /// <summary>A set of allowable table sizes, all of which are prime.</summary>
      private static readonly int[] _tableSizes = new int[]
            {
                1, 2, 5, 11, 23, 47, 97, 197, 397, 797, 1597, 3203, 6421, 12853, 25717, 51437,
                102877, 205759, 411527, 823117, 1646237, 3292489, 6584983, 13169977, 26339969,
                52679969, 105359939, 210719881, 421439783, 842879579, 1685759167
            };

      private const double _maxLoadFactor = 1.0d;

      private Equate<T> _equate;
      private Hash<T> _hash;
      private Node[] _table;
      private int _count;
      private int _sizeIndex;

      #endregion

      #region property

      /// <summary>The function for calculating hash codes for this table.</summary>
      public Hash<T> Hash { get { return _hash; } }

      /// <summary>The function for equating keys in this table.</summary>
      public Equate<T> Equate { get { return _equate; } }

      /// <summary>Returns the current number of items in the structure.</summary>
      /// <remarks>Runetime: O(1).</remarks>
      public int Count { get { return _count; } }

      /// <summary>Returns true if the structure is empty.</summary>
      /// <remarks>Runetime: O(1).</remarks>
      public bool IsEmpty { get { return _count == 0; } }

      /// <summary>Returns the current size of the actual table. You will want this if you 
      /// wish to multithread structure traversals.</summary>
      /// <remarks>Runtime: O(1).</remarks>
      public int TableSize { get { return _table.Length; } }

      #endregion

      #region construct

      /// <summary>Constructs a new hash table instance.</summary>
      /// <remarks>Runtime: O(1).</remarks>
      public Set_Hash(Equate<T> equate, Hash<T> hash)
      {
        this._equate = equate;
        this._hash = hash;
        _table = new Node[_tableSizes[0]];
        _count = 0;
        _sizeIndex = 0;
      }

      #endregion

      #region method

      public bool Contains(T key)
      {
        Node cell = Find(key, ComputeHash(key));
        if (cell == null)
          return false;
        else
          return true;
      }

      private Node Find(T key, int loc)
      {
        for (Node bucket = _table[loc]; bucket != null; bucket = bucket.Next)
          if (_equate(bucket.Key, key))
            return bucket;
        return null;
      }

      private int ComputeHash(T key) { return (_hash(key) & 0x7fffffff) % _table.Length; }

      /// <summary>Adds a value to the hash table.</summary>
      /// <param name="key">The key value to use as the look-up reference in the hash table.</param>
      /// <param name="value">The value to store in the hash table.</param>
      /// <remarks>Runtime: O(n), Omega(1).</remarks>
      public void Add(T key)
      {
        if (key == null)
          throw new Error("attempting to add a null key to the structure.");
        int location = ComputeHash(key);
        if (Find(key, location) == null)
        {
          if (++_count > _table.Length * _maxLoadFactor)
          {
            if (_sizeIndex + 1 == _tableSizes.Length)
              throw new Error("maximum size " + _tableSizes[_tableSizes.Length - 1] + " of hash table reached.");

            Node[] t = _table;
            _table = new Node[_tableSizes[++_sizeIndex]];
            for (int i = 0; i < t.Length; i++)
            {
              while (t[i] != null)
              {
                Node cell = RemoveFirst(t, i);
                Add(cell, ComputeHash(cell.Key));
              }
            }
            location = ComputeHash(key);
          }
          Node p = new Node(key, null);
          Add(p, location);
        }
        else
          throw new Error("\nMember: \"Add(TKey key, TValue value)\"\nThe key is already in the table.");
      }

      private Node RemoveFirst(Node[] t, int i)
      {
        Node first = t[i];
        t[i] = first.Next;
        return first;
      }

      private void Add(Node cell, int location)
      {
        cell.Next = _table[location];
        _table[location] = cell;
      }

      /// <summary>Removes a value from the hash table.</summary>
      /// <param name="key">The key of the value to remove.</param>
      /// <remarks>Runtime: N/A. (I'm still editing this structure)</remarks>
      public void Remove(T key)
      {
        if (key == null)
          throw new Error("attempting to remove \"null\" from the structure.");
        int location = ComputeHash(key);
        if (_table[location].Key.Equals(key))
          _table[location] = _table[location].Next;
        for (Node bucket = _table[location]; bucket != null; bucket = bucket.Next)
        {
          if (bucket.Next == null)
            throw new Error("attempting to remove a non-existing value.");
          else if (bucket.Next.Key.Equals(key))
            bucket.Next = bucket.Next.Next;
        }
        _count--;
      }

      public void Clear()
      {
        _table = new Node[107];
        _count = 0;
        _sizeIndex = 0;
      }

      public T[] ToArray()
      {
        T[] array = new T[_count];
        int index = 0;
        Node node;
        for (int i = 0; i < _table.Length; i++)
          if ((node = _table[i]) != null)
            do
            {
              array[index++] = node.Key;
            } while ((node = node.Next) != null);
        return array;
      }

      //System.Collections.IEnumerator
      //  System.Collections.IEnumerable.GetEnumerator()
      //{
      //  Node node;
      //  for (int i = 0; i < _table.Length; i++)
      //    if ((node = _table[i]) != null)
      //      do
      //      {
      //        yield return node.Key;
      //      } while ((node = node.Next) != null);
      //}

      //System.Collections.Generic.IEnumerator<T>
      //  System.Collections.Generic.IEnumerable<T>.GetEnumerator()
      //{
      //  Node node;
      //  for (int i = 0; i < _table.Length; i++)
      //    if ((node = _table[i]) != null)
      //      do
      //      {
      //        yield return node.Key;
      //      } while ((node = node.Next) != null);
      //}

      /// <summary>Gets the current memory imprint of this structure in bytes.</summary>
      /// <remarks>Returns long.MaxValue on overflow.</remarks>
      public int SizeOf { get { return _count + _table.Length; } }

      /// <summary>Invokes a delegate for each entry in the data structure.</summary>
      /// <param name="function">The delegate to invoke on each item in the structure.</param>
      public void Foreach(Foreach<T> function)
      {
        Node node;
        for (int i = 0; i < _table.Length; i++)
          if ((node = _table[i]) != null)
            do
            {
              function(node.Key);
            } while ((node = node.Next) != null);
      }

      /// <summary>Invokes a delegate for each entry in the data structure.</summary>
      /// <param name="function">The delegate to invoke on each item in the structure.</param>
      public void Foreach(ForeachRef<T> function)
      {
        Node node;
        for (int i = 0; i < _table.Length; i++)
          if ((node = _table[i]) != null)
            do
            {
              T temp = node.Key;
              function(ref temp);
              node.Key = temp;
            } while ((node = node.Next) != null);
      }

      /// <summary>Invokes a delegate for each entry in the data structure.</summary>
      /// <param name="function">The delegate to invoke on each item in the structure.</param>
      /// <returns>The resulting status of the iteration.</returns>
      public ForeachStatus Foreach(ForeachBreak<T> function)
      {
        Node node;
        for (int i = 0; i < _table.Length; i++)
          if ((node = _table[i]) != null)
            do
            {
              if (function(node.Key) == ForeachStatus.Break)
                return ForeachStatus.Break;
            } while ((node = node.Next) != null);
        return ForeachStatus.Continue;
      }

      /// <summary>Invokes a delegate for each entry in the data structure.</summary>
      /// <param name="function">The delegate to invoke on each item in the structure.</param>
      /// <returns>The resulting status of the iteration.</returns>
      public ForeachStatus Foreach(ForeachRefBreak<T> function)
      {
        Node node;
        for (int i = 0; i < _table.Length; i++)
          if ((node = _table[i]) != null)
            do
            {
              T temp = node.Key;
              ForeachStatus status = function(ref temp);
              node.Key = temp;
              if (status == ForeachStatus.Break)
                return ForeachStatus.Break;
            } while ((node = node.Next) != null);
        return ForeachStatus.Continue;
      }

      /// <summary>Creates a shallow clone of this data structure.</summary>
      /// <returns>A shallow clone of this data structure.</returns>
      public Set_Hash<T> Clone()
      {
        throw new System.NotImplementedException();
      }

      #endregion
    }

    public class Quadtree_Linked<T, M>
    {
      #region class

      /// <summary>Can be a leaf or a branch.</summary>
      private abstract class Node
      {
        private M[] _min;
        private M[] _max;
        private Branch _parent;
        private int _index;
        private int _count;

        internal M[] Min { get { return this._min; } }
        internal M[] Max { get { return this._max; } }
        internal Branch Parent { get { return this._parent; } }
        internal int Index { get { return this._index; } }
        internal int Count { get { return this._count; } set { this._count = value; } }

        internal Node(M[] min, M[] max, Branch parent, int index)
        {
          this._min = min;
          this._max = max;
          this._parent = parent;
          this._index = index;
        }
      }

      /// <summary>A branch in the tree. Only contains items.</summary>
      private class Leaf : Node
      {
        internal class Node
        {
          internal T _value;
          internal Node _next;

          public T Value { get { return _value; } set { _value = value; } }
          public Node Next { get { return _next; } set { _next = value; } }

          public Node(T value, Node next)
          {
            _value = value;
            _next = next;
          }
        }

        private Node _head;
        private int _count;

        public Node Head { get { return this._head; } set { this._head = value; } }
        public int Count { get { return this._count; } set { this._count = value; } }

        public Leaf(M[] min, M[] max, Branch parent, int index)
          : base(min, max, parent, index) { }
      }

      /// <summary>A branch in the tree. Only contains nodes.</summary>
      private class Branch : Node
      {
        internal class Node
        {
          private Quadtree_Linked<T, M>.Node _value;
          private Branch.Node _next;

          public Quadtree_Linked<T, M>.Node Value { get { return this._value; } }
          public Branch.Node Next { get { return this._next; } set { this._next = value; } }

          public Node(Quadtree_Linked<T, M>.Node value, Branch.Node next)
          {
            this._value = value;
            this._next = next;
          }
        }

        private Branch.Node _head;

        public Branch.Node Head { get { return this._head; } set { this._head = value; } }

        public Branch(M[] min, M[] max, Branch parent, int index)
          : base(min, max, parent, index) { }
      }

      #endregion

      #region field

      private const int _defaultLoad = 2;

      private Quadtree.Locate<T, M> _locate;
      private Quadtree.Average<M> _average;
      private Compare<M> _compare;
      private int _dimensions;
      private int _children;
      private M[] _origin;

      private Node _top;
      private int _count;
      /// <summary>count ^ (1 / dimensions)</summary>
      private int _load;
      /// <summary>load ^ dimensions</summary>
      private int _loadPowered;
      /// <summary>(load + 1) ^ dimensions</summary>
      private int _loadPlusOnePowered;
      /// <summary>leaf depth of previous addition (sequencial addition optimization)</summary>
      private Node _previousAddition;
      /// <summary>tree depth of previous addition (sequencial addition optimization)</summary>
      private int _previousAdditionDepth;

      /// <summary>Event for handling items that go outside the bounds of the Quadtree.</summary>
      public event Foreach<T> HandleOutOfBounds;

      #endregion

      #region Property

      /// <summary>Gets the dimensions of the center point of the Quadtree.</summary>
      public M[] Origin { get { return (M[])this._origin.Clone(); } }

      /// <summary>The minimum dimensions of the Quadtree.</summary>
      public M[] Min { get { return (M[])this._top.Min.Clone(); } }

      /// <summary>The maximum dimensions of the Quadtree.</summary>
      public M[] Max { get { return (M[])this._top.Max.Clone(); } }

      /// <summary>The number of dimensions in this tree.</summary>
      public int Dimensions { get { return this._dimensions; } }

      /// <summary>The current number of items in the tree.</summary>
      public int Count { get { return this._count; } }

      /// <summary>True if (Count == 0).</summary>
      public bool IsEmpty { get { return this._count == 0; } }

      /// <summary>Gets the current memory allocation size of this structure.</summary>
      public int SizeOf { get { throw new System.NotImplementedException("Sorry, I'm working on it."); } }

      /// <summary>The compare function the Quadtree is using.</summary>
      public Compare<M> Compare { get { return this._compare; } }

      /// <summary>The location function the Quadtree is using.</summary>
      public Quadtree.Locate<T, M> Locate { get { return this._locate; } }

      /// <summary>The average function the Quadtree is using.</summary>
      public Quadtree.Average<M> Average { get { return this._average; } }

      #endregion

      #region construct

      /// <summary>Constructor for an Quadtree_Linked.</summary>
      /// <param name="min">The minimum values of the tree.</param>
      /// <param name="max">The maximum values of the tree.</param>
      /// <param name="locate">A function for locating an item along the provided dimensions.</param>
      /// <param name="compare">A function for comparing two items of the types of the axis.</param>
      /// <param name="average">A function for computing the average between two items of the axis types.</param>
      public Quadtree_Linked(
        M min_x, M min_y,
        M max_x, M max_y,
        Quadtree.Locate<T, M> locate,
        Compare<M> compare,
        Quadtree.Average<M> average)
      {
        M[] min = new M[2] { min_x, min_y, };
        M[] max = new M[2] { max_x, max_y, };

        #region error
#if no_error_checking
                // nothing
#else
        // check the locate and compare delegates
        if (locate == null)
          throw new Error("null reference on location delegate during Quadtree construction");
        if (compare == null)
          throw new Error("null reference on compare delegate during Quadtree construction");

        // Check the min/max values
        if (min == null)
          throw new Error("null reference on min dimensions during Quadtree construction");
        if (max == null)
          throw new Error("null reference on max dimensions during Quadtree construction");
        if (min.Length != max.Length)
          throw new Error("min/max values for omnitree mismatch dimensions");
        for (int i = 0; i < min.Length; i++)
          if (compare(min[i], max[i]) != Comparison.Less)
            throw new Error("invalid min/max values. not all min values are less than the max values");

        // Check the average delegate
        if (average == null)
          throw new Error("null reference on average delegate during Quadtree construction");
        M[] origin2 = new M[min.Length];
        for (int i = 0; i < min.Length; i++)
          origin2[i] = average(min[i], max[i]);
        for (int i = 0; i < min.Length; i++)
          if (compare(min[i], origin2[i]) != Comparison.Less || compare(origin2[i], max[i]) != Comparison.Less)
            throw new Error("invalid average function. not all average values were computed to be between the min/max values.");
#endif
        #endregion

        M[] origin = new M[min.Length];
        for (int i = 0; i < min.Length; i++)
          origin[i] = average(min[i], max[i]);

        this._locate = locate;
        this._average = average;
        this._compare = compare;
        this._dimensions = min.Length;
        this._children = 1 << this._dimensions;

        this._count = 0;
        this._top = new Leaf(min, max, null, -1);

        this._load = _defaultLoad;
        this._loadPlusOnePowered =
          Quadtree_Linked<T, M>.Int_Power(this._load + 1, this._dimensions);
        this._loadPowered =
          Quadtree_Linked<T, M>.Int_Power(_load, _dimensions);

        this._origin = origin;

        this._previousAddition = this._top;
        this._previousAdditionDepth = 0;
      }

      #endregion

      #region method

      /// <summary>Adds an item to the tree.</summary>
      /// <param name="addition">The item to be added.</param>
      public void Add(T addition)
      {
        #region error
#if no_error_checking
                // nothing
#else
        if (this._count == int.MaxValue)
          throw new Error("(Count == int.MaxValue) max Quadtree size reached (change ints to longs if you need to).");
#endif
        #endregion

        // dynamic tree sizes
        if (this._loadPlusOnePowered < this._count)
        {
          this._load++;
          this._loadPlusOnePowered =
            Quadtree_Linked<T, M>.Int_Power(this._load + 1, this._dimensions);
          this._loadPowered =
            Quadtree_Linked<T, M>.Int_Power(this._load, this._dimensions);
        }

        M x, y;
        this._locate(addition, out x, out y);
        M[] ms = new M[2] { x, y };

        #region error
#if no_error_checking
                // this check is still required
                if (!EncapsulationCheck(this._top.Min, this._top.Max, ms))
                    this.HandleOutOfBounds(addition);
#else
        if (!EncapsulationCheck(this._top.Min, this._top.Max, ms))
          if (HandleOutOfBounds == null)
            throw new Error("a node was updated to be out of bounds (found in an addition)");
          else
            this.HandleOutOfBounds(addition);
#endif
        #endregion

        if (this._top is Leaf && (this._top as Leaf).Count >= this._load)
        {
          Leaf leaf = this._top as Leaf;
          this._top = new Branch(this._top.Min, this._top.Max, null, -1);

          for (Leaf.Node list = leaf.Head; list != null; list = list.Next)
          {
            M x_2, y_2_2;
            this._locate(list.Value, out x_2, out y_2_2);
            M[] child_ms = new M[2] { x_2, y_2_2 };

            if (!EncapsulationCheck(this._top.Min, this._top.Max, child_ms))
            {
              this._count--;

              #region error
#if no_error_checking
                            this.HandleOutOfBounds(list.Value);
#else
              if (HandleOutOfBounds == null)
                throw new Error("a node was updated to be out of bounds (found in an addition)");
              else
                this.HandleOutOfBounds(list.Value);
#endif
              #endregion
            }
            else
              Add(list.Value, this._top, child_ms, 0);
          }

          this._previousAddition = this._top;
          this._previousAdditionDepth = 0;
        }

        if (this.EncapsulationCheck(this._previousAddition.Min, this._previousAddition.Max, ms))
          this.Add(addition, this._previousAddition, ms, this._previousAdditionDepth);
        else
          this.Add(addition, _top, ms, 0);
        this._count++;
      }

      /// <summary>Recursive version of the add function.</summary>
      /// <param name="addition">The item to be added.</param>
      /// <param name="node">The current location of the tree.</param>
      /// <param name="ms">The location of the addition.</param>
      /// <param name="depth">The current depth of iteration.</param>
      private void Add(T addition, Node node, M[] ms, int depth)
      {
        if (node is Leaf)
        {
          Leaf leaf = node as Leaf;
          if (depth >= this._load || !(leaf.Count >= this._load))
          {
            Quadtree_Linked<T, M>.Leaf_Add(leaf, addition);

            this._previousAddition = leaf;
            this._previousAdditionDepth = depth;

            return;
          }
          else
          {
            Branch parent = node.Parent;
            Branch growth = GrowBranch(parent, leaf.Min, leaf.Max, this.DetermineChild(parent, ms));

            for (Leaf.Node list = leaf.Head; list != null; list = list.Next)
            {
              M x, y;
              this._locate(list.Value, out x, out y);
              M[] child_ms = new M[2] { x, y };

              #region error
#if no_error_checking
                            // nothing
#else
              if (child_ms == null || child_ms.Length != this._dimensions)
                throw new Error("the location function for omnitree is invalid.");
#endif
              #endregion

              if (EncapsulationCheck(growth.Min, growth.Max, child_ms))
                Add(list.Value, growth, child_ms, depth);
              else
              {
                if (EncapsulationCheck(this._top.Min, this._top.Max, child_ms))
                {
                  this._count--;

                  #region error
#if no_error_checking
                                    this.HandleOutOfBounds(list.Value);
#else
                  if (HandleOutOfBounds == null)
                    throw new Error("a node was updated to be out of bounds (found in an addition)");
                  else
                    this.HandleOutOfBounds(list.Value);

#endif
                  #endregion
                }
                else
                  Add(list.Value, this._top, child_ms, depth);
              }
            }

            Add(addition, growth, ms, depth);
            return;
          }
        }
        else
        {
          Branch branch = node as Branch;
          int child = this.DetermineChild(branch, ms);
          Node child_node = this.Branch_GetChild(branch, child);

          // null children in branches are just empty leaves
          if (child_node == null)
          {
            Leaf leaf = GrowLeaf(branch, child);
            Quadtree_Linked<T, M>.Leaf_Add(leaf, addition);

            this._previousAddition = leaf;
            this._previousAdditionDepth = depth + 1;

            return;
          }

          Add(addition, child_node, ms, depth + 1);
          branch.Count++;
          return;
        }
        node.Count++;
      }

      /// <summary>Adds an item to a leaf.</summary>
      /// <param name="leaf">The leaf to add to.</param>
      /// <param name="addition">The item to add to the leaf.</param>
      private static void Leaf_Add(Leaf leaf, T addition)
      {
        leaf.Head = new Leaf.Node(addition, leaf.Head);
        leaf.Count++;
      }

      /// <summary>Gets a child at of a given index in a branch.</summary>
      /// <param name="branch">The branch to get the child of.</param>
      /// <param name="index">The index of the child to get.</param>
      /// <returns>The value of the child.</returns>
      private Node Branch_GetChild(Branch branch, int index)
      {
        Branch.Node child = branch.Head;
        while (child != null && child.Value.Index != index)
          child = child.Next;
        if (child == null)
          return null;
        else
          return child.Value;
      }

      /// <summary>Sets a child at of a given index in a branch.</summary>
      /// <param name="branch">The branch to set the child of.</param>
      /// <param name="index">The index of the child to set.</param>
      /// <param name="value">The value to be set.</param>
      private Node Branch_SetChild(Branch branch, int index, Node value)
      {
        // leaves are completely new nodes (as oposed to branches replacing leaves)
        if (value is Leaf)
          branch.Head = new Branch.Node(value, branch.Head);
        else
        {
          if (branch.Head.Value.Index == index)
            branch.Head = new Branch.Node(value, branch.Head.Next);
          else
          {
            Branch.Node list = branch.Head;
            while (list.Next.Value.Index != index)
              list = list.Next;
            list.Next = new Branch.Node(value, list.Next.Next);
          }
        }
        return value;
      }

      /// <summary>Takes an integer to the power of the exponent.</summary>
      /// <param name="_base">The base operand of the power function.</param>
      /// <param name="exponent">The exponent operand of the power operand.</param>
      /// <returns>The computed (bease ^ exponent) value.</returns>
      private static int Int_Power(int _base, int exponent)
      {
        int result = 1;
        while (exponent > 0)
        {
          if ((exponent & 1) > 0)
            result *= _base;
          exponent >>= 1;
          _base *= _base;
        }
        return result;
      }

      /// <summary>Removes all the items qualified by the delegate.</summary>
      /// <param name="where">The predicate to qualify removals.</param>
      public void Remove(Predicate<T> where)
      {
        this._count -= this.Remove(this._top, where);

        // dynamic tree sizes
        while (this._loadPowered > this._count && this._load > _defaultLoad)
        {
          this._load--;
          this._loadPlusOnePowered =
            Quadtree_Linked<T, M>.Int_Power(_load + 1, _dimensions);
          this._loadPowered =
            Quadtree_Linked<T, M>.Int_Power(_load, _dimensions);
        }

        this._previousAddition = this._top;
        this._previousAdditionDepth = 0;
      }

      /// <summary>Recursive version of the remove method.</summary>
      /// <param name="node">The current node of traversal.</param>
      /// <param name="where">The predicate to qualify removals.</param>
      private int Remove(Node node, Predicate<T> where)
      {
        int removals = 0;
        if (node is Leaf)
        {
          Leaf leaf = node as Leaf;
          while (leaf.Head != null && where(leaf.Head.Value))
          {
            leaf.Head = leaf.Head.Next;
            removals++;
          }
          if (leaf.Head != null)
          {
            Leaf.Node list = leaf.Head;
            while (list.Next != null)
            {
              if (where(list.Next.Value))
              {
                list.Next = list.Next.Next;
                removals++;
              }
            }
          }

          leaf.Count -= removals;
          return removals;
        }
        else
        {
          Branch branch = node as Branch;
          Branch.Node list = branch.Head;

          while (list != null)
          {
            removals += this.Remove(list.Value, where);
            if (list.Value.Count == 0)
              ChopChild(branch, list.Value.Index);
            list = list.Next;
          }

          branch.Count -= removals;

          if (branch.Count < this._load && branch.Count != 0)
            ShrinkChild(branch.Parent, branch.Index);

          return removals;
        }
      }

      /// <summary>Removes all the items in a given space.</summary>
      /// <param name="min">The minimum values of the space.</param>
      /// <param name="max">The maximum values of the space.</param>
      /// <returns>The number of items that were removed.</returns>
      public void Remove(M[] min, M[] max)
      {
        this._count -= this.Remove(this._top, min, max);

        // dynamic tree sizes
        while (this._loadPowered > this._count && this._load > _defaultLoad)
        {
          this._load--;
          this._loadPlusOnePowered =
            Quadtree_Linked<T, M>.Int_Power(_load + 1, _dimensions);
          this._loadPowered =
            Quadtree_Linked<T, M>.Int_Power(_load, _dimensions);
        }

        this._previousAddition = this._top;
        this._previousAdditionDepth = 0;
      }

      /// <summary>Recursive version of the remove method.</summary>
      /// <param name="node">The current node of traversal.</param>
      /// <param name="min">The min dimensions of the removal space.</param>
      /// <param name="max">The max dimensions of the removal space.</param>
      private int Remove(Node node, M[] min, M[] max)
      {
        int removals = 0;
        if (node is Leaf)
        {
          Leaf leaf = node as Leaf;
          while (leaf.Head != null)
          {
            M x, y;
            this._locate(leaf.Head.Value, out x, out y);
            M[] ms = new M[2] { x, y };

            if (EncapsulationCheck(min, max, ms))
            {
              leaf.Head = leaf.Head.Next;
              removals++;
            }
          }
          if (leaf.Head != null)
          {
            Leaf.Node list = leaf.Head;
            while (list.Next != null)
            {
              M x, y;
              this._locate(list.Next.Value, out x, out y);
              M[] ms = new M[2] { x, y };

              if (EncapsulationCheck(min, max, ms))
              {
                list.Next = list.Next.Next;
                removals++;
              }
            }
          }

          leaf.Count -= removals;
          return removals;
        }
        else
        {
          Branch branch = node as Branch;
          while (branch.Head != null && EncapsulationCheck(min, max, branch.Head.Value.Min, branch.Head.Value.Max))
          {
            removals += branch.Head.Value.Count;
            branch.Head = branch.Head.Next;
          }
          if (branch.Head != null)
          {
            Branch.Node list = branch.Head;
            while (list.Next != null)
            {
              if (EncapsulationCheck(min, max, list.Next.Value.Min, list.Next.Value.Max))
              {
                removals += list.Next.Value.Count;
                list.Next = list.Next.Next;
              }
              else
              {
                removals += Remove(list.Next.Value, min, max);
                if (list.Next.Value.Count == 0)
                  ChopChild(branch, list.Next.Value.Index);
              }
            }
          }

          branch.Count -= removals;

          if (branch.Count < this._load && branch.Count != 0)
            ShrinkChild(branch.Parent, branch.Index);

          return removals;
        }
      }

      /// <summary>Converts a branch back into a leaf when the count is reduced.</summary>
      /// <param name="parent">The parent to shrink a child of.</param>
      /// <param name="child">The index of the child to shrink.</param>
      private void ShrinkChild(Branch parent, int child)
      {
        if (parent == null)
        {
          Node oldChild = this._top;
          this._top = new Leaf(oldChild.Min, oldChild.Max, parent, oldChild.Index);
          this.Foreach((T i) => { this.Add(i); }, oldChild);
        }
        else
        {
          Branch.Node list = parent.Head;
          if (list.Value.Index == child)
            parent.Head = parent.Head.Next;
          else
          {
            while (list != null)
            {
              if (list.Next.Value.Index == child)
              {
                Branch.Node shrinking = list.Next;
                list.Next = new Branch.Node(new Leaf(shrinking.Value.Min, shrinking.Value.Max, parent, shrinking.Value.Index), list.Next.Next);
                this.Foreach((T j) => { this.Add(j); }, shrinking.Value);
                break;
              }
              list = list.Next;
            }
          }
        }
      }

      /// <summary>Removes all the items in a given space validated by a predicate.</summary>
      /// <param name="min">The minimum values of the space.</param>
      /// <param name="max">The maximum values of the space.</param>
      /// <param name="where">The equality constraint of the removal.</param>
      public void Remove(M[] min, M[] max, Predicate<T> where)
      {
        this._count -= this.Remove(this._top, min, max, where);

        // dynamic tree sizes
        while (this._loadPowered > this._count && this._load > _defaultLoad)
        {
          this._load--;
          this._loadPlusOnePowered =
            Quadtree_Linked<T, M>.Int_Power(_load + 1, _dimensions);
          this._loadPowered =
            Quadtree_Linked<T, M>.Int_Power(_load, _dimensions);
        }

        this._previousAddition = this._top;
        this._previousAdditionDepth = 0;
      }

      /// <summary>Recursive version of the remove method.</summary>
      /// <param name="node">The current node of traversal.</param>
      /// <param name="min">The min dimensions of the removal space.</param>
      /// <param name="max">The max dimensions of the removal space.</param>
      /// <param name="where">The equality constraint of the removal.</param>
      private int Remove(Node node, M[] min, M[] max, Predicate<T> where)
      {
        int removals = 0;
        if (node is Leaf)
        {
          Leaf leaf = node as Leaf;
          while (leaf.Head != null)
          {
            M x, y;
            this._locate(leaf.Head.Value, out x, out y);
            M[] ms = new M[2] { x, y }; ;

            if (this.EncapsulationCheck(min, max, ms) && where(leaf.Head.Value))
            {
              leaf.Head = leaf.Head.Next;
              removals++;
            }
            else
              break;
          }
          if (leaf != null)
          {
            Leaf.Node list = (node as Leaf).Head;
            while (list.Next != null)
            {
              M x, y;
              this._locate(list.Next.Value, out x, out y);
              M[] ms = new M[2] { x, y };

              if (this.EncapsulationCheck(min, max, ms) && where(list.Next.Value))
              {
                list.Next = list.Next.Next;
                removals++;
              }
            }
          }

          leaf.Count -= removals;
          this._count -= removals;

          return removals;
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            this.Remove(list.Value, min, max, where);
            if (list.Value.Count == 0)
              this.ChopChild(list.Value.Parent, list.Value.Index);
          }

          node.Count -= removals;

          if (node.Count < this._load && node.Count != 0)
            ShrinkChild(node.Parent, node.Index);

          return removals;
        }
      }

      /// <summary>Grows a branch on the tree at the desired location</summary>
      /// <param name="branch">The branch to grow a branch on.</param>
      /// <param name="min">The minimum dimensions of the new branch.</param>
      /// <param name="max">The maximum dimensions of the new branch.</param>
      /// <param name="child">The child index to grow the branch on.</param>
      /// <returns>The newly constructed branch.</returns>
      private Branch GrowBranch(Branch branch, M[] min, M[] max, int child)
      {
        return this.Branch_SetChild(branch, child,
          new Branch(min, max, branch, child)) as Branch;
      }

      /// <summary>Grows a leaf on the tree at the desired location.</summary>
      /// <param name="branch">The branch to grow a leaf on.</param>
      /// <param name="child">The index to grow a leaf on.</param>
      /// <returns>The constructed leaf.</returns>
      private Leaf GrowLeaf(Branch branch, int child)
      {
        M[] min, max;
        this.DetermineChildBounds(branch, child, out min, out max);
        return this.Branch_SetChild(branch, child,
          new Leaf(min, max, branch, child)) as Leaf;
      }

      /// <summary>Computes the child index that contains the desired dimensions.</summary>
      /// <param name="node">The node to compute the child index of.</param>
      /// <param name="ms">The coordinates to find the child index of.</param>
      /// <returns>The computed child index based on the coordinates relative to the center of the node.</returns>
      private int DetermineChild(Node node, M[] ms)
      {
        int child = 0;
        for (int i = 0; i < this._dimensions; i++)
          if (!(_compare(ms[i], _average(node.Min[i], node.Max[i])) == Comparison.Less))
            child += 1 << i;
        return child;
      }

      /// <summary>Determins the dimensions of the child at the given index.</summary>
      /// <param name="node">The parent of the node to compute dimensions for.</param>
      /// <param name="child">The index of the child to compute dimensions for.</param>
      /// <param name="min">The computed minimum dimensions of the child node.</param>
      /// <param name="max">The computed maximum dimensions of the child node.</param>
      private void DetermineChildBounds(Node node, int child, out M[] min, out M[] max)
      {
        min = new M[this._dimensions];
        max = new M[this._dimensions];
        for (int i = _dimensions - 1; i >= 0; i--)
        {
          int temp = 1 << i;
          if (child >= temp)
          {
            min[i] = this._average(node.Min[i], node.Max[i]);
            max[i] = node.Max[i];
            child -= temp;
          }
          else
          {
            min[i] = node.Min[i];
            max[i] = this._average(node.Min[i], node.Max[i]);
          }
        }
      }

      /// <summary>Checks a node for inclusion (overlap) between two spaces.</summary>
      /// <param name="left_min">The minimum values of the left space.</param>
      /// <param name="left_max">The maximum values of the left space.</param>
      /// <param name="right_min">The minimum values of the right space.</param>
      /// <param name="right_max">The maximum values of the right space.</param>
      /// <returns>True if the spaces overlap; False if not.</returns>
      private bool InclusionCheck(M[] left_min, M[] left_max, M[] right_min, M[] right_max)
      {
        // if the right space is not outside the left space, they must overlap
        for (int j = 0; j < this._dimensions; j++)
          if (this._compare(left_max[j], right_min[j]) == Comparison.Less ||
            this._compare(left_min[j], right_max[j]) == Comparison.Greater)
            return false;
        return true;
      }

      /// <summary>Checks if a space encapsulates a point.</summary>
      /// <param name="min">The minimum values of the space.</param>
      /// <param name="max">The maximum values of the space.</param>
      /// <param name="ms">The point.</param>
      /// <returns>True if the space encapsulates the point; False if not.</returns>
      private bool EncapsulationCheck(M[] min, M[] max, M[] ms)
      {
        // if the space is not outside the bounds, it must be inside
        for (int j = 0; j < this._dimensions; j++)
          if (this._compare(ms[j], min[j]) == Comparison.Less ||
            this._compare(ms[j], max[j]) == Comparison.Greater)
            return false;
        return true;
      }

      /// <summary>Checks if a space (left) encapsulates another space (right).</summary>
      /// <param name="left_min">The minimum values of the left space.</param>
      /// <param name="left_max">The maximum values of the left space.</param>
      /// <param name="right_min">The minimum values of the right space.</param>
      /// <param name="right_max">The maximum values of the right space.</param>
      /// <returns>True if the left space encapsulates the right; False if not.</returns>
      private bool EncapsulationCheck(M[] left_min, M[] left_max, M[] right_min, M[] right_max)
      {
        // if all the dimensions of the left space are 
        // beyond that of the right, the right is encapsulated
        for (int j = 0; j < this._dimensions; j++)
          if (this._compare(left_min[j], right_min[j]) != Comparison.Less ||
            this._compare(left_max[j], right_max[j]) != Comparison.Greater)
            return false;
        return true;
      }

      /// <summary>Chops (removes) a child from a branch.</summary>
      /// <param name="branch">The parent of the child to chop.</param>
      /// <param name="child">The index of the child to chop.</param>
      private void ChopChild(Branch branch, int child)
      {
        if (branch.Head.Value.Index == child)
          branch.Head = branch.Head.Next;
        else
        {
          Branch.Node list = branch.Head;
          while (list.Next != null)
          {
            if (list.Next.Value.Index == child)
            {
              list.Next = list.Next.Next;
              break;
            }
            list = list.Next;
          }
        }
      }

      /// <summary>Iterates through the entire tree and ensures each item is in the proper leaf.</summary>
      public void Update()
      {
        this.Update(this._top, 0);

        this._previousAddition = this._top;
        this._previousAdditionDepth = 0;
      }

      /// <summary>Recursive version of the Update method.</summary>
      /// <param name="node">The current node of iteration.</param>
      /// <param name="depth">The current depth of iteration.</param>
      private int Update(Node node, int depth)
      {
        int removals = 0;

        if (node is Leaf)
        {
          Leaf leaf = node as Leaf;
          while (leaf.Head != null)
          {
            M x, y;
            this._locate(leaf.Head.Value, out x, out y);
            M[] ms = new M[2] { x, y };

            if (!EncapsulationCheck(leaf.Min, leaf.Max, ms))
            {
              T item = leaf.Head.Value;
              leaf.Head = leaf.Head.Next;
              Node temp = leaf.Parent;
              while (temp != null)
              {
                if (EncapsulationCheck(temp.Min, temp.Max, ms))
                  break;
                removals++;
                temp = temp.Parent;
              }

              if (temp == null)
              {
                this._count--;
                #region error
#if no_error_checking
                                this.HandleOutOfBounds(leaf.Head.Value);
#else
                if (HandleOutOfBounds == null)
                  throw new Error("a node was updated to be out of bounds (found in an update)");
                else
                  this.HandleOutOfBounds(leaf.Head.Value);
#endif
                #endregion
              }
              else
                this.Add(item, temp, ms, depth);
            }
            else
              break;

            leaf.Count -= removals;
          }
          if (leaf.Head != null)
          {
            Leaf.Node list = leaf.Head;
            while (list.Next != null)
            {
              M x, y;
              this._locate(list.Next.Value, out x, out y);
              M[] ms = new M[2] { x, y };

              if (!EncapsulationCheck(leaf.Min, leaf.Max, ms))
              {
                T item = list.Next.Value;
                list.Next = list.Next.Next;
                Node temp = leaf.Parent;
                while (temp != null)
                {
                  if (EncapsulationCheck(temp.Min, temp.Max, ms))
                    break;
                  temp.Count--;
                  temp = temp.Parent;
                }

                if (temp == null)
                {
                  this._count--;

                  #region error
#if no_error_checking
                                    this.HandleOutOfBounds(list.Next.Value);
#else
                  if (HandleOutOfBounds == null)
                    throw new Error("a node was updated to be out of bounds (found in an update)");
                  else
                    this.HandleOutOfBounds(list.Next.Value);
#endif
                  #endregion
                }
                else
                  this.Add(item, temp, ms, depth);
              }
            }
          }
        }
        else
        {
          Branch branch = node as Branch;
          Branch.Node list = branch.Head;
          while (list != null)
          {
            removals += this.Update(list.Value, depth + 1);
            if (list.Value.Count == 0)
              ChopChild(branch, list.Value.Index);
          }

          branch.Count -= removals;

          if (branch.Count < this._load && branch.Count != 0)
            ShrinkChild(branch.Parent, branch.Index);
        }

        return removals;
      }

      /// <summary>Iterates through the provided dimensions and ensures each item is in the proper leaf.</summary>
      /// <param name="min">The minimum dimensions of the space to update.</param>
      /// <param name="max">The maximum dimensions of the space to update.</param>
      public void Update(M[] min, M[] max)
      {
        this.Update(min, max, this._top, 0);

        this._previousAddition = this._top;
        this._previousAdditionDepth = 0;
      }

      /// <summary>Recursive version of the Update method.</summary>
      /// <param name="min">The minimum dimensions of the space to update.</param>
      /// <param name="max">The maximum dimensions of the space to update.</param>
      /// <param name="node">The current node of iteration.</param>
      /// <param name="depth">The current depth in the tree.</param>
      private int Update(M[] min, M[] max, Node node, int depth)
      {
        int removals = 0;

        if (node is Leaf)
        {
          Leaf leaf = node as Leaf;
          while (leaf.Head != null)
          {
            M x, y;
            this._locate(leaf.Head.Value, out x, out y);
            M[] ms = new M[2] { x, y };

            if (!EncapsulationCheck(leaf.Min, leaf.Max, ms))
            {
              T item = leaf.Head.Value;
              leaf.Head = leaf.Head.Next;
              Node temp = leaf.Parent;
              while (temp != null)
              {
                if (EncapsulationCheck(temp.Min, temp.Max, ms))
                  break;
                removals++;
                temp = temp.Parent;
              }

              if (temp == null)
              {
                this._count--;

                #region error
#if no_error_checking
                                this.HandleOutOfBounds(leaf.Head.Value);
#else
                if (HandleOutOfBounds == null)
                  throw new Error("a node was updated to be out of bounds (found in an update)");
                else
                  this.HandleOutOfBounds(leaf.Head.Value);
#endif
                #endregion
              }
              else
                this.Add(item, temp, ms, depth);
            }
            else
              break;

            leaf.Count -= removals;
          }
          if (leaf.Head != null)
          {
            Leaf.Node list = leaf.Head;
            while (list.Next != null)
            {
              M x, y;
              this._locate(list.Next.Value, out x, out y);
              M[] ms = new M[2] { x, y };

              if (!EncapsulationCheck(leaf.Min, leaf.Max, ms))
              {
                T item = list.Next.Value;
                list.Next = list.Next.Next;
                Node temp = leaf.Parent;
                while (temp != null)
                {
                  if (EncapsulationCheck(temp.Min, temp.Max, ms))
                    break;
                  temp.Count--;
                  temp = temp.Parent;
                }

                if (temp == null)
                {
                  this._count--;

                  #region error
#if no_error_checking
                                    this.HandleOutOfBounds(list.Next.Value);
#else
                  if (HandleOutOfBounds == null)
                    throw new Error("a node was updated to be out of bounds (found in an update)");
                  else
                    this.HandleOutOfBounds(list.Next.Value);
#endif
                  #endregion
                }
                else
                  this.Add(item, temp, ms, depth);
              }
            }
          }
        }
        else
        {
          Branch branch = node as Branch;
          Branch.Node list = branch.Head;
          while (list != null)
          {
            if (this.InclusionCheck(list.Value.Min, list.Value.Max, min, max))
            {
              removals += this.Update(min, max, list.Value, depth + 1);
              if (list.Value.Count == 0)
                ChopChild(branch, list.Value.Index);
            }
          }

          branch.Count -= removals;

          if (branch.Count < this._load && branch.Count != 0)
            ShrinkChild(branch.Parent, branch.Index);
        }

        return removals;
      }

      /// <summary>Traverses every item in the tree and performs the delegate in them.</summary>
      /// <param name="function">The delegate to perform on every item in the tree.</param>
      public void Foreach(Foreach<T> function)
      {
        this.Foreach(function, this._top);
      }
      private void Foreach(Foreach<T> function, Node node)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          while (list != null)
          {
            function(list.Value);
            list = list.Next;
          }
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            this.Foreach(function, list.Value);
            list = list.Next;
          }
        }
      }

      /// <summary>Traverses every item in the tree and performs the delegate in them.</summary>
      /// <param name="function">The delegate to perform on every item in the tree.</param>
      public void Foreach(ForeachRef<T> function)
      {
        Foreach(function, this._top);
      }
      private void Foreach(ForeachRef<T> function, Node node)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          while (list != null)
          {
            T temp = list.Value;
            function(ref temp);
            list.Value = temp;
            list = list.Next;
          }
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            this.Foreach(function, list.Value);
            list = list.Next;
          }
        }
      }

      /// <summary>Traverses every item in the tree and performs the delegate in them.</summary>
      /// <param name="function">The delegate to perform on every item in the tree.</param>
      public ForeachStatus Foreach(ForeachBreak<T> function)
      {
        return Foreach(function, this._top);
      }
      private ForeachStatus Foreach(ForeachBreak<T> function, Node node)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          while (list != null)
            if (function(list.Value) == ForeachStatus.Break)
              return ForeachStatus.Break;
          list = list.Next;
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            if (this.Foreach(function, list.Value) == ForeachStatus.Break)
              return ForeachStatus.Break;
            list = list.Next;
          }
        }
        return ForeachStatus.Continue;
      }

      /// <summary>Traverses every item in the tree and performs the delegate in them.</summary>
      /// <param name="function">The delegate to perform on every item in the tree.</param>
      public ForeachStatus Foreach(ForeachRefBreak<T> function)
      {
        return Foreach(function, this._top);
      }
      private ForeachStatus Foreach(ForeachRefBreak<T> function, Node node)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          while (list != null)
          {
            T temp = list.Value;
            ForeachStatus status = function(ref temp);
            list.Value = temp;
            if (status == ForeachStatus.Break)
              return ForeachStatus.Break;
            list = list.Next;
          }
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            if (this.Foreach(function, list.Value) == ForeachStatus.Break)
              return ForeachStatus.Break;
            list = list.Next;
          }
        }
        return ForeachStatus.Continue;
      }

      /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
      /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
      /// <param name="min">The minimum dimensions of the traversal.</param>
      /// <param name="max">The maximum dimensions of the traversal.</param>
      public void Foreach(Foreach<T> function, M[] min, M[] max)
      {
        Foreach(function, _top, min, max);
      }
      private void Foreach(Foreach<T> function, Node node, M[] min, M[] max)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          while (list != null)
          {
            M x, y;
            this._locate(list.Value, out x, out y);
            M[] ms = new M[2] { x, y };

#if no_error_checking
                        // nothing
#else
            if (ms == null || ms.Length != this._dimensions)
              throw new Error("the location function for omnitree is invalid.");
#endif

            if (EncapsulationCheck(min, max, ms))
              function(list.Value);

            list = list.Next;
          }
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            if (InclusionCheck(list.Value.Min, list.Value.Max, min, max))
              this.Foreach(function, list.Value, min, max);

            list = list.Next;
          }
        }
      }

      /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
      /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
      /// <param name="min">The minimum dimensions of the traversal.</param>
      /// <param name="max">The maximum dimensions of the traversal.</param>
      public void Foreach(ForeachRef<T> function, M[] min, M[] max)
      {
        Foreach(function, _top, min, max);
      }
      private void Foreach(ForeachRef<T> function, Node node, M[] min, M[] max)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          while (list != null)
          //for (int i = 0; i < leaf.Count; i++)
          {
            M x, y;
            this._locate(list.Value, out x, out y);
            M[] ms = new M[2] { x, y };

#if no_error_checking
                        // nothing
#else
            if (ms == null || ms.Length != this._dimensions)
              throw new Error("the location function for omnitree is invalid.");
#endif

            if (EncapsulationCheck(min, max, ms))
              function(ref list._value);

            list = list.Next;
          }
        }
        else
        {
          Branch.Node list = (node as Branch).Head;
          while (list != null)
          {
            if (InclusionCheck(list.Value.Min, list.Value.Max, min, max))
              this.Foreach(function, list.Value, min, max);

            list = list.Next;
          }
        }
      }

      /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
      /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
      /// <param name="min">The minimum dimensions of the traversal.</param>
      /// <param name="max">The maximum dimensions of the traversal.</param>
      public ForeachStatus Foreach(ForeachBreak<T> function, M[] min, M[] max)
      {
        return Foreach(function, _top, min, max);
      }
      private ForeachStatus Foreach(ForeachBreak<T> function, Node node, M[] min, M[] max)
      {
        if (node is Leaf)
        {
          Leaf.Node list = (node as Leaf).Head;
          for (; list != null; list = list.Next)
          {
            M x, y;
            this._locate(list.Value, out x, out y);
            M[] ms = new M[2] { x, y };

            #region error
#if no_error_checking
                        // nothing
#else
            if (ms == null || ms.Length != this._dimensions)
              throw new Error("the location function for omnitree is invalid.");
#endif
            #endregion

            if (EncapsulationCheck(min, max, ms))
              if (function(list.Value) == ForeachStatus.Break)
                return ForeachStatus.Break;
            list = list.Next;
          }
        }
        else
        {
          for (Branch.Node list = (node as Branch).Head; list != null; list = list.Next)
            if (InclusionCheck(list.Value.Min, list.Value.Max, min, max))
              if (this.Foreach(function, list.Value, min, max) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
        return ForeachStatus.Continue;
      }

      /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
      /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
      /// <param name="min">The minimum dimensions of the traversal.</param>
      /// <param name="max">The maximum dimensions of the traversal.</param>
      public ForeachStatus Foreach(ForeachRefBreak<T> function, M[] min, M[] max)
      {
        return Foreach(function, _top, min, max);
      }
      private ForeachStatus Foreach(ForeachRefBreak<T> function, Node node, M[] min, M[] max)
      {
        if (node is Leaf)
        {
          for (Leaf.Node list = (node as Leaf).Head; list != null; list = list.Next)
          {
            M x, y;
            this._locate(list.Value, out x, out y);
            M[] ms = new M[2] { x, y };

            #region error
#if no_error_checking
                        // nothing
#else
            if (ms == null || ms.Length != this._dimensions)
              throw new Error("the location function for omnitree is invalid.");
#endif
            #endregion

            if (EncapsulationCheck(min, max, ms))
              if (function(ref list._value) == ForeachStatus.Break)
                return ForeachStatus.Break;
          }
        }
        else
        {
          for (Branch.Node list = (node as Branch).Head; list != null; list = list.Next)
            if (InclusionCheck(list.Value.Min, list.Value.Max, min, max))
              if (this.Foreach(function, list.Value, min, max) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
        return ForeachStatus.Continue;
      }

      ///// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
      //System.Collections.IEnumerator
      //  System.Collections.IEnumerable.GetEnumerator()
      //{
      //    T[] array = this.ToArray();
      //    return array.GetEnumerator();
      //}

      ///// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
      //System.Collections.Generic.IEnumerator<T>
      //  System.Collections.Generic.IEnumerable<T>.GetEnumerator()
      //{
      //    T[] array = this.ToArray();
      //    return ((System.Collections.Generic.IEnumerable<T>)array).GetEnumerator();
      //}

      /// <summary>Puts all the items on this tree into an array.</summary>
      /// <returns>The array containing all the items within the tree.</returns>
      public T[] ToArray()
      {
        int index = 0;
        T[] array = new T[this._count];
        this.Foreach((T entry) => { array[index++] = entry; });
        return array;
      }

      /// <summary>Creates a shallow clone of this data structure.</summary>
      /// <returns>A shallow clone of this data structure.</returns>
      public Quadtree_Linked<T, M> Clone()
      {
        // OPTIMIZATION NEEDED
        Quadtree_Linked<T, M> clone = new Quadtree_Linked<T, M>(
          this._top.Min[0], this._top.Min[1],
          this._top.Max[0], this._top.Max[1],
          this._locate,
          this._compare,
          this._average);
        this.Foreach((T current) => { clone.Add(current); });
        return clone;
      }

      /// <summary>Returns the tree to an empty state.</summary>
      public void Clear()
      {
        this._top = new Leaf(this._top.Min, this._top.Max, null, -1);
        this._count = 0;

        this._load = _defaultLoad;
        this._loadPlusOnePowered =
          Quadtree_Linked<T, M>.Int_Power(this._load + 1, this._dimensions);
        this._loadPowered =
          Quadtree_Linked<T, M>.Int_Power(_load, _dimensions);
      }

      #endregion
    }

    public class Edge
    {
      private T _start;
      private T _end;

      public T Start { get { return this._start; } set { this._start = value; } }
      public T End { get { return this._end; } set { this._end = value; } }

      public Edge(T start, T end)
      {
        this._start = start;
        this._end = end;
      }
    }

    #endregion

    #region field

    public Set_Hash<T> _nodes;
    public Quadtree_Linked<Edge, T> _edges;

    #endregion

    #region property

    public int EdgeCount { get { return this._edges.Count; } }
    public int NodeCount { get { return this._nodes.Count; } }

    public int SizeOf { get { throw new System.NotImplementedException(); } }

    #endregion

    #region construct

    public Graph_Quadtree(Graph_Quadtree<T> graph)
    {
      this._edges = graph._edges.Clone();
      this._nodes = graph._nodes.Clone();
    }

    public Graph_Quadtree(Equate<T> equate, Compare<T> compare, Hash<T> hash, T min, T max, Quadtree.Average<T> average)
    {
      this._nodes = new Set_Hash<T>(equate, hash);
      this._edges = new Quadtree_Linked<Edge, T>(min, min, max, max, (Edge a, out T x, out T y) => { x = a.Start; y = a.End; }, compare, average);
    }

    public Graph_Quadtree(Compare<T> compare, Hash<T> hash, T min, T max, Quadtree.Average<T> average)
    {
      this._nodes = new Set_Hash<T>((T a, T b) => { return compare(a, b) == Comparison.Equal; }, hash);
      this._edges = new Quadtree_Linked<Edge, T>(min, min, max, max, (Edge a, out T x, out T y) => { x = a.Start; y = a.End; }, compare, average);
    }

    #endregion

    #region method

    public bool Adjacent(T a, T b)
    {
      bool exists = false;
      this._edges.Foreach((Edge edge) => { exists = true; }, new T[] { a, b }, new T[] { a, b });
      return exists;
    }

    public void Neighbors(T a, Foreach<T> function)
    {
      if (!this._nodes.Contains(a))
        throw new Error("Attempting to look up the neighbors of a node that does not belong to a graph");

      this._edges.Foreach(
          (Edge e) => { function(e.End); },
          new T[] { a, this._edges.Min[1] }, new T[] { a, this._edges.Max[1] });
    }

    public void Add(T start, T end)
    {
      if (!this._nodes.Contains(start))
        throw new Error("Adding an edge to a graph from a node that does not exists");
      if (!this._nodes.Contains(end))
        throw new Error("Adding an edge to a graph to a node that does not exists");
      this._edges.Foreach(
          (Edge e) => { throw new Error("Adding an edge to a graph that already exists"); },
          new T[] { start, end }, new T[] { start, end });

      this._edges.Add(new Edge(start, end));
    }

    public void Remove(T start, T end)
    {
      if (!this._nodes.Contains(start))
        throw new Error("Removing an edge to a graph from a node that does not exists");
      if (!this._nodes.Contains(end))
        throw new Error("Removing an edge to a graph to a node that does not exists");

      bool exists = false;
      this._edges.Foreach(
          (Edge e) => { exists = true; },
          new T[] { start, end }, new T[] { start, end });
      if (!exists)
        throw new Error("Removing a non-existing edge in a graph");

      this._edges.Remove(new T[] { start, end }, new T[] { start, end });
    }

    public void Add(T node)
    {
      if (this._nodes.Contains(node))
        throw new Error("Adding an already-existing node to a graph");

      this._nodes.Add(node);
    }

    public void Remove(T node)
    {
      if (this._nodes.Contains(node))
        throw new Error("Removing non-existing node from a graph");

      this._edges.Remove(new T[] { node, this._edges.Min[1] }, new T[] { node, this._edges.Max[1] });
      this._edges.Remove(new T[] { this._edges.Min[1], node }, new T[] { this._edges.Max[1], node });

      this._nodes.Add(node);
    }

    public void Foreach(Foreach<T> function)
    {
      this._nodes.Foreach(function);
    }

    public void Foreach(ForeachRef<T> function)
    {
      this._nodes.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachBreak<T> function)
    {
      return this._nodes.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachRefBreak<T> function)
    {
      return this._nodes.Foreach(function);
    }

    public void Foreach(Foreach<Edge> function)
    {
      this._edges.Foreach(function);
    }

    public void Foreach(ForeachRef<Edge> function)
    {
      this._edges.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachBreak<Edge> function)
    {
      return this._edges.Foreach(function);
    }

    public ForeachStatus Foreach(ForeachRefBreak<Edge> function)
    {
      return this._edges.Foreach(function);
    }

    public Structure<T> Clone()
    {
      return new Graph_Quadtree<T>(this);
    }

    public T[] ToArray()
    {
      throw new System.NotImplementedException();
    }

    System.Collections.IEnumerator
          System.Collections.IEnumerable.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    System.Collections.Generic.IEnumerator<T>
      System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    #endregion
  }
}
