using System.Collections.Generic;
using Helab.Camera;
using Helab.Controller;
using Helab.Entity;
using Helab.Entity.Character;
using Helab.Entity.Stage;
using Helab.Input;
using Helab.UI;
using UnityEngine;

namespace Helab.Management
{
    public class WorldDatabase : MonoBehaviour
    {
        public WorldRoot worldRoot;

        public CameraGroup cameraGroup;
        
        public List<Light> lights;
        
        public List<UserInput> userInputs;
        
        public List<AbstractController> controllers;
        
        public List<AbstractWidget> widgets;
        
        public List<AbstractEntity> entities;
        
        public PlayerGroup playerGroup;

        public void AddComponent(Component component)
        {
            switch (component)
            {
            case AbstractCamera c:
                worldRoot.DeployToCameraRoot(c.gameObject);
                cameraGroup.AddCamera(c);
                break;
            case Light c:
                worldRoot.DeployToLightRoot(c.gameObject);
                lights.Add(c);
                break;
            case UserInput c:
                worldRoot.DeployToInputRoot(c.gameObject);
                userInputs.Add(c);
                break;
            case AbstractController c:
                worldRoot.DeployToControllerRoot(c.gameObject);
                controllers.Add(c);
                break;
            case AbstractWidget c:
                worldRoot.DeployToUIRoot(c.gameObject);
                widgets.Add(c);
                break;
            case StageEntity c:
                worldRoot.DeployToStageRoot(c.gameObject);
                entities.Add(c);
                break;
            case CharacterEntity c:
                worldRoot.DeployToCharacterRoot(c.gameObject);
                entities.Add(c);
                if (c.IsPlayable)
                {
                    playerGroup.AddPlayer(c);
                }
                break;
            }
        }

        public void RemoveComponent(Component component)
        {
            switch (component)
            {
            case AbstractCamera c:
                cameraGroup.RemoveCamera(c);
                break;
            case Light c:
                lights.Remove(c);
                break;
            case UserInput c:
                userInputs.Remove(c);
                break;
            case AbstractController c:
                controllers.Remove(c);
                break;
            case AbstractWidget c:
                widgets.Remove(c);
                break;
            case StageEntity c:
                entities.Remove(c);
                break;
            case CharacterEntity c:
                entities.Remove(c);
                if (c.IsPlayable)
                {
                    playerGroup.RemovePlayer(c);
                }
                break;
            }
        }
    }
}
