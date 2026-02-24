# Changelog

## 1.0.18
- Fixed custom trader UI to only apply to Haldor — other traders (Hildir, modded NPCs) now use the vanilla StoreGui, resolving mod compatibility conflicts with any mod that adds its own traders

## 1.0.17
- ui improvements

## 1.0.16
- Removed boss progression gates from treasure sell items (Amber, AmberPearl, Ruby, SilverNecklace, GoldRuby) — players can now sell treasure to Haldor at any point in the game

## 1.0.15
- Custom UI sprites for search bar and category buttons (SearchBarBackground.png, CategoryBackground.png)
- Fixed item category classification to use direct enum comparison instead of string matching
- Fixed panel tinting — panels now use a clean grey tint instead of brownish sprite-based coloring
- Fixed TMP font warnings by deferring TextMeshProUGUI initialization until font is assigned
- Updated category button icons (bronze axe, troll leather helmet, wooden shield, stamina mead, bronze)
- Grey tint overlay on Buy/Sell action button to match panel styling

## 1.0.14
- Added BowsBeforeHoes mod support — 10 items (3 bows, 4 quivers, 3 arrows) added to buy and sell configs with recipe-based pricing
- Doubled list panel scroll speed

## 1.0.13
- Fixed standalone bank UI cursor being locked when opened with Z key
- Fixed bank UI not registering as a store UI, causing camera and input issues
- Removed Z key shortcut for bank — bank is now only accessible through the trader UI
- Added full controller support to the standalone bank panel

## 1.0.12
- Version bump

## 1.0.11
- Removed CurrencyPocket dependency

## 1.0.10
- Version bump

## 1.0.9
- Added Haldor's Bank system — bank balance funds all purchases, selling deposits directly to bank
- Added Bank tab to the trader UI and standalone bank panel (Z key)
- Added `setbankbalance` console command (fixed registration so it now works in-game)
- Reverted bank panel to clean text layout
- Various bug fixes and performance improvements

## 1.0.8
- Fixed controller navigation issues with item list scrolling and selection highlighting
- Fixed controller unable to select category headers to expand/collapse them
- Fixed scroll position not resetting when switching between tabs
- Fixed various UI bugs and layout issues
- Suppressed Haldor's random talk bubbles while trading UI is open
- Added `setcoins` console command for testing
- Updated UI design

## 1.0.7
- Updated UI
- Bug fixes

## 1.0.6
- Updated UI design
- Updated price generator script
- Updated config files
- Various bug fixes

## 1.0.5
- Added JsonDotNET and CurrencyPocket as required dependencies

## 1.0.4
- Updated dependency configuration

## 1.0.3
- Added capes to buy menu

## 1.0.2
- Updated README.md

## 1.0.1
- Updated README.md

## 1.0.0
- Initial release
