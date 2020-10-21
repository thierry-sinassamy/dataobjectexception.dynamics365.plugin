using System;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public class Child<T>
    {
        public Root<T> Node;
        public Child<T> NextChild = null;
        public T Thing { get; set; }
        public Type TheType { get; }
        public readonly bool HasParent;
        public bool IsParentToo;
        public string Key;

        public Child(T thing, bool hasParent, string key, Root<T> node)
        {
            TheType = typeof(T);
            Thing = thing;
            Node = node;
            HasParent = hasParent;
            Key = key;
        }

        public void AddChild(T thing, bool hasParent, string keyParent, Root<T> node)
        {
            if (NextChild == null)
            {
                NextChild = new Child<T>(thing, hasParent, keyParent, node);
                IsParentToo = true;
            }
            else
            {
                NextChild.AddChild(thing, hasParent, keyParent, node);
                IsParentToo = true;
            }
        }
    }
}
