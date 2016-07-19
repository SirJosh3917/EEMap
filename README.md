# EEMap
Create maps that look like a world in EE with ease, programically!

# EEMap Documentation

## Introduction - What is EEMap?

EEMap is a library that adds a new control to your toolbox for making bots.
What it adds is a panel, that functions like a map of EE! You can use this
to view parts of a world, as if you were in EE.

## Usage - How do I use this?

Simple add in the DLL to your project, and you'll see a new control appear
in your toolbox, called an "EEMap". Simply drag this onto your form
anywhere you'd like. Now you have an EEMap, ready for usage!

## Guidelines - Are there any variables or stuff I have to do before this is functional for me?

Yes, all you need to do is initialize the map, and have two int variables,
one should be the RenderX, and one should be the RenderY. This is the
upper-left corner of the rendering position, and will be used to render the
map, and will be very important for proper usage.

## Initializing - How do I initialize the map?

####Step 1: Before everything begins

Before everything begins, you need to make sure you're using EEMap:

```
using EEWorldMap;
```

Next, you need to paste in this line of code after the form is loaded:

```
Block.GetBlockImage(1);
```

This line of code will initialize the BlockArray so the EEMap can easily get
a bitmap of any block ID at any time. Dont worry, this line of code applies
for all EEMaps, and only has to be written once.

#### Step 2: Choosing it's size

Initializing the map is easy. Once you create the map, drag out the map to
the size desired. Once the size is changed, the map might change its size a
little bit different from your desired size; this is so the map's width and
height are divisible by 16, therefore allowing blocks to perfectly fit in
it. Now the map is initialized in it's size, lets get on with the next step.

#### Step 3: Modifying the map's properties.

The map has it's own unique properties, that you will have to edit. Left
click on the map once, and click on "Properties", or press "F4". Click on the
properties tab, and scroll down untill you find the tab called "EEMap
Properties", these are the properties of the map. Change the map's size and
width to fit your needs.

## Events - How can I use the events this has?

If you want the player to be able to click somewhere on the map and place a
block, this is a tool that's built into the map. Left click on the map once,
and click on "Properties", or press "F4". Click on the "Events" tab, and
scroll down untill you see "EEMap Events". In "EEMap Events", there should
be a map event called "OnBlockDraw". In the box to the right of it, give
the event a name and press "Enter". You should be taken to the code of the
event. 

Now, paste in this code into the event:

```
int BlockLayer = 0;
int BlockID = 9;
eeMap1 = e.PlaceOnMap(BlockLayer, RenderX, RenderY, BlockID);
eeMap1.RenderBlockPlace(RenderX, RenderY, e.BlockX, e.BlockY);
```

What this code does, is tells the BlockDrawArgs to place a block where the
EEMap was clicked on, and then renders the block placement. But make sure
to take into consideration the following variables:

> BlockLayer BlockID RenderX RenderY e eeMap1

These are all variables that can differ depending on your code:
BlockLayer - The layer of the block to be placed on, 0 for the foreground,
	     1 for the background.

> BlockID - The ID of the block to be placed.

> RenderX - The X position of the upper-left corner where you're rendering.

> RenderY - The Y position of the upper-left corner where you're rendering.

> e - The BlockDrawArgs parameter of when the OnBlockDraw event is fired.

> eeMap1 - The EEMap that is in use.

You can change these variables to modify your needs if you want to.

## Render - How can I make the map show up?

Yes there is. As you may have noticed if you are using EEMap, nothing shows
up. That's because you need to render it, using Render(int xUpperLeftCorner,
int yUpperLeftCorner). Render() allows you to render the map at the upper-left
X position corner, and the upper-left Y position corner. Render() shouldn't be
called alot, however if you are changing your point of view, it needs to be
called on. However if you are just placing one block, dont re-render the
entire thing, just render the block, by calling RenderBlockPlace(int xUpperLeft,
int yUpperLeft, int blockX, int blockY). RenderBlockPlace() renders only one
block being placed on the map.

You should also know that there is a way to programmically
place blocks. Inside your EEMap, there is a uint[,,] MapBlocks that you can
change blocks from there, and re-render the map if you wanted to.

## Is there any more information I should know about?

Yes, theres quite a bit, but stay put, I'll write more about it soon.
