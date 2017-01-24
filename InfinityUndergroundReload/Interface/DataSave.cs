
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace InfinityUndergroundReload.Interface
{
    public class DataSave
    {
        //const string fileName = "../../../../../save/Character.save";
        const string fileName = "../../../save/Character.save";
        InfinityUnderground _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSave"/> class.
        /// </summary>
        /// <param name="Context">The context.</param>
        public DataSave(InfinityUnderground Context)
        {
            _context = Context;
            if (File.Exists(fileName)) IsExistSave = true;
            else IsExistSave = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether if is exist save.
        /// </summary>
        public bool IsExistSave { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        private string LEVEL { get; set; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        /// <value>
        /// The damage.
        /// </value>
        private string DAMAGE { get; set; }

        /// <summary>
        /// Gets or sets the criticalchance.
        /// </summary>
        /// <value>
        /// The criticalchance.
        /// </value>
        private string CRITICALCHANCE { get; set; }

        /// <summary>
        /// Gets or sets the attackspeed.
        /// </summary>
        /// <value>
        /// The attackspeed.
        /// </value>
        private string ATTACKSPEED { get; set; }

        /// <summary>
        /// Gets or sets the armor.
        /// </summary>
        /// <value>
        /// The armor.
        /// </value>
        private string ARMOR { get; set; }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        private string RANGE { get; set; }

        /// <summary>
        /// Gets or sets the lifepoint.
        /// </summary>
        /// <value>
        /// The lifepoint.
        /// </value>
        private string LIFEPOINT { get; set; }


        /// <summary>
        /// Gets or sets the lifepoint.
        /// </summary>
        /// <value>
        /// The lifepoint.
        /// </value>
        private string MAXLIFEPOINT { get; set; }

        /// <summary>
        /// Writes the values.
        /// </summary>
        public void WriteValuesInTheFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(LEVEL);
                writer.Write(DAMAGE);
                writer.Write(CRITICALCHANCE);
                writer.Write(ATTACKSPEED);
                writer.Write(ARMOR);
                writer.Write(RANGE);
                writer.Write(LIFEPOINT);
                writer.Write(MAXLIFEPOINT);
            }
        }

        public void LoadValuesOfThePlayerInTheClass()
        {
            LEVEL = _context.WorldAPI.GetMaxLevel.ToString();
            DAMAGE = _context.WorldAPI.Player.CharacterType.Damage.ToString();
            CRITICALCHANCE = _context.WorldAPI.Player.CharacterType.CriticalChance.ToString();
            ATTACKSPEED = _context.WorldAPI.Player.CharacterType.AttackSpeed.ToString();
            ARMOR = _context.WorldAPI.Player.CharacterType.Armor.ToString();
            RANGE = _context.WorldAPI.Player.CharacterType.Range.ToString();
            LIFEPOINT = _context.WorldAPI.Player.CharacterType.LifePoint.ToString();
            MAXLIFEPOINT = _context.WorldAPI.Player.CharacterType.MaxLifePoint.ToString();
        }

        /// <summary>
        /// Displays the values.
        /// </summary>
        public void LoadValuesFromTheFile()
        {
            if (File.Exists(fileName))
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    LEVEL = reader.ReadString().ToString();
                    DAMAGE = reader.ReadString().ToString();
                    CRITICALCHANCE = reader.ReadString().ToString();
                    ATTACKSPEED = reader.ReadString().ToString();
                    ARMOR = reader.ReadString().ToString();
                    RANGE = reader.ReadString().ToString();
                    LIFEPOINT = reader.ReadString().ToString();
                    MAXLIFEPOINT = reader.ReadString().ToString();
                }
        }

        /// <summary>
        /// Sets the values in the player.
        /// </summary>
        public void SetValuesInThePlayer()
        {
            _context.WorldAPI.GetMaxLevel = Convert.ToInt32(LEVEL);
            _context.WorldAPI.Player.CharacterType.Damage = Convert.ToInt32(DAMAGE);
            _context.WorldAPI.Player.CharacterType.CriticalChance = Convert.ToDouble(CRITICALCHANCE);
            _context.WorldAPI.Player.CharacterType.AttackSpeed = Convert.ToDouble(ATTACKSPEED);
            _context.WorldAPI.Player.CharacterType.Armor = Convert.ToDouble(ARMOR);
            _context.WorldAPI.Player.CharacterType.Range = Convert.ToInt32(RANGE);
            _context.WorldAPI.Player.CharacterType.LifePoint = Convert.ToInt32(LIFEPOINT);
            _context.WorldAPI.Player.CharacterType.MaxLifePoint = Convert.ToInt32(MAXLIFEPOINT);
        }
    }
}