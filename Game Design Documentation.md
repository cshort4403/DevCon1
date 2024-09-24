
# Dev Con 1 Game Design Documentation  

#### 9/14/2024  

**Chris**  
- Add third person character controller  
	- [Starter Assets ThirdPerson by Unity Technologies](https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-updates-in-new-charactercontroller-pa-196526)
- Add simple geometry for testing  

#### 9/17/2024  

**Chris**  
- Add portal manager class  
	- Handles creation and destruction of portals  
	- Manages lifespan of portals and makes sure there is only two  
	- Handles traversal of objects through the portals  
- Attach portal manager class to empty game object in the scene

  #### 9/18/2024

  **Ethan**
  - Added portal asset with rigidbody and collision
    	- [Magic Effects FREE by Hovl Studio] (https://assetstore.unity.com/packages/vfx/particles/spells/magic-effects-free-247933)
  - Create empty game object called "PortalManager" and add the PortalManager script to it

#### 9/19/2024

**Parker**
- Added portal placement to the character controller
	- Added collision checking so player can't place portals inside colliders.
- Created empty game object that is a child of the player, object's transform determines where portal is placed.  

#### 9/23/2024

**Chris**
- Merge portal placement into main and create testing logic branch to bring it all together
- Fixed bug where portals were not deleting.

