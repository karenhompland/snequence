# Snequence !

![Snequence Logo](./Assets/Images/snequence-logo.png)

Snequence is a mobile game developed in Unity for the subject CSC4027Z Game Design at UCT.

## Game Screenshots

![start screen](https://user-images.githubusercontent.com/70148072/196153099-c334d428-5472-4c06-8350-bbf44f1201f0.png)

![game screen](https://user-images.githubusercontent.com/96382311/196655873-d495ce2f-590d-4477-a3b5-006bf3935e93.png)


## Building and running with Xcode simulator

It is reccommended to run the game using the IOS platform device in Unity, as opposed to the game engine one, as the game is designed to be manouvred with touch functionality. The snake won´t be able to be swiped if it is not run with a simulator engine.
Make sure you have the IOS platform downloaded in unity. This can be done from Unity Hub, under Installs.
After cloning the repo, open the game in Unity engine.
Open Build Settings (cmd shift B) and select IOS. Go to you project settings and select "other settings".
Underneath "target SDK", make sure Simulator SDK is selected. It should be already in the project settings from the pull.

After building, open the hierarchy in Xcode and select unity-iphone. Go to build settings and make sure the ENABLE_BITCODE field is set to 'NO'.

Snequence is then ready to build and run!
We reccommend using a simulator made after 2019, like the iphone 11. :)

## Game concept

Snequence is a combination of the classic games snake and color sequence. The objective of the game is to steer the snake around by swiping the screen to collect the colored orbs.
In order to advance in the game, the snake needs to eat the correct sequence of colors. This sequence is shown at the top of the screen.

### Power-ups and obstacles

<img src="https://user-images.githubusercontent.com/70148072/196148188-8012f994-9f49-4d7f-98b1-f2de33b386cf.png" width="200"/>

**Heart**

Gives the snake an extra life to survive one bomb. 

<img src="https://user-images.githubusercontent.com/70148072/196148325-874d2394-323b-483f-bcbc-9ebc21e96867.png" width="200"/>

**Bomb**

Explodes, killing the snake. This results in Game Over.

<img src="https://user-images.githubusercontent.com/70148072/196148526-cbbd6d8a-97c7-42d7-a1e9-4d9e9e89a29e.png" width="200"/>

**Faster**

Makes the snake go faster for a short period of time.

<img src="https://user-images.githubusercontent.com/70148072/196148693-1eeb2cc4-e312-4dbc-b3a2-98ad44b9cbe3.png" width="200"/>


**Slo-Mo**

Makes the snake go slower for a short period of time.

<img src="https://user-images.githubusercontent.com/70148072/196148793-54891d87-6e4f-448b-bb16-bf21c9b7ca8f.png" width="200"/>


**Clock**

Adds ten seconds to the timer.

<img src="https://user-images.githubusercontent.com/70148072/196148903-e86a1d7e-eb64-4b41-9c95-54e507882f2e.png" width="200"/>

**Bush**

Hitting a bush will result in game over.

## Contributions

All group members contributed with developing the game in Unity.

Additionally:

**Karen Hompland:** Animations, logo design

**Ingrid Hagen:** Sound design

**Solveig Aune:** Game element design

Game elements are designed with Blender and texturized in Unity.

## Sound Effects
### Our sound effect are downloaded from Pixabay

**Sequence Complete**: short-success-sound-glockenspiel-treasure-video-game-6346.mp3

**Game over** : negative_beeps-6008.mp3

**Remove Heart** : glass-bottle-shatter-13847.mp3

**Add Heart** : cartoon_wink_magic_sparkle-6896.mp3

**Eat and click** : click-21156.mp3

**Bomb** : failure-drum-sound-effect-2-7184.mp3

### Our background music is downloaded from Jamendo

**Background Music** : Blue Jay Studio - Video Game Background 3



