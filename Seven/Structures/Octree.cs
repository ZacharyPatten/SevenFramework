// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Structures
{
  /// <summary>Sorts items along 3 dimensions. Made by Zachary Patten.</summary>
  /// <typeparam name="T">The generice type of items to be stored in this omnitree.</typeparam>
  /// <typeparam name="M">The type of the axis dimensions to sort the "T" values upon.</typeparam>
  public interface Octree<T, M> : Structure<T>
  {
    #region events

    /// <summary>
    /// Event for handling items that go outside the bounds of the Octree. Asigning this event
    /// will trigger the delegate instead of throwing an exception.
    /// </summary>
    event Foreach<T> HandleOutOfBounds;

    #endregion

    #region properties

    /// <summary>Gets the dimensions of the center point of the Octree.</summary>
    M[] Origin { get; }

    /// <summary>The minimum dimensions of the Octree.</summary>
    M[] Min { get; }

    /// <summary>The maximum dimensions of the Octree.</summary>
    M[] Max { get; }

    /// <summary>The compare function the Octree is using.</summary>
    Compare<M> Compare { get; }

    /// <summary>The location function the Octree is using.</summary>
    Octree.Locate<T, M> Locate { get; }

    /// <summary>The average function the Octree is using.</summary>
    Octree.Average<M> Average { get; }

    /// <summary>The number of dimensions in this tree.</summary>
    int Dimensions { get; }

    /// <summary>The current number of items in the tree.</summary>
    int Count { get; }

    /// <summary>True (if Count == 0).</summary>
    bool IsEmpty { get; }

    #endregion

    #region methods

    /// <summary>Adds an item to the tree.</summary>
    /// <param name="addition">The item to be added.</param>
    void Add(T addition);

    /// <summary>Iterates through the entire tree and ensures each item is in the proper leaf.</summary>
    void Update();

    /// <summary>Iterates through the provided dimensions and ensures each item is in the proper leaf.</summary>
    /// <param name="min">The minimum dimensions of the space to update.</param>
    /// <param name="max">The maximum dimensions of the space to update.</param>
    void Update(M[] min, M[] max);

    /// <summary>Removes all the items in a given space.</summary>
    /// <param name="min">The minimum values of the space.</param>
    /// <param name="max">The maximum values of the space.</param>
    void Remove(M[] min, M[] max);

    /// <summary>Removes all the items in a given space where equality is met.</summary>
    /// <param name="min">The minimum values of the space.</param>
    /// <param name="max">The maximum values of the space.</param>
    /// <param name="where">The equality constraint of the removal.</param>
    void Remove(M[] min, M[] max, Predicate<T> where);

    /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
    /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
    /// <param name="min">The minimum dimensions of the traversal.</param>
    /// <param name="max">The maximum dimensions of the traversal.</param>
    void Foreach(Foreach<T> function, M[] min, M[] max);

    /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
    /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
    /// <param name="min">The minimum dimensions of the traversal.</param>
    /// <param name="max">The maximum dimensions of the traversal.</param>
    void Foreach(ForeachRef<T> function, M[] min, M[] max);

    /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
    /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
    /// <param name="min">The minimum dimensions of the traversal.</param>
    /// <param name="max">The maximum dimensions of the traversal.</param>
    ForeachStatus Foreach(ForeachBreak<T> function, M[] min, M[] max);

    /// <summary>Performs and specialized traversal of the structure and performs a delegate on every node within the provided dimensions.</summary>
    /// <param name="function">The delegate to perform on all items in the tree within the given bounds.</param>
    /// <param name="min">The minimum dimensions of the traversal.</param>
    /// <param name="max">The maximum dimensions of the traversal.</param>
    ForeachStatus Foreach(ForeachRefBreak<T> function, M[] min, M[] max);

    /// <summary>Returns the tree to an empty state.</summary>
    void Clear();

    #endregion
  }

  /// <summary>Extension class for the Octree interface.</summary>
  public static class Octree
  {
    #region delegates

    /// <summary>Locates an item along the given dimensions.</summary>
    /// <typeparam name="T">The type of the item to locate.</typeparam>
    /// <typeparam name="M">The type of axis type of the Octree.</typeparam>
    /// <param name="item">The item to be located.</param>
    /// <param name="ms">The computed locations of the item.</param>
    public delegate void Locate<T, M>(T item, out M x, out M y, out M z);

    /// <summary>Computes the average between two items.</summary>
    /// <typeparam name="M">The type of items to average.</typeparam>
    /// <param name="left">The first item of the average.</param>
    /// <param name="right">The second item of the average.</param>
    /// <returns>The computed average between the two items.</returns>
    public delegate M Average<M>(M left, M right);

    #endregion

    #region error

    /// <summary>Polymorphism base for Octree exceptions.</summary>
    public class Error : Structure.Error
    {
      /// <summary>Constructs an Octree exception.</summary>
      /// <param name="message">The message of the exception.</param>
      public Error(string message) : base(message) { }
    }

    #endregion
  }

  /// <summary>Sorts items along 3 dimensions. Made by Zachary Patten.</summary>
  /// <typeparam name="T">The generice type of items to be stored in this octree.</typeparam>
  /// <typeparam name="M">The type of the axis dimensions to sort the "T" values upon.</typeparam>
  [System.Serializable]
  public class Octree_Linked<T, M> : Octree<T, M>
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
        private Octree_Linked<T, M>.Node _value;
        private Branch.Node _next;

        public Octree_Linked<T, M>.Node Value { get { return this._value; } }
        public Branch.Node Next { get { return this._next; } set { this._next = value; } }

        public Node(Octree_Linked<T, M>.Node value, Branch.Node next)
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

    private Octree.Locate<T, M> _locate;
    private Octree.Average<M> _average;
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

    /// <summary>Event for handling items that go outside the bounds of the Octree.</summary>
    public event Foreach<T> HandleOutOfBounds;

    #endregion

    #region Property

    /// <summary>Gets the dimensions of the center point of the Octree.</summary>
    public M[] Origin { get { return (M[])this._origin.Clone(); } }

    /// <summary>The minimum dimensions of the Octree.</summary>
    public M[] Min { get { return (M[])this._top.Min.Clone(); } }

    /// <summary>The maximum dimensions of the Octree.</summary>
    public M[] Max { get { return (M[])this._top.Max.Clone(); } }

    /// <summary>The number of dimensions in this tree.</summary>
    public int Dimensions { get { return this._dimensions; } }

    /// <summary>The current number of items in the tree.</summary>
    public int Count { get { return this._count; } }

    /// <summary>True if (Count == 0).</summary>
    public bool IsEmpty { get { return this._count == 0; } }

    /// <summary>Gets the current memory allocation size of this structure.</summary>
    public int SizeOf { get { throw new System.NotImplementedException("Sorry, I'm working on it."); } }

    /// <summary>The compare function the Octree is using.</summary>
    public Compare<M> Compare { get { return this._compare; } }

    /// <summary>The location function the Octree is using.</summary>
    public Octree.Locate<T, M> Locate { get { return this._locate; } }

    /// <summary>The average function the Octree is using.</summary>
    public Octree.Average<M> Average { get { return this._average; } }

    #endregion

    #region construct

    /// <summary>Constructor for an Octree_Linked.</summary>
    /// <param name="min">The minimum values of the tree.</param>
    /// <param name="max">The maximum values of the tree.</param>
    /// <param name="locate">A function for locating an item along the provided dimensions.</param>
    /// <param name="compare">A function for comparing two items of the types of the axis.</param>
    /// <param name="average">A function for computing the average between two items of the axis types.</param>
    public Octree_Linked(
      M min_x, M min_y, M min_z,
      M max_x, M max_y, M max_z,
      Octree.Locate<T, M> locate,
      Compare<M> compare,
      Octree.Average<M> average)
    {
      M[] min = new M[3] { min_x, min_y, min_z };
      M[] max = new M[3] { max_x, max_y, max_z };

      #region error
#if no_error_checking
      // nothing
#else
      // check the locate and compare delegates
      if (locate == null)
        throw new Error("null reference on location delegate during Octree construction");
      if (compare == null)
        throw new Error("null reference on compare delegate during Octree construction");

      // Check the min/max values
      if (min == null)
        throw new Error("null reference on min dimensions during Octree construction");
      if (max == null)
        throw new Error("null reference on max dimensions during Octree construction");
      if (min.Length != max.Length)
        throw new Error("min/max values for omnitree mismatch dimensions");
      for (int i = 0; i < min.Length; i++)
        if (compare(min[i], max[i]) != Comparison.Less)
          throw new Error("invalid min/max values. not all min values are less than the max values");

      // Check the average delegate
      if (average == null)
        throw new Error("null reference on average delegate during Octree construction");
      M[] origin = new M[min.Length];
      for (int i = 0; i < min.Length; i++)
        origin[i] = average(min[i], max[i]);
      for (int i = 0; i < min.Length; i++)
        if (compare(min[i], origin[i]) != Comparison.Less || compare(origin[i], max[i]) != Comparison.Less)
          throw new Error("invalid average function. not all average values were computed to be between the min/max values.");
#endif
      #endregion

      this._locate = locate;
      this._average = average;
      this._compare = compare;
      this._dimensions = min.Length;
      this._children = 1 << this._dimensions;

      this._count = 0;
      this._top = new Leaf(min, max, null, -1);

      this._load = _defaultLoad;
      this._loadPlusOnePowered =
        Octree_Linked<T, M>.Int_Power(this._load + 1, this._dimensions);
      this._loadPowered =
        Octree_Linked<T, M>.Int_Power(_load, _dimensions);

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
        throw new Error("(Count == int.MaxValue) max Octree size reached (change ints to longs if you need to).");
#endif
      #endregion

      // dynamic tree sizes
      if (this._loadPlusOnePowered < this._count)
      {
        this._load++;
        this._loadPlusOnePowered =
          Octree_Linked<T, M>.Int_Power(this._load + 1, this._dimensions);
        this._loadPowered =
          Octree_Linked<T, M>.Int_Power(this._load, this._dimensions);
      }

      M x, y, z;
      this._locate(addition, out x, out y, out z);
      M[] ms = new M[3] { x, y, z };

      #region error
#if no_error_checking
      // this check is still required
      if (!EncapsulationCheck(this._top.Min, this._top.Max, ms))
          this.HandleOutOfBounds(list.Value);
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
          M x_2, y_2, z_2;
          this._locate(list.Value, out x_2, out y_2, out z_2);
          M[] child_ms = new M[3] { x_2, y_2, z_2 };
          
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
          Octree_Linked<T, M>.Leaf_Add(leaf, addition);

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
            M x, y, z;
            this._locate(list.Value, out x, out y, out z);
            M[] child_ms = new M[3] { x, y, z };

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
          Octree_Linked<T, M>.Leaf_Add(leaf, addition);

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
          Octree_Linked<T, M>.Int_Power(_load + 1, _dimensions);
        this._loadPowered =
          Octree_Linked<T, M>.Int_Power(_load, _dimensions);
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
          Octree_Linked<T, M>.Int_Power(_load + 1, _dimensions);
        this._loadPowered =
          Octree_Linked<T, M>.Int_Power(_load, _dimensions);
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
          M x, y, z;
          this._locate(leaf.Head.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };
          
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
            M x, y, z;
            this._locate(list.Next.Value, out x, out y, out z);
            M[] ms = new M[3] { x, y, z };
            
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
          Octree_Linked<T, M>.Int_Power(_load + 1, _dimensions);
        this._loadPowered =
          Octree_Linked<T, M>.Int_Power(_load, _dimensions);
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
          M x, y, z;
          this._locate(leaf.Head.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z }; ;

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
            M x, y, z;
            this._locate(list.Next.Value, out x, out y, out z);
            M[] ms = new M[3] { x, y, z };

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
          M x, y, z;
          this._locate(leaf.Head.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

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
              this.HandleOutOfBounds(leaf.Contents[i]);
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
            M x, y, z;
            this._locate(list.Next.Value, out x, out y, out z);
            M[] ms = new M[3] { x, y, z };
            
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
                this.HandleOutOfBounds(leaf.Contents[i]);
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
          M x, y, z;
          this._locate(leaf.Head.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

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
              this.HandleOutOfBounds(leaf.Contents[i]);
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
            M x, y, z;
            this._locate(list.Next.Value, out x, out y, out z);
            M[] ms = new M[3] { x, y, z };

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
                this.HandleOutOfBounds(leaf.Contents[i]);
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
          M x, y, z;
          this._locate(list.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

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
          M x, y, z;
          this._locate(list.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

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
          M x, y, z;
          this._locate(list.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

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
          M x, y, z;
          this._locate(list.Value, out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

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

    /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
    System.Collections.IEnumerator
      System.Collections.IEnumerable.GetEnumerator()
    {
      T[] array = this.ToArray();
      return array.GetEnumerator();
    }

    /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
    System.Collections.Generic.IEnumerator<T>
      System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    {
      T[] array = this.ToArray();
      return ((System.Collections.Generic.IEnumerable<T>)array).GetEnumerator();
    }

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
    public Structure<T> Clone()
    {
      // OPTIMIZATION NEEDED
      Octree_Array<T, M> clone = new Octree_Array<T, M>(
        this._top.Min[0], this._top.Min[1], this._top.Min[2],
        this._top.Max[0], this._top.Max[1], this._top.Max[2],
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
        Octree_Linked<T, M>.Int_Power(this._load + 1, this._dimensions);
      this._loadPowered =
        Octree_Linked<T, M>.Int_Power(_load, _dimensions);
    }

    #endregion

    #region error

    /// <summary>Octree_Array Exception.</summary>
    private class Error : Octree.Error
    {
      public Error(string message) : base(message) { }
    }

    #endregion
  }

  /// <summary>Sorts items along 3 dimensions. Made by Zachary Patten.</summary>
  /// <typeparam name="T">The generice type of items to be stored in this octree.</typeparam>
  /// <typeparam name="M">The type of the axis dimensions to sort the "T" values upon.</typeparam>
  [System.Serializable]
  public class Octree_Array<T, M> : Octree<T, M>
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

    /// <summary>A leaf in the tree. Only contains items.</summary>
    private class Leaf : Node
    {
      private T[] _contents;

      public T[] Contents { get { return this._contents; } set { this._contents = value; } }

      public Leaf(M[] min, M[] max, Branch parent, int index)
        : base(min, max, parent, index)
      {
        this._contents = new T[_defaultLoad];
      }
    }

    /// <summary>A branch in the tree. Only contains nodes.</summary>
    private class Branch : Node
    {
      private Node[] _children;
      private int _childCount;

      internal int ChildCount { get { return this._childCount; } set { this._childCount = value; } }
      internal Node[] Children { get { return this._children; } set { this._children = value; } }

      public Branch(M[] min, M[] max, Branch parent, int index, int initialSize)
        : base(min, max, parent, index)
      {
        this._children = new Node[initialSize];
        this._childCount = 0;
      }
    }

    #endregion

    #region field

    private const int _defaultLoad = 2;

    private Octree.Locate<T, M> _locate;
    private Octree.Average<M> _average;
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

    /// <summary>Event for handling items that go outside the bounds of the Octree.</summary>
    public event Foreach<T> HandleOutOfBounds;

    #endregion

    #region property

    /// <summary>Gets the dimensions of the center point of the Octree.</summary>
    public M[] Origin { get { return (M[])this._origin.Clone(); } }

    /// <summary>The minimum dimensions of the Octree.</summary>
    public M[] Min { get { return (M[])this._top.Min.Clone(); } }

    /// <summary>The maximum dimensions of the Octree.</summary>
    public M[] Max { get { return (M[])this._top.Max.Clone(); } }

    /// <summary>The number of dimensions in this tree.</summary>
    public int Dimensions { get { return this._dimensions; } }

    /// <summary>The current number of items in the tree.</summary>
    public int Count { get { return this._count; } }

    /// <summary>True if (Count == 0).</summary>
    public bool IsEmpty { get { return this._count == 0; } }

    /// <summary>Gets the current memory allocation size of this structure.</summary>
    public int SizeOf { get { throw new System.NotImplementedException("Sorry, I'm working on it."); } }

    /// <summary>The compare function the Octree is using.</summary>
    public Compare<M> Compare { get { return this._compare; } }

    /// <summary>The location function the Octree is using.</summary>
    public Octree.Locate<T, M> Locate { get { return this._locate; } }

    /// <summary>The average function the Octree is using.</summary>
    public Octree.Average<M> Average { get { return this._average; } }

    #endregion

    #region construct

    /// <summary>Constructor for an Octree_Linked.</summary>
    /// <param name="min">The minimum values of the tree.</param>
    /// <param name="max">The maximum values of the tree.</param>
    /// <param name="locate">A function for locating an item along the provided dimensions.</param>
    /// <param name="compare">A function for comparing two items of the types of the axis.</param>
    /// <param name="average">A function for computing the average between two items of the axis types.</param>
    public Octree_Array(
      M min_x, M min_y, M min_z,
      M max_x, M max_y, M max_z,
      Octree.Locate<T, M> locate,
      Compare<M> compare,
      Octree.Average<M> average)
    {
      M[] min = new M[3] { min_x, min_y, min_z };
      M[] max = new M[3] { max_x, max_y, max_z };

      // check the locate and compare delegates
      if (locate == null)
        throw new Error("null reference on location delegate during Octree construction");
      if (compare == null)
        throw new Error("null reference on compare delegate during Octree construction");

      // Check the min/max values
      if (min == null)
        throw new Error("null reference on min dimensions during Octree construction");
      if (max == null)
        throw new Error("null reference on max dimensions during Octree construction");
      if (min.Length != max.Length)
        throw new Error("min/max values for omnitree mismatch dimensions");
      for (int i = 0; i < min.Length; i++)
        if (compare(min[i], max[i]) != Comparison.Less)
          throw new Error("invalid min/max values. not all min values are less than the max values");

      // Check the average delegate
      if (average == null)
        throw new Error("null reference on average delegate during Octree construction");
      M[] origin = new M[min.Length];
      for (int i = 0; i < min.Length; i++)
        origin[i] = average(min[i], max[i]);
      for (int i = 0; i < min.Length; i++)
        if (compare(min[i], origin[i]) != Comparison.Less || compare(origin[i], max[i]) != Comparison.Less)
          throw new Error("invalid average function. not all average values were computed to be between the min/max values.");

      this._locate = locate;
      this._average = average;
      this._compare = compare;
      this._dimensions = min.Length;
      this._children = 1 << this._dimensions;

      this._count = 0;
      this._top = new Leaf(min, max, null, -1);

      this._load = _defaultLoad;
      this._loadPlusOnePowered =
        Octree_Array<T, M>.Int_Power(this._load + 1, this._dimensions);
      this._loadPowered =
        Octree_Array<T, M>.Int_Power(_load, _dimensions);

      this._origin = origin;

      this._previousAddition = this._top;
      this._previousAdditionDepth = 0;
    }

    #endregion

    #region methods

    /// <summary>Adds an item to the tree.</summary>
    /// <param name="addition">The item to be added.</param>
    public void Add(T addition)
    {
      if (this._count == int.MaxValue)
        throw new Error("(Count == int.MaxValue) max Octree size reached (change ints to longs if you need to).");

      // dynamic tree sizes
      if (this._loadPlusOnePowered < this._count)
      {
        this._load++;
        this._loadPlusOnePowered =
          Octree_Array<T, M>.Int_Power(this._load + 1, this._dimensions);
        this._loadPowered =
          Octree_Array<T, M>.Int_Power(this._load, this._dimensions);
      }

      M x, y, z;
      this._locate(addition, out x, out y, out z);
      M[] ms = new M[3] { x, y, z };

      if (ms == null || ms.Length != this._dimensions)
        throw new Error("the location function for omnitree is invalid.");

      if (!EncapsulationCheck(this._top.Min, this._top.Max, ms))
        throw new Error("out of bounds during addition");

      if (this._top is Leaf && (this._top as Leaf).Count >= this._load)
      {
        Leaf leaf = this._top as Leaf;
        this._top = new Branch(this._top.Min, this._top.Max, null, -1, _defaultLoad);

        for (int i = 0; i < leaf.Count; i++)
        {
          M x_2, y_2, z_2;
          this._locate(leaf.Contents[i], out x_2, out y_2, out z_2);
          M[] child_ms = new M[3] { x_2, y_2, z_2 };

          if (child_ms == null || child_ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (!EncapsulationCheck(this._top.Min, this._top.Max, child_ms))
          {
            this._count--;
            if (HandleOutOfBounds == null)
              throw new Error("a node was updated to be out of bounds (found in an addition)");
            else
              this.HandleOutOfBounds(leaf.Contents[i]);
          }
          else
            Add(leaf.Contents[i], this._top, child_ms, 0);
        }
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
          Octree_Array<T, M>.Leaf_Add(leaf, addition);

          this._previousAddition = leaf;
          this._previousAdditionDepth = depth;

          return;
        }
        else
        {
          Branch parent = node.Parent;
          Branch growth = GrowBranch(parent, leaf.Min, leaf.Max, this.DetermineChild(parent, ms));

          for (int i = 0; i < leaf.Count; i++)
          {
            M x_2, y_2, z_2;
            this._locate(leaf.Contents[i], out x_2, out y_2, out z_2);
            M[] child_ms = new M[3] { x_2, y_2, z_2 };

            if (child_ms == null || child_ms.Length != this._dimensions)
              throw new Error("the location function for omnitree is invalid.");

            if (EncapsulationCheck(growth.Min, growth.Max, child_ms))
              Add(leaf.Contents[i], growth, child_ms, depth);
            else
            {
              if (EncapsulationCheck(this._top.Min, this._top.Max, child_ms))
              {
                this._count--;
                if (HandleOutOfBounds == null)
                  throw new Error("a node was updated to be out of bounds (found in an addition)");
                else
                  this.HandleOutOfBounds(leaf.Contents[i]);
              }
              else
                Add(leaf.Contents[i], this._top, child_ms, depth);
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
          Octree_Array<T, M>.Leaf_Add(leaf, addition);

          this._previousAddition = leaf;
          this._previousAdditionDepth = depth + 1;

          branch.Count++;
          return;
        }

        Add(addition, child_node, ms, depth + 1);
        branch.Count++;
        return;
      }
    }

    /// <summary>Adds an item to a leaf.</summary>
    /// <param name="leaf">The leaf to add to.</param>
    /// <param name="addition">The item to add to the leaf.</param>
    private static void Leaf_Add(Leaf leaf, T addition)
    {
      if (leaf.Count == leaf.Contents.Length)
      {
        T[] newAllocaiton = new T[leaf.Contents.Length * 2];
        for (int i = 0; i < leaf.Contents.Length; i++)
          newAllocaiton[i] = leaf.Contents[i];
        leaf.Contents = newAllocaiton;
      }
      leaf.Contents[leaf.Count++] = addition;
    }

    /// <summary>Gets a child at of a given index in a branch.</summary>
    /// <param name="branch">The branch to get the child of.</param>
    /// <param name="index">The index of the child to get.</param>
    /// <returns>The value of the child.</returns>
    private Node Branch_GetChild(Branch branch, int index)
    {
      // fully allocated branch - use true indeces
      if (branch.Children.Length == this._children)
        return branch.Children[index];
      // partially allocated branch - use fake indeces
      for (int i = 0; i < branch.ChildCount; i++)
        if (branch.Children[i].Index == index)
          return branch.Children[i];
      return null;
    }

    /// <summary>Sets a child at of a given index in a branch.</summary>
    /// <param name="branch">The branch to set the child of.</param>
    /// <param name="index">The index of the child to set.</param>
    /// <param name="value">The value to be set.</param>
    private Node Branch_SetChild(Branch branch, int index, Node value)
    {
      // leaves are completely new nodes (as oposed to branches replacing leaves)
      if (value is Leaf)
      {
        // if the branch is fully allocated, treat the index as the
        // actual index we want to set
        if (branch.Children.Length == this._children)
          branch.Children[index] = value;
        // if the branch is not yet fully allocated - the index must
        // first be found in the partial allocation
        else
        {
          // the list array has reached capacity and needs to grow
          if (branch.ChildCount == branch.Children.Length)
          {
            Node[] newAllocation =
              new Node[branch.Children.Length * 2 > this._children ?
                branch.Children.Length * 2 : this._children];

            // if the growth will result in a fully allocated branch -
            // make the indeces true indeces
            if (newAllocation.Length == this._children)
            {
              foreach (Node node in branch.Children)
                newAllocation[node.Index] = node;
              newAllocation[index] = value;
              branch.Children = newAllocation;
              branch.ChildCount++;
            }
            // if the branch will not yet be fully allocated - just
            // keep using fake indeces
            else
            {
              for (int i = 0; i < branch.Children.Length; i++)
                newAllocation[i] = branch.Children[i];
              newAllocation[branch.ChildCount++] = value;
              branch.Children = newAllocation;
            }
          }
          // now growth required - just add using fake indeces
          else
            branch.Children[branch.ChildCount++] = value;
        }
      }
      else
      {
        // value is a branch; we need to overwrite a leaf
        for (int i = 0; i < branch.Children.Length; i++)
          if (branch.Children[i].Index == index)
          {
            branch.Children[i] = value;
            break;
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
          Octree_Array<T, M>.Int_Power(_load + 1, _dimensions);
        this._loadPowered =
          Octree_Array<T, M>.Int_Power(_load, _dimensions);
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
        for (int i = 0; i < leaf.Count; i++)
        {
          if (where(leaf.Contents[i]))
            removals++;
          else
            leaf.Contents[i - removals] = leaf.Contents[i];
        }
        leaf.Count -= removals;
        this._count -= removals;

        return removals;
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (branch.Children[i] != null)
            {
              removals += this.Remove(branch.Children[i], where);
              if (branch.Children[i].Count == 0)
                ChopChild(branch, branch.Children[i--].Index);
            }
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
          {
            removals += this.Remove(branch.Children[i], where);
            if (branch.Children[i].Count == 0)
              this.ChopChild(branch, branch.Children[i--].Index);
          }
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
          Octree_Array<T, M>.Int_Power(_load + 1, _dimensions);
        this._loadPowered =
          Octree_Array<T, M>.Int_Power(_load, _dimensions);
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
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (this.EncapsulationCheck(min, max, ms))
            removals++;
          else
            leaf.Contents[i - removals] = leaf.Contents[i];
        }
        leaf.Count -= removals;
        this._count -= removals;

        return removals;
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (branch.Children[i] != null && InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
            {
              if (this.EncapsulationCheck(min, max, node.Min, node.Max))
              {
                removals += node.Count;
                ChopChild(branch, branch.Children[i--].Index);
              }
              else
              {
                removals += this.Remove(branch.Children[i], min, max);
                if (branch.Children[i].Count == 0)
                  ChopChild(branch, branch.Children[i--].Index);
              }
            }
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
            {
              if (this.EncapsulationCheck(min, max, node.Min, node.Max))
              {
                removals += node.Count;
                this.ChopChild(branch, branch.Children[i--].Index);
              }
              else
              {
                removals += this.Remove(branch.Children[i], min, max);
                if (branch.Children[i].Count == 0)
                  this.ChopChild(branch, branch.Children[i--].Index);
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
      else if (parent.Children.Length == this._children)
      {
        Node oldChild = parent.Children[child];
        parent.Children[child] = new Leaf(oldChild.Min, oldChild.Max, parent, oldChild.Index);
        this.Foreach((T i) => { this.Add(i); }, oldChild);
      }
      else
      {
        for (int i = 0; i < parent.ChildCount; i++)
        {
          if (parent.Children[i].Index == child)
          {
            Node oldChild = parent.Children[i];
            parent.Children[i] = new Leaf(oldChild.Min, oldChild.Max, parent, oldChild.Index);
            this.Foreach((T j) => { this.Add(j); }, oldChild);
            break;
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
          Octree_Array<T, M>.Int_Power(_load + 1, _dimensions);
        this._loadPowered =
          Octree_Array<T, M>.Int_Power(_load, _dimensions);
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
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (this.EncapsulationCheck(min, max, ms) && where(leaf.Contents[i]))
            removals++;
          else
            leaf.Contents[i - removals] = leaf.Contents[i];
        }
        leaf.Count -= removals;
        this._count -= removals;

        return removals;
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (branch.Children[i] != null)
            {
              removals += this.Remove(branch.Children[i], min, max, where);
              if (branch.Children[i].Count == 0)
                ChopChild(branch, branch.Children[i--].Index);
            }
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
          {
            removals += this.Remove(branch.Children[i], min, max, where);
            if (branch.Children[i].Count == 0)
              this.ChopChild(branch, branch.Children[i--].Index);
          }
        }
        branch.Count -= removals;

        if (branch.Count < this._load && branch.Count != 0)
          ShrinkChild(branch.Parent, branch.Index);

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
        new Branch(min, max, branch, child, _defaultLoad)) as Branch;
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
      if (branch.Children.Length == this._children)
        branch.Children[child] = null;
      else
      {
        for (int i = 0; i < branch.ChildCount; i++)
          if (branch.Children[i].Index == child)
          {
            branch.Children[i] = branch.Children[branch.ChildCount - 1];
            branch.ChildCount--;
            break;
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
    private void Update(Node node, int depth)
    {
      if (node is Leaf)
      {
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (!EncapsulationCheck(leaf.Min, leaf.Max, ms))
          {
            T item = leaf.Contents[i];
            leaf.Contents[i] = leaf.Contents[--leaf.Count];
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
              if (HandleOutOfBounds == null)
                throw new Error("a node was updated to be out of bounds (found in an update)");
              else
                this.HandleOutOfBounds(leaf.Contents[i]);
            }
            else
              this.Add(item, temp, ms, depth);
          }
        }
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (branch.Children[i] != null)
            {
              this.Update(branch.Children[i], depth + 1);
              if (branch.Children[i].Count == 0)
                ChopChild(branch, branch.Children[i].Index);
            }
        }
        else
          for (int i = 0; i < branch.ChildCount; i++)
          {
            this.Update(branch.Children[i], depth + 1);
            if (branch.Children[i].Count == 0)
              ChopChild(branch, branch.Children[i].Index);
          }

        if (branch.Count < this._load && branch.Count != 0)
          ShrinkChild(branch.Parent, branch.Index);
      }
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
    private void Update(M[] min, M[] max, Node node, int depth)
    {
      if (node is Leaf)
      {
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");


          if (!EncapsulationCheck(leaf.Min, leaf.Max, ms))
          {
            T item = leaf.Contents[i];
            leaf.Contents[i] = leaf.Contents[--leaf.Count];
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
              if (HandleOutOfBounds == null)
                throw new Error("a node was updated to be out of bounds (found in an update)");
              else
                this.HandleOutOfBounds(leaf.Contents[i]);
            }
            else
              this.Add(item, temp, ms, depth);
          }
        }
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (branch.Children[i] != null)
            {
              this.Update(branch.Children[i], depth + 1);
              if (branch.Children[i].Count == 0)
                ChopChild(branch, branch.Children[i].Index);
            }
        }
        else
          for (int i = 0; i < branch.ChildCount; i++)
          {
            this.Update(branch.Children[i], depth + 1);
            if (branch.Children[i].Count == 0)
              ChopChild(branch, branch.Children[i].Index);
          }

        if (branch.Count < this._load && branch.Count != 0)
          ShrinkChild(branch.Parent, branch.Index);
      }
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
          function(leaf.Contents[i]);
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          foreach (Node child in branch.Children)
            if (child != null)
              this.Foreach(function, child);
        }
        else
          for (int i = 0; i < branch.ChildCount; i++)
            this.Foreach(function, branch.Children[i]);
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
          function(ref leaf.Contents[i]);
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          foreach (Node child in branch.Children)
            if (child != null)
              this.Foreach(function, child);
        }
        else
          for (int i = 0; i < branch.ChildCount; i++)
            this.Foreach(function, branch.Children[i]);
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
          if (function(leaf.Contents[i]) == ForeachStatus.Break)
            return ForeachStatus.Break;
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.ChildCount == this._children)
        {
          foreach (Node child in branch.Children)
            if (child != null)
              if (this.Foreach(function, child) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
        else
          for (int i = 0; i < branch.ChildCount; i++)
            if (this.Foreach(function, branch.Children[i]) == ForeachStatus.Break)
              return ForeachStatus.Break;
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
          if (function(ref leaf.Contents[i]) == ForeachStatus.Break)
            return ForeachStatus.Break;
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          foreach (Node child in branch.Children)
            if (child != null)
              if (this.Foreach(function, child) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
        else
          for (int i = 0; i < branch.ChildCount; i++)
            if (this.Foreach(function, branch.Children[i]) == ForeachStatus.Break)
              return ForeachStatus.Break;
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (EncapsulationCheck(min, max, ms))
            function(leaf.Contents[i]);
        }
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (branch.Children[i] != null && InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              this.Foreach(function, branch.Children[i], min, max);
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              this.Foreach(function, branch.Children[i], min, max);
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (EncapsulationCheck(min, max, ms))
            function(ref leaf.Contents[i]);
        }
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < this._children; i++)
            if (branch.Children[i] != null && InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              this.Foreach(function, branch.Children[i], min, max);
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              this.Foreach(function, branch.Children[i], min, max);
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (EncapsulationCheck(min, max, ms))
            if (function(leaf.Contents[i]) == ForeachStatus.Break)
              return ForeachStatus.Break;
        }
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < this._children; i++)
            if (branch.Children[i] != null && InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              if (this.Foreach(function, branch.Children[i], min, max) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              if (this.Foreach(function, branch.Children[i], min, max) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
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
        Leaf leaf = node as Leaf;
        for (int i = 0; i < leaf.Count; i++)
        {
          M x, y, z;
          this._locate(leaf.Contents[i], out x, out y, out z);
          M[] ms = new M[3] { x, y, z };

          if (ms == null || ms.Length != this._dimensions)
            throw new Error("the location function for omnitree is invalid.");

          if (EncapsulationCheck(min, max, ms))
            if (function(ref leaf.Contents[i]) == ForeachStatus.Break)
              return ForeachStatus.Break;
        }
      }
      else
      {
        Branch branch = node as Branch;
        if (branch.Children.Length == this._children)
        {
          for (int i = 0; i < this._children; i++)
            if (branch.Children[i] != null && InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              if (this.Foreach(function, branch.Children[i], min, max) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
        else
        {
          for (int i = 0; i < branch.ChildCount; i++)
            if (InclusionCheck(branch.Children[i].Min, branch.Children[i].Max, min, max))
              if (this.Foreach(function, branch.Children[i], min, max) == ForeachStatus.Break)
                return ForeachStatus.Break;
        }
      }
      return ForeachStatus.Continue;
    }

    /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
    System.Collections.IEnumerator
      System.Collections.IEnumerable.GetEnumerator()
    {
      T[] array = this.ToArray();
      return array.GetEnumerator();
    }

    /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
    System.Collections.Generic.IEnumerator<T>
      System.Collections.Generic.IEnumerable<T>.GetEnumerator()
    {
      T[] array = this.ToArray();
      return ((System.Collections.Generic.IEnumerable<T>)array).GetEnumerator();
    }

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
    public Structure<T> Clone()
    {
      // OPTIMIZATION NEEDED
      Octree_Array<T, M> clone = new Octree_Array<T, M>(
        this._top.Min[0], this._top.Min[1], this._top.Min[2],
        this._top.Max[0], this._top.Max[1], this._top.Max[2],
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
        Octree_Array<T, M>.Int_Power(this._load + 1, this._dimensions);
      this._loadPowered =
        Octree_Array<T, M>.Int_Power(_load, _dimensions);
    }

    #endregion

    #region error

    /// <summary>Octree_Array Exception.</summary>
    private class Error : Octree.Error
    {
      public Error(string message) : base(message) { }
    }

    #endregion
  }

  #region Back-Up Version

  //public interface Octree<T> : Structure<T>
  //{
  //  int Count { get; }
  //  bool IsEmpty { get; }
  //  void Add(T addition);
  //  //void Move(KeyType moving);
  //  //void Update();
  //}

  ///// <summary>Axis-Aligned rectangular prism generic octree for storing items along three axis.</summary>
  ///// <typeparam name="T">The generice type of items to be stored in this octree.</typeparam>
  //[System.Serializable]
  //public class Octree_Linked<T, M> : Octree<T>
  //{
  //  /// <summary>Represents a single node of the octree. Includes references both upwards and
  //  /// downwards the tree.</summary>
  //  private abstract class Node
  //  {
  //    private M _minX;
  //    private M _minY;
  //    private M _minZ;
  //    private M _maxX;
  //    private M _maxY;
  //    private M _maxZ;
  //    private Branch _parent;

  //    internal M MinX { get { return _minX; } }
  //    internal M MinY { get { return _minY; } }
  //    internal M MinZ { get { return _minZ; } }
  //    internal M MaxX { get { return _maxX; } }
  //    internal M MaxY { get { return _maxY; } }
  //    internal M MaxZ { get { return _maxZ; } }
  //    internal Branch Parent { get { return _parent; } }

  //    internal Node(M minX, M minY, M minZ, M maxX, M maxY, M maxZ, Branch parent)
  //    {
  //      _minX = minX;
  //      _minY = minY;
  //      _minZ = minZ;
  //      _maxX = maxX;
  //      _maxY = maxY;
  //      _maxZ = maxZ;
  //      _parent = parent;
  //    }
  //  }

  //  /// <summary>Represents a single node of the octree. Includes references both upwards and
  //  /// downwards the tree.</summary>
  //  private class Leaf : Node
  //  {
  //    private T[] _contents;
  //    private int _count;

  //    internal T[] Contents { get { return _contents; } }
  //    internal int Count { get { return _count; } set { _count = value; } }
  //    internal bool IsFull { get { return _count == _contents.Length; } }

  //    internal Leaf(M minX, M minY, M minZ, M maxX, M maxY, M maxZ, Branch parent, int loadFactor)
  //      : base(minX, minY, minZ, maxX, maxY, maxZ, parent)
  //    { _contents = new T[loadFactor]; }

  //    internal Leaf Add(T addition)
  //    {
  //      //Console.WriteLine("Placing " + addition + ", in " + this.MinX + ", " + this.MinY + ", " + this.MinZ);
  //      if (_count == _contents.Length)
  //        throw new Error("There is a glitch in my octree, sorry...");
  //      _contents[_count++] = addition;
  //      return this;
  //    }
  //  }

  //  /// <summary>Represents a single node of the octree. Includes references both upwards and
  //  /// downwards the tree.</summary>
  //  private class Branch : Node
  //  {
  //    public Node[] _children;

  //    public Node[] Children { get { return this._children; } }

  //    internal bool IsEmpty
  //    {
  //      get
  //      {
  //        foreach (Node child in this._children)
  //          if (child != null)
  //            return false;
  //        return true;
  //      }
  //    }

  //    internal Branch(M minX, M minY, M minZ, M maxX, M maxY, M maxZ, Branch parent)
  //      : base(minX, minY, minZ, maxX, maxY, maxZ, parent)
  //    {
  //      this._children = new Node[8];
  //    }
  //  }

  //  public delegate void Locate<Type>(Type item, out M x, out M y, out M z);

  //  public delegate T Average<T>(T first, T second);

  //  private Locate<T> _locate;
  //  public Average<M> _average;
  //  public Compare<M> _compare;
  //  private int _loadFactor;
  //  private int _count;
  //  private Node _top;

  //  public int Count { get { return _count; } }
  //  public bool IsEmpty { get { return _count == 0; } }

  //  public Octree_Linked(
  //    M minX, M minY, M minZ,
  //    M maxX, M maxY, M maxZ,
  //    int loadFactor,
  //    Locate<T> locate,
  //    Compare<M> compare,
  //    Average<M> average)
  //  {
  //    this._loadFactor = loadFactor;
  //    this._top = new Leaf(minX, minY, minZ, maxX, maxY, maxZ, null, _loadFactor);
  //    this._count = 0;
  //    this._locate = locate;
  //    this._average = average;
  //    this._compare = compare;
  //  }

  //  /// <summary>Adds an item to the Octree.</summary>
  //  /// <param name="id">The id associated with the addition.</param>
  //  /// <param name="addition">The addition.</param>
  //  public void Add(T addition)
  //  {
  //    M x, y, z;
  //    this._locate(addition, out x, out y, out z);

  //    if (
  //      _compare(x, _top.MinX) == Comparison.Less ||
  //      _compare(y, _top.MinY) == Comparison.Less ||
  //      _compare(z, _top.MinZ) == Comparison.Less ||
  //      _compare(x, _top.MaxX) == Comparison.Greater ||
  //      _compare(y, _top.MaxY) == Comparison.Greater ||
  //      _compare(z, _top.MaxZ) == Comparison.Greater)
  //      throw new Error("out of bounds during addition");

  //    this.Add(addition, _top, x, y, z);
  //    this._count++;
  //  }

  //  /// <summary>Recursively adds an item to the octree and returns the node where the addition was placed
  //  /// and adjusts the octree structure as needed.</summary>
  //  private Leaf Add(T addition, Node octreeNode, M x, M y, M z)
  //  {
  //    //Console.WriteLine("Adding " + addition + " to " + octreeNode.MinX + ", " + octreeNode.MinY + ", " + octreeNode.MinZ);

  //    // If the node is a leaf we have reached the bottom of the tree
  //    if (octreeNode is Leaf)
  //    {
  //      Leaf leaf = (Leaf)octreeNode;
  //      if (!leaf.IsFull)
  //      {
  //        // We found a proper leaf, and the leaf has room, just add it
  //        leaf.Add(addition);
  //        return leaf;
  //      }
  //      else
  //      {
  //        // The leaf is full so we need to grow out the tree
  //        Branch parent = octreeNode.Parent;
  //        Branch growth;
  //        if (parent == null)
  //          growth = (Branch)(_top = new Branch(_top.MinX, _top.MinY, _top.MinZ, _top.MaxX, _top.MaxY, _top.MaxZ, null));
  //        else
  //          growth = GrowBranch(parent, this.DetermineChild(parent, x, y, z));
  //        return Add(addition, growth, x, y, z);
  //      }
  //    }
  //    // We are still traversing the tree, determine the next move
  //    else
  //    {
  //      Branch branch = (Branch)octreeNode;
  //      int child = this.DetermineChild(branch, x, y, z);
  //      // If the leaf is null, we must grow one before attempting to add to it
  //      if (branch.Children[child] == null)
  //        return GrowLeaf(branch, child).Add(addition);
  //      return Add(addition, branch.Children[child], x, y, z);
  //    }
  //  }

  //  // Grows a branch on the tree at the desired location
  //  private Branch GrowBranch(Branch branch, int child)
  //  {
  //    // values for the new node
  //    M minX, minY, minZ, maxX, maxY, maxZ;
  //    this.DetermineChildBounds(branch, child, out minX, out minY, out minZ, out maxX, out maxY, out maxZ);
  //    branch.Children[child] = new Branch(minX, minY, minZ, maxX, maxY, maxZ, branch);
  //    //Console.WriteLine("Growing branch " + x + ", " + y + ", " + z);
  //    return (Branch)branch.Children[child];
  //  }

  //  // Grows a leaf on the tree at the desired location
  //  private Leaf GrowLeaf(Branch branch, int child)
  //  {
  //    if (branch.Children[child] != null)
  //      throw new Error("My octree has a glitched, sorry.");
  //    // values for new node
  //    M minX, minY, minZ, maxX, maxY, maxZ;
  //    this.DetermineChildBounds(branch, child, out minX, out minY, out minZ, out maxX, out maxY, out maxZ);
  //    branch.Children[child] = new Leaf(minX, minY, minZ, maxX, maxY, maxZ, branch, _loadFactor);
  //    //Console.WriteLine("Growing leaf " + x + ", " + y + ", " + z);
  //    return (Leaf)branch.Children[child];
  //  }

  //  /// <summary>
  //  /// Determines relative child index.
  //  /// 0: (-x, -y, -z)
  //  /// 1: (-x, -y, +z)
  //  /// 2: (-x, +y, -z)
  //  /// 3: (-x, +y, +z)
  //  /// 4: (+x, -y, -z)
  //  /// 5: (+x, -y, +z)
  //  /// 6: (+x, +y, -z)
  //  /// 7: (+x, +y, +z)
  //  /// </summary>
  //  private int DetermineChild(Node node, M x, M y, M z)
  //  {
  //    Comparison x_comp = _compare(x, _average(node.MinX, node.MaxX));
  //    Comparison y_comp = _compare(y, _average(node.MinY, node.MaxY));
  //    Comparison z_comp = _compare(z, _average(node.MinZ, node.MaxZ));

  //    if (z_comp == Comparison.Less)
  //      if (y_comp == Comparison.Less)
  //        if (x_comp == Comparison.Less)
  //          return 0;
  //        else // (x >= node.X)
  //          return 4;
  //      else // (y >= node.Y)
  //        if (x_comp == Comparison.Less)
  //          return 2;
  //        else // (x >= node.X)
  //          return 6;
  //    else // (z >= node.Z)
  //      if (y_comp == Comparison.Less)
  //        if (x_comp == Comparison.Less)
  //          return 1;
  //        else // (x >= node.X)
  //          return 5;
  //      else // (y >= node.Y)
  //        if (x_comp == Comparison.Less)
  //          return 3;
  //        else  // (x >= node.X)
  //          return 7;
  //  }

  //  /// <summary>
  //  /// Determins the bounds of a child node.
  //  /// 0: (-x, -y, -z)
  //  /// 1: (-x, -y, +z)
  //  /// 2: (-x, +y, -z)
  //  /// 3: (-x, +y, +z)
  //  /// 4: (+x, -y, -z)
  //  /// 5: (+x, -y, +z)
  //  /// 6: (+x, +y, -z)
  //  /// 7: (+x, +y, +z)
  //  /// </summary>
  //  private void DetermineChildBounds(Node node, int child,
  //    out M minX, out M minY, out M minZ, out M maxX, out M maxY, out M maxZ)
  //  {
  //    switch (child)
  //    {
  //      case 0: // 0: (-x, -y, -z)
  //        minX = node.MinX;
  //        minY = node.MinY;
  //        minZ = node.MinZ;
  //        maxX = _average(node.MinX, node.MaxX);
  //        maxY = _average(node.MinY, node.MaxY);
  //        maxZ = _average(node.MinZ, node.MaxZ);
  //        return;
  //      case 1: // 1: (-x, -y, +z)
  //        minX = node.MinX;
  //        minY = node.MinY;
  //        minZ = _average(node.MinZ, node.MaxZ);
  //        maxX = _average(node.MinX, node.MaxX);
  //        maxY = _average(node.MinY, node.MaxY);
  //        maxZ = node.MaxZ;
  //        return;
  //      case 2: // 2: (-x, +y, -z)
  //        minX = node.MinX;
  //        minY = _average(node.MinY, node.MaxY);
  //        minZ = node.MinZ;
  //        maxX = _average(node.MinX, node.MaxX);
  //        maxY = node.MaxY;
  //        maxZ = _average(node.MinZ, node.MaxZ);
  //        return;
  //      case 3: // 3: (-x, +y, +z)
  //        minX = node.MinX;
  //        minY = _average(node.MinY, node.MaxY);
  //        minZ = _average(node.MinZ, node.MaxZ);
  //        maxX = _average(node.MinX, node.MaxX);
  //        maxY = node.MaxY;
  //        maxZ = node.MaxZ;
  //        return;
  //      case 4: // 4: (+x, -y, -z)
  //        minX = _average(node.MinX, node.MaxX);
  //        minY = node.MinY;
  //        minZ = node.MinZ;
  //        maxX = node.MaxX;
  //        maxY = _average(node.MinY, node.MaxY);
  //        maxZ = _average(node.MinZ, node.MaxZ);
  //        return;
  //      case 5: // 5: (+x, -y, +z)
  //        minX = _average(node.MinX, node.MaxX);
  //        minY = node.MinY;
  //        minZ = _average(node.MinZ, node.MaxZ);
  //        maxX = node.MaxX;
  //        maxY = _average(node.MinY, node.MaxY);
  //        maxZ = node.MaxZ;
  //        return;
  //      case 6: // 6: (+x, +y, -z)
  //        minX = _average(node.MinX, node.MaxX);
  //        minY = _average(node.MinY, node.MaxY);
  //        minZ = node.MinZ;
  //        maxX = node.MaxX;
  //        maxY = node.MaxY;
  //        maxZ = _average(node.MinZ, node.MaxZ);
  //        return;
  //      case 7: // 7: (+x, +y, +z)
  //        minX = _average(node.MinX, node.MaxX);
  //        minY = _average(node.MinY, node.MaxY);
  //        minZ = _average(node.MinZ, node.MaxZ);
  //        maxX = node.MaxX;
  //        maxY = node.MaxY;
  //        maxZ = node.MaxZ;
  //        return;
  //      default:
  //        throw new Error("There is a glitch in my octree, sorry...");
  //    }
  //  }

  //  private bool ContainsBounds(Node node, M xMin, M yMin, M zMin, M xMax, M yMax, M zMax)
  //  {
  //    return !(node == null || (
  //      _compare(xMax, node.MinX) == Comparison.Less &&
  //      _compare(yMax, node.MinY) == Comparison.Less &&
  //      _compare(zMax, node.MinZ) == Comparison.Less &&
  //      _compare(xMin, node.MaxX) == Comparison.Greater &&
  //      _compare(yMin, node.MaxY) == Comparison.Greater &&
  //      _compare(zMin, node.MaxZ) == Comparison.Greater));
  //  }

  //  private bool ContainsCoordinate(Node node, M x, M y, M z)
  //  {
  //    return !(node == null || (
  //      _compare(x, node.MinX) == Comparison.Less &&
  //      _compare(y, node.MinY) == Comparison.Less &&
  //      _compare(z, node.MinZ) == Comparison.Less &&
  //      _compare(x, node.MaxX) == Comparison.Greater &&
  //      _compare(y, node.MaxY) == Comparison.Greater &&
  //      _compare(z, node.MaxZ) == Comparison.Greater));
  //  }

  //  private void PluckLeaf(Branch branch, int child)
  //  {
  //    if (!(branch.Children[child] is Leaf) || ((Leaf)branch.Children[child]).Count > 1)
  //      throw new Error("There is a glitch in my octree, sorry.");
  //    branch.Children[child] = null;
  //    while (branch.IsEmpty)
  //    {
  //      ChopBranch(branch.Parent, this.DetermineChild(branch.Parent, branch.MinX, branch.MinY, branch.MinZ));
  //      branch = branch.Parent;
  //    }
  //  }

  //  private void ChopBranch(Branch branch, int child)
  //  {
  //    if (branch.Children[child] == null)
  //      throw new Error("There is a glitch in my octree, sorry...");
  //    branch.Children[child] = null;
  //  }

  //  /// <summary>Iterates through the entire tree and ensures each item is in the proper node.</summary>
  //  public void Update()
  //  {
  //    throw new System.NotImplementedException("Sorry, I'm still working on the update function.");
  //  }

  //  public void Foreach(Foreach<T> function)
  //  {
  //    Foreach(function, _top);
  //  }
  //  private void Foreach(Foreach<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          function(items[i]);
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i]);
  //      }
  //    }
  //  }

  //  public void Foreach(ForeachRef<T> function)
  //  {
  //    Foreach(function, _top);
  //  }
  //  private void Foreach(ForeachRef<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          function(ref items[i]);
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i]);
  //      }
  //    }
  //  }

  //  public ForeachStatus Foreach(ForeachBreak<T> function)
  //  {
  //    return Foreach(function, _top);
  //  }
  //  private ForeachStatus Foreach(ForeachBreak<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          if (function(items[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  public ForeachStatus Foreach(ForeachRefBreak<T> function)
  //  {
  //    return Foreach(function, _top);
  //  }
  //  private ForeachStatus Foreach(ForeachRefBreak<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          if (function(ref items[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  /// <summary>Performs a functional paradigm traversal of the octree with data structure optimization.</summary>
  //  /// <param name="function">The function to perform per iteration.</param>
  //  /// <param name="xMin">The minimum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMin">The minimum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMin">The minimum z of a rectangular prism to query the octree.</param>
  //  /// <param name="xMax">The maximum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMax">The maximum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMax">The maximum z of a rectangular prism to query the octree.</param>
  //  public ForeachStatus Foreach(ForeachBreak<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    return Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private ForeachStatus Foreach(ForeachBreak<T> function, Node node, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (node != null)
  //    {
  //      if (node is Leaf)
  //      {
  //        int count = ((Leaf)node).Count;
  //        T[] items = ((Leaf)node).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          M x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (
  //            _compare(x, node.MinX) == Comparison.Less &&
  //            _compare(y, node.MinY) == Comparison.Less &&
  //            _compare(z, node.MinZ) == Comparison.Less &&
  //            _compare(x, node.MaxX) == Comparison.Greater &&
  //            _compare(y, node.MaxY) == Comparison.Greater &&
  //            _compare(z, node.MaxZ) == Comparison.Greater)
  //            if (function(items[i]) == ForeachStatus.Break)
  //              return ForeachStatus.Break;
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)node;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  /// <summary>Performs a functional paradigm traversal of the octree with data structure optimization.</summary>
  //  /// <param name="function">The function to perform per iteration.</param>
  //  /// <param name="xMin">The minimum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMin">The minimum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMin">The minimum z of a rectangular prism to query the octree.</param>
  //  /// <param name="xMax">The maximum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMax">The maximum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMax">The maximum z of a rectangular prism to query the octree.</param>
  //  public ForeachStatus Foreach(ForeachRefBreak<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    return Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private ForeachStatus Foreach(ForeachRefBreak<T> function, Node node, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (node != null)
  //    {
  //      if (node is Leaf)
  //      {
  //        int count = ((Leaf)node).Count;
  //        T[] items = ((Leaf)node).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          M x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (
  //            _compare(x, node.MinX) == Comparison.Less &&
  //            _compare(y, node.MinY) == Comparison.Less &&
  //            _compare(z, node.MinZ) == Comparison.Less &&
  //            _compare(x, node.MaxX) == Comparison.Greater &&
  //            _compare(y, node.MaxY) == Comparison.Greater &&
  //            _compare(z, node.MaxZ) == Comparison.Greater)
  //            if (function(ref items[i]) == ForeachStatus.Break)
  //              return ForeachStatus.Break;
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)node;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  public void Foreach(Foreach<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private void Foreach(Foreach<T> function, Node node, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (node != null)
  //    {
  //      if (node is Leaf)
  //      {
  //        int count = ((Leaf)node).Count;
  //        T[] items = ((Leaf)node).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          M x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (
  //            _compare(x, node.MinX) == Comparison.Less &&
  //            _compare(y, node.MinY) == Comparison.Less &&
  //            _compare(z, node.MinZ) == Comparison.Less &&
  //            _compare(x, node.MaxX) == Comparison.Greater &&
  //            _compare(y, node.MaxY) == Comparison.Greater &&
  //            _compare(z, node.MaxZ) == Comparison.Greater)
  //            function(items[i]);
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)node;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax);
  //      }
  //    }
  //  }

  //  public void Foreach(ForeachRef<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private void Foreach(ForeachRef<T> function, Node node, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (node != null)
  //    {
  //      if (node is Leaf)
  //      {
  //        int count = ((Leaf)node).Count;
  //        T[] items = ((Leaf)node).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          M x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (
  //            _compare(x, node.MinX) == Comparison.Less &&
  //            _compare(y, node.MinY) == Comparison.Less &&
  //            _compare(z, node.MinZ) == Comparison.Less &&
  //            _compare(x, node.MaxX) == Comparison.Greater &&
  //            _compare(y, node.MaxY) == Comparison.Greater &&
  //            _compare(z, node.MaxZ) == Comparison.Greater)
  //            function(ref items[i]);
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)node;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax);
  //      }
  //    }
  //  }

  //  public T[] ToArray()
  //  {
  //    int index = 0;
  //    T[] array = new T[this._count];
  //    this.Foreach((T entry) => { array[index++] = entry; });
  //    return array;

  //    //int finalIndex;
  //    //T[] array = new T[_count];
  //    //ToArray(_top, array, 0, out finalIndex);
  //    //if (array.Length != finalIndex)
  //    //  throw new Error("There is a glitch in my octree, sorry...");
  //    //return array;
  //  }
  //  private void ToArray(Node octreeNode, T[] array, int entryIndex, out int returnIndex)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        returnIndex = entryIndex;
  //        foreach (T item in ((Leaf)octreeNode).Contents)
  //          array[returnIndex++] = item;
  //      }
  //      else
  //      {
  //        // The current node is a branch
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          ToArray(branch.Children[i], array, entryIndex, out entryIndex);
  //        returnIndex = entryIndex;
  //      }
  //    }
  //    else
  //      returnIndex = entryIndex;
  //  }

  //  #region Structure<Type>

  //  System.Collections.IEnumerator
  //    System.Collections.IEnumerable.GetEnumerator()
  //  {
  //    T[] array = this.ToArray();
  //    return array.GetEnumerator();
  //  }

  //  /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
  //  System.Collections.Generic.IEnumerator<T>
  //    System.Collections.Generic.IEnumerable<T>.GetEnumerator()
  //  {
  //    T[] array = this.ToArray();
  //    return ((System.Collections.Generic.IEnumerable<T>)array).GetEnumerator();
  //  }

  //  /// <summary>Gets the current memory imprint of this structure in bytes.</summary>
  //  /// <remarks>Returns long.MaxValue on overflow.</remarks>
  //  public int SizeOf { get { throw new System.NotImplementedException(); } }

  //  /// <summary>Creates a shallow clone of this data structure.</summary>
  //  /// <returns>A shallow clone of this data structure.</returns>
  //  public Structure<T> Clone()
  //  {
  //    throw new System.NotImplementedException();
  //  }

  //  #endregion

  //  /// <summary>This is used for throwing OcTree exceptions only to make debugging faster.</summary>
  //  private class Error : Structure.Error
  //  {
  //    public Error(string message) : base(message) { }
  //  }
  //}

  ///// <summary>Stores objects efficiently in 3-Dimensional space by x, y, and z coordinates.</summary>
  ///// <typeparam name="T">The generice type of items to be stored in this octree.</typeparam>
  //[System.Serializable]
  //public class Octree_Linked_Center<T> : Octree<T>
  //{
  //  /// <summary>Represents a single node of the octree. Includes references both upwards and
  //  /// downwards the tree.</summary>
  //  private abstract class Node
  //  {
  //    private float _x, _y, _z, _scale;
  //    private Branch _parent;

  //    internal float X { get { return _x; } }
  //    internal float Y { get { return _y; } }
  //    internal float Z { get { return _z; } }
  //    internal float Scale { get { return _scale; } }
  //    internal Branch Parent { get { return _parent; } }

  //    internal Node(float x, float y, float z, float scale, Branch parent)
  //    {
  //      _x = x;
  //      _y = y;
  //      _z = z;
  //      _scale = scale;
  //      _parent = parent;
  //    }
  //  }

  //  /// <summary>Represents a single node of the octree. Includes references both upwards and
  //  /// downwards the tree.</summary>
  //  private class Leaf : Node
  //  {
  //    private T[] _contents;
  //    private int _count;

  //    internal T[] Contents { get { return _contents; } }
  //    internal int Count { get { return _count; } set { _count = value; } }
  //    internal bool IsFull { get { return _count == _contents.Length; } }

  //    internal Leaf(float x, float y, float z, float scale, Branch parent, int branchFactor)
  //      : base(x, y, z, scale, parent)
  //    { _contents = new T[branchFactor]; }

  //    internal Leaf Add(T addition)
  //    {
  //      System.Console.WriteLine("Placing " + addition + ", in " + this.X + ", " + this.Y + ", " + this.Z);
  //      if (_count == _contents.Length)
  //        throw new Error("There is a glitch in my octree, sorry...");
  //      _contents[_count++] = addition;
  //      return this;
  //    }
  //  }

  //  /// <summary>Represents a single node of the octree. Includes references both upwards and
  //  /// downwards the tree.</summary>
  //  private class Branch : Node
  //  {
  //    public Node[] _children;

  //    public Node[] Children { get { return this._children; } }

  //    internal bool IsEmpty
  //    {
  //      get
  //      {
  //        foreach (Node child in this._children)
  //          if (child != null)
  //            return false;
  //        return true;
  //      }
  //    }

  //    internal Branch(float x, float y, float z, float scale, Branch parent)
  //      : base(x, y, z, scale, parent)
  //    {
  //      this._children = new Node[8];
  //    }
  //  }

  //  public delegate void Locate<Type>(Type item, out double x, out double y, out double z);
  //  private Locate<T> _locate;
  //  private int _loadFactor;
  //  private int _count;
  //  private Node _top;

  //  public int Count { get { return _count; } }
  //  public bool IsEmpty { get { return _count == 0; } }

  //  /// <summary>Creates an octree for three dimensional space partitioning.</summary>
  //  /// <param name="x">The x coordinate of the center of the octree.</param>
  //  /// <param name="y">The y coordinate of the center of the octree.</param>
  //  /// <param name="z">The z coordinate of the center of the octree.</param>
  //  /// <param name="scale">How far the tree expands along each dimension.</param>
  //  /// <param name="loadFactor">The maximum items per octree node before expansion.</param>
  //  public Octree_Linked_Center(float x, float y, float z, float scale, int loadFactor, Locate<T> locate)
  //  {
  //    this._loadFactor = loadFactor;
  //    this._top = new Leaf(x, y, z, scale, null, _loadFactor);
  //    this._count = 0;
  //    this._locate = locate;
  //  }

  //  /// <summary>Adds an item to the Octree.</summary>
  //  /// <param name="id">The id associated with the addition.</param>
  //  /// <param name="addition">The addition.</param>
  //  public void Add(T addition)
  //  {
  //    this.Add(addition, _top);
  //    this._count++;
  //  }

  //  /// <summary>Recursively adds an item to the octree and returns the node where the addition was placed
  //  /// and adjusts the octree structure as needed.</summary>
  //  private Leaf Add(T addition, Node octreeNode)
  //  {
  //    System.Console.WriteLine("Adding " + addition + " to " + octreeNode.X + ", " + octreeNode.Y + ", " + octreeNode.Z);

  //    // If the node is a leaf we have reached the bottom of the tree
  //    if (octreeNode is Leaf)
  //    {
  //      Leaf leaf = (Leaf)octreeNode;
  //      if (!leaf.IsFull)
  //      {
  //        // We found a proper leaf, and the leaf has room, just add it
  //        leaf.Add(addition);
  //        return leaf;
  //      }
  //      else
  //      {
  //        // The leaf is full so we need to grow out the tree
  //        Branch parent = octreeNode.Parent;
  //        Branch growth;
  //        if (parent == null)
  //          growth = (Branch)(_top = new Branch(_top.X, _top.Y, _top.Z, _top.Scale, null));
  //        else
  //        {
  //          double x, y, z;
  //          this._locate(addition, out x, out y, out z);
  //          growth = GrowBranch(parent, this.DetermineChild(parent, x, y, z));
  //        }
  //        return Add(addition, growth);
  //      }
  //    }
  //    // We are still traversing the tree, determine the next move
  //    else
  //    {
  //      Branch branch = (Branch)octreeNode;
  //      double x, y, z;
  //      this._locate(addition, out x, out y, out z);
  //      int child = this.DetermineChild(branch, x, y, z);
  //      // If the leaf is null, we must grow one before attempting to add to it
  //      if (branch.Children[child] == null)
  //        return GrowLeaf(branch, child).Add(addition);
  //      return Add(addition, branch.Children[child]);
  //    }
  //  }

  //  // Grows a branch on the tree at the desired location
  //  private Branch GrowBranch(Branch branch, int child)
  //  {
  //    // values for the new node
  //    float x, y, z, scale;
  //    this.DetermineChildBounds(branch, child, out x, out y, out z, out scale);
  //    branch.Children[child] = new Branch(x, y, z, scale, branch);
  //    System.Console.WriteLine("Growing branch " + x + ", " + y + ", " + z);
  //    return (Branch)branch.Children[child];
  //  }

  //  // Grows a leaf on the tree at the desired location
  //  private Leaf GrowLeaf(Branch branch, int child)
  //  {
  //    if (branch.Children[child] != null)
  //      throw new Error("My octree has a glitched, sorry.");
  //    // values for new node
  //    float x, y, z, scale;
  //    this.DetermineChildBounds(branch, child, out x, out y, out z, out scale);
  //    branch.Children[child] = new Leaf(x, y, z, scale, branch, _loadFactor);
  //    System.Console.WriteLine("Growing leaf " + x + ", " + y + ", " + z);
  //    return (Leaf)branch.Children[child];
  //  }

  //  /// <summary>
  //  /// Determines relative child index.
  //  /// 0: (-x, -y, -z)
  //  /// 1: (-x, -y, +z)
  //  /// 2: (-x, +y, -z)
  //  /// 3: (-x, +y, +z)
  //  /// 4: (+x, -y, -z)
  //  /// 5: (+x, -y, +z)
  //  /// 6: (+x, +y, -z)
  //  /// 7: (+x, +y, +z)
  //  /// </summary>
  //  private int DetermineChild(Node node, double x, double y, double z)
  //  {
  //    if (z < node.Z)
  //      if (y < node.Y)
  //        if (x < node.X)
  //          return 0;
  //        else // (x >= node.X)
  //          return 4;
  //      else // (y >= node.Y)
  //        if (x < node.X)
  //          return 2;
  //        else // (x >= node.X)
  //          return 6;
  //    else // (z >= node.Z)
  //      if (y < node.Y)
  //        if (x < node.X)
  //          return 1;
  //        else // (x >= node.X)
  //          return 5;
  //      else // (y >= node.Y)
  //        if (x < node.X)
  //          return 3;
  //        else  // (x >= node.X)
  //          return 7;
  //  }

  //  /// <summary>Determins the bounds of a child node.</summary>
  //  private void DetermineChildBounds(Node node, int child, out float x, out float y, out float z, out float scale)
  //  {
  //    float halfScale = node.Scale * 0.5f;
  //    switch (child)
  //    {
  //      case 0:
  //        x = node.X - halfScale;
  //        y = node.Y - halfScale;
  //        z = node.Z - halfScale;
  //        scale = halfScale;
  //        return;
  //      case 1:
  //        x = node.X - halfScale;
  //        y = node.Y - halfScale;
  //        z = node.Z + halfScale;
  //        scale = halfScale;
  //        return;
  //      case 2:
  //        x = node.X - halfScale;
  //        y = node.Y + halfScale;
  //        z = node.Z - halfScale;
  //        scale = halfScale;
  //        return;
  //      case 3:
  //        x = node.X - halfScale;
  //        y = node.Y + halfScale;
  //        z = node.Z + halfScale;
  //        scale = halfScale;
  //        return;
  //      case 4:
  //        x = node.X + halfScale;
  //        y = node.Y - halfScale;
  //        z = node.Z - halfScale;
  //        scale = halfScale;
  //        return;
  //      case 5:
  //        x = node.X + halfScale;
  //        y = node.Y - halfScale;
  //        z = node.Z + halfScale;
  //        scale = halfScale;
  //        return;
  //      case 6:
  //        x = node.X + halfScale;
  //        y = node.Y + halfScale;
  //        z = node.Z - halfScale;
  //        scale = halfScale;
  //        return;
  //      case 7:
  //        x = node.X + halfScale;
  //        y = node.Y + halfScale;
  //        z = node.Z + halfScale;
  //        scale = halfScale;
  //        return;
  //      default:
  //        throw new Error("There is a glitch in my octree, sorry...");
  //    }
  //  }

  //  private bool ContainsBounds(Node node, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    return !(node == null ||
  //        xMax < node.X - node.Scale || xMin > node.X + node.Scale ||
  //        yMax < node.Y - node.Scale || yMin > node.Y + node.Scale ||
  //        zMax < node.Z - node.Scale || zMin > node.Z + node.Scale);
  //  }

  //  private bool ContainsCoordinate(Node node, float x, float y, float z)
  //  {
  //    return !(node == null ||
  //        x < node.X - node.Scale || x > node.X + node.Scale ||
  //        y < node.Y - node.Scale || y > node.Y + node.Scale ||
  //        z < node.Z - node.Scale || z > node.Z + node.Scale);
  //  }

  //  private void PluckLeaf(Branch branch, int child)
  //  {
  //    if (!(branch.Children[child] is Leaf) || ((Leaf)branch.Children[child]).Count > 1)
  //      throw new Error("There is a glitch in my octree, sorry.");
  //    branch.Children[child] = null;
  //    while (branch.IsEmpty)
  //    {
  //      ChopBranch(branch.Parent, this.DetermineChild(branch.Parent, branch.X, branch.Y, branch.Z));
  //      branch = branch.Parent;
  //    }
  //  }

  //  private void ChopBranch(Branch branch, int child)
  //  {
  //    if (branch.Children[child] == null)
  //      throw new Error("There is a glitch in my octree, sorry...");
  //    branch.Children[child] = null;
  //  }

  //  /// <summary>Iterates through the entire tree and ensures each item is in the proper node.</summary>
  //  public void Update()
  //  {
  //    throw new System.NotImplementedException("Sorry, I'm still working on the update function.");
  //  }

  //  public void Foreach(Foreach<T> function)
  //  {
  //    Foreach(function, _top);
  //  }
  //  private void Foreach(Foreach<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          function(items[i]);
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i]);
  //      }
  //    }
  //  }

  //  public void Foreach(ForeachRef<T> function)
  //  {
  //    Foreach(function, _top);
  //  }
  //  private void Foreach(ForeachRef<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          function(ref items[i]);
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i]);
  //      }
  //    }
  //  }

  //  public ForeachStatus Foreach(ForeachBreak<T> function)
  //  {
  //    return Foreach(function, _top);
  //  }
  //  private ForeachStatus Foreach(ForeachBreak<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          if (function(items[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  public ForeachStatus Foreach(ForeachRefBreak<T> function)
  //  {
  //    return Foreach(function, _top);
  //  }
  //  private ForeachStatus Foreach(ForeachRefBreak<T> function, Node octreeNode)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //          if (function(ref items[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i]) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  /// <summary>Performs a functional paradigm traversal of the octree with data structure optimization.</summary>
  //  /// <param name="function">The function to perform per iteration.</param>
  //  /// <param name="xMin">The minimum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMin">The minimum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMin">The minimum z of a rectangular prism to query the octree.</param>
  //  /// <param name="xMax">The maximum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMax">The maximum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMax">The maximum z of a rectangular prism to query the octree.</param>
  //  public ForeachStatus Foreach(ForeachBreak<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    return Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private ForeachStatus Foreach(ForeachBreak<T> function, Node octreeNode, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          double x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (items[i] != null &&
  //            x > xMin && x < xMax &&
  //            y > yMin && y < yMax &&
  //            z > zMin && z < zMax)
  //              if (function(items[i]) == ForeachStatus.Break)
  //                return ForeachStatus.Break;
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  /// <summary>Performs a functional paradigm traversal of the octree with data structure optimization.</summary>
  //  /// <param name="function">The function to perform per iteration.</param>
  //  /// <param name="xMin">The minimum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMin">The minimum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMin">The minimum z of a rectangular prism to query the octree.</param>
  //  /// <param name="xMax">The maximum x of a rectangular prism to query the octree.</param>
  //  /// <param name="yMax">The maximum y of a rectangular prism to query the octree.</param>
  //  /// <param name="zMax">The maximum z of a rectangular prism to query the octree.</param>
  //  public ForeachStatus Foreach(ForeachRefBreak<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    return Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private ForeachStatus Foreach(ForeachRefBreak<T> function, Node octreeNode, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          double x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (items[i] != null &&
  //            x > xMin && x < xMax &&
  //            y > yMin && y < yMax &&
  //            z > zMin && z < zMax)
  //            if (function(ref items[i]) == ForeachStatus.Break)
  //              return ForeachStatus.Break;
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          if (Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax) == ForeachStatus.Break)
  //            return ForeachStatus.Break;
  //        return ForeachStatus.Continue;
  //      }
  //    }
  //    return ForeachStatus.Continue;
  //  }

  //  public void Foreach(Foreach<T> function, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    Foreach(function, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  //  }
  //  private void Foreach(Foreach<T> function, Node octreeNode, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        int count = ((Leaf)octreeNode).Count;
  //        T[] items = ((Leaf)octreeNode).Contents;
  //        for (int i = 0; i < count; i++)
  //        {
  //          double x, y, z;
  //          this._locate(items[i], out x, out y, out z);
  //          if (items[i] != null &&
  //              x > xMin && x < xMax &&
  //              y > yMin && y < yMax &&
  //              z > zMin && z < zMax)
  //            function(items[i]);
  //        }
  //      }
  //      else
  //      {
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          Foreach(function, branch.Children[i], xMin, yMin, zMin, xMax, yMax, zMax);
  //      }
  //    }
  //  }

  //  public T[] ToArray()
  //  {
  //    int finalIndex;
  //    T[] array = new T[_count];
  //    ToArray(_top, array, 0, out finalIndex);
  //    if (array.Length != finalIndex)
  //      throw new Error("There is a glitch in my octree, sorry...");
  //    return array;
  //  }
  //  private void ToArray(Node octreeNode, T[] array, int entryIndex, out int returnIndex)
  //  {
  //    if (octreeNode != null)
  //    {
  //      if (octreeNode is Leaf)
  //      {
  //        returnIndex = entryIndex;
  //        foreach (T item in ((Leaf)octreeNode).Contents)
  //          array[returnIndex++] = item;
  //      }
  //      else
  //      {
  //        // The current node is a branch
  //        Branch branch = (Branch)octreeNode;
  //        for (int i = 0; i < 8; i++)
  //          ToArray(branch.Children[i], array, entryIndex, out entryIndex);
  //        returnIndex = entryIndex;
  //      }
  //    }
  //    else
  //      returnIndex = entryIndex;
  //  }

  //  #region Structure<Type>

  //  System.Collections.IEnumerator
  //    System.Collections.IEnumerable.GetEnumerator()
  //  {
  //    T[] array = this.ToArray();
  //    return array.GetEnumerator();
  //  }

  //  /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
  //  System.Collections.Generic.IEnumerator<T>
  //    System.Collections.Generic.IEnumerable<T>.GetEnumerator()
  //  {
  //    T[] array = this.ToArray();
  //    return ((System.Collections.Generic.IEnumerable<T>)array).GetEnumerator();
  //  }

  //  /// <summary>Gets the current memory imprint of this structure in bytes.</summary>
  //  /// <remarks>Returns long.MaxValue on overflow.</remarks>
  //  public int SizeOf { get { throw new System.NotImplementedException(); } }

  //  /// <summary>Checks to see if a given object is in this data structure.</summary>
  //  /// <param name="item">The item to check for.</param>
  //  /// <param name="compare">Delegate representing comparison technique.</param>
  //  /// <returns>true if the item is in this structure; false if not.</returns>
  //  public bool Contains(T item, Compare<T> compare)
  //  {
  //    throw new System.NotImplementedException();
  //  }

  //  /// <summary>Checks to see if a given object is in this data structure.</summary>
  //  /// <typeparam name="Key">The type of the key to check for.</typeparam>
  //  /// <param name="key">The key to check for.</param>
  //  /// <param name="compare">Delegate representing comparison technique.</param>
  //  /// <returns>true if the item is in this structure; false if not.</returns>
  //  public bool Contains<Key>(Key key, Compare<T, Key> compare)
  //  {
  //    throw new System.NotImplementedException();
  //  }

  //  /// <summary>Creates a shallow clone of this data structure.</summary>
  //  /// <returns>A shallow clone of this data structure.</returns>
  //  public Structure<T> Clone()
  //  {
  //    throw new System.NotImplementedException();
  //  }

  //  #endregion

  //  /// <summary>This is used for throwing OcTree exceptions only to make debugging faster.</summary>
  //  private class Error : Structure.Error
  //  {
  //    public Error(string message) : base(message) { }
  //  }
  //}

  //#region OctreeLinked

  ////[Serializable]
  ////public class OctreeLinked<Type> : Octree<Type>
  ////  where Type : IOctreeEntry
  ////{
  ////  private Func<Type, Type, int> _comparisonFunction;
  ////  private Func<OctreeLinkedReference, Type, int> _referenceComparison;

  ////  #region OctreeLinkedNode

  ////  /// <summary>Represents a single node of the octree. Includes references both upwards and
  ////  /// downwards the tree.</summary>
  ////  private abstract class OctreeLinkedNode
  ////  {
  ////    private float _x, _y, _z, _scale;
  ////    private OctreeLinkedBranch _parent;

  ////    internal float X { get { return _x; } }
  ////    internal float Y { get { return _y; } }
  ////    internal float Z { get { return _z; } }
  ////    internal float Scale { get { return _scale; } }
  ////    internal OctreeLinkedBranch Parent { get { return _parent; } }

  ////    internal OctreeLinkedNode(float x, float y, float z, float scale, OctreeLinkedBranch parent)
  ////    {
  ////      _x = x;
  ////      _y = y;
  ////      _z = z;
  ////      _scale = scale;
  ////      _parent = parent;
  ////    }

  ////    /// <summary>Finds the child index relative to "this" node given x, y, and z coordinates.</summary>
  ////    static internal int DetermineChild(OctreeLinkedNode node, float x, float y, float z)
  ////    {
  ////      // Finds the child given an x, y, and z
  ////      // Possible child (all): 0, 1, 2, 3, 4, 5, 6, 7
  ////      if (z < node.Z)
  ////      {
  ////        // Possible child: 0, 2, 4, 6
  ////        if (y < node.Y)
  ////          // Possible child: 0, 4
  ////          if (x < node.X) return 0;
  ////          else return 4;
  ////        else
  ////          // Possible child: 2, 6, 
  ////          if (x < node.X) return 2;
  ////          else return 6;
  ////      }
  ////      else
  ////      {
  ////        // Possible child: 1, 3, 5, 7
  ////        if (y < node.Y)
  ////          // Possible child: 1, 5
  ////          if (x < node.X) return 1;
  ////          else return 5;
  ////        else
  ////          // Possible child: 3, 7 
  ////          if (x < node.X) return 3;
  ////          else return 7;
  ////      }
  ////    }

  ////    /// <summary>Determins the bounds of a child node.</summary>
  ////    static internal void DetermineChildBounds(OctreeLinkedNode node, int child, out float x, out float y, out float z, out float scale)
  ////    {
  ////      float halfScale = node.Scale * .5f;
  ////      switch (child)
  ////      {
  ////        case 0: x = node.X - halfScale; y = node.Y - halfScale; z = node.Z - halfScale; scale = halfScale; return;
  ////        case 1: x = node.X - halfScale; y = node.Y - halfScale; z = node.Z + halfScale; scale = halfScale; return;
  ////        case 2: x = node.X - halfScale; y = node.Y + halfScale; z = node.Z - halfScale; scale = halfScale; return;
  ////        case 3: x = node.X - halfScale; y = node.Y + halfScale; z = node.Z + halfScale; scale = halfScale; return;
  ////        case 4: x = node.X + halfScale; y = node.Y - halfScale; z = node.Z - halfScale; scale = halfScale; return;
  ////        case 5: x = node.X + halfScale; y = node.Y - halfScale; z = node.Z + halfScale; scale = halfScale; return;
  ////        case 6: x = node.X + halfScale; y = node.Y + halfScale; z = node.Z - halfScale; scale = halfScale; return;
  ////        case 7: x = node.X + halfScale; y = node.Y + halfScale; z = node.Z + halfScale; scale = halfScale; return;
  ////        default: throw new OctreeLinkedException("There is a glitch in my octree, sorry...");
  ////      }
  ////    }

  ////    static internal bool ContainsBounds(OctreeLinkedNode node, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  ////    {
  ////      return !(node == null ||
  ////          xMax < node.X - node.Scale || xMin > node.X + node.Scale ||
  ////          yMax < node.Y - node.Scale || yMin > node.Y + node.Scale ||
  ////          zMax < node.Z - node.Scale || zMin > node.Z + node.Scale);
  ////    }

  ////    static internal bool ContainsCoordinate(OctreeLinkedNode node, float x, float y, float z)
  ////    {
  ////      return !(node == null ||
  ////          x < node.X - node.Scale || x > node.X + node.Scale ||
  ////          y < node.Y - node.Scale || y > node.Y + node.Scale ||
  ////          z < node.Z - node.Scale || z > node.Z + node.Scale);
  ////    }
  ////  }

  ////  #endregion

  ////  #region OctreeLinkedLeaf

  ////  /// <summary>Represents a single node of the octree. Includes references both upwards and
  ////  /// downwards the tree.</summary>
  ////  private class OctreeLinkedLeaf : OctreeLinkedNode
  ////  {
  ////    //private OctreeEntry[] _contents;
  ////    private Type[] _contents;
  ////    private int _count;

  ////    //internal OctreeEntry[] Contents { get { return _contents; } }
  ////    internal Type[] Contents { get { return _contents; } }
  ////    internal int Count { get { return _count; } set { _count = value; } }
  ////    internal bool IsFull { get { return _count == _contents.Length; } }

  ////    internal OctreeLinkedLeaf(float x, float y, float z, float scale, OctreeLinkedBranch parent, int branchFactor)
  ////      : base(x, y, z, scale, parent)
  ////    { _contents = new Type[branchFactor]; }

  ////    internal OctreeLinkedLeaf Add(Type addition)
  ////    {
  ////      if (_count == _contents.Length)
  ////        throw new OctreeLinkedException("There is a glitch in my octree, sorry...");
  ////      _contents[_count++] = addition;
  ////      return this;
  ////    }
  ////  }

  ////  #endregion

  ////  #region OctreelinkedBranch

  ////  /// <summary>Represents a single node of the octree. Includes references both upwards and
  ////  /// downwards the tree.</summary>
  ////  private class OctreeLinkedBranch : OctreeLinkedNode
  ////  {
  ////    // The children are indexed as follows (relative to this node's center):
  ////    // 0: (-x, -y, -z)   1: (-x, -y, z)   2: (-x, y, -z)   3: (-x, y, z)
  ////    // 4: (x, -y, -z)   5: (x, -y, z)   6: (x, y, -z)   7: (x, y, z)
  ////    //private OctreeLinkedNode[] _children;

  ////    private OctreeLinkedNode _child0;
  ////    private OctreeLinkedNode _child1;
  ////    private OctreeLinkedNode _child2;
  ////    private OctreeLinkedNode _child3;
  ////    private OctreeLinkedNode _child4;
  ////    private OctreeLinkedNode _child5;
  ////    private OctreeLinkedNode _child6;
  ////    private OctreeLinkedNode _child7;

  ////    public OctreeLinkedNode Child0 { get { return _child0; } }
  ////    public OctreeLinkedNode Child1 { get { return _child1; } }
  ////    public OctreeLinkedNode Child2 { get { return _child2; } }
  ////    public OctreeLinkedNode Child3 { get { return _child3; } }
  ////    public OctreeLinkedNode Child4 { get { return _child4; } }
  ////    public OctreeLinkedNode Child5 { get { return _child5; } }
  ////    public OctreeLinkedNode Child6 { get { return _child6; } }
  ////    public OctreeLinkedNode Child7 { get { return _child7; } }

  ////    public OctreeLinkedNode this[int index]
  ////    {
  ////      get
  ////      {
  ////        switch (index)
  ////        {
  ////          case 0: return _child0;
  ////          case 1: return _child1;
  ////          case 2: return _child2;
  ////          case 3: return _child3;
  ////          case 4: return _child4;
  ////          case 5: return _child5;
  ////          case 6: return _child6;
  ////          case 7: return _child7;
  ////          default: throw new OctreeLinkedException("index out of bounds.");
  ////        }
  ////      }
  ////      set
  ////      {
  ////        switch (index)
  ////        {
  ////          case 0: _child0 = value; break;
  ////          case 1: _child1 = value; break;
  ////          case 2: _child2 = value; break;
  ////          case 3: _child3 = value; break;
  ////          case 4: _child4 = value; break;
  ////          case 5: _child5 = value; break;
  ////          case 6: _child6 = value; break;
  ////          case 7: _child7 = value; break;
  ////          default: throw new OctreeLinkedException("index out of bounds.");
  ////        }
  ////      }
  ////    }

  ////    //internal OctreeLinkedNode[] Children { get { return _children; } }

  ////    internal bool IsEmpty
  ////    {
  ////      get
  ////      {
  ////        //return _children[0] == null && _children[1] == null && _children[2] == null
  ////        //  && _children[3] == null && _children[4] == null && _children[5] == null
  ////        //  && _children[6] == null && _children[7] == null;
  ////        return _child0 == null && _child1 == null && _child2 == null
  ////          && _child3 == null && _child4 == null && _child5== null
  ////          && _child6 == null && _child7 == null;
  ////      }
  ////    }

  ////    internal OctreeLinkedBranch(float x, float y, float z, float scale, OctreeLinkedBranch parent)
  ////      : base(x, y, z, scale, parent)
  ////    {
  ////      //_children = new OctreeLinkedNode[8];
  ////    }
  ////  }

  ////  #endregion

  ////  #region OctreeLinkedReference

  ////  private class OctreeLinkedReference
  ////  {
  ////    private Type _value;
  ////    private OctreeLinkedLeaf _leaf;

  ////    internal Type Value { get { return _value; } set { _value = value; } }
  ////    internal OctreeLinkedLeaf Leaf { get { return _leaf; } set { _leaf = value; } }

  ////    internal OctreeLinkedReference(Type value, OctreeLinkedLeaf leaf) { _value = value; _leaf = leaf; }
  ////  }

  ////  #endregion

  ////  private int _branchFactor;
  ////  private int _count;
  ////  private AvlTree<OctreeLinkedReference> _referenceDatabase;
  ////  private OctreeLinkedNode _top;

  ////  private object _lock;
  ////  private int _readers;
  ////  private int _writers;

  ////  public int Count { get { return _count; } }
  ////  public bool IsEmpty { get { return _count == 0; } }

  ////  /// <summary>Creates an octree for three dimensional space partitioning.</summary>
  ////  /// <param name="x">The x coordinate of the center of the octree.</param>
  ////  /// <param name="y">The y coordinate of the center of the octree.</param>
  ////  /// <param name="z">The z coordinate of the center of the octree.</param>
  ////  /// <param name="scale">How far the tree expands along each dimension.</param>
  ////  /// <param name="branchFactor">The maximum items per octree node before expansion.</param>
  ////  public OctreeLinked(float x, float y, float z, float scale, int branchFactor,
  ////    Func<Type, Type, int> comparisonFunction)
  ////  {
  ////    _branchFactor = branchFactor;
  ////    _top = new OctreeLinkedLeaf(x, y, z, scale, null, _branchFactor);
  ////    _count = 0;

  ////    _comparisonFunction = comparisonFunction;

  ////    _referenceComparison =
  ////      (OctreeLinkedReference left, Type right) =>
  ////      { return comparisonFunction(left.Value, right); };

  ////    Func<OctreeLinkedReference, OctreeLinkedReference, int> octreeReferenceComparison =
  ////      (OctreeLinkedReference left, OctreeLinkedReference right) =>
  ////      { return comparisonFunction(left.Value, right.Value); };
  ////    _referenceDatabase = null;// new AvlTreeLinked<OctreeLinkedReference>(octreeReferenceComparison);
  ////  }

  ////  /// <summary>Adds an item to the Octree.</summary>
  ////  /// <param name="id">The id associated with the addition.</param>
  ////  /// <param name="addition">The addition.</param>
  ////  /// <param name="x">The x coordinate of the addition's location.</param>
  ////  /// <param name="y">The y coordinate of the addition's location.</param>
  ////  /// <param name="z">The z coordinate of the addition's location.</param>
  ////  public void Add(Type addition)
  ////  {
  ////    _referenceDatabase.Add(new OctreeLinkedReference(addition, Add(addition, _top)));
  ////    _count++;
  ////  }

  ////  /// <summary>Recursively adds an item to the octree and returns the node where the addition was placed
  ////  /// and adjusts the octree structure as needed.</summary>
  ////  private OctreeLinkedLeaf Add(Type addition, OctreeLinkedNode octreeNode)
  ////  {
  ////    // If the node is a leaf we have reached the bottom of the tree
  ////    if (octreeNode is OctreeLinkedLeaf)
  ////    {
  ////      OctreeLinkedLeaf leaf = (OctreeLinkedLeaf)octreeNode;
  ////      if (!leaf.IsFull)
  ////      {
  ////        // We found a proper leaf, and the leaf has room, just add it
  ////        leaf.Add(addition);
  ////        return leaf;
  ////      }
  ////      else
  ////      {
  ////        // The leaf is full so we need to grow out the tree
  ////        OctreeLinkedBranch parent = octreeNode.Parent;
  ////        OctreeLinkedBranch growth;
  ////        if (parent == null)
  ////          growth = (OctreeLinkedBranch)(_top = new OctreeLinkedBranch(_top.X, _top.Y, _top.Z, _top.Scale, null));
  ////        else
  ////          growth = GrowBranch(parent, OctreeLinkedNode.DetermineChild(parent, addition.Position.X, addition.Position.Y, addition.Position.Z));
  ////        //foreach (Type entry in leaf.Contents)
  ////        //  _referenceDatabase.Get<Type>(entry, _referenceComparison).Leaf = Add(entry, growth);
  ////        return Add(addition, growth);
  ////      }
  ////    }
  ////    // We are still traversing the tree, determine the next move
  ////    else
  ////    {
  ////      OctreeLinkedBranch branch = (OctreeLinkedBranch)octreeNode;
  ////      int child = OctreeLinkedNode.DetermineChild(branch, addition.Position.X, addition.Position.Y, addition.Position.Z);
  ////      // If the leaf is null, we must grow one before attempting to add to it
  ////      if (branch[child] == null)
  ////        return GrowLeaf(branch, child).Add(addition);
  ////      return Add(addition, branch[child]);
  ////    }
  ////  }

  ////  // Grows a branch on the tree at the desired location
  ////  private OctreeLinkedBranch GrowBranch(OctreeLinkedBranch branch, int child)
  ////  {
  ////    // values for the new node
  ////    float x, y, z, scale;
  ////    OctreeLinkedNode.DetermineChildBounds(branch, child, out x, out y, out z, out scale);
  ////    branch[child] = new OctreeLinkedBranch(x, y, z, scale, branch);
  ////    return (OctreeLinkedBranch)branch[child];
  ////  }

  ////  // Grows a leaf on the tree at the desired location
  ////  private OctreeLinkedLeaf GrowLeaf(OctreeLinkedBranch branch, int child)
  ////  {
  ////    if (branch[child] != null)
  ////      throw new OctreeLinkedException("My octree has a glitched, sorry.");
  ////    // values for new node
  ////    float x, y, z, scale;
  ////    OctreeLinkedNode.DetermineChildBounds(branch, child, out x, out y, out z, out scale);
  ////    branch[child] = new OctreeLinkedLeaf(x, y, z, scale, branch, _branchFactor);
  ////    return (OctreeLinkedLeaf)branch[child];
  ////  }

  ////  /// <summary>Removes an item from the octree by the id that was assigned to it.</summary>
  ////  /// <param name="id">The string id of the removal that was given to the item when it was added.</param>
  ////  public void Remove(Type key)
  ////  {
  ////    throw new NotImplementedException();
  ////    //Remove(key, _referenceDatabase.Get<Type>(key, _referenceComparison).Leaf);
  ////    //_referenceDatabase.Remove<Type>(key, _referenceComparison);
  ////    _count--;
  ////  }

  ////  private void Remove(Type key, OctreeLinkedLeaf leaf)
  ////  {
  ////    if (leaf.Count > 1)
  ////    {
  ////      Type[] contents = leaf.Contents;
  ////      for (int i = 0; i < leaf.Count; i++)
  ////        if (_comparisonFunction(contents[i], key) == 0)
  ////        {
  ////          Type temp = contents[_count - 1];
  ////          contents[_count - 1] = contents[i];
  ////          contents[i] = temp;
  ////          break;
  ////        }
  ////    }
  ////    else PluckLeaf(leaf.Parent, OctreeLinkedNode.DetermineChild(leaf.Parent, leaf.X, leaf.Y, leaf.Z));
  ////  }

  ////  private void PluckLeaf(OctreeLinkedBranch branch, int child)
  ////  {
  ////    if (!(branch[child] is OctreeLinkedLeaf) || ((OctreeLinkedLeaf)branch[child]).Count > 1)
  ////      throw new OctreeLinkedException("There is a glitch in my octree, sorry.");
  ////    branch[child] = null;
  ////    while (branch.IsEmpty)
  ////    {
  ////      ChopBranch(branch.Parent, OctreeLinkedNode.DetermineChild(branch.Parent, branch.X, branch.Y, branch.Z));
  ////      branch = branch.Parent;
  ////    }
  ////  }

  ////  private void ChopBranch(OctreeLinkedBranch branch, int child)
  ////  {
  ////    if (branch[child] == null)
  ////      throw new OctreeLinkedException("There is a glitch in my octree, sorry...");
  ////    branch[child] = null;
  ////  }

  ////  /// <summary>Moves an existing item from one position to another.</summary>
  ////  /// <param name="key">The key of the item to be moved.</param>
  ////  /// <param name="x">The x coordinate of the new position of the item.</param>
  ////  /// <param name="y">The y coordinate of the new position of the item.</param>
  ////  /// <param name="z">The z coordinate of the new position of the item.</param>
  ////  public void Move(Type key, float x, float y, float z)
  ////  {
  ////    OctreeLinkedLeaf leaf = null;// _referenceDatabase.Get<Type>(key, _referenceComparison).Leaf;
  ////    Type entry = default(Type);
  ////    bool found = false;
  ////    foreach (Type value in leaf.Contents)
  ////      if (_comparisonFunction(value, key) == 0)
  ////      {
  ////        entry = value;
  ////        found = true;
  ////        break;
  ////      }
  ////    if (found == false)
  ////      throw new OctreeLinkedException("attempting to move a non-existing value.");
  ////    entry.Position.X = x;
  ////    entry.Position.Y = y;
  ////    entry.Position.Z = z;
  ////    if ((x > leaf.X - leaf.Scale && x < leaf.X + leaf.Scale)
  ////      && (y > leaf.Y - leaf.Scale && y < leaf.Y + leaf.Scale)
  ////      && (z > leaf.Z - leaf.Scale && z < leaf.Z + leaf.Scale))
  ////      return;
  ////    else
  ////    {
  ////      Remove(key, leaf);
  ////      Add(entry, _top);
  ////    }
  ////  }

  ////  /// <summary>Iterates through the entire tree and ensures each item is in the proper node.</summary>
  ////  public void Update()
  ////  {
  ////    throw new NotImplementedException("Sorry, I'm still working on the update function.");
  ////  }

  ////  /// <summary>Performs a functional paradigm traversal of the octree.</summary>
  ////  /// <param name="traversalFunction"></param>
  ////  public bool TraverseBreakable(Func<Type, bool> traversalFunction)
  ////  {
  ////    if (!TraverseBreakable(traversalFunction, _top))
  ////      return false;
  ////    return true;
  ////  }
  ////  private bool TraverseBreakable(Func<Type, bool> traversalFunctionBreakable, OctreeLinkedNode octreeNode)
  ////  {
  ////    if (octreeNode != null)
  ////    {
  ////      if (octreeNode is OctreeLinkedLeaf)
  ////      {
  ////        foreach (Type item in ((OctreeLinkedLeaf)octreeNode).Contents)
  ////          if (!traversalFunctionBreakable(item)) return false;
  ////      }
  ////      else
  ////      {
  ////        // The current node is a branch
  ////        OctreeLinkedBranch branch = (OctreeLinkedBranch)octreeNode;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child0)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child1)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child2)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child3)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child4)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child5)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child6)) return false;
  ////        if (!TraverseBreakable(traversalFunctionBreakable, branch.Child7)) return false;
  ////      }
  ////    }
  ////    return true;
  ////  }

  ////  public void Traverse(Action<Type> traversalFunction)
  ////  {
  ////    Traverse(traversalFunction, _top);
  ////  }
  ////  private void Traverse(Action<Type> traversalFunction, OctreeLinkedNode octreeNode)
  ////  {
  ////    if (octreeNode != null)
  ////    {
  ////      if (octreeNode is OctreeLinkedLeaf)
  ////      {
  ////        foreach (Type item in ((OctreeLinkedLeaf)octreeNode).Contents)
  ////          traversalFunction(item);
  ////      }
  ////      else
  ////      {
  ////        // The current node is a branch
  ////        OctreeLinkedBranch branch = (OctreeLinkedBranch)octreeNode;
  ////        Traverse(traversalFunction, branch.Child0);
  ////        Traverse(traversalFunction, branch.Child1);
  ////        Traverse(traversalFunction, branch.Child2);
  ////        Traverse(traversalFunction, branch.Child3);
  ////        Traverse(traversalFunction, branch.Child4);
  ////        Traverse(traversalFunction, branch.Child5);
  ////        Traverse(traversalFunction, branch.Child6);
  ////        Traverse(traversalFunction, branch.Child7);
  ////      }
  ////    }
  ////  }

  ////  /// <summary>Performs a functional paradigm traversal of the octree with data structure optimization.</summary>
  ////  /// <param name="traversalFunction">The function to perform per iteration.</param>
  ////  /// <param name="xMin">The minimum x of a rectangular prism to query the octree.</param>
  ////  /// <param name="yMin">The minimum y of a rectangular prism to query the octree.</param>
  ////  /// <param name="zMin">The minimum z of a rectangular prism to query the octree.</param>
  ////  /// <param name="xMax">The maximum x of a rectangular prism to query the octree.</param>
  ////  /// <param name="yMax">The maximum y of a rectangular prism to query the octree.</param>
  ////  /// <param name="zMax">The maximum z of a rectangular prism to query the octree.</param>
  ////  public bool TraverseBreakable(Func<Type, bool> traversalFunction, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  ////  {
  ////    return TraverseBreakable(traversalFunction, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  ////  }
  ////  private bool TraverseBreakable(Func<Type, bool> traversalFunction, OctreeLinkedNode octreeNode, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  ////  {
  ////    if (octreeNode != null)
  ////    {
  ////      if (octreeNode is OctreeLinkedLeaf)
  ////      {
  ////        foreach (Type entry in ((OctreeLinkedLeaf)octreeNode).Contents)
  ////          //if (!traversalFunction(item)) return false;
  ////          if (entry != null &&
  ////          entry.Position.X > xMin && entry.Position.X < xMax
  ////          && entry.Position.Y > yMin && entry.Position.Y < yMax
  ////          && entry.Position.Z > zMin && entry.Position.Z < zMax)
  ////            if (!traversalFunction(entry)) return false;
  ////      }
  ////      else
  ////      {
  ////        OctreeLinkedBranch branch = (OctreeLinkedBranch)octreeNode;
  ////        OctreeLinkedNode node = branch.Child0;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child1;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child2;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child3;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child4;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child5;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child6;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////        node = branch.Child7;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          if (!TraverseBreakable(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////            return false;
  ////      }
  ////    }
  ////    return true;
  ////  }

  ////  public void Traverse(Action<Type> traversalFunction, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  ////  {
  ////    Traverse(traversalFunction, _top, xMin, yMin, zMin, xMax, yMax, zMax);
  ////  }
  ////  private void Traverse(Action<Type> traversalFunction, OctreeLinkedNode octreeNode, float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
  ////  {
  ////    if (octreeNode != null)
  ////    {
  ////      if (octreeNode is OctreeLinkedLeaf)
  ////      {
  ////        foreach (Type entry in ((OctreeLinkedLeaf)octreeNode).Contents)
  ////          if (entry != null &&
  ////          entry.Position.X > xMin && entry.Position.X < xMax
  ////          && entry.Position.Y > yMin && entry.Position.Y < yMax
  ////          && entry.Position.Z > zMin && entry.Position.Z < zMax)
  ////            traversalFunction(entry);
  ////      }
  ////      else
  ////      {
  ////        OctreeLinkedBranch branch = (OctreeLinkedBranch)octreeNode;
  ////        OctreeLinkedNode node = branch.Child0;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child1;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child2;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child3;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child4;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child5;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child6;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////        node = branch.Child7;
  ////        if (OctreeLinkedNode.ContainsBounds(node, xMin, yMin, zMin, xMax, yMax, zMax))
  ////          Traverse(traversalFunction, node, xMin, yMin, zMin, xMax, yMax, zMax);
  ////      }
  ////    }
  ////  }

  ////  public Type[] ToArray()
  ////  {
  ////    int finalIndex;
  ////    Type[] array = new Type[_count];
  ////    ToArray(_top, array, 0, out finalIndex);
  ////    if (array.Length != finalIndex)
  ////      throw new OctreeLinkedException("There is a glitch in my octree, sorry...");
  ////    return array;
  ////  }
  ////  private void ToArray(OctreeLinkedNode octreeNode, Type[] array, int entryIndex, out int returnIndex)
  ////  {
  ////    if (octreeNode != null)
  ////    {
  ////      if (octreeNode is OctreeLinkedLeaf)
  ////      {
  ////        returnIndex = entryIndex;
  ////        foreach (Type item in ((OctreeLinkedLeaf)octreeNode).Contents)
  ////          array[returnIndex++] = item;
  ////      }
  ////      else
  ////      {
  ////        // The current node is a branch
  ////        OctreeLinkedBranch branch = (OctreeLinkedBranch)octreeNode;
  ////        ToArray(branch.Child0, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child1, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child2, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child3, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child4, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child5, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child6, array, entryIndex, out entryIndex);
  ////        ToArray(branch.Child7, array, entryIndex, out entryIndex);
  ////        returnIndex = entryIndex;
  ////      }
  ////    }
  ////    else
  ////      returnIndex = entryIndex;
  ////  }

  ////  #region Structure<Type>

  ////  #region .Net Framework Compatibility

  ////  /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
  ////  IEnumerator IEnumerable.GetEnumerator()
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>FOR COMPATIBILITY ONLY. AVOID IF POSSIBLE.</summary>
  ////  IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  #endregion

  ////  /// <summary>Gets the current memory imprint of this structure in bytes.</summary>
  ////  /// <remarks>Returns long.MaxValue on overflow.</remarks>
  ////  public int SizeOf { get { throw new NotImplementedException(); } }

  ////  /// <summary>Pulls out all the values in the structure that are equivalent to the key.</summary>
  ////  /// <typeparam name="Key">The type of the key to check for.</typeparam>
  ////  /// <param name="key">The key to check for.</param>
  ////  /// <param name="compare">Delegate representing comparison technique.</param>
  ////  /// <returns>An array containing all the values matching the key or null if non were found.</returns>
  ////  //Type[] GetValues<Key>(Key key, Compare<Type, Key> compare);

  ////  /// <summary>Pulls out all the values in the structure that are equivalent to the key.</summary>
  ////  /// <typeparam name="Key">The type of the key to check for.</typeparam>
  ////  /// <param name="key">The key to check for.</param>
  ////  /// <param name="compare">Delegate representing comparison technique.</param>
  ////  /// <returns>An array containing all the values matching the key or null if non were found.</returns>
  ////  /// <param name="values">The values that matched the given key.</param>
  ////  /// <returns>true if 1 or more values were found; false if no values were found.</returns>
  ////  //bool TryGetValues<Key>(Key key, Compare<Type, Key> compare, out Type[] values);

  ////  /// <summary>Checks to see if a given object is in this data structure.</summary>
  ////  /// <param name="item">The item to check for.</param>
  ////  /// <param name="compare">Delegate representing comparison technique.</param>
  ////  /// <returns>true if the item is in this structure; false if not.</returns>
  ////  public bool Contains(Type item, Compare<Type> compare)
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>Checks to see if a given object is in this data structure.</summary>
  ////  /// <typeparam name="Key">The type of the key to check for.</typeparam>
  ////  /// <param name="key">The key to check for.</param>
  ////  /// <param name="compare">Delegate representing comparison technique.</param>
  ////  /// <returns>true if the item is in this structure; false if not.</returns>
  ////  public bool Contains<Key>(Key key, Compare<Type, Key> compare)
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>Invokes a delegate for each entry in the data structure.</summary>
  ////  /// <param name="function">The delegate to invoke on each item in the structure.</param>
  ////  public void Foreach(Foreach<Type> function)
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>Invokes a delegate for each entry in the data structure.</summary>
  ////  /// <param name="function">The delegate to invoke on each item in the structure.</param>
  ////  public void Foreach(ForeachRef<Type> function)
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>Invokes a delegate for each entry in the data structure.</summary>
  ////  /// <param name="function">The delegate to invoke on each item in the structure.</param>
  ////  /// <returns>The resulting status of the iteration.</returns>
  ////  public ForeachStatus Foreach(ForeachBreak<Type> function)
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>Invokes a delegate for each entry in the data structure.</summary>
  ////  /// <param name="function">The delegate to invoke on each item in the structure.</param>
  ////  /// <returns>The resulting status of the iteration.</returns>
  ////  public ForeachStatus Foreach(ForeachRefBreak<Type> function)
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  /// <summary>Creates a shallow clone of this data structure.</summary>
  ////  /// <returns>A shallow clone of this data structure.</returns>
  ////  public Structure<Type> Clone()
  ////  {
  ////    throw new NotImplementedException();
  ////  }

  ////  ///// <summary>Converts the structure into an array.</summary>
  ////  ///// <returns>An array containing all the item in the structure.</returns>
  ////  //public Type[] ToArray()
  ////  //{
  ////  //  throw new NotImplementedException();
  ////  //}

  ////  #endregion

  ////  /// <summary>This is used for throwing OcTree exceptions only to make debugging faster.</summary>
  ////  private class OctreeLinkedException : Error
  ////  {
  ////    public OctreeLinkedException(string message) : base(message) { }
  ////  }
  ////}

  //#endregion

  #endregion
}