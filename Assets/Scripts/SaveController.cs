using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveController : MonoBehaviour
{
    const String nameDirectory = "/saveJSON";
    const String nameSave = "/partidaGuardada.JSON";

    [SerializeField] bolaController bolaController;

    [Serializable]
    public class BolaInfo
    {
        public int bounces;
    }



    public string GetPathToSaveGameFolder()
    {
        return Application.dataPath + nameDirectory;
    }
    public string GetPathToSaveGameFile()
    {
        return GetPathToSaveGameFolder() + nameSave;

    }
   
    private void AssertDirectories()
    {
        //Si carpetra No existe, pimero creamos carpeta
        //Si la carpeta existe, creamos archivo directamente 
        if (!Directory.Exists(GetPathToSaveGameFolder()))
        {
            Directory.CreateDirectory(GetPathToSaveGameFolder());
            Debug.Log("El directorio es ha creado en " + GetPathToSaveGameFolder());
        }
    }

    public void SaveBounces()
    {
        AssertDirectories();
        BolaInfo bolaInfo = new BolaInfo();
        bolaInfo.bounces = bolaController.GetBounces();

        string json = JsonUtility.ToJson(bolaInfo);
        string path = GetPathToSaveGameFile();
        File.WriteAllText(path, json);

        Debug.Log("JSON guardado en: " + path);
        Debug.Log(json);
    }


    public void LoadBounces()
    {
        bool existDirectory = true;
        bool existFile = true;
        if (!Directory.Exists(GetPathToSaveGameFolder()))
        {
            Debug.Log("No existe la carpeta de guardado.");
            existDirectory = false;
        }

  
        string path = GetPathToSaveGameFile();

        if (!File.Exists(path))
        {
            Debug.Log("No existe ninguna partida guardada.");
            existFile = false;
        }
        if (existFile == true && existDirectory == true)
        {
            
            string json = File.ReadAllText(path);

            
            BolaInfo bolaInfo = JsonUtility.FromJson<BolaInfo>(json);

            
            bolaController.SetBounces(bolaInfo.bounces);

            Debug.Log("Partida cargada. Botes: " + bolaInfo.bounces);
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
