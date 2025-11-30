# Time Machine

This is a project i thought of a few years ago but never got round to it, i've always been a fan of victorian science fiction and one of my favorites is "The Time Machine" by H.G Wells, and it's 1960 movie adaption by George Pal, the machine is a lovely piece of steampunk engineering, and while models do exist, i could never find any sort of software simulation in a similar vein to the ones that simulate the time circuits from BTTF, so this is my answer that.

A lot of is vibe coded and written in VB.NET so the code might not be ideal.

I should also point out that this project is NOT affiliated with H.G Wells, George Pal or The Time Machine, i claim fair use on the background image used in the software itself, the icon is from the novels original cover and afaik it's in the public domain.

## Instructions

## To build

Download visual studio, pull the latest branch (which should be v1.0.1.1, i have deleted all the early expiremental versions), you can build/publish using the dotnet CLI or build and run directly in VS.

## Using it

When opened the software asks for your starting time, i.e the time the machine will display, it's coded so that the format has a leading zero for days but it doesn't matter how you enter it, if you click ok on the default strings it will use the current PC time.

The operation is the same as in the movie, albeit the lever is now a trackbar, forward sends you forward in time, backward sends you back in time, it's also possible to stop time.

The Day/Month/Year lights will illuminate when approaching the end of a Day, Month or Year.

Clicking the nameplate brings up a settings window where you can toggle various elements and reset the time to current, useful if you got lost! you can also find the about box here.

## Known Problems

* "Timer" elements are used and as such the machines "clock" will not keep good time if left running

* It's not possible to visit eloi, that's because eloi live in 802,701 and this machine caps out at 9999, that's a limitation of how windows handles date fields, the maximum year is 9999.

* The font (Bodoni) is not quite true to the film

* The month windows displays the date in numerical film, not a truncated month name (e.g Dec) as in the film

* At the highest speeds the lights the condition for the lights is rarely met and thus they flicker randomly


