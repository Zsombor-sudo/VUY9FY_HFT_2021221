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
    [TestFixture]
    public class Tester
    {
        SongLogic sLogic;
        SongLogic bLogic;
        public Tester()
        {
            Mock<ISongRepository> mock = new Mock<ISongRepository>();

            artist fakeArtist = new artist()
            {
                IsBand = true,
                Id = 100,
                Name = "Gizik"
            };

            
            list fakeList1 = new list()
            {
                Score = 5,
                SongId = 100,
                Year = 2021
            };
            list fakeList2 = new list()
            {
                Score = 1,
                SongId = 101,
                Year = 2021
            };

            mock.Setup((x) => x.Create(It.IsAny<song>()));
            mock.Setup((x) => x.GetAll()).Returns(
                new List<song>
                {
                    new song(){
                        SongId = 100,
                        ArtistId = 100,
                        Title = "Bokros dal",
                        Release = 2021,
                        Artist = fakeArtist,
                        Score = fakeList1,
                    },
                    new song(){
                        SongId = 101,
                        ArtistId = 100,
                        Title = "Rossz dal",
                        Release = 2020,
                        Artist = fakeArtist,
                        Score = fakeList2,
                    }
                }.AsQueryable());

            

            sLogic = new SongLogic(mock.Object);
        }

        [TestCase("Bokros dal",true)]
        [TestCase("Rossz dal", false)]
        public void WasSongNominatedInSameYearTest(string title, bool presult)
        {
            //ACT 
            var result = sLogic.WasSongNominatedInSameYear(title);

            //ASSERT
            Assert.That(result, Is.EqualTo(presult));
        }
        [TestCase("Bokros dal", 2021, true)]
        [TestCase("Rossz dal", 2021, false)]
        public void WasSongsNomininatedInYearTest(string title, int year, bool presult)
        {
            //ACT 
            var result = sLogic.WasSongsNomininatedInYear(title, year);

            //ASSERT
            Assert.That(result, Is.EqualTo(presult));
        }
        public void SongScored5Test()
        {
            //ACT 
            var result = sLogic.SongScored5();
            var presult = new List<string> { "Bokros dal" };
            //ASSERT
            Assert.That(result, Is.EqualTo(presult));
        }
        public void SongsByBandsTest()
        {
            //ACT 
            var result = sLogic.SongsByBands();

            //ASSERT
            Assert.That(result, Is.EqualTo(new List<string> { "Bokros dal", "Rossz dal" }));
        }
        public void SongsByBandsCountTest()
        {
            //ACT 
            var result = sLogic.SongsByBandsCount();

            //ASSERT
            Assert.That(result, Is.EqualTo(2));
        }
        public void SongScoreAvgTest()
        {
            //ACT
            var result = sLogic.SongScoreAvg();

            //ASSERT
            Assert.That(result, Is.EqualTo(3));
        }
        [TestCase(2020, true)]
        [TestCase(3052, false)]
        public void CreateSongTest(int release, bool result)
        {
            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => sLogic.Create(new song()
                {
                    Title = "Riptide",
                    Release = release
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => sLogic.Create(new song()
                {
                    Title = "Strange",
                    Release = release
                }), Throws.Exception);
            }
        }
        [TestCase(2020, true)]
        [TestCase(3052, false)]
        public void UpdateSongTest(int release, bool result)
        {
            //ACT + ASSERT
            if (result)
            {
                Assert.That(() => sLogic.Update(new song()
                {
                    Title = "Riptide",
                    Release = release
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => sLogic.Update(new song()
                {
                    Title = "Strange",
                    Release = release
                }), Throws.Exception);
            }
        }
        [TestCase(100, true)]
        [TestCase(999, false)]
        public void GetOneSongTest(int id, bool result)
        {
            if (result)
            {
                Assert.That(() => sLogic.GetOne(id), Throws.Nothing);
            }
            else
            {
                Assert.That(() => sLogic.GetOne(id), Throws.Exception);

            }
        }
        [TestCase(100, true)]
        [TestCase(999, false)]
        public void DeleteSongTest(int id, bool result)
        {
            if (result)
            {
                Assert.That(() => sLogic.Delete(id), Throws.Nothing);
            }
            else
            {
                Assert.That(() => sLogic.Delete(id), Throws.Exception);

            }
        }


    }
}
