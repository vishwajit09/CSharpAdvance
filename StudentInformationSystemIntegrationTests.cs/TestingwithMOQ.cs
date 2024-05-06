using Moq;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories.Interfaces;
using StudentInformationSystem.Services;
using StudentInformationSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystemIntegrationTests.cs
{
    public class TestingwithMOQ
    {

        Mock<IDepartmentRepository> departmentRepositoryMock = new Mock<IDepartmentRepository>();
        Department department = new Department()
        {
            Name = "Coding",
            Lectures = new List<Lecture> { new Lecture { Name = "C#" } },
            Students = new List<Student> { new Student { Name = "Vis" } }

        };

        Mock<IStudentRepository> studentRepositoryMock = new Mock<IStudentRepository>();
        Student student = new Student()
        {
            Name = "John Doe"
        };

        [Fact]
        public void GetDepartmentByName_DepartmentName_DepartmentDetails()
        {
            // Arrange

            departmentRepositoryMock.Setup(repo => repo.GetDepartmentByName(It.IsAny<string>())).Returns(department);

            var departmentService = new DepartmentService(departmentRepositoryMock.Object);

            // Act
            var expectDepartment = departmentService.GetDepartmentByName("Coding");

            // Assert
            Assert.Equal(expectDepartment, department);

        }

        [Fact]
        public void GetDepartmentById_DepartmentId_DepartmentDetails()
        {
            departmentRepositoryMock.Setup(repo => repo.GetDepartmentById(It.IsAny<int>())).Returns(department);

            var departmentService = new DepartmentService(departmentRepositoryMock.Object);

            // Act
            var expectDepartment = departmentService.GetDepartmentByID(1);

            // Assert
            Assert.Equal(expectDepartment, department);
        }
        [Fact]
        public void CreateDepartmentId_DepartmentId_DepartmentDetails()
        {
            departmentRepositoryMock.Setup(repo => repo.AddDepartment(It.IsAny<Department>()));

            var departmentService = new DepartmentService(departmentRepositoryMock.Object);

            // Act
            departmentService.CreateDepartment(department);

            var expectDepartment = departmentService.GetDepartmentByID(0);

            // Assert
            departmentRepositoryMock.Verify(repo => repo.AddDepartment(It.IsAny<Department>()), Times.Once);
            //Assert.Equal(expectDepartment, department);
        }

        [Fact]
        public void GetStudent_StudentName_student()
        {


            studentRepositoryMock.Setup(service => service.GetStudentById(It.IsAny<int>())).Returns(student);

            var studentRepoository = studentRepositoryMock.Object;

            //Student Service Mock Setup
            var studentMockService = new Mock<StudentService>(studentRepoository);

            studentMockService.Setup(service => service.GetStudentById(It.IsAny<int>())).Returns(student);

            var studentService = studentMockService.Object;

            var expectedStudent = studentService.GetStudentById(0);

            Assert.Equal(student, expectedStudent);




        }

    }
}
