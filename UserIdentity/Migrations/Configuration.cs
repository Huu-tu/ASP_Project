namespace UserIdentity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UserIdentity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UserIdentity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(UserIdentity.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUser(context, "adminson@fpt.edu.vn", "257000", "Ngo Linh Son");
                CreateUser(context, "adminngoc@fpt.edu.vn", "257000", "Nguyen Minh Ngoc");
                CreateUser(context, "admintu@fpt.edu.vn", "257000", "Do Huu Tu");

                CreateUser(context, "Trainee1@fpt.edu.vn", "257000", "Tran Duc Khiem");
                CreateUser(context, "Trainee2@fpt.edu.vn", "257000", "Ngo Thanh Cong");
                CreateUser(context, "Trainee3@fpt.edu.vn", "257000", "Nguyen Phuong Thao");

                CreateUser(context, "Trainer1@fpt.edu.vn", "257000", "N T Dinh Long");
                CreateUser(context, "Trainer2@fpt.edu.vn", "257000", "D T Tung");
                CreateUser(context, "Trainer3@fpt.edu.vn", "257000", "P Thuy Duong");

                CreateUser(context, "Staff1@fpt.edu.vn", "257000", "Ngo Thi Thuy");
                CreateUser(context, "Staff2@fpt.edu.vn", "257000", "Ngo Lan Phuong");
                CreateUser(context, "Staff3@fpt.edu.vn", "257000", "Ngo Van Minh");


                CreateRole(context, "Admin");
                CreateRole(context, "Staff");
                CreateRole(context, "Trainer");
                CreateRole(context, "Trainee");


                createTrainee(context, "Tran Duc Khiem", "2000-08-08 ", "male", "0983456233", "Trainee1@fpt.edu.vn", 550, "Ha Noi");
                createTrainee(context, "Ngo Thanh Cong", "2000-08-08 ", "male", "0983456234", "Trainee2@fpt.edu.vn", 450, "Ha Noi");
                createTrainee(context, "Nguyen Phuong Thao", "2000-08-08 ", "female", "0983456235", "Trainee3@fpt.edu.vn", 480, "Ha Nam");

                createTrainer(context, "N T Dinh Long", "1986-08-08 ", "male", "0983456236", "Trainer1@fpt.edu.vn", "Ha Noi");
                createTrainer(context, "D Trung Tung", "1980-08-08 ", "male", "0983456237", "Trainer2@fpt.edu.vn", "Ha Noi");
                createTrainer(context, "P Thuy Duong", "1989-08-08 ", "female", "0983456238", "Trainer3@fpt.edu.vn", "Ha Nam");

                createStaff(context, "N T Dinh ", "1986-08-08 ", "male", "0983456239", "Staff1@fpt.edu.vn", "Ha Noi");
                createStaff(context, "D Trung ", "1980-08-08 ", "male", "0983456230", "Staff2@fpt.edu.vn", "Ha Noi");
                createStaff(context, "P Thuy ", "1989-08-08 ", "female", "0983456231", "Staff3@fpt.edu.vn", "Ha Nam");


                createTerm(context, "Spring-2020", "January, 10th", "May, 10th");
                createTerm(context, "Summer-2020", "May, 10th", "September, 10th");
                createTerm(context, "Fall-2020", "October, 1st", "December, 10th");
                createTerm(context, "Spring-2021", "January, 10th", "May, 10th");

                createTopic(context, "Java", "abcxyz");
                createTopic(context, "C#", "11111");
                createTopic(context, "C++", "22222");
                createTopic(context, "PHP", "33333");
                createTopic(context, "Python", "44444");
                createTopic(context, "English", "55555");

                AddUserToRole(context, "adminson@fpt.edu.vn", "Admin");
                AddUserToRole(context, "adminngoc@fpt.edu.vn", "Admin");
                AddUserToRole(context, "admintu@fpt.edu.vn", "Admin");

                AddUserToRole(context, "Trainee1@fpt.edu.vn", "Trainee");
                AddUserToRole(context, "Trainee2@fpt.edu.vn", "Trainee");
                AddUserToRole(context, "Trainee3@fpt.edu.vn", "Trainee");

                AddUserToRole(context, "Staff1@fpt.edu.vn", "Staff");
                AddUserToRole(context, "Staff2@fpt.edu.vn", "Staff");
                AddUserToRole(context, "Staff3@fpt.edu.vn", "Staff");

                AddUserToRole(context, "Trainer1@fpt.edu.vn", "Trainer");
                AddUserToRole(context, "Trainer2@fpt.edu.vn", "Trainer");
                AddUserToRole(context, "Trainer3@fpt.edu.vn", "Trainer");

            }
        }


        private void CreateUser(ApplicationDbContext context, string email, string password, string fullname)
        {
            
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullname
            };
            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join(";", userCreateResult.Errors));
            }

        }

        private void CreateRole (ApplicationDbContext context, string rolename)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleResult = roleManager.Create(new IdentityRole(rolename));
            if (!roleResult.Succeeded)
            {
                throw new Exception(string.Join(";", roleResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(m => m.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var addToRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addToRoleResult.Succeeded)
            {
                throw new Exception(string.Join(";", addToRoleResult.Errors));
            }
        }

        private void createTrainee(ApplicationDbContext context,string name,string dateofbirth,string gender, string phonenumber, string email, int toeic, string city)
        {
            var trainee = new Trainee();
            trainee.Name = name;
            trainee.DateOfBirth = dateofbirth;
            trainee.Gender = gender;
            trainee.PhoneNumber = phonenumber;
            trainee.Email = email;
            trainee.TOEIC = toeic;
            trainee.City = city;
            context.Trainees.Add(trainee);
        }

       
        private void createTrainer(ApplicationDbContext context, string name, string dateofbirth, string gender, string phonenumber, string email, string city)
        {
            var trainer = new Trainer();
            trainer.Name = name;
            trainer.DateOfBirth = dateofbirth;
            trainer.Gender = gender;
            trainer.PhoneNumber = phonenumber;
            trainer.Email = email;
            trainer.City = city;
            context.Trainers.Add(trainer);
        }

       
        private void createStaff(ApplicationDbContext context, string name, string dateofbirth, string gender, string phonenumber, string email, string city)
        {
            var staff = new Staff();
            staff.Name = name;
            staff.DateOfBirth = dateofbirth;
            staff.Gender = gender;
            staff.PhoneNumber = phonenumber;
            staff.Email = email;
            staff.City = city;
            context.Staffs.Add(staff);
        }
       
        private void createAdmin(ApplicationDbContext context, string name, string dateofbirth, string gender, string phonenumber, string email)
        {
            var admin = new Admin();
            admin.Name = name;
            admin.DateOfBirth = dateofbirth;
            admin.Gender = gender;
            admin.PhoneNumber = phonenumber;
            admin.Email = email;
            context.Admins.Add(admin);
        }
       
        private void createTopic(ApplicationDbContext context, string topicname, string description)
        {
            var topic = new Topic();
            topic.TopicName = topicname;
            topic.TopicDescription = description;
            context.Topics.Add(topic);
        }

       
        private void createSession(ApplicationDbContext context, string date, Course course)
        {
            var session = new Session();
            session.Date = date;
            session.Course = course;
            context.Sessions.Add(session);
        }

        
        private void createTerm (ApplicationDbContext context,string termname, string daystart, string dayfinish)
        {
            var term = new Term();
            term.TermName = termname;
            term.DayStart = daystart;
            term.DayFinish = dayfinish;
            context.Terms.Add(term);
        }
       
        private void createCourse (ApplicationDbContext context, string coursename,string coursedescription,Trainer trainer, Topic topic, Term term)
        {
            var course = new Course();
            course.CourseName = coursename;
            course.CourseDescription = coursedescription;
            course.Trainer = trainer;
            course.Topic = topic;
            course.Term = term;
            context.Courses.Add(course);
        }
            
    }
}
