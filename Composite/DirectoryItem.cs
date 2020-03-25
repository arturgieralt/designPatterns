using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class DirectoryItem: FileSystemItem
    {
        public List<FileSystemItem> Elements {get;} = new List<FileSystemItem>();
        
        public DirectoryItem(string name): base(name) 
        {
        }

        public void Add(FileSystemItem element)
        {
            Elements.Add(element);
        }

        public void Remove(FileSystemItem element)
        {
            Elements.Remove(element);
        }

        public override decimal GetSizeInKB()
        {
            return Elements.Sum(e => e.GetSizeInKB());
        }

        public FileSystemItem GetItem(string name)
        {
            var elements = new Stack<DirectoryItem>();

            elements.Push(this);

            while(elements.Any()){
                var currentElement = elements.Pop();

                if(currentElement.Name == name) 
                {
                    return currentElement;
                }

                foreach(var item in currentElement.Elements) {

                    if(item.Name == name)
                    {
                        return item;
                    }

                    if(item.GetType() == typeof(DirectoryItem)) {
                        elements.Push((DirectoryItem)item);
                    }
                }
            }

            throw new Exception("Directory not found");
        }
    }
}