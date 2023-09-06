namespace Zbw.Carrent.CarManagement.Domain
{
    public class CarCategory
    {
        public CarCategory(string name, decimal dailyFee)
        {
            Id = Guid.NewGuid();
            Name = name;
            DailyFee = dailyFee;
        }

        public Guid Id { get; }

        public string Name { get; }

        public decimal DailyFee { get; set; }
    }
}
