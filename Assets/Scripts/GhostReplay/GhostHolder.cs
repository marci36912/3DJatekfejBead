using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GhostHolder : MonoBehaviour
{
    private static List<Ghost> _points;
    private static string playerName;
    private static string  playedDate;
    private static readonly string fileName = "saves";

    private void Start() 
    {
        loadSaves();
        if(playerName == "" || playerName == null)
            playerName = "John Doe";
    }

    public void setPoints(List<Ghost> points)
    {
        if(_points != null)
        { 
            if((_points[_points.Count-1].timestamp - _points[0].timestamp) > (points[points.Count-1].timestamp - points[0].timestamp))
            {
                _points = points;
                writeSaves();
            }
            
            Debug.Log("Recording done");
        }
        else
        {
            _points = points;
            writeSaves();   
        }
    }

    public List<Ghost> getPoints()
    {
        Debug.Log("points set");
        return _points;
    }

    public static void setName(string name)
    {
        playerName = name;
    }

    public static void setDate()
    {
        playedDate = DateTime.Now.ToString("yyyy/MM/dd");
    }

    public void writeSaves()
    {
        if(playedDate == "" || playedDate == null)
            setDate();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"{playerName} {playedDate}\n");
            foreach (Ghost point in _points)
            {
                outputFile.WriteLine(point.ToString());
            }

            outputFile.Close();
        }

        Debug.Log("Data written");
    }

    public void loadSaves()
    {
        if(File.Exists(fileName))
        {
            _points = new List<Ghost>();
            using(StreamReader file = new StreamReader(fileName)) 
            {
                string line = file.ReadLine();
                string[] firstLine = line.Split(' ');

                playerName = firstLine[0];
                playedDate = firstLine[1];

                while((line = file.ReadLine()) != null) 
                {
                    _points.Add(new Ghost(line));
                }

                file.Close();
            }

            Debug.Log("Data loaded");
        }
    }
}