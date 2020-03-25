using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class FileSystemBuilder
    {
        private DirectoryItem currentDirectory;
        public DirectoryItem Root;

        public FileSystemBuilder(string rootDirectory)
        {
            Root = new DirectoryItem(rootDirectory);
            currentDirectory = Root;
        }

        public FileSystemBuilder AddDirectory(string name)
        {
            var dir = new DirectoryItem(name);
            this.currentDirectory.Add(dir);
            this.currentDirectory = dir;
            return this;
        }

        public FileSystemBuilder AddFile(string name, decimal fileSize)
        {
            var file = new FileItem(name, fileSize);
            this.currentDirectory.Add(file);
            return this;
        }

        public FileSystemBuilder SetCurrentDirectory(string directoryName)
        {
            var elements = new Stack<DirectoryItem>();

            elements.Push(Root);

            while(elements.Any()){
                var currentElement = elements.Pop();

                if(currentElement.Name == directoryName) 
                {
                    currentDirectory = currentElement;
                    return this;
                }

                foreach(var directoryItem in currentElement.Elements.OfType<DirectoryItem>()) {
                    elements.Push(directoryItem);
                }
            }

            throw new Exception("Directory not found");
        }

        public DirectoryItem Build() 
        {
            return Root;
        }
    }
}