using dataobjectexception.dynamics365.crud.registration.Infrastructure;
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
        public int LevelCount { get; set; }

        public Child(T thing, bool hasParent, string key, Root<T> node, EnumLevelCount enumLevelCount)
        {
            TheType = typeof(T);
            Thing = thing;
            Node = node;
            HasParent = hasParent;
            Key = key;
            LevelCount = (int)enumLevelCount;
        }

        public void AddChild(T thing, bool hasParent, string keyParent, Root<T> node, EnumLevelCount enumLevelCount)
        {
            if (NextChild == null)
            {
                NextChild = new Child<T>(thing, hasParent, keyParent, node, enumLevelCount);
                IsParentToo = true;
            }
            else
            {
                NextChild.AddChild(thing, hasParent, keyParent, node, enumLevelCount);
                IsParentToo = true;
            }
        }
    }
}
