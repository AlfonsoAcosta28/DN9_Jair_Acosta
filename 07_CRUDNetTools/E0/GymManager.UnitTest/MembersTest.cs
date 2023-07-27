using GymManager.Accounts.Dto;
using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using GymManager.DataAcces;
using GymManager.DataAcces.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManager.UnitTest
{
    [TestFixture]
    public class MembersTest
    {

        protected TestServer server;
        //private IMemberAppService repository;
        private GymManagerContext context;

        [OneTimeSetUp]
        [SetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var manager = server.Host.Services.GetService<GymManagerContext>();
            var ciudad = manager.Cities.Add(new City { Id = 1, Name = "Zitacuro" });
            //repository = server.Host.Services.GetService<IMemberAppService>();
            context = manager;
        }
        [Order(0)]
        [Test]
        public async Task AddMemeber_Test()
        { 

            var repository = server.Host.Services.GetService<IMemberAppService>();

            var member1 = await repository.AddMemberAsync(new MemberDto()
            {
                Name = "Diana",
                LastName = "Acosta",
                Email = "diana@gmail.com",
                Id = 1,
                City = new City
                {
                    Id = 1
                },
                AllowNewsletter = true,
                BirthDay = DateTime.Now
            });
            var result1 = await repository.GetMemberAsync(member1.Id);

            Assert.IsNotNull(result1);
            Assert.AreEqual(member1.Id, result1.Id);
            Assert.AreEqual(member1.Name, result1.Name);
            Assert.AreEqual(member1.LastName, result1.LastName);
            Assert.AreEqual(member1.City.Id, result1.City.Id);


            var member2 = await repository.AddMemberAsync(new MemberDto()
            {
                Name = "Gina",
                LastName = "Duran",
                Email = "ginaacosta07@gmail.com",
                Id = 2,
                City = new City
                {
                    Id = 1
                },
                AllowNewsletter = true,
                BirthDay = DateTime.Now
            });
            var result2 = await repository.GetMemberAsync(member2.Id);

            Assert.IsNotNull(result2);
            Assert.AreEqual(member2.Id, result2.Id);
            Assert.AreEqual(member2.Name, result2.Name);
            Assert.AreEqual(member2.LastName, result2.LastName);
            Assert.AreEqual(member2.City.Id, result2.City.Id);

        }
        [Order(1)]
        [Test]
        public async Task GetMembersAsync_Test()
        {
           var repository = server.Host.Services.GetService<IMemberAppService>();
            
            var list = await repository.GetMembersAsync();

            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 2);

            //Assert.Pass();
        }

        [Order(2)]
        [Test]
        public async Task GetMemberById_Test()
        {

            var repository = server.Host.Services.GetService<IMemberAppService>();

            var member1 = new Member {
                Name = "Diana",
                LastName = "Acosta",
                Email = "diana@gmail.com",
                Id = 1,
                City = new City
                {
                    Id = 1
                },
                AllowNewsletter = true,
                BirthDay = DateTime.Now
            };
            var result = await repository.GetMemberAsync(member1.Id);

            

            Assert.IsNotNull(result);
            Assert.AreEqual(member1.Id, result.Id);
            Assert.AreEqual(member1.Name, result.Name);
            Assert.AreEqual(member1.LastName, result.LastName);
            Assert.AreEqual(member1.City.Id, result.City.Id);

        }


        [Order(3)]
        [Test]
        public async Task EditMember_Test()
        {
            /* var repository = server.Host.Services.GetService<IMemberAppService>();
           /*
            var originalMember = await repository.AddMemberAsync(new MemberDto()
            {
                Name = "Jair",
                LastName = "Acosta",
                Email = "jair@gmail.com",
                //Id = 3,
                City = new City
                {
                    Id = 1
                },
                AllowNewsletter = true,
                BirthDay = DateTime.Now  
            });
           
            var insertEntity = await repository.GetMemberAsync(1);

            var editMember = new Member()
            {
                Name = "asd",
                LastName = "asd",
                Email = "asdf@gmail.com",
                // Id = insertEntity.Id,
                Id = 3,
                AllowNewsletter = true,
                BirthDay = DateTime.Now
            };
            var updateEntity = await repository.EditMemberAsync(editMember);

            var checkUodate = await repository.GetMemberAsync(insertEntity.Id);
            */
            //    Assert.IsNotNull(originalMember);
            // Assert.AreNotEqual(originalMember.Name, checkUpdate.Name);
            // Assert.AreNotEqual(originalMember.LastName, checkUpdate.LastName);
            // Assert.AreNotEqual(originalMember.Email, checkUpdate.Email);


            // var insertEntity = await context.Members.AddAsync(originalMember);

            var originalMember = context.Members.Find(1);

            var editMember = new Member()
            {
                Name = "asd",
                LastName = "asd",
                Email = "asdf@gmail.com",
                Id = 3,
                AllowNewsletter = true,
                BirthDay = DateTime.Now
            };
            var checkUpdate = context.Members.Update(editMember);

            Assert.IsNotNull(originalMember);
            Assert.AreNotEqual(originalMember.Name, checkUpdate.Entity.Name);
            Assert.AreNotEqual(originalMember.LastName, checkUpdate.Entity.LastName);
            Assert.AreNotEqual(originalMember.Email, checkUpdate.Entity.Email);
        }

        [Order(4)]
        [Test]
        public async Task DeleteMember_Test()
        {
            var repository = server.Host.Services.GetService<IMemberAppService>();
            var memberToDelete = new Member
            {
                Name = "ivan",
                LastName = "acosta",
                Email = "ivan@gmail.com",
                //City = new City
               // {
                 //   Id = 1
                //}

            };
            var result = context.Members.Add(memberToDelete);
            // int memberIdToDelete = 1;
            //var memberToDelete = await context.Members.FindAsync(memberIdToDelete);
            /*var memberToDelete = new Member
            {
                Name = "ivan",
                LastName = "acosta",
                Email = "ivan@gmail.com",
                Id = 4,
            };
            */
            //await context.Members.AddAsync(memberToDelete);
            //await context.SaveChangesAsync();
            var memberFind = await context.Members.FindAsync(memberToDelete.Id);
            if (memberToDelete != null)
            {
                // context.Members.Remove(memberToDelete);
                // await context.SaveChangesAsync();
                var eliminado = repository.DeleteMemberAsync(memberFind.Id);
                var result2 = await context.Members.FindAsync(memberFind.Id);

                Assert.IsNull(result2);
            }
            else
            {
                Assert.Fail($"Member with Id {memberToDelete} not found in the database.");
            }

        }
    }
}