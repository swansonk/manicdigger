﻿using System;
using System.Collections.Generic;
using System.Text;
using ManicDigger.Collisions;

namespace ManicDigger
{
    public class GameDataTilesMinecraft : IGameData
    {
        public GameDataTilesMinecraft()
        {
            MakeData();
        }
        public byte TileIdEmpty
        {
            get { return (byte)TileTypeMinecraft.Empty; }
        }
        public byte TileIdGrass
        {
            get { return (byte)TileTypeMinecraft.Grass; }
        }
        public byte TileIdDirt
        {
            get { return (byte)TileTypeMinecraft.Dirt; }
        }
        public int GetTileTextureId(int tileType, TileSide side)
        {
            if (side == TileSide.Top) { return data[tileType].TextureTop; }
            if (side == TileSide.Bottom) { return data[tileType].TextureBottom; }
            return data[tileType].TextureSide;
        }
        public int[] DefaultMaterialSlots
        {
            get
            {
                var slots = new List<int>();
                slots.Add((int)TileTypeMinecraft.Dirt);
                slots.Add((int)TileTypeMinecraft.Stone);
                slots.Add((int)TileTypeMinecraft.Cobblestone);
                slots.Add((int)TileTypeMinecraft.Wood);
                slots.Add((int)TileTypeMinecraft.Sand);
                slots.Add((int)TileTypeMinecraft.Gravel);
                slots.Add((int)TileTypeMinecraft.Leaves);
                slots.Add((int)TileTypeMinecraft.Stair);
                slots.Add((int)TileTypeMinecraft.Glass);
                slots.Add((int)TileTypeMinecraft.Sponge);
                return slots.ToArray();
            }
        }
        public byte GoldTileId
        {
            get { return (int)TileTypeMinecraft.GoldOre; }
        }
        #region IGameData Members
        public int TileIdStone
        {
            get { return (int)TileTypeMinecraft.Stone; }
        }
        public int TileIdWater
        {
            get { return (int)TileTypeMinecraft.Water; }
        }
        public int TileIdSand
        {
            get { return (int)TileTypeMinecraft.Sand; }
        }
        public bool IsWaterTile(int tiletype)
        {
            return tiletype == (int)TileTypeMinecraft.Water
                || tiletype == (int)TileTypeMinecraft.InfiniteWaterSource;
        }
        #endregion
        #region IGameData Members
        public bool IsBuildableTile(int tiletype)
        {
            if (!IsValidTileType(tiletype)) { throw new ArgumentException(); }
            //if (tiletype == 41) { return false; }//?
            //if (tiletype == 29) { return false; }//?
            return data[tiletype].Buildable;
        }
        #endregion
        public bool IsValidTileType(int tiletype)
        {
            return data[tiletype] != null;
        }
        void MakeData()
        {
            data[(int)TileTypeMinecraft.Stone] = new TileTypeData() { Buildable = true, AllTextures = 1 };
            data[(int)TileTypeMinecraft.Grass] = new TileTypeData()
            {
                Buildable = false,
                TextureBottom = 2,
                TextureSide = 3,
                TextureTop = 0,
            };
            data[(int)TileTypeMinecraft.Dirt] = new TileTypeData() { Buildable = true, AllTextures = 2 };
            data[(int)TileTypeMinecraft.Cobblestone] = new TileTypeData() { Buildable = true, AllTextures = (1 * 16) + 0 };
            data[(int)TileTypeMinecraft.Wood] = new TileTypeData() { Buildable = true, AllTextures = 4 };
            data[(int)TileTypeMinecraft.Sapling] = new TileTypeData() { Buildable = true, AllTextures = 15 }; //special
            data[(int)TileTypeMinecraft.Adminium] = new TileTypeData() { Buildable = true, AllTextures = (1 * 16) + 1 };
            data[(int)TileTypeMinecraft.Water] = new TileTypeData() { Buildable = false, AllTextures = 14 };
            data[(int)TileTypeMinecraft.StationaryWater] = new TileTypeData() { Buildable = false, AllTextures = 14 };
            data[(int)TileTypeMinecraft.Lava] = new TileTypeData() { Buildable = false, AllTextures = (1 * 16) + 15 };
            data[(int)TileTypeMinecraft.StationaryLava] = new TileTypeData() { Buildable = false, AllTextures = (1 * 16) + 15 };
            data[(int)TileTypeMinecraft.Sand] = new TileTypeData() { Buildable = true, AllTextures = (1 * 16) + 2 };
            data[(int)TileTypeMinecraft.Gravel] = new TileTypeData() { Buildable = true, AllTextures = (1 * 16) + 3 };
            data[(int)TileTypeMinecraft.GoldOre] = new TileTypeData() { Buildable = false, AllTextures = (2 * 16) + 0 };
            data[(int)TileTypeMinecraft.IronOre] = new TileTypeData() { Buildable = false, AllTextures = (2 * 16) + 1 };
            data[(int)TileTypeMinecraft.CoalOre] = new TileTypeData() { Buildable = false, AllTextures = (2 * 16) + 2 };
            data[(int)TileTypeMinecraft.TreeTrunk] = new TileTypeData()
            {
                Buildable = true,
                TextureTop = (1 * 16) + 5,
                TextureBottom = (1 * 16) + 5,
                TextureSide = (1 * 16) + 4,
            };
            data[(int)TileTypeMinecraft.Leaves] = new TileTypeData() { Buildable = true, AllTextures = (1 * 16) + 6 };
            data[(int)TileTypeMinecraft.Sponge] = new TileTypeData() { Buildable = true, AllTextures = (3 * 16) + 0 };
            data[(int)TileTypeMinecraft.Glass] = new TileTypeData() { Buildable = true, AllTextures = (3 * 16) + 1 };
            data[(int)TileTypeMinecraft.RedCloth] = new TileTypeData() { Buildable = true, AllTextures = 64 };
            data[(int)TileTypeMinecraft.RedCloth + 1] = new TileTypeData() { Buildable = true, AllTextures = 64 + 1 };
            data[(int)TileTypeMinecraft.RedCloth + 2] = new TileTypeData() { Buildable = true, AllTextures = 64 + 2 };
            data[(int)TileTypeMinecraft.RedCloth + 3] = new TileTypeData() { Buildable = true, AllTextures = 64 + 3 };
            data[(int)TileTypeMinecraft.RedCloth + 4] = new TileTypeData() { Buildable = true, AllTextures = 64 + 4 };
            data[(int)TileTypeMinecraft.RedCloth + 5] = new TileTypeData() { Buildable = true, AllTextures = 64 + 5 };
            data[(int)TileTypeMinecraft.RedCloth + 6] = new TileTypeData() { Buildable = true, AllTextures = 64 + 6 };
            data[(int)TileTypeMinecraft.RedCloth + 7] = new TileTypeData() { Buildable = true, AllTextures = 64 + 7 };
            data[(int)TileTypeMinecraft.RedCloth + 8] = new TileTypeData() { Buildable = true, AllTextures = 64 + 8 };
            data[(int)TileTypeMinecraft.RedCloth + 9] = new TileTypeData() { Buildable = true, AllTextures = 64 + 9 };
            data[(int)TileTypeMinecraft.RedCloth + 10] = new TileTypeData() { Buildable = true, AllTextures = 64 + 10 };
            data[(int)TileTypeMinecraft.RedCloth + 11] = new TileTypeData() { Buildable = true, AllTextures = 64 + 11 };
            data[(int)TileTypeMinecraft.RedCloth + 12] = new TileTypeData() { Buildable = true, AllTextures = 64 + 12 };
            data[(int)TileTypeMinecraft.RedCloth + 13] = new TileTypeData() { Buildable = true, AllTextures = 64 + 13 };
            data[(int)TileTypeMinecraft.RedCloth + 14] = new TileTypeData() { Buildable = true, AllTextures = 64 + 14 };
            data[(int)TileTypeMinecraft.RedCloth + 15] = new TileTypeData() { Buildable = true, AllTextures = 64 + 15 };//36
            data[(int)TileTypeMinecraft.YellowFlowerDecorations] = new TileTypeData() { Buildable = false, AllTextures = 13 };
            data[(int)TileTypeMinecraft.RedRoseDecorations] = new TileTypeData() { Buildable = false, AllTextures = 12 };
            data[(int)TileTypeMinecraft.RedMushroom] = new TileTypeData() { Buildable = false, AllTextures = 28 };
            data[(int)TileTypeMinecraft.BrownMushroom] = new TileTypeData() { Buildable = false, AllTextures = 29 };
            data[(int)TileTypeMinecraft.Lava] = new TileTypeData() { Buildable = false, AllTextures = 30 };
            data[(int)TileTypeMinecraft.GoldBlock] = new TileTypeData() { Buildable = false, AllTextures = 24 };
            data[(int)TileTypeMinecraft.IronBlock] = new TileTypeData() { Buildable = false, AllTextures = 23 };
            data[(int)TileTypeMinecraft.DoubleStair] = new TileTypeData() { Buildable = true, AllTextures = (0 * 16) + 5 };//43 todo
            data[(int)TileTypeMinecraft.Stair] = new TileTypeData() { Buildable = true, AllTextures = 6 };//44
            data[(int)TileTypeMinecraft.TNT] = new TileTypeData() { Buildable = true, AllTextures = (0 * 16) + 8 };//45
            data[(int)TileTypeMinecraft.Brick] = new TileTypeData() { Buildable = true, AllTextures = (6 * 16) + 7 };//46
            data[(int)TileTypeMinecraft.Bookcase] = new TileTypeData() { Buildable = true, AllTextures = (2 * 16) + 3 };//47
            data[(int)TileTypeMinecraft.MossyCobblestone] = new TileTypeData() { Buildable = true, AllTextures = (2 * 16) + 4 };//48
            data[(int)TileTypeMinecraft.Obsidian] = new TileTypeData() { Buildable = true, AllTextures = (2 * 16) + 5 };//49
            //torch todo
            //fire todo
            data[(int)TileTypeMinecraft.InfiniteWaterSource] = new TileTypeData() { Buildable = false, AllTextures = 14 };//52
            data[(int)TileTypeMinecraft.InfiniteLavaSource] = new TileTypeData() { Buildable = false, AllTextures = 30 };//53
            data[(int)TileTypeMinecraft.Chest] = new TileTypeData() { Buildable = true, AllTextures = 4 };//54
            //gear todo
            //diamond todo
            //diamond block todo
            //crafting table todo
            //crops todo
            //soil todo
            //furnace todo
            //burning furnace todo
        }
        TileTypeData[] data = new TileTypeData[256];
        class TileTypeData
        {
            public bool Buildable;
            public int TextureTop;
            public int TextureSide;
            public int TextureBottom;
            public int AllTextures
            {
                set
                {
                    TextureTop = value;
                    TextureSide = value;
                    TextureBottom = value;
                }
            }
        }
    }
    //http://www.minecraftwiki.net/wiki/Blocks,Items_%26_Data_values
    public enum TileTypeMinecraft : byte
    {
        Empty = 0,
        Stone,
        Grass,
        Dirt,
        Cobblestone,
        Wood,
        Sapling,
        Adminium,
        Water,
        StationaryWater,
        Lava,
        StationaryLava,
        Sand,
        Gravel,
        GoldOre,
        IronOre,
        CoalOre,
        TreeTrunk,
        Leaves,
        Sponge,
        Glass,
        RedCloth,
        OrangeCloth,
        YellowCloth,
        LightGreenCloth,
        GreenCloth,
        AquaGreenCloth,
        CyanCloth,
        BlueCloth,
        PurpleCloth,
        IndigoCloth,
        VioletCloth,
        //dec  hex  Block type  ,
        MagentaCloth,
        PinkCloth,
        BlackCloth,
        GrayCloth,
        WhiteCloth,
        YellowFlowerDecorations,
        RedRoseDecorations,
        RedMushroom,
        BrownMushroom,
        GoldBlock,
        IronBlock,
        DoubleStair,
        Stair,
        Brick,
        TNT,
        Bookcase,
        MossyCobblestone,
        Obsidian,
        Torch,
        FireBlock,
        InfiniteWaterSource,
        InfiniteLavaSource,
        Chest,
        Gear,
        DiamondPre,
        DiamondBlock,
        CraftingTable,
        Crops,
        Soil,
        Furnace,
        BurningFurnace,
    }
}