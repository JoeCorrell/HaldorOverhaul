<div align="center">

# 🛒 Haldor Trading Overhaul

**Transform Haldor into the ultimate merchant with full buy/sell functionality and a personal bank**

[![Version](https://img.shields.io/badge/Version-1.0.14-blue?style=for-the-badge)](https://github.com/JoeCorrell/HaldorOverhaul/releases)
[![BepInEx](https://img.shields.io/badge/BepInEx-5.4.2200+-orange?style=for-the-badge)](#-requirements)
[![Items](https://img.shields.io/badge/Items-590+-green?style=for-the-badge)](#)

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

## ✨ Features

Browse and buy over 590 items from Haldor, organized by category with real-time search. Sell your unwanted gear directly back to him at 30% of the buy price. Items unlock progressively as you defeat bosses, keeping the economy tied to your progression. All item lists and prices are driven by JSON config files you can edit freely, and a Python script is included to regenerate them from scratch.

The mod has full controller support. Use LB/RB to switch panels, D-Pad or left stick to navigate, A to confirm, X to toggle categories, and B to close. Everything is mapped and works seamlessly alongside the mouse.

---

## 🏦 Bank

Haldor acts as your personal banker. Your bank balance funds all purchases. When you buy something, the cost is deducted from the bank, and when you sell, the proceeds go straight in.

To access the bank, open the shop at Haldor and click the **Bank** tab. Use **Deposit** to move coins from your inventory into the bank, and **Withdraw** to take them back out.

---

## 🤝 Compatible Mods

<p align="center">
<img src="https://raw.githubusercontent.com/JoeCorrell/HaldorOverhaul/main/Screenshots/BowsBeforeHoes.png" alt="Bows Before Hoes" width="300"/>
</p>

**[Bows Before Hoes](https://thunderstore.io/c/valheim/p/Azumatt/BowsBeforeHoes/)** by Azumatt — Full buy and sell support for all items added by this mod. Prices are calculated from crafting recipes using the same ingredient-based system as vanilla items.

| Item | Type | Biome |
|------|------|-------|
| BBH_BlackForest_Bow | Bow | Black Forest |
| BBH_Surtling_Bow | Bow | Swamp |
| BBH_Seeker_Bow | Bow | Mistlands |
| BBH_BlackForest_Quiver | Quiver | Black Forest |
| BBH_PlainsLox_Quiver | Quiver | Plains |
| BBH_Seeker_Quiver | Quiver | Mistlands |
| BBH_OdinPlus_Quiver | Quiver | Ashlands |
| TorchArrow | Arrow (×20) | No boss required |
| SeekerArrow | Arrow (×20) | Ashlands |
| MistTorchArrow | Arrow (×20) | Ashlands |

The prebuilt config files already include all BowsBeforeHoes items. Simply install BowsBeforeHoes alongside this mod and the items will appear in Haldor's shop automatically.

---

## 📦 Installation

Install BepInEx, then download the latest release and extract it to `BepInEx/plugins/HaldorOverhaul/`. Move the two config files (`HaldorOverhaul.haldor.buy.json` and `HaldorOverhaul.haldor.sell.json`) to `BepInEx/config/`, then launch Valheim.

---

## ⚙️ Configuration

Two JSON files control what Haldor buys and sells. `buy.json` lists items he sells to you; `sell.json` lists items you can sell to him. Each entry looks like this:

```json
{
  "item_prefab": "SwordIron",
  "item_quantity": 1,
  "item_price": 4234,
  "must_defeated_boss": "defeated_gdking"
}
```

Leave `must_defeated_boss` empty to make an item always available. Run `generate.py` to regenerate both files from scratch using the built-in pricing system.

---

## 🙏 Credits

**This is my first Valheim mod! I really hope people enjoy it.**

Inspired by [shudnal's TradersExtended](https://thunderstore.io/c/valheim/p/shudnal/TradersExtended/) · Item data sourced from the [Jotunn Library](https://valheim-modding.github.io/Jotunn/)

[![GitHub](https://img.shields.io/badge/GitHub-Issues-181717?style=for-the-badge&logo=github)](https://github.com/JoeCorrell/HaldorOverhaul/issues)
[![Discord](https://img.shields.io/badge/Discord-@profmags-5865F2?style=for-the-badge&logo=discord&logoColor=white)](https://discord.com)

*Made with ❤️ for the Valheim community*

</div>
