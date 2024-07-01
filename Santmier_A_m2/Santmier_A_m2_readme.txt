Name: Allen Santmier
Email: asantmier3@gatech.edu
Canvas: Allen Bailey Santmier

Main Scene: demo

A new script called BallCollisionReporter under Scripts/AppEvents has been added for the blue ball sfx. The red balls have this script as well, by the way.
The kitsune mask compound collision is done with a bunch of capsules and boxes and works reliably in my testing.
The top ball of the chain is fixed and the 5 balls attached to it are set up to act like a chain.
The elevator works exactly as described in the pdf and video. The Weeble Wobble is a green capsule wobbling over to the right. 
Green and any other colored materials that weren't provided are made with the same properties as the given materials.
The physic material objects have all been placed on or by the ramp.
The ragdoll's colliders have been adjusted to fit it better and is placed above a hurdle so that it'll flop over it.
A new script called JumpingBean under Scripts/CharacterControl has been added for the jumping bean. It has a tendency to roll off screen, but its values have been configured
to try and keep it on screen as much as possible and still be able to jump.
A new script has been added at Scripts/Utility/PauseSimulation and attached to the object Pauser for auto-pausing the game and controlling it with 'P'.