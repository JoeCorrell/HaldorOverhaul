<div align="center">

# 🛒 Haldor Trading Overhaul

**Transform Haldor into the ultimate merchant with full buy/sell functionality and a personal bank**

`580+ Items` · `Recipe-Based Pricing` · `Full Controller Support` · `Built-in Bank`

[![Version](https://img.shields.io/badge/Version-1.0.11-blue?style=for-the-badge)](https://github.com/JoeCorrell/HaldorOverhaul/releases)
[![BepInEx](https://img.shields.io/badge/BepInEx-5.4.2200+-orange?style=for-the-badge)](#-requirements)
[![Items](https://img.shields.io/badge/Items-580+-green?style=for-the-badge)](#)

---

<p align="center">
<img src="https://raw.githubusercontent.com/JoeCorrell/HaldorOverhaul/main/Screenshots/Buy.png" alt="Buy Tab" width="600"/>
</p>

<p align="center">
<img src="https://raw.githubusercontent.com/JoeCorrell/HaldorOverhaul/main/Screenshots/Sell.png" alt="Sell Tab" width="600"/>
</p>

<p align="center">
<img src="https://raw.githubusercontent.com/JoeCorrell/HaldorOverhaul/main/Screenshots/Bank.png" alt="Bank Tab" width="600"/>
</p>

---

[Features](#-features) · [Bank](#-bank) · [Installation](#-installation) · [Configuration](#-configuration) · [Pricing](#-pricing-system) · [Troubleshooting](#-troubleshooting)

---

</div>

## ✨ Features

| | | | | |
|:---:|:---:|:---:|:---:|:---:|
| **🛒 Trading** | **🔍 Search** | **📂 Categories** | **🎮 Controller** | **🏦 Bank** |
| Buy & Sell System | Real-time Filtering | Organized Browsing | Full Gamepad Support | Personal Coin Vault |
| 580+ Tradeable Items | Persistent Focus | Collapsible Sections | Seamless Switching | Deposit & Withdraw |
| JSON-Driven Configs | Both Panels | Visual Item Icons | D-Pad Navigation | Bank-Funded Purchases |
| Boss Progression | Instant Results | Quick Navigation | All Actions Mapped | Z Key Shortcut |

| | |
|:---:|:---:|
| **⚙️ Technical** | **💎 Balanced Economy** |
| Reflection-based for update resilience | Recipe-based pricing ensures fair values |
| No hard dependencies on internal types | Biome-tier progression (Meadows → Ashlands) |
| Auto config generation on first run | Category multipliers for item types |
| Hot-reloadable JSON configurations | Rarity overrides for special items |

---

## 🏦 Bank

Haldor keeps your coins safe. The bank is central to trading — **your bank balance funds all purchases**, and selling items deposits directly into the bank.

### How It Works

| Action | Result |
|:---|:---|
| **Deposit** | Moves all inventory coins into your bank |
| **Withdraw** | Moves all bank coins into your inventory |
| **Buy item** | Deducted from your bank balance |
| **Sell item** | Added directly to your bank balance |

> ⚠️ **You must have coins in the bank to buy items.** Walk up to Haldor with coins in your inventory, open the Bank tab, and deposit before shopping.

### Accessing the Bank

- **At Haldor** — Open the shop and click the **Bank** tab (or use D-Pad right on controller)
- **Anywhere** — Press **Z** to open the standalone bank panel at any time

### Console Command

```
setbankbalance 5000
setbankbalance = 5000
```

Enable the console with `-console` in your Steam launch options (F5 in-game).

---

## 🎮 Controller Support

| LB / RB | D-Pad / Stick | X | A | B |
|:---:|:---:|:---:|:---:|:---:|
| Switch Panels | Navigate Items / Bank Buttons | Toggle Category | Buy / Sell / Confirm | Close UI |

---

## 📋 Requirements

| Requirement | Version | Notes |
|:---:|:---:|:---|
| **Valheim** | Latest | PC Version |
| **BepInEx** | 5.4.2200+ | [Download Here](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/) |
| **JsonDotNET** | 13.0.4 | [Download Here](https://thunderstore.io/c/valheim/p/ValheimModding/JsonDotNET/) |

---

## 📦 Installation

| Step | Action |
|:---:|:---|
| **1** | Install BepInEx for Valheim |
| **2** | Download the latest release |
| **3** | Extract to `BepInEx/plugins/HaldorOverhaul/` |
| **4** | Move config files to `BepInEx/config/` |
| **5** | Launch Valheim and enjoy! |

> 💡 **Config files included!** Just move `HaldorOverhaul.haldor.buy.json` and `HaldorOverhaul.haldor.sell.json` to your config folder, or run `generate.py` to create custom configs.

<details>
<summary><b>📁 File Structure</b></summary>

```
BepInEx/
├── plugins/
│   └── HaldorOverhaul/
│       ├── HaldorOverhaul.dll
│       ├── manifest.json
│       └── README.md
└── config/
    ├── HaldorOverhaul.haldor.buy.json
    └── HaldorOverhaul.haldor.sell.json
```

</details>

---

## ⚙️ Configuration

| Config File | Purpose |
|:---|:---:|
| `HaldorOverhaul.haldor.buy.json` | Items Haldor sells to you |
| `HaldorOverhaul.haldor.sell.json` | Items you can sell to Haldor |

<details>
<summary><b>📝 Entry Format</b></summary>

```json
{
  "item_prefab": "SwordIron",
  "item_quantity": 1,
  "item_price": 4234,
  "must_defeated_boss": "defeated_gdking"
}
```

| Field | Description |
|:---|:---|
| `item_prefab` | Internal item name (must match exactly) |
| `item_quantity` | Stack size per transaction |
| `item_price` | Price in coins |
| `must_defeated_boss` | Boss key required (empty = always available) |

</details>

<details>
<summary><b>🏆 Boss Keys</b></summary>

| Boss | Key |
|:---|:---|
| Eikthyr | `defeated_eikthyr` |
| The Elder | `defeated_gdking` |
| Bonemass | `defeated_bonemass` |
| Moder | `defeated_dragon` |
| Yagluth | `defeated_goblinking` |
| The Queen | `defeated_queen` |
| Fader | `defeated_fader` |

</details>

---

## 💰 Pricing System

### Biome Multipliers

| Biome | Mult | Boss Required |
|:---|:---:|:---:|
| Meadows | 1.5x | — |
| Black Forest | 2.75x | Eikthyr |
| Swamp | 4.5x | The Elder |
| Mountain | 7.5x | Bonemass |
| Plains | 12x | Moder |
| Mistlands | 20x | Yagluth |
| Ashlands | 32x | The Queen |
| Deep North | 50x | Fader |

<details>
<summary><b>📊 Category Multipliers</b></summary>

| Category | Mult | Category | Mult |
|:---|:---:|:---|:---:|
| **Weapons** | | **Materials** | |
| Two-Handed | 1.3x | Common | 0.8x |
| One-Handed | 1.0x | Rare | 1.5x |
| Staves | 1.35x | Boss Drops | 2.5x |
| Crossbows | 1.25x | | |
| Bows | 1.1x | **Trophies** | |
| | | Boss | 3.0x |
| **Armor** | | Rare | 1.3x |
| Heavy | 1.35x | Common | 0.9x |
| Light | 1.2x | | |
| Capes | 0.85x | **Other** | |
| Shields | 0.9x | Keys | 2.0x |
| | | Tools | 0.8x |
| **Consumables** | | Cosmetic | 0.7x |
| Cooked | 1.0x | | |
| Raw | 0.7x | | |
| Meads | 1.2x | | |
| Ammo | 1.0x | | |

</details>

<details>
<summary><b>💎 Rarity Overrides</b></summary>

| Item | Mult | Item | Mult |
|:---|:---:|:---|:---:|
| HardAntler | 2.0x | Chain | 1.8x |
| CryptKey | 2.2x | SurtlingCore | 1.6x |
| Wishbone | 2.0x | Ectoplasm | 1.4x |
| DragonTear | 2.0x | BlackCore | 1.7x |
| DragonEgg | 2.5x | Eitr | 1.8x |

</details>

### Key Constants

| Setting | Value |
|:---|:---:|
| Sell Ratio | 30% of buy price |
| Craft Markup | 15% on crafted items |
| Min Price | 5 coins |
| Max Price | 99,999 coins |

---

## 📊 Sample Prices

### Materials

| Material | Buy | Sell | Biome |
|:---|---:|---:|:---:|
| Wood | 5 | 1 | Meadows |
| Bronze | 105 | 31 | Black Forest |
| Iron | 144 | 43 | Swamp |
| Silver | 180 | 54 | Mountain |
| Black Metal | 336 | 100 | Plains |
| Eitr | 3,510 | 1,053 | Mistlands |
| Flametal | 972 | 291 | Ashlands |

### Weapons

| Weapon | Buy | Biome |
|:---|---:|:---:|
| Flint Axe | 54 | Meadows |
| Bronze Sword | 676 | Black Forest |
| Iron Sword | 4,234 | Swamp |
| Silver Sword | 12,232 | Mountain |
| Blackmetal Sword | 10,920 | Plains |
| Mistwalker | 31,220 | Mistlands |
| THSwordSlayer | 67,891 | Ashlands |

---

## 🔧 Price Generator

```bash
python generate.py                      # Default - Steam config folder
python generate.py "C:\custom\path"     # Custom output directory
```

<details>
<summary><b>🔄 How It Works</b></summary>

| Stage | Description |
|:---|:---|
| **Data Sources** | Fetches from Jotunn Item & Recipe lists |
| **Raw Materials** | `base × biome × category × rarity` |
| **Crafted Items** | `ingredients × markup × biome × category × rarity` |
| **Output** | `buy.json` (579 items) + `sell.json` (593 items) |

</details>

---

## 🎨 Customization

<details>
<summary><b>Adding Items</b></summary>

```python
'ItemPrefab': (Biome.TIER, base_price, stack_size, sell_only),
```

</details>

<details>
<summary><b>Excluding Items</b></summary>

```python
HILDA_EXCLUSIVES = {'ArmorDress1', 'ArmorTunic1'}
EXCLUDED_PATTERNS = [r'^Bow_projectile', r'^fx_']
```

</details>

<details>
<summary><b>Adjusting Prices</b></summary>

```python
SELL_MULTIPLIER = 0.30
CRAFTING_MARKUP = 1.15
CATEGORY_MULTIPLIERS = {'weapon_2h': 1.3}
RARITY_OVERRIDES = {'Chain': 1.8}
```

</details>

---

## 🔍 Troubleshooting

| Issue | Solutions |
|:---|:---|
| **Items not appearing** | Check `item_prefab` name · Verify boss defeated · Validate JSON syntax |
| **Wrong prices** | Re-run `generate.py` · Check `ITEM_DATABASE` · Verify ingredients |
| **Script errors** | Install Python 3.x · Check internet connection · Try custom path |
| **Can't buy items** | Deposit coins into the Bank tab first — bank balance funds all purchases |
| **`setbankbalance` not found** | Enable console with `-console` in Steam launch options, then press F5 |

---

## 🙏 Credits

<div align="center">

**This is my first Valheim mod! I really hope people enjoy it.**

| Inspiration | Data Source |
|:---:|:---:|
| [shudnal's TradersExtended](https://thunderstore.io/c/valheim/p/shudnal/TradersExtended/) | [Jotunn Library](https://valheim-modding.github.io/Jotunn/) |

---

## 📬 Contact

[![GitHub](https://img.shields.io/badge/GitHub-Issues-181717?style=for-the-badge&logo=github)](https://github.com/JoeCorrell/HaldorOverhaul/issues)
[![Discord](https://img.shields.io/badge/Discord-@profmags-5865F2?style=for-the-badge&logo=discord&logoColor=white)](https://discord.com)

---

Made with ❤️ for the Valheim community

</div>
