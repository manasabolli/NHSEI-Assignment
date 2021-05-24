using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WebAi.IRepository;
using WebApi.Controllers;
using WebApi.Models;

namespace NUnitTest
{
    [TestFixture]
    public class AssignmentControllerUnitTest
    {
        public  Mock<IRepositoryAssignment> _repo = new Mock<IRepositoryAssignment>();        
        private RequestModel requestModel;
        private GetResponse getResponse;       
        public AssignmentControllerUnitTest(IRepositoryAssignment _repo)
        {
            this._repo = (Mock<IRepositoryAssignment>)_repo;
            requestModel = new RequestModel()
            {
                BusinessUnit = "<BusinessUnit>",
                ExpiryDate = DateTime.Now,
            };             
            
        }

        [Test]
        public void PostBatchIDreturntrue(RequestModel model)
        {
            var controller = new AssignmentController(_repo.Object);
            Respnse obj = new Respnse();
            _repo.Setup(p => p.PostBatchID(It.IsAny<RequestModel>())).Returns(obj);
            //Act
            var result = controller.PostBatchID(model);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf((Type)result, typeof(Microsoft.AspNetCore.Mvc.IActionResult));
            var actualResult = (Microsoft.AspNetCore.Mvc.OkObjectResult)result;
            Assert.AreEqual(actualResult.StatusCode, 200);
            Assert.IsInstanceOf((Type)actualResult.Value, typeof(Respnse));

        }

        [Test]
        public void PostBatchIDreturnfalse(RequestModel model)
        {
            var controller = new AssignmentController(_repo.Object);
            Respnse obj = null;
            _repo.Setup(p => p.PostBatchID(It.IsAny<RequestModel>())).Returns(obj);
            //Act
            var result = controller.PostBatchID(model);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf((Type)result, typeof(Microsoft.AspNetCore.Mvc.IActionResult));
            var actualResult = (Microsoft.AspNetCore.Mvc.BadRequestResult)result;
            Assert.AreEqual(actualResult.StatusCode, 400);
           // Assert.IsInstanceOf((Type)actualResult.Value, typeof());

        }
        [Test]
        public void GetBatchDetailstrue(Guid batchid)
        {
            var controller = new AssignmentController(_repo.Object);
            batchid = new Guid();
            GetResponse obj = new GetResponse();
            _repo.Setup(p => p.GetBatchDetails(It.IsAny<Guid>())).Returns(obj);
            //Act
            var result = controller.GetBatchDetails(batchid);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf((Type)result, typeof(Microsoft.AspNetCore.Mvc.IActionResult));
            var actualResult = (Microsoft.AspNetCore.Mvc.OkObjectResult)result;
            Assert.AreEqual(actualResult.StatusCode, 200);
            Assert.IsInstanceOf((Type)actualResult.Value, typeof(Respnse));

        }

    }
}
