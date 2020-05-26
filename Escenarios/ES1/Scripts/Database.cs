using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.IO;
// [System.Serializable]
// public class Niveles
// {

// }

[System.Serializable]
public class User
{
    public int id;
    public string username;
    public string password;
    public bool tutorial;
    public int[] niveles;
    public bool[] achivements;

}

[System.Serializable]
public class Users
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public User[] users;
    
    public void Push(User x) {
        int len = users.Length;
        User[] newUsers = new User[len+1];
        for(int i=0; i<len;i++){
            newUsers[i] = users[i];
        }
        newUsers[len] = x;
        users = newUsers;
    }
}


public class Database : MonoBehaviour
{
    public TextAsset jsonFile;
    public static Users userBase;

    // Start is called before the first frame update
    void Start()
    {
        userBase = JsonUtility.FromJson<Users>(jsonFile.text);
    }

    public static int login(string username, string pass) {
        // Debug.Log("aver si encontramos algo " + userBase.users[1].username);
        foreach (User user in userBase.users) {
            if(user.username == username && user.password == pass) {
                // Debug.Log("aver si encontramos algo ");
                return user.id;
            }
        }
        return -1;
    }


    public static bool getAchivement(int i) {
        return userBase.users[GlobalVariables.usernameId].achivements[i];
    }
    
    public static void setAchivement(int i) {
        userBase.users[GlobalVariables.usernameId].achivements[i] = true;
    }

    public static int getScore(int i) {
        return userBase.users[GlobalVariables.usernameId].niveles[i];
    }
    
    public static void setScore(int i, int s) {
        userBase.users[GlobalVariables.usernameId].niveles[i] = s;
    }

    public static bool getTutorial() {
        return userBase.users[GlobalVariables.usernameId].tutorial;
    }

    public static void setTutorial() {
        userBase.users[GlobalVariables.usernameId].tutorial = false;
    }
    
    public static void makeUser(string name, string password) {
        User nUser = new User();
        Debug.Log("Paso 1");
        nUser.id = userBase.users[userBase.users.Length - 1].id + 1;
        nUser.username = name;
        nUser.password = password;
        int[] niv = {0, 0, 0, 0, 0, 0, 0};
        nUser.niveles = niv;
        bool[] ach = {false, false, false, false, false, false, false};
        nUser.achivements = ach;
        Debug.Log("Paso 2");
        userBase.Push(nUser); 
        Debug.Log("Paso end");
    }

    public static void saveData(){
        string jsonData = JsonUtility.ToJson (userBase, true);
        File.WriteAllText("../ProyectoIntegrador2.0/Assets/ES1/database/users.json",jsonData);
    }
}
