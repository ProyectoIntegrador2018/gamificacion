using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
