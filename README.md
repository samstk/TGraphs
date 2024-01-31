# TGraphs
## Summary
A simple plotting / simulation program using C# and WPF and can be used as a sandbox for game paths (such as rotating around an origin).

## Progress
The program is nearly completed, however current code can be used as a proof-of-concept.

## Definitions
### T-Value
Just a value on the x-axis. The aim is that the x-variable is actually time.

## Current Features
* Each scene has a number of instances (or expressions).
* Each 'expression' is compiled using the Roselyn API, and then rendered onto the graph view.
* Whilst the front-end of the app does not support changing certain design properties such as Render Step, they are implemented in the model. This can be changed within any saved scene.
* Minor adjusting features of the graph.

## Planned Features
* T-Value animations (at the moment, all T-Values are shown as specified by T-Min and T-Max).
* Design Options (Color, Dotted Lines, End of Line Graphics - e.g. square)
