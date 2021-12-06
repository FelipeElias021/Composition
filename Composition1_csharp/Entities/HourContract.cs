using System;
using System.Globalization;

namespace Composition1_csharp.Entities
{
    class HourContract
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }


        public HourContract()
        {
        }

        public HourContract(int id)
        {
            Id = id;
        }

        public HourContract(int id, DateTime date, double valuePerHour, int hours) : this(id)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nDate: {Date.ToShortDateString()}\nValue per hour: {ValuePerHour.ToString("F2", CultureInfo.InvariantCulture)} ETC\nHours: {Hours}\nTotal value: {TotalValue().ToString("F2", CultureInfo.InvariantCulture)} ETC";
        }
    }
}
