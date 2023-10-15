using Newtonsoft.Json;

namespace Application.Core.Helpers
{
    public class JsonDataHelper
    {
        public T ReadJsonFile<T>(string jsonFilePath)
        {
            var jsonStringData = File.ReadAllText(jsonFilePath);
            var jsonObjectData = JsonConvert.DeserializeObject<T>(jsonStringData);
            return jsonObjectData;
        }

        public bool WriteToJsonFile<T>(T model, string jsonFilePath)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Formatting.Indented;

            var jsonStringData = JsonConvert.SerializeObject(model,jsonSerializerSettings);
            File.WriteAllText(jsonFilePath, jsonStringData);

            var dataWritten = false;

            if(File.Exists(jsonFilePath) && File.ReadAllText(jsonFilePath)==jsonStringData)
            {
                dataWritten = true;
            }
            return dataWritten;
        }

    }
}
