using Kepler_22_B.API;
using Kepler_22_B.API.Map;
using Kepler_22_B.API.Characteres;
using NUnit.Framework;
using Microsoft.Xna.Framework;

namespace Kepler_22_B.Tests
{
    [TestFixture]
    class MapTests
    {
        /// <summary>
        /// Whens a boss room is créate have path.
        /// </summary>
        [Test]
        public void WhenABossRoomIsCréateHavePath()
        {
            BossRoom sut = new BossRoom();

            Assert.That(sut.Path, Is.Not.Null);
        }

        /// <summary>
        /// Whens a labyrinthe room is créate have path.
        /// </summary>
        [Test]
        public void WhenALabyrintheRoomIsCréateHavePath()
        {
            LabyrintheRoom sut = new LabyrintheRoom();

            Assert.That(sut.Path, Is.Not.Null);
        }

        /// <summary>
        /// Whens a Monster room is créate have path.
        /// </summary>
        [Test]
        public void WhenAMonsterRoomIsCréateHavePath()
        {
            MonsterRoom sut = new MonsterRoom();

            Assert.That(sut.Path, Is.Not.Null);
        }


        /// <summary>
        /// Whens a secret room is créate have path.
        /// </summary>
        [Test]
        public void WhenASecretRoomIsCréateHavePath()
        {
            SecretRoom sut = new SecretRoom();

            Assert.That(sut.Path, Is.Not.Null);
        }


        /// <summary>
        /// Whens a trap room is créate have path.
        /// </summary>
        [Test]
        public void WhenATrapRoomIsCréateHavePath()
        {
            SecretRoom sut = new SecretRoom();

            Assert.That(sut.Path, Is.Not.Null);
        }

        /// <summary>
        /// Selects a type of room.
        /// </summary>
        [Test]
        public void SelectATypeOfRoom()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            sut.CreateRoom();

            Assert.That(sut.TypeOfRoom, Is.Not.Null);
        }

        /// <summary>
        /// Addeds the new door to the room.
        /// </summary>
        [Test]
        public void AddedNewDoorToTheRoom()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            sut.AddDoor(new Vector2(0, 0), new Vector2(5, 5), DoorDirection.Top);

            Assert.That(sut.FirstDoor, Is.Not.Null);
        }


        /// <summary>
        /// Addeds the new door to the room.
        /// </summary>
        [Test]
        public void ClearTheFirstRoomDeleteAllDoor()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            sut.AddDoor(new Vector2(0, 0), new Vector2(5, 5), DoorDirection.Top);

            sut.ClearDoor();

            Assert.That(sut.FirstDoor, Is.Null);
        }



        /// <summary>
        /// Addeds the new door to the room is the same.
        /// </summary>
        [Test]
        public void AddedNewDoorToTheRoomAsTheSameVector()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            Door door = new Door(new Vector2(0, 0), new Vector2(5, 5), DoorDirection.Top);
            sut.AddDoor(new Vector2(0, 0), new Vector2(5, 5), DoorDirection.Top);

            Assert.That(sut.FirstDoor.LowerThan, Is.EqualTo(door.LowerThan));
        }


        /// <summary>
        /// Tests if the player are in one door.
        /// </summary>
        [Test]
        public void TestIfThePlayerAreInOneDoor()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            sut.AddDoor(new Vector2(25, 0), new Vector2(27, 2), DoorDirection.Top);

            sut.Context.World.Players[0].PositionX = 830;
            sut.Context.World.Players[0].PositionY = 10;

            Assert.That(sut.PlayerInTheDoor(), Is.SameAs(sut.FirstDoor));
        }


        /// <summary>
        /// Tests the vector for change room.
        /// </summary>
        [Test]
        public void TestVectorForChangeRoom()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            sut.AddDoor(new Vector2(49, 49), new Vector2(51, 51), DoorDirection.Bottom);

            int lastPos = (int)sut.PosCurrentRoom.Y;

            sut.changeVectorCurrentRoom(sut.PlayerInTheDoor());

            Assert.That((int)sut.PosCurrentRoom.Y, Is.EqualTo(lastPos+1));
        }


        /// <summary>
        /// Counts the door who not send to the negative Vector room.
        /// </summary>
        [Test]
        public void CountTheDoorWhoWasCreateWithoutVectorRoomNegatif()
        {
            int countDoorEstmating = 2;

            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            sut.ChangeRoom();
            sut.Context.GetCurrentlevel = 5;
            sut.CreateRoomOut();

            Door currentDoor = sut.FirstDoor;
            int countDoor = 0;

            while (currentDoor != null)
            {
                countDoor++;
                currentDoor = currentDoor.NextDoor;
            }

            Assert.That(countDoor, Is.EqualTo(countDoorEstmating));
        }


        /// <summary>
        /// Incrementes the level.
        /// </summary>
        [Test]
        public void IncrementeTheLevel()
        {
            RoomInLevel sut = new RoomInLevel(new Level(new World()));

            int currentLevel = sut.Context.GetCurrentlevel;

            sut.RoomForNextLevel();

            Assert.That(sut.Context.GetCurrentlevel, Is.EqualTo(currentLevel+1));

        }

        /// <summary>
        /// Tests the convertion pixe in tiles for the position x of the player.
        /// </summary>
        [Test]
        public void TestTheConvertionPixeInTilesForThePositionXOfThePlayer()
        {
            int tilesWidth = 32;

            World sut = new World();

            sut.Players[0] = new CTPlayer(128, 256);

            int posX = (sut.Players[0].PositionX / tilesWidth)+1;
            int posY = (sut.Players[0].PositionY / tilesWidth)+1;

            Assert.That(sut.Player1PositionXInTile, Is.EqualTo(posX));
            Assert.That(sut.Player1PositionYInTile, Is.EqualTo(posY));

        }


        /// <summary>
        /// Tests if the player can go under ground.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanGoUnderGround()
        {
            World sut = new World();

            sut.Players[0] = new CTPlayer(288, 576);

            Assert.That(sut.AccessUnderground(), Is.True);

        }



    }
}
