using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparerDomain.Model;


namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Similar_type_values_test()
        {
            
            Student first = new Student
            {
                StudentId = 1,
                StudentName = "John",
                Marks = new int[5] { 20, 75, 80, 90, 100 }

            };

            Student second = new Student
            {
                StudentId = 1,
                StudentName = "John",
                Marks = new int[5] { 20, 75, 80, 90, 100 }
            };

            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Non_similar_type_values_test()
        {
            Student first = new Student
            {
                StudentId = 1,
                StudentName = "John",
                Marks = new int[5] { 20, 75, 80, 90, 100 }

            };

            Student second = new Student
            {
                StudentId = 2,
                StudentName = "Johny",
                Marks = new int[5] { 90, 80, 100, 20, 75 }
            };

            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Similar_type_values_with_sequence_change_in_marks_test()
        {
            Student first = new Student
            {
                StudentId = 1,
                StudentName = "John",
                Marks = new int[5] { 20, 75, 80, 90, 100 }

            };

            Student second = new Student
            {
                StudentId = 1,
                StudentName = "John",
                Marks = new int[5] { 90, 80, 100, 20, 75 }
            };

            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
    }
}
