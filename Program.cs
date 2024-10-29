// See https://aka.ms/new-console-template for more information
using System;

                Student student= new Student();
                Admin amnManager = new Admin();
                Course course= new Course();
                Teacher teacher= new Teacher();
                Enroll enroll= new Enroll();
                Result result = new Result();
                ResultTable.CreateDatabase();
                ResultTable.ResultTb();
                // ResultTable.CreateResult(result);
                ResultTable.GetResultAndScore();
                // AdminTable.CreateAdminTb();
                // StudentTable.CreateStudentTb();
                // CourseTable.CourseTb();
                // EnrollmentTable.CreateEnrollmentTb();
                // EnrollmentTable.getTheTotalNumberOfCourseUnit();
                // EnrollmentTable.CreateEnroll(enroll);

    bool running = true;

            while (running)
            {
                Console.WriteLine("Welcome to SCHOOL ENROLLMENT APP");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. REGISTER AS A STUDENT");
                Console.WriteLine("2. REGISTER AS A TEACHER");
                Console.WriteLine("3. LOGIN AS A STUDENT");
                Console.WriteLine("4. LOGIN AS A TEACHER");
                Console.WriteLine("5. LOGIN AS ADMIN");
                Console.WriteLine("6. EXIT");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                Console.Write("Choose an option  ==> ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                     StudentTable.CreateStudent(student);
                       break;
                       case "2":
                     TeacherTable.CreateTeacher(teacher);
                       break;
                        case "5":
                        var man = AdminTable.AdminLog(amnManager) ;
                        if (true)
                        {
                            bool ami = true;
                            while (ami)
                            {
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            Console.WriteLine("1. ASSIGN TEACHER TO COURSE ");
                            Console.WriteLine("2. GET ALL COURSES AND TEACHER ASSIGNED");
                            Console.WriteLine("3. UPDATE TEACHER");
                            Console.WriteLine("4. UPDATE COURSENAME");
                            Console.WriteLine("5. UPDATE COURSECODE");
                            Console.WriteLine("6. DELETE");
                            Console.WriteLine("7. EXIT");
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");

                            Console.Write("Choose an option  ==> ");

                            Console.WriteLine("--------------------------------------------------------------------------------------------------");

                            string AdminChoice = Console.ReadLine();
                            switch (AdminChoice)
                            {
                                case "1":
                                AdminTable.CreateCourse(course);
                                break;
                                case "2":
                                 CourseTable.GetAllCourses();
                                break;
                                case "3":
                                CourseTable.UpdateCourseTeacher();
                                break;
                                case "4":
                                CourseTable.UpdateCoursename();
                                break;
                                case "5":
                                CourseTable.UpdateCoursecode();
                                break;
                                case "6":
                                CourseTable.DeleteCourse();
                                break;
                                case "7":
                                break;
                                case "8":
                                running = false;
                                break;
                                default:
                                Console.WriteLine("Invalid option.");
                                break;
                            } 
                        }
                    }
                       break;
                       
                    case "3":
                         Console.WriteLine("Enter email");
                         string email = Console.ReadLine();
                         Console.WriteLine("Enter password");
                         string password = Console.ReadLine();
                        var loggedInUser = StudentTable.Login(email , password);
                        if (loggedInUser != null )
                        {
                            bool loggedIn = true;
                            while (loggedIn)
                            {
                                Console.WriteLine("1.ENROLL FOR A COURSE");
                                Console.WriteLine("2. GET ALL COURSES AND TEACHER ASSIGNED");
                                Console.WriteLine("3. CHECK MY RESULTS");
                                Console.WriteLine("4. EXIT");
                                Console.Write("Choose an option  ==> ");
                                string loginChoice = Console.ReadLine();
                                switch (loginChoice)
                                {
                                    case "1":
                                    CourseTable.GetAllCourses();
                                    EnrollmentTable.CreateEnroll(enroll);
                                    break;

                                    case "2":
                                    EnrollmentTable.GetAllCourseAndTeacher();
                                    EnrollmentTable.getTheTotalNumberOfCourseUnit();
                                    break;

                                    case "3":
                                    ResultTable.GetResultAndScore();
                                    break;

                                    case "4":
                                    loggedIn = false;
                                    break;

                                   default:
                                   Console.WriteLine("Invalid number");
                                   break;
                                 }
                            }
                        }
                        break;
                        case "4":
                         Console.WriteLine("Enter email");
                         string email1 = Console.ReadLine();
                         Console.WriteLine("Enter password");
                         string password1 = Console.ReadLine();
                        var loggedInUser1 = TeacherTable.Login(email1 , password1);
                        if (loggedInUser1 != null )
                        {
                            bool loggedIn = true;
                            while (loggedIn)
                            {
                                Console.WriteLine("1. GET COURSE ASSIGNED TO TEACHER");
                                Console.WriteLine("2. CHECK ALL COURSES AND TEACHERS");
                                Console.WriteLine ("3. CHECK ALL STUDENT ASSIGNED TO TEACHER COURSE");
                                Console.WriteLine("4. INPUT STUDENT SCORES");
                                Console.WriteLine("5. CHECK THE RESULTS OF STUDENT BY COURSE ID");
                                Console.WriteLine("6. EXIT");
                                Console.Write("Choose an option  ==> ");
                                string loginChoice = Console.ReadLine();
                                switch (loginChoice)
                                {
                                    case "1":
                                    TeacherTable.GetTeacherCourse();
                                    break;

                                    case "2":
                                    CourseTable.GetAllCourses();
                                    break;

                                    case "3":
                                    TeacherTable.GetAllStudentOfferingMyCourse();
                                    break;

                                    case "4":
                                    ResultTable.CreateResult(result);
                                    break;
                                     
                                    case "5":
                                    ResultTable.GetResultByTeacher();
                                    break;

                                    case "6":
                                    loggedIn = false;
                                    break;

                                   default:
                                   Console.WriteLine("Invalid number");
                                   break;
                                 }
                            }
                        }
                        break;
                    case "6":
                        running = false;
                        break;
                      default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
