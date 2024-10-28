namespace MyDoctorAppointment.Domain.Entities
{
    public class Repository
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public CellEntity Doctors { get; set; }
        public CellEntity Patients { get; set; }
        public CellEntity Appointments { get; set; }
    }

    public class CellEntity
    {
        public int LastId { get; set; }
        public string Path { get; set; }
    }
}
