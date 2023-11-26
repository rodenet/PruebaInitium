using AutoMapper;
using Moq;
using NUnit.Framework;
using PruebaInitium.Application.DTO;
using PruebaInitium.Application.DTO.Mapper;
using PruebaInitium.Application.Services;
using PruebaInitium.Domain.Entities;
using PruebaInitium.Domain.Exceptions;
using PruebaInitium.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PruebaInitium.Application.Test
{
    public class AthleteServiceTest
    {
        Mock<IAthleteRepository> athleteRepositoryMock;
        Mock<ICountryRepository> countryRepositoryMock;
        Mock<IEntryRepository> entryRepositoryMock;

        MapperConfiguration _config;
        IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            athleteRepositoryMock = new Mock<IAthleteRepository>();
            countryRepositoryMock = new Mock<ICountryRepository>();
            entryRepositoryMock = new Mock<IEntryRepository>();

            _config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            _mapper = _config.CreateMapper();
        }

        [Test]
        public void InsertAthlete_EmptyName()
        {
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            Assert.ThrowsAsync<EmptyNameException>(async () => await athleteService.Insert(new InsertAthleteDTO()
            {
                Country = "BRA",
                Name = ""
            }));
        }

        [Test]
        public void InsertAthlete_CountryDoesNotExists()
        {
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            Assert.ThrowsAsync<CountryDoesNotExistsException>(async () => await athleteService.Insert(new InsertAthleteDTO()
            {
                Country = "BRA",
                Name = "Name"
            }));
        }

        [Test]
        public async Task InsertAthlete_Pass()
        {
            athleteRepositoryMock.Setup(x => x.Insert(It.IsAny<Athlete>())).Returns(Task.FromResult(new Athlete() { }));
            countryRepositoryMock.Setup(x => x.GetByCode(It.IsAny<string>())).Returns(Task.FromResult(new Country() { }));
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            await athleteService.Insert(new InsertAthleteDTO()
            {
                Country = "BRA",
                Name = "Name"
            });
            Assert.Pass();
        }

        [Test]
        public void InsertEntry_AthleteDoesNotExists()
        {
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            Assert.ThrowsAsync<AthleteDoesNotExistsException>(async () => await athleteService.InsertEntry(new InsertEntryDTO
            {
                AthleteId = Guid.Empty,
                Weight = 0
            }));
        }

        [Test]
        public void InsertEntry_WeightLessEqualZero()
        {

            athleteRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Athlete() { }));
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            Assert.ThrowsAsync<WeightLessEqualZeroException>(async () => await athleteService.InsertEntry(new InsertEntryDTO
            {
                AthleteId = Guid.NewGuid(),
                Weight = 0
            }));
        }

        [Test]
        public async Task InsertEntry_Pass()
        {

            athleteRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Athlete() { }));
            entryRepositoryMock.Setup(x => x.Insert(It.IsAny<Entry>())).Returns(Task.FromResult(new Entry() { }));
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            await athleteService.InsertEntry(new InsertEntryDTO
            {
                AthleteId = Guid.NewGuid(),
                Weight = 1
            });
            Assert.Pass();
        }

        [Test]
        public async Task GetAthlete_CorrectWeights()
        {
            Athlete athlete = new Athlete()
            {
                Entries = new Entry[]
                {
                    new Entry
                    {
                        Weight = 110,
                        Type = EntryType.ARRANQUE
                    },
                    new Entry
                    {
                        Weight = 120,
                        Type = EntryType.ARRANQUE
                    },
                    new Entry
                    {
                        Weight = 110,
                        Type = EntryType.ENVION
                    },
                    new Entry
                    {
                        Weight = 100,
                        Type = EntryType.ENVION
                    }
                }
            };

            athleteRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(athlete));
            IAthleteService athleteService = new AthleteService(athleteRepositoryMock.Object, countryRepositoryMock.Object, entryRepositoryMock.Object, _mapper);
            AthleteDTO result = await athleteService.Get(Guid.NewGuid());

            Assert.AreEqual(120, result.Arranque);
            Assert.AreEqual(110, result.Envion);
            Assert.AreEqual(230, result.Total);
        }
    }
}