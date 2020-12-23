using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Classroom
{
    public class Classroom : IClassroom
    {
        private readonly Dictionary<int, Student> studentsById =
            new Dictionary<int, Student>();

        private readonly Dictionary<string, Student> studentsByName =
            new Dictionary<string, Student>();

        private readonly Dictionary<Class, HashSet<Student>> classesWithStudents
            = new Dictionary<Class, HashSet<Student>>();

        private readonly Dictionary<string, Class> classesByName
            = new Dictionary<string, Class>();

        private readonly Dictionary<string, HashSet<Student>> studentsByTown
            = new Dictionary<string, HashSet<Student>>();

        private readonly Dictionary<int, HashSet<Student>> studentsByAge
            = new Dictionary<int, HashSet<Student>>();

        private readonly Dictionary<Class, HashSet<string>> classWithStudentNames =
            new Dictionary<Class, HashSet<string>>();

        private readonly HashSet<Student> allStudents =
            new HashSet<Student>();

        public void RegisterStudent(Student student, Class classToAdd)
        {
            if (this.Exists(student))
            {
                throw new ArgumentException("Student already exists!");
            }

            if (!this.classesWithStudents.ContainsKey(classToAdd))
            {
                throw new ArgumentException("Class is not present in the records!");
            }

            if (this.classWithStudentNames[classToAdd].Contains(student.Name))
            {
                throw new ArgumentException("There is already a student with this name in the class!");
            }

            if (!this.studentsByTown.ContainsKey(student.Town))
            {
                this.studentsByTown[student.Town] = new HashSet<Student>();
            }

            if (!this.studentsByAge.ContainsKey(student.Age))
            {
                this.studentsByAge[student.Age] = new HashSet<Student>();
            }

            this.classWithStudentNames[classToAdd].Add(student.Name);
            this.studentsById[student.Id] = student;
            this.classesWithStudents[classToAdd].Add(student);
            this.studentsByName[student.Name] = student;
            this.studentsByTown[student.Town].Add(student);
            this.studentsByAge[student.Age].Add(student);
            this.allStudents.Add(student);
        }

        public void CreateClass(string name)
        {
            if (this.classesByName.ContainsKey(name))
            {
                throw new ArgumentException("There is already a class with this name!");
            }

            var currentClass = new Class(name);
            this.classesByName[name] = currentClass;
            this.classesWithStudents[currentClass] = new HashSet<Student>();
            this.classWithStudentNames[currentClass] = new HashSet<string>();
        }

        public bool Exists(Student student) => this.studentsById.ContainsKey(student.Id);

        public bool Exists(Class classToSearch) => this.classesByName.ContainsKey(classToSearch.Name);

        public Student GetStudent(string name, Class studentClass)
        {
            if (!this.studentsByName.ContainsKey(name))
            {
                throw new ArgumentException("There is no student with the given name!");
            }

            if (!this.Exists(studentClass))
            {
                throw new ArgumentException("This class does not exist!");
            }

            if (!this.classWithStudentNames[studentClass].Contains(name))
            {
                throw new ArgumentException("There is no student with this name in the class!");
            }

            return this.studentsByName[name];
        }

        public Student RemoveStudent(string name, Class studentClass)
        {
            var student = this.GetStudent(name, studentClass);

            this.studentsByName.Remove(name);
            this.classesWithStudents[studentClass].Remove(student);
            this.studentsById.Remove(student.Id);
            this.studentsByTown[student.Town].Remove(student);
            this.studentsByAge[student.Age].Remove(student);
            this.allStudents.Remove(student);
            this.classWithStudentNames[studentClass].Remove(student.Name);

            return student;
        }

        public IEnumerable<Student> GetStudentsByClass(Class studentsClass)
        {
            if (!this.Exists(studentsClass))
            {
                throw new ArgumentException("This class does not exist!");
            }

            return this.classesWithStudents[studentsClass];
        }

        public IEnumerable<Student> GetStudentByTown(string town)
        {
            if (!this.studentsByTown.ContainsKey(town))
            {
                return new List<Student>();
            }

            return this.studentsByTown[town];
        }

        public void MoveClass(Class oldClass, Class newClass, string studentName)
        {
            var student = this.RemoveStudent(studentName, oldClass);
            this.RegisterStudent(student, newClass);
        }

        public IEnumerable<Student> GetAllOrderedByHeightDescThenByNameAscThenByTownNameDesc()
        {
            return this.allStudents.OrderByDescending(st => st.Height)
                .ThenBy(st => st.Name)
                .ThenByDescending(st => st.Town);
        }

        public IEnumerable<Student> GetStudentByAge(int age)
        {
            if (!this.studentsByAge.ContainsKey(age))
            {
                return new List<Student>();
            }

            return this.studentsByAge[age];
        }

        public IEnumerable<Student> GetStudentsInHeightRange(int low, int hi)
        {
            var result = new HashSet<Student>();

            foreach (var student in this.allStudents)
            {
                if (student.Height >= low && student.Height <= hi)
                {
                    result.Add(student);
                }
            }

            return result;
        }
    }
}