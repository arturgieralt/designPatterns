using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


// extension for .net core composite element 
namespace Composite
{
    public static class Extensions
    {
        public static IEnumerable<XElement> FindElements(this XElement root, Predicate<XElement> predicate)
        {
            var stack = new Stack<XElement>();
            stack.Push(root);

            while (stack.Any())
            {
                var current = stack.Pop();
                foreach (var element in current.Elements())
                {
                    stack.Push(element);
                }
                if (predicate(current))
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<FileSystemItem> GetItems(this DirectoryItem directoryItem, Predicate<FileSystemItem> predicate)
        {
             var elements = new Stack<DirectoryItem>();

            elements.Push(directoryItem);

            while(elements.Any()){
                var currentElement = elements.Pop();

                if(predicate(currentElement)) 
                {
                    yield return currentElement;
                }

                foreach(var item in currentElement.Elements) {

                    if(predicate(item))
                    {
                        yield return item;
                    }

                    if(item.GetType() == typeof(DirectoryItem)) {
                        elements.Push((DirectoryItem)item);
                    }
                }
            }
        }
    }
}
