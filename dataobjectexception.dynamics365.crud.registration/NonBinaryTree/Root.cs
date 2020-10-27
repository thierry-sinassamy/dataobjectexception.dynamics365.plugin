using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{    
    public class Root<T>
    {
        public T Thing { get; set; }
        public Type  TheType { get; }
        public string Key { get; set; }
        public bool IsParent { get; set; }
        public Child<T> Children { get; set; }
        public int LevelCount { get; set; }

        public Root(T thing, string key, bool isParent)
        {
            Thing = thing;
            TheType = typeof(T);
            Key = key;
            IsParent = isParent;
            LevelCount = (int)EnumLevelCount.LevelRoot;
        }

        public void AddChild(T thing, string key, Root<T> node, EnumLevelCount enumLevelCount)
        {
            if(this.Children == null)
            {
                this.Children = new Child<T>(thing, true, key, node, enumLevelCount);
            }
            else
            {
                this.Children.AddChild(thing, false, key, node, enumLevelCount);
            }
        }
    }
}
