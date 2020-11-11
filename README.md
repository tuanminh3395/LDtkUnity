# LDtk for Unity
A package for easy Unity-integration with the [Level Designer Toolkit, created by deepknight](https://github.com/deepnight/ldtk).  
It's still in very early stages and prone to bugs, but I hope to share this with anyone else who can find this useful.  
Available for download through the Unity Package Manager.  

## [Documentation](https://github.com/Cammin/LDtkUnity/blob/master/DOCUMENTATION.md)  

## Features  
- Supports most features of LDtk (work in progress)  
- Supports Unity's [Enter Play Mode options](https://docs.unity3d.com/Manual/ConfigurableEnterPlayMode.html)  
- Easy and convenient entity instance field injection

## Required
This package uses Newtonsoft.Json for Unity to deserialize a LDtk project.  
[Newtonsoft.Json for Unity](https://github.com/jilleJr/Newtonsoft.Json-for-Unity)

## Install  
- Install Newtonsoft.Json for Unity.
- Then put this in your manifest:  
 ```"com.cammin.ldtkunity": "https://github.com/Cammin/LDtkUnity.git?path=/Assets/LDtkUnity#master"```
 
 ### Features Currently Missing and Planned
 
 - Tileset layer creation not implemented yet
 - Add Images into Documentation and Readme, finish documentation
 - Consider making data structs use a Json Attribute to allow alternate variable names
 - Make TileCoordTool
