using Churras.Models;
// <copyright file="ChurrascoServiceTest.cs">Copyright ©  2017</copyright>

using System;
using Churras.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Churras.Data;

namespace Churras.Tests
{
    [TestClass]
    [PexClass(typeof(ChurrascoService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ChurrascoServiceTest
    {
        public ChurrascoServiceTest()
        {

        }

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public void DeleteParticipante(
            [PexAssumeUnderTest]ChurrascoService target,
            int key,
            int churrascoKey
        )
        {
            target.DeleteParticipante(key, churrascoKey);
            // TODO: add assertions to method ChurrascoServiceTest.DeleteParticipante(ChurrascoService, Int32, Int32)
        }

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public ChurrascoDashboard GetChurrascoDashboard([PexAssumeUnderTest]ChurrascoService target)
        {
            IUnityContainer myContainer = new UnityContainer();

            //myContainer.RegisterType<IRepository<Churrasco>, FakeRepository<Churrasco>>();
            //myContainer.RegisterType<IRepository<Participante>, FakeRepository<Participante>>();


            //MyClass classUnderTest = new MyClass(myContainer);
            //classUnderTest.DoWork();

            ChurrascoDashboard result = target.GetChurrascoDashboard();
            return result;
            // TODO: add assertions to method ChurrascoServiceTest.GetChurrascoDashboard(ChurrascoService)
        }
    }
}
