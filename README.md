# Space-Strategy
A simple Unity 2D game inspired by old flash games.

Prototype available on https://squeakums.itch.io/planet-rush

Intended to run on a computer browser, mobile compatibility not yet implemented.

Layout:
Friendly planets are shown in green. Neutral planets are yellow. Enemy planets are red.
Each planet has its own starting population value and growth value. For the first level, green and red each have one planet with growth 2. Every other planet is growth 1.
Yellow planets all start with growth 0, which converts to growth 1 when green or red take over.
Take over a planet by mobilizing population from an adjacent planet. If you drop the target planet population to zero, ownership switches to you.
Take over all planets on the map to win.

Controls:
Select a friendly planet with left click. You will see a targeting reticle to show the currently selected planet.
Adjacent planets have a colored outline around them. Right click an adjacent planet to move half the population of the selected planet towards it.
