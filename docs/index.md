# convay's game of life

## Overview
This project provide's a graphical implementation of [Convay's GameOfLife](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) (GOL). Written in C# with Visual Studio 2017, the GUI provides
easy costumizing of the GOL environment in a rather simple .NET Windows Forms setting. The GOL environment itself is drawn on a simple panel, 
no additional grapics libraries are utilized. The project was done in context of the current (Sept'17) it-talents.de challenge.

## Game Of Life
The GOL is an example for finite cellular automatons: In an environment of a predetermined size, cells can either live or not live. 
For a given start distribution of living cells, the next generation of cells can be simulated where each cell either dies or lives 
based on the number of neighbouring living/dead cells and a set of predefined rules. During successive updates, several situations can occur:

1. *All cells die*
2. *Cell develop certain static patterns together with neighbouring cells*
3. *Random (and possibly infinite) development of cells*

## Features
* Dynamic size of environment
* Automatic processing for 'infinite' amount of generations. Per each graphical update the number of generations to calculate can be set. The number of
updates to perform per second can be adjusted
* Profiling. Instead of showing currently living cells, for each cell the number of times a cell was alive during the previous updates can be shown as a simple
heatmap, thereby showing a profile of the so far calculated updates.
* Environment can be reduced to a non-infinite environment
* Different possibilities of start cell assignments, including random assignment of cells.
* **GOD**-mode. Anytime during the GOL life cycle, the user can simply click or click-drag with the left mouse button to toggle the cells below the mouse pointer*.

## Controls
Before each run, the current environment for the specified options needs to be initialized using the "Init" button in the GUI.
The following options in the GUI can be used to adjust the behaviour of the GameOfLife:

|control name|meaning|
|------|----|
|*size*|Size of the environment, i.e. dimension/number of cells to be used|
|*update interval*|The internval in which to perform a new update of the GOL|
|*generations per update*|Number of generations of the GOL to calculate per update cycle|
|*infinite environment*|Flag whether to use an infinite environment (default) or restrict the environment at the borders. For infinite environments, update rules will be calculated across borders|
|*initialization*|A start initilization to use. Compare WIKI entry for the currently possible options. Random initialization decides randomly for each cell whether it should be alive or dead|
|*probability of living cell*|For the random initialization, the probability with which a cell is set to be alive|
|*field color*|The color to be used for drawing the living cells|
|*bg color*|The background color, i.e. color for dead cells|
|*use gradient coloring*|Flag whether to calculate color values for each cell based on the number of neighbouring cells. The less cells, the lighter the color and vice versa|
|*random stained coloring*|Flag whether to use random colors for each cell in each update|
|*fixed colors*|Flag whether to assign random colors to all cells which should be kept throughout all updates|
|*flicker background*|Whether to flicker the background or not. This is not very pleasant to look at and rather... unnecessary.|
|*show profile*|Flag whether to show living/dead cell indicators or the summary profile over all updates so far|
|*next*|Perform one single update|
|*start*|Perform automatic updates in the specified interval until the field is empty (or infinitely...)|


*No cells are harmed during this process ;-)
