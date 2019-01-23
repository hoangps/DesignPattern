using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns
{
    public class Composite : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("Composite");

            var treeRoot = new Folder("root");
            treeRoot.Add(new File("track.mp3"));
            treeRoot.Add(new File("report.csv"));

            var hiddenFolder = new Folder("This folder is empty");
            treeRoot.Add(hiddenFolder);

            hiddenFolder.Add(new File("Suspicious file.zip"));
            hiddenFolder.Add(new File("Nothing to see here.jpg"));

            treeRoot.Display();

            Console.ReadLine();
        }
    }


    public abstract class FolderNode
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public FolderNode(string name)
        {
            Level = 1;
            Name = name;
        }

        public virtual void Add(FolderNode node) { Console.WriteLine("Operation not supported"); }

        public virtual void Remove(FolderNode node) { Console.WriteLine("Operation not supported"); }

        public virtual void Display() { Console.WriteLine("Operation not supported"); }
    }

    public class File : FolderNode
    {
        public File(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine(new String('-', Level) + " File: " + Name);
        }
    }

    public class Folder : FolderNode
    {
        private List<FolderNode> _children = new List<FolderNode>();

        public Folder(string name) : base(name)
        {
        }

        public override void Add(FolderNode node)
        {
            node.Level = Level + 1;
            _children.Add(node);
        }

        public override void Remove(FolderNode node)
        {
            _children.Remove(node);
        }

        public override void Display()
        {
            Console.WriteLine(new String('-', Level) + " Folder: " + Name);
            foreach (var childNode in _children)
                childNode.Display();
        }
    }
}
