using Xunit;
using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.ValueObjects;
using Domain.Entities.Documents;

namespace Domain.Tests
{
    public class RequestTests
    {
        [Fact]
        public void SetIssueId_ReturnsRequestWithCorrectIssuerId()
        {
            //Arrange
            var req = CreateRequestInstance();

            //Act
            req.SetIssueId(1);

            //Assert
            Assert.Equal(1, req.IssuerId);
        }

        [Fact]
        public void SetPrice_ReturnsRequestWithCorrectPrice()
        {
            //Arrange
            var req = CreateRequestInstance();

            //Act
            req.SetPrice(100);

            //Assert
            Assert.Equal(100, req.Price);
        }

        [Fact]
        public void SetPostalFees_ReturnsRequestWithCorrectPostalFees()
        {
            //Arrange
            var req = CreateRequestInstance();

            //Act
            req.SetPostalFees(100);

            //Assert
            Assert.Equal(100, req.PostalFees);
        }

        [Fact]
        public void AddRequestState_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            RequestState reqState1 = new RequestState();
            RequestState reqState2 = new RequestState();

            //Act
            req.AddRequestState(reqState1);
            req.AddRequestState(reqState2);

            //Assert
            Assert.Equal(2, req.RequestStates.Count);
        }

        [Fact]
        public void AddPaymentDetail_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            PaymentDetails paymentDetails1 = new PaymentDetails();
            PaymentDetails paymentDetails2 = new PaymentDetails();

            //Act
            req.AddPaymentDetail(paymentDetails1);
            req.AddPaymentDetail(paymentDetails2);

            //Assert
            Assert.Equal(2, req.PaymentDetails.Count);
        }

        [Fact]
        public void AddWorkPermitRenewDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            WorkPermitRenew doc = new WorkPermitRenew();

            //Act
            req.AddWorkPermitRenewDoc(doc);

            //Assert
            Assert.Equal(1, req.WorkPermitRenews.Count);
        }

        [Fact]
        public void AddWorkPermitReplaceDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            WorkPermitReplace doc = new WorkPermitReplace();

            //Act
            req.AddWorkPermitReplaceDoc(doc);

            //Assert
            Assert.Equal(1, req.WorkPermitReplaces.Count);
        }

        [Fact]
        public void AddDWorkPermitClearanceDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            WorkPermitClearance doc = new WorkPermitClearance();

            //Act
            req.AddDWorkPermitClearanceDoc(doc);

            //Assert
            Assert.Equal(1, req.WorkPermitClearances.Count);
        }

        [Fact]
        public void AddCriminalStateRecordDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            CriminalStateRecord doc = new CriminalStateRecord();

            //Act
            req.AddCriminalStateRecordDoc(doc);

            //Assert
            Assert.Equal(1, req.CriminalStateRecords.Count);
        }

        [Fact]
        public void AddBirthDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            BirthDoc doc = new BirthDoc();

            //Act
            req.AddBirthDoc(doc);

            //Assert
            Assert.Equal(1, req.BirthDocs.Count);
        }

        [Fact]
        public void AddDeathRecordDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            DeathDoc doc = new DeathDoc();

            //Act
            req.AddDeathRecordDoc(doc);

            //Assert
            Assert.Equal(1, req.DeathDocs.Count);
        }

        [Fact]
        public void AddDivorceRecordDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            DivorceDoc doc = new DivorceDoc();

            //Act
            req.AddDivorceRecordDoc(doc);

            //Assert
            Assert.Equal(1, req.DivorceDocs.Count);
        }

        [Fact]
        public void AddFamilyRecordDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            FamilyRecord doc = new FamilyRecord();

            //Act
            req.AddFamilyRecordDoc(doc);

            //Assert
            Assert.Equal(1, req.FamilyRecords.Count);
        }

        [Fact]
        public void AddMarriageRecordDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            MarriageDoc doc = new MarriageDoc();

            //Act
            req.AddMarriageRecordDoc(doc);

            //Assert
            Assert.Equal(1, req.MarriageDocs.Count);
        }

        [Fact]
        public void AddNidDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            NidDoc doc = new NidDoc();

            //Act
            req.AddNidDoc(doc);

            //Assert
            Assert.Equal(1, req.NidDoc.Count);
        }

        [Fact]
        public void AddPersonalRecordDoc_ReturnsRequestWithCorrectCount()
        {
            //Arrange
            var req = CreateRequestInstance();
            PersonalRecord doc = new PersonalRecord();

            //Act
            req.AddPersonalRecordDoc(doc);

            //Assert
            Assert.Equal(1, req.PersonalRecords.Count);
        }

        [Fact]
        public void ChangePaymentMethod_ReturnsRequestWithCorrectPaymentMethod()
        {
            //Arrange
            var req = CreateRequestInstance();
            PaymentMethod paymentMethod = new PaymentMethod() { Code = "100" };

            //Act
            req.ChangePaymentMethod(paymentMethod);

            //Assert
            Assert.Equal("100", req.PaymentMethod.Code);
        }

        private Request CreateRequestInstance()
        {
            var request = new Request("code",
                new RequesterName("hamdy", "ahmed", "abdo", "abdo"),
                "fatema",
                new Gender(),
                new NID("28410071402991"),
                new ContactDetails("01009868724", null, null, null, "h@h.h"),
                new Address(),
                new Address(),
                new PaymentMethod(),
                new Issuer());

            return request;
        }
    }
}
