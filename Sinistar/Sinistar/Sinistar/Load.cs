using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sinistar
{
    /// <summary>
    /// Class that works on loading different things into
    /// the game, that isn't associated with native items. 
    /// For instance, one method will work on loading all
    /// of the sprites from a specific image and .txt file. 
    /// </summary>
    class Load
    {
        public static Dictionary<String, Rectangle[]> Sprites()
        {
            Dictionary<string, Rectangle[]> groups = new Dictionary<string, Rectangle[]>(); 
            using(Stream stream = TitleContainer.OpenStream("spritesheetLocations.txt"))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    string allTextInFile = reader.ReadToEnd();
                    string[] lines = allTextInFile.Split('\n');

                    // Keeps track of what line you're on in the file. 
                    int lineIndex = 1;

                    // For every sprite group in the file...
                    for(int groupIndex = 0; groupIndex < int.Parse(lines[0]); groupIndex++)
                    {
                        string[] words = lines[lineIndex].Split(' ');
                        string name = words[0]; 
                        Rectangle[] textures = new Rectangle[int.Parse(words[1])]; // How many rectangles in one group
                        for(int textureIndex = 0; textureIndex < textures.Length; textureIndex++)
                        {
                            lineIndex++;
                            words = lines[lineIndex].Split(' ');
                            textures[textureIndex] = new Rectangle(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3])); 
                        }
                        lineIndex++;

                        groups.Add(name, textures);  
                    }
                }
            }

            return groups; 
        }
    }
}
