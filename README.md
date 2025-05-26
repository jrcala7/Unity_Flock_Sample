# Simple Flock using Unity

This project simulates a simple flock behavior using Unity.

## Instructions

Run the Main Scene to start and move the leader object around to simulate the flock following the leader.

[Sample Demo GIF](Imgs/SampleFollow.gif)

## Explination

This simulates a flock by using the following rules:

### Neighbors

A Neighbor is defined by getting every agent / entity within a set radius

[Neighbors Radius](Imgs/NeighborRadius.png)

### Alignment Rule

An agent should move in the general direction as its neighbors.
This is the average of all velocities of its neighbors

### Cohesion Rule

An agent should be within the its neighbors.
This is the average of the positions of its neighbors and compute the velocity to reach it.

### Separation Rule

An agent should not get too close to its neighbors
The agent should be at a minimum distance to the average positions of its neighbors and compute the velocity to it.

Afterwhich a user defined ratio is applied to the velocities derived using the 3 rules and is set as the current velocity of the agent.

[Sample Run](Imgs/SampleStart.gif)