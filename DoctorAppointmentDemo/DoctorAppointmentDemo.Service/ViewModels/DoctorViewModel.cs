namespace MyDoctorAppointment.Service.ViewModels
{
    public class DoctorViewModel
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name},  {Surname}, {Experience}, {DoctorType}";
        }
    }
}