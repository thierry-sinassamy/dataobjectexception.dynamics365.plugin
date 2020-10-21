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

        public Root(T thing, string key, bool isParent)
        {
            Thing = thing;
            TheType = typeof(T);
            Key = key;
            IsParent = isParent;
        }

        public void AddChild(T thing, string key, Root<T> node)
        {
            if(this.Children == null)
            {
                this.Children = new Child<T>(thing, true, key, node);
            }
            else
            {
                this.Children.AddChild(thing, false, key, node);
            }
        }
    }
}
