namespace Zbw.Carrent.CarManagement.Domain
{
    public class CarCategory
    {
        public Guid Id { get; }
        public string Name { get; }
        public decimal DailyFee { get; set; }
    }
}
