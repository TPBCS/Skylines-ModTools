﻿using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace ModTools
{

    public class Configuration
    {

        public Rect mainWindowRect = new Rect(128, 128, 356, 260);
        public bool mainWindowVisible = false;

        public Rect sceneExplorerRect = new Rect(128, 440, 800, 500);
        public bool sceneExplorerVisible = false;

        public Rect watchesRect = new Rect(504, 128, 800, 300);
        public bool watchesVisible = false;

        public bool logExceptionsToConsole = true;
        public bool evaluatePropertiesAutomatically = true;
        public bool extendGamePanels = true;

        public Color backgroundColor = Color.grey;
        public Color gameObjectColor = new Color(165.0f / 255.0f, 186.0f / 255.0f, 229.0f / 255.0f, 1.0f);
        public Color enabledComponentColor = Color.white;
        public Color disabledComponentColor = new Color(127.0f / 255.0f, 127.0f / 255.0f, 127.0f / 255.0f, 1.0f);
        public Color selectedComponentColor = new Color(233.0f / 255.0f, 138.0f / 255.0f, 23.0f / 255.0f, 1.0f);

        public Color nameColor = new Color(0.0f, 179.0f / 255.0f, 255.0f / 255.0f, 1.0f);
        public Color typeColor = new Color(58.0f / 255.0f, 179.0f / 255.0f, 58.0f / 255.0f, 1.0f);
        public Color keywordColor = new Color(233.0f / 255.0f, 102.0f / 255.0f, 47.0f / 255.0f, 1.0f);
        public Color modifierColor = new Color(84.0f / 255.0f, 109.0f / 255.0f, 57.0f / 255.0f, 1.0f);
        public Color memberTypeColor = new Color(86.0f / 255.0f, 127.0f / 255.0f, 68.0f / 255.0f, 1.0f);
        public Color valueColor = Color.white;


        public void OnPreSerialize()
        {

        }

        public void OnPostDeserialize()
        {

        }

        public static void Serialize(string filename, Configuration config)
        {
            var serializer = new XmlSerializer(typeof(Configuration));

            using (var writer = new StreamWriter(filename))
            {
                config.OnPreSerialize();
                serializer.Serialize(writer, config);
            }
        }

        public static Configuration Deserialize(string filename)
        {
            var serializer = new XmlSerializer(typeof(Configuration));

            try
            {
                using (var reader = new StreamReader(filename))
                {
                    var config = (Configuration)serializer.Deserialize(reader);
                    config.OnPostDeserialize();
                    return config;
                }
            }
            catch { }

            return null;
        }
    }

}