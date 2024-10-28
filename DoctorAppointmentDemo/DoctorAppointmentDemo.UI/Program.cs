using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using DoctorAppointmentDemo.Domain.Enums;
using System.Net.Quic;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;

        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            _doctorService = new DoctorService(appSettings, serializationService);
        }

        public Doctor AddItem()
        {
            Console.WriteLine("Введіть ім'я");
            var name = Console.ReadLine();
            Console.WriteLine("Введіть прізвище");
            var surname = Console.ReadLine();
            Console.WriteLine("Введіть досвід роботи");
            var experience = Convert.ToByte((Console.ReadLine()));
            Console.WriteLine("Введіть підпрофесію доктора: ");
            Console.WriteLine("1 - дантист");
            Console.WriteLine("2 - дерматолог");
            Console.WriteLine("3 - сімейний доктор");
            Console.WriteLine("4 - парамедик");
            var doctorType = (DoctorTypes)(Int32.Parse(Console.ReadLine()));
            var newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Experience = experience,
                DoctorType = doctorType
            };
            return newDoctor;
        }

        public void Menu()
        {
            var docs = _doctorService.GetAll();
            var menuComplete = false;
            while (true)
            {
                Console.WriteLine("Виберіть дію: ");
                Console.WriteLine("1. Додати доктора");
                Console.WriteLine("2. Продивитись лист докторів");
                Console.WriteLine("3. Вихід");
                var choice = (MenuOperations)(Int32.Parse(Console.ReadLine()));
                switch (choice)
                {
                    case MenuOperations.AddItem:
                        _doctorService.Create(AddItem());
                        Console.WriteLine("Доктор був доданий успішно");
                        break;
                    case MenuOperations.CheckItemList:
                        docs = _doctorService.GetAll();
                        foreach (var doc in docs)
                        {
                            Console.WriteLine(doc.ToString());
                        }
                        break;
                    case MenuOperations.Exit:
                        menuComplete = true;
                        Console.WriteLine("До побачення!");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір");
                        choice = (MenuOperations)(Int32.Parse(Console.ReadLine()));
                        continue;
                }
                if (menuComplete == true)
                    break;

            }
        }
    }

    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Виберіть формат даних (1 - Json або 2 - XML)");
                Console.Write("Вибраний тип: ");
                var choice = (DataTypes)(Int32.Parse(Console.ReadLine()));
                DoctorAppointment? doctorAppointment = null;
            while (true)
            {
                switch (choice) {
                    case DataTypes.XML:
                
                        doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializer());
                        break;
                
                    case DataTypes.Json:
                        doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializer());
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір");
                        choice = (DataTypes)(Int32.Parse(Console.ReadLine()));
                        continue;
                }
                if (!doctorAppointment.Equals(null))
                    break;
            }
            doctorAppointment.Menu();
        }
    }
}