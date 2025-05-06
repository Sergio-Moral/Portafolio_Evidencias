using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.Text; // Needed for encoding
public class SignUpScript : MonoBehaviour
{
    public TMP_InputField nombre;
    public TMP_InputField noLista;
    public TMP_Dropdown grupo;
    public TMP_Dropdown genero;

    [System.Serializable]
    public class User
    {
        public string name;
        public int list;
        public string group;
        public string gender;
        public List<Level> levels;

    }

    public IEnumerator Upload(User u)
    {
        // Convert the user object to JSON format
        string jsonData = JsonUtility.ToJson(u);
        // Log the JSON to see what is being sent
        Debug.Log("Sending JSON: " + jsonData);

        // Convert the JSON string to bytes and set the request type and headers
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);
        Debug.Log("Sending JSON: " + jsonData);

        UnityWebRequest www = UnityWebRequest.Put("http://127.0.0.1:14465/register", jsonToSend);
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");

        // Send the request and wait for the response
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Server Response: " + www.downloadHandler.text);
            // Optionally, handle the JSON response here if needed
            User responseUser = JsonUtility.FromJson<User>(www.downloadHandler.text);
            Debug.Log("Received: " + responseUser.group + " " + responseUser.gender + " " + responseUser.list);
        }
    }

    public void recoverUserData()
    {
        // Create a user object from the input fields
        User u = new User
        {
            name = nombre.text,
            list = int.Parse(noLista.text),
            group = grupo.options[grupo.value].text,
            gender = genero.options[genero.value].text
        };

        // Start the coroutine to upload the user data
        StartCoroutine(Upload(u));
    }

    void Start()
    {
        // Optionally initialize anything needed on start
    }

    void Update()
    {
        // Update logic if needed
    }
}
