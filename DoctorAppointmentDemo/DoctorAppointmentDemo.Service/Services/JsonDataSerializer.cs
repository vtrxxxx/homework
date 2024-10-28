using MyDoctorAppointment.Data.Interfaces;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyDoctorAppointment.Service.Services
{
    public class JsonDataSerializer : ISerializationService
    {
        public T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);

            //return JsonConvert.DeserializeObject<T>(json);
        }

        public void Serialize<T>(string path, T data)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(data));

            //File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}