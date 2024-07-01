Name: Allen Santmier
Email: asantmier3@gatech.edu
Canvas: Allen Bailey Santmier

Main Scene: GameMenuScene

The new GameMenuScene is with the old demo scene in the Scenes folder.
I have added a new layed "PostProcessing" and assigned it to the main camera for post processing FX. 
Additionally, some blur and film grain has been put on the post-processing volume of the camera.
The GameStarter script for the menus can be found under Scripts/Utility in addition to the CollectableBall and BallCollector scripts.
The collectable is to the right of the player's starting position and is named Pickup Ball.
Because the pickup ball makes the same bomb bounce sound as some of the balls, it's best to wait for the balls to settle down a little before testing.

The object I created for the last step is a door that automatically opens when the player gets close enough, then closes when they move away.
All the assets used in the door, including its prefab, can be found in the folder labled "M3 Door" and were all made by hand.
Because the scene is so cluttered around the player character since M2, these doors have been placed over to the right.
The door will open when a rigidbody is in an area around it, so it will respond to the player as well as any other physics object.
I would have made it so that the door only responds to the player, but I didn't want to modify the player at all nor hardcode the doors.