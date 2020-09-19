using System;

namespace Juce.Tween
{
    internal class ExtensionDefineEntry
    {
        public string Name { get; private set; }
        public string Define { get; private set; }
        public bool Enabled { get; set; }

        public ExtensionDefineEntry(string name, string define)
        {
            Name = name;
            Define = define;
        }
    }
}
