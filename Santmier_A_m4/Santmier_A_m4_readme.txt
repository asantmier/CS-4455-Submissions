Name: Allen Santmier
Email: asantmier3@gatech.edu
Canvas: Allen Bailey Santmier

Main Scene: demo

The waypoints are blue balls, and the moving one is red instead.
While the minion is tracking the moving waypoint a tall purple cylinder will indicate the predicted position it's chasing.
The new MinionAI script can be found in Scripts/CharacterControl/.
The moving waypoint animation can be foundin Animations/.
The provied VelocityReporter can be found in Scripts/Utility/ and has been modified to actually work.
The minion is given a stopping distance of .5 and a look ahead time of 3 seconds, as well as some tweaks to speed an acceleration.
For prediction, the minion will not use prediction if the predicted position is off the navmesh, for simplicity, and because it seems to actually work really well.