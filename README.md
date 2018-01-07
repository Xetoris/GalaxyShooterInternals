# GalaxyShooterInternals
Internal logic dll + tests for Galaxy Shooter tutorial project.

### Summary

I'm going through a course on Udemy about creating a basic Unity 2D shooter. This project has the extracted game logic (w/o Unity MonoBehavior bindings).

The dream:
* Basic game code (as much as I can separate from Mono specific behavior) is maintained in this library.
* This library keeps a set of unit tests for testing just the logic of each component.
* The DLL is built and included as a resource in the Unity project itself.

The actual unity project has some assets associated with it that came with the course, so I will not be uploading it to a public repository.


### Notes

The two dll's in libs/ came from my local Unity install. If you want to know more about them, I suggest you take a look at the Unity scripting reference. 2018.1's beta documentation in particular is pretty great for finding where things are referenced: 

https://docs.unity3d.com/2018.1/Documentation/ScriptReference/index.html