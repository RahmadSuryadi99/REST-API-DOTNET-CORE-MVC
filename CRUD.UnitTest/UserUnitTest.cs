using CRUD.Provider.UserProv;
using CRUD.Repository.UserRepo;
using System;
using Xunit.Abstractions;

namespace CRUD.UnitTest
{
    public class UserUnitTest
    {
        private readonly ITestOutputHelper _output;


        private readonly IUserProvider _userProvider;

        public UserUnitTest( ITestOutputHelper output)
        {
            _output = output;
            _userProvider = new UserProvider(new UserRepository(new DataAccess.Models.LatihanDbContext())); 
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        public void TestGetUserById(int id, int expect)
        {
            var result = _userProvider.GetUserById(id);
            Assert.NotEmpty(result.Nama);
            _output.WriteLine(result.Nama);
            //Assert.Equal(expect, result);
            //Assert.True(true);

        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(2)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {

            var result = _userProvider.IsPrime(value);

            Assert.False(result, $"gagal karna tidak false");


        }
    }
}