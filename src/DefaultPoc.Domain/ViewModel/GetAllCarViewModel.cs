using DefaultPoc.Domain.Enums;

namespace DefaultPoc.Domain.ViewModel
{
    public class GetAllCarViewModel
    {
        public Guid Id { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Value { get; set; }
    }
}