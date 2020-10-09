using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Timelogger.Entities;

namespace Timelogger.Api.Tests
{
  public class TimeRegistrationSaveBusinessServiceTests
  {
    private ITimeRegistrationSaveBusinessService _service;
    private Mock<IProjectLoader> _loader;
    private Mock<ITimeRegistrationSaver> _saver;
    private Mock<IDateTimeService> _dateTimeService;

    [SetUp]
    public void Initialize()
    {
      _loader = new Mock<IProjectLoader>();
      _saver = new Mock<ITimeRegistrationSaver>();
      _dateTimeService = new Mock<IDateTimeService>();
      _service = new TimeRegistrationSaveBusinessService(
        _loader.Object,
        _saver.Object,
        _dateTimeService.Object);
    }

    [Test]
    public void Execute_ShouldReturnTrue_WhenTimeRegistrationCanBeSaved()
    {
      var project = new Project
      {
        Deadline = new DateTime(2020, 1, 2)
      };
      _loader.Setup(mock => mock.Load(1)).Returns(project);
      _dateTimeService.Setup(mock => mock.GetUtcNow()).Returns(new DateTime(2020, 1, 1));
      var timeRegistration = new TimeRegistrationModel();

      var result = _service.Execute(1, timeRegistration);

      result.Should().BeTrue();
      _loader.Verify(mock => mock.Load(1), Times.Once);
      _dateTimeService.Verify(mock => mock.GetUtcNow(), Times.Once);
      _saver.Verify(mock => mock.Save(project, timeRegistration), Times.Once);
    }

    [Test]
    public void Execute_ShouldReturnFalse_WhenProjectDoesNotExist()
    {
      _loader.Setup(mock => mock.Load(1)).Returns((Project)null);
      var timeRegistration = new TimeRegistrationModel();

      var result = _service.Execute(1, timeRegistration);

      result.Should().BeFalse();
      _loader.Verify(mock => mock.Load(1), Times.Once);
      _dateTimeService.Verify(mock => mock.GetUtcNow(), Times.Never);
      _saver.Verify(mock => mock.Save(null, timeRegistration), Times.Never);
    }

    [Test]
    public void Execute_ShouldReturnFalse_WhenProjectDeadlineHasPassed()
    {
      Project project = new Project
      {
        Deadline = new DateTime(2020, 1, 1)
      };
      _loader.Setup(mock => mock.Load(1)).Returns(project);
      _dateTimeService.Setup(mock => mock.GetUtcNow()).Returns(new DateTime(2020, 1, 2));
      var timeRegistration = new TimeRegistrationModel();

      var result = _service.Execute(1, timeRegistration);

      result.Should().BeFalse();
      _loader.Verify(mock => mock.Load(1), Times.Once);
      _dateTimeService.Verify(mock => mock.GetUtcNow(), Times.Once);
      _saver.Verify(mock => mock.Save(null, timeRegistration), Times.Never);
    }
  }
}