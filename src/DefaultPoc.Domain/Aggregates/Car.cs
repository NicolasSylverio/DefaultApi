using DefaultPoc.Domain.Enums;

namespace DefaultPoc.Domain.Aggregates
{
    public class Car
    {
        public Brand Brand { get; private set; }
        public string Name { get; private set; }
        public string Model { get; private set; }
        public decimal Value { get; private set; }

        public Car(Brand brand, string name, string model, decimal value)
        {
            Brand = brand;
            Name = name;
            Model = model;
            Value = value;
        }
    }
}