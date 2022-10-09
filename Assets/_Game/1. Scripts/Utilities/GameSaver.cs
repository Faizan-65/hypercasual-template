using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public static class GameSaver
    {
        public static void Save<T>(string saveName, T saveData)
        {
            var jsonString = JsonConvert.SerializeObject(saveData);     //convert to json string
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(jsonString);  //convert string to 8 bit-bytes.
            var base64String = Convert.ToBase64String(bytesToEncode);   //convert 8 to 6 bit bytes and convert to base64 equivalent
                                                                        //https://www.youtube.com/watch?v=7gSSMy_M4HU 


            var path = $"{Application.persistentDataPath}/{saveName}.save";     //get path to save at
            var file = new FileStream(path, FileMode.Create);                   //create file at path
       
            var formatter = new BinaryFormatter();  
            formatter.Serialize(file, base64String);                            //write the data to file
            file.Close();
        }

        public static T Load<T>(string saveName)
        {
            var path = $"{Application.persistentDataPath}/{saveName}.save";
            if (!File.Exists(path))
            {
                return default;     //default mean whatever type come as T, it will be returned
            }
            
            var formatter = new BinaryFormatter();
            var file = File.Open(path, FileMode.Open);
            try
            {
                var base64String = (string) formatter.Deserialize(file);
                byte[] bytesToDecode = Convert.FromBase64String(base64String);
                var jsonString = Encoding.UTF8.GetString(bytesToDecode);
                var saveData = JsonConvert.DeserializeObject<T>(jsonString);
                file.Close();
                return saveData;
            }
            catch
            {
                file.Close();
                return default;
            }
        }
    }
