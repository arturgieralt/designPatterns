using System.Collections.Generic;
using System.Linq;

namespace Creational.Prototype
{
    public class CarConfiguration: CarConfigurationPrototype
    {

        public string Name { get; }
        public IEnumerable<CarPart> CarParts { get; private set; }
        public CarModel Model { get; private set;}
        public CarConfiguration(string configName, CarModel model, IEnumerable<CarPart> carParts)
        {
            Name = configName;
            Model = model;
            CarParts = carParts;
        }

        public decimal GetTotalPrice()
        {
            return decimal.Add(Model.BasePrice, CarParts.Sum(cp => cp.Price));
        }

        public override CarConfigurationPrototype Clone()
        {
            // nothing fancy
            CarConfiguration clone = (CarConfiguration)this.MemberwiseClone();
            clone.CarParts = this.CarParts.Select(cp =>     
                new CarPart(){
                    Name = cp.Name,
                    Price = cp.Price
                }).ToList();
            clone.Model = new CarModel()
            {
                Name = this.Model.Name,
                BasePrice = this.Model.BasePrice
            };
            
            return clone;
        }
    }

    public class CarModel
    {
        public string Name { get; set;}
        public decimal BasePrice { get; set;}
    }

    public class CarPart 
    {
        public string Name { get; set;}
        public decimal Price { get; set;}
    }
}