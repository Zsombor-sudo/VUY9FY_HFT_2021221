using NUnit.Framework;
using System;
using Moq;
using VUY9FY_HFT_2021221.Logic;
using static VUY9FY_HFT_2021221.Repository.IRepository;
using VUY9FY_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace VUY9FY_HFT_2021221.Test
{
    //10 teszt kell
    [TestFixture]
    public class Tester
    {
        SongLogic sLogic;
        ArtistLogic aLogic;

        [SetUp]
        public void Init()
        {
            var mockSongRepository = new Mock<ISongRepository>();
            var mockArtistRepository = new Mock<IArtistRepository>();

            artist fakeArtist = new artist();
            fakeArtist.Id = 1;
            fakeArtist.Name = "Adel";
            fakeArtist.IsBand = true;
            var songs = new List<song>()
            {
                new song()
                {
                    SongId = 1,
                    Title = "Someone Like You",
                    Artist = fakeArtist,
                    ArtistId = 1,
                    Release = 2011,
                    Score = new list()
                    {
                        Year = 2011,
                        Score = 1,
                        SongId = 1
                    }
                },
                new song()
                {
                    SongId = 2,
                    Title = "Skyfall",
                    Artist = fakeArtist,
                    ArtistId = 1,
                    Release = 2012,
                    Score = new list()
                    {
                        Year = 2012,
                        Score = 2,
                        SongId = 2
                    }
                }
            }.AsQueryable();
            fakeArtist.Songs = songs.ToArray();

            mockSongRepository.Setup((t) => t.GetAll()).Returns(songs);
            sLogic = new SongLogic(mockSongRepository.Object);
            mockArtistRepository.Setup((t) => t.GetAll()).Returns((IQueryable<artist>)fakeArtist);
            aLogic = new ArtistLogic(mockArtistRepository.Object);
        }

        [Test]
        public void ArtistCountByIsBandTest()
        {
            //ACT 
            var result = aLogic.ArtistCountByIsBand();

            //ASSERT
            var expected = new List<KeyValuePair<bool, int>>()
            {
                new KeyValuePair<bool, int>
                (true, 1)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void SongsByYearCountTest()
        {
            //ACT 
            var result = sLogic.SongsByYearCount(2011);

            //ASSERT
            Assert.That(result, Is.EqualTo(1));

        }
        [Test]
        public void IsSongByBandTest()
        {
            //ACT 
            var result = sLogic.IsSongByBand("Someone Like You");

            //ASSERT
            Assert.That(result, Is.EqualTo(true));

        }
        [Test]
        public void GetOneTest()
        {
            //ACT 
            var result = sLogic.GetOne(1);
            artist fakeArtist = new artist();
            fakeArtist.Id = 1;
            fakeArtist.Name = "Adel";
            fakeArtist.IsBand = true;
            var songs = new List<song>()
            {
                new song()
                {
                    SongId = 1,
                    Title = "Someone Like You",
                    Artist = fakeArtist,
                    ArtistId = 1,
                    Release = 2011,
                    Score = new list()
                    {
                        Year = 2011,
                        Score = 1,
                        SongId = 1
                    }
                },
                new song()
                {
                    SongId = 2,
                    Title = "Skyfall",
                    Artist = fakeArtist,
                    ArtistId = 1,
                    Release = 2012,
                    Score = new list()
                    {
                        Year = 2012,
                        Score = 2,
                        SongId = 2
                    }
                }
            }.AsQueryable();
            fakeArtist.Songs = songs.ToArray();

            //ASSERT
            Assert.That(result, Is.EqualTo(fakeArtist.Songs.First(x => x.SongId == 1)));
        }
        [Test]
        public void GetAllTest()
        {
            //ACT 
            var result = sLogic.GetAll();
            artist fakeArtist = new artist();
            fakeArtist.Id = 1;
            fakeArtist.Name = "Adel";
            fakeArtist.IsBand = true;
            var songs = new List<song>()
            {
                new song()
                {
                    SongId = 1,
                    Title = "Someone Like You",
                    Artist = fakeArtist,
                    ArtistId = 1,
                    Release = 2011,
                    Score = new list()
                    {
                        Year = 2011,
                        Score = 1,
                        SongId = 1
                    }
                },
                new song()
                {
                    SongId = 2,
                    Title = "Skyfall",
                    Artist = fakeArtist,
                    ArtistId = 1,
                    Release = 2012,
                    Score = new list()
                    {
                        Year = 2012,
                        Score = 2,
                        SongId = 2
                    }
                }
            }.AsQueryable();
            fakeArtist.Songs = songs.ToArray();

            //ASSERT
            Assert.That(result, Is.EqualTo(fakeArtist.Songs));
        }
    }
}
