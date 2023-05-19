using System;
using System.IO;
using Newtonsoft.Json;
using Godot;

public class GetJsonFile<T>
{
    public static T GetData(string path)
    {
        if (!System.IO.File.Exists(path))
            throw new ApplicationException("Path not found");
        
        string text = System.IO.File.ReadAllText(path);

        var data = JsonConvert.DeserializeObject<T>(text);
            
        return data;
    }
}