namespace Composite
{
    public class FileItem: FileSystemItem
    {
        public decimal SizeInBytes { get; }
        public FileItem(string name, decimal size): base(name) {
            SizeInBytes = size;
        }

        public override decimal GetSizeInKB()
        {
            return decimal.Divide(SizeInBytes,1000);
        }
        
    }
}