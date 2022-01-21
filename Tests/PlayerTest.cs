using NUnit.Framework;
using System;
using System.Linq;
using Domain.Entities;
using Repository.Repositories;
using Repository;

namespace Tests
{
    public class PlayerTest
    {
        private readonly PlayerRepository _playerRepository;

        public PlayerTest()
        {
            _playerRepository = new PlayerRepository();
            RegisterMappings.Register();
        }


        [Test]
        public void GetAll()
        {
            try
            {
                var result = _playerRepository.GetAll().ToList();

                Assert.IsTrue(result.Any());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void GetById()
        {
            try
            {
                var player = _playerRepository.GetById(2);
                Assert.AreEqual(2, player.Id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void Insert()
        {
            try
            {
                var player = new Player
                {
                    Age = 38,
                    Name = "NOVO JOGADOR",
                    TeamId = 2
                };

                _playerRepository.Insert(ref player);

                Assert.IsTrue(player.Id != 0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void Update()
        {
            try
            {
                var player = _playerRepository.GetById(4);

                player.Name = "ALTERADO";

                Assert.IsTrue(_playerRepository.Update(player));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void Delete()
        {
            try
            {
                Assert.IsTrue(_playerRepository.Delete(8));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void GetList()
        {
            try
            {
                var result = _playerRepository.GetList(x => x.Age > 25).ToList();
                Assert.IsTrue(result.Any());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}