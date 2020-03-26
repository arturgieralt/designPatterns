using System.Collections.Generic;

namespace Creational.Prototype
{
    public class CarConfigurationManager
    {
        private Dictionary<string, CarConfigurationPrototype> _configurations = new Dictionary<string, CarConfigurationPrototype>();

        public CarConfigurationPrototype this[string name]
        {
            get { return _configurations[name]; }
            set { _configurations.Add(name, value); }
        }
    }
}